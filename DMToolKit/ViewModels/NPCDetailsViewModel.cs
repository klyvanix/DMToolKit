using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Pages;

namespace DMToolKit.ViewModels
{
    [QueryProperty("NPC", "NPC")]
    public partial class NPCDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        public NPC nPC;

        public NPCDetailsViewModel() { }

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
                    {"NPC", NPC }
                });
        }
    }
}
