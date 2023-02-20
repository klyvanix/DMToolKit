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
        public ObservableCollection<Name> lastNames;

        [ObservableProperty]
        public int nameCount;

        DataController DataController;

        public LastNameViewModel() 
        {
            DataController = DataController.Instance;
            LastNames = new ObservableCollection<Name>();
            NameCount = DataController.NameData.LastNameList.Count;
            UpdateData();
        }

        public void UpdateData()
        {
            if (DataController.NameData.LastNameList.Count == 0 || 
                DataController.NameData.LastNameList == null)
                return;

            LastNames.Clear();
            foreach (var item in DataController.NameData.LastNameList)
                LastNames.Add(item);
        }

        [RelayCommand]
        public void Delete(Name s)
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
            DataController.NameData.LastNameList = LastNames.ToList();
            DataController.SaveNameData();
            UpdateData();
        }
    }
}
