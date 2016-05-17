using System;
using System.Base;
using System.Classes;
using System.UITypes;
using Xcl.StdCtrls;
using Xcl.Forms;
using Xcl.Samples;
using SampleBaseForm;

namespace FontSizeSamples
{
	public class TFontSizeSamples: TSampleBaseForm
	{

		public TFontSizeSamples (TComponent AOwner):base(AOwner)
		{
		}

		public override void Loaded()
		{
			base.Loaded ();

			for (int i = 0; i <= 12; i++) {
				TLabel label = TLabel.Create (self);
				label.Parent = self;
				label.Top = (i * 35)+45;
				label.Left = 10;
				label.Width = Screen.Width - 20;
				label.Height = 30;
				label.Font.Size = i + 10;

				label.Caption = String.Format ("{0}", label.Font.Size);
			}
		}
	}
}

