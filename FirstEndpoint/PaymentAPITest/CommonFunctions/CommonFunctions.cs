using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebserviceAutomation.FirstEndpoint.TestResult;
using System.Collections.Specialized;
using System.Configuration;

namespace WebserviceAutomation.FirstEndpoint.PaymentAPITest.CommonFunctions
{
    public static class CommonFunctions
    {
        public static string GetJSONFromFile_IFNSW(string TCname)
        {
            //var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);


            var FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\" + ConfigurationManager.AppSettings.Get("DataPath_IFNSW") + "\\" + TCname;
            string text = System.IO.File.ReadAllText(FilePath.Replace("file:\\", ""));
            Console.WriteLine("Contents of WriteText.txt = {0}", text);

            ////use this way to separate test data in different folder. directory should be the same in Preqa and QA
            //var FilePath = "D:\\PhuocVo\\TestPaymentAPI\\TestData\\IFNSW\\" + TCname;
            //string text = System.IO.File.ReadAllText(FilePath);

            return text;
        }

        public static string GetJSONFromFile_WINSW(string TCname)
        {
            //var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);


            var FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\" + ConfigurationManager.AppSettings.Get("DataPath_WINSW") + "\\" + TCname;
            string text = System.IO.File.ReadAllText(FilePath.Replace("file:\\", ""));
            Console.WriteLine("Contents of WriteText.txt = {0}", text);

            ////use this way to separate test data in different folder. directory should be the same in Preqa and QA
            //var FilePath = "D:\\PhuocVo\\TestPaymentAPI\\TestData\\IFNSW\\" + TCname;
            //string text = System.IO.File.ReadAllText(FilePath);

            return text;
        }


        public static string SendPostRequestAndGetResponseAsString_IFNSW(WebRequest requestObjPost, string TCname)
        {
            string response = "";
            using (var streanWriter = new StreamWriter(requestObjPost.GetRequestStream()))
            {
                string json = GetJSONFromFile_IFNSW(TCname);
                streanWriter.Write(json);
                streanWriter.Flush();
                streanWriter.Close();

                var httpResponse = (HttpWebResponse)requestObjPost.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                    Console.WriteLine("result: " + response);

                }
            }
            return response;
        }

        public static string SendPostRequestAndGetResponseAsString_WINSW(WebRequest requestObjPost, string TCname)
        {
            string response = "";
            using (var streanWriter = new StreamWriter(requestObjPost.GetRequestStream()))
            {
                string json = GetJSONFromFile_WINSW(TCname);
                streanWriter.Write(json);
                streanWriter.Flush();
                streanWriter.Close();

                var httpResponse = (HttpWebResponse)requestObjPost.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                    Console.WriteLine("result: " + response);

                }
            }
            return response;
        }

        public static string ToSafeFileName(this string s)
        {
            return s
                .Replace("\\", "")
                .Replace("/", "")
                .Replace("\"", "")
                .Replace("*", "")
                .Replace(":", "")
                .Replace("?", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("|", "");
        }




    }
}
