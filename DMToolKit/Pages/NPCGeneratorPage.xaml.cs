using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NPCGeneratorPage : ContentPage
{
	public NPCGeneratorPage(NPCGeneratorViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}