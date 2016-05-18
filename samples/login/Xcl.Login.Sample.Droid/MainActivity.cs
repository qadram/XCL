using Android.App;
using Android.Widget;
using Android.OS;
using Xcl.Login.Sample;

namespace Xcl.Login.Sample.Droid
{
	[Activity (Label = "Xcl.Login.Sample", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			App.Run (this);

		}
	}
}


