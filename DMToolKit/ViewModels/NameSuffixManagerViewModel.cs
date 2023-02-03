using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Services;
using System.Collections.ObjectModel;

namespace DMToolKit.ViewModels
{
    public partial class NameSuffixManagerViewModel : ObservableObject
    {

        [ObservableProperty]
        ObservableCollection<string> suffixList;

        [ObservableProperty]
        string inputField;

        public NameSuffixManagerViewModel() 
        {
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
        public void Delete(string s)
        {
            if (SuffixList.Contains(s))
            {
                SuffixList.Remove(s);
                SaveData();
            }
        }

        private void UpdateData()
        {
            if (DataController.NameConstructionData.SuffixList.Count == 0)
                DataController.NameConstructionData.SuffixList = new List<string>();

            SuffixList.Clear();
            foreach (var item in DataController.NameConstructionData.SuffixList)
                SuffixList.Add(item);
        }

        private void SaveData()
        {
            DataController.NameConstructionData.SuffixList = SuffixList.ToList();
            DataController.SaveNameConstructionData();
            UpdateData();
        }
    }
}
