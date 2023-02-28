using DMToolKit.Data;

namespace DMToolKit.Services
{
    public class NameData
    {
        public int selectedMasculineListIndex;
        public int selectedFeminineListIndex;
        public int selectedSurnameListIndex;

        //Name Lists
        public List<ThemedNameCollection> ThemedNameCollections;

        public NameData() 
        {
            ThemedNameCollections = new List<ThemedNameCollection>();
        }

        public NameData(bool InitialStartup)
        {
            ThemedNameCollections = new List<ThemedNameCollection>();
            selectedMasculineListIndex = 0;
            selectedFeminineListIndex = 1;
            selectedSurnameListIndex = 2;
            if (InitialStartup) 
            {
                ThemedNameCollections.Add(new ThemedNameCollection("Masculine"));
                ThemedNameCollections[selectedMasculineListIndex].Collection.Add("Albert");
                ThemedNameCollections[selectedMasculineListIndex].Collection.Add("Merlin");

                ThemedNameCollections.Add(new ThemedNameCollection("Feminine"));
                ThemedNameCollections[selectedFeminineListIndex].Collection.Add("Keenah");
                ThemedNameCollections[selectedFeminineListIndex].Collection.Add("Nara");

                ThemedNameCollections.Add(new ThemedNameCollection("Surname"));
                ThemedNameCollections[selectedSurnameListIndex].Collection.Add("Vander");
                ThemedNameCollections[selectedSurnameListIndex].Collection.Add("Gelspar");
            }
        }

        public bool ListNameExists(string name)
        {
            for(int i = 0; i < ThemedNameCollections.Count; i++)
                if (ThemedNameCollections[i].Name == name) return true;
            return false;
        }

        public void AddNameToList(string name)
        {
            ThemedNameCollections.Add(new ThemedNameCollection(name));
        }

        public void DeleteNameFromList(string name) 
        {
            for(int i = 0; i < ThemedNameCollections.Count; i++) 
            {
                if (ThemedNameCollections[i].Name == name)
                    ThemedNameCollections.RemoveAt(i);
            }
        }
    }
}
