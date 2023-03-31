using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NamePrefixManagerPage : ContentPage
{
	NamePrefixManagerViewModel viewModel;
	public NamePrefixManagerPage(NamePrefixManagerViewModel vm)
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