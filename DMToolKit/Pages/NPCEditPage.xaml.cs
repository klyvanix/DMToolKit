using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NPCEditPage : ContentPage
{
    NPCEditViewModel viewModel;
    public NPCEditPage(NPCEditViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        viewModel = vm;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.UpdateData();
    }
}