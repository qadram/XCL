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
#if __ANDROID__
using Android.Graphics;
#endif

namespace System.UITypes
{
	#if __ANDROID__
	public partial struct TRect
	{
		public RectF ToRectF()
		{
			return(new RectF(Left, Top, Left+Width, Top+Height));
		}
	}

	public partial class TColor
	{
		/// <summary>
		/// Sets the handle to the Android color created from the RGB triplet
		/// </summary>
		/// <param name="R">R.</param>
		/// <param name="G">G.</param>
		/// <param name="B">B.</param>
		partial void NativeFromRGB(byte R, byte G, byte B)
		{
			handle = Color.Rgb(R, G, B);

		}
		partial void CreateHandle(TColors AColor)
		{
			switch(AColor)
			{
			case 
				TColors.clBlack: handle = Color.Black; 
				break;
			case 
				TColors.clMaroon: handle = Color.Rgb(0x80,0,0); 
				break;
			case 
				TColors.clGreen: handle = Color.Rgb(0,0x80,0); 
				break;
			case 
				TColors.clOlive: handle = Color.Rgb(0x80,0x80,0); 
				break;
			case 
				TColors.clNavy: handle = Color.Rgb(0,0,0x80); 
				break;
			case 
				TColors.clPurple: handle = Color.Purple; 
				break;
			case 
				TColors.clTeal: handle = Color.Rgb(0,0x80,0x80); 
				break;
			case 
				TColors.clGray: handle = Color.Gray; 
				break;
			case 
				TColors.clSilver: handle = Color.LightGray; 
				break;
			case 
				TColors.clRed: handle = Color.Red; 
				break;
			case 
				TColors.clLime: handle = Color.Green; 
				break;
			case 
				TColors.clYellow: handle = Color.Yellow; 
				break;
			case 
				TColors.clBlue: handle = Color.Blue; 
				break;
			case 
				TColors.clFuchsia: handle = Color.Magenta; 
				break;
			case 
				TColors.clAqua: handle = Color.Cyan; 
				break;
			case 
				TColors.clLtGray: handle = Color.LightGray; 
				break;
			case 
				TColors.clDkGray: handle = Color.DarkGray; 
				break;
			case 
				TColors.clWhite: handle = Color.White; 
				break;
			case 
				TColors.clNone: handle = Color.Transparent; 
				break;
			default:
				handle = Color.Transparent;
				break;				
			}
		}
	}
	#endif

}

