using System.Base;
using System.Generics.Collections;
using System.Classes;
//using Newtonsoft.Json;

namespace System.JSON
{

	public abstract class TJSONAncestor : TObject
	{
		protected virtual Boolean IsNull()
		{
			return false;
		}

		protected abstract void AddDescendant(TJSONAncestor Descendant);

		public TJSONAncestor()
		{
		}

		public virtual string Value()
		{
			return "";
		}

		public abstract int EstimatedByteSize();

		public abstract int ToBytes(Byte[] Data, int Offset);

		public string ToJSON()
		{
			return "";
		}

		public abstract TJSONAncestor Clone();

		public virtual bool GetOwned()
		{
			return false;
		}

		private bool FOwned;
		public bool Owned
		{
			get
			{
				return GetOwned();
			}
			set
			{
				// SetOwned
				FOwned = value;
			}
		}

		public bool Null
		{
			get
			{
				return IsNull();
			}
		}
	}

	public class TJSONByteReader : TObject
	{

	}

	public sealed class TJSONPair : TJSONAncestor
	{
		protected override void AddDescendant(TJSONAncestor Descendant)
		{
		}

		private void SetJsonString(TJSONString Descendant)
		{
		}

		private void SetJsonValue(TJSONValue Val)
		{
		}

		private TJSONString GetJsonString()
		{
			return null;
		}

		private TJSONValue GetJsonValue()
		{
			return null;
		}

		public TJSONPair()
		{
		}

		public TJSONPair(TJSONString Str, TJSONValue Value)
		{
		}

		public TJSONPair(TJSONString Str, TJSONString Value)
		{
		}

		public override int EstimatedByteSize()
		{
			return -1;
		}

		public override int ToBytes(Byte[] Data, int Offset)
		{
			return -1;
		}

		public override string ToString()
		{
			return "";
		}

		public override TJSONAncestor Clone()
		{
			return null;
		}

		public TJSONString JsonString
		{
			get
			{
				return GetJsonString();
			}
			set
			{
				SetJsonString(value);
			}
		}

		public TJSONValue JsonValue
		{
			get
			{
				return GetJsonValue();
			}
			set
			{
				SetJsonValue(value);
			}
		}
	}

	public abstract class TJSONValue : TJSONAncestor
	{
	}

	public class TJSONString : TJSONValue
	{
		//protected TStringBuilder FStrBuffer;


		protected override void AddDescendant(TJSONAncestor Descendant)
		{
		}

		protected override bool IsNull()
		{
			return false;
		}

		//protected override bool AsTValue(PTypeInfo ATypeInfo; out TValue AValue)

		public static Byte Hex(int Digit)
		{
			return 0;
		}

		public TJSONString()
		{
		}

		public TJSONString(string Value)
		{
		}

		public virtual void AddChar(char Ch)
		{
		}

		public override int EstimatedByteSize()
		{
			return -1;
		}

		public override int ToBytes(Byte[] Data, int Idx)
		{
			return -1;
		}

		public override string ToString()
		{
			return "";
		}

		public override String Value()
		{
			return "";
		}

		public override TJSONAncestor Clone()
		{
			return null;
		}
	}

	public sealed class TJSONNumber : TJSONString
	{
		private TJSONNumber(string Value)
		{
		}

		private Double GetAsDouble()
		{
			return 0;
		}

		private int GetAsInt()
		{
			return 0;
		}

		private Int64 GetAsInt64()
		{
			return 0;
		}


		public TJSONNumber()
		{
		}

		public TJSONNumber(Double Value)
		{
		}

		public TJSONNumber(int Value)
		{
		}

		public TJSONNumber(Int64 Value)
		{
		}

		public override int EstimatedByteSize()
		{
			return -1;
		}

		public override int ToBytes(Byte[] Data, int Idx)
		{
			return -1;
		}

		public override string ToString()
		{
			return "";
		}

		public override string Value()
		{
			return "";
		}

		public override TJSONAncestor Clone()
		{
			return null;
		}

		public Double AsDouble
		{
			get
			{
				return GetAsDouble();
			}
		}

		public int AsInt
		{
			get
			{
				return GetAsInt();
			}
		}

		public Int64 AsInt64
		{
			get
			{
				return GetAsInt64();
			}
		}
	}

	public enum TJSONParseOption { IsUTF8, UseBool };

	public class TJSONParseOptions : TSet
	{
		public static int IsUTF8 = 1;
		public static int UseBool = 2;
	}

