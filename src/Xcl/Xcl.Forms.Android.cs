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
using Xcl.StdCtrls;
using Xcl.Forms;
using System.UITypes;
#if __ANDROID__
using Android.App;
using Android.OS;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Util;
using Android.Content.Res;
using Android.Content.PM;
#endif

namespace Xcl.Forms
{
	#if __ANDROID__

	public partial class TApplication:TComponent
	{
		public static Context context = null;
		public static Activity MainActivity = null;

		partial void NativeInitialize(object param)
		{
			TApplication.MainAssembly = param.GetType().Assembly;
			TApplication.MainActivity = (Activity)param;
			TApplication.context = TApplication.MainActivity.BaseContext;
		}

		partial void NativeRun()
		{
			MainForm.Show();
		}
	}

	public partial class TScreen:TComponent
	{
		public int ToDp(float pixelValue)
		{
			var dp = (int) ((pixelValue)/TApplication.MainActivity.Resources.DisplayMetrics.Density);
			return dp;
		}

		public float ToPixels(float dpValue)
		{
			var pixels = (float) ((dpValue)*TApplication.MainActivity.Resources.DisplayMetrics.Density);
			return pixels;
		}

		partial void NativeGetWidth()
		{
			//TODO: Use nfloat everywhere
			var metrics = TApplication.MainActivity.Resources.DisplayMetrics;
			FWidth=(float)ToDp(metrics.WidthPixels);			
		}

		partial void NativeGetHeight()
		{
			var metrics = TApplication.MainActivity.Resources.DisplayMetrics;
			FHeight=(float)ToDp(metrics.HeightPixels);			
		}
	}

	[Activity (Theme = "@android:style/Theme.Black.NoTitleBar.Fullscreen", ConfigurationChanges=ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
	public class TFormActivity: Activity
	{
		public ViewGroup View;
		public TCustomForm Form;

		private static TList<TCustomForm> FFormStack = null;

		public static TList<TCustomForm> FormStack
		{
			get{
				if (FFormStack == null)
					FFormStack = new TList<TCustomForm> ();

				return(FFormStack);
			}
		}

		public TFormActivity () : base ()
		{
		}

		public override void OnConfigurationChanged (Configuration newConfig)
		{
			base.OnConfigurationChanged (newConfig);
			var w = newConfig.ScreenWidthDp;
			var h = newConfig.ScreenHeightDp;
			Form.SetBounds(0,0,w,h);
			Form.Realign();
		}

		protected override void OnCreate(Bundle bundle)
		{
			ViewGroup existingView = null;

			base.OnCreate(bundle);
			Form = FormStack [0];
			if (Form.handle != null) {
				existingView = Form.handle.View;
			}

			Form.handle = this;
			Form.Handle = Form.handle;
			FormStack.Delete (0);

			if (existingView != null) {
				View = existingView;
				(View.Parent as ViewGroup).RemoveView (View);
				this.SetContentView (View);
			} else {
				View = new AbsoluteLayout (this);
				this.SetContentView (View);
				Form.Loaded ();
			}
		}
		
	}

	public partial class TCustomForm: TScrollingControl
	{
		public TFormActivity handle;

		protected override void CreateNativeHandle()
		{
			//To be created by the activity when invoked
		}

		public override void SetParent(TControl AControl)
		{
			handle.View.AddView (AControl.Handle as View);
		}

		protected override void SetColor(TColor AColor)
		{
			handle.View.SetBackgroundColor((Color)AColor.handle);
		}


		public override void UpdateBounds()
		{
			
		}
	}

	public partial class TForm:TCustomForm
	{
		public override void Close()
		{
			handle.Finish ();
		}

		public override void Show()
		{
			TFormActivity.FormStack.Add (this);
			Intent intent = new Intent (TApplication.context, typeof(TFormActivity));
			TApplication.MainActivity.StartActivity (intent);
			TApplication.MainActivity.Finish ();

		}	
	}
	#endif
}

