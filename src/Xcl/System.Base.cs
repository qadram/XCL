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
using System.Diagnostics;
using System.Reflection;

using Xcl.Forms;

namespace System.Base
{
	/// <summary>
	/// Class to emulate sets
	/// </summary>
	public class TSet
	{
		public int value = 0;

		/// <summary>
		/// Check if the specified flag is included in the set
		/// </summary>
		/// <param name="flag">Flag.</param>
		public bool isin(int flag)
		{
			return((value & flag)==flag);
		}

		/// <summary>
		/// Include the specified flag.
		/// </summary>
		/// <param name="flag">Flag.</param>
		public void include(int flag)
		{
			value = value | flag;
		}

		/// <summary>
		/// Exclude the specified flag.
		/// </summary>
		/// <param name="flag">Flag.</param>
		public void exclude(int flag)
		{
			value = value & ~flag;
		}

		public bool isequal(int flag)
		{
			return ((value & flag)==value);
		}

		public bool isequal(int flag1, int flag2)
		{
			return ((value & (flag1 | flag2))==value);
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="System.Base.TSet"/> class.
		/// </summary>
		/// <param name="initialvalue">Initialvalue.</param>
		public TSet(int initialvalue)
		{
			value = initialvalue;

		}
	}	
	/// <summary>
	/// Class to hold all the global functions and variables
	/// </summary>
	public partial class _
	{
		/// <summary>
		/// Returns a random number between 0 and ARange.
		/// </summary>
		/// <param name="ARange">A range.</param>
		public static int Random(int ARange)
		{
			return(new Random ().Next (ARange));
		}

		public static int MulDiv(int number, int numerator, int denominator) {
			return (int)(((long)number * numerator) / denominator);
		}

		/// <summary>
		/// Returns a random number between 0.0 and 1.0
		/// </summary>
		public static double Random()
		{
			return(new Random ().NextDouble ());
		}
	}

	/// <summary>
	/// Base class for all XCL objects
	/// </summary>
	public class TObject: IDisposable
	{
		/// <summary>
		/// Emulates the Delphi self variable
		/// </summary>
		/// <value>The self.</value>
		public TObject self
		{
			get {
				return(this);
			}
		}

		public TApplication Application
		{
			get{
				return (_.Application);
			}
		}

		public TScreen Screen
		{
			get{
				return(_.Screen);
			}
		}

		public virtual void Dispose()
		{
		}

		/// <summary>
		/// Returns the Type for this object
		/// </summary>
		/// <returns>The type.</returns>
		public Type ClassType()
		{
			return(this.GetType ());
		}

		/// <summary>
		/// Returns the name of the class
		/// </summary>
		/// <returns>The name of the class.</returns>
		public string ClassName()
		{
			return(this.GetType ().Name);
		}

		/// <summary>
		/// Verifies if the name of the class is an specific one
		/// </summary>
		/// <returns><c>true</c>, if the name of the class is equal to Name, <c>false</c> otherwise.</returns>
		/// <param name="Name">Name.</param>
		public bool ClassNameIs(string Name)
		{
			return(ClassName () == Name);
		}

		/// <summary>
		/// Returns the TypeInfo for this class
		/// </summary>
		/// <returns>The TypeInfo.</returns>
		public TypeInfo ClassInfo()
		{
			return(this.GetType ().GetTypeInfo ());
		}

		/// <summary>
		/// Returns the class from which this class inherits
		/// </summary>
		/// <returns>The parent class.</returns>
		public Type ClassParent()
		{
			return(this.GetType().GetTypeInfo().BaseType);
		}

		/// <summary>
		/// To test if a class inherits from another class
		/// </summary>
		/// <returns><c>true</c>, if from was inheritsed, <c>false</c> otherwise.</returns>
		/// <param name="type">Type.</param>
		public bool InheritsFrom(Type type)
		{
			return(this.ClassInfo ().IsSubclassOf (type));
		}

		/// <summary>
		/// Qualifieds the name of the class.
		/// </summary>
		/// <returns>The qualified class name.</returns>
		public string QualifiedClassName()
		{
			return(this.GetType ().FullName);
		}

		/// <summary>
		/// Returns the unit where this class was declared
		/// </summary>
		/// <returns>The name.</returns>
		public string UnitName()
		{
			string fullName = QualifiedClassName ();
			int position = fullName.LastIndexOf('.');
			if (position == -1) {
				return fullName;
			} else {
				return fullName.Substring (0, position);
			}
		}

		/// <summary>
		/// The same as UnitName()
		/// </summary>
		/// <returns>The scope.</returns>
		public string UnitScope()
		{
			//In Delphi, UnitScope is used in a slight different way than UnitName, but here it doesn't make sense
			return UnitName ();
		}
	}

}