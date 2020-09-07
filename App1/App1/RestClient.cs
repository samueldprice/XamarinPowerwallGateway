using App1.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace App1
{
    public class RestClient : IRestClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private static readonly int RETRY_MAX = 1;

        public RestClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<FailableResult<T>> Get<T>(string url)
        {
            var retry = 0;
            while(retry < RETRY_MAX)
            {
                try
                {
                    var client = _httpClientFactory.Get();
                    var response = await client.GetAsync(url);
                    var resultStr = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<T>(resultStr);

                    return new FailableResult<T> { Result = result };
                }
                catch (Exception e)
                {
                    if (retry >= RETRY_MAX)
                    {
                        return new FailableResult<T> { Error = e.Message + e.StackTrace.ToString() };
                    }
                }

                _httpClientFactory.Recycle();
                retry += 1;
            }

            throw new InvalidProgramException();
        }
    }
}
