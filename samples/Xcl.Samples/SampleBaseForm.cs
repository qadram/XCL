using System;
using System.Base;
using System.Classes;
using System.UITypes;
using Xcl.StdCtrls;
using Xcl.Forms;
using Xcl.Samples;
using Xcl.ComCtrls;

namespace SampleBaseForm
{
	public class TSampleBaseForm: TForm
	{
		public TToolbar toolbar;

		public TSampleBaseForm (TComponent AOwner):base(AOwner)
		{
		}

		public override void Loaded()
		{
			toolbar = TToolbar.Create (self);

			toolbar.Parent = self;
			toolbar.Width = Screen.Width;
			toolbar.Height = 40;

			var button = TButton.Create (self);
			button.Caption = "< Back";
			button.Width = 100;
			button.Height = 40;
			button.Parent = toolbar;
			button.OnClick += btnBackClick;

			/*
			TToolButton button = new TToolButton (self);
			button.Toolbar = toolbar;
			button.OnClick+= btnBackClick;
			button.Parent = toolbar;
			*/
		}

		void btnBackClick (object sender, EventArgs e)
		{
			Close ();
		}
	}
}


