using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NameSuffixManagerPage : ContentPage
{
	public NameSuffixManagerPage(NameSuffixManagerViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}