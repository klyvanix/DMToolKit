using DMToolKit.Data;

namespace DMToolKit.Services
{
    public class NameData
    {
        //Name Lists
        public List<ThemedNameCollection> ThemedNameCollections;

        public NameData() 
        {
            ThemedNameCollections = new List<ThemedNameCollection>();
        }

        public NameData(bool InitialStartup)
        {
            ThemedNameCollections = new List<ThemedNameCollection>();
            if (InitialStartup) 
            {
                ThemedNameCollections.Add(new ThemedNameCollection("Masculine"));
                ThemedNameCollections[0].Collection.Add("Albert");
                ThemedNameCollections[0].Collection.Add("Merlin");

                ThemedNameCollections.Add(new ThemedNameCollection("Feminine"));
                ThemedNameCollections[1].Collection.Add("Keenah");
                ThemedNameCollections[1].Collection.Add("Nara");

                ThemedNameCollections.Add(new ThemedNameCollection("Surname"));
                ThemedNameCollections[2].Collection.Add("Vander");
                ThemedNameCollections[2].Collection.Add("Gelspar");
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
