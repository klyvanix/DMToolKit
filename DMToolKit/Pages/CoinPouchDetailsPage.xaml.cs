using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class CoinPouchDetailsPage : ContentPage
{
    CoinPouchDetailsViewModel viewModel;
    public CoinPouchDetailsPage(CoinPouchDetailsViewModel vm)
	{
        InitializeComponent();
        BindingContext = vm;
        viewModel = vm;

    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.UpdateData();
    }
}