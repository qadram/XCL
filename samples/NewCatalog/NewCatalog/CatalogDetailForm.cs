using System;
using System.Base;
using System.Classes;
using System.UITypes;
using Xcl.StdCtrls;
using Xcl.Forms;
using Xcl.ComCtrls;
using Xcl.Controls;
using Xcl.Graphics;
using Xcl.ExtCtrls;
using System.Text;
using System.IO;
using System.Security.Policy;
using CatalogMain;

namespace CatalogDetailForm
{
    public class TfmDetail : TForm
	{
        private TPanel pnMain;
        private TPanel pnMainLeft;
        private TPanel pnMainRight;
        private TPanel pnBottom;

        private TLabel lbTitle;
        private TLabel lbManufacturer;
        private TLabel lbDescription;

        private TImage imMainImage;
        private TListView lvImages;
        private TImageList ilImages;

        private const int LeftMargin = 15;
        private const int TopMargin = 15;

        private TProduct FCurrentProduct;
        public TProduct CurrentProduct
        {
            get
            {
                return FCurrentProduct;
            }

            set
            {
                FCurrentProduct = value;
                UpdateData();
            }
        }

        public TfmDetail(TComponent AOwner) : base(AOwner)
		{
		}

		public override void Loaded()
		{
			base.Loaded();
            CreateComponents();
		}

        private void CreateComponents()
        {
            pnBottom = new TPanel(self);
            pnBottom.Parent = self;
            pnBottom.Align = TAlign.alBottom;
            pnBottom.Height = 85;

			pnMain = new TPanel(self);
			pnMain.Parent = self;
            pnMain.Align = TAlign.alClient;

            pnMainLeft = new TPanel(self);
            pnMainLeft.Parent = pnMain;
            pnMainLeft.Align = TAlign.alLeft;

            pnMainRight = new TPanel(self);
			pnMainRight.Parent = pnMain;
			pnMainRight.Align = TAlign.alRight;

            lbTitle = new TLabel(self);
            lbTitle.Width = (Screen.Width / 100) * 60;
            lbTitle.Parent = pnMainLeft;
            lbTitle.Left = LeftMargin;
            lbTitle.Top = TopMargin;

            lbManufacturer = new TLabel(self);
            lbManufacturer.Parent = pnMainLeft;
            lbManufacturer.Top = lbTitle.Top + 50;
            lbManufacturer.Left = LeftMargin;

            lbDescription = new TLabel(self);
            lbDescription.Parent = pnMainLeft;
            lbDescription.Left = LeftMargin;
            lbDescription.Top = lbManufacturer.Top + 80;

            imMainImage = new TImage(self);
            imMainImage.Parent = pnMainRight;

            lvImages = new TListView(self);

            lvImages.Parent = pnBottom;
			lvImages.Align = TAlign.alClient;
			lvImages.ViewStyle = TViewStyle.vsIcon;
            lvImages.OnSelectItem += lvImagesClick;

            ilImages = new TImageList(self);
            lvImages.LargeImages = ilImages;
		}

        private void UpdateData()
        {
            lbTitle.Caption = CurrentProduct.Title;
            CheckImages();
            lbManufacturer.Caption = CurrentProduct.Details.Manufacturer;
            lbDescription.Caption = CurrentProduct.Details.Description;
         
        }

		private void CheckImages()
		{
			string LExt;
			foreach (var LImagePath in CurrentProduct.Details.Images)
			{
				if (LImagePath != "")
				{
					var LMD5 = Hash.CreateMD5(Encoding.UTF8.GetBytes(LImagePath));
					if (LImagePath.IndexOf("http", StringComparison.CurrentCulture) < 0)
					{
						LExt = Path.GetExtension(LImagePath);
					}
					else
					{
						Uri LURI = new Uri(LImagePath);
						LExt = Path.GetExtension(LURI.AbsolutePath);
					}
					var LStr = BitConverter.ToString(LMD5.MD5).Replace("-", "") + LExt;
					string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

					string LPath = Path.Combine(documentsPath, LStr);
					if (!File.Exists(LPath))
					{
						var LBytes = TImageDownloader.DownloadAsync(LImagePath);
						if (LBytes.Length > 0)

						{
							File.WriteAllBytes(LPath, LBytes);
						}
					}
					TPicture LPicture = new TPicture();
					LPicture.LoadFromFile(LPath);
					var LNewItem = lvImages.Items.Add();
					LNewItem.Caption = "";
                    LNewItem.ImageIndex = ilImages.Add(LPicture);
				}
			}
		}

        private void lvImagesClick(TObject Sender, TSelectItemEventArgs e)
        {
        }
	}
}