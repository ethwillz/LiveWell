using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace LiveWell
{
    public partial class More : ContentPage
    {
        public More()
        {
            InitializeComponent();

            List<Page> pages = new List<Page>()
            {
                new Page("Property"),
                new Page("Maintenance")
            };

            otherPages.ItemsSource = pages;
            otherPages.RowHeight = 60;
        }

        public class Page
        {
            public Page(String page)
            {
                this.PageName = page;
            }

            public string PageName { get; set; }
        }
    }
}
