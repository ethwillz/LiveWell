using System;

using Xamarin.Forms;

namespace LiveWell
{
    public partial class Maintenance : ContentPage
    {
        public Maintenance()
        {
            InitializeComponent();
        }

        async void submitClick (object sender, EventArgs e)
        {
            DatabasePOST conn = new DatabasePOST();
            await conn.postMaintenance("1", "1", null, summary.Text, explanation.Text);
            summary.Text = "";
            explanation.Text = "";
            await DisplayAlert("Success", "Maintenance request submitted", "OK");
        }
    }
}
