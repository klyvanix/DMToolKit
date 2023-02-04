using Android.Service.Autofill;
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
        public ObservableCollection<Name> masculineNames;

        DataController DataController;

        public MasculineNameViewModel() 
        {
            DataController = DataController.Instance;
            MasculineNames = new ObservableCollection<Name>();
            UpdateData();
        }

        [RelayCommand]
        public void UpdateData() 
        {
            if (DataController.NameData.MasculineNameList.Count == 0 ||
                DataController.NameData.MasculineNameList == null)
                return;

            MasculineNames.Clear();
            foreach (var item in DataController.NameData.MasculineNameList)
                MasculineNames.Add(item);
        }

        [RelayCommand]
        public void Delete(Name s)
        {
            if(MasculineNames.Contains(s))
            {
                MasculineNames.Remove(s);
                SaveData();
            }
        }
        private void SaveData() 
        {
            DataController.NameData.MasculineNameList = MasculineNames.ToList();
            DataController.SaveNameData();
            UpdateData();
        }
    }
}
