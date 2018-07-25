using System;
using System.Base;
using System.Classes;
using System.UITypes;
using Xcl.StdCtrls;
using Xcl.Forms;
using Xcl.ExtCtrls;
using Xcl.Login.Sample;

#if __ANDROID__
using Android.Widget;
using Android.Views;
using Android.Graphics;
#endif

namespace EntryForm
{
	public class TEntryForm: TForm
	{
		public TButton btnLogin;
		public TButton btnSignup;
		public TImage imBackground;
		public TLabel lbSlogan;
		public TLabel lbOutside;

		public TEntryForm (TComponent AOwner):base(AOwner)
		{
		}

		public override void Loaded()
		{
			imBackground = TImage.Create (self);
			imBackground.Parent = self;
			imBackground.Width = Screen.Width;
			imBackground.Height = Screen.Height;
			imBackground.Picture.LoadFromResource ("jaguar.jpg");

			btnLogin = TButton.Create (self);
			btnLogin.Parent = self;
			btnLogin.Left = 10;
			btnLogin.Color = TColor.clNone;
			btnLogin.Top = Screen.Height - 100;
			btnLogin.Width = (Screen.Width / 2) - 20;
			btnLogin.Font.Color = TColor.clWhite;
			btnLogin.Height = 60;
			btnLogin.Caption = "Log In";
			btnLogin.OnClick += btnLoginClick;

			btnSignup = TButton.Create (self);
			btnSignup.Parent = self;
			btnSignup.Color = TColor.clNone;
			btnSignup.Top = btnLogin.Top;
			btnSignup.Width = btnLogin.Width;
			btnSignup.Height = btnLogin.Height;
			btnSignup.Left = Screen.Width - btnSignup.Width - 10;
			btnSignup.Font.Color = TColor.clWhite;
			btnSignup.Caption = "Sign Up";

			lbSlogan = TLabel.Create (self);
			lbSlogan.Caption = "CAR RENTAL\nTHE WAY IT SHOULD BE!";
			lbSlogan.Font.Size = 20;
			lbSlogan.Font.Name = "GillSans";
			lbSlogan.Font.Color = TColor.clWhite;
			lbSlogan.Alignment = TAlignment.taCenter;
			lbSlogan.Parent = self;
			lbSlogan.Top = btnLogin.Top - 90;
			lbSlogan.Left = 10;
			lbSlogan.Width = Screen.Width - 20;
			lbSlogan.Height = 150;

			lbOutside = TLabel.Create (self);
			lbOutside.Caption = "I booked outside of Silvercar";
			lbOutside.Font.Size = 10;
			lbOutside.Font.Color = TColor.clWhite;
			lbOutside.Alignment = TAlignment.taCenter;
			lbOutside.Parent = self;
			lbOutside.Top = Screen.Height - 40;
			lbOutside.Left = 10;
			lbOutside.Width = Screen.Width - 20;
			lbOutside.Height = 20;

		}

		void btnLoginClick (object sender, EventArgs e)
		{
			App.LoginForm.Show ();
		}
	}
}


