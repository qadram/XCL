/**
*  This file is part of the RadX project
*
*  Copyright (c) 2016 radx.plugin@gmail.com
*
*  Checkout AUTHORS file for more information on the developers
*
*  This library is free software; you can redistribute it and/or
*  modify it under the terms of the GNU Lesser General Public
*  License as published by the Free Software Foundation; either
*  version 2.1 of the License, or (at your option) any later version.
*
*  This library is distributed in the hope that it will be useful,
*  but WITHOUT ANY WARRANTY; without even the implied warranty of
*  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
*  Lesser General Public License for more details.
*
*  You should have received a copy of the GNU Lesser General Public
*  License along with this library; if not, write to the Free Software
*  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307
*  USA
*/
using System;
using System.Generics.Collections;
using System.Base;
using System.SysUtils;
using System.Classes;
using System.UITypes;
using Xcl.Controls;
#if __IOS__
using UIKit;
using System.Drawing;
using Foundation;
using CoreGraphics;
//using ObjCRuntime;
//using System.ComponentModel;
//using System.Runtime.CompilerServices;

namespace Xcl.ComCtrls
{
	
	public partial class TToolbar: TFocusControl
	{		
		public UIToolbar toolbar;

		protected override void CreateNativeHandle()
		{
			//Creates the native handle
			toolbar = new UIToolbar ();

			//Assign native handles to manage through the wrappers
			//FFont.handle = uitoolbar.Font;
			FFont.Color.handle = toolbar.TintColor;

			NativeChanged ();
			Handle = toolbar;                                          
		}
	}

	public partial class TToolButton: TComponent
	{
		public UIBarButtonItem barbuttonitem;

		protected override void CreateNonVisualHandle()
		{
			//Creates the native handle
			barbuttonitem = new UIBarButtonItem ();
			barbuttonitem.Title = "< Back";

			//Assign native handles to manage through the wrappers
			//FFont.handle = uitoolbar.Font;
			//FFont.Color.handle = uibarbuttonitem.TintColor;

			//NativeChanged ();
			Handle = barbuttonitem;
		}

		partial  void NativeOnClickAdd(EventHandler value)
		{
			barbuttonitem.Clicked+=value;
		}

		partial  void NativeOnClickRemove(EventHandler value)
		{
			barbuttonitem.Clicked-=value;
		}


		partial void NativeToolbarChanged(TToolbar AToolbar)
		{
			AToolbar.Buttons.Add(this);
			UIBarButtonItem[] items=new UIBarButtonItem[AToolbar.Buttons.Count];
			for (int i=0; i<=AToolbar.Buttons.Count-1; i++)
			{
				items[i]=(UIBarButtonItem)AToolbar.Buttons[i].Handle;
			}
			AToolbar.toolbar.Items=items;


		//	AToolbar.toolbar.item
			//barbuttonitem.
		}
	}

	public class TCustomIconViewCell : UICollectionViewCell
	{
		private TCustomListView FOwner;
		public UIImageView FImage;
		public UILabel FLabel;
		public bool FIsIcon = true;

		public TCustomIconViewCell(TCustomListView AOwner)
		{
			FOwner = AOwner;
		}

		private void CreateComponents()
		{
			FImage = new UIImageView(new CGRect(2, 2, 71, 40));
			FLabel = new UILabel(new CGRect(8, 44, 60, 14));
			FImage.BackgroundColor = UIColor.White;
            //FLabel.BackgroundColor = UIColor.Red;
            //FLabel.Font = FLabel.Font.WithSize(FOwner.Font.Size);
            FLabel.Font = UIFont.SystemFontOfSize(8);
            FLabel.TextColor = UIColor.White;
			ContentView.AddSubview(FImage);
			ContentView.AddSubview(FLabel);
		}


		public TCustomIconViewCell(IntPtr handle) : base(handle)
		{
			CreateComponents();
		}
				                            
	}

	public class TCollectionViewDeletegate : UICollectionViewDelegateFlowLayout
	{
		private TCustomListView FOwner;

		private int IndexPathToNItem(NSIndexPath AIndexPath)
		{
			return 0;
		}

		public TCollectionViewDeletegate(TCustomListView AOwner)
		{
			FOwner = AOwner;
		}

		public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
		{
			return new CGSize(75, 60);
		}

        public override nfloat GetMinimumLineSpacingForSection(UICollectionView collectionView, UICollectionViewLayout layout, nint section)
        {
            return 5;
        }

		public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
		{
			FOwner.DoSelectItem(FOwner.Items[indexPath.Row], true);
		}

		public override void ItemDeselected(UICollectionView collectionView, NSIndexPath indexPath)
		{
			FOwner.DoSelectItem(FOwner.Items[indexPath.Row], false);
		}
	}

	public class TCollectionViewDataSourceDelegate : UICollectionViewDataSource
	{
		private TCustomListView FOwner;

		public TCollectionViewDataSourceDelegate(TCustomListView AOwner)
		{
			FOwner = AOwner;
		}

