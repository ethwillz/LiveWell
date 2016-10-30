using ModernHttpClient;
using Newtonsoft.Json;
using System;
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

            ConnectHelpers.Item item = new ConnectHelpers.Item(listID, itemName, imageUrl);
            string contentJson = JsonConvert.SerializeObject(item);
            var content = new StringContent(contentJson, Encoding.UTF8, "application/json");

            //Runs GET HTTP request to server and gets data back in JSON format
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
    }
}
