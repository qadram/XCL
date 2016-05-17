using System;
using System.Base;
using System.Classes;
using System.UITypes;
using Xcl.StdCtrls;
using Xcl.Forms;
using Xcl.Samples;
using SampleBaseForm;

namespace LabelSamples
{
	public class TLabelSamples: TSampleBaseForm
	{

		public TLabelSamples (TComponent AOwner):base(AOwner)
		{
		}

		public override void Loaded()
		{
			base.Loaded ();

			int alignment = 0;
			for (int i = 0; i <= 16; i++) {
				TLabel label = TLabel.Create (self);
				label.Parent = self;
				label.Top = (i * 30)+45;
				label.Left = 10;
				label.Color = new TColor((TColors)(16-i));
				label.Font.Color = new TColor((TColors)i);
				label.Width = Screen.Width - 20;
				label.Alignment = (TAlignment)alignment;
				alignment++;
				if (alignment >= 3)
					alignment = 0;
				label.Caption = label.Alignment.ToString ()+" "+((TColors)i).ToString();
				label.Height = 30;


			}
		}
	}
}


