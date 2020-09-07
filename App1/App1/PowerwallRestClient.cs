using App1.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace App1
{
    public class PowerwallRestClient
    {
        private readonly IRestClient _restClient;
        private readonly IPowerwallMapper _powerwallMapper;

        public PowerwallRestClient(
            IRestClient restClient, 
            IPowerwallMapper powerwallMapper
            )
        {
            _restClient = restClient;
            _powerwallMapper = powerwallMapper;
        }

        public async Task<FailableResult<PowerwallStatus>> Get()
        {
            var aggregates = await _restClient.Get<Aggregates>("https://192.168.91.1/api/meters/aggregates");
            var soe = await _restClient.Get<Soe>("https://192.168.91.1/api/system_status/soe");
            var mapped = _powerwallMapper.Map(aggregates.Result, soe.Result);
            return new FailableResult<PowerwallStatus>
            {
                Result = mapped,
                Error = $"{aggregates.Error}\n{soe.Error}"
            };
        }
    }
}
