using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.ViewModels
{
    [QueryProperty("InputName","InputName")]
    public partial class AddNameViewModel : ObservableObject
    {
        [ObservableProperty]
        public Name inputName;

        DataController DataController;

        public AddNameViewModel() 
        {
            DataController = DataController.Instance;
        }

        [RelayCommand]
        public void AddMasculine()
        {
            if (DataController.NameData.MasculineNameList == null)
                DataController.NameData.MasculineNameList = new List<Name>();

            DataController.NameData.MasculineNameList.Add(InputName);
            DataController.NameData.MasculineNameList.Sort();
            DataController.SaveNameData();
        }

        [RelayCommand]
        public void AddFeminine()
        {
            if (DataController.NameData.FeminineNameList == null)
                DataController.NameData.FeminineNameList = new List<Name>();

            DataController.NameData.FeminineNameList.Add(InputName);
            DataController.NameData.FeminineNameList.Sort();
            DataController.SaveNameData();
        }

        [RelayCommand]
        public void AddLast()
        {
            if (DataController.NameData.LastNameList == null)
                DataController.NameData.LastNameList = new List<Name>();

            DataController.NameData.LastNameList.Add(InputName);
            DataController.NameData.LastNameList.Sort();
            DataController.SaveNameData();
        }


        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
