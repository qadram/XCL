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
using Foundation;
using System.Drawing;
#endif

namespace Xcl.StdCtrls
{
	#if __IOS__
	public partial class TButton: TCustomButton
	{
		public UIKit.UIButton uibutton;

		protected override void CreateNativeHandle()
		{
			//Creates the native handle
			uibutton = new UIButton ();

			//Assign native handles to manage through the wrappers
			FFont.handle = uibutton.Font;
			FFont.Color.handle = uibutton.TintColor;

			NativeChanged ();
			Handle = uibutton;
		}
		public override void NativeSetEnabled()
		{
			uibutton.Enabled = Enabled;
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
		public UITextField textfield;

		protected override void CreateNativeHandle()
		{
			textfield = new UITextField ();
			Handle = textfield;
			Font.Size = 16;
			textfield.AutocapitalizationType = UITextAutocapitalizationType.None;
		}

		public override void SetText(string Value)
		{
			base.SetText(Value);
			textfield.Text = Value;

		}

		public virtual void NativeSetEnabled()
		{
			textfield.Enabled = Enabled;
		}

		public override void NativeChanged()
		{
			textfield.Font = FFont.handle;
			textfield.TextColor = (UIColor)FFont.Color.handle;
		}

		partial void NativeSetIsPassword()
		{
			textfield.SecureTextEntry=FIsPassword;
		}

		partial void NativeSetIsEmail()
		{
			if (FIsEmail)
			{
				textfield.KeyboardType = UIKeyboardType.EmailAddress;
			}
			else{
				textfield.KeyboardType = UIKeyboardType.Default;
			}
		}


		public override string GetText()
		{
			return(textfield.Text);
		}

		partial void NativeSetPlaceHolder(string value)
		{
			//textfield.Placeholder = value;
			textfield.AttributedPlaceholder=new NSAttributedString (
				value,
				null,
				FPlaceHolderColor.handle as UIColor,
				null,
				null
			);
		}

		protected override void NativeEvent (bool Add, string EventName, EventHandler value)
		{
			base.NativeEvent (Add, EventName, value);

			if (Add) 
			{
				if (EventName == "OnChange") textfield.EditingChanged += value;
			} 
			else 
			{
				if (EventName == "OnChange") textfield.EditingChanged -= value;
			}
		}
	}

	public class Label:UILabel
	{
		//TODO: Redraw when the layout is changed
		public TTextLayout Layout=TTextLayout.tlTop;

		public override void DrawText (CoreGraphics.CGRect rect)
		{
			if (Layout == TTextLayout.tlTop) {
				var size = rect.Size;
				size.Height = SizeThatFits (size).Height;
				rect.Size = size;
			}		
			else if (Layout == TTextLayout.tlBottom) {
				var size = rect.Size;
				var height = SizeThatFits (size).Height;
				rect.Y += (rect.Size.Height - height);
				size.Height = height;
				rect.Size = size;
			}

			base.DrawText (rect);
		}
	}

	public partial class TLabel:TGraphicControl
	{
		public Label handle;

		protected override void CreateNativeHandle()
		{
			handle = new Label ();
			handle.Lines = 0;
			FFont.handle = handle.Font;
			Handle = handle;
		}

		public override void NativeChanged()
		{
			handle.Font = FFont.handle;
			handle.TextColor = (UIColor)FFont.Color.handle;
		}
		partial void NativeSetTextLayout()
		{
			handle.Layout = FLayout;
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