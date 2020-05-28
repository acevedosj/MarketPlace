using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Core
{
    public class Product
    {
        public string CategoryCode
        {
            get;
            set;
        }

        public Guid CategoryId
        {
            get;
            set;
        }

        public string CategoryName
        {
            get;
            set;
        }

        public string Code
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Image
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public Guid ProductId
        {
            get;
            set;
        }

        public decimal UnitPrice
        {
            get;
            set;
        }

        public Product()
        {
        }
    }
}
