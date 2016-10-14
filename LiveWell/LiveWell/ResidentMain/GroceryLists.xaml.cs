using System;
using System.Collections.Generic;

using Xamarin.Forms;
using static LiveWell.ConnectHelpers;

namespace LiveWell
{
    public partial class GroceryLists : ContentPage
    {
        List<ListInformation> lists;

        public GroceryLists()
        {
            InitializeComponent();

            populateList();
        }

        void onTap(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushModalAsync(new ListDetails(lists, ((TextCell)sender).Text, ((TextCell)sender).Detail));
            ((ListView)sender).SelectedItem = null;
        }

        async void populateList()
        {
            DatabaseGET conn = new DatabaseGET();
            lists = await conn.getLists(1);

            //List which will come from database with all the list items and information
            List<ListInfo> list = new List<ListInfo>();
            for (int i = 0; i < lists.Count; i++)
            {
                if (lists[i].residentID1 != null && lists[i].residentID2 != null && lists[i].residentID3 != null && lists[i].residentID4 != null)
                    list.Add(new ListInfo(lists[i].listName, lists[i].residentID1 + ", " + lists[i].residentID2 + ", " + lists[i].residentID3 + ", & " + lists[i].residentID4));
                else if (lists[i].residentID1 != null && lists[i].residentID2 != null && lists[i].residentID3 != null)
                    list.Add(new ListInfo(lists[i].listName, lists[i].residentID1 + ", " + lists[i].residentID2 + ", & " + lists[i].residentID3));
                else if (lists[i].residentID1 != null && lists[i].residentID2 != null)
                    list.Add(new ListInfo(lists[i].listName, lists[i].residentID1 + ", & " + lists[i].residentID2));
                else
                    list.Add(new ListInfo(lists[i].listName, lists[i].residentID1));
            }

            allLists.ItemsSource = list;
            allLists.RowHeight = 60;
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
