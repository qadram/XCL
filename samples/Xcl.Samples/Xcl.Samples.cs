using Xcl.Forms;
using MenuForm;
using ButtonSamples;
using FontSizeSamples;
using LabelSamples;
using EditSamples;
using TouchSamples;
using AlignSamples;
using AnchorSamples;
using ListViewSamples;
using RESTSamples;
using PanelSamples;

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
		public static TListViewSamples ListViewSamples;
		public static TRESTSamples RestSamples;
		public static TPanelSamples PanelSamples;

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

            //Commented, as it's not working properly, at least on this revision, will check after update
			//TApplication.CreateForm<TListViewSamples> (ref ListViewSamples);

			TApplication.CreateForm<TRESTSamples>(ref RestSamples);
			TApplication.CreateForm<TPanelSamples>(ref PanelSamples);
            TApplication.Run ();
		}
	}
}