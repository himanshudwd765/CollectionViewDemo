using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollectionViewDemo.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsArticleTileComponent : StackLayout
    {
        public NewsArticleTileComponent()
        {
            InitializeComponent();

            AbsoluteLayout.SetLayoutBounds(container, new Rectangle(0, 0, 1, 100));
            AbsoluteLayout.SetLayoutFlags(container, AbsoluteLayoutFlags.WidthProportional);

            AbsoluteLayout.SetLayoutBounds(imgContainer, new Rectangle(0, 0, 100, 100));
            AbsoluteLayout.SetLayoutFlags(imgContainer, AbsoluteLayoutFlags.None);

            AbsoluteLayout.SetLayoutBounds(textContainer, new Rectangle(110, 0, .7, 80));
            AbsoluteLayout.SetLayoutFlags(textContainer, AbsoluteLayoutFlags.WidthProportional);
        }
    }
}