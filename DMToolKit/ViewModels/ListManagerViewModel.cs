using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Pages;
using DMToolKit.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.ViewModels
{
    public partial class ListManagerViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<string> listGroups;

        DataController DataController;

        public ListManagerViewModel() 
        {
            ListGroups = new ObservableCollection<string>();
            DataController = DataController.Instance;
            foreach(var item in DataController.NameData.ThemedNameCollections)
                listGroups.Add(item.Name);
        }
        [RelayCommand]
        async Task GoToCollection(string listName)
        {
            int index = -1;
            ObservableCollection<string> collection = new ObservableCollection<string>();

            for (int i = 0; i < DataController.NameData.ThemedNameCollections.Count; i++)
            {
                if(listName == DataController.NameData.ThemedNameCollections[i].Name)
                {
                    collection = new ObservableCollection<string>(DataController.NameData.ThemedNameCollections[i].Collection);
                    index = i;
                    break;
                }
            }
            await Shell.Current.GoToAsync($"{nameof(NameCollectionPage)}", true,
                new Dictionary<string, object>
                {
                    {"Collection", collection },
                    {"ListIndex", index },
                    {"ListName", listName}
                });
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync($"..");
        }
    }
}
