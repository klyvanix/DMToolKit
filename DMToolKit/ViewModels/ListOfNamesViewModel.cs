using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.ViewModels
{
    [QueryProperty("NamesList","NamesList")]
    public partial class ListOfNamesViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<string> namesList;

        public ListOfNamesViewModel()
        {
        }

        [RelayCommand]
        void Delete(string name)
        {
            if (string.IsNullOrEmpty(name))
                return;
            NamesList.Remove(name);
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
