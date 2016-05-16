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
		public TButton btnLabelTest;

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
			btnFontSizes.OnClick += btnFontSizesClick;

			btnLabelTest = TButton.Create (self);
			btnLabelTest.Parent = self;

			btnLabelTest.Top = 150;
			btnLabelTest.Left = 10;
			btnLabelTest.Height = 50;
			btnLabelTest.Width = Screen.Width - 20;
			btnLabelTest.Caption = "Label Test";
			btnLabelTest.OnClick += btnLabelTestClick;
		}

		void btnLabelTestClick (object sender, EventArgs e)
		{
			App.LabelTest.Show ();
		}

		void btnFontSizesClick (object sender, EventArgs e)
		{
			App.FontSizes.Show ();	
		}

		void Button1Click (object sender, EventArgs e)
		{
			App.ButtonSamples.Show ();
			
		}
	}
}
