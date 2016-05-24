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
using System.SysUtils;
using System.Classes;

namespace System.UITypes
{
	/// <summary>
	/// Anchor kind
	/// </summary>
	public enum TAnchors {akLeft=1, akTop=2, akRight=4, akBottom=8};

	public partial struct TRect
	{
		public TRect (float Left, float Top, float Width, float Height)
		{
			this.Left = Left;
			this.Top = Top;
			this.Width = Width;
			this.Height = Height;
		}

		public float Left { get; set; }
		public float Top { get; set; }
		public float Width { get; set; }
		public float Height { get; set; }

	}


	/// <summary>
	/// Default colors
	/// </summary>
	public enum TColors {clNone, clBlack, clMaroon, clGreen, clOlive, clNavy, clPurple, clTeal, clGray, clSilver, clRed, clLime, clYellow, clBlue, clFuchsia, clAqua, clLtGray, clDkGray, clWhite};

	public enum TMouseButton {mbLeft, mbRight, mbMiddle};

	/// <summary>
	/// Color wrapper
	/// </summary>
	public partial class TColor: TObject
	{
		public object handle;

		/// <summary>
		/// Creates the handle.
		/// </summary>
		/// <param name="AColor">A color.</param>
		partial void CreateHandle(TColors AColor);

		/// <summary>
		/// Initializes a new instance of the <see cref="System.UITypes.TColor"/> class using a color from the set
		/// </summary>
		/// <param name="AColor">A color.</param>
		public TColor(TColors AColor)
		{
			CreateHandle (AColor);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="System.UITypes.TColor"/> class from an RGB triplet
		/// </summary>
		/// <param name="R">R.</param>
		/// <param name="G">G.</param>
		/// <param name="B">B.</param>
		public TColor(byte R, byte G, byte B)
		{
			NativeFromRGB (R, G, B);
		}

		/// <summary>
		/// Native implementation to set handle to the color from an RGB triplet
		/// </summary>
		/// <param name="R">R.</param>
		/// <param name="G">G.</param>
		/// <param name="B">B.</param>
		partial void NativeFromRGB(byte R, byte G, byte B);

		/// <summary>
		/// Creates a TColor from the specified R, G and B.
		/// </summary>
		/// <param name="R">R.</param>
		/// <param name="G">G.</param>
		/// <param name="B">B.</param>
		public static TColor RGB (byte R, byte G, byte B)
		{
			return(new TColor (R, G, B));
		}

		public static TColor clNone { 
			get { 
				return(new TColor(TColors.clNone));
			}
		}

		public static TColor clBlack { 
			get { 
				return(new TColor(TColors.clBlack));
			}
		}

		public static TColor clMaroon { 
			get { 
				return(new TColor(TColors.clMaroon));
			}
		}

		public static TColor clGreen { 
			get { 
				return(new TColor(TColors.clGreen));
			}
		}

		public static TColor clOlive { 
			get { 
				return(new TColor(TColors.clOlive));
			}
		}

		public static TColor clNavy { 
			get { 
				return(new TColor(TColors.clNavy));
			}
		}

		public static TColor clPurple { 
			get { 
				return(new TColor(TColors.clPurple));
			}
		}

		public static TColor clTeal { 
			get { 
				return(new TColor(TColors.clTeal));
			}
		}

		public static TColor clSilver { 
			get { 
				return(new TColor(TColors.clSilver));
			}
		}

		public static TColor clRed { 
			get { 
				return(new TColor(TColors.clRed));
			}
		}

		public static TColor clLime { 
			get { 
				return(new TColor(TColors.clLime));
			}
		}

		public static TColor clYellow { 
			get { 
				return(new TColor(TColors.clYellow));
			}
		}

		public static TColor clBlue { 
			get { 
				return(new TColor(TColors.clBlue));
			}
		}

		public static TColor clFuchsia { 
			get { 
				return(new TColor(TColors.clFuchsia));
			}
		}

		public static TColor clAqua { 
			get { 
				return(new TColor(TColors.clAqua));
			}
		}

		public static TColor clLtGray { 
			get { 
				return(new TColor(TColors.clLtGray));
			}
		}

		public static TColor clDkGray { 
			get { 
				return(new TColor(TColors.clDkGray));
			}
		}

		public static TColor clWhite { 
			get { 
				return(new TColor(TColors.clWhite));
			}
		}
	}
}