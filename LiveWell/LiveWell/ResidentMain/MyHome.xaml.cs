using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWell
{
    public partial class MyHome : ContentPage
    {
        public MyHome()
        {
            InitializeComponent();

            List<Notification> notifications = new List<Notification>()
            {
                new Notification("Chris W. bought groceries and you owe $23.72", "Groceries"),
                new Notification("Campustown fined your room for a noise violation", "Fine"),
                new Notification("Maintenance scheduled for October 2nd at 2:00pm", "Maintenance"),
                new Notification("Chris W. bought groceries and you owe $23.72", "Groceries"),
                new Notification("Campustown fined your room for a noise violation", "Fine"),
                new Notification("Maintenance scheduled for October 2nd at 2:00pm", "Maintenance"),
                new Notification("Chris W. bought groceries and you owe $23.72", "Groceries"),
                new Notification("Campustown fined your room for a noise violation", "Fine"),
                new Notification("Maintenance scheduled for October 2nd at 2:00pm", "Maintenance")
            };
            
            quickview.ItemsSource = notifications;
            quickview.RowHeight = 60;
        }

        async void payment(Object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Submit payment", "Cancel", null, "Bank Account", "Credit Card", "PayPal", "Venmo");
            //Handles payment through bank account
            if (action.Equals("Bank Account"))
            {

            }
            //Handles payment through credit card
            if (action.Equals("Credit Card"))
            {

            }
            //Handles payment through PayPal
            if (action.Equals("PayPal"))
            {

            }
            //Handles payment through Venmo
            if (action.Equals("Venmo"))
            {

            }
        }
    }

    public class Notification
    {
        public Notification(String summary, String details)
        {
            this.Summary = summary;
            this.Details = details;
        }

        public String Summary { get; set; }
        public String Details { get; set; }
    }
}
