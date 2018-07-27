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
using System.Threading;
using Xcl.Controls;
using Xcl.Graphics;
using Xcl.ImgList;

namespace Xcl.ExtCtrls
{
	/// <summary>
	/// Image class to show a picture on screen
	/// </summary>
	public partial class TImage:TGraphicControl, IChangeNotifier
	{
		/// <summary>
		/// Animate this instance. You have to assign an ImageList with the images to be animated
		/// </summary>
		public void Animate()
		{
			NativeAnimate ();
		}

		partial void NativeAnimate();

		public static TImage Create(TComponent AOwner)
		{
			return(new TImage (AOwner));
		}

		public TImage(TComponent AOwner):base(AOwner)
		{
			FPicture = new TPicture ();
			FPicture.Notifier = this;
		}

		private TCustomImageList FImages = null;

		/// <summary>
		/// Gets or sets the images property, to be used when animating
		/// </summary>
		/// <value>The images.</value>
		public TCustomImageList Images
		{
			get{
				return(FImages);
			}
			set{
				FImages = value;
			}
		}


		private TPicture FPicture;

		/// <summary>
		/// Gets or sets the picture to be shown
		/// </summary>
		/// <value>The picture.</value>
		public TPicture Picture
		{
			get{
				return(FPicture);
			}
			set{
				FPicture.Assign (value);
			}
		}

	}


	public partial class TTimer : TComponent
	{
		private int FInterval = 1000;
		public int Interval
		{
			get
			{
				return FInterval;
			}

			set
			{
				NativeSetInterval(value);
				FInterval = value;
			}
			
		}

		private bool FEnabled = true;
		public bool Enabled
		{
			get
			{
				return FEnabled;
			}

			set
			{
				NativeSetEnabled(value);
				FEnabled = value;
			}
		}

		static void DoTimer(Object state)
		{
			(state as TTimer).FOnTimer(state, EventArgs.Empty);

		}

		public static TTimer Create(TComponent AOwner)
		{
			return (new TTimer(AOwner));
		}

		public event TNotifyEvent FOnTimer;
		public event TNotifyEvent OnTimer
		{
			add
			{
				FOnTimer += value;
			}
			remove
			{
				FOnTimer -= value;
			}
		}


		partial void NativeCreateTimer();
		partial void NativeSetInterval(int Value);
		partial void NativeSetEnabled(bool value);

		public TTimer(TComponent AOwner) : base(AOwner)
		{
			NativeCreateTimer();
		}
	}

	public partial class TCustomPanel : TCustomControl
	{
		private TAlignment FAlignment;
		private TAlignment FVerticalAlignment;

		public TCustomPanel(TComponent AOWner) : base(AOWner)
		{			
		
		}
	}

	public partial class TPanel : TCustomPanel
	{
		public TPanel(TComponent AOWner) : base(AOWner)
		{
			
		}

		public static TPanel Create(TComponent AOwner)
		{
			return (new TPanel(AOwner));
		}

	}
}