using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Pages;
using DMToolKit.Services;

namespace DMToolKit.ViewModels
{

    [QueryProperty("Character", "Character")]
    public partial class NPCEditViewModel : ObservableObject
    {
        [ObservableProperty]
        public NPC character;

        [ObservableProperty]
        public string notes;

        [ObservableProperty]
        public List<string> classificationList;

        [ObservableProperty]
        public int pickerIndex;

        DataController DataController;

        public NPCEditViewModel()
        {
            DataController = DataController.Instance;
            PickerIndex = 0;
            Notes = string.Empty;
            ClassificationList = new List<string>();
            ClassificationList.Clear();
            foreach (var item in DataController.NPCData.NPCCategories)
                ClassificationList.Add(item);
        }


        public void UpdateData()
        {
            Notes = Character.Notes;
        }

        [RelayCommand]
        async Task SaveChanges()
        {
            if (DataController.NPCData.NPCList.Contains(Character))
            {
                var index = DataController.NPCData.NPCList.IndexOf(Character);
                Character.Notes = Notes;
                Character.Role = ClassificationList[PickerIndex];
                DataController.NPCData.NPCList[index] = Character;
                DataController.SaveNPCData();
            }
            await Shell.Current.GoToAsync($"../..");
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync($"..");
        }
    }
}
