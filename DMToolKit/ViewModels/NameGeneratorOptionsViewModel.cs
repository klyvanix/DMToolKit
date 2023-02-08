using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Services;
using System.Collections.ObjectModel;

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
        public string lockedPrefix;

        [ObservableProperty]
        public ObservableCollection<string> prefixList;

        DataController DataController;

        public NameGeneratorOptionsViewModel() 
        {
            DataController = DataController.Instance;
            SelectedIndex = 0;
            LetterLock = false;
            PrefixLock = false;
            PrefixList= new ObservableCollection<string>();
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
    }
}
