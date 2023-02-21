using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NameCollectionPage : ContentPage
{
	public NameCollectionPage(NameCollectionViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}