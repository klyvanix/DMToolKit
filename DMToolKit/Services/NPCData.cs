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
                NPCCategories.Add("Barbarian");
                NPCCategories.Add("Bard");
                NPCCategories.Add("Cleric");
                NPCCategories.Add("Peasant");
            }
        }
    }
}
