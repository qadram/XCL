using System;
using System.Base;
using System.Classes;
using System.UITypes;
using Xcl.StdCtrls;
using Xcl.Forms;
using Xcl.ComCtrls;
using Xcl.Controls;
using Xcl.Graphics;
using Xcl.Samples;
using SampleBaseForm;


namespace ListViewSamples
{
	public class TListViewSamples : TSampleBaseForm
	{
		public TListView lvData;
		public TLabel label;
		public TImageList imImages;

		public TListViewSamples(TComponent AOwner) : base(AOwner)
		{
		}

		public override void Loaded()
		{
			TListItem LNewItem = null;
			base.Loaded();

			imImages = new TImageList(self);
			imImages.Add(TPicture.FromResource("images.jpeg"));
			imImages.Add(TPicture.FromResource("images.png"));
			imImages.Add(TPicture.FromResource("images-2.png"));
			imImages.Add(TPicture.FromResource("images-3.png"));
             
			lvData = new TListView(self);
			lvData.Parent = self;
			lvData.Top = 60;
			lvData.Left = 10;
			lvData.Height = 250;
			lvData.Width = Screen.Width - 20;
			lvData.SmallImages = imImages;
			lvData.LargeImages = imImages;


			//lvData.Items.BeginUpdate();
			LNewItem = lvData.Items.Add();
			LNewItem.Caption = "Venga 1!";
			LNewItem.ImageIndex = 1;
			LNewItem.SubItems.Add("Venga 12");
			LNewItem.SubItemsImages[0] = 3;
			LNewItem.SubItems.Add("Venga 13");
			LNewItem.SubItemsImages[1] = 3;

			LNewItem = lvData.Items.Add();
			LNewItem.ImageIndex = -1;
			LNewItem.Caption = "Venga 2!";
			LNewItem.SubItems.Add("Venga 22");
			LNewItem.SubItems.Add("Venga 23");

			for (int i = 0; i < 100; i++)
			{
				LNewItem = lvData.Items.Add();
				LNewItem.ImageIndex = -1;
				LNewItem.Caption = "V-" + (i + 3).ToString();
				LNewItem.SubItems.Add("Venga 22");
				LNewItem.SubItems.Add("Venga 23");
			}	

			//lvData.Items.EndUpdate();

			var lNew = lvData.Columns.Add();
			lNew.Caption = "Column 1";

			lNew = lvData.Columns.Add();
			lNew.Caption = "Column 2";
			lNew = lvData.Columns.Add();
			lNew.Caption = "Column 3";

			lvData.OnSelectItem += selectItem;

			//lvData.ViewStyle = TViewStyle.vsReport;

			label = TLabel.Create(self);
			label.Parent = self;
			label.Top = 250;
			label.Left = 10;
		}

		public void selectItem(TObject Sender, TSelectItemEventArgs e)
		{
			label.Caption = e.Item.Caption;
			if (lvData.ViewStyle == TViewStyle.vsIcon)
				lvData.ViewStyle = TViewStyle.vsReport;
			else
				lvData.ViewStyle = TViewStyle.vsIcon;
		}
	}
}