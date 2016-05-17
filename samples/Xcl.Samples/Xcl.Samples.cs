using Xcl.Forms;
using MenuForm;
using ButtonSamples;
using FontSizeSamples;
using LabelSamples;
using EditSamples;

namespace Xcl.Samples
{
	public partial class App
	{
		public static TMenuForm MenuForm;
		public static TButtonSamples ButtonSamples;
		public static TFontSizeSamples FontSizeSamples;
		public static TLabelSamples LabelSamples;
		public static TEditSamples EditSamples;

		public static void Run(object param)
		{
			TApplication.Initialize (param);
			TApplication.CreateForm<TMenuForm> (ref MenuForm);
			TApplication.CreateForm<TButtonSamples> (ref ButtonSamples);
			TApplication.CreateForm<TFontSizeSamples> (ref FontSizeSamples);
			TApplication.CreateForm<TLabelSamples> (ref LabelSamples);
			TApplication.CreateForm<TEditSamples> (ref EditSamples);
			TApplication.Run ();
		}
	}
}