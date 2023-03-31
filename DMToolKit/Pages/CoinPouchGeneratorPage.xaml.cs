using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class CoinPouchGeneratorPage : ContentPage
{
    CoinPouchGeneratorViewModel viewModel;
    public CoinPouchGeneratorPage(CoinPouchGeneratorViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
        viewModel = vm;

    }

    private void ExpandButton_Clicked(object sender, EventArgs e)
    {
        if (viewModel.OptionsShown)
            ExpandButton.Source = "retract.png";
        else
            ExpandButton.Source = "expand.png";
    }
}