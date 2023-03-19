using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NameCollectionPage : ContentPage
{
	NameCollectionViewModel viewModel;
	public NameCollectionPage(NameCollectionViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		viewModel = vm;
    }

    private void ExpandClicked(object sender, EventArgs e)
    {
		if (viewModel.OptionsOpen)
			ExpandButton.Source = "expanddark.png";
		else
			ExpandButton.Source = "retractdark.png";
    }
}