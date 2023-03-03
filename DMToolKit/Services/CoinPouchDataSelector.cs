using DMToolKit.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.Services
{
    internal class CoinPouchDataSelector : DataTemplateSelector
    {
        public DataTemplate Coin { get; set; }
        public DataTemplate Mixed { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var pouch = item as CoinPouch;
            if (pouch.TotalNumberOfGems == 0)
                return Coin;
            else
                return Mixed;
        }
    }
}
