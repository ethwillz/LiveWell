﻿using System;

namespace LiveWell
{
    public class ConnectHelpers
    {

        //Notification object which stores all necessary data returned by the HTTP request
        public class Notification
        {
            public Notification(String notificationID, String residentID, String type, String amount, String firstName, String lastName, String details)
            {
                this.notificationID = notificationID;
                this.residentID = residentID;
                this.type = type;
                this.amount = amount;
                this.firstName = firstName;
                this.lastName = lastName;
                this.details = details;
            }

            public String notificationID { get; set; }
            public String residentID { get; set; }
            public String type { get; set; }
            public String amount { get; set; }
            public String firstName { get; set; }
            public String lastName { get; set; }
            public String details { get; set; }
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
		}

        public class ResidentInfo
        {
            public ResidentInfo(String address, String number, String residentID, String firstName, String lastName)
            {
                this.address = address;
                this.number = number;
                this.residentID = residentID;
                this.firstName = firstName;
                this.lastName = lastName;
            }

            public String address { get; set; }
            public String number { get; set; }
            public String residentID { get; set; }
            public String firstName { get; set; }
            public String lastName { get; set; }
        }

        public class MaintenanceRequest
        {
            public MaintenanceRequest(String roomID, String residentID, String employeeID, String summary, String date)
            {
                this.roomID = roomID;
                this.residentID = residentID;
                this.employeeID = employeeID;
                this.summary = summary;
                this.date = date;
            }

            public String roomID { get; set; }
            public String residentID { get; set; }
            public String employeeID { get; set; }
            public String summary { get; set; }
            public String date { get; set; }
        }

        public class ListInformation
        {
            public ListInformation(String listID, String listName, String residentID1, String residentID2, String residentID3, String residentID4, String itemID)
            {
                this.listID = listID;
                this.listName = listName;
                this.residentID1 = residentID1;
                this.residentID2 = residentID2;
                this.residentID3 = residentID3;
                this.residentID4 = residentID4;
                this.itemID = itemID;
                this.itemName = itemName;
                this.imageUrl = imageUrl;
            }

            public String listID { get; set; }
            public String listName { get; set; }
            public String residentID1 { get; set; }
            public String residentID2 { get; set; }
            public String residentID3 { get; set; }
            public String residentID4 { get; set; }
            public String itemID { get; set; }
            public String itemName { get; set; }
            public String imageUrl { get; set; }
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
            public Item(String listID, String itemName, String imageUrl)
            {
                this.listID = listID;
                this.itemName = itemName;
                this.imageUrl = imageUrl;
            }

            public String listID { get; set; }
            public String itemName { get; set; }
            public String imageUrl { get; set; }
        }

    }
}
