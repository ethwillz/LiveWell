using System;

using Xamarin.Forms;

namespace MyFirstApp
{
	public class App: Application
		{
		public App()
		{
			MainPage = new NavigationPage(new MainView());
		}
		}
}
 