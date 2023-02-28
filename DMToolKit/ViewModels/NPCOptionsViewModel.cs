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
        public int masculineListIndex;
        [ObservableProperty]
        public int feminineListIndex;
        [ObservableProperty]
        public int surnameListIndex;

        [ObservableProperty]
        public List<string> namesList;

        [ObservableProperty]
        public bool addVisible;

        [ObservableProperty]
        public string listGroupToAdd;

        [ObservableProperty]
        public ObservableCollection<string> npcGroups;

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
            NpcGroups = new ObservableCollection<string>(DataController.NPCData.NPCCategories);
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

            DataController.NPCData.NPCCategories.Add(groupName);
            NpcGroups.Add(groupName);
            ListGroupToAdd = string.Empty;
            AddVisible = false;
        }

        [RelayCommand]
        public void DeleteList(string groupName)
        {
            if (string.IsNullOrEmpty(groupName))
                return;
            DataController.NPCData.NPCCategories.Remove(groupName);
            NpcGroups.Remove(groupName);
            DataController.SaveNameData();
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
        }
    }
}
