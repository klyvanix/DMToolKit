using DMToolKit.Data;

namespace DMToolKit.Services 
{
    internal class NPCHelpPageSelector : DataTemplateSelector
    {
        public DataTemplate Default { get; set; }
        public DataTemplate Page1 { get; set; }
        public DataTemplate Page2 { get; set; }
        public DataTemplate Page3 { get; set; }
        public DataTemplate Page4 { get; set; }
        public DataTemplate Page5 { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var page = item as HelpPageItem;
            if (page != null)
            {
                switch (page.PageNumber)
                {
                    case 1: return Page1;
                    case 2: return Page2;
                    case 3: return Page3;
                    case 4: return Page4;
                    case 5: return Page5;
                }
            }

            return Default;
        }
    }
}
