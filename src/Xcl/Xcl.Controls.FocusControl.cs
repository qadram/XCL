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
using System.Generics.Collections;
using System.Linq;
using Xcl.Forms;

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
			FControls = new TList<TControl> ();
			// FTabList = new TList<TControl> ();
			// FFocusControls = new TList<TControl> ();
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
				RequestAlign ();
			}
		}

		private int FAlignLevel;
		private TList<TControl> FAlignControlList;

		public TRect GetClientRect()
		{
			return(new TRect (Left, Top, Left+Width, Top+Height));
		}

		private TList<TControl> FControls;

		public TList<TControl> Controls
		{
			get{
				return(FControls);
			}
		}

		public int ControlCount
		{
			get{
				return(FControls.Count());
			}
		}
		/*
		private TList<TControl> FTabList;

		public TList<TControl> TabList
		{
			get{
				return(FTabList);
			}
		}

		private TList<TControl> FFocusControls;

		public TList<TControl> FocusControls
		{
			get{
				return(FFocusControls);
			}
		}
		*/


		private bool AlignWork()
		{
			for (int i=ControlCount-1; i>=0; i--)
			{
				if (Controls [i].Align != TAlign.alNone) {
					return(true);
				}
				//TODO: Anchors
				//if (Controls[I].Align <> alNone) or
				//	(Controls[I].Anchors <> [akLeft, akTop]) then Exit;
			}
			return(false);
		}

		public bool InsertBefore(TControl C1, TControl C2, TAlign AAlign)
		{
			switch (AAlign) {
			//TODO: Use Margins.ControlTop et al
			case TAlign.alTop: 
				return(C1.Top<C2.Top);
			case TAlign.alBottom:
				return((C1.Top + C1.Height) >= (C2.Top + C2.Height));
			case TAlign.alLeft: 
				return(C1.Left<C2.Left);
			case TAlign.alRight:
				return((C1.Left + C1.Width) >= (C2.Left + C2.Width));
			//TODO: alCustom
			default: return(false);
			}
		}

		public TPoint GetClientSize(TFocusControl Control)
		{
			//TODO: Include Padding here
			return(new TPoint (Control.Width,Control.Height));
		}

		public void DoPosition(TControl Control, TAlign AAlign, TAlignInfo AlignInfo, ref TRect Rect)
		{
			ArrangeControl (Control, GetClientSize(Control.Parent), AAlign, AlignInfo, ref Rect);
		}

		public void ArrangeControl(TControl AControl, TPoint ParentSize, TAlign AAlign, TAlignInfo AAlignInfo, ref TRect Rect, bool UpdateAnchorOrigin = false)
		{
			float NewLeft;
			float NewTop;
			float NewWidth;
			float NewHeight;

			//TODO: Anchors here
			if (AAlign==TAlign.alNone)
			{
				/*
				if ((AControl.FOriginalParentSize.X != 0) && (AControl.FOriginalParentSize.Y != 0)) 
				{
					//TODO: Margins here
					NewLeft = AControl.Left;	
					NewTop = AControl.Top;
					NewWidth = AControl.Width;
					NewHeight = AControl.Height;

					//TODO: Anchors here
				}
				*/

				if (AAlign == TAlign.alNone)
					return;
			}

			NewWidth = Rect.Right - Rect.Left;
			if ((NewWidth<0) || ((AAlign==TAlign.alLeft) || (AAlign==TAlign.alRight) || (AAlign==TAlign.alCustom)))
			{
				//TODO: Margins
				NewWidth = AControl.Width;
			}

			NewHeight = Rect.Bottom - Rect.Top;
			if ((NewHeight<0) || ((AAlign==TAlign.alTop) || (AAlign==TAlign.alBottom) || (AAlign==TAlign.alCustom)))
			{
				//TODO: Margins
				NewHeight = AControl.Height;
			}

			NewLeft = Rect.Left;

			NewTop = Rect.Top;

			switch (AAlign) {
			case TAlign.alTop:
				Rect.Top += NewHeight;
				break;
			case TAlign.alBottom:
				Rect.Bottom -= NewHeight;
				NewTop = Rect.Bottom;
				break;
			case TAlign.alLeft:
				Rect.Left += NewWidth;
				break;
			case TAlign.alRight:
				Rect.Right -= NewWidth;
				NewLeft = Rect.Right;
				break;
			//TODO: alCustom
			}

			//TODO: Margin
			AControl.SetBounds(NewLeft, NewTop, NewWidth, NewHeight);

			//TODO: Check margin dimensions
		}


		public void DoAlign(TAlign AAlign, TControl AControl, TList<TControl> AlignList, ref TRect Rect)
		{
			AlignList.Clear();

			if ((AControl!=null) && 
				((AAlign == TAlign.alNone) || (AControl.Visible) || (AControl.ComponentState.isin(TComponentState.csDesigning)) && (!(AControl.ControlStyle.isin(TControlStyle.csNoDesignVisible)))) &&
				(AControl.Align == AAlign))
			{
				AlignList.Add (AControl);	
			}

			for (int i = 0; i <= ControlCount - 1; i++) {
				var Control = Controls [i];

				if ((Control.Align == AAlign) &&
					(
						(AAlign==TAlign.alNone) || 
						((Control.Visible) || (Control.ControlStyle.isequal(TControlStyle.csAcceptsControls, TControlStyle.csNoDesignVisible)) ) ||
						(Control.ComponentState.isin(TComponentState.csDesigning)) &&
						(!Control.ControlStyle.isin(TControlStyle.csNoDesignVisible))
					) &&
					((!(Control is TCustomForm)) || (!Control.ComponentState.isin(TComponentState.csDesigning)))
				  )
				{
					if (Control == AControl)
						continue;

					int J = 0;

					while ((J < AlignList.Count) && (!InsertBefore (Control, AlignList [J], AAlign)))
						J++;

					AlignList.Insert (J, Control);
				}
		
			}

			TAlignInfo AlignInfo = new TAlignInfo ();

			for (int i = 0; i <= AlignList.Count - 1; i++) {
				AlignInfo.AlignList = AlignList;
				AlignInfo.ControlIndex = i;
				AlignInfo.Align = AAlign;
				DoPosition (AlignList [i], AAlign, AlignInfo, ref Rect);
			}
		}


		public void AlignControls(TControl AControl, ref TRect Rect)
		{
			bool UsingParentList;
			TList<TControl> AlignList;
			TList<TControl> LAlignControlList;


			if (AlignWork ()) {
				UsingParentList = false;
				LAlignControlList = null;

				try
				{
					if (FAlignControlList == null) {
						if ((FParent != null) && (FParent.FAlignControlList != null)) {
							// Use align list from parent
							UsingParentList = true;
							FAlignControlList = Parent.FAlignControlList;
						} else {
							// Create list of controls to be aligned
							LAlignControlList = new TList<TControl>();
							FAlignControlList = LAlignControlList;						
						}
					}

					//TODO: Padding
					//AdjustClientRect(Rect);
					AlignList = new TList<TControl> ();
					try
					{
						DoAlign(TAlign.alTop, AControl, AlignList, ref Rect);
						DoAlign(TAlign.alBottom, AControl, AlignList, ref Rect);
						DoAlign(TAlign.alLeft, AControl, AlignList, ref Rect);
						DoAlign(TAlign.alRight, AControl, AlignList, ref Rect);
						DoAlign(TAlign.alClient, AControl, AlignList, ref Rect);
						DoAlign(TAlign.alCustom, AControl, AlignList, ref Rect);
						DoAlign(TAlign.alNone, AControl, AlignList, ref Rect);
						ControlsAligned();					
					}
					finally{
						AlignList = null;
					}
					//TODO: Review this
//					if (Showing)
//						DoAdjustSize();

//					if ((LAlignControlList != null) && (LAlignControlList.Count > 0)) 
//						AlignNestedControls();
				}
				finally {
					if (LAlignControlList != null) {
						FAlignControlList = null;
						LAlignControlList = null;
					}
					else
					{
						if (UsingParentList)
							FAlignControlList = null;
					}
					
				}
			}
			else{
			}
		}

		public virtual void ControlsAligned()
		{
		}

		public void AlignControl(TControl AControl)
		{
			if ((!HandleAllocated ()) || (ComponentState.isin (TComponentState.csDestroying)))
				return;
			if (FAlignLevel != 0)
				ControlState.include (TControlState.csAlignmentNeeded);
			else
			{
				DisableAlign();
				try
				{
					var Rect = GetClientRect();
					AlignControls(AControl, ref Rect);
				}
				finally {
					ControlState.exclude (TControlState.csAlignmentNeeded);					
					EnableAlign();
				}
			}

		}

		public override void RequestAlign()
		{
			bool ParentListAssigned;

			if (Parent != null) {
				ParentListAssigned = false;
				if ((FAlignControlList != null) && (Parent.FAlignControlList != null)) {
					Parent.FAlignControlList = FAlignControlList;
					ParentListAssigned = true;
				}
				try
				{
					base.RequestAlign();
				}
				finally {
					if (ParentListAssigned) {
						Parent.FAlignControlList = null;
					}
				}
			}
		}


		private void DisableAlign()
		{
			FAlignLevel++;
		}

		private void EnableAlign()
		{
			FAlignLevel--;
			if (FAlignLevel==0)
			{
				if (ControlState.isin (TControlState.csAlignmentNeeded))
					Realign ();
			}
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
				/*
				if (AControl is TFocusControl) {
					FFocusControls.Add(AControl);
					FTabList.Add (AControl);
				} else {
					FControls.Add (AControl);
				}
				*/
				FControls.Add (AControl);
				AControl.FParent = this;
				SetParent (AControl);
			}					
		}

		private void Remove(TControl AControl)
		{
			if (AControl != null) {
				/*
				if (AControl is TFocusControl) {
					FFocusControls.Remove(AControl);
					FTabList.Remove (AControl);

				} else {
					FControls.Remove (AControl);
				}
				*/
				FControls.Remove (AControl);
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
