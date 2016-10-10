using System;

namespace LiveWell
{
	class ConnectHelpers
	{

		public class Notification
		{
			public Notification(String notificationID, String residentID, String type, String amount, String sender, String details)
			{
				this.notificationID = notificationID;
				this.residentID = residentID;
				this.type = type;
				this.amount = amount;
				this.sender = sender;
				this.details = details;
			}

			public String notificationID { get; set; }
			public String residentID { get; set; }
			public String type { get; set; }
			public String amount { get; set; }
			public String sender { get; set; }
			public String details { get; set; }
		}

		public class Address
		{
			public Address(String buildingID, String address)
			{
				this.buildingID = buildingID;
				this.address = address;
			}

			public String buildingID { get; set; }
			public String address { get; set; }
		}
	}
}

