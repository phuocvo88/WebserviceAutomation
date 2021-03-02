using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebserviceAutomation.FirstEndpoint
{
    class TestAPI2
    {
        public void TestPostRequest() 
        {
            string strUrl = String.Format("https://emicspaymentapi.mnlaswig.int/payment/create");
            WebRequest requestObjPost = WebRequest.Create(strUrl);
            requestObjPost.Method = "POST";
            requestObjPost.ContentType = "application/json";

            string username = "1";
            string password = "397adb8a-1ca5-4de6-8a56-6f95e7bf1db6";
            string encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
            //httpWebRequest.Headers.Add("Authorization", "Basic " + encoded);
            requestObjPost.Headers.Add("Authorization", "Basic " + encoded);
            //requestObjPost.Credentials = new NetworkCredential("1", "397adb8a-1ca5-4de6-8a56-6f95e7bf1db6");

            using (var streanWriter = new StreamWriter(requestObjPost.GetRequestStream()))
            {
                string json = GetJSONFromFile();
                streanWriter.Write(json);
                streanWriter.Flush();
                streanWriter.Close();

                var httpResponse = (HttpWebResponse)requestObjPost.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result2 = streamReader.ReadToEnd();
                    Console.WriteLine("result: " + result2);

                
                }


            }


        }


        public string GetJSONFromFile()
        {
            var FilePath = "C:\\Users\\P.Minh\\source\\repos\\webserviceautomationTest\\WebserviceAutomation\\FirstEndpoint\\TestData\\IFNSW\\TC34.txt";
            string text = System.IO.File.ReadAllText(FilePath);
            Console.WriteLine("Contents of WriteText.txt = {0}", text);
            return text;
        }
    }
}
