using CollectionViewDemo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace CollectionViewDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsArticleView : ContentPage
    {
        private string _currentColorState = "Select";

        NewsArticleViewModel viewModel;

        public NewsArticleView()
        {
            Xamarin.Forms.NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            BindingContext = viewModel = new NewsArticleViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var safeInsets = On<iOS>().SafeAreaInsets();
            safeInsets.Bottom = 0;
            Padding = safeInsets;
            viewModel?.GetNewsItemCommand.Execute(null);
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            if (_currentColorState == "Select")
            {
                _currentColorState = "UnSelect";
            }
            else
            {
                _currentColorState = "Select";
            }

            VisualStateManager.GoToState(tileFrame, _currentColorState);
            VisualStateManager.GoToState(squareIcon, _currentColorState);
            VisualStateManager.GoToState(listFrame, _currentColorState);
            VisualStateManager.GoToState(listIcon, _currentColorState);

            var param = ((Label)sender).ClassId;
            viewModel?.ChangeLayoutCommand.Execute(param);

        }
    }
}