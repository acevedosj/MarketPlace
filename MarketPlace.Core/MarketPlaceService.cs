using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Core
{
    public class MarketPlaceService : IMarketPlaceService
    {
        private readonly IProductRepository _productRepository;

        public MarketPlaceService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public void ProductAdd(string code, string name, string description, decimal unitPrice, Guid categoryId, string image)
        {
            if (this._productRepository.FindProductByCode(code) != null)
            {
                throw new ArgumentException(string.Concat("Product  with code ", code, " already exists"));
            }
            Product product = new Product()
            {
                ProductId = Guid.NewGuid(),
                Code = code,
                Name = name,
                Description = description,
                UnitPrice = unitPrice,
                CategoryId = categoryId,
                Image = image
            };
            this._productRepository.SaveProduct(product);
        }

        public void ProductCategoryAdd(string code, string name)
        {
            if (this._productRepository.FindProductCategoryByCode(code) != null)
            {
                throw new ArgumentException(string.Concat("ProductCategory  with code ", code, " already exists"));
            }
            ProductCategory productCategory = new ProductCategory()
            {
                ProductCategoryId = Guid.NewGuid(),
                Code = code,
                Name = name
            };
            this._productRepository.SaveCategory(productCategory);
        }

        public IEnumerable<ProductCategory> ProductCategoryList()
        {
            return this._productRepository.ProductCategoryList();
        }

        public IEnumerable<Product> ProductList()
        {
            return this._productRepository.ProductList();
        }
    }

}
