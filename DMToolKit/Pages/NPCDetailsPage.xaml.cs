using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NPCDetailsPage : ContentPage
{
	public NPCDetailsPage(NPCDetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}