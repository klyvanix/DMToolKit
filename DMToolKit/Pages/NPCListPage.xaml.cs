using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NPCListPage : ContentPage
{
    NPCListViewModel viewModel;
    public NPCListPage(NPCListViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        viewModel = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.UpdateNPCList();
    }
}