using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Pages;

namespace DMToolKit.ViewModels
{
    public partial class NPCListViewModel : ObservableObject
    {
        public NPCListViewModel() { }

        [RelayCommand]
        async Task GoToNPCGenerator()
        {
            await Shell.Current.GoToAsync($"//{nameof(NPCGeneratorPage)}");
        }
    }
}
