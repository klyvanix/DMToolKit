using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class MasculineNamePage : ContentPage
{
	public MasculineNamePage(MasculineNameViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}