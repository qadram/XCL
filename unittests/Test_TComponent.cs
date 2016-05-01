using NUnit.Framework;
using System;
using System.Base;
using System.Classes;
using System.SysUtils;

namespace unittests
{
	[TestFixture ()]
	public class Test_TComponent
	{
		public TComponent aobject;
		public TComponent ownedobject;
		public TComponent ownedobject2;

		[SetUp()]
		public void Setup()
		{
			aobject = new TComponent (null);
			ownedobject = new TComponent (aobject);
			ownedobject2 = new TComponent (aobject);

		}

		[Test ()]
		public void Test_Tag ()
		{
			Assert.AreEqual (0, aobject.Tag);
			aobject.Tag = 1;
			Assert.AreEqual (1, aobject.Tag);
		}

		[Test ()]
		public void Test_Name ()
		{
			Assert.AreEqual ("", aobject.Name);
			aobject.Name="Label2";
			Assert.AreEqual ("Label2", aobject.Name);
			try
			{
				aobject.Name = "123Label";
				Assert.Fail(aobject.Name + "should not be a valid component name");
			}
			catch (Exception e) {
				Assert.AreEqual (typeof(EComponentError), e.GetType ());				
			}
			aobject.Name = "Label123";
			try
			{
				ownedobject.Name = "Button1";
				ownedobject2.Name = "Button1";
				Assert.Fail("Shouldn't be possible to have two components with the same owner and the same name");
			}
			catch (Exception e) {
				Assert.AreEqual (typeof(EComponentError), e.GetType ());				
			}

			ownedobject2.Name = "Button2";

			for (int i = 0; i <= aobject.ComponentCount - 1; i++) {
				if (i == 0)
					Assert.AreEqual ("Button1", aobject.Components [i].Name);	
				if (i == 1)
					Assert.AreEqual ("Button2", aobject.Components [i].Name);					
			}

		}

		[Test ()]
		public void Test_Owner ()
		{
			//Default values
			Assert.AreEqual (null, aobject.Owner);
			Assert.AreEqual (aobject, ownedobject.Owner);
			Assert.AreEqual (aobject, ownedobject2.Owner);
			Assert.AreEqual (2, aobject.ComponentCount);

			//Removing a component
			aobject.RemoveComponent (ownedobject);
			Assert.AreEqual (null, ownedobject.Owner);
			Assert.AreEqual (1, aobject.ComponentCount);

			//Removing a component already removed should not produce any problem
			aobject.RemoveComponent (ownedobject);
			Assert.AreEqual (null, ownedobject.Owner);
			Assert.AreEqual (1, aobject.ComponentCount);

			//Removing all components
			aobject.RemoveComponent (ownedobject2);
			Assert.AreEqual (null, ownedobject2.Owner);
			Assert.AreEqual (0, aobject.ComponentCount);

			//Inserting back again
			aobject.InsertComponent (ownedobject2);
			Assert.AreEqual (aobject, ownedobject2.Owner);
			Assert.AreEqual (1, aobject.ComponentCount);

			//Inserting back again
			aobject.InsertComponent (ownedobject);
			Assert.AreEqual (aobject, ownedobject.Owner);
			Assert.AreEqual (2, aobject.ComponentCount);

			//Inserting again should not cause any duplicity
			aobject.InsertComponent (ownedobject);
			Assert.AreEqual (aobject, ownedobject.Owner);
			Assert.AreEqual (2, aobject.ComponentCount);
		}


		[Test ()]
		public void Test_ComponentIndex ()
		{
			//Default values
			Assert.AreEqual (-1, aobject.ComponentIndex);
			Assert.AreEqual (0, ownedobject.ComponentIndex);
			Assert.AreEqual (1, ownedobject2.ComponentIndex);

			//Removing a component
			aobject.RemoveComponent (ownedobject);
			Assert.AreEqual (-1, aobject.ComponentIndex);
			Assert.AreEqual (-1, ownedobject.ComponentIndex);
			Assert.AreEqual (0, ownedobject2.ComponentIndex);

			//Inserting back again
			aobject.InsertComponent (ownedobject);
			Assert.AreEqual (-1, aobject.ComponentIndex);
			Assert.AreEqual (1, ownedobject.ComponentIndex);
			Assert.AreEqual (0, ownedobject2.ComponentIndex);

			//Inserting again should not cause any duplicity
			aobject.InsertComponent (ownedobject);
			Assert.AreEqual (-1, aobject.ComponentIndex);
			Assert.AreEqual (1, ownedobject.ComponentIndex);
			Assert.AreEqual (0, ownedobject2.ComponentIndex);

			//Setting component index should reorder the list
			ownedobject2.ComponentIndex = 1;
			Assert.AreEqual (-1, aobject.ComponentIndex);
			Assert.AreEqual (0, ownedobject.ComponentIndex);
			Assert.AreEqual (1, ownedobject2.ComponentIndex);

		}

		[Test ()]
		public void Test_Assign ()
		{
			try
			{
				aobject.Assign (null);
				Assert.Fail("Assigning to null should raise an EConvertError exception");
			}
			catch (Exception e){
				Assert.AreEqual (typeof(EConvertError), e.GetType ());
			}

			try
			{
				aobject.Assign (ownedobject);
				Assert.Fail("Assigning a TComponent to a TComponent should raise an EConvertError exception");
			}
			catch (Exception e){
				Assert.AreEqual (typeof(EConvertError), e.GetType ());
			}
		}

		[Test ()]
		public void Test_GetNamePath ()
		{
			Assert.AreEqual ("", aobject.GetNamePath ());
			aobject.Name = "Button1";
			Assert.AreEqual ("Button1", aobject.GetNamePath ());

			Assert.AreEqual ("", ownedobject.GetNamePath ());
			ownedobject.Name = "Label1";
			Assert.AreEqual ("Label1", ownedobject.GetNamePath ());

		}

		[Test ()]
		public void Test_ClassType ()
		{
			Assert.AreEqual (aobject.GetType (), aobject.ClassType ());
		}

		[Test ()]
		public void Test_ClassName ()
		{
			Assert.AreEqual ("TComponent", aobject.ClassName ());
		}

		[Test ()]
		public void Test_ClassNameIs ()
		{
			Assert.AreEqual (true, aobject.ClassNameIs ("TComponent"));
			Assert.AreEqual (false, aobject.ClassNameIs ("TObject"));
		}


		[Test ()]
		public void Test_ClassParent ()
		{
			Assert.AreEqual (typeof(TPersistent), aobject.ClassParent ());
		}

		[Test ()]
		public void Test_InheritsFrom ()
		{
			Assert.AreEqual (true, aobject.InheritsFrom (typeof(object)));
			Assert.AreEqual (true, aobject.InheritsFrom (typeof(TObject)));
			Assert.AreEqual (true, aobject.InheritsFrom (typeof(TPersistent)));
			Assert.AreEqual (false, aobject.InheritsFrom (typeof(TComponent)));
		}


		[Test ()]
		public void Test_QualifiedClassName ()
		{
			Assert.AreEqual ("System.Classes.TComponent", aobject.QualifiedClassName ());
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
		public void Test_ComponentState ()
		{
			// Assert.AreEqual ((TComponentState)0 , aobject.ComponentState);

		}
	}
}



