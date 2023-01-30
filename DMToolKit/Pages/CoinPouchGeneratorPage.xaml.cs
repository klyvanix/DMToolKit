using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class CoinPouchGeneratorPage : ContentPage
{
	public CoinPouchGeneratorPage(CoinPouchGeneratorViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}