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
        bool namePartLock;

        [ObservableProperty]
        public string lockedPrefix;

        [ObservableProperty]
        public ObservableCollection<string> prefixList;

        [ObservableProperty]
        public string prefixToAdd;

        [ObservableProperty]
        public string suffixToAdd;

        DataController DataController;

        public NameGeneratorOptionsViewModel() 
        {
            DataController = DataController.Instance;
            SelectedIndex = 0;
            LetterLock = false;
            PrefixLock = false;
            NamePartLock = true;
            PrefixList = new ObservableCollection<string>();
            PrefixToAdd = string.Empty;
            SuffixToAdd = string.Empty;
            LockedPrefix = string.Empty;
            LockedLetterList = new List<string>()
            {
                "A", "B", "C", "D", "E",
                "F", "G", "H", "I", "J",
                "K", "L", "M", "N", "O",
                "P", "Q", "R", "S", "T",
                "U", "V", "W", "X", "Y", "Z"
            };

            if (DataController.NameConstructionData.PrefixList.Count == 0)
                return;

            PrefixList.Clear();
            foreach (var item in DataController.NameConstructionData.PrefixList)
                PrefixList.Add(item);
        }

        [RelayCommand]
        async Task SaveOptions()
        {
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
            if (DataController.NameConstructionData.PrefixList.Contains(item))
                return;

            DataController.NameConstructionData.PrefixList.Add(item);
            DataController.NameConstructionData.PrefixList.Sort();
            DataController.SaveNameConstructionData();
            PrefixToAdd = string.Empty;
        }

        [RelayCommand]
        void AddToSuffixList()
        {
            if (string.IsNullOrEmpty(SuffixToAdd))
                return;

            if (DataController.NameConstructionData.SuffixList.Contains(SuffixToAdd))
                return;

            DataController.NameConstructionData.SuffixList.Add(SuffixToAdd);
            DataController.NameConstructionData.SuffixList.Sort();
            DataController.SaveNameConstructionData();
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
