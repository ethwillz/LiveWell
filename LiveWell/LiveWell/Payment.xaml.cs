using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace LiveWell
{
    public partial class Payment : ContentPage
    {
        public Payment()
        {
            InitializeComponent();

            //Example list of payments which will come from the database in the future
            List<PayRecord> payments = new List<PayRecord>()
            {
                new PayRecord("You owe Chris W. $19.32", "Groceries"),
                new PayRecord("Campustown charged you $50", "Fine"),
                new PayRecord("You paid $30.56 to Micah B. and $35.87 to Chase W.", "Paid"),
                new PayRecord("Chase W. bought list you owe $13.54", "Groceries"),
                new PayRecord("You owe Chris W. $19.32", "Groceries"),
                new PayRecord("Campustown charged you $50", "Fine"),
                new PayRecord("You paid $30.56 to Micah B. and $35.87 to Chase W.", "Paid"),
                new PayRecord("Chase W. bought list you owe $13.54", "Groceries"),
                new PayRecord("You owe Chris W. $19.32", "Groceries"),
                new PayRecord("Campustown charged you $50", "Fine"),
                new PayRecord("You paid $30.56 to Micah B. and $35.87 to Chase W.", "Paid"),
                new PayRecord("Chase W. bought list you owe $13.54", "Groceries")
            };

            //Sets listview to the payment list and sets row height
            payHistory.ItemsSource = payments;
            payHistory.RowHeight = 60;
        }

        //Runs async method which handles credit card payment through PayPal
        public void payBuilding(Object sender, EventArgs e)
        {
            RunAsyncPayment().Wait();
        }

        //Has user approve PayPal charge to their credit card and sends it to account of building
        async Task RunAsyncPayment()
        {
            /*
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.sandbox.paypal.com/v1/payments/payment");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var paymentInfo = new Pay() { number = };
                HttpResponseMessage response = await client.PostAsJsonAsync("v1/payments/payment", paymentInfo);
                if (response.IsSuccessStatusCode)
                {

                }
            }
            */
        }

        //Object which stores information about payment history
        public class PayRecord
        {
            public PayRecord(String summary, String details)
            {
                this.Summary = summary;
                this.Details = details;
            }

            public String Summary { get; set; }
            public String Details { get; set; }
        }

        public class Pay
        {
            public String number { get; set; }
            public String type { get; set; }
            public String expire_month { get; set; }
            public String expire_year { get; set; }
            public String cvv2 { get; set; }
            public String first_name { get; set; }
            public String last_name { get; set; }
            public String total { get; set; }
            public String currency { get; set; }
        }
    }
}
