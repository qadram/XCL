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
using Xcl.Graphics;
using System.Generics.Collections;
using System.ImageList;

namespace Xcl.ImgList
{
	/// <summary>
	/// Base class for ImageList
	/// </summary>
	public partial class TCustomImageList:TBaseImageList
	{
		private TList<TPicture> FImages;

		public TCustomImageList(TComponent AOwner):base(AOwner)
		{
			FImages = new TList<TPicture> ();

		}

		protected override int GetCount ()
		{
			return(FImages.Count);
		}

		/// <summary>
		/// Gets the items.
		/// </summary>
		/// <value>The items.</value>
		public TList<TPicture> Items
		{
			get{
				return(FImages);
			}
		}

		/// <summary>
		/// Add the specified Image.
		/// </summary>
		/// <param name="Image">Image.</param>
		public int Add(TPicture Image)
		{
			FImages.Add (Image);
			return(FImages.Count);
		}

	}
}



