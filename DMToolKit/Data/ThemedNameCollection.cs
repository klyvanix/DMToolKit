using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.Data
{
    [Serializable]
    public class ThemedNameCollection
    {
        public string Name { get; set; }
        public List<string> Collection { get; set; }

        public ThemedNameCollection()
        {
            Name= string.Empty;
            Collection = new List<string>();
        }

        public ThemedNameCollection(string name)
        {
            Name = name;
            Collection = new List<string>();
        }

        public void AddNameToCollection(string Name)
        {
            Collection.Add(Name);
            Collection.Sort();
        }

        public void RemoveNameFromCollection(string Name) 
        {
            Collection.Remove(Name);
        }

        public bool ContainsName(string Name)
        {
            for(int i = 0; i < Collection.Count; i++) 
            {
                if (Collection[i] == Name)
                    return true;
            }
            return false;
        }
    }
}
