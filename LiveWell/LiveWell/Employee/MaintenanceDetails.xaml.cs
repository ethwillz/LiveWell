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
        public MaintenanceDetails(String requestID, String date, String summary, String description, String roomID, String address)
        {
            InitializeComponent();

            this.requestID.Text = "Maintenance request #" + requestID;
            room.Text = "Room " + roomID;
            building.Text = "Building: " + address;
            this.summary.Text = summary;
            this.description.Text = description;
            this.date.Text = "Date requested: " + date;
        }
    }
}
