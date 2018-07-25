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
using SampleBaseForm;


namespace RESTSamples
{
	public class TRESTSamples : TSampleBaseForm
	{
		public TRESTClient RestClient;
		public TRESTRequest RestRequest;
		public TRESTResponse RestResponse;

		public TButton btnDefault;

		public TRESTSamples(TComponent AOwner) : base(AOwner)
		{
		}

		public override void Loaded()
		{
			base.Loaded();

			btnDefault = TButton.Create(self);
			btnDefault.Parent = self;

			btnDefault.Top = 60;
			btnDefault.Left = 10;
			btnDefault.Height = 50;
			btnDefault.Width = Screen.Width - 20;
			btnDefault.Caption = "Get Data";
			btnDefault.OnClick += Button1Click;

			RestClient = new TRESTClient(self);
			RestRequest = new TRESTRequest(self);
			//RestResponse = new TRESTResponse(self);

			RestRequest.Client = RestClient;
			RestClient.BaseURL = "http://www.songsterr.com/a/ra/";
			RestRequest.Resource = "songs.json";
			RestRequest.Params.AddItem("pattern", "Madonna");
			//RestRequest.Execute();
		}

		void Button1Click(object sender, EventArgs e)
		{
			RestRequest.Execute();
			var LContent = RestRequest.Response.Content;
		}
	}
}