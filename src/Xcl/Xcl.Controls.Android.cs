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
using Xcl.Forms;
#if __ANDROID__
using Android.Widget;
using Android.Views;
using Android.Graphics;
#endif

namespace Xcl.Controls
{
	#if __ANDROID__
	public partial class TControl:TComponent
	{
		public View view
		{
			get{
				return(Handle as View);
			}
		}

		public ViewGroup viewgroup
		{
			get{
				return(Handle as ViewGroup);
			}
		}

		public TextView textview
		{
			get{
				return(Handle as TextView);
			}
		}
			
		partial void NativeSetColor(TColor AColor)
		{
			view.SetBackgroundColor((Color)AColor.handle);
		}

		public virtual void NativeApplyFontChanges()
		{
			textview.SetTextColor ((Color)FFont.Color.handle);
			textview.TextSize = FFont.Size;
			//TODO: Manage exception here
			if (FFont.Name != "sans-serif") {
				Typeface tf = Typeface.CreateFromAsset (TApplication.context.Assets, "fonts/" + _.LowerCase (FFont.Name) + ".ttf");
				textview.SetTypeface (tf, TypefaceStyle.Normal);
			}
		}

		partial void NativeSetVisible(bool value)
		{
			if (value)
			{
				view.Visibility=ViewStates.Visible;
			}
			else
			{
				view.Visibility=ViewStates.Gone;
			}
		}

		partial void NativeUpdateBounds()
		{
			//TODO: Review the type of parent layout
			view.LayoutParameters = new AbsoluteLayout.LayoutParams((int)_.Screen.ToPixels(FWidth), (int)_.Screen.ToPixels(FHeight), (int)_.Screen.ToPixels(FLeft), (int)_.Screen.ToPixels(FTop));			
		}
	}

	public partial class TFocusControl:TControl{

		partial void NativeSetParent(TControl AControl)
		{
			viewgroup.AddView (AControl.view);
		}
	}

	#endif
}

