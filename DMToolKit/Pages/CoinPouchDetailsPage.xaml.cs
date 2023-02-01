using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class CoinPouchDetailsPage : ContentPage
{
	public CoinPouchDetailsPage(CoinPouchDetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}