		public override nint GetItemsCount(UICollectionView collectionView, nint section)
		{
			return FOwner.Items.Count;
			//return FOwner.Items.Count / (System.nint)(FOwner.uiCollection.Frame.Width / 75);
		}

		public override nint NumberOfSections(UICollectionView collectionView)
		{
			return 1;
			//return (System.nint)(FOwner.uiCollection.Frame.Width / 75);
		}

		public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
		{
			var LCell = (TCustomIconViewCell)collectionView.DequeueReusableCell("iconCell", indexPath);

			if (FOwner.ViewStyle != TViewStyle.vsIcon && LCell.FIsIcon)
												
			LCell.BackgroundColor = UIColor.Blue;

			var FIndexPath = indexPath;

			var LItem = FOwner.Items[indexPath.Row];
			LCell.FLabel.Text = LItem.Caption;
			if (LItem.ImageIndex >= 0 && FOwner.LargeImages != null)
				LCell.FImage.Image = FOwner.LargeImages.Items[LItem.ImageIndex].handle;
			else
				LCell.FImage.Image = null;

			return LCell;
		}
	}

	public class TCustomIconCell : UITableViewCell
	{
		private TList<UILabel> FLabels = null;
		private TList<UIImageView> FImages = null;
		private TCustomListView FOwner;
		private NSIndexPath FIndexPath;

		public TCustomIconCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId)
		{
			
		}

		private void CreateComponents(TCustomListView Owner)
		{
			FOwner = Owner;
			FLabels = new TList<UILabel>();
			FImages = new TList<UIImageView>();

			//var LLeft = 5;
			SelectionStyle = UITableViewCellSelectionStyle.Gray;
			//ContentView.BackgroundColor = UIColor.FromRGB(218, 255, 127);
			for (int I = 0; I <= FOwner.Columns.Count - 1; I++)
			{
				var LImage = new UIImageView();
				FImages.Add(LImage);

				//var LLabel = new UILabel(new CGRect(LLeft, 0, FOwner.Columns[I].Width, 26));
				var LLabel = new UILabel();
				FLabels.Add(LLabel);
				ContentView.AddSubviews(LImage, LLabel);
				//LLeft += FOwner.Columns[I].Width + 5;
			}			
		}

		public TCustomIconCell(IntPtr handle) : base(handle)
		{
			
		}

		public void UpdateCell(TCustomListView Owner, NSIndexPath indexPath)
		{
			if (FLabels == null)
				CreateComponents(Owner);
			FIndexPath = indexPath;

			var LItem = Owner.Items[indexPath.Row];
			FLabels[0].Text = LItem.Caption;
			if (LItem.ImageIndex >= 0 && Owner.SmallImages != null)
				FImages[0].Image = Owner.SmallImages.Items[LItem.ImageIndex].handle;
			else
				FImages[0].Image = null;

			for (int I = 0; I <= LItem.SubItems.Count - 1; I++)
			{
				FLabels[I + 1].Text = LItem.SubItems[I];
				if (LItem.SubItemsImages[I] >= 0 && Owner.SmallImages != null)
					FImages[I + 1].Image = Owner.SmallImages.Items[LItem.SubItemsImages[I]].handle;
				else
					FImages[I + 1].Image = null;
			}
		}

