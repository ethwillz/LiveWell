using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
            FundingInstrument[] fu = new FundingInstrument[1];
            fu[0] = new FundingInstrument(new CreditCard("4032032534003485", "visa", "9", "2021", "123", "Ethan", "Williams"));
            PayDetails payDetails = new PayDetails();

            payDetails.intent = "sale";
            payDetails.payer = new Payer("credit_card", fu);
            Transactions[] transactions = new Transactions[1];
            transactions[0] = new Transactions(new Amount("72.34", "USD"), "Payment for rent");
            payDetails.transactions = transactions;

            RunAsyncPayment(payDetails);
        }

        public void payPal()
        {
            /*
            PayDetails payDetails = new PayDetails();
            payDetails.intent = "sale";
            payDetails.payer = new Payer("paypal");
            Transactions[] transactions = new Transactions[1];
            transactions[0] = new Transactions(new Amount("72.34", "USD"), "Payment for rent");
            payDetails.transactions = transactions;

            RunAsyncPayment(payDetails);
            */
        }
        public void venmo()
        {

        }

        //Runs payment through service using json input and returns success or not
        async Task RunAsyncPayment(PayDetails payDetails)
        {
            //Sets up http request to get authorization token
            var getToken = new HttpClient(new NativeMessageHandler());
            getToken.BaseAddress = new Uri("https://api.sandbox.paypal.com/v1/oauth2/token");
            getToken.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            getToken.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en_US"));
            getToken.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "QVpPME41R0pWWkRFMFVidDQxN1FxZGVHMjJpRUZGaE8tdU1qaEpjU1BLSzZxVWZvUTJ5RzVMQ3p3LUpuc1owd2FEVDNvMmlBR2xVQ3p2b2g6RUtMaHQwZHVoZzRqSDc4bmRHSEh5QWtqYjB5dDQ1N0dndWhUTGtNUXRKb3FMSkJmNGFxZG9nR1c1M2hSZGJ1YXM4VENycU94cFlTUHBWRXY=");

            //Runs http request and obtains authorization token
            var tokenContent = new FormUrlEncodedContent(new[]
            {
                 new KeyValuePair<string, string>("grant_type", "client_credentials")
             });
            HttpResponseMessage tokenResponse = await getToken.PostAsync("https://api.sandbox.paypal.com/v1/oauth2/token", tokenContent);
            AccessResponse responseJson = tokenResponse.Content.ReadAsAsync<AccessResponse>().Result;
            var accessToken = responseJson.access_token;

            Debug.WriteLine(accessToken);

            //Sets up http request to post new payment according to payDetails object
            var postPayment = new HttpClient(new NativeMessageHandler());
            postPayment.BaseAddress = new Uri("https://api.sandbox.paypal.com/v1/payments/payment");
            postPayment.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            //Runs http request to post new payment
            string postJson = JsonConvert.SerializeObject(payDetails);
            Debug.WriteLine(postJson);
            var postContent = new StringContent(postJson, Encoding.UTF8, "application/json");
            HttpResponseMessage paymentResponse = await postPayment.PostAsync("https://api.sandbox.paypal.com/v1/payments/payment", postContent);
        }
    }
}