	public class TJSONObject
	{
		static public TJSONValue ParseJSONValue(Byte[] Data, int Offset, bool IsUTF8 = true)
		{
			return null;
		}

		static public TJSONValue ParseJSONValue(Byte[] Data, int Offset, TJSONParseOptions Options)
		{
			return null;
		}

		public static TJSONValue ParseJSONValue(Byte[] Data, int Offset, int ALength, bool IsUTF8 = true)
		{
			return null;
		}

		public static TJSONValue ParseJSONValue(Byte[] Data, int Offset, int ALength, TJSONParseOptions Options)
		{
			return null;
		}

		public static TJSONValue ParseJSONValue(string Data, bool UseBool = false)
		{
			return null;
		}
	}


	public sealed class TJSONNull : TJSONValue
	{
		public const String NullString = "null";

		protected override void AddDescendant(TJSONAncestor Descendant)
		{
		}

		//protected override bool AsTValue(PTypeInfo ATypeInfo, out TValue AValue)

		protected override bool IsNull()
		{
			return false;
		}

		public override int EstimatedByteSize()
		{
			return -1;
		}

		public override int ToBytes(Byte[] Data, int Offset)
		{
			return -1;
		}

		public override string ToString()
		{
			return null;
		}

		public override string Value()
		{
			return "";
		}

		public override TJSONAncestor Clone()
		{
			return null;
		}
	}


	public class TJSONBool : TJSONValue
	{
		private const String FalseString = "false";
		private const String TrueString = "true";

		//protected override bool AsTValue(PTypeInfo ATypeInfo, out TValue: AValue);

		protected override void AddDescendant(TJSONAncestor Descendant)
		{
		}

		public TJSONBool(bool AValue)
		{
		}

		public override int EstimatedByteSize()
		{
			return -1;
		}

		public override int ToBytes(Byte[] Data, int Offset)
		{
			return -1;
		}

		public override String ToString()
		{
			return "";
		}

		public override string Value()
		{
			return "";
		}

		public override TJSONAncestor Clone()
		{
			return null;
		}

		private bool FValue;
		public bool AsBoolean
		{
			get
			{
				return FValue;
			}
		}
	}

	public sealed class TJSONTrue : TJSONBool
	{
		public TJSONTrue(): base(true)
		{
		}

		public override TJSONAncestor Clone()
		{
			return null;
		}
	}

	public sealed class TJSONFalse : TJSONBool
	{
		public TJSONFalse(): base(false)
		{
		}

		public override TJSONAncestor Clone()
		{
			return null;
		}
	}

	public sealed class TJSONArray : TJSONValue
	{
		private TList<TJSONValue> FElements;

		public TJSONValue FindValue(string APath)
		{
			return null;
		}

		protected override void AddDescendant(TJSONAncestor Descendant)
		{

		}

		public TJSONValue Pop()
		{
			return null;
		}


		public TJSONValue GetValue(int Index)
		{
			return null;
		}

		public int GetCount()
		{
			return -1;
		}

		public TJSONArray()
		{
		}

		public TJSONArray(TJSONValue FirstElem)
		{
		}

		public TJSONArray(TJSONValue FirstElem, TJSONValue SecondElem)
		{
		}

		public TJSONArray(string FirstElem, string SecondElem)
		{
		}

		public int Count
		{
			get
			{
				return GetCount();
			}
		}

		public TJSONValue this[int Index]
		{
			get
			{
				return GetValue(Index);
			}
		}


		public TJSONValue Remove(int Index)
		{
			return null;
		}

		public void AddElement(TJSONValue Element)
		{

		}

		public TJSONArray Add(string Element)
		{
			return null;
		}

		public TJSONArray Add(int Element)
		{
			return null;
		}

		public TJSONArray Add(Double Element)
		{
			return null;
		}

		public TJSONArray Add(bool Element)
		{
			return null;
		}

		public TJSONArray Add(TJSONObject Element)
		{
			return null;
		}

		public TJSONArray Add(TJSONArray Element)
		{
			return null;
		}

		public override int EstimatedByteSize()
		{
			return -1;
		}

		public void SetElements(TList<TJSONValue> AList)
		{
		}

		public override int ToBytes(Byte[] Data, int Pos)
		{
			return -1;
		}

		public override string ToString()
		{
			return "";
		}

		public override TJSONAncestor Clone()
		{
			return null;
		}

		//public TJSONArrayEnumerator GetEnumerator()

		public int Size()
		{
			return -1;
		}

		public TJSONValue Get(int Index)
		{
			return null;
		}
	}  
}
