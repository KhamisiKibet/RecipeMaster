using Android.Widget;
using RecipeMaster.Services;

namespace RecipeMaster.Platforms;

public class Toaster : Services.Toast
{
    public void MakeToast(string message)
    {
        Android.Widget.Toast.MakeText(Microsoft.Maui.ApplicationModel.Platform.AppContext, message, ToastLength.Long).Show();
    }
}
