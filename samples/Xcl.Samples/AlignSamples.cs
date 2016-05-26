using System;
using System.Base;
using System.Classes;
using System.UITypes;
using Xcl.ComCtrls;
using Xcl.StdCtrls;
using Xcl.Forms;
using Xcl.Samples;
using Xcl.Controls;
using SampleBaseForm;

namespace AlignSamples
{
	public class TAlignSamples: TSampleBaseForm
	{		
		public TButton[] btnAlign;

		public TAlignSamples (TComponent AOwner):base(AOwner)
		{
		}

		private void SetupButton(TButton button)
		{
			button.Caption = button.Align.ToString ();
		}

		public override void Loaded()
		{
			base.Loaded ();

			btnAlign = new TButton[5];

			for (int i = 0; i <= 4; i++) {
				btnAlign [i] = TButton.Create (self);
				btnAlign [i].Parent = self;
				btnAlign [i].Top = 100;
				btnAlign [i].Height = 50;
				btnAlign [i].Align = (TAlign)(i+1);
				SetupButton (btnAlign [i]);
				btnAlign [i].OnClick += btnAlignClick;
			}
		}

		void btnAlignClick (object sender, EventArgs e)
		{
			(sender as TButton).Align++;
			if ((sender as TButton).Align == TAlign.alCustom) {
				(sender as TButton).Align = TAlign.alTop;
				(sender as TButton).Height = 50;
			}
			SetupButton (sender as TButton);
		}
	}
}





