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
            NameConstructionData = new NameConstructionData();
            NameData= new NameData();
        }

        public NPCData NPCData { get; set; }
        public NameConstructionData NameConstructionData { get; set; }
        public NameData NameData { get; set; }

        private static string npcDataName = $"{FileSystem.AppDataDirectory}/NPCData.xml";
        private static string nameDataName = $"{FileSystem.AppDataDirectory}/NameData.xml";
        private static string nameConstructionDataName = $"{FileSystem.AppDataDirectory}/NameConstructionData.xml";

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
        public void LoadNameConstructionData()
        {
            if (File.Exists(nameConstructionDataName))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(NameConstructionData));
                TextReader reader = new StreamReader(nameConstructionDataName);
                NameConstructionData = (NameConstructionData)xmlSerializer.Deserialize(reader);
                reader.Close();
            }
            else
            {
                NameConstructionData = new NameConstructionData(true);
                SaveNameConstructionData();
            }
        }

        public void SaveNameConstructionData()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(NameConstructionData));
            TextWriter writer = new StreamWriter(nameConstructionDataName);
            xmlSerializer.Serialize(writer, NameConstructionData);
            writer.Close();
        }
    }
}
