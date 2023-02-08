using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NamePrefixManagerPage : ContentPage
{
	public NamePrefixManagerPage(NamePrefixManagerViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		var vm = BindingContext as NamePrefixManagerViewModel;
		vm.UpdateData();
    }
}