using System;
using System.Base;
using System.Classes;
using System.UITypes;
using Xcl.StdCtrls;
using Xcl.Forms;
using Xcl.Samples;

namespace LabelAlignment
{
	public class TLabelAlignment: TForm
	{

		public TLabelAlignment (TComponent AOwner):base(AOwner)
		{
		}

		public override void Loaded()
		{
			for (int i = 0; i <= 2; i++) {
				TLabel label = TLabel.Create (self);
				label.Parent = self;
				label.Top = i * 35;
				label.Left = 10;
				label.Width = Screen.Width - 20;
				label.Alignment = (TAlignment)i;
				label.Name = label.Alignment.ToString ();
				label.Height = 30;


			}
		}
	}
}


