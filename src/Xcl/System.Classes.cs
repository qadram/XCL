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
using System.Linq;
using System.Generics.Collections;



namespace System.Classes
{
	/// <summary>
	/// Exception for Component derived errors
	/// </summary>
	public class EComponentError: EException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="System.Classes.EComponentError"/> class. And allows you to specify a format string and parameters
		/// </summary>
		/// <param name="format">Format.</param>
		/// <param name="args">Arguments.</param>
		public EComponentError(string format, params object[] args): base(format, args)
		{
		}
	}

	/// <summary>
	/// Exception for invalid operations
	/// </summary>
	public class EInvalidOperation: EException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="System.Classes.EInvalidOperation"/> class. And allows you to specify a format string and parameters
		/// </summary>
		/// <param name="format">Format.</param>
		/// <param name="args">Arguments.</param>
		public EInvalidOperation(string format, params object[] args): base(format, args)
		{
		}
	}

	public enum TShiftState {ssShift, ssAlt, ssCtrl,
		ssLeft, ssRight, ssMiddle, ssDouble, ssTouch, ssPen, ssCommand, ssHorizontal};

	//TODO
	public class TFiler: TObject
	{
	}


	/// <summary>
	/// Interface to implement a notification pattern
	/// </summary>
	public interface IChangeNotifier
	{
		 void Changed ();
	}


	/// <summary>
	/// A class to implement object persistance
	/// </summary>
	public class TPersistent: TObject
	{
		/// <summary>
		/// The pointer to the native object this object is wrapping
		/// </summary>
		public object Handle;

		/// <summary>
		/// Gets or sets the notifier used to notify changes in this object
		/// </summary>
		/// <value>The notifier.</value>
		public IChangeNotifier Notifier {
			get;
			set;
		}

		public TPersistent ()
		{
		}

		/// <summary>
		/// Assign the source object to this one
		/// </summary>
		/// <param name="Source">Source.</param>
		public virtual void Assign(TPersistent Source)
		{
			if (Source != null)
				Source.AssignTo (this);
			else
				AssignError (null);
		}

		/// <summary>
		/// Raises an assign error
		/// </summary>
		/// <param name="Source">Source.</param>
		private void AssignError(TPersistent Source)
		{
			string SourceName;

			if (Source != null) {
				SourceName = Source.ClassName ();
			} else {
				SourceName = "null";
			}
				
			throw new EConvertError (RTLConsts.SAssignError, SourceName, ClassName());
		}

		/// <summary>
		/// Assigns this objects to Dest
		/// </summary>
		/// <param name="Dest">Destination.</param>
		protected virtual void AssignTo(TPersistent Dest)
		{
			Dest.AssignError (this);
		}


		protected virtual void DefineProperties(TFiler Filer)
		{
		}

		/// <summary>
		/// Gets the name path.
		/// </summary>
		/// <returns>The name path.</returns>
		public virtual string GetNamePath()
		{
			string S = "";
			string Result = ClassName ();

			if (GetOwner() != null) {
				S = GetOwner ().GetNamePath ();
			}

			if (S != "") {
				Result = S + "." + Result;
			}

			return(Result);
		}

		/// <summary>
		/// Returns the owner of this object
		/// </summary>
		/// <returns>The owner.</returns>
		protected virtual TPersistent GetOwner()
		{
			return(null);
		}
	}

	/// <summary>
	/// A comparer used to sort a component list by name, case insensitive
	/// </summary>
	public class TComponentComparer: IComparer<TComponent>
	{
		public int Compare(TComponent c1, TComponent c2)
		{
			return(StringComparer.CurrentCultureIgnoreCase.Compare (c1.Name, c2.Name));
		}
	}

	//TODO: Review the set feature migration
	/// <summary>
	/// Component State
	/// </summary>
	public class TComponentState:TSet
	{
		public TComponentState (int initialvalue) : base (initialvalue)
		{
			
		}		
		public static int csLoading = 1;
		public static int csReading = 2;
		public static int csWriting = 4;
		public static int csDestroying = 8;
		public static int csDesigning = 16;
		public static int csAncestor = 32;
		public static int csUpdating = 64;
		public static int csFixups = 128;
		public static int csFreeNotification = 256;
		public static int csInline = 512;
		public static int csDesignInstance = 1024;
	}

	/// <summary>
	/// Component Style
	/// </summary>
	public enum TComponentStyle {csInheritable = 1, csCheckPropAvail = 2, csSubComponent = 4, csTransient = 8};

	/// <summary>
	/// Used for the Notification method to be aware of linked properties
	/// </summary>
	public enum TOperation {opInsert, opRemove};

	/// <summary>
	/// Basic component class, which implements ownership
	/// </summary>
	public class TComponent: TPersistent
	{
		private string FName = "";
		private TComponentStyle FComponentStyle;
		private TComponentState FComponentState;
		private TList<TComponent> FComponents;
		private TList<TComponent> FFreeNotifies;
		private TList<TComponent> FSortedComponents;
		private TComponent FOwner;
		private TComponentComparer FComparer;

		/// <summary>
		/// Insert a component as owned of this component
		/// </summary>
		/// <param name="AComponent">A component.</param>
		protected internal void Insert(TComponent AComponent)
		{
			if (FComponents == null)
				FComponents = new TList<TComponent> ();

			FComponents.Add (AComponent);

			if (FSortedComponents != null)
				AddSortedComponent (AComponent);
			AComponent.FOwner = this;
		}

		/// <summary>
		/// Removes a component from being owned by this component
		/// </summary>
		/// <param name="AComponent">A component.</param>
		protected internal void Remove(TComponent AComponent)
		{
			AComponent.FOwner = null;
			int Count = FComponents.Count;

			if (Count > 0) {
				if (FComponents[Count - 1] == AComponent) {
					FComponents.RemoveAt (Count - 1);
				}
				else {
					FComponents.Remove (AComponent);
				}

				if (FSortedComponents != null)
					FSortedComponents.Remove(AComponent);
			}
		}

		protected void DoEvent(Delegate AnEvent, object sender, EventArgs e)
		{
			var eventList = AnEvent.GetInvocationList().ToList();
			object[] args = { this, e };
			foreach (var item in eventList) {
				item.DynamicInvoke(args);
			}			
		}


		protected virtual void CreateNonVisualHandle()
		{
		}

		//Done
		public TComponent(TComponent AOwner)
		{
			CreateNonVisualHandle ();
			FComparer = new TComponentComparer ();
			FComponentState = new TComponentState (0);
			FComponentStyle = TComponentStyle.csInheritable;
			if (AOwner != null) AOwner.InsertComponent(this);
		}

		/// <summary>
		/// Removes the notification.
		/// </summary>
		/// <param name="AComponent">A component.</param>
		private void RemoveNotification(TComponent AComponent)
		{
			if (FFreeNotifies != null) {
				int Count = FFreeNotifies.Count;
				if (Count > 0) {
					if (FFreeNotifies [Count - 1] == AComponent)
						FFreeNotifies.Delete (Count - 1);
					else
						FFreeNotifies.Remove (AComponent);
				}

				//TODO: Review if this is actually needed
				if (FFreeNotifies.Count == 0)
					FFreeNotifies = null;
			}
		}

		/// <summary>
		/// Removes the free notification.
		/// </summary>
		/// <param name="AComponent">A component.</param>
		public void RemoveFreeNotification(TComponent AComponent)
		{
			RemoveNotification (AComponent);
			AComponent.RemoveNotification (this);
		}

		/// <summary>
		/// Adds a free notification
		/// </summary>
		/// <param name="AComponent">A component.</param>
		public void FreeNotification(TComponent AComponent)
		{
			if ((Owner == null) || (AComponent.Owner != Owner)) {
				//TODO: Assert
				if (FFreeNotifies==null) FFreeNotifies = new TList<TComponent>();
				if (FFreeNotifies.IndexOf (AComponent) < 0) {
					FFreeNotifies.Add (AComponent);
					AComponent.FreeNotification (this);
				}
			}
			FComponentState.include (TComponentState.csFreeNotification);
		}

		/// <summary>
		/// Notifies the Operation with the specified AComponent
		/// </summary>
		/// <param name="AComponent">A component.</param>
		/// <param name="Operation">Operation.</param>
		protected virtual void Notification(TComponent AComponent, TOperation Operation)
		{
			if ((Operation == TOperation.opRemove) && (AComponent != null)) {
				RemoveFreeNotification (AComponent);
			}

			if (FComponents != null) {
				int I = FComponents.Count - 1;
				while (I >= 0) {
					FComponents [I].Notification (AComponent, Operation);
					I--;
					if (I >= FComponents.Count) {
						I = FComponents.Count - 1;
					}
				}
			}
		}

		/// <summary>
		/// Executes the action.
		/// </summary>
		/// <returns><c>true</c>, if action was executed, <c>false</c> otherwise.</returns>
		/// <param name="Action">Action.</param>
		public virtual bool ExecuteAction(TBasicAction Action)
		{
			bool Result = ((Action != null) && (!Action.Suspended()) && (Action.HandlesTarget(this)));
			if (Result)
				Action.ExecuteTarget (this);
			
			return(Result);
		}

		/// <summary>
		/// Finds a component by name
		/// </summary>
		/// <returns>The component if found, null otherwise.</returns>
		/// <param name="AName">A name.</param>
		public TComponent FindComponent(string AName)
		{
			TComponent Result = null;

			if ((AName!="") && (FComponents != null))
			{
				if (FSortedComponents == null) {
					//TODO: Review this for performance
					FSortedComponents = new TList<TComponent> ();
					for (int i = 0; i < FComponents.Count; i++) {
						FSortedComponents.Add(FComponents [i]);
					}
					FSortedComponents.Sort (FComparer);
						
				}
				int Index=0;

				Result = FindSortedComponent (AName, out Index); 
			}
			return(Result);
		}

		/// <summary>
		/// Finds the sorted component.
		/// </summary>
		/// <returns>The component if found, null otherwise, and sets Index with the right value.</returns>
		/// <param name="AName">A name.</param>
		/// <param name="Index">Index.</param>
		private TComponent FindSortedComponent(string AName, out int Index)
		{
			Index = 0;
			//TODO: Review performance
			TComponent Result = FSortedComponents.Find(x => x.Name == AName);
			if (Result != null)
				Index = FSortedComponents.IndexOf(Result);
			return(Result);
		}

		/// <summary>
		/// Adds the sorted component.
		/// </summary>
		/// <param name="AComponent">A component.</param>
		private void AddSortedComponent(TComponent AComponent)
		{
			int Index = 0;
			FindSortedComponent (AComponent.Name, out Index);
			FSortedComponents.Insert (Index, AComponent);
		}

		/// <summary>
		/// Removes the sorted component.
		/// </summary>
		/// <param name="AComponent">A component.</param>
		private void RemoveSortedComponent(TComponent AComponent)
		{
			FSortedComponents.Remove (AComponent);
		}

		/// <summary>
		/// Gets the parent component.
		/// </summary>
		/// <returns>The parent component.</returns>
		public virtual TComponent GetParentComponent()
		{
			return(null);
		}

		protected override TPersistent GetOwner()
		{
			return(FOwner);
		}


		public override string GetNamePath ()
		{
			return(FName);			
		}

		/// <summary>
		/// Determines whether this instance has parent.
		/// </summary>
		/// <returns><c>true</c> if this instance has parent; otherwise, <c>false</c>.</returns>
		public virtual bool HasParent()
		{
			return false;
		}

		/// <summary>
		/// Validates the rename operation
		/// </summary>
		/// <param name="AComponent">A component.</param>
		/// <param name="CurName">Current name.</param>
		/// <param name="NewName">New name.</param>
		protected virtual void ValidateRename(TComponent AComponent, string CurName, string NewName)
		{
			if ((AComponent != null) && (!_.SameText(CurName, NewName))
				&& (AComponent.Owner == this) && (FindComponent(NewName) != null))
			{
				throw new EComponentError (RTLConsts.SDuplicateName,NewName);
			}

			if ((ComponentState.isin(TComponentState.csDesigning)) && (Owner!=null))
			{
				Owner.ValidateRename(AComponent, CurName, NewName);
			}
		}

		/// <summary>
		/// Validates the container.
		/// </summary>
		/// <param name="AComponent">A component.</param>
		public virtual void ValidateContainer(TComponent AComponent)
		{
			AComponent.ValidateInsert (this);
		}

		protected virtual void ValidateInsert(TComponent AComponent)
		{
		}

		/// <summary>
		/// Inserts the component.
		/// </summary>
		/// <param name="AComponent">A component.</param>
		public void InsertComponent(TComponent AComponent)
		{
			//TODO: Notify designers
			AComponent.ValidateContainer(this);
			if (AComponent.FOwner != null)
				AComponent.FOwner.RemoveComponent (AComponent);
			ValidateRename(AComponent,"",AComponent.Name);
			Insert (AComponent);

			//TODO: SetReference
			if ((ComponentState.isin(TComponentState.csDesigning))) {
				AComponent.SetDesigning (true);
			}
			Notification(AComponent, TOperation.opInsert);

		}

		/// <summary>
		/// Removes the component.
		/// </summary>
		/// <param name="AComponent">A component.</param>
		public void RemoveComponent(TComponent AComponent)
		{
			ValidateRename(AComponent, AComponent.Name, "");
			Notification(AComponent, TOperation.opRemove);
			//TODO: SetReference
			Remove(AComponent);
		}

		/// <summary>
		/// Sets the designing mode
		/// </summary>
		/// <param name="Value">If set to <c>true</c> value.</param>
		/// <param name="SetChildren">If set to <c>true</c> set children.</param>
		protected void SetDesigning(bool Value, bool SetChildren = true)
		{
			if (Value)
				FComponentState.include(TComponentState.csDesigning);
			else
				FComponentState.exclude(TComponentState.csDesigning);

			if (SetChildren) {
				for (int i = 0; i <= ComponentCount - 1; i++) {
					Components [i].SetDesigning (Value);
				}
			}
		}

		/// <summary>
		/// Changes the name for a new one
		/// </summary>
		/// <param name="NewName">New name.</param>
		protected void ChangeName(string NewName)
		{
			FName = NewName;
			if ((FOwner!=null) && (FOwner.FSortedComponents!=null))
			{
				FOwner.RemoveSortedComponent(this);
				FOwner.AddSortedComponent(this);
			}
		}


		/// <summary>
		/// Sets the sub component flag
		/// </summary>
		/// <param name="IsSubComponent">If set to <c>true</c> is sub component.</param>
		public void SetSubComponent(bool IsSubComponent)
		{
			if (IsSubComponent) {
				FComponentStyle = FComponentStyle | TComponentStyle.csSubComponent;
			} else {
				FComponentStyle = FComponentStyle & TComponentStyle.csSubComponent;				
			}
		}

		/// <summary>
		/// List of owned components
		/// </summary>
		/// <value>The components.</value>
		public TList<TComponent> Components
		{
			get{
				return(FComponents);
			}
		}

		/// <summary>
		/// Gets the component count.
		/// </summary>
		/// <value>The component count.</value>
		public int ComponentCount
		{
			get {
				if (FComponents != null)
					return(FComponents.Count);
				else
					return(0);
			}
		}

		/// <summary>
		/// Gets or sets the index of the component in the owner's component list
		/// </summary>
		/// <value>The index of the component.</value>
		public int ComponentIndex
		{
			get{
				if ((FOwner != null) && (FOwner.FComponents != null))
					return(FOwner.FComponents.IndexOf (this));
				else
					return(-1);
			}
			set{
				if (FOwner != null) {
					int I = FOwner.FComponents.IndexOf (this);

					if (I >= 0) {
						int Count = FOwner.FComponents.Count;
						if (value < 0)
							value = 0;
						if (value >= Count)
							value = Count - 1;
						if (value != I) {
							FOwner.FComponents.Delete (I);
							FOwner.FComponents.Insert (value, this);
						}
					}
				}
			}
		}


		/// <summary>
		/// Gets the state of the component.
		/// </summary>
		/// <value>The state of the component.</value>
		public TComponentState ComponentState { 
			get { return this.FComponentState; } 
		}

		/// <summary>
		/// Gets the component style.
		/// </summary>
		/// <value>The component style.</value>
		public TComponentStyle ComponentStyle { 
			get { return this.FComponentStyle; }
		}

		/// <summary>
		/// Gets or sets the design info. Used by the form designer to store information for non visual components
		/// </summary>
		/// <value>The design info.</value>
		public Int32 DesignInfo { get; set; }

		/// <summary>
		/// Gets the owner.
		/// </summary>
		/// <value>The owner.</value>
		public TComponent Owner
		{
			get {
				return(FOwner);
			}
		}

		public virtual void SetName(string NewName)
		{
			if (FName != NewName) {
				if ((NewName != "") && (!_.IsValidIdent (NewName))) {
					throw new EComponentError (RTLConsts.SInvalidName, NewName);
				}
				if (FOwner != null)
					FOwner.ValidateRename (this, FName, NewName);
				else
					ValidateRename (null, FName, NewName);

				ChangeName (NewName);
			}				
		}
		//TODO: Published equivalent using attributes
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get{
				return(FName);
			}
			set{
				SetName (value);
			}
		}

		/// <summary>
		/// Gets or sets the tag.
		/// </summary>
		/// <value>The tag.</value>
		public int Tag { get; set; }
	}


	//TODO:
	public class TBasicAction:TComponent
	{
		public TBasicAction (TComponent AOwner) : base (AOwner)
		{
		}

		public virtual bool Suspended()
		{
			return(false);
		}

		public virtual bool HandlesTarget(TObject Target)
		{
			return(false);
		}

		public virtual void ExecuteTarget(TObject Target)
		{
		}
	}
}

