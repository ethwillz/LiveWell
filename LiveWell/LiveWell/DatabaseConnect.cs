using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static LiveWell.ConnectHelpers;

namespace LiveWell
{
    class DatabaseConnect
    {
        public async Task<List<Notification>> getNotifications(int residentID)
        {
            //Instantiates new httpclient object with base address for http requests
            var getNotifications = new HttpClient(new NativeMessageHandler());
            getNotifications.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/getNotifications.php");

            //Runs GET HTTP request to server and gets data back in JSON format
            HttpResponseMessage gotNotifications = await getNotifications.GetAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/getNotifications.php?residentID=" + residentID));
            String data = await gotNotifications.Content.ReadAsStringAsync();
            
            //Data desrialized into list of notification objects (automatically handled by NewtonSoft.Json library)
            List<Notification> notifications = JsonConvert.DeserializeObject<List<Notification>>(data);

            //Returns list for use in UI
            return notifications;
        }

		public async Task<List<Address>> getAddress(int buildingID)
		{
			var getAddress = new HttpClient(new NativeMessageHandler());
			getAddress.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/getBuilding.php");

			HttpResponseMessage gotAddress = await getAddress.GetAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/getBuilding.php?buildingID=" + buildingID));
			String data = await gotAddress.Content.ReadAsStringAsync();
			//Debug.WriteLine(@data);
			List<Address> addresses = JsonConvert.DeserializeObject<List<Address>>(data);
			//Debug.WriteLine(@addresses);
			return addresses;
		}
    }
}
