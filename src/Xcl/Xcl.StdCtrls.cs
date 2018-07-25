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
using System.Collections.Generic;
using System.Base;
using System.SysUtils;
using System.Classes;
using System.UITypes;
using Xcl.Controls;
using Xcl.ImgList;

namespace Xcl.StdCtrls
{
	/// <summary>
	/// Base class for button-type controls
	/// </summary>
	public partial class TButtonControl: TFocusControl
	{
		private Boolean FClicksDisabled;
		protected Boolean ClicksDisabled
		{
			get
			{
				return FClicksDisabled;
			}
			set
			{
				FClicksDisabled = value;
			}
		}

		private Boolean FWordWrap;
		protected Boolean WordWrap
		{
			get
			{
				return (FWordWrap);
			}
			set
			{
				if (FWordWrap != value)
				{
					FWordWrap = value;
					// TODO repaint
				}
			}
		}

		protected virtual Boolean GetChecked()
		{
			return(false);
		}
		protected virtual void SetChecked(Boolean Value)
		{
		}

		protected Boolean Checked
		{
			get
			{
				return (GetChecked());
			}
			set
			{
				SetChecked(value);
			}
		}
/*
		protected override void ActionChange(TObject Sender, Boolean CheckDefaults)
		{
		}

		protected override TControlActionLinkClass GetActionLinkClass()
		{
		}

		protected override void CreateParams(var TCreateParams CreateParams)
		{
		}
*/		

		public TButtonControl(TComponent AOwner):base(AOwner)
		{
			
		}
	}

	/// <summary>
	/// Base class for button class
	/// </summary>
	public partial class TCustomButton:TButtonControl
	{
		public TCustomButton(TComponent AOwner):base(AOwner)
		{
			FLeft = 0;
			FTop = 0;
			FWidth = 75;
			FHeight = 36;
			UpdateBounds ();
		}	

		private TCustomImageList FImages = null;

		/// <summary>
		/// Gets or sets the images property, to be used when animating
		/// </summary>
		/// <value>The images.</value>
		public TCustomImageList Images
		{
			get{
				return(FImages);
			}
			set{
				if (value != FImages) {
					if (FImages != null) {
						//FImages.UnRegisterChanges (FImageChangeLink);
					}
					FImages = value;
					if (FImages != null) {
						//Images.RegisterChanges (FImageChangeLink);
						Images.FreeNotification (this);
					}
					UpdateImageList();
				}
			}
		}

		protected virtual void UpdateImageList()
		{
		}

		private int FImageIndex=-1;
		public int ImageIndex
		{
			get {
				return(FImageIndex);
			}
			set{
				FImageIndex = value;

			}
			
		}


	}

	/// <summary>
	/// A button
	/// </summary>
	public partial class TButton: TCustomButton
	{
		public static TButton Create(TComponent AOwner)
		{
			return(new TButton (AOwner));
		}
		public TButton(TComponent AOwner):base(AOwner)
		{
		}	
	}


	/// <summary>
	/// Base class for Edit class
	/// </summary>
	public partial class TCustomEdit:TFocusControl
	{
		#region Events
		//OnChangeEvent event
		protected void DoChange (object sender, EventArgs e)
		{
			DoEvent (FOnChange, sender, e);
		}

		protected event TNotifyEvent FOnChange;
		public event TNotifyEvent OnChange
		{
			add{
				if (FOnChange==null) NativeEvent(true, "OnChange", DoChange);
				FOnChange+=value;
			}
			remove{
				NativeEvent(false, "OnChange", DoChange);
				FOnChange -= value;
			}
		}

		#endregion

		/// <summary>
		/// Edit control
		/// </summary>
		public TCustomEdit(TComponent AOwner):base(AOwner)
		{
			FPlaceHolderColor = new TColor (TColors.clSilver);			
			FLeft = 0;
			FTop = 0;
			FWidth = 120;
			FHeight = 40;
			UpdateBounds ();

		}	

		partial void NativeSetIsPassword();

		private bool FIsPassword=false;
		public bool IsPassword
		{
			get{
				return(FIsPassword);
			}
			set {
				FIsPassword = value;
				NativeSetIsPassword ();
			}
		}

		partial void NativeSetIsEmail();

		private bool FIsEmail=false;
		public bool IsEmail
		{
			get{
				return(FIsEmail);
			}
			set {
				FIsEmail = value;
				NativeSetIsEmail ();
			}
		}

		public virtual void SetPlaceHolderColor(TColor AColor)
		{
			FPlaceHolderColor = AColor;
			NativeSetPlaceHolder (FPlaceHolder);
		}

		private TColor FPlaceHolderColor;
		public TColor PlaceHolderColor
		{
			get{
				return(FPlaceHolderColor);
			}
			set{
				SetPlaceHolderColor (value);	
			}
		}

		partial void NativeSetPlaceHolder(string value);

