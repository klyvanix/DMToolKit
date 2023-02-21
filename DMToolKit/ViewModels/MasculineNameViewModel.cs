using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Services;
using System.Collections.ObjectModel;

namespace DMToolKit.ViewModels
{
    public partial class MasculineNameViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<string> masculineNames;

        [ObservableProperty]
        public int nameCount;

        DataController DataController;

        public MasculineNameViewModel() 
        {
            DataController = DataController.Instance;
            MasculineNames = new ObservableCollection<string>();
            NameCount = DataController.NameData.MasculineNameList.Collection.Count;
            UpdateData();
        }

        public void UpdateData() 
        {
            if (DataController.NameData.MasculineNameList.Collection.Count == 0 ||
                DataController.NameData.MasculineNameList == null)
                return;

            MasculineNames.Clear();
            foreach (var item in DataController.NameData.MasculineNameList.Collection)
                MasculineNames.Add(item);
        }

        [RelayCommand]
        public void Delete(string s)
        {
            if(MasculineNames.Contains(s))
            {
                MasculineNames.Remove(s);
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
            DataController.NameData.MasculineNameList.Collection = MasculineNames.ToList();
            DataController.SaveNameData();
            UpdateData();
        }
    }
}
