using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolidayMaui
{
    internal class APIClient : MainPage
    {
        HttpClient _httpClient;
        CountryCodes codes = new CountryCodes();
        Conversionresult conversionresult = new Conversionresult();



        public APIClient()
        {
            _httpClient = new HttpClient();
        }

       public async Task<double> ConvertPair(string c1, string c2, double v)
       {
            Uri uri = new Uri("https://v6.exchangerate-api.com/v6/13190f03d445d8a2357ad591/pair/" + c1 + "/" + c2 + "/" + v);
            try
            {
                HttpResponseMessage rs = await _httpClient.GetAsync(uri);
                string rsStr = await rs.Content.ReadAsStringAsync();
                conversionresult = JsonConvert.DeserializeObject<Conversionresult>(rsStr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return conversionresult.conversion_result;
        }

        public async Task<CountryCodes> GetCountryCodes()
        {
            Uri uri = new Uri("https://v6.exchangerate-api.com/v6/13190f03d445d8a2357ad591/codes");
            try
            {
                HttpResponseMessage rs = await _httpClient.GetAsync(uri);
                string rsStr = await rs.Content.ReadAsStringAsync();
                codes = JsonConvert.DeserializeObject<CountryCodes>(rsStr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return codes ;
        }
    }
}
