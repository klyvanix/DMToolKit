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

        DataController DataController;

        public NPCAddViewModel()
        {
            DataController = DataController.Instance;
        }

        [RelayCommand]
        public async Task SaveData()
        {
            InputNPC.Notes = Notes;
            DataController.NPCData.NPCList.Add(InputNPC);
            DataController.SaveNPCData();
            await Shell.Current.GoToAsync("..");
        }
    }
}
