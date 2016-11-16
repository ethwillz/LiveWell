using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using LiveWell.Droid;

[Activity(Label = "LiveWell", MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Splash",
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