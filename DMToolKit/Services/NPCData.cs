using DMToolKit.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.Services
{
    public class NPCData
    {
        public List<NPC> NPCList;
        public List<string> NPCCategories;

        public NPCData() 
        {
            NPCList = new List<NPC>();
            NPCCategories = new List<string>();
        }

        public NPCData(bool initialStartup)
        {
            NPCList = new List<NPC>();
            NPCCategories = new List<string>();
            if (initialStartup)
            {
                NPCCategories.Add("Peasant");
                NPCCategories.Add("Innkeeper");
                NPCCategories.Add("Blacksmith");
                NPCCategories.Add("Merchant");
            }
        }

        public bool NameInList(string name) 
        {
            for(int i = 0; i < NPCCategories.Count; i++) 
            {
                if (NPCCategories[i] == name)
                    return true;
            }
            return false;
        }

        public int GetNPCIndex(NPC character)
        {
            for(int i = 0; i < NPCList.Count; i++) 
            {
                if (NPCList[i] == character) 
                    return i;
            }
            return -1;
        }
    }
}
