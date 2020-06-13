using CollectionViewDemo.Models;
using CollectionViewDemo.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CollectionViewDemo.ViewModels
{
    public class NewsArticleViewModel : BaseViewModel
    {
        private ApiManager apiManager;
        public ObservableCollection<Article> Articles { get; set; }

        #region Commands
        public Command GetNewsItemCommand { get; set; }
        public Command ChangeLayoutCommand { get; set; } 
        #endregion

        public NewsArticleViewModel()
        {
            apiManager = new ApiManager();
            GetNewsItemCommand = new Command(async () => await ExecuteLoadNewsItemsCommand());
            ChangeLayoutCommand = new Command((x) => ChangeLayout(x));
        }

        async Task ExecuteLoadNewsItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var result = await apiManager.GetNewArticleAsync();
                if (result != null)
                    Articles = new ObservableCollection<Article>(result.Articles);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void ChangeLayout(object listLayout)
        {
            var result = Articles.ToList();

            switch (listLayout)
            {
                case "CardView":
                        result.ForEach(x => x.TemplateType = "card");
                    break;
                case "ListView":
                    result.ForEach(x => x.TemplateType = "list");
                    break;
            }

            Articles.Clear();
            Articles = new ObservableCollection<Article>(result);
        }

    }
}
