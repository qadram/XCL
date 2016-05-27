using Xcl.Forms;
using MenuForm;
using ButtonSamples;
using FontSizeSamples;
using LabelSamples;
using EditSamples;
using TouchSamples;
using AlignSamples;
using AnchorSamples;

namespace Xcl.Samples
{
	public partial class App
	{
		public static TMenuForm MenuForm;
		public static TButtonSamples ButtonSamples;
		public static TFontSizeSamples FontSizeSamples;
		public static TLabelSamples LabelSamples;
		public static TEditSamples EditSamples;
		public static TTouchSamples TouchSamples;
		public static TAlignSamples AlignSamples;
		public static TAnchorSamples AnchorSamples;

		public static void Run(object param)
		{
			TApplication.Initialize (param);
			TApplication.CreateForm<TMenuForm> (ref MenuForm);
			TApplication.CreateForm<TButtonSamples> (ref ButtonSamples);
			TApplication.CreateForm<TFontSizeSamples> (ref FontSizeSamples);
			TApplication.CreateForm<TLabelSamples> (ref LabelSamples);
			TApplication.CreateForm<TEditSamples> (ref EditSamples);
			TApplication.CreateForm<TTouchSamples> (ref TouchSamples);
			TApplication.CreateForm<TAlignSamples> (ref AlignSamples);
			TApplication.CreateForm<TAnchorSamples> (ref AnchorSamples);
			TApplication.Run ();
		}
	}
}