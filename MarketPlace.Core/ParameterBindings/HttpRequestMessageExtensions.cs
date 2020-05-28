using MarketPlace.Core.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Core.ParameterBindings
{
    public static class HttpRequestMessageExtensions
    {
        public static async Task<IEnumerable<Attachment>> ToAttachments(HttpRequestMessage request)
        {
            IEnumerable<Attachment> attachments;
            string str;
            Stream result;
            string environmentVariable;
            MultipartFormDataStreamProvider multipartFormDataStreamProvider;
            List<Attachment> attachments1;
            if (request.Content.IsMimeMultipartContent())
            {
                result = request.Content.ReadAsStreamAsync().Result;
                if (result.CanSeek)
                {
                    result.Position = (long)0;
                }
                environmentVariable = Environment.GetEnvironmentVariable("TEMP");
                multipartFormDataStreamProvider = new MultipartFormDataStreamProvider(environmentVariable);
                await request.Content.ReadAsMultipartAsync<MultipartFormDataStreamProvider>(multipartFormDataStreamProvider);
                attachments1 = new List<Attachment>();
                foreach (MultipartFileData fileDatum in multipartFormDataStreamProvider.FileData)
                {
                    string fileName = fileDatum.Headers.ContentDisposition.FileName;
                    if (fileName != null)
                    {
                        str = fileName.Replace("\"", "");
                    }
                    else
                    {
                        str = null;
                    }
                    string str1 = str;
                    Attachment attachment = new Attachment()
                    {
                        FileName = str1,
                        Extension = Path.GetExtension(str1),
                        MimeType = fileDatum.Headers.ContentType.MediaType,
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now,
                        Data = File.ReadAllBytes(fileDatum.LocalFileName)
                    };
                    Attachment attachment1 = attachment;
                    attachments1.Add(attachment1);
                    File.Delete(fileDatum.LocalFileName);
                    str1 = null;
                    attachment1 = null;
                }
                attachments = attachments1;
            }
            else
            {
                attachments = Enumerable.Empty<Attachment>();
            }
            result = null;
            environmentVariable = null;
            multipartFormDataStreamProvider = null;
            attachments1 = null;
            return attachments;
        }

        public static async Task<string> ToRaw(HttpRequestMessage request)
        {
            string str;
            bool flag;
            bool count;
            string item;
            string str1;
            string str2;
            Stream stream;
            string environmentVariable;
            MultipartFormDataStreamProvider multipartFormDataStreamProvider;
            HttpContent httpContent;
            string str3;
            QuotedPrintableService quotedPrintableService;
            if (request.Content.IsMimeMultipartContent())
            {
                Stream stream1 = await request.Content.ReadAsStreamAsync();
                stream = stream1;
                stream1 = null;
                if (stream.CanSeek)
                {
                    stream.Position = (long)0;
                }
                environmentVariable = Environment.GetEnvironmentVariable("TEMP");
                MultipartFormDataStreamProvider multipartFormDataStreamProvider1 = await request.Content.ReadAsMultipartAsync<MultipartFormDataStreamProvider>(new MultipartFormDataStreamProvider(environmentVariable));
                multipartFormDataStreamProvider = multipartFormDataStreamProvider1;
                multipartFormDataStreamProvider1 = null;
                httpContent = multipartFormDataStreamProvider.Contents.FirstOrDefault<HttpContent>();
                if (httpContent != null)
                {
                    flag = false;
                }
                else
                {
                    HttpContentHeaders httpContentHeader = httpContent.Headers;
                    if (httpContentHeader != null)
                    {
                        ContentDispositionHeaderValue contentDispositionHeaderValue = httpContentHeader.ContentDisposition;
                        if (contentDispositionHeaderValue != null)
                        {
                            str2 = contentDispositionHeaderValue.FileName;
                        }
                        else
                        {
                            str2 = null;
                        }
                    }
                    else
                    {
                        str2 = null;
                    }
                    flag = string.IsNullOrEmpty(str2);
                }
                if (flag)
                {
                    Collection<HttpContent> contents = multipartFormDataStreamProvider.Contents;
                    httpContent = contents.FirstOrDefault<HttpContent>((HttpContent c) => {
                        string fileName;
                        HttpContentHeaders headers = c.Headers;
                        if (headers != null)
                        {
                            ContentDispositionHeaderValue contentDisposition = headers.ContentDisposition;
                            if (contentDisposition != null)
                            {
                                fileName = contentDisposition.FileName;
                            }
                            else
                            {
                                fileName = null;
                            }
                        }
                        else
                        {
                            fileName = null;
                        }
                        return string.IsNullOrWhiteSpace(fileName);
                    });
                }
                NameValueCollection formData = multipartFormDataStreamProvider.FormData;
                if (formData != null)
                {
                    count = formData.Count == 0;
                }
                else
                {
                    count = false;
                }
                if (count)
                {
                    item = null;
                }
                else
                {
                    item = multipartFormDataStreamProvider.FormData[0];
                }
                str3 = item;
                quotedPrintableService = new QuotedPrintableService();
                if (quotedPrintableService.HeaderIsPresent(httpContent))
                {
                    str3 = quotedPrintableService.Decode(str3);
                }
                foreach (MultipartFileData fileDatum in multipartFormDataStreamProvider.FileData)
                {
                    File.Delete(fileDatum.LocalFileName);
                }
                string str4 = str3;
                if (str4 != null)
                {
                    char[] chrArray = new char[] { '\uFEFF', '\u200B' };
                    str1 = str4.Trim(chrArray);
                }
                else
                {
                    str1 = null;
                }
                str = str1;
            }
            else
            {
                str = await request.Content.ReadAsStringAsync();
            }
            stream = null;
            environmentVariable = null;
            multipartFormDataStreamProvider = null;
            httpContent = null;
            str3 = null;
            quotedPrintableService = null;
            return str;
        }
    }
}
