using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Services;
using System.Collections.ObjectModel;

namespace DMToolKit.ViewModels
{
    public partial class NamePrefixManagerViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<string> prefixList;

        [ObservableProperty]
        string inputField;

        public NamePrefixManagerViewModel() 
        {
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
        public void Delete(string s)
        {
            if (PrefixList.Contains(s))
            {
                PrefixList.Remove(s);
                SaveData();
            }
        }

        private void UpdateData()
        {
            if(DataController.NameConstructionData.PrefixList.Count == 0)
                DataController.NameConstructionData.PrefixList = new List<string>();

            PrefixList.Clear();
            foreach (var item in DataController.NameConstructionData.PrefixList)
                PrefixList.Add(item);
        }

        private void SaveData()
        {
            DataController.NameConstructionData.PrefixList = PrefixList.ToList();
            DataController.SaveNameConstructionData();
            UpdateData();
        }
    }
}
