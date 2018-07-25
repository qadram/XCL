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
using System.Base;
using System.Classes;
using System.Generics.Collections;
using Xcl.Controls;

namespace Xcl.ComCtrls
{
	public partial class TCustomTabControl : TFocusControl
	{
		public TCustomTabControl(TComponent AOwner) : base(AOwner)
		{
		}
	}

	public partial class TTabSheet : TFocusControl
	{
		public TTabSheet(TComponent AOwner) : base(AOwner)
		{
		}
	}

	public partial class TPageControl : TCustomTabControl
	{
		public TPageControl(TComponent AOwner) : base(AOwner)
		{
			Pages = new TList<TTabSheet>();
		}

		public static TPageControl Create(TComponent AOwner)
		{
			return (new TPageControl(AOwner));
		}


		public TList<TTabSheet> Pages;
	}

	public partial class TToolButton : TComponent
	{
		public TToolButton(TComponent AOwner) : base(AOwner)
		{

		}

		partial void NativeToolbarChanged(TToolbar AToolbar);
		private TToolbar FToolbar;
		public TToolbar Toolbar
		{
			get
			{
				return (FToolbar);
			}
			set
			{
				NativeToolbarChanged(value);
				FToolbar = value;
			}
		}


		partial void NativeOnClickAdd(EventHandler value);

		partial void NativeOnClickRemove(EventHandler value);


		private void DoClick(object sender, EventArgs e)
		{
			DoEvent(FOnClick, sender, e);
		}

		private event EventHandler FOnClick;
		/// <summary>
		/// Occurs when the control is clicked.
		/// </summary>
		public event EventHandler OnClick
		{
			add
			{
				//DoClick is just added once to the native control
				if (FOnClick == null)
				{
					NativeOnClickAdd(DoClick);
				}

				//And the event is added internally, so it's fired along with the others
				FOnClick += value;
			}
			remove
			{
				NativeOnClickRemove(DoClick);
				FOnClick -= value;
			}
		}
	}

	public partial class TToolbar : TFocusControl
	{
		public TList<TToolButton> Buttons;


		public TToolbar(TComponent AOwner) : base(AOwner)
		{
			Buttons = new TList<TToolButton>();
			FLeft = 0;
			FTop = 0;
			FWidth = 200;
			FHeight = 50;
			UpdateBounds();
		}

		public static TToolbar Create(TComponent AOwner)
		{
			return (new TToolbar(AOwner));
		}
	}

	public class TSubItems : TStringList
	{
		private TListItem FOwner;
		public TListItem Owner
		{
			get
			{
				return FOwner;
			}
		}

		private TList<int> FImageIndices;

		protected override void Put(int Index, string S)
		{
			base.Put(Index, S);
			FImageIndices[Index] = -1;
		}

		protected override void SetUpdateState(Boolean Updating)
		{
		}

		public TSubItems(TListItem AOwner)
		{
			FOwner = AOwner;
			FImageIndices = new TList<int>();
		}

		public override int Add(string S)
		{
			FImageIndices.Add(-1);
			return base.Add(S);
			// TODO refreshData
		}

		public override int AddObject(string S, TObject AObject)
		{
			return base.AddObject(S, AObject);
		}

		public override void Clear()
		{
			base.Clear();
			FImageIndices.Clear();
		}

		public override void Delete(int Index)
		{
			base.Delete(Index);
			FImageIndices.Delete(Index);
		}

		public override void Insert(int Index, string S)
		{
			base.Insert(Index, S);
			FImageIndices.Insert(Index, -1);
		}

		public int GetImageIndex(int Index)
		{
			return FImageIndices[Index];
		}

		public void SetImageIndex(int Index, int Value)
		{
			FImageIndices[Index] = Value;
		}

		public TList<int> GetImageIndices()
		{
			return FImageIndices;
		}
	}

	public partial class TListItem : TPersistent
	{
		private TListItems FOwner;

		private String FCaption;
		public String Caption
		{
			get
			{
				return (FCaption);
			}
			set
			{
				if (value != FCaption)
					FCaption = value;
				// TODO addional stuff
			}
		}

