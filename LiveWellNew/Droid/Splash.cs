﻿using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using LiveWellNew.Droid;

[Activity(Label = "LiveWellNew", MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Splash",
	ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
public class Splash : Activity
{
	protected override void OnCreate(Bundle bundle)
	{
		base.OnCreate(bundle);

		var intent = new Intent(this, typeof(MainActivity));
		StartActivity(intent);
		Finish();
	}
}