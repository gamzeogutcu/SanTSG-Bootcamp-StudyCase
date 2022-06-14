using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Web.Services
{
    public class HotelService
    {
        public static T Post<T>(string Url, object Request, string token = null) where T : new()
        {
            try
            {
                string postUrl = Url;
                using (var client = new HttpClient())
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    if (token != null)
                    {
                        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    }
                    string json = JsonConvert.SerializeObject(Request, Formatting.Indented);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage result = client.PostAsync(postUrl, stringContent).Result;


                    string res = result.Content.ReadAsStringAsync().Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<T>(res);
                    }
                    return default(T);

                }
            }

            catch (Exception)
            {
                return default(T);
            }
        }
    }

}