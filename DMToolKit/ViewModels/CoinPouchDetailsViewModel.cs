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

        [ObservableProperty]
        bool cPVisible;
        [ObservableProperty]
        bool sPVisible;
        [ObservableProperty]
        bool ePVisible;
        [ObservableProperty]
        bool gPVisible;
        [ObservableProperty]
        bool pPVisible;
        [ObservableProperty]
        bool jewelsVisible;
        [ObservableProperty]
        bool gemsVisible;
        [ObservableProperty]
        bool emeraldsVisible;
        [ObservableProperty]
        bool rubysVisible;
        [ObservableProperty]
        bool diamondsVisible;

        public CoinPouchDetailsViewModel() { }

        public void UpdateData()
        {
            CPVisible = CoinPouch.CP != 0;
            SPVisible = CoinPouch.SP != 0;
            EPVisible = CoinPouch.EP != 0;
            GPVisible = CoinPouch.GP != 0;
            PPVisible = CoinPouch.PP != 0;
            JewelsVisible = CoinPouch.Jewels != 0;
            GemsVisible = CoinPouch.Gems != 0;
            EmeraldsVisible = CoinPouch.Emeralds != 0;
            RubysVisible = CoinPouch.Rubys != 0;
            DiamondsVisible = CoinPouch.Diamonds != 0;
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
