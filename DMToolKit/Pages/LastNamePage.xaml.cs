using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class LastNamePage : ContentPage
{
	public LastNamePage(LastNameViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		var viewmodel = (LastNameViewModel)BindingContext;
		viewmodel.UpdateData();
    }
}