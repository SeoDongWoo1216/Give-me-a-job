using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NaverMapAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            string clientID = "F_ewIqiLjJb8Bff4IBUx";
            string clientSecret = "Np0vEDDYql";
            string search = "부산";
            string openApiUrl = $"https://openapi.naver.com/v1/search/local?query={search}";

            string responseJson = GetOpenApiResult(openApiUrl, clientID, clientSecret);
            JObject parsedJson = JObject.Parse(responseJson);

        }

        private static string GetOpenApiResult(string openApiUrl, string clientID, string clientSecret)
        {
            var result = "";

            try
            {
                WebRequest request = WebRequest.Create(openApiUrl);
                request.Headers.Add("X-Naver-Client-Id", clientID);
                request.Headers.Add("X-Naver-Client-Secret", clientSecret);

                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);

                result = reader.ReadToEnd();

                reader.Close();
                stream.Close();
                response.Close();

            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
    }
}
