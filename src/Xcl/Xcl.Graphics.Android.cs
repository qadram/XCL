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
using System.IO;
using System.Reflection;
using System.Linq;
#if __ANDROID__
using Android.Graphics;
using Android.Widget;
#endif

namespace Xcl.Graphics
{
	#if __ANDROID__
	public partial class TPicture:TPersistent
	{
		//TODO: Change this to Bitmap
		public Bitmap handle;
		public TPicture():base()
		{
			handle = null;
			Handle = handle;
		}

		protected override void AssignTo(TPersistent Dest)
		{
			if (Dest is TPicture) {
				(Dest as TPicture).handle = Bitmap.CreateBitmap (handle);
				(Dest as TPicture).NotifyChanged();
			} else {
				base.AssignTo (Dest);
			}
		}

		public void NotifyChanged()
		{
			if (Notifier!=null) Notifier.Changed();
		}


		public static Stream GetEmbeddedResourceStream(string resourceFileName)
		{
			var assembly = Assembly.GetCallingAssembly();
			var resourceNames = assembly.GetManifestResourceNames();

			var resourcePaths = resourceNames
				.Where(x => x.EndsWith(resourceFileName, StringComparison.CurrentCultureIgnoreCase))
				.ToArray();

			if (!resourcePaths.Any())
			{
				throw new Exception(string.Format("Resource ending with {0} not found.", resourceFileName));
			}

			if (resourcePaths.Count() > 1)
			{
				throw new Exception(string.Format("Multiple resources ending with {0} found: {1}{2}", resourceFileName, Environment.NewLine, string.Join(Environment.NewLine, resourcePaths)));
			}

			return assembly.GetManifestResourceStream(resourcePaths.Single());
		}

		partial void NativeLoadFromResource(string ResourceName)
		{
			//TODO: notify the owner of this TPicture that the image has changed
			var imageStream = Assembly.GetCallingAssembly().GetManifestResourceStream(ResourceName);

			handle = BitmapFactory.DecodeStream(imageStream);

			Handle = handle;
			NotifyChanged();
		}
	}


	public partial class TFont:TGraphicsObject
	{
		//public UIFont handle;

		partial void NativeInitializeFont()
		{
			FName = "sans-serif";
			FSize = 18;
			FColor = new TColor (TColors.clWhite);
		}

		public void NotifyChanged()
		{
			if (Notifier!=null) Notifier.Changed();
		}

		partial void SetName(string AName)
		{
			//handle=UIFont.FromName(AName, FSize);
			//Handle = handle;
			NotifyChanged();
		}

		partial void SetSize(float ASize)
		{
			//handle=UIFont.FromName(FName, ASize);
			//Handle = handle;
			NotifyChanged();
		}

		partial void SetColor(TColor AColor)
		{
			NotifyChanged();
		}

	}
	#endif
}