		public override void LayoutSubviews()
		{
			var LLeft = 5;
			var LImageWidth = 0;
			var LItem = FOwner.Items[FIndexPath.Row];
			base.LayoutSubviews();

			if (FOwner.SmallImages != null)
			{
				FImages[0].Frame = new CGRect(LLeft, 0, 24, 24);
				LLeft += 24;
				LImageWidth = 24;
			}
			FLabels[0].Frame = new CGRect(LLeft, 0, FOwner.Columns[0].Width - LImageWidth, 26);
			LLeft += FOwner.Columns[0].Width + 5 - LImageWidth;

			for (int I = 0; I <= LItem.SubItems.Count - 1; I++)
			{
				if (FOwner.SmallImages != null && LItem.SubItemsImages[I] >= 0)
				{
					FImages[I + 1].Frame = new CGRect(LLeft, 0, 24, 24);
					LLeft += 24;
					LImageWidth = 24;
				}
				else
				{
					FImages[I + 1].Frame = new CGRect(0, 0, 0, 0);
					LImageWidth = 0;
				}
				FLabels[I + 1].Frame = new CGRect(LLeft, 0, FOwner.Columns[I + 1].Width - LImageWidth, 26);
				LLeft += FOwner.Columns[I].Width + 5 - LImageWidth;	
			}

			//Image.Frame = new CGRect(ContentView.Bounds.Width - 63, 5, 33, 33);
			//Label.Frame = new CGRect(5, 4, ContentView.Bounds.Width - 63, 25);
		}
	}

	class TTableViewDelegate : UITableViewDelegate
	{
		private TCustomListView FOwner;

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			FOwner.DoSelectItem(FOwner.Items[indexPath.Row], true);
		}

		public override void RowDeselected(UITableView tableView, NSIndexPath indexPath)
		{
			FOwner.DoSelectItem(FOwner.Items[indexPath.Row], false);
		}

		public override nfloat GetHeightForHeader(UITableView tableView, nint section)
		{
			if (FOwner.ViewStyle != TViewStyle.vsReport)
				return 0;
			else
				return 26;
		}

		public override UIView GetViewForHeader(UITableView tableView, nint section)
		{
			if (FOwner.ViewStyle != TViewStyle.vsReport)
				return null;
			
			var LView = new UIView(new CGRect(0, 0, FOwner.Width, 26));
			var LLeft = 10;

			LView.BackgroundColor = UIColor.GroupTableViewBackgroundColor;
			for (int I = 0; I <= FOwner.Columns.Count - 1; I++)
			{
				var LLabel = new UILabel(new CGRect(LLeft, 0, FOwner.Columns[I].Width, 26));
				LLabel.Text = FOwner.Columns[I].Caption;
				LView.AddSubview(LLabel);
				LLeft += FOwner.Columns[I].Width + 5;
			}
			return LView;
		}

		public TTableViewDelegate(TCustomListView AOwner)
		{
			FOwner = AOwner;
		}
	}

	class TTableViewDataSourceDelegate : UITableViewDataSource
	{
		private TCustomListView FOwner;
		
		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = null;
			if (FOwner.ViewStyle != TViewStyle.vsReport)
			{
				cell = (UITableViewCell)tableView.DequeueReusableCell("cellId");
				cell.TextLabel.Text = FOwner.Items[indexPath.Row].Caption;
				if (FOwner.SmallImages != null && FOwner.Items[indexPath.Row].ImageIndex >= 0)
					cell.ImageView.Image = FOwner.SmallImages.Items[FOwner.Items[indexPath.Row].ImageIndex].handle;
			}
			else
			{
				var LCustomCell = (UITableViewCell)tableView.DequeueReusableCell("reportCellId") as TCustomIconCell;
				LCustomCell.UpdateCell(FOwner, indexPath);

				cell = LCustomCell;

			}
			return cell;
		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{
			return (FOwner.Items.Count);
		}

		public override nint NumberOfSections(UITableView tableView)
		{
			return (1);
		} 

		public TTableViewDataSourceDelegate(TCustomListView AOwner)
		{
			FOwner = AOwner;
		}
	}

    public partial class TCustomListView: TCustomMultiSelectListControl
	{

		public UIKit.UITableView uiTableView;
		private TTableViewDataSourceDelegate dataDelegate;
		private TTableViewDelegate viewDelegate;

		public UICollectionView uiCollection;
		private TCollectionViewDataSourceDelegate colDataDelegate;
		private TCollectionViewDeletegate colDelegate;
        public UICollectionViewFlowLayout uiLayout;

		protected override void CreateNativeHandle()
		{
			//Creates the native handle
			if (this.ViewStyle != TViewStyle.vsIcon && this.ViewStyle != TViewStyle.vsSmallIcon)
			{
				uiTableView = new UITableView(new CGRect(0, 0, Width, Height));
				dataDelegate = new TTableViewDataSourceDelegate(this);
				viewDelegate = new TTableViewDelegate(this);

				uiTableView.Delegate = viewDelegate;
				uiTableView.DataSource = dataDelegate;
				uiTableView.RegisterClassForCellReuse(typeof(UITableViewCell), "cellId");
				uiTableView.RegisterClassForCellReuse(typeof(TCustomIconCell), "reportCellId");

				NativeChanged();
				Handle = uiTableView;
			}
			else
			{
				uiLayout = new UICollectionViewFlowLayout(); 
				uiCollection = new UICollectionView(new CGRect(0, 0, Width, Height), uiLayout);
				colDataDelegate = new TCollectionViewDataSourceDelegate(this);
				colDelegate = new TCollectionViewDeletegate(this);
				var FLayout = new UICollectionViewFlowLayout();
				FLayout.ScrollDirection = UICollectionViewScrollDirection.Vertical;

				uiCollection.Delegate = colDelegate;
				uiCollection.DataSource = colDataDelegate;
				uiCollection.RegisterClassForCell(typeof(TCustomIconViewCell), "iconCell");

				NativeChanged();
				Handle = uiCollection;
			}
		}

		partial void NativeChangeViewStyle()
		{
			if (uiTableView != null)
			{
				//uiTableView.Hidden = true;
                uiTableView.RemoveFromSuperview();
				uiTableView.Dispose();
				dataDelegate.Dispose();
				viewDelegate.Dispose();
			}
			else
			{
				//uiCollection.Hidden = true;
				uiCollection.RemoveFromSuperview();
				uiCollection.Dispose();
				colDelegate.Dispose();
				colDataDelegate.Dispose();
			}

			CreateNativeHandle();
			ReloadData();
		}

		partial void ReloadData()
		{
			if (this.ViewStyle != TViewStyle.vsIcon && this.ViewStyle != TViewStyle.vsSmallIcon)
				uiTableView.ReloadData();
			else
				uiCollection.ReloadData();
		}			        
	}

}
#endif