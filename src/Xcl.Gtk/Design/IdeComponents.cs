using System;
using System.Collections.Generic;
using System.Reflection;

namespace Xcl.Design
{
	public delegate void PaintEventHandler(IDisposable context);
	public class IdeComponents
	{
		static List<IIdeComponentItem> list;

		public IdeComponents()
		{
		}

		static public IList<IIdeComponentItem> GetComponentList()
		{
			return ComponentList;
		}

		static protected List<IIdeComponentItem> ComponentList
		{
			get
			{
				if (list == null)
					list = new List<IIdeComponentItem>();
				return list;
			}
		}

		static public void Add(Assembly assembly, string ClassName, string description,
		                      string category, string targetversion, string resourceiconname)
		{

			ComponentList.Add(new IdeComponentItem() as IIdeComponentItem);
			list[list.Count - 1].assembly = assembly;
			list[list.Count - 1].ClassName = ClassName;
			list[list.Count - 1].Description = description;
			list[list.Count - 1].Category = category;
			list[list.Count - 1].targetRadxVersion = targetversion;
			list[list.Count - 1].ResourceIconName = resourceiconname;
		}

	}

	public class IdeComponentItem : IIdeComponentItem
	{
		public Assembly assembly { get; set; }
		public string ClassName { get; set; }
		public string Description { get; set; }
		public string targetRadxVersion { get; set; }
		public string Category { get; set; }
		public string ResourceIconName { get; set; }
	}
}
