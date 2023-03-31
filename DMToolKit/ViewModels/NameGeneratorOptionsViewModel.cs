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
        string entryToAdd;

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
            EntryToAdd = string.Empty;
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
            string color = string.Empty;
            if (Application.Current.RequestedTheme == AppTheme.Light)
                color = "E29E21";
            else
                color = "226A9C";

            uncheckedGradient = new RadialGradientBrush(new GradientStopCollection()
            {
                new GradientStop(Color.FromArgb("00000000"), 0.4f),
                new GradientStop(Color.FromArgb("00000000"), .65f)
            });
            checkedGradient = new RadialGradientBrush(new GradientStopCollection()
            {
                new GradientStop(Color.FromArgb(color), 0.4f),
                new GradientStop(Color.FromArgb("00000000"), .45f)
            });

            LetterBrush = uncheckedGradient;
            PrefixBrush = uncheckedGradient;
        }

        public void UpdateData()
        {
            PrefixCount = $"{DataController.NameSeedData.PrefixList.Count}";
            SuffixCount = $"{DataController.NameSeedData.SuffixList.Count}";
            PrefixLock = DataController.AppSettings.PrefixLock;
            LetterLock = DataController.AppSettings.LetterLock;
            LockedPrefix = DataController.AppSettings.Prefix;
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
                }
            }
            DataController.AppSettings.PrefixLock = PrefixLock;
            DataController.AppSettings.Prefix = LockedPrefix;
            DataController.AppSettings.LetterLock = LetterLock;
            DataController.AppSettings.Letter = LockedLetterList[SelectedIndex];
            
            if (SelectedIndex >= 0 || string.IsNullOrEmpty(LockedPrefix))
            {
                await Shell.Current.GoToAsync($"..");
            }
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync($"..");
        }

        [RelayCommand]
        async Task GoToPrefix()
        {
            await Shell.Current.GoToAsync($"/{nameof(NamePrefixManagerPage)}");
        }

        [RelayCommand]
        async Task GoToSuffix()
        {
            await Shell.Current.GoToAsync($"/{nameof(NameSuffixManagerPage)}");
        }

        [RelayCommand]
        void AddToPrefixList()
        {
            if (string.IsNullOrEmpty(EntryToAdd))
                return;

            var prefix = char.ToUpper(EntryToAdd[0]) + EntryToAdd.Substring(1);
            if (DataController.NameSeedData.PrefixList.Contains(prefix))
                return;

            DataController.NameSeedData.PrefixList.Add(prefix);
            DataController.NameSeedData.PrefixList.Sort();
            DataController.SaveNameSeedData();
            EntryToAdd = string.Empty;
            PrefixCount = $"{DataController.NameSeedData.PrefixList.Count}";
        }

        [RelayCommand]
        void AddToSuffixList()
        {
            if (string.IsNullOrEmpty(EntryToAdd))
                return;

            var suffix = char.ToLower(EntryToAdd[0]) + EntryToAdd.Substring(1);
            if (DataController.NameSeedData.SuffixList.Contains(suffix))
                return;

            DataController.NameSeedData.SuffixList.Add(suffix);
            DataController.NameSeedData.SuffixList.Sort();
            DataController.SaveNameSeedData();
            EntryToAdd = string.Empty;
            SuffixCount = $"{DataController.NameSeedData.SuffixList.Count}";
        }

        [RelayCommand]
        void AddBoth()
        {
            if (string.IsNullOrEmpty(EntryToAdd) && string.IsNullOrEmpty(EntryToAdd))
                return;

            var prefix = char.ToUpper(EntryToAdd[0]) + EntryToAdd.Substring(1);
            var suffix = char.ToLower(EntryToAdd[0]) + EntryToAdd.Substring(1);

            if (!DataController.NameSeedData.PrefixList.Contains(prefix))
            {
                DataController.NameSeedData.PrefixList.Add(prefix);
                DataController.NameSeedData.PrefixList.Sort();
                DataController.SaveNameSeedData();
                EntryToAdd = string.Empty;
                PrefixCount = $"{DataController.NameSeedData.PrefixList.Count}";
            }

            if (!DataController.NameSeedData.SuffixList.Contains(suffix))
            {
                DataController.NameSeedData.SuffixList.Add(suffix);
                DataController.NameSeedData.SuffixList.Sort();
                DataController.SaveNameSeedData();
                EntryToAdd = string.Empty;
                SuffixCount = $"{DataController.NameSeedData.SuffixList.Count}";
            }
        }

        [RelayCommand]
        void ClearLocks()
        {
            LetterLock = false;
            PrefixLock = false;
            PrefixBrush = uncheckedGradient;
            LetterBrush = uncheckedGradient;
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
