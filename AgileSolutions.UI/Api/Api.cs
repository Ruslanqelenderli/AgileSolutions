using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AgileSolutions.UI.Api
{
    public class Api<T>
    {
        public static async Task<HttpResponseMessage> PostAsync(string url, object model)
        {
            var jsondata = JsonConvert.SerializeObject(model);
            var data = new StringContent(jsondata, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            
            var response = await client.PostAsync(url, data);
            return response;
        }
        public static async Task<HttpResponseMessage> PutAsync(string url, object model)
        {
            var jsondata = JsonConvert.SerializeObject(model);
            var data = new StringContent(jsondata, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            
            var response = await client.PutAsync(url, data);
            return response;
        }
        public static async Task<List<T>> GetAsync(string url)
        {


            using var client = new HttpClient();
            
            var response = await client.GetAsync(url);
            var jsonstring = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<T>>(jsonstring);
            return values;
        }
        public static async Task<HttpResponseMessage> DeleteAsync(string url)
        {


            using var client = new HttpClient();
            
            var response = await client.DeleteAsync(url);
            return response;
        }

    }
}
