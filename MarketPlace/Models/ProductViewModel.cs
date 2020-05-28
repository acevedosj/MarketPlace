using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MarketPlace.Models
{
    [DataContract(Name = "Product")]
    public class ProductViewModel
    {
        [DataMember(Name = "CategoryId")]
        public Guid CategoryId
        {
            get;
            set;
        }

        [DataMember(Name = "Code")]
        public string Code
        {
            get;
            set;
        }

        [DataMember(Name = "Description")]
        public string Description
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

        [DataMember(Name = "UnitPrice")]
        public decimal UnitPrice
        {
            get;
            set;
        }

        public ProductViewModel()
        {
        }
    }
}