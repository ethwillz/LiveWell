using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWell
{
    public partial class EmployeeHistoryPage : ContentPage
    {
        public EmployeeHistoryPage()
        {
            InitializeComponent();
        }

        async void fine(Object o, EventArgs e)
        {
            DatabaseGET conn2 = new DatabaseGET();
            List<ConnectHelpers.EmployeeInfo> employee = await conn2.getEmployeeInfo(Convert.ToInt32(CurrentUser.ID));
            String[] types = { "Noise violation", "Late rent", "Stolen/damaged property", "Other" };
            DatabasePOST conn = new DatabasePOST();
            await conn.postFine(employee[0].buildingID, types[type.SelectedIndex], unit.Text, amount.Text);
            await DisplayAlert("Success", "Fine issued", "OK");
            unit.Text = "";
            amount.Text = "";
        }
    }
}