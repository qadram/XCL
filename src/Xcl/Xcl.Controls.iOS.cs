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
#if __IOS__
using UIKit;
using System.Drawing;

namespace Xcl.Controls
{
	public partial class TFocusControl:TControl
	{
		public UIControl control
		{
			get{
				return(Handle as UIControl);
			}
		}

		protected override void NativeEvent (bool Add, string EventName, EventHandler value)
		{
			//TODO: Review bubbling this or not through a boolean return
			base.NativeEvent (Add, EventName, value);

			if (Add) 
			{
				if (EventName == "OnMouseDown") control.TouchDown += value;
				else if (EventName == "OnClick") control.TouchUpInside += value;
				else if (EventName == "OnTouchDown") control.TouchDown += value;
				else if (EventName == "OnTouchDownRepeat") control.TouchDownRepeat += value;
				else if (EventName == "OnTouchDragEnter") control.TouchDragEnter += value;
				else if (EventName == "OnTouchDragExit") control.TouchDragExit += value;
				else if (EventName == "OnTouchDragInside") control.TouchDragInside += value;
				else if (EventName == "OnTouchDragOutside") control.TouchDragOutside += value;
				else if (EventName == "OnTouchUpInside") control.TouchUpInside += value;
				else if (EventName == "OnTouchUpOutside") control.TouchUpOutside += value;

			} 
			else 
			{
				if (EventName == "OnMouseDown") control.TouchDown -= value;
				else if (EventName == "OnClick") control.TouchUpInside -= value;
				else if (EventName == "OnTouchDown") control.TouchDown -= value;
				else if (EventName == "OnTouchDownRepeat") control.TouchDownRepeat -= value;
				else if (EventName == "OnTouchDragEnter") control.TouchDragEnter -= value;
				else if (EventName == "OnTouchDragExit") control.TouchDragExit -= value;
				else if (EventName == "OnTouchDragInside") control.TouchDragInside -= value;
				else if (EventName == "OnTouchDragOutside") control.TouchDragOutside -= value;
				else if (EventName == "OnTouchUpInside") control.TouchUpInside -= value;
				else if (EventName == "OnTouchUpOutside") control.TouchUpOutside -= value;

			}
		}
	}

	public partial class TControl:TComponent
	{
		public UIView view
		{
			get{
				return(Handle as UIView);
			}
		}

		partial void NativeSetColor(TColor AColor)
		{
			view.BackgroundColor = AColor.handle as UIColor;
		}

		partial void NativeSetVisible(bool value)
		{
			view.Hidden=!value;
		}

		partial void NativeUpdateBounds()
		{
			view.Frame = new RectangleF (FLeft, FTop, FWidth, FHeight); 
		}

	}

	public partial class TFocusControl:TControl{

		partial void NativeSetParent(TControl AControl)
		{
			view.AddSubview (AControl.view);
		}
	}

}
#endif