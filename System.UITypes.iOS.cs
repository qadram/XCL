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
#if __IOS__
using UIKit;
#endif

namespace System.UITypes
{
	#if __IOS__
	public partial class TColor
	{
		/// <summary>
		/// Sets the handle to the UIColor created from an RGB triplet
		/// </summary>
		/// <param name="R">R.</param>
		/// <param name="G">G.</param>
		/// <param name="B">B.</param>
		partial void NativeFromRGB(byte R, byte G, byte B)
		{
			handle = UIColor.FromRGB(R, G, B);

		}

		/// <summary>
		/// Creates the handle to the UIColor specified by AColor
		/// </summary>
		/// <param name="AColor">A color.</param>
		partial void CreateHandle(TColors AColor)
		{
			switch(AColor)
			{
			case 
				TColors.clBlack: handle = UIColor.Black; 
				break;
			case 
				TColors.clMaroon: handle = UIColor.FromRGB(0x80,0,0); 
				break;
			case 
				TColors.clGreen: handle = UIColor.FromRGB(0,0x80,0); 
				break;
			case 
				TColors.clOlive: handle = UIColor.FromRGB(0x80,0x80,0); 
				break;
			case 
				TColors.clNavy: handle = UIColor.FromRGB(0,0,0x80); 
				break;
			case 
				TColors.clPurple: handle = UIColor.Purple; 
				break;
			case 
				TColors.clTeal: handle = UIColor.FromRGB(0,0x80,0x80); 
				break;
			case 
				TColors.clGray: handle = UIColor.Gray; 
				break;
			case 
				TColors.clSilver: handle = UIColor.LightGray; 
				break;
			case 
				TColors.clRed: handle = UIColor.Red; 
				break;
			case 
				TColors.clLime: handle = UIColor.Green; 
				break;
			case 
				TColors.clYellow: handle = UIColor.Yellow; 
				break;
			case 
				TColors.clBlue: handle = UIColor.Blue; 
				break;
			case 
				TColors.clFuchsia: handle = UIColor.Magenta; 
				break;
			case 
				TColors.clAqua: handle = UIColor.Cyan; 
				break;
			case 
				TColors.clLtGray: handle = UIColor.LightGray; 
				break;
			case 
				TColors.clDkGray: handle = UIColor.DarkGray; 
				break;
			case 
				TColors.clWhite: handle = UIColor.White; 
				break;

			default:
				handle = UIColor.Clear;
				break;				
			}
			/*
			Black	UIColor. A color with grayscale 0.0 and alpha 1.0.
			Blue	UIColor. A color with RGBA of (0,0,1,1).
			Brown	UIColor. A color with RGBA of (0.6, 0.4, 0.2, 1.0).
			Cyan	UIColor. A color with RGBA of (0, 1, 1, 1).
			DarkGray	UIColor. A color with grayscale 1/3 and alpha 1.
			Gray	UIColor. A color object with grayscale 0.5 and alpha 1.0.
			Green	UIColor. A color with RGBA of (0,1,0,1).
			LightGray	UIColor. A color with grayscale 2/3 and alpha 1.
			Magenta	UIColor. A color with RGBA of (1,0,1,1).
			Orange	UIColor. A color with RGBA of (1.0, 0.5, 0.0, 1.0).
			Purple	UIColor. A color with RGBA of (0.5, 0.0, 0.5, 1.0).
			Red	UIColor. A color with RGBA of (1,0,0,1).
			White	UIColor. A color with grayscale 1 and alpha 1.
			Yellow	UIColor. A color with RGBA of (1, 1, 0, 1).

			handle = UIColor.Red;
			*/
		}
	}
	#endif

}
