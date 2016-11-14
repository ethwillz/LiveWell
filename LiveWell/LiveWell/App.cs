
using Xamarin.Forms;

namespace LiveWell
{
    public class App : Application
    {
        public App()
        {
			MainPage = new FirstPage();

            MainPage.SetValue(NavigationPage.BarBackgroundColorProperty, Color.Black);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
