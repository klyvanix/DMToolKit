using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Services;

namespace DMToolKit.ViewModels
{
    [QueryProperty("InputNPC", "InputNPC")]
    public partial class NPCAddViewModel : ObservableObject
    {
        [ObservableProperty]
        public NPC inputNPC;

        [ObservableProperty]
        public string notes;

        [ObservableProperty]
        public List<string> classificationList;

        [ObservableProperty]
        public int pickerIndex;

        DataController DataController;

        public NPCAddViewModel()
        {
            DataController = DataController.Instance;
            PickerIndex = 0;
            ClassificationList = new List<string>();
            UpdateData();
        }

        [RelayCommand]
        public async Task SaveData()
        {
            InputNPC.Notes = Notes;
            InputNPC.Role = ClassificationList[PickerIndex];
            DataController.NPCData.NPCList.Add(InputNPC);
            DataController.SaveNPCData();
            await Shell.Current.GoToAsync("..");
        }

        public void UpdateData()
        {
            ClassificationList = DataController.NPCData.NPCCategories;
        }
    }
}
