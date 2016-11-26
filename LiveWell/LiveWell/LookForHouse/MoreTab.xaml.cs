using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWell
{
	public partial class MoreTab : ContentPage
	{
		public MoreTab()
		{
			InitializeComponent();

			#if __ANDROID__
			// Create a storage reference from our app
			StorageReference storageRef = storage.getReferenceFromUrl("gs://livewell-78cf1.appspot.com");
		
			// Create a reference
			StorageReference testImagesRef = storageRef.child("Keisuke/unnamed.png");
			testImagesRef.putFile();

			#endif

			#if __IOS__
			// iOS-specific code
			#endif
		}

		public void OnMainButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new Resident());
		}
		public void OnLogOutButtonClicked(object sender, EventArgs args)
		{
			LiveWell.Helpers.Settings.GeneralSettings = "";
			CurrentUser.type = 'N';
			Navigation.PushModalAsync(new FirstPage());
		}
	}
}