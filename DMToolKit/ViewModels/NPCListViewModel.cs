using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Pages;
using DMToolKit.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DMToolKit.ViewModels
{
    public partial class NPCListViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<NPCClassificationList> characterClassificationList;

        DataController DataController;

        int classListIndex;
        int characterListIndex;

        public NPCListViewModel()
        {
            CharacterClassificationList = new ObservableCollection<NPCClassificationList>();
            DataController = DataController.Instance;
            UpdateNPCList();
            classListIndex = -1;
            characterListIndex = -1;
        }

        public void UpdateNPCList(bool resetView = true)
        {
            if (DataController.NPCData.NPCClassificationList.Count == 0)
                return;
            CharacterClassificationList.Clear();
            for (int i = 0; i < DataController.NPCData.NPCClassificationList.Count; i++)
            {
                if(resetView)
                    DataController.NPCData.NPCClassificationList[i].ListVisible = false;
                CharacterClassificationList.Add(DataController.NPCData.NPCClassificationList[i]);
            }
        }

        [RelayCommand]
        public void Delete(NPC npc)
        {
            classListIndex = DataController.NPCData.GetNPCClassListIndex(npc.Classification);
            characterListIndex = DataController.NPCData.GetNPCIndex(npc, classListIndex);

            if (classListIndex == -1 || characterListIndex == -1)
                return;

            DataController.NPCData.NPCClassificationList[classListIndex].Collection.RemoveAt(characterListIndex);

            DataController.SaveNPCData();

            UpdateNPCList(false);
        }

        [RelayCommand]
        async Task GoToDetails(NPC input)
        {
            if (input is null)
                return;

            await Shell.Current.GoToAsync($"{nameof(NPCDetailsPage)}", true,
                new Dictionary<string, object>
                {
                    {"Character", input }
                });
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync($"..");
        }

        [RelayCommand]
        void ToggleListVisibility(NPCClassificationList list)
        {
            if (list == null) return;
            list.ListVisible = !list.ListVisible;
        }
    }
}
