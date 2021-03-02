using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebserviceAutomation.FirstEndpoint.TestResult;

namespace WebserviceAutomation.FirstEndpoint.PaymentAPITest.TestExecution.IFNSW
{
    [TestFixture]
    public class IFNSWTestCase : BaseTest
    {
         

        [Test]
        public void TC19()
        {
            string TCname = "TC19.txt";
            string httpResponse = CommonFunctions.CommonFunctions.SendPostRequestAndGetResponseAsString_IFNSW(requestObjPost, TCname);

            Response response = JsonConvert.DeserializeObject<Response>(httpResponse);

            Console.WriteLine("Is Success: {0}", response.Success);
            Console.WriteLine("PaymentID: {0}", response.PaymentId);
            Console.WriteLine("param 3 length: {0}", response.Exceptions.Count);
            //for (int i = 0; i < response.Exceptions.Count; i++)
            //{
            //    Console.WriteLine("value at " + i + " " + response.Exceptions.ElementAt(i).ToString()  ); 
            //}

            PaymentException expectException = new PaymentException();
            expectException.ErrorNo = 50740;
            expectException.FieldName = null;
            //expectException.Message = "LINE 1 - Service Amount exceeds Calculated Amount by 139.23%. Maximum variation is 0.02%";
            expectException.Message = "LINE 1 - Service Amount exceeds Calculated Amount by";
            
            
            bool reponseContainsException = response.Exceptions.Any(e => e.ErrorNo == expectException.ErrorNo
                                                                       && e.FieldName == expectException.FieldName
                                                                       && e.Message.Contains(expectException.Message));


            Assert.IsTrue(response.Success == false && response.PaymentId == null && reponseContainsException);
        }

        [Test]
        public void TC20()
        {
            string TCname = "TC20.txt";
            string httpResponse = CommonFunctions.CommonFunctions.SendPostRequestAndGetResponseAsString_IFNSW(requestObjPost, TCname);

            Response response = JsonConvert.DeserializeObject<Response>(httpResponse);
            Console.WriteLine("Is Success: {0}", response.Success);
            Console.WriteLine("PaymentID: {0}", response.PaymentId);
            //Console.WriteLine("param 3: {0}", response.Exceptions);

            PaymentException expectException = new PaymentException();
            expectException.ErrorNo = 50002;
            expectException.FieldName = null;
            expectException.Message = "LINE 1 - Duplicate Payment found.";

            bool reponseContainsException = response.Exceptions.Any(e => e.ErrorNo == expectException.ErrorNo
                                                                       && e.FieldName == expectException.FieldName
                                                                       && e.Message.Contains(expectException.Message));
            if (response.Exceptions.Count == 0)
            {
                Assert.IsTrue(response.Success == true && response.PaymentId != null && response.Exceptions.Count == 0);
            }
            else
            {
                Assert.IsTrue(response.Success == true && response.PaymentId != null && reponseContainsException);
            }
            
        }

        [Test]
        public void TC21()
        {
            string TCname = "TC21.txt";
            string httpResponse = CommonFunctions.CommonFunctions.SendPostRequestAndGetResponseAsString_IFNSW(requestObjPost, TCname);

            Response response = JsonConvert.DeserializeObject<Response>(httpResponse);
            Console.WriteLine("Is Success: {0}", response.Success);
            Console.WriteLine("PaymentID: {0}", response.PaymentId);

            PaymentException expectException = new PaymentException();
            expectException.ErrorNo = 50737;
            expectException.FieldName = null;
            //expectException.Message = "Claim is \\\"Read Only\\\". No changes allowed.";
            expectException.Message = @"Claim is ""Read Only"". No changes allowed.";
            //expectException.Message = "CLAIM IS READ ONLY.";
            bool reponseContainsException = response.Exceptions.Any(e => e.ErrorNo == expectException.ErrorNo
                                                                       && e.FieldName == expectException.FieldName
                                                                       && e.Message == expectException.Message);

            Assert.IsTrue(response.Success == false && response.PaymentId == null && reponseContainsException);
            Console.WriteLine("test");
        }

        [Test]
        public void TC22()
        {
            string TCname = "TC22.txt";
            string httpResponse = CommonFunctions.CommonFunctions.SendPostRequestAndGetResponseAsString_IFNSW(requestObjPost, TCname);

            Response response = JsonConvert.DeserializeObject<Response>(httpResponse);
            Console.WriteLine("Is Success: {0}", response.Success);
            Console.WriteLine("PaymentID: {0}", response.PaymentId);


            PaymentException expectException = new PaymentException();
            expectException.ErrorNo = 50001;
            expectException.FieldName = null;
            expectException.Message = "User is not authorised to open a Restricted claim.";

            bool reponseContainsException = response.Exceptions.Any(e => e.ErrorNo == expectException.ErrorNo
                                                                       && e.FieldName == expectException.FieldName
                                                                       && e.Message == expectException.Message);

            Assert.IsTrue(response.Success == false && response.PaymentId == null && reponseContainsException);
        }

