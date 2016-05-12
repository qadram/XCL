using System;
using System.Base;
using System.Classes;
using System.UITypes;
using Xcl.StdCtrls;
using Xcl.Forms;

namespace MenuForm
{
	public class TMenuForm: TForm
	{
		public TButton btnButtons;

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
			btnButtons.Width = _.Screen.Width - 20;
			btnButtons.Caption = "Buttons";
			btnButtons.OnClick += Button1Click;
		}

		void Button1Click (object sender, EventArgs e)
		{
			
		}
	}
}
