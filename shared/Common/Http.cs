namespace shared.Common
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class Http
    {
        public static async Task<Response> Get<Response>(string url, IDictionary<string, string> dict = null)
        {
            Response returnObject = default;
            if (dict != null)
            {
                url += QueryString(dict);
            }

            using (HttpClient httpClient = new HttpClient())
            {
                using HttpResponseMessage response = await httpClient.GetAsync(url);
                string apiResponse = await response.Content.ReadAsStringAsync();
                returnObject = JsonConvert.DeserializeObject<Response>(apiResponse);
            }

            return returnObject;
        }

        public static async Task<Response> Post<Response>(string url, object body)
        {
            Response returnObject = default;
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromHours(10);

                using HttpResponseMessage response = await httpClient.PostAsJsonAsync(url, body);
                string apiResponse = await response.Content.ReadAsStringAsync();
                returnObject = JsonConvert.DeserializeObject<Response>(apiResponse);
            }

            return returnObject;
        }

        public static string QueryString(IDictionary<string, string> dict)
        {
            List<string> list = new List<string>();
            foreach (KeyValuePair<string, string> item in dict)
            {
                list.Add(item.Key + "=" + item.Value);
            }

            return "?" + string.Join("&", list);
        }
    }
}
