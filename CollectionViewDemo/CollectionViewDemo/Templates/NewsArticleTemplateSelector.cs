using CollectionViewDemo.Models;
using Xamarin.Forms;

namespace CollectionViewDemo.Templates
{
    public class NewsArticleTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CardViewTemplate { get; set; }
        public DataTemplate TileViewTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((Article)item).TemplateType.Equals("card") ? CardViewTemplate : TileViewTemplate;
        }
    }
}
