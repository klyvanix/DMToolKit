using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NPCOptionsPage : ContentPage
{
	public NPCOptionsPage(NPCOptionsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}