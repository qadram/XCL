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
using System.Reflection;
using System.Classes;
using System.UITypes;
using Xcl.Controls;

namespace System.Base
{
	using Xcl.Forms;

	public partial class _
	{
		private static TApplication FApplication=null;

		private static TScreen FScreen=null;

		/// <summary>
		/// The global application variable
		/// </summary>
		/// <value>The application.</value>
		public static TApplication Application
		{
			get{
				if (FApplication == null)
					FApplication = new TApplication (null);
				
				return(FApplication);
			}
		}

		/// <summary>
		/// The global screen variable
		/// </summary>
		/// <value>The screen.</value>
		public static TScreen Screen
		{
			get{
				if (FScreen == null)
					FScreen = new TScreen (null);

				return(FScreen);
			}
		}
	}
}
namespace Xcl.Forms
{
	/// <summary>
	/// Application class
	/// </summary>
	public partial class TApplication:TComponent
	{
		public TCustomForm MainForm = null;
		public static Assembly MainAssembly = null;

		public static void CreateForm<T>(ref T Form)
		{
			Form = (T)Activator.CreateInstance (typeof(T), _.Application);

			//First form created is considered the main form
			if (_.Application.MainForm == null) {
				_.Application.MainForm = (Form as TCustomForm);
			}
		}



		partial void NativeInitialize(object param);

		public static void Initialize(object param)
		{
			_.Application.NativeInitialize(param);
		}

		partial void NativeRun();

		public static void Run()
		{
			_.Application.NativeRun();
		}

		public TApplication(TComponent AOwner):base(AOwner)
		{
		}	
	}

	/// <summary>
	/// Screen class
	/// </summary>
	public partial class TScreen:TComponent
	{
		public TScreen(TComponent AOwner):base(AOwner)
		{
		}	

		partial void NativeGetWidth();
		partial void NativeGetHeight();

		private float FWidth=0;
		/// <summary>
		/// Gets the width of the screen
		/// </summary>
		/// <value>The width.</value>
		public float Width
		{
			get{
				NativeGetWidth();
				return(FWidth);
			}
		}

		private float FHeight=0;

		/// <summary>
		/// Gets the height of the screen
		/// </summary>
		/// <value>The height.</value>
		public float Height
		{
			get{
				NativeGetHeight();
				return(FHeight);
			}
		}
	}

	/// <summary>
	/// Base class for any control with scrollbars
	/// </summary>
	public partial class TScrollingControl:TFocusControl
	{
		public TScrollingControl(TComponent AOwner):base(AOwner)
		{
		}	

	}

	/// <summary>
	/// Base class for any Form class
	/// </summary>
	public partial class TCustomForm:TScrollingControl
	{
		public TCustomForm(TComponent AOwner):base(AOwner)
		{
		}	

		public virtual void Close()
		{
		}

		public virtual void Show()
		{
		}

		public virtual void Loaded()
		{
		}

	}

	/// <summary>
	/// Base class for forms
	/// </summary>
	public partial class TForm: TCustomForm
	{
		public new TForm self
		{
			get {
				return(this);
			}
		}

		partial void Initialize();

		public TForm(TComponent AOwner):base(AOwner)
		{
			FLeft = 0;
			FTop = 0;
			FWidth = 200;
			FHeight = 50;
			UpdateBounds ();

			Initialize ();
		}	

	}
}
