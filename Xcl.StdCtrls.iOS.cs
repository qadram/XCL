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
using Xcl.Controls;
using Xcl.StdCtrls;
using System.UITypes;
#if __IOS__
using UIKit;
using System.Drawing;
#endif

namespace Xcl.StdCtrls
{
	#if __IOS__
	public partial class TButton: TCustomButton
	{
		public UIKit.UIButton uibutton;

		protected override void NativeOnClickAdd(EventHandler value)
		{
			uibutton.TouchUpInside+=value;
		}
		protected override void NativeOnClickRemove(EventHandler value)
		{
			uibutton.TouchUpInside-=value;
		}

		protected override void CreateHandle()
		{
			//Creates the native handle
			uibutton = new UIButton ();

			//Assign native handles to manage through the wrappers
			FFont.handle = uibutton.Font;
			FFont.Color.handle = uibutton.TintColor;

			NativeChanged ();
			Handle = uibutton;
		}

		public override void NativeChanged()
		{
			uibutton.Font = FFont.handle;
			uibutton.SetTitleColor ((UIColor)FFont.Color.handle, UIControlState.Normal);
		}


		public override void SetText(string Value)
		{
			base.SetText(Value);
			uibutton.SetTitle (Value, UIControlState.Normal);			
		}
	}

	public partial class TEdit: TCustomEdit
	{
		public UIKit.UITextField handle;

		protected override void CreateHandle()
		{
			handle = new UITextField ();
			Handle = handle;
		}

		public override void SetText(string Value)
		{
			base.SetText(Value);
			handle.Text = Value;

		}

		public override string GetText()
		{
			return(handle.Text);
		}

	}

	public partial class TLabel:TGraphicControl
	{
		public UIKit.UILabel handle;

		protected override void CreateHandle()
		{
			handle = new UILabel ();
			FFont.handle = handle.Font;
			Handle = handle;
		}

		public override void NativeChanged()
		{
			handle.Font = FFont.handle;
			handle.TextColor = (UIColor)FFont.Color.handle;
		}

		partial void NativeSetTextAlignment()
		{
			switch (FAlignment)
			{
			case TAlignment.taCenter:
				handle.TextAlignment = UITextAlignment.Center;
				break;
			case TAlignment.taLeftJustify:
				handle.TextAlignment = UITextAlignment.Left;
				break;
			case TAlignment.taRightJustify:
				handle.TextAlignment = UITextAlignment.Right;
				break;
			default:
				handle.TextAlignment = UITextAlignment.Left;
				break;
			}
		}

		public override void SetText(string Value)
		{
			base.SetText(Value);
			handle.Text = Value;

		}

	}


	#endif
}