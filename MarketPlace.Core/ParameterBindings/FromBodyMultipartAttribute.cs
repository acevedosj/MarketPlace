using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace MarketPlace.Core.ParameterBindings
{
    public class FromBodyMultipartAttribute : ParameterBindingAttribute
    {
        public string ContentType
        {
            get;
            set;
        }

        public FromBodyMultipartAttribute()
        {
        }

        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            return new FromBodyMultipartBinding(parameter);
        }
    }
}


