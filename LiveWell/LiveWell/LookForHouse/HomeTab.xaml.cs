using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWell
{
	public partial class HomeTab : ContentPage
	{
		public HomeTab()
		{
			MapTab map = new MapTab();
			InitializeComponent();
			title.Text = "Explore " + map.getFilterResult() + " apartments";
		}
	}
}
