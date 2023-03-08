using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DMToolKit.ViewModels;

[QueryProperty("FirstSliderValue", "FirstIndex"), 
        QueryProperty("SecondSliderValue", "SecondIndex"), 
        QueryProperty("ThirdSliderValue", "ThirdIndex"), 
        QueryProperty("FourthSliderValue", "FourthIndex"), 
        QueryProperty("FifthSliderValue", "FifthIndex")] 
public partial class CoinPouchOptionsViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TotalValue))]
    [NotifyPropertyChangedFor(nameof(FirstPercentage))]
    [NotifyPropertyChangedFor(nameof(SecondPercentage))]
    [NotifyPropertyChangedFor(nameof(ThirdPercentage))]
    [NotifyPropertyChangedFor(nameof(FourthPercentage))]
    [NotifyPropertyChangedFor(nameof(FifthPercentage))]
    double firstSliderValue;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TotalValue))]
    [NotifyPropertyChangedFor(nameof(FirstPercentage))]
    [NotifyPropertyChangedFor(nameof(SecondPercentage))]
    [NotifyPropertyChangedFor(nameof(ThirdPercentage))]
    [NotifyPropertyChangedFor(nameof(FourthPercentage))]
    [NotifyPropertyChangedFor(nameof(FifthPercentage))]
    double secondSliderValue;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TotalValue))]
    [NotifyPropertyChangedFor(nameof(FirstPercentage))]
    [NotifyPropertyChangedFor(nameof(SecondPercentage))]
    [NotifyPropertyChangedFor(nameof(ThirdPercentage))]
    [NotifyPropertyChangedFor(nameof(FourthPercentage))]
    [NotifyPropertyChangedFor(nameof(FifthPercentage))]
    double thirdSliderValue;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TotalValue))]
    [NotifyPropertyChangedFor(nameof(FirstPercentage))]
    [NotifyPropertyChangedFor(nameof(SecondPercentage))]
    [NotifyPropertyChangedFor(nameof(ThirdPercentage))]
    [NotifyPropertyChangedFor(nameof(FourthPercentage))]
    [NotifyPropertyChangedFor(nameof(FifthPercentage))]
    double fourthSliderValue;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TotalValue))]
    [NotifyPropertyChangedFor(nameof(FirstPercentage))]
    [NotifyPropertyChangedFor(nameof(SecondPercentage))]
    [NotifyPropertyChangedFor(nameof(ThirdPercentage))]
    [NotifyPropertyChangedFor(nameof(FourthPercentage))]
    [NotifyPropertyChangedFor(nameof(FifthPercentage))]
    double fifthSliderValue;

    double TotalValue => FirstSliderValue + SecondSliderValue + ThirdSliderValue + FourthSliderValue + FifthSliderValue;
    
    public double FirstPercentage => Math.Round ((FirstSliderValue / TotalValue) * 100, 2);
    public double SecondPercentage => Math.Round((SecondSliderValue / TotalValue) * 100, 2);
    public double ThirdPercentage => Math.Round((ThirdSliderValue / TotalValue) * 100, 2);
    public double FourthPercentage => Math.Round((FourthSliderValue / TotalValue) * 100, 2);
    public double FifthPercentage => Math.Round((FifthSliderValue / TotalValue) * 100, 2);

    public CoinPouchOptionsViewModel() 
    {
        FirstSliderValue = 300f;
        SecondSliderValue = 200f;
        ThirdSliderValue = 70f;
        FourthSliderValue = 60f;
        FifthSliderValue = 20f;
    }

    [RelayCommand]
    async Task Save()
    {
        await Shell.Current.GoToAsync($"..", true,
                new Dictionary<string, object>
                {
                    {"FirstIndex", (int)FirstSliderValue },
                    {"SecondIndex", (int)SecondSliderValue},
                    {"ThirdIndex", (int)ThirdSliderValue },
                    {"FourthIndex", (int)FourthSliderValue },
                    {"FifthIndex", (int)FifthSliderValue }
                });
    }

    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}
