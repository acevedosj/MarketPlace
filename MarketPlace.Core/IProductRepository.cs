using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Core
{
    public interface IProductRepository
    {
        Product FindProductByCode(string code);

        ProductCategory FindProductCategoryByCode(string code);

        IEnumerable<ProductCategory> ProductCategoryList();

        IEnumerable<Product> ProductList();

        void SaveCategory(ProductCategory newProductCategory);

        void SaveProduct(Product newProduct);
    }
}
