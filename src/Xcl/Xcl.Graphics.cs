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

namespace Xcl.Graphics
{
	public partial class TPicture:TPersistent
	{
		/// <summary>
		/// Returns a TPicture object created from a resource image
		/// </summary>
		/// <returns>The resource.</returns>
		/// <param name="ResourceName">Resource name.</param>
		public static TPicture FromResource(string ResourceName)
		{
			var picture = new TPicture ();
			picture.LoadFromResource (ResourceName);
			return(picture);
		}

		/// <summary>
		/// Loads from resource.
		/// </summary>
		/// <param name="ResourceName">Resource name.</param>
		public void LoadFromResource(string ResourceName)
		{
			NativeLoadFromResource (ResourceName);
		}

		partial void NativeLoadFromResource(string ResourceName);

	}

	/// <summary>
	/// Base class for graphics objects
	/// </summary>
	public partial class TGraphicsObject:TPersistent
	{
	}


	/// <summary>
	/// Font encapsulation
	/// </summary>
	public partial class TFont:TGraphicsObject
	{
		protected string FName;
		protected float FSize;
		protected TColor FColor;

		partial void NativeInitializeFont();

		public TFont():base()
		{
			NativeInitializeFont();
		}

		partial void SetName(string AName);
     	partial void SetSize(float ASize);
		partial void SetColor(TColor AColor);

		/// <summary>
		/// Gets or sets the size.
		/// </summary>
		/// <value>The size.</value>
		public float Size
		{
			get {
				return(FSize);
			}
			set{
				FSize = value;
				SetSize (value);
			}

		}

		/// <summary>
		/// Gets or sets the color.
		/// </summary>
		/// <value>The color.</value>
		public TColor Color
		{
			get {
				return(FColor);
			}
			set{
				FColor = value;
				SetColor (value);
			}
					
		}

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get {
				return(FName);
			}
			set{
				FName = value;
				SetName (value);
			}
		}
	}
}

