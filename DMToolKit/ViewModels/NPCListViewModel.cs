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
        ObservableCollection<NPC> npcList;

        //[ObservableProperty]
        //ObservableCollection<NPC> npcCategoryList;

        DataController DataController;

        public NPCListViewModel()
        {
            NpcList = new ObservableCollection<NPC>();
            DataController = DataController.Instance;
            UpdateNPCList();
        }

        public void UpdateNPCList()
        {
            if (DataController.NPCData.NPCList.Count == 0 || DataController.NPCData.NPCList == null)
                return;

            NpcList.Clear();
            foreach(var item in DataController.NPCData.NPCList)
                NpcList.Add(item);
        }

        [RelayCommand]
        public void Delete(NPC npc)
        {
            if (NpcList.Contains(npc))
            {
                NpcList.Remove(npc);
                Savedata();
            }

            //foreach (var list in NpcCategoryList)
            //{
            //if (list.Contains(npc))
            //    {
            //        list.Remove(npc);
            //        Savedata();
            //    }
            //}
        }

        private void Savedata()
        {
            DataController.NPCData.NPCList = NpcList.ToList();
            DataController.SaveNPCData();
            UpdateNPCList();
        }
    }
}
