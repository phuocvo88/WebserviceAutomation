using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebserviceAutomation.FirstEndpoint.PaymentAPITest.TestExecution
{
    public class BaseTest
    {
       public  WebRequest requestObjPost;
       [SetUp]
        public  void SetUp()
        {
            //string strUrl = String.Format("https://emicspaymentapi.mnlaswig.int/payment/create");
            string strUrl = ConfigurationManager.AppSettings.Get("TestUri");
            requestObjPost = WebRequest.Create(strUrl);
            requestObjPost.Method = "POST";
            requestObjPost.ContentType = "application/json";

            string username = "1";
            string password = "397adb8a-1ca5-4de6-8a56-6f95e7bf1db6";
            string encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
           
            requestObjPost.Headers.Add("Authorization", "Basic " + encoded);
            //requestObjPost.Credentials = new NetworkCredential("1", "397adb8a-1ca5-4de6-8a56-6f95e7bf1db6");
        }
       
        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("test done");
        }
    }
}
