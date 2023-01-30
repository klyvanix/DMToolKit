using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}

