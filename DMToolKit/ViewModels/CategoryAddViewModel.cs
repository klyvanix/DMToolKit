using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Services;

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
            if (string.IsNullOrEmpty(CategoryName) && !GetCategoryDoesNotExist())
                return;

            var item = char.ToUpper(CategoryName[0]) + CategoryName.Substring(1);
            DataController.NPCData.NPCCategories.Add(item);
            DataController.NPCData.NPCCategories.Sort();
            DataController.SaveNPCData();
            await Shell.Current.GoToAsync("..");
        }
        private bool GetCategoryDoesNotExist()
        {
            for(int i = 0; i < DataController.NPCData.NPCCategories.Count; i++)
            {
                if (DataController.NPCData.NPCCategories[i].Equals(CategoryName))
                    return true;
            }
            return false;
        }
    }
}
