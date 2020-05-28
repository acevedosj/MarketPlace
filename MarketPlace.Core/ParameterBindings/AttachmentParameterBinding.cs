using MarketPlace.Core.Model;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;

namespace MarketPlace.Core.ParameterBindings
{
    public class AttachmentParameterBinding : HttpParameterBinding
    {
        public AttachmentParameterBinding(HttpParameterDescriptor parameter) : base(parameter)
        {
        }

        public override async Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            IEnumerable<Attachment> attachments = await HttpRequestMessageExtensions.ToAttachments(actionContext.Request);
            IEnumerable<Attachment> attachments1 = attachments;
            attachments = null;
            actionContext.ActionArguments[base.Descriptor.ParameterName] = attachments1;
            attachments1 = null;
        }
    }
}
