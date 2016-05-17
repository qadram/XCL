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
	public partial class TCustomTabControl:TFocusControl
	{
		public TCustomTabControl (TComponent AOwner) : base (AOwner)
		{
		}
	}

	public partial class TTabSheet: TFocusControl
	{
		public TTabSheet (TComponent AOwner) : base (AOwner)
		{
		}
	}

	public partial class TPageControl:TCustomTabControl
	{
		public TPageControl (TComponent AOwner) : base (AOwner)
		{
			Pages = new TList<TTabSheet> ();
		}

		public static TPageControl Create(TComponent AOwner)
		{
			return(new TPageControl (AOwner));
		}


		public TList<TTabSheet> Pages;
	}

	public partial class TToolButton: TComponent
	{
		public TToolButton (TComponent AOwner) : base (AOwner)
		{
			
		}

		partial void NativeToolbarChanged(TToolbar AToolbar);
		private TToolbar FToolbar;
		public TToolbar Toolbar
		{
			get {
				return(FToolbar);
			}
			set{
				NativeToolbarChanged (value);
				FToolbar = value;
			}
		}


		partial  void NativeOnClickAdd(EventHandler value);

		partial  void NativeOnClickRemove(EventHandler value);


		private void DoClick (object sender, EventArgs e)
		{
			DoEvent (FOnClick, sender, e);
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
				if (FOnClick==null)	{
					NativeOnClickAdd(DoClick);
				}

				//And the event is added internally, so it's fired along with the others
				FOnClick+=value;
			}
			remove
			{
				NativeOnClickRemove (DoClick);
				FOnClick-=value;
			}
		}

	}

	public partial class TToolbar: TFocusControl
	{
		public TList<TToolButton> Buttons;


		public TToolbar (TComponent AOwner) : base (AOwner)
		{
			Buttons = new TList<TToolButton> ();			
			FLeft = 0;
			FTop = 0;
			FWidth = 200;
			FHeight = 50;
			UpdateBounds ();
		}

		public static TToolbar Create(TComponent AOwner)
		{
			return(new TToolbar (AOwner));
		}
	}
}