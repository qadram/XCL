using System;
using System.Reflection;

namespace Xcl.Design
{
	public interface IRegisterComponent
	{
		void Register();
	}

	public interface IIdeComponentItem
	{
		Assembly assembly { get; set; }
		string ClassName { get; set; }
		string Description { get; set; }
		string targetRadxVersion { get; set; }
		string Category { get; set; }
		string ResourceIconName { get; set; }
	}

}
