using System;

using Xamarin.Forms;

namespace LiveWellNew
{
	public partial class Maintenance : ContentPage
	{
		public Maintenance()
		{
			InitializeComponent();
		}

		async void submitClick(object sender, EventArgs e)
		{
			DatabasePOST conn = new DatabasePOST();
			await conn.postMaintenance(CurrentUser.ID, summary.Text, explanation.Text);
			summary.Text = "";
			explanation.Text = "";
			await DisplayAlert("Success", "Maintenance request submitted", "OK");
		}
	}
}