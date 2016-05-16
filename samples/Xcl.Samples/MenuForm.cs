using System;
using System.Base;
using System.Classes;
using System.UITypes;
using Xcl.StdCtrls;
using Xcl.Forms;
using Xcl.Samples;

namespace MenuForm
{
	public class TMenuForm: TForm
	{
		public TButton btnButtons;
		public TButton btnFontSizes;
		public TButton btnLabelAlignment;

		public TMenuForm (TComponent AOwner):base(AOwner)
		{
		}

		public override void Loaded()
		{
			btnButtons = TButton.Create (self);
			btnButtons.Parent = self;

			btnButtons.Top = 20;
			btnButtons.Left = 10;
			btnButtons.Height = 50;
			btnButtons.Width = Screen.Width - 20;
			btnButtons.Caption = "Buttons";
			btnButtons.OnClick += Button1Click;

			btnFontSizes = TButton.Create (self);
			btnFontSizes.Parent = self;

			btnFontSizes.Top = 80;
			btnFontSizes.Left = 10;
			btnFontSizes.Height = 50;
			btnFontSizes.Width = Screen.Width - 20;
			btnFontSizes.Caption = "Font Sizes";
			btnFontSizes.OnClick += BtnFontSizesClick;

			btnLabelAlignment = TButton.Create (self);
			btnLabelAlignment.Parent = self;

			btnLabelAlignment.Top = 150;
			btnLabelAlignment.Left = 10;
			btnLabelAlignment.Height = 50;
			btnLabelAlignment.Width = Screen.Width - 20;
			btnLabelAlignment.Caption = "Label Alignments";
			btnLabelAlignment.OnClick += BtnLabelAlignmentClick;
		}

		void BtnLabelAlignmentClick (object sender, EventArgs e)
		{
			App.LabelAlignment.Show ();
		}

		void BtnFontSizesClick (object sender, EventArgs e)
		{
			App.FontSizes.Show ();	
		}

		void Button1Click (object sender, EventArgs e)
		{
			App.ButtonSamples.Show ();
			
		}
	}
}
