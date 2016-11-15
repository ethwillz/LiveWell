using System;
using System.Collections.Generic;

using Xamarin.Forms;
using static LiveWell.ConnectHelpers;

namespace LiveWell
{
    public partial class EmployeeMaintenance : ContentPage
    {
        List<MaintenanceRecord> requests;
        List<EmployeeInfo> employee;

        public EmployeeMaintenance()
        {
            InitializeComponent();

            populateList();
        }

        async void populateList()
        {
            DatabaseGET conn = new DatabaseGET();
            employee = await conn.getEmployeeInfo(CurrentUser.ID);
            requests = await conn.getMaintenance(employee[0].buildingID);
            List<Request> allRequests = new List<Request>();
            for (int i = 0; i < requests.Count; i++)
            {
                allRequests.Add(new Request(requests[i].summary, requests[i].roomID));
            }
            requestList.ItemsSource = allRequests;
        }

        public void onTap(Object sender, EventArgs e)
        {
            var index = (requestList.ItemsSource as List<Request>).IndexOf(((ListView)sender).SelectedItem as Request);
            Navigation.PushModalAsync(new MaintenanceDetails(requests[index].maintenanceID, requests[index].date, requests[index].summary, requests[index].description, requests[index].roomID, employee[0].address));
            ((ListView)sender).SelectedItem = null;
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
