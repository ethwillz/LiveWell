using System;
using System.Collections.Generic;
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

            //Runs async operation to populate listview with data from MySQL database
            populatePage();
        }

        async void populatePage()
        {
            //Instantiates conenction object and calls method which gets notifications given a residentID
            DatabaseGET conn = new DatabaseGET();
            List<Notification> notifications = await conn.getNotifications(1);
            List<ResidentInfo> resident = await (conn.getResidentInfo(1));

            //Sets text for room information at top of screen
            address.Text = resident[0].address;
            room.Text = resident[0].number;
            String roommates = "";
            for(int i = 0; i < resident.Count; i++)
            {
                if (i == resident.Count - 2)
                    roommates += resident[i].firstName + " " + resident[i].lastName + ", & ";
                else if (i == resident.Count - 1)
                    roommates += resident[i].firstName + " " + resident[i].lastName;
                else
                    roommates += resident[i].firstName + " " + resident[i].lastName + ", ";
            }
            residents.Text = roommates;

            //Creates list of notifications for use in UI
            List<QuickViewNotif> notifs = new List<QuickViewNotif>();
            for(int i = 0; i < notifications.Count; i++)
            {
                if(notifications[i].type == "groceries")
                {
                    notifs.Add(new QuickViewNotif(notifications[i].firstName + " " + notifications[i].lastName + " bought '" + notifications[i].details + "' and you owe $" + notifications[i].amount + ".", "Groceries"));
                }
                if(notifications[i].type == "fine")
                {
                    notifs.Add(new QuickViewNotif("Your room was fined $" + notifications[i].amount + " for '" + notifications[i].details + "'.", "Fine"));
                }
            }

            //Sets the source of the listview and the row height
            quickview.ItemsSource = notifs;
            quickview.RowHeight = 60;
            quickview.IsEnabled = false;
        }

        async void payment(Object sender, EventArgs e)
        {
            DatabaseUPDATE u = new DatabaseUPDATE();
            var action = await DisplayActionSheet("Submit payment", "Cancel", null, "Credit Card");
            //Handles payment through credit card
            if (action.Equals("Credit Card"))
            {
                new ResidentMain.HandlePayment().creditCard();
                await u.updateBalances(true, true, "1");
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
