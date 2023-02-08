using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Pages;
using DMToolKit.Services;
using System.Collections.ObjectModel;

namespace DMToolKit.ViewModels
{
    public partial class CategoryManagerViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<string> categories;

        DataController DataController;

        public CategoryManagerViewModel() 
        {
            DataController = DataController.Instance;
            Categories= new ObservableCollection<string>();
            UpdateData();
        }

        [RelayCommand]
        async Task GoToAddPage()
        {
            await Shell.Current.GoToAsync($"{nameof(CategoryAddPage)}");
        }

        public void UpdateData()
        {
            Categories.Clear();
            foreach (var item in DataController.NPCData.NPCCategories)
                Categories.Add(item);
        }

        [RelayCommand]
        public void Delete(string s)
        {
            if (Categories.Contains(s))
            {
                Categories.Remove(s);
                SaveData();
            }
        }

        private void SaveData()
        {
            DataController.NPCData.NPCCategories = Categories.ToList();
            DataController.NPCData.NPCCategories.Sort();
            DataController.SaveNPCData();
            UpdateData();
        }
    }
}
