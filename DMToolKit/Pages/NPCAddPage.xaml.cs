using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NPCAddPage : ContentPage
{
	public NPCAddPage(NPCAddViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}