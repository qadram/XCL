using System;
using System.Base;
using System.Classes;
using System.UITypes;
using Xcl.StdCtrls;
using Xcl.Controls;
using Xcl.Forms;
using Xcl.Samples;

namespace MenuForm
{
	public class TMenuForm: TForm
	{
		public TButton btnButtons;
		public TButton btnFontSizes;
		public TButton btnLabelTest;
		public TButton btnEditSamples;
		public TButton btnTouchSamples;
		public TButton btnAlignSamples;

		public TMenuForm (TComponent AOwner):base(AOwner)
		{
		}

		public TButton CreateMenuItem(string Caption, TNotifyEvent Event)
		{
			TButton result = TButton.Create (self);

			result.Parent = self;
			result.Height = 50;
			result.Top = Screen.Height;
			result.Align = TAlign.alTop;
			result.Caption = Caption;
			result.OnClick += Event;

			return(result);
		}

		public override void Loaded()
		{
			CreateMenuItem ("Buttons", btnButtonsClick);
			CreateMenuItem ("Font Sizes", btnFontSizesClick);
			CreateMenuItem ("Label Test", btnLabelTestClick);
			CreateMenuItem ("Edit Test", btnEditSamplesClick);
			CreateMenuItem ("Touch Test", btnTouchSamplesClick);
    		CreateMenuItem ("Align Test", btnAlignSamplesClick);
		}

		void btnAlignSamplesClick (object sender, EventArgs e)
		{
			App.AlignSamples.Show ();
		}


		void btnTouchSamplesClick (object sender, EventArgs e)
		{
			App.TouchSamples.Show ();
		}

		void btnEditSamplesClick (object sender, EventArgs e)
		{
			App.EditSamples.Show ();
		}

		void btnLabelTestClick (object sender, EventArgs e)
		{
			App.LabelSamples.Show ();
		}

		void btnFontSizesClick (object sender, EventArgs e)
		{
			App.FontSizeSamples.Show ();	
		}

		void btnButtonsClick (object sender, EventArgs e)
		{
			App.ButtonSamples.Show ();
			
		}
	}
}
