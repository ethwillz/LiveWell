using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace EmployeeTest
{
	public class CreateAccount : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			Button backButton = FindViewById<Button>(Resource.Id.Back);
			backButton.Click += delegate
			{
				SetContentView(Resource.Layout.Main);
			};
		}
	}
}

