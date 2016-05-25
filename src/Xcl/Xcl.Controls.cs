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
	/// <summary>
	/// Base class for any control
	/// </summary>
	public partial class TControl:TComponent,IChangeNotifier
	{
		public TControl(TComponent AOwner):base(AOwner)
		{
			FControlStyle = new TControlStyle (0);
			FFont = new TFont ();
			FFont.Notifier = this;
			FColor = new TColor (TColors.clNone);
			CreateNativeHandle ();
		}

		/// <summary>
		/// Called to create the handle, override in the native implementations
		/// to actually create the native object
		/// </summary>
		protected virtual void CreateNativeHandle()
		{

		}

		/// <summary>
		/// Called to attach a native event, override in the native implementations
		/// to attach/detach the EventHandler to the EventName
		/// 
		/// If the native event needs an event handler of different type, you should ignore
		/// value and use your own handler to: process parameters and convert them to the 
		/// xcl parameter types
		/// </summary>
		/// <param name="Add">If set to <c>true</c> add.</param>
		/// <param name="EventName">Event name.</param>
		/// <param name="value">Value.</param>
		protected virtual void NativeEvent (bool Add, string EventName, EventHandler value)
		{
		}


		#region Events
		//OnMouseDown event
		protected void DoMouseDown (object sender, EventArgs e)
		{
			DoEvent (FOnMouseDown, sender, new TMouseEventArgs(TMouseButton.mbLeft, TShiftState.ssLeft, 0,0));
		}

		private event TMouseEvent FOnMouseDown;
		public event TMouseEvent OnMouseDown
		{
			add{
			    if (FOnMouseDown==null)	NativeEvent(true, "OnMouseDown", DoMouseDown);
				FOnMouseDown+=value;
			}
			remove{
				NativeEvent(false, "OnMouseDown", DoMouseDown);
				FOnMouseDown -= value;
			}
		}

		//OnClick event
		protected void DoClick (object sender, EventArgs e)
		{
			DoEvent (FOnClick, sender, e);
		}

		protected event TNotifyEvent FOnClick;
		public event TNotifyEvent OnClick
		{
			add{
				if (FOnClick==null)	NativeEvent(true, "OnClick", DoClick);
				FOnClick+=value;
			}
			remove{
				NativeEvent(false, "OnClick", DoClick);
				FOnClick -= value;
			}
		}

		//OnTouchDown event
		protected void DoTouchDown (object sender, EventArgs e)
		{
			DoEvent (FOnTouchDown, sender, e);
		}

		protected event TNotifyEvent FOnTouchDown;
		public event TNotifyEvent OnTouchDown
		{
			add{
				if (FOnTouchDown==null)	NativeEvent(true, "OnTouchDown", DoTouchDown);
				FOnTouchDown+=value;
			}
			remove{
				NativeEvent(false, "OnTouchDown", DoTouchDown);
				FOnTouchDown -= value;
			}
		}

		//OnTouchDownRepeat event
		protected void DoTouchDownRepeat (object sender, EventArgs e)
		{
			DoEvent (FOnTouchDownRepeat, sender, e);
		}

		protected event TNotifyEvent FOnTouchDownRepeat;
		public event TNotifyEvent OnTouchDownRepeat
		{
			add{
				if (FOnTouchDownRepeat==null)	NativeEvent(true, "OnTouchDownRepeat", DoTouchDownRepeat);
				FOnTouchDownRepeat+=value;
			}
			remove{
				NativeEvent(false, "OnTouchDownRepeat", DoTouchDownRepeat);
				FOnTouchDownRepeat -= value;
			}
		}


		//OnTouchDragEnter event
		protected void DoTouchDragEnter (object sender, EventArgs e)
		{
			DoEvent (FOnTouchDragEnter, sender, e);
		}

		protected event TNotifyEvent FOnTouchDragEnter;
		public event TNotifyEvent OnTouchDragEnter
		{
			add{
				if (FOnTouchDragEnter==null)	NativeEvent(true, "OnTouchDragEnter", DoTouchDragEnter);
				FOnTouchDragEnter+=value;
			}
			remove{
				NativeEvent(false, "OnTouchDragEnter", DoTouchDragEnter);
				FOnTouchDragEnter -= value;
			}
		}

		//OnTouchDragExit event
		protected void DoTouchDragExit (object sender, EventArgs e)
		{
			DoEvent (FOnTouchDragExit, sender, e);
		}

		protected event TNotifyEvent FOnTouchDragExit;
		public event TNotifyEvent OnTouchDragExit
		{
			add{
				if (FOnTouchDragExit==null)	NativeEvent(true, "OnTouchDragExit", DoTouchDragExit);
				FOnTouchDragExit+=value;
			}
			remove{
				NativeEvent(false, "OnTouchDragExit", DoTouchDragExit);
				FOnTouchDragExit -= value;
			}
		}

		//OnTouchDragInside event
		protected void DoTouchDragInside (object sender, EventArgs e)
		{
			DoEvent (FOnTouchDragInside, sender, e);
		}

		protected event TNotifyEvent FOnTouchDragInside;
		public event TNotifyEvent OnTouchDragInside
		{
			add{
				if (FOnTouchDragInside==null)	NativeEvent(true, "OnTouchDragInside", DoTouchDragInside);
				FOnTouchDragInside+=value;
			}
			remove{
				NativeEvent(false, "OnTouchDragInside", DoTouchDragInside);
				FOnTouchDragInside -= value;
			}
		}

		//OnTouchDragOutside event
		protected void DoTouchDragOutside (object sender, EventArgs e)
		{
			DoEvent (FOnTouchDragOutside, sender, e);
		}

		protected event TNotifyEvent FOnTouchDragOutside;
		public event TNotifyEvent OnTouchDragOutside
		{
			add{
				if (FOnTouchDragOutside==null)	NativeEvent(true, "OnTouchDragOutside", DoTouchDragOutside);
				FOnTouchDragOutside+=value;
			}
			remove{
				NativeEvent(false, "OnTouchDragOutside", DoTouchDragOutside);
				FOnTouchDragOutside -= value;
			}
		}

		//OnTouchUpInside event
		protected void DoTouchUpInside (object sender, EventArgs e)
		{
			DoEvent (FOnTouchUpInside, sender, e);
		}

		protected event TNotifyEvent FOnTouchUpInside;
		public event TNotifyEvent OnTouchUpInside
		{
			add{
				if (FOnTouchUpInside==null)	NativeEvent(true, "OnTouchUpInside", DoTouchUpInside);
				FOnTouchUpInside+=value;
			}
			remove{
				NativeEvent(false, "OnTouchUpInside", DoTouchUpInside);
				FOnTouchUpInside -= value;
			}
		}

		//OnTouchUpOutside event
		protected void DoTouchUpOutside (object sender, EventArgs e)
		{
			DoEvent (FOnTouchUpOutside, sender, e);
		}

		protected event TNotifyEvent FOnTouchUpOutside;
		public event TNotifyEvent OnTouchUpOutside
		{
			add{
				if (FOnTouchUpOutside==null)	NativeEvent(true, "OnTouchUpOutside", DoTouchUpOutside);
				FOnTouchUpOutside+=value;
			}
			remove{
				NativeEvent(false, "OnTouchUpOutside", DoTouchUpOutside);
				FOnTouchUpOutside -= value;
			}
		}

		#endregion




		internal TFocusControl FParent;

		protected float FLeft;
		protected float FTop;
		protected float FWidth;
		protected float FHeight;


		private float FExplicitLeft;
		private float FExplicitTop;
		private float FExplicitWidth;
		private float FExplicitHeight;

		private TControlState FControlState;
		private TControlStyle FControlStyle;
		private TScalingFlags FScalingFlags;

		public bool AnchorMove { get; set; }


		protected TFont FFont;

		/// <summary>
		/// Gets or sets the font.
		/// </summary>
		/// <value>The font.</value>
		public TFont Font
		{
			get {
				return(FFont);
			}
			set {
				FFont.Assign (value);
			}
		}

		public virtual void NativeChanged()
		{
		}

		/// <summary>
		/// Invoked when a complex property has been changed and the native control needs to be updated
		/// </summary>
		public virtual void Changed()
		{
			NativeChanged ();
		}

		public virtual void NativeSetEnabled()
		{
		}

		private bool FEnabled=true;
		public bool Enabled
		{
			get{
				return(FEnabled);
			}
			set {
				FEnabled = value;
				NativeSetEnabled ();
			}
		}



		partial void NativeSetColor(TColor AColor);
		protected virtual void SetColor(TColor AColor)
		{
			NativeSetColor (AColor);
		}

		private TColor FColor;
		/// <summary>
		/// Gets or sets the color.
		/// </summary>
		/// <value>The color.</value>
		public TColor Color
		{
			get{
				return(FColor);
			}
			set{
				FColor = value;
				SetColor (value);	
			}
		}

		public override void SetName(string NewName)
		{
			var ChangeText = (
				(ControlStyle.isin(TControlStyle.csSetCaption)) &&
				(!ComponentState.isin(TComponentState.csLoading)) && 
				(Name == FText) &&
				(Owner == null) || 
				(!(Owner is TControl)) ||
				(!(((TControl)Owner).ComponentState.isin(TComponentState.csLoading)))
			    );
			
			base.SetName(NewName);
			//TODO: Should be Text, not Caption
			if (ChangeText) Caption = NewName;

		}

		private string FText;

		//TODO: Review this 
		public virtual string GetText()
		{
			return(FText);
		}

		public virtual void SetText(string Value)
		{
			FText = Value;
		}

		/// <summary>
		/// Gets or sets the caption.
		/// </summary>
		/// <value>The caption.</value>
		public string Caption
		{
			get {
				return(GetText());
			}
			set{
				SetText (value);
			}
		}

		/// <summary>
		/// Gets or sets the caption.
		/// </summary>
		/// <value>The caption.</value>
		public string Text
		{
			get {
				return(GetText());
			}
			set{
				SetText (value);
			}
		}

		private bool CheckNewSize(ref float NewWidth, ref float NewHeight)
		{
			//TODO:
			return(true);
		}

		partial void NativeUpdateBounds();

		/// <summary>
		/// Updates the bounds of the control
		/// </summary>
		public virtual void UpdateBounds()
		{
			NativeUpdateBounds ();
		}

		public TRect BoundsRect
		{
			get{
				return(new TRect (Left, Top, Width, Height));	
			}
		}

		/// <summary>
		/// Sets the bounds for the control
		/// </summary>
		/// <param name="ALeft">A left.</param>
		/// <param name="ATop">A top.</param>
		/// <param name="AWidth">A width.</param>
		/// <param name="AHeight">A height.</param>
		public virtual void SetBounds (float ALeft, float ATop, float AWidth, float AHeight)
		{
			if ((CheckNewSize (ref AWidth, ref AHeight)) && ((ALeft != FLeft) || (ATop != FTop) || (AWidth != FWidth) || (AHeight != FHeight))) {
				InvalidateControl (Visible, false);
				FLeft = ALeft;
				FTop = ATop;
				FWidth = AWidth;
				FHeight = AHeight;
				UpdateAnchorRules ();
				//TODO:
				Invalidate ();
			}
		}

		/// <summary>
		/// Gets or sets the state of the control.
		/// </summary>
		/// <value>The state of the control.</value>
		public TControlState ControlState {
			get {
				return(FControlState);
			}
			set{
				FControlState = value;
			}
		}

		/// <summary>
		/// Gets or sets the control style.
		/// </summary>
		/// <value>The control style.</value>
		public TControlStyle ControlStyle
		{
			get{
				return(FControlStyle);
			}
			set{
				FControlStyle = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Xcl.Controls.TControl"/> align with margins.
		/// </summary>
		/// <value><c>true</c> if align with margins; otherwise, <c>false</c>.</value>
		public bool AlignWithMargins
		{
			get {
				return((ControlStyle.isin(TControlStyle.csAlignWithMargins)));
			}
			set{
			
			}
		}

		/// <summary>
		/// Gets or sets the left position
		/// </summary>
		/// <value>The left.</value>
		public float Left
		{
			get
			{
				return(FLeft);
			}
			set
			{
				SetBounds (value, FTop, FWidth, FHeight);
				FScalingFlags = FScalingFlags | TScalingFlags.sfLeft;

				if (ComponentState.isin(TComponentState.csReading)) {
					FExplicitLeft = FLeft;
				}
			}
		}

		/// <summary>
		/// Gets or sets the top position
		/// </summary>
		/// <value>The top.</value>
		public float Top
		{
			get
			{
				return(FTop);
			}
			set
			{
				SetBounds (FLeft, value, FWidth, FHeight);
				FScalingFlags = FScalingFlags | TScalingFlags.sfTop;

				if (ComponentState.isin(TComponentState.csReading)) {
					FExplicitTop = FTop;
				}
			}
		}

		/// <summary>
		/// Gets or sets the width.
		/// </summary>
		/// <value>The width.</value>
		public float Width
		{
			get
			{
				return(FWidth);
			}
			set
			{
				SetBounds (FLeft, FTop, value, FHeight);
				FScalingFlags = FScalingFlags | TScalingFlags.sfWidth;

				if (ComponentState.isin(TComponentState.csReading)) {
					FExplicitWidth = FWidth;
				}
			}
		}

		/// <summary>
		/// Gets or sets the height.
		/// </summary>
		/// <value>The height.</value>
		public float Height
		{
			get
			{
				return(FHeight);
			}
			set
			{
				SetBounds (FLeft, FTop, FWidth, value);
				FScalingFlags = FScalingFlags | TScalingFlags.sfHeight;

				if (ComponentState.isin(TComponentState.csReading)) {
					FExplicitHeight = FHeight;
				}
			}
		}

		partial void NativeSetVisible(bool value);

		public virtual void SetVisible(bool value)
		{
			NativeSetVisible (value);
		}

		private bool FVisible = true;

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Xcl.Controls.TControl"/> is visible.
		/// </summary>
		/// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
		public bool Visible
		{
			get{
				return(FVisible);
			}
			set{
				FVisible = value;
				SetVisible (FVisible);
				//TODO:
			}
		}

		/// <summary>
		/// Gets or sets the parent.
		/// </summary>
		/// <value>The parent.</value>
		public TFocusControl Parent
		{
			get{
				return(FParent);
			}
			set {
				if (FParent != value) {
					if (value == this)
						throw new EInvalidOperation (RTLConsts.SControlParentSetToSelf);

					if (FParent != null)
						FParent.RemoveControl (this);

					if (value != null) {
						value.InsertControl (this);
						//TODO: ScaleForPPI - Not sure about this one
						UpdateAnchorRules();
					}
				}
			}
		}

		protected internal bool FAnchorMove;
		private TAnchors FAnchors;

		/// <summary>
		/// Invalidates the control.
		/// </summary>
		/// <param name="IsVisible">If set to <c>true</c> is visible.</param>
		/// <param name="IsOpaque">If set to <c>true</c> is opaque.</param>
		public void InvalidateControl(bool IsVisible, bool IsOpaque)
		{
			//TODO:
		}


		private void UpdateAnchorRules()
		{
			if ((!FAnchorMove) && (!(ComponentState.isin(TComponentState.csLoading))))
			{
				TAnchors Anchors = FAnchors;
				//TODO:
			}
		}

		/// <summary>
		/// Gets or sets the hint.
		/// </summary>
		/// <value>The hint.</value>
		public string Hint { get; set; }

		/// <summary>
		/// Gets or sets the type of the help.
		/// </summary>
		/// <value>The type of the help.</value>
		public THelpType HelpType { get; set; }

		private string FHelpKeyword;
		/// <summary>
		/// Gets or sets the help keyword.
		/// </summary>
		/// <value>The help keyword.</value>
		public string HelpKeyword { get { return FHelpKeyword; }
			set{
				if (!(ComponentState.isin(TComponentState.csLoading)))
					HelpType = THelpType.htKeyword;

					FHelpKeyword = value;
				}
			}
			
		private int FHelpContext;
		/// <summary>
		/// Gets or sets the help context.
		/// </summary>
		/// <value>The help context.</value>
		public int HelpContext { get { return FHelpContext; }
			set{
				if (!(ComponentState.isin(TComponentState.csLoading)))
					HelpType = THelpType.htContext;

				FHelpContext = value;
			}
		}

		/// <summary>
		/// Invalidate this instance.
		/// </summary>
		public void Invalidate()
		{
			InvalidateControl(Visible, ((ControlStyle.isin(TControlStyle.csOpaque))));
		}

	}
}