using System;
using Android.App;
using Android.Widget;
using Android.OS;

namespace MyFirstApp
{
	public class LoginPage: Activity
	{
		public LoginPage()
		{
			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.btnLogin);

			button.Click += delegate
			{
				EditText username = FindViewById<EditText>(Resource.Id.txtUsername);
				EditText password = FindViewById<EditText>(Resource.Id.txtPassword);
				TextView result = FindViewById<TextView>(Resource.Id.txtResult);
				result.Text = "Your username is " + username.Text + " and password is " + password.Text;
			};
		}
	}
}
