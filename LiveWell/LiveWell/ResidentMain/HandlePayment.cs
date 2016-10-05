using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Auth;

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
            RunAsyncPayment(payDetails).Wait();
        }

        public void payPal()
        {

        }
        public void venmo()
        {

        }

        //Runs payment through service using json input and returns success or not
        async Task RunAsyncPayment(PayDetails payDetails)
        {
            var getToken = new HttpClient(new NativeMessageHandler());
            getToken.BaseAddress = new Uri("https://api.sandbox.paypal.com/v1/oauth2/token");
            getToken.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            getToken.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en_US"));
            getToken.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("AZO0N5GJVZDE0Ubt417QqdeG22iEFFhO-uMjhJcSPKK6qUfoQ2yG5LCzw-JnsZ0waDT3o2iAGlUCzvoh", "EKLht0duhg4jH78ndGHHyAkjb0yt457GguhTLkMQtJoqLJBf4aqdogGW53hRdbuas8TCrqOxpYSPpVEv");
            getToken.DefaultRequestHeaders.TryAddWithoutValidation("content-type", "application/x-www-form-urlencoded");

            OAuthDetails clientCredentials = new OAuthDetails("client_credentials");
            HttpResponseMessage tokenResponse = await getToken.PostAsJsonAsync("/v1/oauth2/token", clientCredentials);
            AccessResponse accessInfo = await tokenResponse.Content.ReadAsAsync<AccessResponse>();

            var postPayment = new HttpClient(new NativeMessageHandler());
            postPayment.BaseAddress = new Uri("https://api.sandbox.paypal.com/v1/payments/payment");
            postPayment.DefaultRequestHeaders.Accept.Clear();
            postPayment.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            postPayment.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessInfo.access_token);

            HttpResponseMessage paymentResponse = await postPayment.PostAsJsonAsync("/v1/payments/payment", payDetails);
        }

        async Task getAuthToken()
        {
            /*
            var http = new HttpClient();
            http.BaseAddress = new Uri("https://api.sandbox.paypal.com/v1/oauth2/token");
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            http.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en_US"));
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("AZO0N5GJVZDE0Ubt417QqdeG22iEFFhO-uMjhJcSPKK6qUfoQ2yG5LCzw-JnsZ0waDT3o2iAGlUCzvoh:EKLht0duhg4jH78ndGHHyAkjb0yt457GguhTLkMQtJoqLJBf4aqdogGW53hRdbuas8TCrqOxpYSPpVEv");

            string json = JsonConvert.SerializeObject(new GrantType("clientcredentials"));

            HttpResponseMessage response = await http.GetAsync(json);
            */
        }
    }
}
