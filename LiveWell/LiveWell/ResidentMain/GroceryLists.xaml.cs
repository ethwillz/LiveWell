using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWell
{
    public partial class GroceryLists : ContentPage
    {
        public GroceryLists()
        {
            InitializeComponent();

            //List which will come from database with all the list items and information
            List<ListInfo> lists = new List<ListInfo>()
            {
                new ListInfo("Bathroom stuff", "Ethan W. & Micah B."),
                new ListInfo("Food and such", "Chase W. & Micah B."),
                new ListInfo("Party supplies", "Chris W. & Micah B."),
                new ListInfo("Bathroom stuff", "Ethan W. & Micah B."),
                new ListInfo("Food and such", "Chase W. & Micah B."),
                new ListInfo("Party supplies", "Chris W. & Micah B."),
                new ListInfo("Bathroom stuff", "Ethan W. & Micah B."),
                new ListInfo("Food and such", "Chase W. & Micah B."),
                new ListInfo("Party supplies", "Chris W. & Micah B."),
                new ListInfo("Bathroom stuff", "Ethan W. & Micah B."),
                new ListInfo("Food and such", "Chase W. & Micah B."),
                new ListInfo("Party supplies", "Chris W. & Micah B.")
            };

            allLists.ItemsSource = lists;
            allLists.RowHeight = 60;
        }

        void onTap(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            Navigation.PushModalAsync(new ListDetails());
        }
    }

    //List class which has all information for a given list
    public class ListInfo
    {
        public ListInfo(String listName, String users)
        {
            this.ListName = listName;
            this.Users = users;;
        }

        public String ListName { get; set; }
        public String Users { get; set; }
    }
}
