using Android.App;
using Android.Widget;
using Android.OS;

using System.Base;
using Xcl.Forms;
using Xcl.Samples;
using MenuForm;

namespace Xcl.Samples.Droid
{
	[Activity (Label = "Xcl.Samples", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			_.CreateApplication<App> ();
			TApplication.Initialize (this);
			TApplication.CreateForms ();
			TApplication.Run ();
		}
	}
}


