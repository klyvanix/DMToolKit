using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class CategoryManagerPage : ContentPage
{
	public CategoryManagerPage(CategoryManagerViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		//As page is appearing make sure we are updating the data on the page.
		var vm = BindingContext as CategoryManagerViewModel;
		vm.UpdateData();
    }
}