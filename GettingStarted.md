## Hello World
This is a sample Hello World, in which:
* A Button, an Edit and a Label are created, and put on the Form
* An event is attached to the Button, so, when clicked, the Label is set with the contents of the Edit
```
using System;
using System.Base;
using System.Classes;
using System.UITypes;
using Xcl.StdCtrls;
using Xcl.Forms;

namespace Unit1
{
	public class TForm1: TForm
	{
		public TButton Button1;
		public TEdit Edit1;
		public TLabel Label1;

		public TForm1 (TComponent AOwner):base(AOwner)
		{
		}

		public override void Loaded()
		{
			Button1 = TButton.Create (self);
			Edit1 = TEdit.Create (self);
			Label1 = TLabel.Create (self);

			Button1.Parent = self;
			Edit1.Parent = self;
			Label1.Parent = self;

			Button1.Top = 100;
			Button1.Left = 50;
			Button1.Height = 50;
			Button1.Color = TColor.clBlue;
			Button1.Caption = "Click here!!!";
			Button1.OnClick += Button1Click;

			Edit1.Left = 10;
			Edit1.Top = 40;
			Edit1.Width = 200;
			Edit1.Height = 40;
			Edit1.Text = "This is a test";	

			Label1.Left = 10;
			Label1.Top = 180;
			Label1.Width = 200;
			Label1.Height = 40;
			Label1.Text = "Label1";	

		}

		void Button1Click (object sender, EventArgs e)
		{
			Label1.Caption = Edit1.Text;
		}
	}
}
```
