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
        public List<Name> MasculineNameList;
        public List<Name> FeminineNameList;
        public List<Name> LastNameList;

        public NameData() 
        {
            MasculineNameList = new List<Name>();
            FeminineNameList = new List<Name>();
            LastNameList = new List<Name>();
        }

        public NameData(bool InitialStartup)
        {
            MasculineNameList = new List<Name>();
            FeminineNameList = new List<Name>();
            LastNameList = new List<Name>();
            if (InitialStartup) 
            {
                MasculineNameList.Add(new Name("Mer", "lin"));

                MasculineNameList.Add(new Name("Dal", "mar"));

                FeminineNameList.Add(new Name("Kee", "nah"));

                FeminineNameList.Add(new Name("Na" , "ra"));

                LastNameList.Add(new Name("Van" , "der"));

                LastNameList.Add(new Name("Gel", "spar"));
            }
        }
    }
}
