using Android.OS.Strictmode;
using DMToolKit.ViewModels;
using Java.Lang;

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