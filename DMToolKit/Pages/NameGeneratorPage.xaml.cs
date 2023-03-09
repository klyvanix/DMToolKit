using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NameGeneratorPage : ContentPage
{
    NameGeneratorViewModel vm;
    readonly Animation loadingAnimation;
	public NameGeneratorPage(NameGeneratorViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
        vm.PropertyChanged += Vm_PropertyChanged;
		loadingAnimation = new Animation(v => LoadingImage.Rotation = v, 0, 360, Easing.Linear);
	}

    private void Vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        var vm = BindingContext as NameGeneratorViewModel;
        if(e.PropertyName == nameof(IsBusy))
        {
            if(vm.IsBusy)
            {
                loadingAnimation.Commit(this, "rotate", 24, 1000, Easing.Linear,
                    (v, c) => LoadingImage.Rotation = 0, () => true);
            }
            else
            {
                this.AbortAnimation("rotate");
            }
        }
    }
}