		private string FPlaceHolder="";
		public string PlaceHolder {
			get {
				return(FPlaceHolder);
			}
			set {
				FPlaceHolder = value;
				NativeSetPlaceHolder (FPlaceHolder);
			}
		}
	}

	public partial class TEdit: TCustomEdit
	{
		public static TEdit Create(TComponent AOwner)
		{
			return(new TEdit (AOwner));
		}

		public TEdit(TComponent AOwner):base(AOwner)
		{
		}
	}

	public enum TTextLayout {tlTop, tlCenter, tlBottom};

	/// <summary>
	/// Label control
	/// </summary>
	public partial class TCustomLabel:TGraphicControl
	{
		private TAlignment FAlignment=TAlignment.taLeftJustify;

		partial void NativeSetTextAlignment();

		/// <summary>
		/// Gets or sets the alignment.
		/// </summary>
		/// <value>The alignment.</value>
		public TAlignment Alignment
		{
			get {
				return(FAlignment);
			}
			set {
				FAlignment = value;
				NativeSetTextAlignment ();
			}
		}

		private TTextLayout FLayout=TTextLayout.tlTop;

		partial void NativeSetTextLayout();

		/// <summary>
		/// Gets or sets the alignment.
		/// </summary>
		/// <value>The alignment.</value>
		public TTextLayout Layout
		{
			get {
				return(FLayout);
			}
			set {
				FLayout = value;
				NativeSetTextLayout ();
			}
		}


		public TCustomLabel(TComponent AOwner):base(AOwner)
		{
			FLeft = 0;
			FTop = 0;
			FWidth = 75;
			FHeight = 36;
			UpdateBounds ();
		}
	}

	public partial class TLabel:TCustomLabel
	{
		public TLabel(TComponent AOwner):base(AOwner)
		{
			
		}

		public static TLabel Create(TComponent AOwner)
		{
			return(new TLabel (AOwner));
		}
	}

    public abstract class TCustomComboBoxStrings: TStringList
    {
        protected TStringList FData;
        protected TCustomComboBox FComboBox;

        public TCustomComboBoxStrings(): base()
        {
            FData = new TStringList();    
        }

        public TCustomComboBox ComboBox
        {
            get
            {
                return FComboBox;
            }
            set
            {
                FComboBox = value;
            }
        }

        protected override int GetCount()
        {
            return FData.Count;
        }

        protected override string Get(int Index)
        {
            return FData[Index];
        }

        public override TObject GetObject(int Index)
        {
            return FData.GetObject(Index);
        }

        public override void PutObject(int Index, TObject AObject)
        {
            FData.PutObject(Index, AObject);
        }

        protected override void SetUpdateState(bool Updating)
        {
            base.SetUpdateState(Updating);
        }

        public override void Clear()
        {
            FComboBox.NotifyClear();
            FData.Clear();
        }

        public override void Delete(int Index)
        {
            FComboBox.NotifyDelete(Index);
            FData.Delete(Index);
        }

        public override int IndexOf(string S)
        {
            return FData.IndexOf(S);
        }
    }

    public class TComboBoxStrings: TCustomComboBoxStrings
    {
        public override int Add(string S)
        {
            ComboBox.NotifyAdd(S);
            return FData.Add(S);
        }

        public override void Insert(int Index, string S)
        {
            ComboBox.NotifyInsert(Index, S);
            FData.Insert(Index, S);
        }       
    }

    public partial class TCustomCombo: TCustomListControl
    {
        public TCustomCombo(TComponent AOwner): base(AOwner)
        {
            
        }

        protected TStrings FItems;

        protected override int GetItemIndex()
        {
            int LIndex = 0;
            NativeGetItemIndex(ref LIndex);
            return LIndex;
        }

        protected override void SetItemIndex(int Index)
        {
            NativeSetItemIndex(Index);
        }

        public TStrings Items
        {
            get
            {
                return FItems;
            }
            set
            {
                FItems = value;
            }
        }

        partial void NativeSetItemIndex(int Index);

        partial void NativeGetItemIndex(ref int Index);
    }

    public partial class TCustomComboBox: TCustomCombo
    {
        public TCustomComboBox(TComponent AOwner): base(AOwner)
        {
            FItems = new TComboBoxStrings();
            (FItems as TCustomComboBoxStrings).ComboBox = this;
        }

        public void NotifyAdd(String NewItem)
        {
            NativeAdd(NewItem);
        }

        public void NotifyInsert(int Index, String NewItem)
        {
            NativeInsert(Index, NewItem);    
        }

        public void NotifyClear()
        {
            NativeClear();
        }

        public void NotifyDelete(int Index)
        {
            NativeDelete(Index);
        }

        partial void NativeAdd(String NewItem);

        partial void NativeInsert(int Pos, String NewItem);

        partial void NativeClear();

        partial void NativeDelete(int Index);
    }

    public partial class TComboBox: TCustomComboBox
    {
        public TComboBox(TComponent AOwner): base(AOwner)
        {

        }
    }
}
