using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class ListOfNamesPage : ContentPage
{
	public ListOfNamesPage(ListOfNamesViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}