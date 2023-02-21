using DMToolKit.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.Services
{
    public class NameData
    {
        //Name Lists
        public ThemedNameCollection MasculineNameList;
        public ThemedNameCollection FeminineNameList;
        public ThemedNameCollection SurnameNameList;

        public List<ThemedNameCollection> ThemedNameCollections;

        public NameData() 
        {
            MasculineNameList = new ThemedNameCollection("Masculine");
            FeminineNameList = new ThemedNameCollection("Feminine");
            SurnameNameList = new ThemedNameCollection("Surname");
            ThemedNameCollections = new List<ThemedNameCollection>();
        }

        public NameData(bool InitialStartup)
        {
            MasculineNameList = new ThemedNameCollection("Masculine");
            FeminineNameList = new ThemedNameCollection("Feminine");
            SurnameNameList = new ThemedNameCollection("Surname");
            ThemedNameCollections = new List<ThemedNameCollection>();
            if (InitialStartup) 
            {
                MasculineNameList.Collection.Add("Albert");
                MasculineNameList.Collection.Add("Merlin");

                FeminineNameList.Collection.Add("Keenah");
                FeminineNameList.Collection.Add("Nara");

                SurnameNameList.Collection.Add("Vander");
                SurnameNameList.Collection.Add("Gelspar");
                ThemedNameCollections.Add(MasculineNameList);
                ThemedNameCollections.Add(FeminineNameList);
                ThemedNameCollections.Add(SurnameNameList);
            }
        }
    }
}
