using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NameGeneratorOptionsPage : ContentPage
{
	public NameGeneratorOptionsPage(NameGeneratorOptionsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}