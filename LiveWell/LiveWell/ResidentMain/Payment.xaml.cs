using System;
using System.Collections.Generic;

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
        async void payBuilding(Object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Submit payment", "Cancel", null, "Bank Account", "Credit Card", "PayPal", "Venmo");
            //Handles payment through bank account
            if (action.Equals("Bank Account"))
            {
                new ResidentMain.HandlePayment().bankAccount();
            }
            //Handles payment through credit card
            if (action.Equals("Credit Card"))
            {
                new ResidentMain.HandlePayment().creditCard();
            }
            //Handles payment through PayPal
            if (action.Equals("PayPal"))
            {
                new ResidentMain.HandlePayment().payPal();
            }
            //Handles payment through Venmo
            if (action.Equals("Venmo"))
            {
                new ResidentMain.HandlePayment().venmo();
            }
        }

        async void payRoom(Object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Submit payment", "Cancel", null, "Bank Account", "Credit Card", "PayPal", "Venmo");
            //Handles payment through bank account
            if (action.Equals("Bank Account"))
            {
                new ResidentMain.HandlePayment().bankAccount();
            }
            //Handles payment through credit card
            if (action.Equals("Credit Card"))
            {
                new ResidentMain.HandlePayment().creditCard();
            }
            //Handles payment through PayPal
            if (action.Equals("PayPal"))
            {
                new ResidentMain.HandlePayment().payPal();
            }
            //Handles payment through Venmo
            if (action.Equals("Venmo"))
            {
                new ResidentMain.HandlePayment().venmo();
            }
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
    }
}
