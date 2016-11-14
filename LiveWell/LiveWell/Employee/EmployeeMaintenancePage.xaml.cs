using System;
using System.Collections.Generic;

using Xamarin.Forms;
using static LiveWell.ConnectHelpers;

namespace LiveWell
{
    public partial class EmployeeMaintenancePage : ContentPage
    {
        List<MaintenanceRequest> requests;

        public EmployeeMaintenancePage()
        {
            InitializeComponent();

            populateList();
        }

        async void populateList()
        {
            DatabaseGET conn = new DatabaseGET();
            //requests = conn.getMaintenance(CurrentUser.ID);
            List<Request> allRequests = new List<Request>();
            for(int i = 0; i < requests.Count; i++)
            {
                allRequests.Add(new Request(requests[i].summary, requests[i].roomID));
            }
            //requestList.ItemsSource = 
        }

        public void onTap(Object sender, EventArgs e)
        {
            //var index = (requestList.ItemsSource as List<Request>).IndexOf(((ListView)sender).SelectedItem as ListInfo);
            //Navigation.PushModalAsync(new MaintenanceDetails(requests[index].date, requests[index].summary, requests[index].roomID));
            //((ListView)sender).SelectedItem = null;
        }
    }

    public class Request
    {
        public Request(String summary, String room)
        {
            this.summary = summary;
            this.room = room;
        }

        public String summary { get; set; }
        public String room { get; set; }
    }
}

