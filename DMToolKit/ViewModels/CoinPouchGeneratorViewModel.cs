using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Pages;
using System.Collections.ObjectModel;

namespace DMToolKit.ViewModels
{
    public partial class CoinPouchGeneratorViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<CoinPouch> coinPouchList;

        [ObservableProperty]
        bool optionsShown;

        [ObservableProperty]
        int outputTarget;

        [ObservableProperty]
        int generationNumber;

        public CoinPouchGeneratorViewModel() 
        {
            CoinPouchList = new ObservableCollection<CoinPouch>();
            optionsShown = false;
            OutputTarget = 0;
            GenerationNumber = 1;
        }

        [RelayCommand]
        public void Add()
        {
            if (GenerationNumber != 1 || OutputTarget != 0)
                CoinPouchList.Clear();

            for (int i = 0; i < GenerationNumber; i++)
            {
                if (OutputTarget != 0)
                {
                    CoinPouchList.Add(new CoinPouch(OutputTarget));
                    OutputTarget = 0;
                }
                else
                    CoinPouchList.Add(new CoinPouch());
            }
            OutputTarget = 0;
        }

        [RelayCommand]
        public void Clear()
        {
            CoinPouchList.Clear();
            GenerationNumber = 1;
            OutputTarget = 0;
        }

        [RelayCommand]
        public void ToggleOptions()
        {
            OptionsShown = !OptionsShown;
        }

        [RelayCommand]
        public void ClearCounter()
        {
            OutputTarget = 0;
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
