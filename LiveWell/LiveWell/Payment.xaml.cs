using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace LiveWell
{
    public partial class Payment : ContentPage
    {
        public Payment()
        {
            InitializeComponent();

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

            payHistory.ItemsSource = payments;
            payHistory.RowHeight = 60;
        }

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
    }
}
