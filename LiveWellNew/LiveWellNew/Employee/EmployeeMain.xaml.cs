using Xamarin.Forms;

namespace LiveWellNew
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