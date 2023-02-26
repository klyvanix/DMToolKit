using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Services;
using System.Collections.ObjectModel;

namespace DMToolKit.ViewModels
{
    [QueryProperty("InputField", "InputField")]
    public partial class NameSuffixManagerViewModel : ObservableObject
    {

        [ObservableProperty]
        ObservableCollection<string> suffixList;

        [ObservableProperty]
        string inputField;

        DataController DataController;
        public NameSuffixManagerViewModel() 
        {
            DataController = DataController.Instance;
            SuffixList = new ObservableCollection<string>();
            InputField = string.Empty;
            UpdateData();
        }

        [RelayCommand]
        void Add()
        {
            if (string.IsNullOrEmpty(InputField))
                return;

            var item = char.ToLower(InputField[0]) + InputField.Substring(1);
            SuffixList.Add(item);
            SuffixList.Sort();
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
            if (SuffixList.Contains(s))
            {
                SuffixList.Remove(s);
                SaveData();
            }
        }

        public void UpdateData()
        {
            if (DataController.NameSeedData.SuffixList.Count == 0)
                DataController.NameSeedData.SuffixList = new List<string>();

            SuffixList.Clear();
            for(int i = 0; i < DataController.NameSeedData.SuffixList.Count; i++)
                SuffixList.Add(DataController.NameSeedData.SuffixList[i]);
        }

        private void SaveData()
        {
            DataController.NameSeedData.SuffixList = SuffixList.ToList();
            DataController.SaveNameSeedData();
            UpdateData();
        }
    }
}
