using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static LiveWell.ConnectHelpers;

namespace LiveWell
{
    class DatabaseGET
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

        //Gets all relevant information for an individual resident
        public async Task<List<ResidentInfo>> getResidentInfo(int residentID)
        {
            //Instantiates new httpclient object with base address for http requests
            var getNotifications = new HttpClient(new NativeMessageHandler());
            getNotifications.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/getRoom.php");

            //Runs GET HTTP request to server and gets data back in JSON format
            HttpResponseMessage gotNotifications = await getNotifications.GetAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/getRoom.php?residentID=" + residentID));
            String data = await gotNotifications.Content.ReadAsStringAsync();

            //Data desrialized into list of notification objects (automatically handled by NewtonSoft.Json library)
            List<ResidentInfo> residentInfo = JsonConvert.DeserializeObject<List<ResidentInfo>>(data);

            //Returns list for use in UI
            return residentInfo;
        }

        public async Task<List<Notification>> getPayments(int residentID)
        {
            //Instantiates new httpclient object with base address for http requests
            var getNotifications = new HttpClient(new NativeMessageHandler());
            getNotifications.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/getPayments.php");

            //Runs GET HTTP request to server and gets data back in JSON format
            HttpResponseMessage gotNotifications = await getNotifications.GetAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/getPayments.php?residentID=" + residentID));
            String data = await gotNotifications.Content.ReadAsStringAsync();

            //Data desrialized into list of notification objects (automatically handled by NewtonSoft.Json library)
            List<Notification> notifications = JsonConvert.DeserializeObject<List<Notification>>(data);

            //Returns list for use in UI
            return notifications;
        }

        public async Task<List<ListInformation>> getLists(int residentID)
        {
            //Instantiates new httpclient object with base address for http requests
            var getLists = new HttpClient(new NativeMessageHandler());
            getLists.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/getLists.php");

            //Runs GET HTTP request to server and gets data back in JSON format
            HttpResponseMessage gotLists = await getLists.GetAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/getLists.php?residentID=" + residentID));
            String data = await gotLists.Content.ReadAsStringAsync();

            //Data desrialized into list of notification objects (automatically handled by NewtonSoft.Json library)
            List<ListInformation> lists= JsonConvert.DeserializeObject<List<ListInformation>>(data);

            //Returns list for use in UI
            return lists;
        }

        public async Task<List<Food>> getFoods()
        {
            //Instantiates new httpclient object with base address for http requests
            var getFoods = new HttpClient(new NativeMessageHandler());
            getFoods.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/getFoods.php");

            //Runs GET HTTP request to server and gets data back in JSON format
            HttpResponseMessage gotLists = await getFoods.GetAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/getFoods.php"));
            String data = await gotLists.Content.ReadAsStringAsync();

            //Data desrialized into list of notification objects (automatically handled by NewtonSoft.Json library)
            List<Food> foods = JsonConvert.DeserializeObject<List<Food>>(data);

            //Returns list for use in UI
            return foods;
        }

        public async Task<List<Address>> getAddress(int price, String accommodationType, int numRooms)
        {
            var getAddress = new HttpClient(new NativeMessageHandler());
            getAddress.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/getBuilding.php");

			HttpResponseMessage gotAddress = await getAddress.GetAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/getBuilding.php?price=" + price + "&accommodationType=" + accommodationType + "&numRooms=" + numRooms));
            String data = await gotAddress.Content.ReadAsStringAsync();
            //Debug.WriteLine(@data);
            List<Address> addresses = JsonConvert.DeserializeObject<List<Address>>(data);
            //Debug.WriteLine(@addresses);
            return addresses;
        }

		/*For Testing*/
		//public async Task<List<Address>> getAddress(int price)
		//{
		//	var getAddress = new HttpClient(new NativeMessageHandler());
		//	getAddress.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/getBuilding.php");

		//	HttpResponseMessage gotAddress = await getAddress.GetAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/getBuilding.php?price=" + price));
		//	String data = await gotAddress.Content.ReadAsStringAsync();
		//	//Debug.WriteLine(@data);
		//	List<Address> addresses = JsonConvert.DeserializeObject<List<Address>>(data);
		//	//Debug.WriteLine(@addresses);
		//	return addresses;
		//}

        public async Task<List<ListInformation>> getSuggestions(int residentID)
        {
            //Instantiates new httpclient object with base address for http requests
            var getFoods = new HttpClient(new NativeMessageHandler());
            getFoods.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/getSuggestions.php");

            //Runs GET HTTP request to server and gets data back in JSON format
            HttpResponseMessage gotLists = await getFoods.GetAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/getSuggestions.php?residentID=" + residentID));
            String data = await gotLists.Content.ReadAsStringAsync();

            //Data desrialized into list of notification objects (automatically handled by NewtonSoft.Json library)
            List<ListInformation> foods = JsonConvert.DeserializeObject<List<ListInformation>>(data);

            //Returns list for use in UI
            return foods;

        }
    }
}
