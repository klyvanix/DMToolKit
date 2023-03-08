using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class CoinPouchOptionsPage : ContentPage
{
	public CoinPouchOptionsPage(CoinPouchOptionsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}