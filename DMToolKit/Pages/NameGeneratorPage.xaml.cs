using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NameGeneratorPage : ContentPage
{
	public NameGeneratorPage(NameGeneratorViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
	}
}