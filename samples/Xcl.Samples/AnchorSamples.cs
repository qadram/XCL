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

namespace AnchorSamples
{
	public class TAnchorSamples: TSampleBaseForm
	{		
		public TButton btnRight;

		public TButton btnRightBottom;

		public TAnchorSamples (TComponent AOwner):base(AOwner)
		{
		}

		public override void Loaded()
		{
			base.Loaded ();
			btnRight = TButton.Create (self);
			btnRight.Parent = self;
			btnRight.Top = 100;
			btnRight.Left = 10;
			btnRight.Width = Screen.Width-20;
			btnRight.Height = 50;
			btnRight.Caption = "LeftTopRight-anchored Button";
			btnRight.Anchors= new TAnchors(TAnchors.akLeft,TAnchors.akTop,TAnchors.akRight);

			btnRightBottom = TButton.Create (self);
			btnRightBottom.Parent = self;
			btnRightBottom.Top = 170;
			btnRightBottom.Left = 10;
			btnRightBottom.Width = Screen.Width-20;
			btnRightBottom.Height = Screen.Height-340;
			btnRightBottom.Caption = "TopBottom-anchored Button";
			btnRightBottom.Anchors= new TAnchors(TAnchors.akTop,TAnchors.akRight);

		}
	}
}






