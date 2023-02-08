using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Pages;
using DMToolKit.Services;

namespace DMToolKit.ViewModels
{

    [QueryProperty("NPC", "NPC")]
    public partial class NPCEditViewModel : ObservableObject
    {
        [ObservableProperty]
        public NPC nPC;

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
            Notes = NPC.Notes;
        }

        [RelayCommand]
        async Task SaveChanges()
        {
            if (DataController.NPCData.NPCList.Contains(NPC))
            {
                var index = DataController.NPCData.NPCList.IndexOf(NPC);
                NPC.Notes = Notes;
                NPC.Role = ClassificationList[PickerIndex];
                DataController.NPCData.NPCList[index] = NPC;
                DataController.SaveNPCData();
            }
            await Shell.Current.GoToAsync($"//{nameof(NPCListPage)}");
            //await Shell.Current.GoToAsync($"//{nameof(NPCListPage)}/{nameof(NPCDetailsPage)}", true,
            //    new Dictionary<string, object>
            //    {
            //        {"NPC", NPC }
            //    });
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync($"..");
        }
    }
}
