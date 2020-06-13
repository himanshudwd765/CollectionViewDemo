using Acr.UserDialogs;
using CollectionViewDemo.Models;
using MonkeyCache.FileStore;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace CollectionViewDemo.Services
{
    public class ApiManager : IApiManager
    {
        const string url = "https://newsapi.org/v2/top-headlines?country=in&pageSize=10&apiKey=7025ecb77e2a46c4a901e9ce9ddcbd97";

        public ApiManager()
        {
            Barrel.ApplicationId = "CachingNewsData";
        }
        public async Task<News> GetNewArticleAsync()
        {
            try
            {
                if (Connectivity.NetworkAccess != NetworkAccess.Internet && !Barrel.Current.IsExpired(key: url))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Please check your internet connectivity and try again", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<News>(key: url);
                }

                var client = new HttpClient();
                var json = await client.GetStringAsync(url);
                var newsArticles = JsonConvert.DeserializeObject<News>(json);

                //Saves the cache and set a timespan for expiration
                Barrel.Current.Add(key: url, data: newsArticles, expireIn: TimeSpan.FromDays(1));

                return newsArticles;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return null;
        }
    }
}
