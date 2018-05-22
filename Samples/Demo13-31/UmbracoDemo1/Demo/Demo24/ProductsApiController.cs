using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.WebApi;

namespace UmbracoDemo1.Demo.Demo24
{
    /// <summary>
    /// /umbraco/api/ProductsApi/{methodName}
    /// </summary>
    public class ProductsApiController : UmbracoApiController
    {
        ProductModel[] products = new ProductModel[]
            {
                new ProductModel { Id = 1, Name = "Test name 1", Category = "Normale"},
                new ProductModel { Id = 2, Name = "Test name 2", Category = "Normale"},
                new ProductModel { Id = 3, Name = "Test name 3", Category = "Plus"},
            };

        public IEnumerable<ProductModel> GetAllProducts()
        {
            return products;
        }

        public ProductModel GetProductById(int productId)
        {
            var product = products.FirstOrDefault(p => p.Id == productId);
            return product;
        }
    }
}