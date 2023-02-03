using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DMToolKit.Services
{
    public static class DataController
    {
        public static NPCData NPCData { get; set; }
        public static NameConstructionData NameConstructionData { get; set; }
        public static NameData NameData { get; set; }

        private static string npcDataName = $"{FileSystem.AppDataDirectory}/{nameof(NPCData)}.xml";
        private static string nameDataName = $"{FileSystem.AppDataDirectory}/{nameof(NameData)}.xml";
        private static string nameConstructionDataName = $"{FileSystem.AppDataDirectory}/{nameof(NameConstructionData)}.xml";

        //NPC Loading & Saving
        public static void LoadNPCData()
        {
            if(File.Exists(npcDataName)) 
            {
                XmlSerializer xmlSerializer= new XmlSerializer(typeof(NPCData));
                TextReader reader = new StreamReader(npcDataName);
                NPCData = (NPCData)xmlSerializer.Deserialize(reader);
                reader.Close();
            }
            else
            {
                NPCData = new NPCData();
                SaveNPCData();
            }
        }

        public static void SaveNPCData()
        {
            XmlSerializer xmlSerializer= new XmlSerializer(typeof(NPCData));
            TextWriter writer = new StreamWriter(npcDataName);
            xmlSerializer.Serialize(writer, NPCData);
            writer.Close();
        }

        //Name Data Loading & Saving
        public static void LoadNameData()
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
                NameData = new NameData();
                SaveNameData();
            }
        }

        public static void SaveNameData()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(NameData));
            TextWriter writer = new StreamWriter(nameDataName);
            xmlSerializer.Serialize(writer, NameData);
            writer.Close();
        }

        //Name Constructino Data Loading & Saving
        public static void LoadNameConstructionData()
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
                NameConstructionData = new NameConstructionData();
                SaveNameConstructionData();
            }
        }

        public static void SaveNameConstructionData()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(NameConstructionData));
            TextWriter writer = new StreamWriter(nameConstructionDataName);
            xmlSerializer.Serialize(writer, NameConstructionData);
            writer.Close();
        }
    }
}
