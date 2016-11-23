using System;
using System.Collections.Generic;

namespace LiveWell
{
    public class ConnectHelpers
    {

        //Notification object which stores all necessary data returned by the HTTP request
        public class NotificationHandler
        {
            public NotificationHandler(String notificationID, String type, String sender, String recipient, String description, String amount)
            {
                this.notificationID = notificationID;
                this.type = type;
                this.sender = sender;
                this.recipient = recipient;
                this.description = description;
                this.amount = amount;
            }

            public String notificationID { get; set; }
            public String type { get; set; }
            public String sender { get; set; }
            public String recipient { get; set; }
            public String description { get; set; }
            public String amount { get; set; }
        }

        public class Address
		{
			public Address(String accommodationType, String address)
			{
				this.accommodationType = accommodationType;
				this.address = address;
			}

			public String accommodationType { get; set; }
			public String address { get; set; }
			public String imageUrl { get; set; }
			public int buildingID { get; set; }
			public double latitude { get; set; }
			public double longitude { get; set; }
		}

		public class Favorite
		{
			public Favorite(int buildingID, int favorite)
			{
				this.buildingID = buildingID;
				this.favorite = favorite;
			}

			public int buildingID { get; set; }
			public int favorite { get; set; }
		}

		public class Image
		{
			public Image(String accommodationType, String address, String imageUrl, int buildingID)
			{
				this.accommodationType = accommodationType;
				this.address = address;
				this.imageUrl = imageUrl;
				this.buildingID = buildingID;
			}

			public String accommodationType { get; set; }
			public String address { get; set; }
			public String imageUrl { get; set; }
			public int buildingID { get; set; }

		}

        public class ResidentInfo
        {
			public ResidentInfo(){ } //default constructor is needed since there are two other constructors
            public ResidentInfo(String address, String number, String email, String password, String firstName, String lastName, String residentID)
            {
                this.address = address;
                this.number = number;
				this.email = email;
				this.password = password;
                this.firstName = firstName;
                this.lastName = lastName;
				this.residentID =residentID;
            }

			public String email { get; set; }
			public String password { get; set; }
            public String address { get; set; }
            public String number { get; set; }
            public String firstName { get; set; }
            public String lastName { get; set; }
			public String residentID { get; set; }
        }

        public class EmployeeInfo
        {
            public EmployeeInfo(String firstName, String lastName, String buildingID, String address)
            {
                this.firstName = firstName;
                this.lastName = lastName;
                this.buildingID = buildingID;
                this.address = address;
            }

            public String firstName { get; set; }
            public String lastName { get; set; }
            public String buildingID { get; set; }
            public String address { get; set; }
        }

        /*Both resident, employee and owner*/
        public class UserInfo
		{
			public UserInfo(String userType, String firstName, String lastName, String email, String password)
			{
				this.userType = userType;
				this.firstName = firstName;
				this.lastName = lastName;
				this.email = email;
				this.password = password;
			}

			public String userType { get; set; }
			public String email { get; set; }
			public String password { get; set; }
			public String firstName { get; set; }
			public String lastName { get; set; }
			public String residentID { get; set; }
			public String employeeID { get; set; }
			public String ownerID { get; set; }
		}

        public class MaintenanceRequest
        {
            public MaintenanceRequest(String residentID, String summary, String explanation, DateTime date)
            {
                this.residentID = residentID;
                this.summary = summary;
                this.explanation = explanation;
                this.date = date.ToString();
            }

            public MaintenanceRequest(String date, String employeeID, String ID)
            {
                this.date = date;
                this.employeeID = employeeID;
                this.requestID = ID;
            }

            public String requestID { get; set; }
            public String roomID { get; set; }
            public String residentID { get; set; }
            public String employeeID { get; set; }
            public String summary { get; set; }
            public String date { get; set; }
            public String roomNumber { get; set; }
            public String explanation { get; set; }
        }

        public class MaintenanceRecord
        {
            public MaintenanceRecord(String maintenanceID, String number, String residentID, String employeeID, String summary, String description, String date)
            {
                this.maintenanceID = maintenanceID;
                this.number = number;
                this.residentID = residentID;
                this.employeeID = employeeID;
                this.summary = summary;
                this.description = description;
                this.date = date;
            }

            public String maintenanceID { get; set; }
            public String number { get; set; }
            public String residentID { get; set; }
            public String employeeID { get; set; }
            public String summary { get; set; }
            public String description { get; set; }
            public String date { get; set; }
        }

        public class ListInformation
        {
            public ListInformation(String listID, String listName, String residentID1, String residentID2, String residentID3, String residentID4)
            {
                this.listID = listID;
                this.listName = listName;
                this.residentID1 = residentID1;
                this.residentID2 = residentID2;
                this.residentID3 = residentID3;
                this.residentID4 = residentID4;
            }

            public String listID { get; set; }
            public String listName { get; set; }
            public String residentID1 { get; set; }
            public String residentID2 { get; set; }
            public String residentID3 { get; set; }
            public String residentID4 { get; set; }
        }

        public class Food
        {
            public Food(String name, String imageUrl)
            {
                this.name = name;
                this.imageUrl = imageUrl;
            }

            public String name { get; set; }
            public String imageUrl { get; set; }
        }

        public class Item
        {
            public Item(String itemName, String imageUrl)
            {
                this.itemName = itemName;
                this.imageUrl = imageUrl;
            }

            public String itemName { get; set; }
            public String imageUrl { get; set; }
        }

        public class ItemPost
        {
            public ItemPost(String listID, String itemName, String imageUrl)
            {
                this.listID = listID;
                this.itemName = itemName;
                this.imageUrl = imageUrl;
            }

            public String listID { get; set; }
            public String itemName { get; set; }
            public String imageUrl { get; set; }
        }

        public class balance
        {
            public balance(String amount1, String amount2, String amount3, String amount4, String bAmount)
            {
                this.amount1 = amount1;
                this.amount2 = amount2;
                this.amount3 = amount3;
                this.amount4 = amount4;
                this.bAmount = bAmount;
            }

            public String amount1 { get; set; }
            public String amount2 { get; set; }
            public String amount3 { get; set; }
            public String amount4 { get; set; }
            public String bAmount { get; set; }
        }

        public class ItemList
        {
            public ItemList(String listName, int residentID1, int residentID2, int residentID3, int residentID4)
            {
                this.listName = listName;
                this.residentID1 = residentID1;
                this.residentID2 = residentID2;
                this.residentID3 = residentID3;
                this.residentID4 = residentID4;
            }

            public String listName { get; set; }
            public int residentID1 { get; set; }
            public int residentID2 { get; set; }
            public int residentID3 { get; set; }
            public int residentID4 { get; set; }
        }

        public class Name
        {
            public Name(String firstName, String lastName)
            {
                this.firstName = firstName;
                this.lastName = lastName;
            }

            public String firstName { get; set; }
            public String lastName { get; set; }
        }

        public class Payment
        {
            public Payment(String amount, String sender, List<String> roommates, String listID, String listName)
            {
                this.amount = amount;
                this.sender = sender;
                this.roommates = roommates;
                this.listID = listID;
                this.listName = listName;
            }

            public String amount { get; set; }
            public String sender { get; set; }
            public List<String> roommates { get; set; }
            public String listID { get; set; }
            public String listName { get; set; }
        }

    }
}
