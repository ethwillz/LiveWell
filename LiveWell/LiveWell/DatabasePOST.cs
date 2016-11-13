﻿using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static LiveWell.ConnectHelpers;

namespace LiveWell
{
    class DatabasePOST
    {
        public async Task postMaintenance(String roomID, String residentID, String employeeID, String summary, String date)
        {
            //Instantiates new httpclient object with base address for http requests
            var getNotifications = new HttpClient(new NativeMessageHandler());
            getNotifications.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/postMaintenance.php");

            MaintenanceRequest maintenance = new MaintenanceRequest(roomID, residentID, employeeID, summary, date);
            string contentJson = JsonConvert.SerializeObject(maintenance);
            var content = new StringContent(contentJson, Encoding.UTF8, "application/json");

            //Runs GET HTTP request to server and gets data back in JSON format
            HttpResponseMessage gotNotifications = await getNotifications.PostAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/postMaintenance.php"), content);
        }

        public async Task postItem(String listID, String itemName, String imageUrl)
        {
            //Instantiates new httpclient object with base address for http requests
            var getNotifications = new HttpClient(new NativeMessageHandler());
            getNotifications.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/postItem.php");

            ConnectHelpers.ItemPost item = new ConnectHelpers.ItemPost(listID, itemName, imageUrl);
            string contentJson = JsonConvert.SerializeObject(item);
            var content = new StringContent(contentJson, Encoding.UTF8, "application/json");

            //Runs POST HTTP request to server and gets data back in JSON format
            HttpResponseMessage gotNotifications = await getNotifications.PostAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/postItem.php"), content);
        }

		public async Task postFavoriteAccommodation(int buildingID, int favorite)
		{
			//Instantiates new httpclient object with base address for http requests
			var getNotifications = new HttpClient(new NativeMessageHandler());
			getNotifications.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/postBuilding.php");

			ConnectHelpers.Favorite favoriteAccommodation = new ConnectHelpers.Favorite(buildingID, favorite);
			string contentJson = JsonConvert.SerializeObject(favoriteAccommodation);
			var content = new StringContent(contentJson, Encoding.UTF8, "application/json");

			//Runs GET HTTP request to server and gets data back in JSON format
			HttpResponseMessage gotNotifications = await getNotifications.PostAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/postBuilding.php"), content);
		}

		public async Task postResidentInfo(String firstName, String lastName, String email, String password)
		{
			System.Diagnostics.Debug.WriteLine(firstName);
			System.Diagnostics.Debug.WriteLine(lastName);
			System.Diagnostics.Debug.WriteLine("YES!!!!!!!!!!!!!!!!!!!!!!!!");

			//Instantiates new httpclient object with base address for http requests
			var getNotifications = new HttpClient(new NativeMessageHandler());
			getNotifications.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/postResidentInfo.php");

			ConnectHelpers.ResidentInfo resident = new ConnectHelpers.ResidentInfo(firstName,lastName,email,password);
			string contentJson = JsonConvert.SerializeObject(resident);
			var content = new StringContent(contentJson, Encoding.UTF8, "application/json");

			//Runs GET HTTP request to server and gets data back in JSON format
			HttpResponseMessage gotNotifications = await getNotifications.PostAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/postResidentInfo.php"), content);
		}
		
        public async Task postList(String listName, List<int> ids)
        {
            var postList = new HttpClient(new NativeMessageHandler());
            postList.BaseAddress = new Uri("http://proj-309.la-04.cs.iastate.edu/postList.php");

            ConnectHelpers.ItemList list;
            if(ids.Count == 1)
            {
                list = new ConnectHelpers.ItemList(listName, ids[0], 0, 0, 0);
            }
            else if(ids.Count == 2)
            {
                list = new ConnectHelpers.ItemList(listName, ids[0], ids[1], 0, 0);
            }
            else if(ids.Count == 3)
            {
                list = new ConnectHelpers.ItemList(listName, ids[0], ids[1], ids[2], 0);
            }
            else
                list = new ConnectHelpers.ItemList(listName, ids[0], ids[1], ids[2], ids[3]);


            string contentJson = JsonConvert.SerializeObject(list);
            var content = new StringContent(contentJson, Encoding.UTF8, "application/json");

            //Runs POST HTTP request to server and gets data back in JSON format
            HttpResponseMessage sentList = await postList.PostAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/postList.php"), content);
        }

        public async Task chargeAllAndNotify(String amount, String sender, List<String> roommates, String listID, String listName)
        {
            //Instantiates new httpclient object with base address for http requests
            var getNotifications = new HttpClient(new NativeMessageHandler());
            getNotifications.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/postGroceryPayment.php");

            ConnectHelpers.Payment favoriteAccommodation = new ConnectHelpers.Payment(amount, sender, roommates, listID, listName);
            string contentJson = JsonConvert.SerializeObject(favoriteAccommodation);
            var content = new StringContent(contentJson, Encoding.UTF8, "application/json");

            //Runs GET HTTP request to server and gets data back in JSON format
            HttpResponseMessage gotNotifications = await getNotifications.PostAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/postGroceryPayment.php"), content);
        }
    }
}
