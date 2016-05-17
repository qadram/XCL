using System;
using System.Base;
using System.Classes;
using System.UITypes;
using Xcl.ComCtrls;
using Xcl.StdCtrls;
using Xcl.Forms;
using Xcl.Samples;
using SampleBaseForm;

namespace EditSamples
{
	public class TEditSamples: TSampleBaseForm
	{
		public TEdit edit;
		public TLabel label;

		public TEditSamples (TComponent AOwner):base(AOwner)
		{
		}

		public override void Loaded()
		{
			base.Loaded ();

			edit = TEdit.Create (self);
			edit.Parent = self;
			edit.Left = 10;
			edit.Top = 50;
			edit.PlaceHolder = "Type something here";
			edit.Width = Screen.Width - 20;
			edit.Height = 40;
			edit.OnChange += editChange;


			label = TLabel.Create (self);
			label.Parent = self;
			label.Left = 10;
			label.Top = 100;
			label.Width = Screen.Width - 20;
			label.Height = 40;
		}

		void editChange (object sender, EventArgs e)
		{
			label.Caption = edit.Text;
		}
	}
}



