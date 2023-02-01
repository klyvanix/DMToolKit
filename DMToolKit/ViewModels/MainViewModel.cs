using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Pages;

namespace DMToolKit.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {

        }

        [RelayCommand]
        async Task GoToCoinPouchGenerator()
        {
            await Shell.Current.GoToAsync($"//{nameof(CoinPouchGeneratorPage)}");
        }

        [RelayCommand]
        async Task GoToNPCGenerator()
        {
            await Shell.Current.GoToAsync($"//{nameof(NPCGeneratorPage)}");
        }
    }
}
