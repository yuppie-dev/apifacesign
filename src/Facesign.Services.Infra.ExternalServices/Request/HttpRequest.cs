
using Facesign.Services.Entities.Facetec;
using Microsoft.AspNetCore.Http;

namespace Facesign.Services.Infra.ExternalServices.Request
{
    public class HttpRequest
    {
        internal static bool key = false;
        internal static HttpResponseMessage value;

        public async Task<HttpResponseMessage> GetToken(string baseref,string url, List<FacetecHeaders> list)
        {            
            try
            {
                using (HttpClient http = GetHttpClient(baseref))
                {
                    setHeader(http, list);                   
                    return await http.GetAsync(url);
                                        
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }            
        }



        public async Task<HttpResponseMessage> Post(string baseref,string url, List<FacetecHeaders> list, StringContent data, string token = null)
        {
            using (var http = GetHttpClient(baseref))
            {
                setHeader(http, list);
                return await http.PostAsync(url, data); 
            }           
        }


        internal void  setHeader(HttpClient client, List<FacetecHeaders> list)
        {
            foreach (var item in list)
            {
                try
                {
                    client.DefaultRequestHeaders.Add(item.key, item.value);
                }
                catch (Exception)
                {
                }               
            }         
        }


        public async Task<HttpResponseMessage> Get(string baseref,string url, StringContent data, string token = null)
        {
            try
            {
                using (var http = GetHttpClient(baseref))
                {
                   // setHeader(http, list);
                    return await http.GetAsync(url); 
                }
            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
            
        }

        public static HttpClient GetHttpClient(string baseref)
        {
            var httpClient = new HttpClient();            
            httpClient.BaseAddress = new Uri(baseref);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }
    }
}
