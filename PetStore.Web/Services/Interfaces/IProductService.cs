using PetStore.Web.Models;

namespace PetStore.Web.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAllProducts(string token);
        Task<ProductModel> GetProductById(string token, long id);
        Task<ProductModel> CreatProduct(string token, ProductModel model);
        Task<ProductModel> UpdateProduct(string token, ProductModel model);
        Task<bool> DeleteProductById(string token, long id);
    }
}
