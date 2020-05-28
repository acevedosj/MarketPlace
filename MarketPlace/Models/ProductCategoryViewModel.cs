using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MarketPlace.Models
{
    [DataContract(Name = "ProductCategory")]
    public class ProductCategoryViewModel
    {
        [DataMember(Name = "Code")]
        public string Code
        {
            get;
            set;
        }

        [DataMember(Name = "Name")]
        public string Name
        {
            get;
            set;
        }

        public ProductCategoryViewModel()
        {
        }
    }
}