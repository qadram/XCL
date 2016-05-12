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
using Xcl.Forms;
using Xcl.Graphics;
#if __ANDROID__
using Android.Graphics;
using Android.Widget;
using Android.Animation;
using Android.Views.Animations;
using Android.Graphics.Drawables;
#endif
namespace Xcl.ExtCtrls
{
	#if __ANDROID__
	public partial class TImage:TGraphicControl
	{
		public ImageView handle;

		private int CurrentImage=0;
		private int BackgroundImage=0;

		protected override void CreateHandle()
		{
			handle = new ImageView (TApplication.context);
			handle.SetScaleType (ImageView.ScaleType.FitXy);
			Handle = handle;
		}


		//TODO: Move this to the portable class
		partial void NativeAnimate()
		{
			if ((CurrentImage==0) && (BackgroundImage==0))
			{
				BackgroundImage=1;

				//Set the one on the background to the next image
				var pic2 = Images.Items[BackgroundImage];
				var bmd = new BitmapDrawable (pic2.handle);
				handle.Background = bmd;
			}
			else
			{
				CurrentImage++;
				if (CurrentImage>=Images.Count) CurrentImage=0;

				BackgroundImage++;
				if (BackgroundImage>=Images.Count) BackgroundImage=0;
			}

			//Set the current image to the one that was on the background
			Picture.Assign(Images.Items[CurrentImage]);
			handle.ImageAlpha = 255;


			//Detect the initial case where the background image is empty
			// Set the background image to the current image + 1
			// Detect overload
			// Set the picture image alpha to 255
			ObjectAnimator animator = ObjectAnimator.OfInt(handle, "ImageAlpha", 255, 0);
			animator.SetDuration(5000);
			animator.Update+= (object sender, ValueAnimator.AnimatorUpdateEventArgs e) =>
			{
				int newValue = (int) e.Animation.AnimatedValue;

				if (newValue==254)
				{
					//Set the one on the background to the next image
					var pic2 = Images.Items[BackgroundImage];
					var bmd = new BitmapDrawable (pic2.handle);
					handle.Background = bmd;

				}

				if (newValue==0)
				{
					this.Animate();
				}
			};
			animator.Start();
		}

		public override void NativeChanged()
		{
			handle.SetImageBitmap(FPicture.handle);
		}


	}
	#endif
}


