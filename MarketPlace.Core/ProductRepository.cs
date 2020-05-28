using Insight.Database;
using Insight.Database.Providers.SqlInsightDbProvider;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Core
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        static ProductRepository()
        {
            SqlInsightDbProvider.RegisterProvider();
        }

        public ProductRepository(string connectionString)
        {
            string connectionString2 = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            this._connectionString = connectionString;
        }

        public Product FindProductByCode(string code)
        {
            SqlConnection connection = new SqlConnection(this._connectionString);
            Product product = connection.Single<Product>("sp_Product_FindProductByCode", new { Code = code });
            return product;
        }

        public ProductCategory FindProductCategoryByCode(string code)
        {
            SqlConnection connection = new SqlConnection(this._connectionString);
            ProductCategory productCategory = connection.Single<ProductCategory>("sp_Product_FindCategorytByCode", new { Code = code });
            return productCategory;
        }

        public IEnumerable<ProductCategory> ProductCategoryList()
        {
            SqlConnection connection = new SqlConnection(this._connectionString);
            IList<ProductCategory> product = connection.Query<ProductCategory>("sp_ProductCategory_List");
            return product;
        }

        public IEnumerable<Product> ProductList()
        {
            SqlConnection connection = new SqlConnection(this._connectionString);
            IList<Product> product = connection.Query<Product>("sp_Product_List");
            return product;
        }

        public void SaveCategory(ProductCategory newProductCategory)
        {
            SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Execute("sp_ProductCategory_Save", newProductCategory);
        }

        public void SaveProduct(Product newProduct)
        {
            SqlConnection connection = new SqlConnection(this._connectionString); 
            connection.Execute("sp_Product_Save", newProduct);
        }
    }
}
