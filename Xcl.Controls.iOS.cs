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
#endif

namespace Xcl.Controls
{
	#if __IOS__
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
			(Handle as UIView).BackgroundColor = AColor.handle as UIColor;
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
	#endif
}
