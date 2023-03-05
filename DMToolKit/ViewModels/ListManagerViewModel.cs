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
        ObservableCollection<string> listGroups;

        [ObservableProperty]
        bool addVisible;

        [ObservableProperty]
        string listNameToAdd;

        [ObservableProperty]
        string expandImage;

        DataController DataController;

        public ListManagerViewModel() 
        {
            ListGroups = new ObservableCollection<string>();
            ListNameToAdd = string.Empty;
            AddVisible = false;
            DataController = DataController.Instance;
            UpdateLists(); 
            if (Application.Current.RequestedTheme == AppTheme.Light)
                ExpandImage = "expand";
            else
                ExpandImage = "expanddark";
        }

        public void UpdateLists()
        {
            ListGroups.Clear();
            foreach (var item in DataController.NameData.ThemedNameCollections)
                ListGroups.Add(item.Name);
        }

        [RelayCommand]
        public void ToggleAddMenu()
        {
            AddVisible = !AddVisible;
            if (AddVisible)
            {
                if (Application.Current.RequestedTheme == AppTheme.Light)
                    ExpandImage = "retract";
                else
                    ExpandImage = "retractdark";
            }
            else
            {
                if (Application.Current.RequestedTheme == AppTheme.Light)
                    ExpandImage = "expand";
                else
                    ExpandImage = "expanddark";
            }
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
                    {"ListOfNames", collection },
                    {"ListIndex", index },
                    {"ListName", listName}
                });
        }

        [RelayCommand]
        public void AddList(string listName) 
        {
            if (string.IsNullOrEmpty(listName) || DataController.NameData.ListNameExists(listName))
                return;

            DataController.NameData.AddNameToList(listName);
            DataController.SaveNameData();
            UpdateLists();
            ListNameToAdd = string.Empty;
        }

        [RelayCommand]
        public void DeleteList(string listName)
        {
            if (string.IsNullOrEmpty(listName) || 
                !DataController.NameData.ListNameExists(listName) ||
                listName == "Masculine" || listName == "Feminine" || listName == "Surname")
                return;
            DataController.NameData.DeleteNameFromList(listName);
            DataController.SaveNameData();
            UpdateLists();
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync($"..");
        }
    }
}
