using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using static LiveWell.ConnectHelpers;

namespace LiveWell
{
    public partial class Payment : ContentPage
    {
        DatabaseUPDATE u = new DatabaseUPDATE();

        public Payment()
        {
            InitializeComponent();

            //Runs async operation to populate listview with data from MySQL database
            populateList();
        }

        async void populateList()
        {
            //Instantiates conenction object and calls method which gets notifications given a residentID
            DatabaseGET conn = new DatabaseGET();
            List<balance> balances = await conn.getBalances(1);
            List<ConnectHelpers.NotificationHandler> notifications = await conn.getPayments(1);

            roomBill.Text = (Convert.ToDouble(balances[0].amount1) + Convert.ToDouble(balances[0].amount2) + Convert.ToDouble(balances[0].amount3) + Convert.ToDouble(balances[0].amount4)).ToString();
            buildingBill.Text = balances[0].bAmount;


            //Payment history of the current user
            List<PayRecord> pay = new List<PayRecord>();
            for (int i = 0; i < notifications.Count; i++)
            {
                if (notifications[i].type == "groceries")
                {
                    pay.Add(new PayRecord(notifications[i].firstName + " " + notifications[i].lastName + " bought '" + notifications[i].details + "' and you owe $" + notifications[i].amount + ".", "Groceries"));
                }
                if (notifications[i].type == "fine")
                {
                    pay.Add(new PayRecord("Your room was fined $" + notifications[i].amount + " for '" + notifications[i].details + "'.", "Fine"));
                }
                if (notifications[i].type == "payment" && notifications[i].firstName == null)
                {
                    pay.Add(new PayRecord("You paid " + notifications[i].firstName + " " + notifications[i].lastName + " " + notifications[i].amount + " for '" + notifications[i].details + "'.", "Payment"));
                }
            }

            //Sets listview to the payment list and sets row height
            payHistory.ItemsSource = pay;
            payHistory.RowHeight = 60;
        }

        //Runs async method which handles credit card payment through PayPal
        async void payBuilding(Object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Submit payment", "Cancel", null, "Bank Account", "Credit Card", "PayPal", "Venmo");
            //Handles payment through credit card
            if (action.Equals("Credit Card"))
            {
                new ResidentMain.HandlePayment().creditCard();
                await u.updateBalances(false, true, "1");
            }
        }

        async void payRoom(Object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Submit payment", "Cancel", null, "Credit Card");
            //Handles payment through credit card
            if (action.Equals("Credit Card"))
            {
                new ResidentMain.HandlePayment().creditCard();
                await u.updateBalances(true, false, "1");
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
