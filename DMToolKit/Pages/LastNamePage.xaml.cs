using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class LastNamePage : ContentPage
{
	public LastNamePage(LastNameViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}