		private TSubItems FSubItems;
		public TSubItems SubItems
		{
			get
			{
				return FSubItems;
			}
			set
			{
				FSubItems.Assign(value);
			}
		}

		public TList<int> SubItemsImages
		{
			get
			{
				return FSubItems.GetImageIndices();
			}
		}

		private int FImageIndex;
		public int ImageIndex
		{
			get
			{
				return FImageIndex;
			}
			set
			{
				FImageIndex = value;
				// TODO refresh
			}
		}

		private int FStateIndex;
		public int StateIndex
		{
			get
			{
				return FStateIndex;
			}
			set
			{
				FStateIndex = value;
				// TODO refresh
			}
		}

		public TObject Data { get; set; }

		public TListItem(TListItems AOwner)
		{
			FOwner = AOwner;
			FSubItems = new TSubItems(this);
		}
	}

	public partial class TListItems : TPersistent
	{
		private TList<TListItem> FItems;

		private TCustomListView FOwner;
		public TCustomListView Owner
		{
			get
			{
				return (FOwner);
			}
		}

		public TListItem this[int index]
		{
			get
			{
				return FItems[index];
			}
		}

		public int Count
		{
			get
			{
				return (FItems.Count);
			}
		}

		private int FImageIndex;
		public int ImageIndex
		{
			get
			{
				return (FImageIndex);
			}
			set
			{
				FImageIndex = value;
			}
		}

		private void CheckReloadData()
		{
			if (FUpdateCount == 0)
				Owner.RefreshData();
		}

		public TListItem Add()
		{
			var LNewItem = new TListItem(this);
			FItems.Add(LNewItem);
			CheckReloadData();
			return (LNewItem);
		}

		public TListItem AddItem(TListItem Item, int Index = -1)
		{
			if (Index == -1)
				FItems.Add(Item);
			else
				FItems.Insert(Index, Item);
			CheckReloadData();

			return (Item);
		}

		public void Delete(int Index)
		{
			FItems.Delete(Index);
			CheckReloadData();
		}

		private int FUpdateCount;
		public void BeginUpdate() 
		{
			FUpdateCount++;
		}

		public void EndUpdate()
		{
			FUpdateCount--;
			CheckReloadData();
		}

		public TListItems(TCustomListView AOwner)
		{
			FItems = new TList<TListItem>();
			FOwner = AOwner;
		}
	}

	public class TListColumn: TCollectionItem
	{
		private TAlignment FAlignment = TAlignment.taLeftJustify;
		public TAlignment Alignment
		{
			get
			{
				return FAlignment;
			}
			set
			{
				FAlignment = value;
			}
		}

		private Boolean FAutoSize = false;
		public Boolean AutoSize
		{
			get
			{
				return FAutoSize;
			}
			set
			{
				FAutoSize = value;
			}
		}

		private string FCaption;
		public string Caption
		{
			get
			{
				return FCaption;
			}
			set
			{
				FCaption = value;
			}
		}

		private int FImageIndex = -1;
		public int ImageIndex
		{
			get
			{
				return FImageIndex;
			}
			set
			{
				FImageIndex = value;
			}
		}

		private int FMaxWidth = 0;
		public int MaxWidth
		{
			get
			{
				return FMaxWidth;
			}
			set
			{
				FMaxWidth = value;
			}
		}

		private int FMinWidth = 0;
		public int MinWidth
		{
			get
			{
				return FMinWidth;
			}
			set
			{
				FMinWidth = value;
			}
		}

		private int FTag = 0;
		public int Tag
		{
			get
			{
				return FTag;
			}
			set
			{
				FTag = value;
			}
		}

		private int FWidth = 100;
		public int Width
		{
			get
			{
				return FWidth;
			}
			set
			{
				FWidth = value;
			}
		}

		protected override String GetDisplayName()
		{
			return FCaption;
		}

		protected override void SetIndex(int Value)
		{
			base.SetIndex(Value);
		}

		public TListColumn(TCollection Collection) : base(Collection)
		{
			
		}

		public override void Assign(TPersistent Source)
		{
			base.Assign(Source);
		}

		public int WidthType
		{
			get
			{
				return FWidth;
			}
		}
	}