        [Test]
        public void TC23()
        {
            string TCname = "TC23.txt";
            string httpResponse = CommonFunctions.CommonFunctions.SendPostRequestAndGetResponseAsString_IFNSW(requestObjPost, TCname);

            Response response = JsonConvert.DeserializeObject<Response>(httpResponse);
            Console.WriteLine("Is Success: {0}", response.Success);
            Console.WriteLine("PaymentID: {0}", response.PaymentId);


            PaymentException expectException = new PaymentException();
            expectException.ErrorNo = 50912;
            expectException.FieldName = null;
            expectException.Message = "LINE 1 - Payments of estimate types 50-60 & 64-77 are not allowed if Date of Service or Period End Date of payment is after the date when Claims Liability Status was set to 07 denied.";

            bool reponseContainsException = response.Exceptions.Any(e => e.ErrorNo == expectException.ErrorNo
                                                                       && e.FieldName == expectException.FieldName
                                                                       && e.Message == expectException.Message);

            Assert.IsTrue(response.Success == false && response.PaymentId == null && reponseContainsException);
        }



        [Test]
        public void TC28()
        {
            string TCname = "TC28.txt";
            string httpResponse = CommonFunctions.CommonFunctions.SendPostRequestAndGetResponseAsString_IFNSW(requestObjPost, TCname);

            Response response = JsonConvert.DeserializeObject<Response>(httpResponse);
            Console.WriteLine("Is Success: {0}", response.Success);
            Console.WriteLine("PaymentID: {0}", response.PaymentId);


            PaymentException expectException = new PaymentException();
            expectException.ErrorNo = 51369;
            expectException.FieldName = null;
            expectException.Message = "LINE 1 - Medical Benefit Cease Date cannot be before the latest treatment date";

            bool reponseContainsException = response.Exceptions.Any(e => e.ErrorNo == expectException.ErrorNo
                                                                       && e.FieldName == expectException.FieldName
                                                                       && e.Message == expectException.Message);

            Assert.IsTrue(response.Success == false && response.PaymentId == null && reponseContainsException);
        }



        [Test]
        public void TC35()
        {
            string TCname = "TC35.txt";
            string httpResponse = CommonFunctions.CommonFunctions.SendPostRequestAndGetResponseAsString_IFNSW(requestObjPost, TCname);

            Response response = JsonConvert.DeserializeObject<Response>(httpResponse);
            Console.WriteLine("Is Success: {0}", response.Success);
            Console.WriteLine("PaymentID: {0}", response.PaymentId);


            PaymentException expectException = new PaymentException();
            expectException.ErrorNo = 50042;
            expectException.FieldName = null;
            expectException.Message = "LINE 1 - Invalid Payment Type..";

            bool reponseContainsException = response.Exceptions.Any(e => e.ErrorNo == expectException.ErrorNo
                                                                       && e.FieldName == expectException.FieldName
                                                                       && e.Message == expectException.Message);

            Assert.IsTrue(response.Success == false && response.PaymentId == null && reponseContainsException);
        }

        [Test]
        public void TC38()
        {
            string TCname = "TC38.txt";
            string httpResponse = CommonFunctions.CommonFunctions.SendPostRequestAndGetResponseAsString_IFNSW(requestObjPost, TCname);

            Response response = JsonConvert.DeserializeObject<Response>(httpResponse);
            Console.WriteLine("Is Success: {0}", response.Success);
            Console.WriteLine("PaymentID: {0}", response.PaymentId);


            PaymentException expectException = new PaymentException();
            expectException.ErrorNo = 7285;
            expectException.FieldName = null;
            expectException.Message = "Liability Status Code (C: 2.2.9) must not be equal to 01 or 12 when Claim payments to date (C: 2.9.4) is greater than zero";

            bool reponseContainsException = response.Exceptions.Any(e => e.ErrorNo == expectException.ErrorNo
                                                                       && e.FieldName == expectException.FieldName
                                                                       && e.Message == expectException.Message);

            Assert.IsTrue(response.Success == false && response.PaymentId == null && reponseContainsException);
        }

        [Test]
        public void TC39()
        {
            string TCname = "TC39.txt";
            string httpResponse = CommonFunctions.CommonFunctions.SendPostRequestAndGetResponseAsString_IFNSW(requestObjPost, TCname);

            Response response = JsonConvert.DeserializeObject<Response>(httpResponse);
            Console.WriteLine("Is Success: {0}", response.Success);
            Console.WriteLine("PaymentID: {0}", response.PaymentId);


            PaymentException expectException = new PaymentException();
            expectException.ErrorNo = 50223;
            expectException.FieldName = null;
            expectException.Message = "LINE 1 - Cannot make a payment for the selected pay type";

            bool reponseContainsException = response.Exceptions.Any(e => e.ErrorNo == expectException.ErrorNo
                                                                       && e.FieldName == expectException.FieldName
                                                                       && e.Message == expectException.Message);

            Assert.IsTrue(response.Success == false && response.PaymentId == null && reponseContainsException);
        }


