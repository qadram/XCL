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
using System.Text.RegularExpressions;

namespace System.Base
{
	/// <summary>
	/// This class holds global functions usually as static members
	/// </summary>
	public partial class _
	{
		/// <summary>
		/// Compares to strings ignoring case
		/// </summary>
		/// <returns><c>true</c>, if text was the same, <c>false</c> otherwise.</returns>
		/// <param name="S1">S1.</param>
		/// <param name="S2">S2.</param>
		public static bool SameText(string S1, string S2)
		{
			return(S1.Equals (S2, StringComparison.OrdinalIgnoreCase));
		}

		/// <summary>
		/// Returns the lower case version of a string
		/// </summary>
		/// <returns>The lower case of a string.</returns>
		/// <param name="S">S.</param>
		public static string LowerCase(string S)
		{
			return(S.ToLower());
		}

		internal static bool is_identifier_start_character(char c)
		{
			return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || c == '_' || c == '@' || char.IsLetter(c);
		}

		internal static bool is_identifier_part_character(char c)
		{
			return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || c == '_' || (c >= '0' && c <= '9') || char.IsLetter(c);
		}


		//TODO: AllowDots
		/// <summary>
		/// Determines if Ident is a valid identifier
		/// </summary>
		/// <returns><c>true</c> if is Ident is a valid identifier; otherwise, <c>false</c>.</returns>
		/// <param name="Ident">Ident.</param>
		/// <param name="AllowDots">If set to <c>true</c> allow dots.</param>
		public static bool IsValidIdent (string Ident, bool AllowDots = false)
		{
			if (Ident == null || Ident.Length == 0)
				return false;

			if (!is_identifier_start_character(Ident[0]))
				return false;

			for (int i = 1; i < Ident.Length; i++)
				if (!is_identifier_part_character(Ident[i]))
					return false;

			return true;
		}


	}
}

namespace System.SysUtils
{

/// <summary>
/// Base class for all exceptions
/// </summary>
public class EException: Exception
{
	public EException()
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="System.SysUtils.EException"/> class.
	/// </summary>
	/// <param name="format">Format.</param>
	/// <param name="args">Arguments.</param>
	public EException(string format, params object[] args): base(String.Format(format, args))
	{
		
	}
}

/// <summary>
/// Exception raised when there is a conversion error
/// </summary>
public class EConvertError: EException
{
	public EConvertError(string format, params object[] args): base(format, args)
	{
	}
}

}
