
using Xamarin.Forms;

namespace LiveWell
{
    public class App : Application
    {
        public App()
        {
            var main = new NavigationPage(new FirstPage());
            main.BarBackgroundColor = Color.White;
            main.BarTextColor = Color.Black;
			MainPage = main;
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
