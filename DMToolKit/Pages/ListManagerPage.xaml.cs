using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class ListManagerPage : ContentPage
{
    ListManagerViewModel viewModel;
    public ListManagerPage( ListManagerViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        viewModel = vm;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.UpdateLists();
    }
}