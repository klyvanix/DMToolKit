using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.ViewModels
{
    public partial class CoinPouchGeneratorViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<CoinPouch> coinPouchList;

        [ObservableProperty]
        int outputTarget;

        public CoinPouchGeneratorViewModel() 
        {
            CoinPouchList = new ObservableCollection<CoinPouch>();
            OutputTarget = 0;
        }

        [RelayCommand]
        public void Add()
        {
            if (OutputTarget != 0)
                CoinPouchList.Add(new CoinPouch(OutputTarget));
            else
                CoinPouchList.Add(new CoinPouch());
        }

        [RelayCommand]
        public void Clear()
        {
            CoinPouchList.Clear();
        }

        [RelayCommand]
        async Task GoToDetails(CoinPouch coinPouch)
        {
            if (coinPouch is null)
                return;

            await Shell.Current.GoToAsync($"{nameof(CoinPouchDetailsPage)}", true,
                new Dictionary<string, object>
                {
                    {"CoinPouch", coinPouch }
                });
        }
    }
}
