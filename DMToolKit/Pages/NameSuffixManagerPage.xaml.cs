using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NameSuffixManagerPage : ContentPage
{
	public NameSuffixManagerPage(NameSuffixManagerViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var vm = BindingContext as NameSuffixManagerViewModel;
        vm.UpdateData();
    }
}