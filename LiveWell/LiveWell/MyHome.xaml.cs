using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace LiveWell
{
    public partial class MyHome : ContentPage
    {
        public MyHome()
        {
            List<Notification> notifications = new List<Notification>()
            {
                new Notification("Chris W. bought groceries and you owe $23.72"),
                new Notification("Campustown fined your room for a noise violation"),
                new Notification("Maintenance scheduled for October 2nd at 2:00pm")
            };
            
            quickview.ItemsSource = notifications;
            quickview.ItemTemplate = new DataTemplate(() =>
            {
                return new TextCell
                {

                };
            });
        }
    }

    public class Notification
    {
        String summary;
        public Notification(String summary)
        {
            this.summary = summary;
        }
    }
}
