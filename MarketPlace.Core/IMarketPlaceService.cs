using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Core
{
    public interface IMarketPlaceService
    {
        void ProductAdd(string code, string name, string description, decimal unitPrice, Guid categoryId, string image);

        void ProductCategoryAdd(string code, string name);

        IEnumerable<ProductCategory> ProductCategoryList();

        IEnumerable<Product> ProductList();
    }
}
