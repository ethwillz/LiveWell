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
        //Instantiates new httpclient object with base address for http requests
        HttpClient client = new HttpClient(new NativeMessageHandler());

        public async Task<List<Notification>> getNotifications(int residentID)
        {
            client.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/");

            //Runs GET HTTP request to server and gets data back in JSON format
            HttpResponseMessage gotNotifications = await client.GetAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/getNotifications.php?residentID=" + residentID));
            String data = await gotNotifications.Content.ReadAsStringAsync();
            
            //Data desrialized into list of notification objects (automatically handled by NewtonSoft.Json library)
            List<Notification> notifications = JsonConvert.DeserializeObject<List<Notification>>(data);

            //Returns list for use in UI
            return notifications;
        }

        //Gets all relevant information for an individual resident
        public async Task<List<ResidentInfo>> getResidentInfo(int residentID)
        {
            client.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/getRoom.php");

            //Runs GET HTTP request to server and gets data back in JSON format
            HttpResponseMessage gotNotifications = await client.GetAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/getRoom.php?residentID=" + residentID));
            String data = await gotNotifications.Content.ReadAsStringAsync();

            //Data desrialized into list of notification objects (automatically handled by NewtonSoft.Json library)
            List<ResidentInfo> residentInfo = JsonConvert.DeserializeObject<List<ResidentInfo>>(data);

            //Returns list for use in UI
            return residentInfo;
        }

        public async Task<List<Notification>> getPayments(int residentID)
        {
           client.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/getPayments.php");

            //Runs GET HTTP request to server and gets data back in JSON format
            HttpResponseMessage gotNotifications = await client.GetAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/getPayments.php?residentID=" + residentID));
            String data = await gotNotifications.Content.ReadAsStringAsync();

            //Data desrialized into list of notification objects (automatically handled by NewtonSoft.Json library)
            List<Notification> notifications = JsonConvert.DeserializeObject<List<Notification>>(data);

            //Returns list for use in UI
            return notifications;
        }

        public async Task<List<ListInformation>> getLists(int residentID)
        {
            client.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/getLists.php");

            //Runs GET HTTP request to server and gets data back in JSON format
            HttpResponseMessage gotLists = await client.GetAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/getLists.php?residentID=" + residentID));
            String data = await gotLists.Content.ReadAsStringAsync();

            //Data desrialized into list of notification objects (automatically handled by NewtonSoft.Json library)
            List<ListInformation> lists= JsonConvert.DeserializeObject<List<ListInformation>>(data);

            //Returns list for use in UI
            return lists;
        }

        public async Task<List<ListInformation>> getLists(String listID)
        {
            client.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/getLists.php");

            //Runs GET HTTP request to server and gets data back in JSON format
            HttpResponseMessage gotLists = await client.GetAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/getLists.php?listID=" + listID));
            String data = await gotLists.Content.ReadAsStringAsync();

            //Data desrialized into list of notification objects (automatically handled by NewtonSoft.Json library)
            List<ListInformation> lists = JsonConvert.DeserializeObject<List<ListInformation>>(data);

            //Returns list for use in UI
            return lists;
        }

        public async Task<List<Food>> getFoods()
        {
            client.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/getFoods.php");

            //Runs GET HTTP request to server and gets data back in JSON format
            HttpResponseMessage gotLists = await client.GetAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/getFoods.php"));
            String data = await gotLists.Content.ReadAsStringAsync();

            //Data desrialized into list of notification objects (automatically handled by NewtonSoft.Json library)
            List<Food> foods = JsonConvert.DeserializeObject<List<Food>>(data);

            //Returns list for use in UI
            return foods;
        }

		public async Task<List<Address>> getAddress()
		{
			var getAddress = new HttpClient(new NativeMessageHandler());
			getAddress.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/getBuilding.php");

			HttpResponseMessage gotAddress = await getAddress.GetAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/getBuilding.php?"));
			String data = await gotAddress.Content.ReadAsStringAsync();
			//Debug.WriteLine(@data);
			List<Address> addresses = JsonConvert.DeserializeObject<List<Address>>(data);
			//Debug.WriteLine(@addresses);
			return addresses;
		}

        public async Task<List<Address>> getAddress(int price, String accommodationType, int numRooms)
        {
            client.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/getBuilding.php");

			HttpResponseMessage gotAddress = await client.GetAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/getBuilding.php?price=" + price + "&accommodationType=" + accommodationType + "&numRooms=" + numRooms));

            String data = await gotAddress.Content.ReadAsStringAsync();
            //Debug.WriteLine(@data);
            List<Address> addresses = JsonConvert.DeserializeObject<List<Address>>(data);
            //Debug.WriteLine(@addresses);
            return addresses;
        }

		public async Task<List<Address>> getFavorite()
		{
			var getFavorite = new HttpClient(new NativeMessageHandler());
			int favorite = 1;
			getFavorite.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/getBuilding.php");

			HttpResponseMessage gotFavorite = await getFavorite.GetAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/getBuilding.php?favorite=" + favorite));
			String data = await gotFavorite.Content.ReadAsStringAsync();
			//Debug.WriteLine(@data);
			List<Address> addresses = JsonConvert.DeserializeObject<List<Address>>(data);
			//Debug.WriteLine(@addresses);
			return addresses;
		}

        public async Task<List<ConnectHelpers.Item>> getSuggestions(int residentID)
        {
            client.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/getSuggestions.php");

            //Runs GET HTTP request to server and gets data back in JSON format
            HttpResponseMessage gotLists = await client.GetAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/getSuggestions.php?residentID=" + residentID));
            String data = await gotLists.Content.ReadAsStringAsync();

            //Data desrialized into list of notification objects (automatically handled by NewtonSoft.Json library)
            List<ConnectHelpers.Item> foods = JsonConvert.DeserializeObject<List<ConnectHelpers.Item>>(data);

            //Returns list for use in UI
            return foods;

        }

        public async Task<List<balance>> getBalances(int residentID)
        {
            client.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/getBalances.php");

            //Runs GET HTTP request to server and gets data back in JSON format
            HttpResponseMessage gotLists = await client.GetAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/getBalances.php?residentID=" + residentID));
            String data = await gotLists.Content.ReadAsStringAsync();

            //Data desrialized into list of notification objects (automatically handled by NewtonSoft.Json library)
            List<balance> balances = JsonConvert.DeserializeObject<List<balance>>(data);

            //Returns list for use in UI
            return balances;

        }

        public async Task<List<ConnectHelpers.Item>> getProductsOnList(String listID)
        {
            client.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/getItems.php");

            //Runs GET HTTP request to server and gets data back in JSON format
            HttpResponseMessage gotItems = await client.GetAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/getItems.php?listID=" + listID));
            String data = await gotItems.Content.ReadAsStringAsync();

            //Data desrialized into list of notification objects (automatically handled by NewtonSoft.Json library)
            List<ConnectHelpers.Item> items = JsonConvert.DeserializeObject<List<ConnectHelpers.Item>>(data);

            //Returns list for use in UI
            return items;

        }

        public async Task<String> getName(String residentID)
        {
            client.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/getName.php");

            //Runs GET HTTP request to server and gets data back in JSON format
            HttpResponseMessage gotName = await client.GetAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/getName.php?residentID=" + residentID));
            String data = await gotName.Content.ReadAsStringAsync();

            //Data desrialized into list of notification objects (automatically handled by NewtonSoft.Json library)
            List<Name> name = JsonConvert.DeserializeObject<List<Name>>(data);

            //Returns list for use in UI
            return name[0].firstName + " " + name[0].lastName;
        }
    }
}
