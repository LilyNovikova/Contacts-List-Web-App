using System.Net.Http;
using System.Text;

namespace ContactsWebApp.AutoTests.Utils.ApiUtils
{
    public static class ApiClientUtils
    {
        public static string GetContent(this HttpResponseMessage response)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            return response.Content.ReadAsStringAsync().Result;
        }

        public static string GetContentType(this HttpResponseMessage response)
        {
            return response.Content.Headers.ContentType.MediaType;
        }
    }
}
