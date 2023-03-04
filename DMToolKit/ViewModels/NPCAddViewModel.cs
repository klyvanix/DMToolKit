using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Services;
using System.Collections.ObjectModel;

namespace DMToolKit.ViewModels
{
    [QueryProperty("InputNPC", "InputNPC")]
    public partial class NPCAddViewModel : ObservableObject
    {
        [ObservableProperty]
        NPC inputNPC;

        [ObservableProperty]
        string notes;

        [ObservableProperty]
        ObservableCollection<string> classificationList;

        [ObservableProperty]
        int pickerIndex;

        DataController DataController;

        public NPCAddViewModel()
        {
            DataController = DataController.Instance;
            PickerIndex = 0;
            ClassificationList = new ObservableCollection<string>();
            UpdateData();
        }

        [RelayCommand]
        public async Task SaveData()
        {
            InputNPC.Notes = Notes;
            InputNPC.Classification = ClassificationList[PickerIndex];
            DataController.NPCData.AddNPCTtoClassList(InputNPC, PickerIndex);
            DataController.SaveNPCData();
            await Shell.Current.GoToAsync("..");
        }

        public void UpdateData()
        {
            for(int i = 0; i < DataController.NPCData.NPCClassificationList.Count; i++) 
            {
                ClassificationList.Add(DataController.NPCData.NPCClassificationList[i].ListName);
            }
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync($"..");
        }
    }
}
