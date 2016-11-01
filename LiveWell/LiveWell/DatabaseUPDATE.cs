using ModernHttpClient;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LiveWell
{
    class DatabaseUPDATE
    {
        public async Task updateBalances(Boolean roommates, Boolean building, String residentID)
        {
            var postPayment = new HttpClient(new NativeMessageHandler());
            postPayment.BaseAddress = new Uri("http://proj-309-la-04.cs.iastate.edu/updateBalances.php");

            String pay;
            if (roommates && building)
                pay = "both";
            else if (roommates)
                pay = "roommates";
            else
                pay = "building";

            var content = new StringContent("", Encoding.UTF8, "application/json");

            HttpResponseMessage gotNotifications = await postPayment.PostAsync(new Uri("http://proj-309-la-04.cs.iastate.edu/updateBalances.php?paymentType=" + pay + "&residentID=" + residentID), content);
        }
    }
}
