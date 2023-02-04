using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class MasculineNamePage : ContentPage
{
	public MasculineNamePage(MasculineNameViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		var viewmodel = (MasculineNameViewModel)BindingContext;
		viewmodel.UpdateData();
    }
}