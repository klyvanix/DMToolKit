using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class AddNamePage : ContentPage
{
	public AddNamePage(AddNameViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		var vm = (AddNameViewModel)BindingContext;
		vm.CheckIfPrefixExists();
		vm.CheckIfSuffixExists();
		vm.UpdateLists();
    }
}