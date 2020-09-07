using App1.Models;
using System.Threading.Tasks;

namespace App1.Models
{
    public interface IRestClient
    {
        Task<FailableResult<T>> Get<T>(string url);
    }
}