using Xcl.Forms;
using MenuForm;
using ButtonSamples;
using FontSizeSamples;
using LabelSamples;
using PageControlTest;

namespace Xcl.Samples
{
	public partial class App
	{
		public static TMenuForm MenuForm;
		public static TButtonSamples ButtonSamples;
		public static TFontSizeSamples FontSizeSamples;
		public static TLabelSamples LabelSamples;
		public static TPageControlTest PageControlTest;

		public static void Run(object param)
		{
			TApplication.Initialize (param);
			TApplication.CreateForm<TMenuForm> (ref MenuForm);
			TApplication.CreateForm<TButtonSamples> (ref ButtonSamples);
			TApplication.CreateForm<TFontSizeSamples> (ref FontSizeSamples);
			TApplication.CreateForm<TLabelSamples> (ref LabelSamples);
			TApplication.CreateForm<TPageControlTest> (ref PageControlTest);
			TApplication.Run ();
		}
	}
}