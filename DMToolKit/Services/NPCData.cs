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
        public List<NPCClassificationList> NPCClassificationList;

        public NPCData()
        {
            NPCList = new List<NPC>();
            NPCCategories = new List<string>();
        }

        public NPCData(bool initialStartup)
        {
            NPCList = new List<NPC>();
            NPCClassificationList = new List<NPCClassificationList>();
            if (initialStartup)
            {
                NPCClassificationList.Add(new NPCClassificationList("Commoner"));
            }
        }

        public void CreateNewClassification(string name)
        {
            for (int i = 0; i < NPCClassificationList.Count; i++)
                if (NPCClassificationList[i].ListName == name)
                    return;

            NPCClassificationList.Add(new NPCClassificationList(name));
        }

        public void DeleteClassification(string name)
        {
            for (int i = 0; i < NPCClassificationList.Count; i++)
            {
                if (NPCClassificationList[i].ListName == name)
                    NPCClassificationList.RemoveAt(i);
            }
        }

        public bool NameInList(string name)
        {
            for (int i = 0; i < NPCClassificationList.Count; i++)
            {
                if (NPCClassificationList[i].ListName == name)
                    return true;
            }
            return false;
        }

        public int GetNPCIndex(NPC character, int classListIndex)
        {
            for (int i = 0; i < NPCClassificationList[classListIndex].Collection.Count; i++)
            {
                if (NPCClassificationList[classListIndex].Collection[i] == character)
                    return i;
            }
            return -1;
        }

        public int GetNPCClassListIndex(string classification)
        {
            for (int i = 0; i < NPCClassificationList.Count; i++)
            {
                if (NPCClassificationList[i].ListName == classification)
                    return i;
            }
            return -1;
        }

        public void AddNPCTtoClassList(NPC character, int characterIndex, int currentClassIndex, int newClassIndex)
        {
            if (currentClassIndex != newClassIndex)
            {
                NPCClassificationList[currentClassIndex].Collection.RemoveAt(characterIndex);
                NPCClassificationList[newClassIndex].Collection.Add(character);
            }
            else
            {
                NPCClassificationList[currentClassIndex].Collection[characterIndex] = character;
            }
        }
        public void AddNPCTtoClassList(NPC character, int classIndex)
        {
            var NPCindex = GetNPCIndex(character, classIndex);
            if (NPCindex == -1)
                NPCClassificationList[classIndex].Collection.Add(character);
        }

        public void DeleteNPCFromClassList(int classIndex, int characterIndex)
        {
            if (classIndex == -1 || characterIndex == -1 || characterIndex >= NPCClassificationList[classIndex].Collection.Count || classIndex >= NPCClassificationList.Count )
                return;
            NPCClassificationList[classIndex].Collection.RemoveAt(characterIndex);
        }

        public void OverwriteNPCInClassList(NPC character, int classIndex, int characterIndex)
        {
            if (classIndex == -1 || characterIndex == -1 || characterIndex >= NPCClassificationList[classIndex].Collection.Count || classIndex >= NPCClassificationList.Count)
                return;
            NPCClassificationList[classIndex].Collection[characterIndex] = character;
        }
    }
}
