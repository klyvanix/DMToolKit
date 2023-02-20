using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Services;
using System.Collections.ObjectModel;

namespace DMToolKit.ViewModels
{
    public partial class FeminineNameViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Name> feminineNames;

        [ObservableProperty]
        public int nameCount;

        DataController DataController;

        public FeminineNameViewModel() 
        {
            DataController = DataController.Instance;
            FeminineNames= new ObservableCollection<Name>();
            NameCount = DataController.NameData.FeminineNameList.Count;
            UpdateData();
        }

        public void UpdateData()
        {
            if (DataController.NameData.FeminineNameList.Count == 0 ||
                DataController.NameData.FeminineNameList == null)
                return;

            FeminineNames.Clear();
            foreach (var item in DataController.NameData.FeminineNameList)
                FeminineNames.Add(item);
        }

        [RelayCommand]
        public void Delete(Name s)
        {
            if(FeminineNames.Contains(s))
            {
                FeminineNames.Remove(s);
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
            DataController.NameData.FeminineNameList = FeminineNames.ToList();
            DataController.SaveNameData();
            UpdateData();
        }
    }
}
