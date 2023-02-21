using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.ViewModels
{

    [QueryProperty("Collection", "Collection"), QueryProperty("ListIndex", "ListIndex"), QueryProperty("ListName", "ListName")]
    public partial class NameCollectionViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<string> collection;

        [ObservableProperty]
        string listName;

        [ObservableProperty]
        string nameToAdd;

        int ListIndex { get; set; }

        DataController DataController;

        public NameCollectionViewModel() 
        {
            DataController = DataController.Instance;
        }

        [RelayCommand]
        public void Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return;

            Collection.Add(input);
            DataController.NameData.ThemedNameCollections[ListIndex].Collection = Collection.ToList();
            DataController.SaveNameData();
            NameToAdd = string.Empty;
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
