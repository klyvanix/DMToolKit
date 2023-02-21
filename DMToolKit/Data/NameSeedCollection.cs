using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.Data
{
    public class NameSeedCollection
    {
        private string _name;
        public string ListName
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                    return;
                _name = value;
            }
        }

        public List<string> PrefixList;
        public List<string> SuffixList;

        public NameSeedCollection()
        {
            ListName = string.Empty;
            PrefixList = new List<string>();
            SuffixList = new List<string>();

            PrefixList.Add("A");
            PrefixList.Add("B");
            PrefixList.Add("C");
            PrefixList.Add("D");
            PrefixList.Add("E");
            PrefixList.Add("F");
            PrefixList.Add("G");
            PrefixList.Add("H");
            PrefixList.Add("I");
            PrefixList.Add("J");
            PrefixList.Add("K");
            PrefixList.Add("L");
            PrefixList.Add("M");
            PrefixList.Add("N");
            PrefixList.Add("O");
            PrefixList.Add("P");
            PrefixList.Add("Q");
            PrefixList.Add("R");
            PrefixList.Add("S");
            PrefixList.Add("T");
            PrefixList.Add("U");
            PrefixList.Add("V");
            PrefixList.Add("W");
            PrefixList.Add("X");
            PrefixList.Add("Y");
            PrefixList.Add("Z");

            SuffixList.Add("a");
            SuffixList.Add("b");
            SuffixList.Add("c");
            SuffixList.Add("d");
            SuffixList.Add("e");
            SuffixList.Add("f");
            SuffixList.Add("g");
            SuffixList.Add("h");
            SuffixList.Add("i");
            SuffixList.Add("j");
            SuffixList.Add("k");
            SuffixList.Add("l");
            SuffixList.Add("m");
            SuffixList.Add("n");
            SuffixList.Add("o");
            SuffixList.Add("p");
            SuffixList.Add("q");
            SuffixList.Add("r");
            SuffixList.Add("s");
            SuffixList.Add("t");
            SuffixList.Add("u");
            SuffixList.Add("v");
            SuffixList.Add("w");
            SuffixList.Add("x");
            SuffixList.Add("y");
            SuffixList.Add("z");
        }

        public NameSeedCollection(string name) 
        {
            ListName = name;
            PrefixList = new List<string>();
            SuffixList = new List<string>();

            PrefixList.Add("A");
            PrefixList.Add("B");
            PrefixList.Add("C");
            PrefixList.Add("D");
            PrefixList.Add("E");
            PrefixList.Add("F");
            PrefixList.Add("G");
            PrefixList.Add("H");
            PrefixList.Add("I");
            PrefixList.Add("J");
            PrefixList.Add("K");
            PrefixList.Add("L");
            PrefixList.Add("M");
            PrefixList.Add("N");
            PrefixList.Add("O");
            PrefixList.Add("P");
            PrefixList.Add("Q");
            PrefixList.Add("R");
            PrefixList.Add("S");
            PrefixList.Add("T");
            PrefixList.Add("U");
            PrefixList.Add("V");
            PrefixList.Add("W");
            PrefixList.Add("X");
            PrefixList.Add("Y");
            PrefixList.Add("Z");

            SuffixList.Add("a");
            SuffixList.Add("b");
            SuffixList.Add("c");
            SuffixList.Add("d");
            SuffixList.Add("e");
            SuffixList.Add("f");
            SuffixList.Add("g");
            SuffixList.Add("h");
            SuffixList.Add("i");
            SuffixList.Add("j");
            SuffixList.Add("k");
            SuffixList.Add("l");
            SuffixList.Add("m");
            SuffixList.Add("n");
            SuffixList.Add("o");
            SuffixList.Add("p");
            SuffixList.Add("q");
            SuffixList.Add("r");
            SuffixList.Add("s");
            SuffixList.Add("t");
            SuffixList.Add("u");
            SuffixList.Add("v");
            SuffixList.Add("w");
            SuffixList.Add("x");
            SuffixList.Add("y");
            SuffixList.Add("z");
        }
    }
}
