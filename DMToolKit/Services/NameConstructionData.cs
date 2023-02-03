using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.Services
{
    public class NameConstructionData
    {
        //Suffix Lists
        public List<string> PrefixList;
        public List<string> SuffixList;

        public NameConstructionData() 
        {
            PrefixList = new List<string>();
            SuffixList = new List<string>();
        }
    }
}
