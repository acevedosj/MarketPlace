using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;
using System.Xml.Linq;

namespace MarketPlace.Core.ParameterBindings
{
    public class FromBodyMultipartBinding : HttpParameterBinding
    {
        public IDictionary<string, Func<string, object>> ContentTypeResolvers
        {
            get;
            private set;
        }

        public Type ViewModelType
        {
            get;
            private set;
        }

        public FromBodyMultipartBinding(HttpParameterDescriptor parameter) : base(parameter)
        {
            this.ViewModelType = parameter.ParameterType;
            this.ContentTypeResolvers = new Dictionary<string, Func<string, object>>()
            {
                { "application/json", new Func<string, object>((string stringContent) => {
                    object viewModel = JsonConvert.DeserializeObject(stringContent, this.ViewModelType);
                    List<ValidationResult> validationResults = new List<ValidationResult>();
                    ValidationContext context = new ValidationContext(viewModel);
                    return viewModel;
                }) }
            };
            Func<string, object> xmlContentTypeResolver = (string stringContent) => XElement.Parse(stringContent);
            this.ContentTypeResolvers.Add("text/xml", xmlContentTypeResolver);
            this.ContentTypeResolvers.Add("application/xml", xmlContentTypeResolver);
        }

        public override async Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            string mediaType;
            bool flag;
            HttpRequestMessage request = actionContext.Request;
            string raw = await HttpRequestMessageExtensions.ToRaw(request);
            string str = raw;
            raw = null;
            HttpHeaderValueCollection<MediaTypeWithQualityHeaderValue> accept = request.Headers.Accept;
            if (accept != null)
            {
                MediaTypeWithQualityHeaderValue mediaTypeWithQualityHeaderValue = accept.SingleOrDefault<MediaTypeWithQualityHeaderValue>();
                if (mediaTypeWithQualityHeaderValue != null)
                {
                    mediaType = mediaTypeWithQualityHeaderValue.MediaType;
                }
                else
                {
                    mediaType = null;
                }
            }
            else
            {
                mediaType = null;
            }
            string str1 = mediaType;
            flag = (string.IsNullOrEmpty(str1) ? true : str1 == "*/*");
            if (flag)
            {
                str1 = "application/json";
            }
            if (str.StartsWith("<"))
            {
                str1 = "application/xml";
            }
            Func<string, object> item = this.ContentTypeResolvers[str1];
            actionContext.ActionArguments[base.Descriptor.ParameterName] = item(str);
            request = null;
            str = null;
            str1 = null;
            item = null;
        }

       
    }
}
