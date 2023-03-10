using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NameCollectionEditPage : ContentPage
{
	public NameCollectionEditPage(NameCollectionEditViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}