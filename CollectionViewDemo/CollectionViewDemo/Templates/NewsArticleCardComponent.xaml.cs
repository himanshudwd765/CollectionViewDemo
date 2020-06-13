using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollectionViewDemo.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsArticleCardComponent : StackLayout
    {
        public NewsArticleCardComponent()
        {
            InitializeComponent();
            HeightRequest = 300;
            AbsoluteLayout.SetLayoutBounds(container, new Rectangle(0, 0, 1, 200));
            AbsoluteLayout.SetLayoutFlags(container, AbsoluteLayoutFlags.WidthProportional);

            AbsoluteLayout.SetLayoutBounds(imgContainer, new Rectangle(0, 0, 1, 200));
            AbsoluteLayout.SetLayoutFlags(imgContainer, AbsoluteLayoutFlags.WidthProportional);


            AbsoluteLayout.SetLayoutBounds(textContainer, new Rectangle(0, 200, 1, 80));
            AbsoluteLayout.SetLayoutFlags(textContainer, AbsoluteLayoutFlags.WidthProportional);
        }
    }
}