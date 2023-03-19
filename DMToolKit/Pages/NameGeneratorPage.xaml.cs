using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NameGeneratorPage : ContentPage
{
	NameGeneratorViewModel viewModel;
	public NameGeneratorPage(NameGeneratorViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
		viewModel = vm;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		viewModel.UpdateSettings();
    }
}