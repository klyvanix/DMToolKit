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
        string lockedPrefix;

        [ObservableProperty]
        ObservableCollection<string> prefixList;

        [ObservableProperty]
        string prefixToAdd;

        [ObservableProperty]
        string suffixToAdd;

        [ObservableProperty]
        string prefixCount;

        [ObservableProperty]
        string suffixCount;

        RadialGradientBrush uncheckedGradient;
        RadialGradientBrush checkedGradient;

        [ObservableProperty]
        RadialGradientBrush prefixBrush;
        [ObservableProperty]
        RadialGradientBrush letterBrush;


        DataController DataController;

        public NameGeneratorOptionsViewModel() 
        {
            DataController = DataController.Instance;
            SelectedIndex = 0;
            LetterLock = false;
            PrefixLock = false;
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

            uncheckedGradient = new RadialGradientBrush(new GradientStopCollection()
            {
                new GradientStop(Color.FromArgb("00000000"), 0.4f),
                new GradientStop(Color.FromArgb("00000000"), .65f)
            });
            checkedGradient = new RadialGradientBrush(new GradientStopCollection()
            {
                new GradientStop(Color.FromArgb("226A9C"), 0.4f),
                new GradientStop(Color.FromArgb("00000000"), .45f)
            });

            LetterBrush = uncheckedGradient;
            PrefixBrush = uncheckedGradient;
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

        [RelayCommand]
        void LetterLocker()
        {
            PrefixBrush = uncheckedGradient;
            LetterBrush = checkedGradient;
            LetterLock = true;
            PrefixLock = false;
        }

        [RelayCommand]
        void PrefixLocker()
        {
            LetterBrush = uncheckedGradient;
            PrefixBrush = checkedGradient;
            LetterLock = false;
            PrefixLock = true;
        }
    }
}
