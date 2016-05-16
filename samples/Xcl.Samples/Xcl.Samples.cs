using Xcl.Forms;
using MenuForm;
using ButtonSamples;
using FontSizes;
using LabelAlignment;

namespace Xcl.Samples
{
	public partial class App
	{
		public static TMenuForm MenuForm;
		public static TButtonSamples ButtonSamples;
		public static TFontSizes FontSizes;
		public static TLabelAlignment LabelAlignment;

		public static void Run(object param)
		{
			TApplication.Initialize (param);
			TApplication.CreateForm<TMenuForm> (ref MenuForm);
			TApplication.CreateForm<TButtonSamples> (ref ButtonSamples);
			TApplication.CreateForm<TFontSizes> (ref FontSizes);
			TApplication.CreateForm<TLabelAlignment> (ref LabelAlignment);
			TApplication.Run ();
		}
	}
}