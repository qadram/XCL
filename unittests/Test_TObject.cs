using NUnit.Framework;
using System;
using System.Base;

namespace unittests
{
	[TestFixture ()]
	public class Test_TObject
	{
		public TObject aobject;

		[SetUp()]
		public void Setup()
		{
			aobject = new TObject ();
			
		}

		[Test ()]
		public void Test_ClassType ()
		{
			Assert.AreEqual (aobject.GetType (), aobject.ClassType ());
		}

		[Test ()]
		public void Test_ClassName ()
		{
			Assert.AreEqual ("TObject", aobject.ClassName ());
		}

		[Test ()]
		public void Test_ClassNameIs ()
		{
			Assert.AreEqual (true, aobject.ClassNameIs ("TObject"));
			Assert.AreEqual (false, aobject.ClassNameIs ("TComponent"));
		}


		[Test ()]
		public void Test_ClassParent ()
		{
			Assert.AreEqual (typeof(object), aobject.ClassParent ());
		}

		[Test ()]
		public void Test_InheritsFrom ()
		{
			Assert.AreEqual (true, aobject.InheritsFrom (typeof(object)));
			Assert.AreEqual (false, aobject.InheritsFrom (typeof(TObject)));
		}


		[Test ()]
		public void Test_QualifiedClassName ()
		{
			Assert.AreEqual ("System.Base.TObject", aobject.QualifiedClassName ());
		}

		[Test ()]
		public void Test_UnitName ()
		{
			Assert.AreEqual ("System.Base", aobject.UnitName ());
		}

		[Test ()]
		public void Test_UnitScope ()
		{
			Assert.AreEqual ("System.Base", aobject.UnitScope ());
			Assert.AreEqual (aobject.UnitName(), aobject.UnitScope ());

		}


		[Test ()]
		public void Test_Nothing ()
		{

		}
	}
}

