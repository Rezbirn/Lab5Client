using Lab5Client.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Nodes;

namespace Lab5Client.API
{
    public class AddressAPI
    {
        public bool HasToken { get => !string.IsNullOrEmpty(_token); }
        private string _token;
        private string _address = "http://localhost:5028/api/address";
        public AddressAPI(string token) : this()
        {
            _token = token;
            
        }
        public AddressAPI() 
        {

        }
        public void SetToken(string token)
        {
            _token = token;
        }
        public async Task<Address> Get(int id)
        {
            using(var httpClient = new HttpClient()) 
            {
                var result = await httpClient.GetAsync(_address + $"?id={id}");
                if (result.IsSuccessStatusCode)
                {
                    var jsonResult = await result.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Address>(jsonResult);
                }
                throw new HttpRequestException(result.StatusCode.ToString());
            }
        }

        public async Task<List<Address>> Get()
        {
            using(var httpClient = new HttpClient()) 
            {
                var result = await httpClient.GetAsync(_address + "/all");
                if (result.IsSuccessStatusCode)
                {
                    var jsonResult = await result.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Address>>(jsonResult);
                }
                throw new HttpRequestException(result.StatusCode.ToString());
            }
        }

        public async Task<HttpStatusCode> Post(Address address)
        {
            using(var httpClient = new HttpClient())
            {
                SetToken(httpClient);
                var httpContent = new StringContent(JsonConvert.SerializeObject(address), Encoding.UTF8, "application/json");
                var result = await httpClient.PostAsync(_address, httpContent);
                return result.StatusCode;
            }
        }

        public async Task<HttpStatusCode> Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                SetToken(httpClient);
                var result = await httpClient.DeleteAsync(_address + $"?id={id}");
                return result.StatusCode;
            }
        }
        private void SetToken(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _token);
        }
    }
}
