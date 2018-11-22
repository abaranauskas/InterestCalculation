using InterestCAlculation.Entities;
using System;
using System.Collections.Generic;
//using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InterestCAlculation.Service
{
    public interface IBaseRateRepository
    {
        Task<decimal> GetRate(BaseRateCode baseRateCode);
    }

    public class BaseRateRepository : IBaseRateRepository
    {
        public async Task<decimal> GetRate(BaseRateCode baseRateCode)
        {
            using (var client = new HttpClient())
            {
                var uri = new Uri($"http://old.lb.lt/webservices/VilibidVilibor/VilibidVilibor.asmx/getLatestVilibRate?RateType={baseRateCode}");

                var response = await client.GetAsync(uri);

                string textResult = await response.Content.ReadAsStringAsync();
                var result = textResult.Replace("</decimal>", "");
                int index = result.LastIndexOf('>');
                return decimal.Parse(result.Remove(0, index + 1));
            }

        }
    }
}
