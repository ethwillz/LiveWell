using LiveWell.ResidentMain;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using static LiveWell.ConnectHelpers;

namespace LiveWell
{
    public partial class GroceryLists : ContentPage
    {
        List<ListInfo> list = new List<ListInfo>();
        List<ListInformation> lists;

        public GroceryLists()
        {
            InitializeComponent();

            populateList();
        }

        void onTap(object sender, ItemTappedEventArgs e)
        {
            var index = (allLists.ItemsSource as List<ListInfo>).IndexOf(((ListView)sender).SelectedItem as ListInfo);
            Navigation.PushModalAsync(new ListDetails(lists, list[index].ListName, list[index].Users, index));
            ((ListView)sender).SelectedItem = null;
        }

        async void populateList()
        {
            DatabaseGET conn = new DatabaseGET();
            lists = await conn.getLists(1);

            //List which will come from database with all the list items and information
            list = new List<ListInfo>();
            List<int> added = new List<int>();
            for (int i = 0; i < lists.Count; i++)
            {
                if (lists[i].residentID1 != null && lists[i].residentID2 != null && lists[i].residentID3 != null && lists[i].residentID4 != null && !added.Contains(Convert.ToInt32(lists[i].listID)))
                {
                    list.Add(new ListInfo(lists[i].listName, lists[i].residentID1 + ", " + lists[i].residentID2 + ", " + lists[i].residentID3 + ", & " + lists[i].residentID4));
                    added.Add(Convert.ToInt32(lists[i].listID));
                }
                else if (lists[i].residentID1 != null && lists[i].residentID2 != null && lists[i].residentID3 != null && !added.Contains(Convert.ToInt32(lists[i].listID)))
                {
                    list.Add(new ListInfo(lists[i].listName, lists[i].residentID1 + ", " + lists[i].residentID2 + ", & " + lists[i].residentID3));
                    added.Add(Convert.ToInt32(lists[i].listID));
                }
                else if (lists[i].residentID1 != null && lists[i].residentID2 != null && !added.Contains(Convert.ToInt32(lists[i].listID)))
                {
                    list.Add(new ListInfo(lists[i].listName, lists[i].residentID1 + ", & " + lists[i].residentID2));
                    added.Add(Convert.ToInt32(lists[i].listID));
                }
                else if (!added.Contains(Convert.ToInt32(lists[i].listID)))
                {
                    list.Add(new ListInfo(lists[i].listName, lists[i].residentID1));
                    added.Add(Convert.ToInt32(lists[i].listID));
                }
            }

            allLists.ItemsSource = list;
            allLists.RowHeight = 60;
        }

        async void newList(Object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddList());
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
