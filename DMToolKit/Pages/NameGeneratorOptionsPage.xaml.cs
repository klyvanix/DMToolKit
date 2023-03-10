using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NameGeneratorOptionsPage : ContentPage
{
	public NameGeneratorOptionsPage(NameGeneratorOptionsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		var vm = BindingContext as NameGeneratorOptionsViewModel;
		vm.UpdateData();
    }
}