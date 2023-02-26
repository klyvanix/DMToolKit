using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DMToolKit.Services
{
    public class DataController 
    {
        public static DataController instance = null;

        public static DataController Instance
        {
            get 
            {
                if(instance == null)
                    instance = new DataController();
                return instance;
            }
        }

        private DataController() 
        {
            NPCData = new NPCData();
            NameSeedData = new NameSeedData();
            NameData= new NameData();
        }

        public NPCData NPCData { get; set; }
        public NameSeedData NameSeedData { get; set; }
        public NameData NameData { get; set; }

        private static string npcDataName = $"{FileSystem.AppDataDirectory}/NPCData.xml";
        private static string nameDataName = $"{FileSystem.AppDataDirectory}/NameData.xml";
        private static string nameSeedDataName = $"{FileSystem.AppDataDirectory}/NameConstructionData.xml";

        //NPC Loading & Saving
        public void LoadNPCData()
        {
            if (File.Exists(npcDataName)) 
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(NPCData));
                TextReader reader = new StreamReader(npcDataName);
                NPCData = (NPCData)xmlSerializer.Deserialize(reader);
                reader.Close();
            }
            else
            {
                NPCData = new NPCData(true);
                SaveNPCData();
            }
        }

        public void SaveNPCData()
        {
            XmlSerializer xmlSerializer= new XmlSerializer(typeof(NPCData));
            TextWriter writer = new StreamWriter(npcDataName);
            xmlSerializer.Serialize(writer, NPCData);
            writer.Close();
        }

        //Name Data Loading & Saving
        public void LoadNameData()
        {
            if (File.Exists(nameDataName))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(NameData));
                TextReader reader = new StreamReader(nameDataName);
                NameData = (NameData)xmlSerializer.Deserialize(reader);
                reader.Close();
            }
            else
            {
                NameData = new NameData(true);
                SaveNameData();
            }
        }

        public void SaveNameData()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(NameData));
            TextWriter writer = new StreamWriter(nameDataName);
            xmlSerializer.Serialize(writer, NameData);
            writer.Close();
        }

        //Name Constructino Data Loading & Saving
        public void LoadNameSeedData()
        {
            if (File.Exists(nameSeedDataName))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(NameSeedData));
                TextReader reader = new StreamReader(nameSeedDataName);
                NameSeedData = (NameSeedData)xmlSerializer.Deserialize(reader);
                reader.Close();
            }
            else
            {
                NameSeedData = new NameSeedData(true);
                SaveNameSeedData();
            }
        }

        public void SaveNameSeedData()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(NameSeedData));
            TextWriter writer = new StreamWriter(nameSeedDataName);
            xmlSerializer.Serialize(writer, NameSeedData);
            writer.Close();
        }

        internal int GetMinIndex(string lockedLetter)
        {
            for(int i = 0; i < NameSeedData.PrefixList.Count; i++)
            {
                if (NameSeedData.PrefixList[i].StartsWith(lockedLetter))
                    return i;
            }
            return -1;
        }

        internal int GetMaxIndex(int minIndex, string lockedLetter)
        {
            if(minIndex != -1)
            {
                if(lockedLetter == "Z")
                    return NameSeedData.PrefixList.Count + 1;

                for (int i = minIndex; i < (NameSeedData.PrefixList.Count); i++)
                {
                    if(i < NameSeedData.PrefixList.Count - 1)
                    {
                        if (!NameSeedData.PrefixList[i + 1].StartsWith(lockedLetter))
                            return i + 1;
                    }
                }
            }
            return -1;
        }
    }
}
