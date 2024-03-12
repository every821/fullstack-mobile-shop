using MobileShopShared.Models;
using MobileShopShared.Responses;

namespace MobileShopServer.Repositories
{
    public interface ICategory
    {
        Task<ServiceResponse> AddCategory(Category model);
        Task<List<Category>> GetAllCategories();
    }
}
