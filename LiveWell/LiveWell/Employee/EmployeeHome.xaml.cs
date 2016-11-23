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
            for (int i = 0; i < notifications.Count; i++)
            {
                if (notifications[i].type.Equals("maintenance"))
                all.Add(new QuickViewNotif("Maintenance scheduled for " + notifications[i].description, notifications[i].type));
            }

        }
    }
}
