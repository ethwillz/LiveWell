using System;
using System.Collections.Generic;

using Xamarin.Forms;
using static LiveWell.ConnectHelpers;

namespace LiveWell.ResidentMain
{
    public partial class AddList : ContentPage
    {
        List<String> names = new List<String>();
        List<ResidentInfo> roommates;
        List<int> ids = new List<int>();


        public AddList()
        {
            InitializeComponent();

            populateList();
        }

        async void populateList()
        {
            DatabaseGET conn = new DatabaseGET();
            roommates = await conn.getResidentInfo(1);
            List<Person> people = new List<Person>();
            for(int i = 0; i < roommates.Count; i++)
            {
                people.Add(new Person(roommates[i].firstName + " " + roommates[i].lastName));
            }

            users.ItemsSource = people;
            users.RowHeight = 60;
        }

        async void add(Object sender, EventArgs e)
        {
            for (int i = 0; i < names.Count; i++)
            {
                for (int j = 0; j < roommates.Count; j++)
                {
                    if ((roommates[j].firstName + " " + roommates[j].lastName).Equals(names[i]))
                    {
                        ids.Add(Convert.ToInt32(roommates[j].residentID));
                    }
                }
            }

            DatabasePOST conn = new DatabasePOST();
            await conn.postList(listName.Text, ids);
            await Navigation.PushModalAsync(new GroceryLists());
        }

        public void selected(Object sender, EventArgs e)
        {
            if (((SwitchCell)sender).On)
                names.Add(((SwitchCell)sender).Text);
        }
    }

    public class Person
    {
        public Person(String user)
        {
            this.user = user;
        }

        public String user { get; set; }
    }
}
