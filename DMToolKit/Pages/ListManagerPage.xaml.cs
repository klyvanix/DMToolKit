using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class ListManagerPage : ContentPage
{
	public ListManagerPage( ListManagerViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
		var vm = BindingContext as ListManagerViewModel;
		vm.UpdateLists();
    }
}