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
#endif

namespace Xcl.Graphics
{
	#if __IOS__
	public partial class TPicture:TPersistent
	{
		public UIImage handle;
		public TPicture():base()
		{
			handle = new UIImage ();
			Handle = handle;
		}

		protected override void AssignTo(TPersistent Dest)
		{
			if (Dest is TPicture) {
				var data = handle.AsPNG ();
				(Dest as TPicture).handle.Dispose ();
				(Dest as TPicture).handle = UIImage.LoadFromData (data);
				data.Dispose ();
				(Dest as TPicture).NotifyChanged();
			} else {
				base.AssignTo (Dest);
			}
		}

		public void NotifyChanged()
		{
			if (Notifier!=null) Notifier.Changed();
		}


		partial void NativeLoadFromResource(string ResourceName)
		{
			//TODO: notify the owner of this TPicture that the image has changed
			//TODO: Review to change this to be an embedded resource instead to be in the bundle
			handle = UIImage.FromBundle(ResourceName);		
			Handle = handle;
			NotifyChanged();
		}
	}

	public partial class TFont:TGraphicsObject
	{
		public UIFont handle;

		public void NotifyChanged()
		{
			if (Notifier!=null) Notifier.Changed();
		}

		partial void SetName(string AName)
		{
			handle=UIFont.FromName(AName, FSize);
			Handle = handle;
			NotifyChanged();
		}

		partial void SetSize(float ASize)
		{
			handle=UIFont.FromName(FName, ASize);
			Handle = handle;
			NotifyChanged();
		}

		partial void SetColor(TColor AColor)
		{
			NotifyChanged();
		}

	}
	#endif
}