        [Test]
        public void TC40()
        {
            string TCname = "TC40.txt";
            string httpResponse = CommonFunctions.CommonFunctions.SendPostRequestAndGetResponseAsString_IFNSW(requestObjPost, TCname);

            Response response = JsonConvert.DeserializeObject<Response>(httpResponse);
            Console.WriteLine("Is Success: {0}", response.Success);
            Console.WriteLine("PaymentID: {0}", response.PaymentId);


            PaymentException expectException = new PaymentException();
            expectException.ErrorNo = 50832;
            expectException.FieldName = null;
            expectException.Message = "LINE 1 - Lumpsum payments cannot be made to a Creditor";

            bool reponseContainsException = response.Exceptions.Any(e => e.ErrorNo == expectException.ErrorNo
                                                                       && e.FieldName == expectException.FieldName
                                                                       && e.Message == expectException.Message);

            Assert.IsTrue(response.Success == false && response.PaymentId == null && reponseContainsException);
        }

        [Test]
        public void TC41()
        {
            string TCname = "TC41.txt";
            string httpResponse = CommonFunctions.CommonFunctions.SendPostRequestAndGetResponseAsString_IFNSW(requestObjPost, TCname);

            Response response = JsonConvert.DeserializeObject<Response>(httpResponse);
            Console.WriteLine("Is Success: {0}", response.Success);
            Console.WriteLine("PaymentID: {0}", response.PaymentId);


            PaymentException expectException = new PaymentException();
            expectException.ErrorNo = 51368;
            expectException.FieldName = null;
            expectException.Message = "Sum of WPI001 must not exceed";

            bool reponseContainsException = response.Exceptions.Any(e => e.ErrorNo == expectException.ErrorNo
                                                                       && e.FieldName == expectException.FieldName
                                                                       && e.Message.Contains(expectException.Message));

            Assert.IsTrue(response.Success == false && response.PaymentId == null && reponseContainsException);
        }

        [Test]
        public void TC42()
        {
            string TCname = "TC42.txt";
            string httpResponse = CommonFunctions.CommonFunctions.SendPostRequestAndGetResponseAsString_IFNSW(requestObjPost, TCname);

            Response response = JsonConvert.DeserializeObject<Response>(httpResponse);
            Console.WriteLine("Is Success: {0}", response.Success);
            Console.WriteLine("PaymentID: {0}", response.PaymentId);


            PaymentException expectException = new PaymentException();
            expectException.ErrorNo = 50026;
            expectException.FieldName = null;
            expectException.Message = "Treatment Date or Service Date must be later than or equal to Date of Injury";

            bool reponseContainsException = response.Exceptions.Any(e => e.ErrorNo == expectException.ErrorNo
                                                                       && e.FieldName == expectException.FieldName
                                                                       && e.Message.Contains(expectException.Message));

            Assert.IsTrue(response.Success == false && response.PaymentId == null && reponseContainsException);
        }




        [Test]
        public void TC43()
        {
            string TCname = "TC43.txt";
            string httpResponse = CommonFunctions.CommonFunctions.SendPostRequestAndGetResponseAsString_IFNSW(requestObjPost, TCname);

            Response response = JsonConvert.DeserializeObject<Response>(httpResponse);
            Console.WriteLine("Is Success: {0}", response.Success);
            Console.WriteLine("PaymentID: {0}", response.PaymentId);


            PaymentException expectException = new PaymentException();
            expectException.ErrorNo = 7248;
            expectException.FieldName = null;
            expectException.Message = "Payment made for Payment classification number Work Trial (range VWT001 - VWT002) but there is no Service provision type equal to '02' Vocational rehabilitation program and no Service provision sub type equal to '01' Work Trial";

            bool reponseContainsException = response.Exceptions.Any(e => e.ErrorNo == expectException.ErrorNo
                                                                       && e.FieldName == expectException.FieldName
                                                                       && e.Message == expectException.Message);

            Assert.IsTrue(response.Success == false && response.PaymentId == null && reponseContainsException);
        }



        [Test]
        public void TC44()
        {
            string TCname = "TC44.txt";
            string httpResponse = CommonFunctions.CommonFunctions.SendPostRequestAndGetResponseAsString_IFNSW(requestObjPost, TCname);

            Response response = JsonConvert.DeserializeObject<Response>(httpResponse);
            Console.WriteLine("Is Success: {0}", response.Success);
            Console.WriteLine("PaymentID: {0}", response.PaymentId);


            PaymentException expectException = new PaymentException();
            expectException.ErrorNo = 4099;
            expectException.FieldName = null;
            expectException.Message = "The sum of a Payment/Recovery amount (C:2.5.7) must not be negative, for the cumulative total of the linked pre agent Payment Type & the new agent Payment Classification Number (C:2.5.17)";

            bool reponseContainsException = response.Exceptions.Any(e => e.ErrorNo == expectException.ErrorNo
                                                                       && e.FieldName == expectException.FieldName
                                                                       && e.Message == expectException.Message);

            Assert.IsTrue(response.Success == false && response.PaymentId == null && reponseContainsException);
        }































    }
}
