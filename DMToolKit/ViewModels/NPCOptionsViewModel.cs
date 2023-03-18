using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Pages;
using DMToolKit.Services;
using System.Collections.ObjectModel;

namespace DMToolKit.ViewModels
{
    [QueryProperty("MasculineListIndex", "MasculineListIndex")]
    [QueryProperty("FeminineListIndex", "FeminineListIndex")]
    [QueryProperty("SurnameListIndex", "SurnameListIndex")]
    public partial class NPCOptionsViewModel: ObservableObject
    {
        [ObservableProperty]
        int masculineListIndex;
        [ObservableProperty]
        int feminineListIndex;
        [ObservableProperty]
        int surnameListIndex;

        [ObservableProperty]
        List<string> namesList;

        [ObservableProperty]
        bool addVisible;

        [ObservableProperty]
        string listGroupToAdd;

        [ObservableProperty]
        string expandImage;

        [ObservableProperty]
        ObservableCollection<string> characterClassifications;

        DataController DataController;

        public NPCOptionsViewModel() 
        {
            DataController = DataController.Instance;
            NamesList = new List<string>();
            for (int i = 0; i < DataController.NameData.ThemedNameCollections.Count; i++)
                NamesList.Add(DataController.NameData.ThemedNameCollections[i].Name);
            MasculineListIndex = -1;
            FeminineListIndex = -1;
            SurnameListIndex = -1;
            ListGroupToAdd = string.Empty;
            AddVisible = false;
            CharacterClassifications = new ObservableCollection<string>();
            ExpandImage = "retract";
            UpdateClassifications();
        }

        private void UpdateClassifications()
        {
            for (int i = 0; i < DataController.NPCData.NPCClassificationList.Count; i++)
                CharacterClassifications.Add(DataController.NPCData.NPCClassificationList[i].ListName);
        }

        [RelayCommand]
        async Task SaveOptions()
        {
            DataController.NameData.selectedMasculineListIndex = MasculineListIndex;
            DataController.NameData.selectedFeminineListIndex = FeminineListIndex;
            DataController.NameData.selectedSurnameListIndex = SurnameListIndex;
            await Shell.Current.GoToAsync($"../../{nameof(NPCGeneratorPage)}", true,
                new Dictionary<string, object>
                {
                    {"MasculineListIndex", MasculineListIndex },
                    {"FeminineListIndex", FeminineListIndex },
                    {"SurnameListIndex", SurnameListIndex }
                });
        }

        [RelayCommand]
        public void AddGroup(string groupName)
        {
            if (string.IsNullOrEmpty(groupName) || DataController.NPCData.NameInList(groupName))
                return;

            DataController.NPCData.CreateNewClassification(groupName);
            CharacterClassifications.Add(groupName);
            DataController.SaveNPCData();
            ListGroupToAdd = string.Empty;
            AddVisible = false;
        }

        [RelayCommand]
        public void DeleteList(string groupName)
        {
            if (string.IsNullOrEmpty(groupName))
                return;
            DataController.NPCData.DeleteClassification(groupName);
            CharacterClassifications.Remove(groupName);
            DataController.SaveNPCData();
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public void ToggleAddMenu()
        {
            AddVisible = !AddVisible;
            if (AddVisible)
            {
                ExpandImage = "expand";
            }
            else
            {
                ExpandImage = "retract";
            }
        }
    }
}
