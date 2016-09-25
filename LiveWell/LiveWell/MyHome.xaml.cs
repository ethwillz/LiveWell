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
