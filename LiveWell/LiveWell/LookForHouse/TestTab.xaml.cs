using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Xamarin.Forms;

namespace LiveWell
{
	public partial class TestTab : ContentPage
	{
		public TestTab()
		{
			InitializeComponent();

			takePhoto.Clicked += async (sender, args) =>
			{

				if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
				{
					DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
					return;
				}

				var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
				{

					Directory = "Sample",
					Name = "test.jpg"
				});

				if (file == null)
					return;

				DisplayAlert("File Location", file.Path, "OK");

				image.Source = ImageSource.FromStream(() =>
		  {
				  var stream = file.GetStream();
				  file.Dispose();
				  return stream;
			  });
			};

			pickPhoto.Clicked += async (sender, args) =>
			{
				if (!CrossMedia.Current.IsPickPhotoSupported)
				{
					DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
					return;
				}
				var file = await CrossMedia.Current.PickPhotoAsync();


				if (file == null)
					return;

				image.Source = ImageSource.FromStream(() =>
		  {
				  var stream = file.GetStream();
				  file.Dispose();
				  return stream;
			  });
			};
		}
	}
}
