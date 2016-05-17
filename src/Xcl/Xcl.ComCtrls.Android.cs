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
using System.Generics.Collections;
using System.Base;
using System.SysUtils;
using System.Classes;
using System.UITypes;
using Xcl.Controls;
using Xcl.Forms;
#if __ANDROID__
using Android.Widget;
using Android.Views;
using Android.Graphics;


namespace Xcl.ComCtrls
{

	public partial class TToolbar: TFocusControl
	{		
		public Toolbar toolbar;

		protected override void CreateHandle()
		{
			//Creates the native handle
			toolbar = new Toolbar (TApplication.context);
			//var color = new TColor (TColors.clRed);
			//toolbar.SetBackgroundColor ((Color)color.handle);

			//Assign native handles to manage through the wrappers
			//FFont.handle = uitoolbar.Font;
			//FFont.Color.handle = toolbar.TintColor;

			NativeChanged ();
			Handle = toolbar;
		}
	}
	/*
	public partial class TToolButton: TComponent
	{
		public UIBarButtonItem barbuttonitem;

		protected override void CreateNonVisualHandle()
		{
			//Creates the native handle
			barbuttonitem = new UIBarButtonItem ();
			barbuttonitem.Title = "< Back";

			//Assign native handles to manage through the wrappers
			//FFont.handle = uitoolbar.Font;
			//FFont.Color.handle = uibarbuttonitem.TintColor;

			//NativeChanged ();
			Handle = barbuttonitem;
		}

		partial  void NativeOnClickAdd(EventHandler value)
		{
			barbuttonitem.Clicked+=value;
		}

		partial  void NativeOnClickRemove(EventHandler value)
		{
			barbuttonitem.Clicked-=value;
		}


		partial void NativeToolbarChanged(TToolbar AToolbar)
		{
			AToolbar.Buttons.Add(this);
			UIBarButtonItem[] items=new UIBarButtonItem[AToolbar.Buttons.Count];
			for (int i=0; i<=AToolbar.Buttons.Count-1; i++)
			{
				items[i]=(UIBarButtonItem)AToolbar.Buttons[i].Handle;
			}
			AToolbar.toolbar.Items=items;


			//	AToolbar.toolbar.item
			//barbuttonitem.
		}
	}
*/

}
#endif
