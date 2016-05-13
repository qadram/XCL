using System;
using System.Base;
using System.Classes;
using System.UITypes;
using Xcl.StdCtrls;
using Xcl.Forms;

namespace ButtonSamples
{
	public class TButtonSamples: TForm
	{
		public TButton btnDefault;

		public TButton btnColors;

		public TButtonSamples (TComponent AOwner):base(AOwner)
		{
		}

		public override void Loaded()
		{
			btnDefault = TButton.Create (self);
			btnDefault.Parent = self;

			btnDefault.Top = 20;
			btnDefault.Left = 10;
			btnDefault.Height = 50;
			btnDefault.Width = Screen.Width - 20;
			btnDefault.Caption = "Default Button";

			btnColors = TButton.Create (self);
			btnColors.Parent = self;

			btnColors.Top = 90;
			btnColors.Left = 10;
			btnColors.Height = 50;
			btnColors.Width = Screen.Width - 20;
			btnColors.Color = TColor.clBlue;
			btnColors.Font.Color = TColor.clRed;
			btnColors.Caption = "Button with Colors";		
		}

		void Button1Click (object sender, EventArgs e)
		{

		}
	}
}

