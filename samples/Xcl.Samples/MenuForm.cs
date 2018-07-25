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
		public TButton btnListViewSamples;
		public TButton btnRestSamples;
		public TButton btnPanelSamples;

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
			CreateMenuItem ("Anchor Test", btnAnchorSamplesClick);
			CreateMenuItem ("ListView Test", btnListViewClick);
			CreateMenuItem("Rest Test", btnRestClick);
			CreateMenuItem("Panel Test", btnPanelSamplesClick);
		}

		void btnAnchorSamplesClick (object sender, EventArgs e)
		{
			App.AnchorSamples.Show ();
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

		void btnListViewClick(object sender, EventArgs e)
		{
			App.ListViewSamples.Show();

		}

		void btnRestClick(object sender, EventArgs e)
		{
			App.RestSamples.Show();
		}

		void btnPanelSamplesClick(object sender, EventArgs e)
		{
			App.PanelSamples.Show();
		}
	}
}
