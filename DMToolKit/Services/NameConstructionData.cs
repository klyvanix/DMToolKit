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
        public NameConstructionData(bool initialStartup)
        {
            PrefixList = new List<string>();
            SuffixList = new List<string>();
            if(initialStartup)
            {
                PrefixList.Add("Ado");
                PrefixList.Add("Jas");
                PrefixList.Add("Dala");
                PrefixList.Add("Na");
                PrefixList.Add("Kho");

                SuffixList.Add("lin");
                SuffixList.Add("nar");
                SuffixList.Add("nah");
                SuffixList.Add("vani");
            }
        }
    }
}
