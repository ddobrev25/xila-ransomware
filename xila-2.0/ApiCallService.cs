using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace xila_2._0
{
    internal class ApiCallService
    {
        private const string URL = @"http://localhost:5097/";
        private string urlParameters = $"?envUsername={Environment.UserName}";
        public string GetKey()
        {
            const string ENDPOINT_URL = URL + "Key";


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ENDPOINT_URL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;

            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result.ToString();
                string result = string.Empty;

                for (int i = 1; i < responseString.Length - 2; i++)
                {
                    result += responseString[i];
                }

                return result;
            }
            else
            {
                throw new Exception($"{response.StatusCode} \n {response.ReasonPhrase}");
            }
        }
    }
}
