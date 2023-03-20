using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Pages;
using System.Collections.ObjectModel;

namespace DMToolKit.ViewModels
{
    [QueryProperty("FirstIndex", "FirstIndex"),
        QueryProperty("SecondIndex", "SecondIndex"),
        QueryProperty("ThirdIndex", "ThirdIndex"),
        QueryProperty("FourthIndex", "FourthIndex"),
        QueryProperty("FifthIndex", "FifthIndex")]
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

        [ObservableProperty]
        int firstIndex;

        [ObservableProperty]
        int secondIndex;

        [ObservableProperty]
        int thirdIndex;

        [ObservableProperty]
        int fourthIndex;

        [ObservableProperty]
        int fifthIndex;

        private int generationCounter;

        public CoinPouchGeneratorViewModel() 
        {
            generationCounter = 0;
            FirstIndex = -1;
            SecondIndex = -1;
            ThirdIndex = -1;
            FourthIndex = -1;
            FifthIndex = -1;
            CoinPouchList = new ObservableCollection<CoinPouch>();
            OptionsShown = false;
            OutputTarget = 0;
            GenerationNumber = 1;
        }

        [RelayCommand]
        public void Add()
        {
            if (generationCounter % 24 == 0)
                CoinPouchList.Clear();

            for (int i = 0; i < GenerationNumber; i++)
            {
                if (OutputTarget != 0)
                {
                    CoinPouchList.Add(new CoinPouch(OutputTarget));
                    OutputTarget = 0;
                }
                else
                {
                    if(FirstIndex == -1)
                        CoinPouchList.Add(new CoinPouch());
                    else
                        CoinPouchList.Add(new CoinPouch(FirstIndex, SecondIndex, ThirdIndex, FourthIndex, FifthIndex));
                }
            }
            OutputTarget = 0;
            generationCounter++;
        }

        [RelayCommand]
        public void Clear()
        {
            CoinPouchList.Clear();
            GenerationNumber = 1;
            OutputTarget = 0;
            generationCounter = 0;
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

        [RelayCommand]
        async Task GoToOptions()
        {
            if(FirstIndex == -1)
                await Shell.Current.GoToAsync($"{nameof(CoinPouchOptionsPage)}");
            else
            { 
                await Shell.Current.GoToAsync($"{nameof(CoinPouchOptionsPage)}", true,
                    new Dictionary<string, object>
                    {
                        {"FirstIndex", (double)FirstIndex },
                        {"SecondIndex", (double)SecondIndex},
                        {"ThirdIndex", (double)ThirdIndex },
                        {"FourthIndex", (double)FourthIndex },
                        {"FifthIndex", (double)FifthIndex }
                    });
            }
        }

        [RelayCommand]
        void IncreaseCounter()
        {
            OutputTarget++;
        }
        [RelayCommand]
        void DecreaseCounter()
        {
            if (OutputTarget > 0)
                OutputTarget--;
        }
    }
}
