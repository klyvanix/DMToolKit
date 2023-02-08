using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Services;
using Xamarin.Google.Crypto.Tink.Signature;

namespace DMToolKit.ViewModels
{
    public partial class CategoryAddViewModel : ObservableObject
    {
        [ObservableProperty]
        public string categoryName;

        DataController DataController;

        public CategoryAddViewModel() 
        {
            CategoryName = string.Empty;
            DataController = DataController.Instance;
        }

        [RelayCommand]
        public async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async Task AddCategory()
        {
            if(!string.IsNullOrEmpty(CategoryName) && !GetCategoryDoesNotExist()) 
            {
                DataController.NPCData.NPCCategories.Add(CategoryName);
                DataController.NPCData.NPCCategories.Sort();
                DataController.SaveNPCData();
                await Shell.Current.GoToAsync("..");
            }
        }
        private bool GetCategoryDoesNotExist()
        {
            foreach (var item in DataController.NPCData.NPCCategories)
            {
                if (item.Equals(CategoryName))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
