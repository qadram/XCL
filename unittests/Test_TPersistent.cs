using NUnit.Framework;
using System;
using System.Base;
using System.Classes;
using System.SysUtils;

namespace unittests
{
	[TestFixture ()]
	public class Test_TPersistent
	{
		public TPersistent aobject;

		[SetUp()]
		public void Setup()
		{
			aobject = new TPersistent ();

		}

		[Test ()]
		public void Test_Assign ()
		{
			try
			{
				aobject.Assign (null);
				Assert.Fail("Assigning to null should raise an EConvert Error exception");
			}
			catch (Exception e){
				Assert.AreEqual (typeof(EConvertError), e.GetType ());
			}
		}

		[Test ()]
		public void Test_GetNamePath ()
		{
			Assert.AreEqual ("TPersistent", aobject.GetNamePath ());
		}

		[Test ()]
		public void Test_ClassType ()
		{
			Assert.AreEqual (aobject.GetType (), aobject.ClassType ());
		}

		[Test ()]
		public void Test_ClassName ()
		{
			Assert.AreEqual ("TPersistent", aobject.ClassName ());
		}

		[Test ()]
		public void Test_ClassNameIs ()
		{
			Assert.AreEqual (true, aobject.ClassNameIs ("TPersistent"));
			Assert.AreEqual (false, aobject.ClassNameIs ("TObject"));
		}


		[Test ()]
		public void Test_ClassParent ()
		{
			Assert.AreEqual (typeof(TObject), aobject.ClassParent ());
		}

		[Test ()]
		public void Test_InheritsFrom ()
		{
			Assert.AreEqual (true, aobject.InheritsFrom (typeof(object)));
			Assert.AreEqual (true, aobject.InheritsFrom (typeof(TObject)));
			Assert.AreEqual (false, aobject.InheritsFrom (typeof(TPersistent)));
		}


		[Test ()]
		public void Test_QualifiedClassName ()
		{
			Assert.AreEqual ("System.Classes.TPersistent", aobject.QualifiedClassName ());
		}

		[Test ()]
		public void Test_UnitName ()
		{
			Assert.AreEqual ("System.Classes", aobject.UnitName ());
		}

		[Test ()]
		public void Test_UnitScope ()
		{
			Assert.AreEqual ("System.Classes", aobject.UnitScope ());
			Assert.AreEqual (aobject.UnitName(), aobject.UnitScope ());

		}


		[Test ()]
		public void Test_Nothing ()
		{

		}
	}
}


