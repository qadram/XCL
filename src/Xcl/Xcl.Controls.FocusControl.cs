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
using Xcl.ImgList;
using Xcl.Graphics;
using System.Linq;

namespace Xcl.Controls
{
	public struct TControlListItem
	{
		public TControl Control;
		public TFocusControl Parent;
	}

	/// <summary>
	/// Base class for controls that can get the focus
	/// </summary>
	public partial class TFocusControl:TControl{

		public TFocusControl(TComponent AOwner):base(AOwner)
		{

		}	


		public override void SetBounds (float ALeft, float ATop, float AWidth, float AHeight)
		{
			if (((ALeft != FLeft) || (ATop != FTop) || (AWidth != FWidth) || (AHeight != FHeight))) {	
				FLeft = ALeft;
				FTop = ATop;
				FWidth = AWidth;
				FHeight = AHeight;
				UpdateBounds ();			
				//UpdateAnchorRules ();
				//UpdateExplicitBounds ();
				//RequestAlign ();
			}
		}


		private void AlignControl(TControl AControl)
		{
		}

		protected virtual void ControlChange(bool Inserting, TControl Child)
		{
		}

		protected virtual void ControlListChange(bool Inserting, TControl Child)
		{
			if (Parent != null)
				Parent.ControlListChange (Inserting, Child);
		}

		protected virtual void ControlListChanging(bool Inserting, TControl Child, TFocusControl AParent)
		{
			if (Parent != null)
				Parent.ControlListChanging (Inserting, Child, AParent);
		}

		protected virtual void ControlListChanging(bool Inserting, TControlListItem Item)
		{
			ControlListChanging (Inserting, Item.Control, Item.Parent);
		}


		public void RemoveFocus(bool Removing)
		{
			//TODO:
		}

		public void DestroyHandle()
		{
			//TODO: Destroy here the handle to the actual object if needed
			//TODO: Review Dispose()

		}


		public bool HandleAllocated()
		{
			return(Handle!=null);
		}

		public void Realign()
		{
			AlignControl (null);
		}

		public void RemoveControl(TControl AControl)
		{
			ControlChange (false, AControl);
			if (AControl is TFocusControl) {
				(AControl as TFocusControl).RemoveFocus (true);
				(AControl as TFocusControl).DestroyHandle ();
			} else {
				if (HandleAllocated ()) {
					AControl.InvalidateControl (AControl.Visible, false);
				}
			}
			Remove (AControl);
			ControlListChange (false, AControl);
			ControlListChanging (false, AControl, this);
			Realign ();
		}


		private bool FShowing;
		private bool FPerformingShowingChanged;

		public bool Showing
		{
			get { return(FShowing); }
		}

		public void UpdateControlState()
		{
			TFocusControl Control = this;

			while (Control.Parent != null) {
				Control = Control.Parent;
				if (!Control.Showing) {
					if ((FShowing) && (!FPerformingShowingChanged)) {
						FPerformingShowingChanged = true;
						try{
							FShowing = false;
							//TODO:
						}
						finally{
							FPerformingShowingChanged = false;
						}
					}
					return;	
				}
			}
			//TODO:
		}

		partial void NativeSetParent(TControl AControl);

		public virtual void SetParent(TControl AControl)
		{
			NativeSetParent (AControl);		
		}

		private void Insert(TControl AControl)
		{
			if (AControl != null) {
				if (AControl is TFocusControl) {
					//TODO:
				} else {
					//TODO:
				}
				AControl.FParent = this;
				SetParent (AControl);
			}					
		}

		private void Remove(TControl AControl)
		{
			if (AControl != null) {
				if (AControl is TFocusControl) {
					//TODO:
				} else {
					//TODO:
				}
				AControl.FParent = null;
				//TODO:
			}					
		}

		public void InsertControl(TControl AControl)
		{
			AControl.ValidateContainer (this);
			TControlListItem Item;
			Item.Control = AControl;
			Item.Parent = this;
			ControlListChanging (true, Item);
			if (Item.Parent != this)
				return;
			ControlListChange (true, AControl);
			Insert(AControl);

			if (!(AControl.ComponentState.isin(TComponentState.csReading))) {
				if (AControl is TFocusControl) {
					//TODO:
					UpdateControlState ();
				} else {
					if (HandleAllocated ())
						AControl.Invalidate ();
				}
				AlignControl (AControl);

			}
		}
	}
}
