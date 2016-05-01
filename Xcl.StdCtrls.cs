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
			//TODO: Review these defaults
			FLeft = 0;
			FTop = 0;
			FWidth = 200;
			FHeight = 50;
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
			//TODO: Review these defaults
			FLeft = 0;
			FTop = 0;
			FWidth = 200;
			FHeight = 50;
			UpdateBounds ();

		}	

	}

	/// <summary>
	/// Alignment for the label
	/// </summary>
	public enum TAlignment {taCenter, taLeftJustify, taRightJustify};

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

		public TLabel(TComponent AOwner):base(AOwner)
		{
		}
	}
}
