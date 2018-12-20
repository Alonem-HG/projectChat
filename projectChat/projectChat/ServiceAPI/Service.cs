using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace projectChat.ServiceAPI
{
    public class Service
    {
        public async Task<string> Get(String url)
        {
            HttpClient client = new HttpClient();
            var result = await client.GetAsync(url);
            String json = await result.Content.ReadAsStringAsync();
            return json;
        }
    }
}
