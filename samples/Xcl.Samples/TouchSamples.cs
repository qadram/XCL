using System;
using System.Base;
using System.Classes;
using System.UITypes;
using Xcl.ComCtrls;
using Xcl.StdCtrls;
using Xcl.Forms;
using Xcl.Samples;
using SampleBaseForm;

namespace TouchSamples
{
	public class TTouchSamples: TSampleBaseForm
	{
		public TButton btnTouch;
		public TLabel lbMessage;

		public TTouchSamples (TComponent AOwner):base(AOwner)
		{
		}

		public void Message(string Msg)
		{
			lbMessage.Caption = Msg;
		}

		public override void Loaded()
		{
			base.Loaded ();

			btnTouch = TButton.Create (self);
			btnTouch.Parent = self;
			btnTouch.Left = 100;
			btnTouch.Top = 100;
			btnTouch.Width = 100;
			btnTouch.Caption = "Touch me!";

			lbMessage = TLabel.Create (self);
			lbMessage.Parent = self;
			lbMessage.Left = 10;
			lbMessage.Top = 180;
			lbMessage.Height = 50;
			lbMessage.Width = Screen.Width - 20;

			btnTouch.OnTouchDown += btnTouchTouchDown;
			btnTouch.OnTouchDownRepeat += btnTouchTouchDownRepeat;
			btnTouch.OnTouchDragEnter += btnTouchTouchDragEnter;
			btnTouch.OnTouchDragExit += btnTouchTouchDragExit;
			btnTouch.OnTouchDragInside += btnTouchTouchDragInside;
			btnTouch.OnTouchDragOutside += btnTouchTouchDragOutside;
			btnTouch.OnTouchUpInside += btnTouchTouchUpInside;
			btnTouch.OnTouchUpOutside += btnTouchTouchUpOutside;
		}

		void btnTouchTouchDragEnter (object sender, EventArgs e)
		{
			Message ("btnTouchTouchDragEnter");			
		}
		void btnTouchTouchDragExit (object sender, EventArgs e)
		{
			Message ("btnTouchTouchDragExit");			
		}
		void btnTouchTouchDragInside (object sender, EventArgs e)
		{
			Message ("btnTouchTouchDragInside");			
		}
		void btnTouchTouchUpInside (object sender, EventArgs e)
		{
			Message ("btnTouchTouchUpInside");			
		}
		void btnTouchTouchDragOutside (object sender, EventArgs e)
		{
			Message ("btnTouchTouchDragOutside");			
		}
		void btnTouchTouchUpOutside (object sender, EventArgs e)
		{
			Message ("btnTouchTouchUpOutside");			
		}

		void btnTouchTouchDownRepeat (object sender, EventArgs e)
		{
			Message ("btnTouchTouchDownRepeat");			
		}

		void btnTouchTouchDown (object sender, EventArgs e)
		{
			Message ("btnTouchTouchDown");
		}

	}
}




