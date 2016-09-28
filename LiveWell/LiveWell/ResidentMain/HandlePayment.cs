using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LiveWell.ResidentMain
{
    class HandlePayment
    {
        public void bankAccount()
        {

        }

        //Creates json object with all credit card information which is then sent to the HTTP server
        public void creditCard()
        {
            PayDetails payDetails = new PayDetails();
            payDetails.intent = "sale";
            payDetails.payer = new Payer("credit_card", new CreditCard("4032032534003485", "visa", "09", "2021", "123", "Ethan", "Williams"));
            payDetails.transactions = new Transactions(new Amount("72.34", "USD"), "Payment for rent");

            string json = JsonConvert.SerializeObject(payDetails);
        }

        public void payPal()
        {

        }
        public void venmo()
        {

        }

        //Runs payment through service using json input and returns success or not
        async Task RunAsyncPayment(String json)
        {
            /*
            var http = new HttpClient();
            http.BaseAddress = new Uri("https://api.sandbox.paypal.com/v1/payments/payment");
            http.DefaultRequestHeaders.Accept.Clear();
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Authorization: Bearer {after this will be access token}"));
            */
        }
    }
}
