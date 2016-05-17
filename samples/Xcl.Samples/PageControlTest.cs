using System;
using System.Base;
using System.Classes;
using System.UITypes;
using Xcl.ComCtrls;
using Xcl.StdCtrls;
using Xcl.Forms;
using Xcl.Samples;

namespace PageControlTest
{
	public class TPageControlTest: TForm
	{
		public TPageControl pagecontrol;

		public TPageControlTest (TComponent AOwner):base(AOwner)
		{
		}

		public override void Loaded()
		{
			pagecontrol = TPageControl.Create (self);
		}
	}
}



