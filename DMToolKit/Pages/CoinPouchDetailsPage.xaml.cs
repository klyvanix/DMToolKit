using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class CoinPouchDetailsPage : ContentPage
{
	public CoinPouchDetailsPage(CoinPouchDetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
		var vm = BindingContext as CoinPouchDetailsViewModel;
		vm.UpdateData();
    }
}