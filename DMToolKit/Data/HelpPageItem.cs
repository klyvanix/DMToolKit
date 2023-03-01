using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.Data
{
    public class HelpPageItem
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public HelpPageItem() 
        {
            Title= string.Empty;
            Description= string.Empty;
        }
        public HelpPageItem(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
