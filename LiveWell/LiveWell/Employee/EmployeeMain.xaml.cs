using Xamarin.Forms;

namespace LiveWell
{
    public partial class EmployeeMain : TabbedPage
    {
        public EmployeeMain()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
