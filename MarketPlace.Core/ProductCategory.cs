using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Core
{
    public class ProductCategory
    {
        public string Code
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public Guid ProductCategoryId
        {
            get;
            set;
        }

        public ProductCategory()
        {
        }
    }
}
