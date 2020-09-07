using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace App1.Models
{
    public interface IHttpClientFactory
    {
        HttpClient Get();
        void Recycle();
    }
}
