using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NameGeneratorOptionsPage : ContentPage
{
	NameGeneratorOptionsViewModel viewModel;
	public NameGeneratorOptionsPage(NameGeneratorOptionsViewModel vm)
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