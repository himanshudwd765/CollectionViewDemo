using CollectionViewDemo.Models;
using System.Threading.Tasks;

namespace CollectionViewDemo.Services
{
    public interface IApiManager
    {
        Task<News> GetNewArticleAsync();
    }
}
