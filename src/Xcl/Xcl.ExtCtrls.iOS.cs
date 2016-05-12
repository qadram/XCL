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
#if __IOS__
using UIKit;
using System.Drawing;
#endif
namespace Xcl.ExtCtrls
{
	#if __IOS__
	public partial class TImage:TGraphicControl
	{
		public UIImageView imageview;

		protected UIImage FImage;

		private int CurrentImage=0;

		protected override void CreateHandle()
		{
			FImage = new UIImage();
			imageview = new UIImageView ();
			Handle = imageview;
		}


		//TODO: Move this to the portable class
		partial void NativeAnimate()
		{
			UIView.Transition(imageview,5.0f,UIViewAnimationOptions.TransitionCrossDissolve,delegate {
				Picture.Assign(Images.Items[CurrentImage]);
			}, delegate {
				CurrentImage++;
				if (CurrentImage>=Images.Count) CurrentImage=0;
				this.Animate();
			});

		}

		public override void NativeChanged()
		{
			imageview.Image=FPicture.handle;
		}

	}
	#endif
}

