using System;
using System.Base;
using System.Classes;
using System.UITypes;
using Xcl.StdCtrls;
using Xcl.Forms;
using Xcl.ComCtrls;
using Xcl.Controls;
using Xcl.Graphics;
using REST;
using Xcl.Samples;
using Xcl.ExtCtrls;
using SampleBaseForm;


namespace PanelSamples
{
	public class TPanelSamples : TSampleBaseForm
	{
		public TPanel pnPanel;
		public TButton btnDefault;
		public TButton btnAnother;

		public TPanelSamples(TComponent AOwner) : base(AOwner)
		{
		}

		public override void Loaded()
		{
			base.Loaded();

			pnPanel = TPanel.Create(self);
			pnPanel.Parent = self;
			pnPanel.Top = 60;
			pnPanel.Left = 10;
			pnPanel.Height = 90;
			pnPanel.Width = Screen.Width - 50;

			btnDefault = TButton.Create(self);
			btnDefault.Parent = pnPanel;
			btnDefault.Top = 20;
			btnDefault.Left = 10;
			btnDefault.Height = 40;
			btnDefault.Width = 100;
			btnDefault.Caption = "Get Data";
			btnDefault.OnClick += Button1Click;
			btnDefault.Align = TAlign.alBottom;

			btnAnother = TButton.Create(self);
			btnAnother.Parent = pnPanel;
			btnAnother.Top = 70;
			btnAnother.Left = Screen.Width - 90;
			btnAnother.Height = 40;
			btnAnother.Width = 130;
			btnAnother.Caption = "Get Data 2";
			btnAnother.OnClick += Button1Click;
			btnAnother.Align = TAlign.alTop;
		}

		void Button1Click(object sender, EventArgs e)
		{
			
		}
	}
}