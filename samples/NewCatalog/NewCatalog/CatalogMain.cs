using System;
using System.Base;
using System.Classes;
using System.UITypes;
using Xcl.StdCtrls;
using Xcl.Controls;
using Xcl.ComCtrls;
using Xcl.Graphics;
using Xcl.Forms;
using REST;
using System.Json;
using System.Generics.Collections;
using System.Security.Policy;
using System.Text;
using System.IO;

namespace CatalogMain
{
	public class TMainCatalog : TForm
	{
		public TListView lvData;
		public TImageList imImages;

		private TList<TProduct> FList;

		public TMainCatalog(TComponent AOwner) : base(AOwner)
		{
		}

		public void CreateComponents()
		{
			FList = new TList<TProduct>();

			imImages = new TImageList(self);

			lvData = new TListView(self);
			lvData.Parent = self;
			lvData.Align = TAlign.alClient;
			lvData.Color = TColor.clSilver;
			lvData.Font.Size = 7;

            lvData.ViewStyle = TViewStyle.vsIcon;

			lvData.LargeImages = imImages;
			lvData.OnSelectItem += lvDataItemClick;
		}

		public override void Loaded()
		{
			CreateComponents();
			var LJSONData = LoadData("http://www.picandoteclas.com/", "products.json");
            ProcessMainData(LJSONData);
			CheckImages();
			FlushData();
		}

		private string LoadData(string ABaseURL, string AResource)
		{
			var RestClient = new TRESTClient(self);
			var RestRequest = new TRESTRequest(self);

			RestRequest.Client = RestClient;
			RestClient.BaseURL = ABaseURL;
			RestRequest.Resource = AResource;
			RestRequest.Execute();
			return RestRequest.Response.Content;

		}

		private void ProcessMainData(string AJSONData)
		{
            var json = JsonValue.Parse(AJSONData);

			foreach (var dataItem in json["products"])
			{
				var LProduct = new TProduct();
				var LObject = (dataItem as JsonObject);
				LProduct.ID = LObject["id"];
				LProduct.ImageURL = LObject["image"];
				LProduct.Title = LObject["title"];
				FList.Add(LProduct);
			}
		}

		private void CheckImages()
		{
			string LExt;
			foreach (var LItem in FList)
			{
				if (LItem.ImageURL != "")
				{
					var LMD5 = Hash.CreateMD5(Encoding.UTF8.GetBytes(LItem.ImageURL));
					if (LItem.ImageURL.IndexOf("http", StringComparison.CurrentCulture) < 0)
					{
						LExt = Path.GetExtension(LItem.ImageURL);
					}
					else
					{
						Uri LURI = new Uri(LItem.ImageURL);
						LExt = Path.GetExtension(LURI.AbsolutePath);
					}
					var LStr = BitConverter.ToString(LMD5.MD5).Replace("-", "") + LExt;
					string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

					string LPath = Path.Combine(documentsPath, LStr);
					if (!File.Exists(LPath))
					{
						//var LBytes = TImageDownloader.DownloadAsync(LItem.ImageURL).Result;
						var LBytes = TImageDownloader.DownloadAsync(LItem.ImageURL);
						if (LBytes.Length > 0)

						{
							File.WriteAllBytes(LPath, LBytes);
						}
					}
					TPicture LPicture = new TPicture();
					LPicture.LoadFromFile(LPath);
					LItem.ImageIndex = imImages.Add(LPicture);
				}
			}
		}

		private void FlushData()
		{
			lvData.Items.BeginUpdate();
			try
			{
				foreach (var LProduct in FList)
				{
					//var LItem = new TListItem(lvData.Items);
                    var LItem = lvData.Items.Add();
					LItem.Caption = LProduct.Title;
					LItem.Data = LProduct;
					LItem.ImageIndex = LProduct.ImageIndex;
				}
			}
			finally
			{
				lvData.Items.EndUpdate();
			}
		}

		private void GetDetailData(ref TProduct AProduct)
		{
			var LDetailData = LoadData("http://www.picandoteclas.com/", "a_product.json");
			UpdateProductInfo(ref AProduct, LDetailData);
		}

		private void UpdateProductInfo(ref TProduct AProduct, string AProductData)
		{
			var json = JsonValue.Parse(AProductData);
			var LObject = json as JsonObject;

			AProduct.Details = new TProductDetails();

			AProduct.Details.Title = LObject["title"];
			AProduct.Details.Manufacturer = LObject["manufacturer"];
			AProduct.Details.Description = LObject["description"];
			AProduct.Details.Images = new string[LObject["images"].Count];

			for (var LCounter = 0; LCounter < LObject["images"].Count; LCounter++)
			{
				AProduct.Details.Images[LCounter] = LObject["images"][LCounter];
			}
		}

		private void lvDataItemClick(TObject Sender, TSelectItemEventArgs e)
		{
			var LProduct = (TProduct)e.Item.Data;
			GetDetailData(ref LProduct);
			CatalogApp.App.CatalogDetail.CurrentProduct = LProduct;
			CatalogApp.App.CatalogDetail.Show();
		}
	}
}