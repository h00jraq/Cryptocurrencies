using System;
using Cryptocurrencies.ROI.Calculator.API;
using Newtonsoft.Json;

namespace ExchangeRate_API
{

    class Rates
    {
        public static bool Import()
        {
            try
            {
                String URLString = "https://v6.exchangerate-api.com/v6/21befb41ac31b6bda340a9b8/latest/USD";
                using (var webClient = new System.Net.WebClient())
                {
                    var json = webClient.DownloadString(URLString);
                    API_Obj Test = (API_Obj)JsonConvert.DeserializeObject(json);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    

    

}