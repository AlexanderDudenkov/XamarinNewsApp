using Android.OS;
using Xamarin.Forms;

[assembly: Dependency(typeof(NewsApp.view.DeviceInfo))]
namespace NewsApp.view
{
    public class DeviceInfo : IDeviceInfo
    {
        public string GetInfo()
        {
            return Build.VERSION.Sdk;
        }
    }
}
