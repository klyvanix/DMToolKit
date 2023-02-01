using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;

namespace DMToolKit.ViewModels
{
    [QueryProperty("CoinPouch", "CoinPouch")]
    public partial class CoinPouchDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        CoinPouch coinPouch;

        public CoinPouchDetailsViewModel() { }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
