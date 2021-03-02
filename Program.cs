using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebserviceAutomation.FirstEndpoint;

namespace WebserviceAutomation
{
    class Program
    {
        static void Main(string[] args)
        {
            //step 1 to create http client
            //HttpClient httpclient = new HttpClient();

            //httpclient.Dispose();//close connection and release resource

            TestAPI2 test = new TestAPI2();
            //test.getJSONFromFile();
            //Console.ReadKey();


            test.TestPostRequest();
            Console.ReadKey();
        }
    }
}
