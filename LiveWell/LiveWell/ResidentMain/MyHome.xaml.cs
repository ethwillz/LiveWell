using ModernHttpClient;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;
using static LiveWell.ConnectHelpers;

namespace LiveWell
{
    public partial class MyHome : ContentPage
    {
        public MyHome()
        {
            InitializeComponent();

            logo.Source = ImageSource.FromResource("LiveWell.LiveWellFullLogo.png");

            //populateList();
        }

        async void populateList()
        {
            DatabaseConnect conn = new DatabaseConnect();
            List<Notification> notifications = await conn.getNotifications(1);

            List<QuickViewNotif> notifs = new List<QuickViewNotif>();
            for(int i = 0; i < notifications.Count; i++)
            {
                if(notifications[i].type == "groceries")
                {
                    notifs.Add(new QuickViewNotif(notifications[i].sender + " bought '" + notifications[i].details + "' and you owe " + notifications[i].amount, "Groceries"));
                }
                if(notifications[i].type == "fine")
                {
                    notifs.Add(new QuickViewNotif("Your room was fined " + notifications[i].amount + " for '" + notifications[i].details + "'", "Fine"));
                }
            }

            quickview.ItemsSource = notifs;
            quickview.RowHeight = 60;
        }

        async void payment(Object sender, EventArgs e)
        {
            populateList();
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
    }

    public class QuickViewNotif
    {
        public QuickViewNotif(String summary, String details)
        {
            this.Summary = summary;
            this.Details = details;
        }

        public String Summary { get; set; }
        public String Details { get; set; }
    }
}
