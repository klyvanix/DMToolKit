using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Services;
using System.Collections.ObjectModel;

namespace DMToolKit.ViewModels
{
    [QueryProperty("InputField","InputField")]
    public partial class NamePrefixManagerViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<string> prefixList;

        [ObservableProperty]
        string inputField;

        DataController DataController;

        public NamePrefixManagerViewModel() 
        {
            DataController = DataController.Instance;
            PrefixList = new ObservableCollection<string>();
            InputField = string.Empty;
            UpdateData();
        }

        [RelayCommand]
        void Add()
        {
            if (string.IsNullOrEmpty(InputField))
                return;

            var item = char.ToUpper(InputField[0]) + InputField.Substring(1);
            PrefixList.Add(item);
            PrefixList.Sort();
            InputField = string.Empty;
            SaveData();
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public void Delete(string s)
        {
            if (PrefixList.Contains(s))
            {
                PrefixList.Remove(s);
                SaveData();
            }
        }

        public void UpdateData()
        {
            if(DataController.NameSeedData.PrefixList.Count == 0)
                DataController.NameSeedData.PrefixList = new List<string>();

            PrefixList.Clear();
            for (int i = 0; i < DataController.NameSeedData.PrefixList.Count; i++)
                PrefixList.Add(DataController.NameSeedData.PrefixList[i]);
        }

        private void SaveData()
        {
            DataController.NameSeedData.PrefixList = PrefixList.ToList();
            DataController.SaveNameSeedData();
            UpdateData();
        }
    }
}
