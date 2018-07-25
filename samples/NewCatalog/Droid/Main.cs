using Android.App;
using Android.Widget;
using Android.OS;

using CatalogApp;

namespace Xcl.Samples.Droid
{
	[Activity(Label = "NewCatalog.Droid", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			App.Run(this);
		}
	}
}


