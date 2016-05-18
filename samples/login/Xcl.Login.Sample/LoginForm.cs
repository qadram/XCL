using System;
using System.Base;
using System.Classes;
using System.UITypes;
using Xcl.StdCtrls;
using Xcl.Forms;
using Xcl.ExtCtrls;

namespace LoginForm
{
	public class TLoginForm: TForm
	{
		public TImage imLogo;
		public TButton btnLogin;
		public TEdit edEmail;
		public TEdit edPassword;
		public TLabel lbForgot;
		public TLabel lbOutside;
		public TLabel lbError;

		public TLoginForm (TComponent AOwner):base(AOwner)
		{
		}

		public override void Loaded()
		{
			Color = TColor.clBlack;
			imLogo = TImage.Create (self);
			imLogo.Parent = self;
			imLogo.Top = 100;
			imLogo.Width = Screen.Width-80;
			imLogo.Height = 70;
			imLogo.Left = 40;
			imLogo.Picture.LoadFromResource ("logo.png");

			edEmail = TEdit.Create (self);
			edEmail.IsEmail = true;
			edEmail.PlaceHolder = "E-mail";
			edEmail.Left = 20;
			edEmail.Font.Color = TColor.clWhite;
			edEmail.Width = Screen.Width - 40;
			edEmail.Top = imLogo.Top + imLogo.Height + 50;
			edEmail.Parent = self;
			edEmail.OnChange += editsChange;

			edPassword = TEdit.Create (self);
			edPassword.IsPassword = true;
			edPassword.PlaceHolder = "Password";
			edPassword.Left = edEmail.Left;
			edPassword.Width = edEmail.Width;
			edPassword.Font.Color = TColor.clWhite;
			edPassword.Top = edEmail.Top+50;
			edPassword.Parent = self;
			edPassword.OnChange += editsChange;

			btnLogin = TButton.Create (self);
			btnLogin.Parent = self;
			btnLogin.Left = edPassword.Left;
			btnLogin.Width = edPassword.Width;
			btnLogin.Top = edPassword.Top + 50;
			btnLogin.Caption = "Log In";
			btnLogin.Height = 40;
			btnLogin.Enabled = false;
			btnLogin.OnClick+= btnLoginClick;

			lbForgot = TLabel.Create (self);
			lbForgot.Parent = self;
			lbForgot.Left = 10;
			lbForgot.Height = 40;
			lbForgot.Width = Screen.Width - 20;
			lbForgot.Top = btnLogin.Top + btnLogin.Height + 20;
			lbForgot.Alignment = TAlignment.taCenter;
			lbForgot.Caption = "Forgot your password?";
			lbForgot.Font.Color = TColor.clLtGray;
			lbForgot.Font.Size = 14;

			lbOutside = TLabel.Create (self);
			lbOutside.Parent = self;
			lbOutside.Left = 10;
			lbOutside.Height = 40;
			lbOutside.Width = Screen.Width - 20;
			lbOutside.Top = lbForgot.Top + lbForgot.Height + 20;
			lbOutside.Alignment = TAlignment.taCenter;
			lbOutside.Caption = "I booked outside of Silvercar";
			lbOutside.Font.Color = TColor.clLtGray;
			lbOutside.Font.Size = 14;

			lbError = TLabel.Create (self);
			lbError.Parent = self;
			lbError.Left = 0;
			lbError.Height = 40;
			lbError.Width = Screen.Width;
			lbError.Top = 0;
			lbError.Alignment = TAlignment.taLeftJustify;
			lbError.Layout = TTextLayout.tlCenter;
			lbError.Caption = "  Invalid email or password";
			lbError.Font.Color = TColor.clWhite;
			lbError.Color = TColor.clRed;
			lbError.Font.Size = 16;

			editsChange (null, null);
		}

		void btnLoginClick (object sender, EventArgs e)
		{
			lbError.Visible = true;
		}

		void editsChange (object sender, EventArgs e)
		{
			lbError.Visible = false;
			btnLogin.Enabled = ((edEmail.Text != "") && (edPassword.Text != ""));
			if (btnLogin.Enabled) {
				btnLogin.Color = TColor.RGB (0x4f, 0xad, 0xd7);
				btnLogin.Font.Color = TColor.clWhite;
			} else {
				btnLogin.Font.Color = TColor.clLtGray;
				btnLogin.Color = TColor.clDkGray;
			}
			
		}
	}
}

