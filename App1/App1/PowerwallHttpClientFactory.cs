using App1.Models;
using System;
using System.Net.Http;


namespace App1
{
    public class PowerwallHttpClientFactory : IHttpClientFactory
    {
        private volatile HttpClient _client;
        private readonly string _lockObj = null;

        public HttpClient Get()
        {
            lock (_lockObj)
            {
                if (_client != null)
                {
                    return _client;
                }

                var handler = new HttpClientHandler();
                handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                handler.ServerCertificateCustomValidationCallback =
                    (httpRequestMessage, cert, cetChain, policyErrors) =>
                    {
                        return true;
                    };

                _client = new HttpClient(handler)
                {
                    Timeout = TimeSpan.FromSeconds(5)
                };

                return _client;
            }
        }

        public void Recycle()
        {
            lock (_lockObj)
            {
                _client.Dispose();
            }
        }
    }
}
