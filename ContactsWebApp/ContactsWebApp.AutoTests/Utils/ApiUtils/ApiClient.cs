using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ContactsWebApp.AutoTests.Utils.ApiUtils
{
    public class ApiClient
    {
        private static ApiClient apiClient;
        private static HttpClient client;

        private ApiClient()
        {
            client = new HttpClient();
        }

        public static ApiClient Instance
        {
            get
            {

                if (apiClient == null)
                {
                    apiClient = new ApiClient();
                }
                return apiClient;
            }
        }

        public HttpResponseMessage Get(string url, string contentType = ApiContentTypes.JsonContent)
        {
            AddContentType(contentType);
            return GetAsync(url).Result;
        }

        public HttpResponseMessage Put(string url, string textToPut, string contentType = ApiContentTypes.JsonContent)
        {
            AddContentType(contentType);
            var content = new StringContent(textToPut, Encoding.UTF8, client.DefaultRequestHeaders.Accept.ToString());
            return client.PutAsync(url, content).Result;
        }

        public HttpResponseMessage Delete(string url, string contentType = ApiContentTypes.JsonContent)
        {
            AddContentType(contentType);
            return client.DeleteAsync(url).Result;
        }

        public HttpResponseMessage Post(string url, string textToPost, string contentType = ApiContentTypes.JsonContent)
        {
            AddContentType(contentType);
            return PostAsync(url, textToPost).Result;
        }

        public void CloseConnection()
        {
            client.Dispose();
            apiClient = null;
        }

        public HttpResponseMessage PostAttachment(string url, byte[] array, string contentFilename = "screenshot.jpg", string contentName = "attachment", string contentType = ApiContentTypes.MultipartFormDataContent)
        {
            AddContentType(contentType);
            return PostAttachmentAsync(url, array).Result;
        }

        public HttpResponseMessage PostWithParams(string url, FormUrlEncodedContent content, string contentType = ApiContentTypes.JsonContent)
        {
            AddContentType(contentType);
            return PostWithParamsAsync(url, content).Result;
        }

        private async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await client.GetAsync(url);
        }

        private async Task<HttpResponseMessage> PostAsync(string url, string textToPost)
        {
            var content = new StringContent(textToPost, Encoding.UTF8, client.DefaultRequestHeaders.Accept.ToString());
            return await client.PostAsync(url, content);
        }

        private void AddContentType(string contentType)
        {
            client.DefaultRequestHeaders.Add("Accept", contentType);
        }

        private async Task<HttpResponseMessage> PostAttachmentAsync(string url, byte[] array, string contentFilename = "screenshot.jpg", string contentName = "attachment")
        {
            var content = new MultipartFormDataContent();
            var image = new ByteArrayContent(array);
            content.Add(image, contentName, contentFilename);
            return await client.PostAsync(url, content);
        }

        private async Task<HttpResponseMessage> PostWithParamsAsync(string url, FormUrlEncodedContent content)
        {
            return await client.PostAsync(url, content);
        }

    }
}
