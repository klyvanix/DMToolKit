using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Services;
using System.Collections.ObjectModel;

namespace DMToolKit.ViewModels
{
    public partial class LastNameViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<string> lastNames;

        [ObservableProperty]
        public int nameCount;

        DataController DataController;

        public LastNameViewModel() 
        {
            DataController = DataController.Instance;
            LastNames = new ObservableCollection<string>();
            NameCount = DataController.NameData.SurnameNameList.Collection.Count;
            UpdateData();
        }

        public void UpdateData()
        {
            if (DataController.NameData.SurnameNameList.Collection.Count == 0 || 
                DataController.NameData.SurnameNameList == null)
                return;

            LastNames.Clear();
            foreach (var item in DataController.NameData.SurnameNameList.Collection)
                LastNames.Add(item);
        }

        [RelayCommand]
        public void Delete(string s)
        {
            if (LastNames.Contains(s))
            {
                LastNames.Remove(s);
                SaveData();
            }
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        private void SaveData()
        {
            DataController.NameData.SurnameNameList.Collection = LastNames.ToList();
            DataController.SaveNameData();
            UpdateData();
        }
    }
}
