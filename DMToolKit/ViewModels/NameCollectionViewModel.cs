using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Pages;
using DMToolKit.Services;
using System.Collections.ObjectModel;

namespace DMToolKit.ViewModels
{

    [QueryProperty("ListOfNames", "ListOfNames"), QueryProperty("ListIndex", "ListIndex"), QueryProperty("ListName", "ListName")]
    public partial class NameCollectionViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<string> listOfNames;

        [ObservableProperty]
        string listName;

        [ObservableProperty]
        string nameToAdd;

        [ObservableProperty]
        int listIndex;

        [ObservableProperty]
        string randomName;

        [ObservableProperty]
        bool optionsOpen;

        DataController DataController;

        public NameCollectionViewModel() 
        {
            DataController = DataController.Instance;
            RandomName = string.Empty;
            OptionsOpen = false;
        }

        private void UpdateCollection()
        {
            ListOfNames.Clear();
            foreach (var item in DataController.NameData.ThemedNameCollections[ListIndex].Collection)
                ListOfNames.Add(item);
        }

        [RelayCommand]
        public void Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return;

            ListOfNames.Add(input);
            DataController.NameData.ThemedNameCollections[ListIndex].Collection = ListOfNames.ToList();
            DataController.SaveNameData();
            NameToAdd = string.Empty;
        }

        [RelayCommand]
        public void Remove(string input) 
        {
            if (string.IsNullOrEmpty(input))
                return;

            DataController.NameData.ThemedNameCollections[ListIndex].RemoveNameFromCollection(input);
            DataController.SaveNameData();
            UpdateCollection();
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async Task GoToAddPage(string input)
        {
            if (input is null)
                return;

            await Shell.Current.GoToAsync($"{nameof(NameAddPage)}", true,
                new Dictionary<string, object>
                {
                    {"InputName", input }
                });
        }

        [RelayCommand]
        void SelectRandomName()
        {
            RandomName = ListOfNames[new Random().Next(0, ListOfNames.Count)];
        }

        [RelayCommand]
        void ToggleOptions()
        {
            OptionsOpen = !OptionsOpen;
        }
    }
}
