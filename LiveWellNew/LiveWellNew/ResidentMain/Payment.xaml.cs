using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using static LiveWellNew.ConnectHelpers;

namespace LiveWellNew
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
			List<balance> balances = await conn.getBalances(CurrentUser.ID);
			List<ConnectHelpers.NotificationHandler> notifications = await conn.getPayments(CurrentUser.ID);

			String amount = (Convert.ToDouble(balances[0].amount1) + Convert.ToDouble(balances[0].amount2) + Convert.ToDouble(balances[0].amount3) + Convert.ToDouble(balances[0].amount4)).ToString();
			if (amount.Equals("0"))
				roomBill.Text = "$0.00";
			else
				roomBill.Text = "$" + amount;
			buildingBill.Text = "$" + balances[0].bAmount;


			//Payment history of the current user
			List<PayRecord> pay = new List<PayRecord>();
			String first = "";
			String last = "";
			for (int i = 0; i < notifications.Count; i++)
			{
				if (notifications[i].type == "payRoom")
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
					pay.Add(new PayRecord(first + " " + last + " paid $" + notifications[i].amount + " for '" + notifications[i].description + "'", "Roommate paid"));
				}
				if (notifications[i].type == "payBuilding")
				{
					pay.Add(new PayRecord("You paid $" + notifications[i].amount + " to owner", "Payment to building"));
				}
				if (notifications[i].type == "fine")
				{
					pay.Add(new PayRecord("Your room was fined $" + notifications[i].amount + " for '" + notifications[i].description + "'.", "Fine"));
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
					pay.Add(new PayRecord(first + " " + last + " bought '" + notifications[i].description + "' and you owe $" + notifications[i].amount + ".", "Debt incurrence"));
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
				//new ResidentMain.HandlePayment().creditCard();
				//await u.updateBalances(false, true, "1");
			}
		}

		async void payRoom(Object sender, EventArgs e)
		{
			var action = await DisplayActionSheet("Submit payment", "Cancel", null, "Credit Card");
			//Handles payment through credit card
			if (action.Equals("Credit Card"))
			{
				//new ResidentMain.HandlePayment().creditCard();
				//await u.updateBalances(true, false, "1");
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