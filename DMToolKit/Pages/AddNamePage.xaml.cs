using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class AddNamePage : ContentPage
{
	public AddNamePage(AddNameViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}