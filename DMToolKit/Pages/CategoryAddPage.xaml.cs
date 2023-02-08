using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class CategoryAddPage : ContentPage
{
	public CategoryAddPage(CategoryAddViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}