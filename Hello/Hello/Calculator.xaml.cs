using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Hello
{
    public partial class Calculator : ContentPage
    {
        public Calculator()
        {
            InitializeComponent();
        }

        public void C(Object sender, EventArgs e)
        {
            Edit.Text = Edit.Text.Substring(0, Edit.Text.Length-1);
        }

        public void AC(Object sender, EventArgs e)
        {
            Edit.Text = "";
        }

        public void Divide(Object sender, EventArgs e)
        {
            Edit.Text += "/";
        }

        public void Seven(Object sender, EventArgs e)
        {
            Edit.Text += "7";
        }

        public void Eight(Object sender, EventArgs e)
        {
            Edit.Text += "8";
        }

        public void Nine(Object sender, EventArgs e)
        {
            Edit.Text += "9";
        }

        public void Multiply(Object sender, EventArgs e)
        {
            Edit.Text += "*";
        }

        public void Four(Object sender, EventArgs e)
        {
            Edit.Text += "4";
        }

        public void Five(Object sender, EventArgs e)
        {
            Edit.Text += "5";
        }

        public void Six(Object sender, EventArgs e)
        {
            Edit.Text += "6";
        }

        public void Subtract(Object sender, EventArgs e)
        {
            Edit.Text += "-";
        }

        public void One(Object sender, EventArgs e)
        {
            Edit.Text += "1";
        }

        public void Two(Object sender, EventArgs e)
        {
            Edit.Text += "2";
        }

        public void Three(Object sender, EventArgs e)
        {
            Edit.Text += "3";
        }

        public void Add(Object sender, EventArgs e)
        {
            Edit.Text += "+";
        }

        public void Zero(Object sender, EventArgs e)
        {
            Edit.Text += "0";
        }

        public void Point(Object sender, EventArgs e)
        {
            Edit.Text += ".";
        }

        public void Equals(Object sender, EventArgs e)
        {
            String operation = Edit.Text;
            String[] end;
            if (operation.Contains("/"))
            {
                end = operation.Split('/');
                Edit.Text = (Convert.ToDouble(end[0]) / Convert.ToDouble(end[1])).ToString();
            }
            else if (operation.Contains("*"))
            {
                end = operation.Split('*');
                Edit.Text = (Convert.ToDouble(end[0]) * Convert.ToDouble(end[1])).ToString();
            }
            else if (operation.Contains("+"))
            {
                end = operation.Split('+');
                Edit.Text = (Convert.ToDouble(end[0]) + Convert.ToDouble(end[1])).ToString();
            }
            else if (operation.Contains("-"))
            {
                end = operation.Split('-');
                Edit.Text = (Convert.ToDouble(end[0]) - Convert.ToDouble(end[1])).ToString();
            }
            else
            {
                DisplayAlert("Error", "Please enter in an operator", "Okay", "Cancel");
            }
        }

    }
}
