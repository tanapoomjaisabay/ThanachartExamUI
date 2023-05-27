using ShoppingCartUI.Services.Interfaces;
using System.Text;

namespace ShoppingCartUI.Services
{
    public class ConnectService : IConnectService
    {
        public string PostAPI(string host, string controller, string json)
        {
            try
            {
                using var client = new HttpClient();

                string url = host + controller;
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync(url, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    return result;
                }
                else
                {
                    throw new HttpRequestException($"Error to send HTTP request. StatusCode={response.StatusCode}. Response Content: {response.Content}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PostAPI failed. " + ex.Message);
            }
        }
    }
}
