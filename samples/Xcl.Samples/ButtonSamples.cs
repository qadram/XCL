﻿using System;
using System.Base;
using System.Classes;
using System.UITypes;
using Xcl.StdCtrls;
using Xcl.Forms;
using SampleBaseForm;

namespace ButtonSamples
{
	public class TButtonSamples: TSampleBaseForm
	{
		public TButton btnDefault;

		public TButton btnBkColors;
		public TButton btnFontColors;

		public TButton btnEvents;

		public TButtonSamples (TComponent AOwner):base(AOwner)
		{
		}

		public override void Loaded()
		{
			base.Loaded ();

			btnDefault = TButton.Create (self);
			btnDefault.Parent = self;

			btnDefault.Top = 60;
			btnDefault.Left = 10;
			btnDefault.Height = 50;
			btnDefault.Width = Screen.Width - 20;
			btnDefault.Caption = "Default Button";

			btnBkColors = TButton.Create (self);
			btnBkColors.Parent = self;

			btnBkColors.Top = 130;
			btnBkColors.Left = 10;
			btnBkColors.Height = 50;
			btnBkColors.Width = Screen.Width - 20;
			btnBkColors.Color = TColor.clBlue;
			btnBkColors.Caption = "Button with Background Color";	

			btnFontColors = TButton.Create (self);
			btnFontColors.Parent = self;

			btnFontColors.Top = 210;
			btnFontColors.Left = 10;
			btnFontColors.Height = 50;
			btnFontColors.Width = Screen.Width - 20;
			btnFontColors.Font.Color = TColor.clRed;
			btnFontColors.Caption = "Button with Font Color";		

			btnEvents = TButton.Create (self);
			btnEvents.Parent = self;

			btnEvents.Top = 290;
			btnEvents.Left = 10;
			btnEvents.Height = 50;
			btnEvents.Width = Screen.Width - 20;
			btnEvents.Caption = "Button with Events";		
			btnEvents.OnClick += Button1Click;
			btnEvents.OnMouseDown += Button1MouseDown;
		}

		void Button1MouseDown (object sender, Xcl.Controls.TMouseEventArgs e)
		{
			(sender as TButton).Caption = e.X.ToString();
		}

		void Button1Click (object sender, EventArgs e)
		{
			(sender as TButton).Caption = "OnClick!";
		}
	}
}