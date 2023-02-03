using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class FeminineNamePage : ContentPage
{
	public FeminineNamePage(FeminineNameViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}