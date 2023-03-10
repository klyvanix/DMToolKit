using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Services;

namespace DMToolKit.ViewModels
{
    [QueryProperty("ListName", "ListName"), QueryProperty("ListIndex", "ListIndex")]
    public partial class NameCollectionEditViewModel : ObservableObject
    {
        [ObservableProperty]
        string listName;

        [ObservableProperty]
        int listIndex;

        DataController DataController = DataController.Instance;

        public NameCollectionEditViewModel() 
        { 
        }

        [RelayCommand]
        async Task Save()
        {
            if (string.IsNullOrEmpty(ListName))
                return;

            DataController.NameData.ThemedNameCollections[ListIndex].Name = ListName;
            DataController.SaveNameData();

            await Shell.Current.GoToAsync($"..");
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync($"..");
        }
    }
}
