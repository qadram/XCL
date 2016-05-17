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
	//TODO: Review the usage of this enum and convert it to a TSet
	/// <summary>
	/// Control State
	/// </summary>
	public enum TControlState {csLButtonDown=1, csClicked=2, csPalette=4,
		csReadingState=8, csAlignmentNeeded=16, csFocusing=32, csCreating=64,
		csPaintCopy=128, csCustomPaint=256, csDestroyingHandle=512, csDocking=1024,
		csDesignerHide=2048, csPanning=4096, csRecreating=8192, csAligning=16384, csGlassPaint=32768,
		csPrintClient=65536};

	/// <summary>
	/// Set for control styles
	/// </summary>
	public class TControlStyle:TSet
	{
		public TControlStyle(int initialvalue):base(initialvalue)
		{
		}		
		public static int csAcceptsControls=1;
		public static int csCaptureMouse = 2;
		public static int csDesignInteractive = 4;
		public static int csClickEvents = 8;
		public static int csFramed = 16;
		public static int csSetCaption = 32;
		public static int csOpaque = 64;
		public static int csDoubleClicks = 128;
		public static int csFixedWidth = 256;
		public static int csFixedHeight = 512;
		public static int csNoDesignVisible = 1024;
		public static int csReplicatable = 2048;
		public static int csNoStdEvents = 4096;
		public static int csDisplayDragImage = 8192;
		public static int csReflector = 16384;
		public static int csActionClient = 32768;
		public static int csMenuEvents = 65536;
		public static int csNeedsBorderPaint = 131072;
		public static int csParentBackground = 262144;
		public static int csPannable = 524288;
		public static int csAlignWithMargins = 1048576;
		public static int csGestures = 2097152;
		public static int csPaintBlackOpaqueOnGlass = 4194304;
		public static int csOverrideStylePaint=8388608;		
	}


	//TODO: Implement the Margins property
	/// <summary>
	/// Used for the Margins property
	/// </summary>
	public class TMargins:TPersistent
	{
		private TControl FControl;

		private float FLeft;
		private float FTop;
		private float FRight;
		private float FBottom;

		protected TControl Control {get {return FControl; }}

		/// <summary>
		/// Initializes a new instance of the <see cref="Xcl.Controls.TMargins"/> class to be used in a Control
		/// </summary>
		/// <param name="Control">Control.</param>
		public TMargins(TControl Control)
		{
			FControl = Control;
			InitDefaults (this);
		}

		/// <summary>
		/// Sets the control bounds.
		/// </summary>
		/// <param name="ALeft">A left.</param>
		/// <param name="ATop">A top.</param>
		/// <param name="AWidth">A width.</param>
		/// <param name="AHeight">A height.</param>
		/// <param name="Aligning">If set to <c>true</c> aligning.</param>
		public void SetControlBounds(float ALeft, float ATop, float AWidth, float AHeight, bool Aligning = false)
		{
			if (Control != null) {
				if (Aligning) {
					Control.AnchorMove = true;
					Control.ControlState = Control.ControlState | TControlState.csAligning;
				}
			}
			try
			{
				if ((Control.AlignWithMargins) && (Control.Parent!=null))
				{
					Control.SetBounds(ALeft+FLeft, ATop+FTop, AWidth - (FLeft+FRight), AHeight - (FTop+FBottom));
				}
				else
				{
					Control.SetBounds(ALeft, ATop, AWidth, AHeight);
				}
			}
			finally {
				if (Aligning) {
					Control.AnchorMove = false;
					Control.ControlState = Control.ControlState & TControlState.csAligning;
				}
			}
		}

		/// <summary>
		/// Initializes the default values
		/// </summary>
		/// <param name="Margins">Margins.</param>
		public static void InitDefaults (TMargins Margins)
		{
			Margins.FLeft = 3;
			Margins.FRight = 3;
			Margins.FTop = 3;
			Margins.FBottom = 3;
		}

	}


	public enum TScalingFlags {sfLeft=1, sfTop=2, sfWidth=4, sfHeight=8, sfFont=16, sfDesignSize=32};
	public enum THelpType {htKeyword=1, htContext=2};


	/// <summary>
	/// This class holds a list of images
	/// </summary>
	public partial class TImageList:TCustomImageList
	{
		public static TImageList Create(TComponent AOwner)
		{
			return(new TImageList (AOwner));
		}

		public TImageList(TComponent AOwner):base(AOwner)
		{
			
		}
	}

	/// <summary>
	/// Base class for any control
	/// </summary>
	public partial class TControl:TComponent,IChangeNotifier
	{
		//TODO: Rename to CreateNativeHandle
		/// <summary>
		/// Called to create the handle
		/// </summary>
		protected virtual void CreateHandle()
		{

		}

		/// <summary>
		/// Override to implement the attachment of the event
		/// </summary>
		/// <param name="value">Value.</param>
		protected virtual void NativeOnClickAdd(EventHandler value)
		{
		}

		/// <summary>
		/// Override to implement the detachment of the event
		/// </summary>
		/// <param name="value">Value.</param>
		protected virtual void NativeOnClickRemove(EventHandler value)
		{
		}


		private void DoClick (object sender, EventArgs e)
		{
			DoEvent (FOnClick, sender, e);
		}

		private event EventHandler FOnClick;
		/// <summary>
		/// Occurs when the control is clicked.
		/// </summary>
		public event EventHandler OnClick
		{
			add
			{				
				//DoClick is just added once to the native control
				if (FOnClick==null)	{
					NativeOnClickAdd(DoClick);
				}

				//And the event is added internally, so it's fired along with the others
				FOnClick+=value;
			}
			remove
			{
				NativeOnClickRemove (DoClick);
				FOnClick-=value;
			}
		}

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

		public TControl(TComponent AOwner):base(AOwner)
		{
			FControlStyle = new TControlStyle (0);
			FFont = new TFont ();
			FFont.Notifier = this;
			CreateHandle ();
		}

		
		partial void NativeSetColor(TColor AColor);

		public virtual void SetColor(TColor AColor)
		{
			NativeSetColor (AColor);
		}

		/// <summary>
		/// Gets or sets the color.
		/// </summary>
		/// <value>The color.</value>
		public TColor Color
		{
			get{
				return(null);
			}
			set{
				SetColor (value);	
			}
		}

		private string FText;

		//TODO: Review this 
		public virtual string GetText()
		{
			return(FText);
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


	/// <summary>
	/// Base class for Graphic controls
	/// </summary>
	public partial class TGraphicControl:TFocusControl
	{
		public TGraphicControl(TComponent AOwner):base(AOwner)
		{
		}

		//TODO: Canvas drawing
	}

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
