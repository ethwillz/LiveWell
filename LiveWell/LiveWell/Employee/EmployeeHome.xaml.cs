using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace LiveWell
{
    public partial class EmployeeHome : ContentPage
    {
        public EmployeeHome()
        {
            InitializeComponent();

            logo.Source = ImageSource.FromResource("LiveWell.LiveWellFullLogo.png");

            populateList();
        }

        async void populateList()
        {
            DatabaseGET conn = new DatabaseGET();
            List<ConnectHelpers.NotificationHandler> notifications = await conn.getNotifications(CurrentUser.type, CurrentUser.ID);
            List<QuickViewNotif> all = new List<QuickViewNotif>();
            for (int i = notifications.Count - 1; i >= 0; i--)
            {
                if (notifications[i].type.Equals("maintenance"))
                    all.Add(new QuickViewNotif("Maintenance request for " + notifications[i].description, "Maintenance request"));
                if (notifications[i].type.Equals("updateEmployee"))
                    all.Add(new QuickViewNotif(notifications[i].description, "Update"));
            }

            quickview.ItemsSource = all;
            quickview.RowHeight = 60;
        }
    }
}