	public class TListColumns : TCollection
	{
		private TCustomListView FOwner;

		protected virtual Type GetListColumnsClass()
		{
			return typeof(TListColumn);
		}

		protected override TPersistent GetOwner()
		{
			return FOwner;
		}

		protected override void Update(TCollectionItem Item)
		{
			
		}

		public TListColumns(TCustomListView AOwner) : base(typeof(TListColumn))
		{
			FOwner = AOwner;
		}

		public new TListColumn Add()
		{
			return (TListColumn)base.Add();
			// TODO refresh
		}

		public new TCustomListView Owner()
		{
			return FOwner;
		}

		public new TListColumn this[int Index]
		{
			get
			{
				return (TListColumn)base.GetItem(Index);
			}
			set
			{
				base.SetItem(Index, value);
			}
		}
	}

	public enum TViewStyle { vsIcon, vsSmallIcon, vsList, vsReport };

	public class TSelectItemEventArgs : EventArgs
	{
		public TListItem Item { get; set; }
		public Boolean IsSelected { get; set; }

		public TSelectItemEventArgs(TListItem AItem, Boolean AIsSelected)
		{
			Item = AItem;
			IsSelected = AIsSelected;
		}
	}

	public delegate void TLVSelectItemEvent(TObject Sender, TSelectItemEventArgs e);

	public partial class TCustomListView : TCustomMultiSelectListControl
	{
		private int FItemIndex = -1;

		private TListItems FListItems;
		public TListItems Items
		{
			get
			{
				return (FListItems);
			}
			set
			{
				FListItems.Assign(value);
			}
		}

		private TListColumns FListColumns;
		public TListColumns Columns
		{
			get
			{
				return FListColumns;
			}
			set
			{
				FListColumns.Assign(value);
			}
		}

		public TListColumn Column(int Index)
		{
			return Columns[Index];
		}

		partial void ReloadData();

		public void RefreshData()
		{
			ReloadData();
		}

		partial void NativeChangeViewStyle();

		private TViewStyle FViewStyle = TViewStyle.vsIcon;
		public TViewStyle ViewStyle
		{
			get
			{
				return (FViewStyle);
			}
			set
			{
				if (FViewStyle != value)
				{
					FViewStyle = value;
					NativeChangeViewStyle();
					var LOldParent = this.Parent;
					this.Parent = null;
					this.Parent = LOldParent;
				}
			}
		}

		private TImageList FSmallImages;
		public TImageList SmallImages
		{
			get
			{
				return (FSmallImages);
			}
			set
			{
				FSmallImages = value;
			}
		}

		private TImageList FLargeImages;
		public TImageList LargeImages
		{
			get
			{
				return (FLargeImages);
			}
			set
			{
				FLargeImages = value;
			}
		}

		protected override int GetItemIndex()
		{
			return (FItemIndex);
		}
		protected override void SetItemIndex(int Index)
		{
			FItemIndex = Index;
			// TODO
		}

		protected internal virtual void DoSelectItem(TListItem Item, Boolean IsSelected)
		{
            /*TLVSelectItemEvent LHandler = FOnSelectItem;
			if (LHandler != null)
				LHandler(this, Item, IsSelected);*/
            if (FOnSelectItem != null)
			    DoEvent(FOnSelectItem, this, new TSelectItemEventArgs(Item, IsSelected));
		}

		private TListItem GetSelected()
		{
			return (null);
			// TODO
		}
		private void SetSelected(TListItem Item)
		{
			// TODO
		}
		public TListItem Selected
		{
			get
			{
				return (GetSelected());
			}
			set
			{
				SetSelected(value);
			}
		}

		private event TLVSelectItemEvent FOnSelectItem;
		public event TLVSelectItemEvent OnSelectItem
		{
			add
			{
				FOnSelectItem += value;
			}
			remove
			{
				FOnSelectItem -= value;
			}
		}

		public TCustomListView(TComponent AOwner) : base(AOwner)
		{
			FListItems = new TListItems(this);
			FListColumns = new TListColumns(this);
		}
	}

	public partial class TListView : TCustomListView
	{
		public TListView(TComponent AOwner) : base(AOwner)
		{

		}

	}
}