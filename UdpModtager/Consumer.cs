using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HotelLibrary;

namespace UdpModtager
{
    public class Consumer
    {

        protected const string baseURIBit = "http://localhost:48074/api/";
        protected string URI;

        public Consumer(string uniqueURIBit)
        {
            URI = baseURIBit + uniqueURIBit;
            ;
        }
        public List<Temperaturmaaling> GetAll()
        {
            List<Temperaturmaaling> maalinger = new List<Temperaturmaaling>();

            using (HttpClient client = new HttpClient())
            {
                Task<string> resTask = client.GetStringAsync(URI);
                String jsonStr = resTask.Result;

                maalinger = JsonConvert.DeserializeObject<List<Temperaturmaaling>>(jsonStr);
            }
            return maalinger;
        }
        public bool Delete(DateTime date)
        {
            bool ok;


            using (HttpClient client = new HttpClient())
            {
                Task<HttpResponseMessage> deleteAsync = client.DeleteAsync($"{URI}/{date}");

                HttpResponseMessage resp = deleteAsync.Result;

                if (resp.IsSuccessStatusCode)
                {
                    String jsonString = resp.Content.ReadAsStringAsync().Result;
                    ok = JsonConvert.DeserializeObject<bool>(jsonString);
                }
                else
                {
                    ok = false;
                }

            }

            return ok;
        }

        public bool Post(Temperaturmaaling maaling)
        {
            bool ok;


            using (HttpClient client = new HttpClient())
            {
                string jsonString = JsonConvert.SerializeObject(maaling);
                StringContent content = new StringContent(jsonString, Encoding.ASCII, "application/json");


                Task<HttpResponseMessage> postAsync = client.PostAsync(URI, content);

                HttpResponseMessage resp = postAsync.Result;

                if (resp.IsSuccessStatusCode)
                {
                    String jsonResString = resp.Content.ReadAsStringAsync().Result;
                    ok = JsonConvert.DeserializeObject<bool>(jsonResString);
                }
                else
                {
                    ok = false;
                }

            }
            return ok;
        }
    }
}
