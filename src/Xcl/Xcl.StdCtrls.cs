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

namespace Xcl.StdCtrls
{
	/// <summary>
	/// Base class for button-type controls
	/// </summary>
	public partial class TButtonControl: TFocusControl
	{
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
			FLeft = 0;
			FTop = 0;
			FWidth = 75;
			FHeight = 36;
			UpdateBounds ();
		}	
	}


	/// <summary>
	/// Base class for Edit class
	/// </summary>
	public partial class TCustomEdit:TFocusControl
	{
		public TCustomEdit(TComponent AOwner):base(AOwner)
		{
		}	

		private void DoChange (object sender, EventArgs e)
		{
			DoEvent (FOnChange, sender, e);
		}

		private event EventHandler FOnChange;

		public event EventHandler OnChange
		{
			add
			{				
				//DoClick is just added once to the native control
				if (FOnChange==null)	{
					NativeOnChangeAdd(DoChange);
				}

				//And the event is added internally, so it's fired along with the others
				FOnChange+=value;
			}
			remove
			{
				NativeOnChangeRemove (DoChange);
				FOnChange-=value;
			}
		}


	}

	/// <summary>
	/// Edit control
	/// </summary>
	public partial class TEdit: TCustomEdit
	{
		public static TEdit Create(TComponent AOwner)
		{
			return(new TEdit (AOwner));
		}

		public TEdit(TComponent AOwner):base(AOwner)
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

	/// <summary>
	/// Alignment for the label
	/// </summary>
	public enum TAlignment {taCenter, taLeftJustify, taRightJustify};

	public enum TTextLayout {tlTop, tlCenter, tlBottom};


	/// <summary>
	/// Label control
	/// </summary>
	public partial class TLabel:TGraphicControl
	{
		public static TLabel Create(TComponent AOwner)
		{
			return(new TLabel (AOwner));
		}

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


		public TLabel(TComponent AOwner):base(AOwner)
		{
		}
	}
}
