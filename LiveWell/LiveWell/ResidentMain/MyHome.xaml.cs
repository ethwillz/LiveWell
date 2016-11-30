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
            List<balance> balances = await conn.getBalances(CurrentUser.ID);
            List<ConnectHelpers.NotificationHandler> notifications = await conn.getNotifications(CurrentUser.type, CurrentUser.ID);
            List<ResidentInfo> resident = await (conn.getResidentInfo(CurrentUser.ID));

            String amount = (Convert.ToDouble(balances[0].amount1) + Convert.ToDouble(balances[0].amount2) + Convert.ToDouble(balances[0].amount3) + Convert.ToDouble(balances[0].amount4) + Convert.ToDouble(balances[0].bAmount)).ToString();
            if (amount.Equals("0"))
                balance.Text = "$0.00";
            else
                balance.Text = "$" + amount;
            
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
            String first = "";
            String last = "";
            for(int i = notifications.Count-1; i >= 0; i--)
            {
                if (notifications[i].type == "payRoom")
                {
                    List<ResidentInfo> name = await conn.getResidentInfo(Convert.ToInt32(notifications[i].sender));
                    for(int j = 0; j < name.Count; j++)
                    {
                        if (name[j].residentID.Equals(notifications[i].sender))
                        {
                            first = name[j].firstName;
                            last = name[j].lastName;
                        }
                    }
                    notifs.Add(new QuickViewNotif(first + " " + last + " paid $" + notifications[i].amount + " for '" + notifications[i].description+ "'", "Roommate paid"));
                }
                if (notifications[i].type == "payBuilding")
                {
                    notifs.Add(new QuickViewNotif("You paid $" + notifications[i].amount + " to owner", "Payment to building"));
                }
                if (notifications[i].type == "maintenanceScheduled")
                {
                    notifs.Add(new QuickViewNotif(notifications[i].description, "Maintenance Scheduled"));
                }
                if (notifications[i].type == "fine")
                {
                    notifs.Add(new QuickViewNotif("Your room was fined $" + notifications[i].amount + " for '" + notifications[i].description + "'.", "Fine"));
                }
                if (notifications[i].type == "update")
                {
                    notifs.Add(new QuickViewNotif(notifications[i].description, "Update"));
                }
                if (notifications[i].type == "bought")
                {
                    List<ResidentInfo> name = await conn.getResidentInfo(Convert.ToInt32(notifications[i].sender));
                    for (int j = 0; j < name.Count; j++)
                    {
                        if (name[j].residentID.Equals(notifications[i].sender))
                        {
                            first = name[j].firstName;
                            last = name[j].lastName;
                        }
                    }
                    notifs.Add(new QuickViewNotif(first + " " + last + " bought '" + notifications[i].description + "' and you owe $" + notifications[i].amount, "Debt incurrence"));
                }
            }

            //Sets the source of the listview and the row height
            quickview.ItemsSource = notifs;
            quickview.RowHeight = 60;
        }

        async void payment(Object sender, EventArgs e)
        {
            DatabaseUPDATE u = new DatabaseUPDATE();
            var action = await DisplayActionSheet("Submit payment", "Cancel", null, "Credit Card");
            //Handles payment through credit card
            if (action.Equals("Credit Card"))
            {
                new ResidentMain.HandlePayment().creditCard();
                //await u.updateBalances(true, true, "1");
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
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
