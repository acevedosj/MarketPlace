using MarketPlace.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace MarketPlace.Core.ParameterBindings
{
    public class AttachmentParameterBindingAttribute : ParameterBindingAttribute
    {
        public AttachmentParameterBindingAttribute()
        {
        }

        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            HttpParameterBinding attachmentParameterBinding;
            if (parameter.ParameterType != typeof(IEnumerable<Attachment>))
            {
                attachmentParameterBinding = parameter.BindAsError("Expected type IEnumerable<Attachment>");
            }
            else
            {
                attachmentParameterBinding = new AttachmentParameterBinding(parameter);
            }
            return attachmentParameterBinding;
        }
    }
}
