using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Pages;
using DMToolKit.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace DMToolKit.ViewModels
{
    public partial class NameGeneratorOptionsViewModel : ObservableObject
    {
        [ObservableProperty]
        List<string> lockedLetterList;

        [ObservableProperty]
        int selectedIndex;

        [ObservableProperty]
        bool letterLock;

        [ObservableProperty]
        bool prefixLock;

        [ObservableProperty]
        bool nameSeedsShown;

        [ObservableProperty]
        public string lockedPrefix;

        [ObservableProperty]
        public ObservableCollection<string> prefixList;

        [ObservableProperty]
        public string prefixToAdd;

        [ObservableProperty]
        public string suffixToAdd;

        [ObservableProperty]
        public string prefixCount;

        [ObservableProperty]
        public string suffixCount;

        DataController DataController;

        public NameGeneratorOptionsViewModel() 
        {
            DataController = DataController.Instance;
            SelectedIndex = 0;
            LetterLock = false;
            PrefixLock = false;
            NameSeedsShown = true;
            PrefixList = new ObservableCollection<string>();
            PrefixToAdd = string.Empty;
            SuffixToAdd = string.Empty;
            LockedPrefix = string.Empty;
            PrefixCount = $"{DataController.NameSeedData.PrefixList.Count}";
            SuffixCount = $"{DataController.NameSeedData.SuffixList.Count}";
            LockedLetterList = new List<string>()
            {
                "A", "B", "C", "D", "E",
                "F", "G", "H", "I", "J",
                "K", "L", "M", "N", "O",
                "P", "Q", "R", "S", "T",
                "U", "V", "W", "X", "Y", "Z"
            };

            if (DataController.NameSeedData.PrefixList.Count == 0)
                return;

            PrefixList.Clear();
            foreach (var item in DataController.NameSeedData.PrefixList)
                PrefixList.Add(item);
        }

        [RelayCommand]
        async Task SaveOptions()
        {
            if (!string.IsNullOrEmpty(LockedPrefix) && PrefixLock)
            {
                var item = char.ToUpper(LockedPrefix[0]) + LockedPrefix.Substring(1);
                if (!DataController.NameSeedData.PrefixList.Contains(item))
                {
                    DataController.NameSeedData.PrefixList.Add(item);
                    DataController.NameSeedData.PrefixList.Sort();
                    DataController.SaveNameSeedData();
                    PrefixToAdd = string.Empty;
                }
            }
            
            if (SelectedIndex >= 0 || string.IsNullOrEmpty(LockedPrefix))
            {
                await Shell.Current.GoToAsync($"..", true,
                        new Dictionary<string, object>
                        {
                        {"LetterLock", LetterLock },
                        {"LockedLetter", LockedLetterList[SelectedIndex]},
                        {"PrefixLock", PrefixLock },
                        {"LockedPrefix", LockedPrefix }
                        });
            }
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async Task AddPrefix()
        {
            await Shell.Current.GoToAsync($"/{nameof(NamePrefixManagerPage)}");
        }

        [RelayCommand]
        async Task AddSuffix()
        {
            await Shell.Current.GoToAsync($"/{nameof(NameSuffixManagerPage)}");
        }

        [RelayCommand]
        void AddToPrefixList()
        {
            if (string.IsNullOrEmpty(PrefixToAdd))
                return;

            var item = char.ToUpper(PrefixToAdd[0]) + PrefixToAdd.Substring(1);
            if (DataController.NameSeedData.PrefixList.Contains(item))
                return;

            DataController.NameSeedData.PrefixList.Add(item);
            DataController.NameSeedData.PrefixList.Sort();
            DataController.SaveNameSeedData();
            PrefixToAdd = string.Empty;
        }

        [RelayCommand]
        void AddToSuffixList()
        {
            if (string.IsNullOrEmpty(SuffixToAdd))
                return;

            if (DataController.NameSeedData.SuffixList.Contains(SuffixToAdd))
                return;

            DataController.NameSeedData.SuffixList.Add(SuffixToAdd);
            DataController.NameSeedData.SuffixList.Sort();
            DataController.SaveNameSeedData();
            SuffixToAdd = string.Empty;
        }

        [RelayCommand]
        async Task ClearLocks()
        {
            LetterLock = false;
            PrefixLock = false;

            await Shell.Current.GoToAsync($"..", true,
                        new Dictionary<string, object>
                        {
                        {"LetterLock", false },
                        {"PrefixLock", false }
                        });
        }
    }
}
