using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace LiveWell
{
    public partial class MaintenanceDetails : ContentPage
    {
        String ID;

        public MaintenanceDetails(String requestID, String date, String summary, String description, String roomID, String address)
        {
            InitializeComponent();

            ID = requestID;
            this.requestID.Text = "Maintenance request #" + requestID;
            room.Text = "Room " + roomID;
            building.Text = "Building: " + address;
            this.summary.Text = summary;
            this.description.Text = description;
            this.date.Text = "Date requested: " + date;
        }

        async void schedule(Object o, EventArgs e)
        {
            DatabasePOST conn = new DatabasePOST();
            await conn.postMaintenance((scheduledDate.Date).ToString(), CurrentUser.ID, ID);
            await Navigation.PushModalAsync(new EmployeeMain());
        }
    }
}
