using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Pages;

namespace DMToolKit.ViewModels
{
    [QueryProperty("Character", "Character")]
    public partial class NPCDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        NPC character;

        public NPCDetailsViewModel() 
        { 

        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync($"..");
        }

        [RelayCommand]
        async Task GoToEdit()
        {
            await Shell.Current.GoToAsync($"{nameof(NPCEditPage)}", true,
                new Dictionary<string, object>
                {
                    {"Character", Character }
                });
        }
    }
}
