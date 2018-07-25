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
using System.Reflection;
using System.IO;

namespace System.Classes
{
    /// <summary>
    /// Exception for Component derived errors
    /// </summary>
    public class EComponentError : EException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="System.Classes.EComponentError"/> class. And allows you to specify a format string and parameters
        /// </summary>
        /// <param name="format">Format.</param>
        /// <param name="args">Arguments.</param>
        public EComponentError(string format, params object[] args) : base(format, args)
        {
        }
    }

    /// <summary>
    /// Exception for invalid operations
    /// </summary>
    public class EInvalidOperation : EException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="System.Classes.EInvalidOperation"/> class. And allows you to specify a format string and parameters
        /// </summary>
        /// <param name="format">Format.</param>
        /// <param name="args">Arguments.</param>
        public EInvalidOperation(string format, params object[] args) : base(format, args)
        {
        }
    }

    public delegate void TNotifyEvent(object sender, EventArgs e);

    public enum TShiftState
    {
        ssShift, ssAlt, ssCtrl,
        ssLeft, ssRight, ssMiddle, ssDouble, ssTouch, ssPen, ssCommand, ssHorizontal
    };

    /// <summary>
    /// Alignment for the label
    /// </summary>
    public enum TAlignment { taCenter, taLeftJustify, taRightJustify };

    //TODO
    public class TFiler : TObject
    {
    }


    /// <summary>
    /// Interface to implement a notification pattern
    /// </summary>
    public interface IChangeNotifier
    {
        void Changed();
    }


    /// <summary>
    /// A class to implement object persistance
    /// </summary>
    public class TPersistent : TObject
    {
        /// <summary>
        /// The pointer to the native object this object is wrapping
        /// </summary>
        public object Handle;

        /// <summary>
        /// Gets or sets the notifier used to notify changes in this object
        /// </summary>
        /// <value>The notifier.</value>
        public IChangeNotifier Notifier
        {
            get;
            set;
        }

        public TPersistent()
        {
        }

        /// <summary>
        /// Assign the source object to this one
        /// </summary>
        /// <param name="Source">Source.</param>
        public virtual void Assign(TPersistent Source)
        {
            if (Source != null)
                Source.AssignTo(this);
            else
                AssignError(null);
        }

        /// <summary>
        /// Raises an assign error
        /// </summary>
        /// <param name="Source">Source.</param>
        private void AssignError(TPersistent Source)
        {
            string SourceName;

            if (Source != null)
            {
                SourceName = Source.ClassName();
            }
            else
            {
                SourceName = "null";
            }

            throw new EConvertError(RTLConsts.SAssignError, SourceName, ClassName());
        }

        /// <summary>
        /// Assigns this objects to Dest
        /// </summary>
        /// <param name="Dest">Destination.</param>
        protected virtual void AssignTo(TPersistent Dest)
        {
            Dest.AssignError(this);
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
            string Result = ClassName();

            if (GetOwner() != null)
            {
                S = GetOwner().GetNamePath();
            }

            if (S != "")
            {
                Result = S + "." + Result;
            }

            return (Result);
        }

        /// <summary>
        /// Returns the owner of this object
        /// </summary>
        /// <returns>The owner.</returns>
        protected virtual TPersistent GetOwner()
        {
            return (null);
        }
    }

    public class TCollectionItem : TPersistent
    {
        private TCollection FCollection;
        public TCollection Collection
        {
            get
            {
                return FCollection;
            }
            set
            {
                SetCollection(value);
            }
        }

        private int FID;
        public int ID
        {
            get
            {
                return FID;
            }
        }

        private int GetIndex()
        {
            return -1; // TODO
        }

        protected void Changed(Boolean AllItems)
        {
        }

        protected override TPersistent GetOwner()
        {
            return null; // TODO
        }

        protected virtual string GetDisplayName()
        {
            return ""; // TODO
        }

        protected virtual void SetCollection(TCollection AValue)
        {
        }

        protected virtual void SetIndex(int Value)
        {
        }

        protected virtual void SetDisplayName(string AValue)
        {
        }

        public TCollectionItem(TCollection Collection)
        {
        }

        public virtual void Release()
        {
        }

        public override string GetNamePath()
        {
            return "";
        }

        public int Index
        {
            get
            {
                return GetIndex();
            }
            set
            {
                SetIndex(value);
            }
        }

        public string DisplayName
        {
            get
            {
                return GetDisplayName();
            }
            set
            {
                SetDisplayName(value);
            }
        }
    }

    public enum TCollectionNotification { cnAdded, cnExtracting, cnDeleting };

    public class TCollection : TPersistent
    {
        private Type FItemClass;
        public Type ItemClass
        {
            get
            {
                return FItemClass;
            }
        }

        private TList<TCollectionItem> FItems;

        private int FUpdateCount;
        protected int UpdateCount
        {
            get
            {
                return FUpdateCount;
            }
        }

        private int FNextID;

        private string FPropName;
        protected string PropName
        {
            get
            {
                return GetPropName();
            }
            set
            {
                FPropName = value;
            }
        }

        private int GetCapacity()
        {
            return FItems.Count;
        }

        private string GetPropName()
        {
            return ""; // TODO
        }

        private void InsertItem(TCollectionItem Item)
        {
            FItems.Add(Item);
            // TODO refresh
        }

        private void RemoveItem(TCollectionItem Item)
        {
            FItems.Remove(Item);
            // TODO refresh
        }

        private void SetCapacity(int Value)
        {
            FItems.Capacity = Value;
        }

        protected int NextID
        {
            get
            {
                return FNextID;
            }
        }

        protected virtual void Notify(TCollectionItem Item, TCollectionNotification Action)
        {
        }

        /*{ Design-time editor support
		}
		function GetAttrCount: Integer; dynamic;
    	function GetAttr(Index: Integer): string; dynamic;
    	function GetItemAttr(Index, ItemIndex: Integer): string; dynamic;
    	*/

        /*protected void Changed
		{
		}
		*/
        protected TCollectionItem GetItem(int Index)
        {
            return FItems[Index];
        }

        protected void SetItem(int Index, TCollectionItem Value)
        {
            FItems[Index] = Value;
            // TODO refresh
        }

        protected virtual void SetItemName(TCollectionItem Item)
        {
        }

        protected virtual void Update(TCollectionItem Item)
        {
        }

        public TCollection(Type ItemClass)
        {
            FItemClass = ItemClass;
            FItems = new TList<TCollectionItem>();
        }

        public TPersistent Owner()
        {
            return null; // TODO
        }

        public TCollectionItem Add()
        {
            var LInfo = FItemClass.GetTypeInfo();
            foreach (var ctor in LInfo.DeclaredConstructors)
            {
                var LPars = ctor.GetParameters();
                if ((LPars.Count() == 1) /*&& (lPars[0].GetType() == typeof(TCollection))*/)
                {
                    object[] args = { this };
                    var LItem = (TCollectionItem)ctor.Invoke(args);
                    FItems.Add(LItem);
                    return LItem;
                }
            }

            return null;
        }

        public override void Assign(TPersistent Source)
        {
        }

        public virtual void BeginUpdate()
        {
        }

        public void Clear()
        {
            BeginUpdate();
            try
            {
                FItems.Clear();
            }
            finally
            {
                EndUpdate();
            }
        }

        public void Delete(int Index)
        {
            FItems.Delete(Index);
            // TODO refresh
        }

        public virtual void EndUpdate()
        {
        }

        public TCollectionItem FindItemID(int ID)
        {
            return null; // TODO
        }

        /*public TCollectionEnumerator GetEnumerator
		{
		}*/

        public override String GetNamePath()
        {
            return ""; // TODO
        }

        public TCollectionItem Insert(int Index)
        {
            return null;
        }

        public int Capacity
        {
            get
            {
                return GetCapacity();
            }
            set
            {
                SetCapacity(value);
            }
        }

        public int Count
        {
            get
            {
                return FItems.Count;
            }
        }

        public TCollectionItem this[int Index]
        {
            get
            {
                return GetItem(Index);
            }
            set
            {
                SetItem(Index, value);
            }
        }
    }

    public class TOwnedCollection : TCollection
    {
        private TPersistent FOwner;

        protected override TPersistent GetOwner()
        {
            return FOwner;
        }

        public TOwnedCollection(TPersistent AOWner, Type ItemClass) : base(ItemClass)
        {
            FOwner = AOWner;
        }
    }

    public class TStringsOptions : TSet
    {
        public static int soStrictDelimiter = 1;
        public static int soWriteBOM = 2;
        public static int soTrailingLineBreak = 4;
        public static int soUseLocale = 8;
    }

    public abstract class TStrings : TPersistent
    {

        private TEncoding FEncoding;

        private TEncoding FDefaultEncoding;

        private string FLineBreak;

        //private IStringAdapter FAdapter;

        private int FUpdateCount;

        private char FDelimiter;

        private char FQuoteChar;

        private char FNameValueSeparator;

        private TStringsOptions FOptions;

        private string GetCommaText()
        {
            return ""; // TODO
        }

        private string GetDelimitedText()
        {
            return ""; // TODO
        }

        private string GetName(int Index)
        {
            return ""; // TODO
        }

        private string GetValue(string Name)
        {
            return ""; // TODO
        }

        //private void ReadData(TReader Reader)

        private void SetCommaText(string Value)
        {
        }

        private void SetDelimitedText(string Value)
        {
        }

        //private void SetStringAdapter(IStringsAdapter Value)

        private void SetValue(string Name, string Value)
        {
        }

        //private void WriteData(TWriter Writer)

        private Boolean GetStrictDelimiter()
        {
            return false; // TODO
        }

        private void SetStrictDelimiter(Boolean Value)
        {
        }

        private string GetValueFromIndex(int Index)
        {
            return ""; // TODO
        }

        private void SetValueFromIndex(int Index, string Value)
        {
        }

        private void SetDefaultEncoding(TEncoding Value)
        {
        }

        private Boolean GetTrailingLineBreak()
        {
            return false; // TODO
        }

        private void SetTrailingLineBreak(Boolean Value)
        {
        }

        private Boolean GetUseLocale()
        {
            return false; // TODO
        }

        private void SetUseLocale(Boolean Value)
        {
        }

        private Boolean GetWriteBOM()
        {
            return false; // TODO
        }

        private void SetWriteBOM(Boolean Value)
        {
        }

        private Boolean GetUpdating()
        {
            return false; // TODO
        }

        private string GetKeyName(int Index)
        {
            return ""; // TODO
        }

        //protected override void DefineProperties(TFIler Filer);

        protected void Error(string Msg, int Data)
        {
        }

        protected string ExtractName(string S)
        {
            return ""; // TODO
        }

        protected string ExtractName(string S, Boolean AllNames)
        {
            return ""; // TODO
        }

        protected abstract string Get(int Index);

        public virtual int GetCapacity()
        {
            return GetCount();
        }

        protected abstract int GetCount();

        public virtual TObject GetObject(int Index)
        {
            return null;
        }

        protected virtual string GetTextStr()
        {
            return ""; // TODO
        }

        public virtual void PutObject(int Index, TObject AObject)
        {
        }

        protected virtual void SetCapacity(int NewCapacity)
        {
        }

        protected virtual void SetEncoding(TEncoding Value)
        {
        }

        protected virtual void SetTextStr(string Value)
        {
        }

        protected virtual int CompareStrings(string S1, string S2)
        {
            return -1; // TODO
        }

        protected int UpdateCount
        {
            get
            {
                return FUpdateCount;
            }
        }

        protected virtual void SetUpdateState(Boolean Updating)
        {
        }

        protected virtual void Put(int Index, string S)
        {
        }

        public virtual int Add(string S)
        {
            var LRes = GetCount();
            Insert(LRes, S);
            return LRes;
        }

        public virtual int AddObject(string S, TObject AObject)
        {
            var LRes = Add(S);
            PutObject(LRes, AObject);
            return LRes;
        }

        public abstract void Clear();
        public abstract void Delete(int Index);
        public abstract void Insert(int Index, string S);

        public TStrings()
        {
        }

        public TStrings AddPair(string Name, string Value)
        {
            Add(Name + NameValueSeparator + Value);
            return this;
        }

        public TStrings AddPair(string Name, string Value, TObject AObject)
        {
            AddObject(Name + NameValueSeparator + Value, AObject);
            return this;
        }

        public void Append(string S)
        {
            Add(S);
        }

        public virtual void AddStrings(TStrings Strings)
        {
            BeginUpdate();
            try
            {
                //for (int I = 0; I < Strings.Count; I++)
                //AddObject(Strings.[I], Strings[I].Objects[I]);
            }
            finally
            {
                EndUpdate();
            }
        }

        //public void AddStrings(TArray<string> Strings)
        //public void AddStrings(TArray<string> Strings, TArray<TObject> Objects)
        public override void Assign(TPersistent Source)
        {
        }

        public void SetStrings(TStrings Source)
        {
        }

        public void BeginUpdate()
        {
        }

        public void EndUpdate()
        {
        }

        public Boolean Equals(TStrings Strings)
        {
            return false; // TODO
        }

        public virtual void Exchange(int Index1, int Index2)
        {
        }

        //public TStringsEnumerator GetEnumerator()
        //function GetText: PChar; virtual;

        public virtual int IndexOf(string S)
        {
            for (int I = 0; I < GetCount(); I++)
                if (CompareStrings(Get(I), S) == 0)
                    return I;

            return -1;
        }

        public virtual int IndexOfName(string Name)
        {
            for (int I = 0; I < GetCount(); I++)
            {
                var LPos = Get(I).IndexOf(NameValueSeparator);
                if (LPos >= 0 && String.Compare(Get(I).Substring(0, LPos), Name) == 0)
                    return I;
            }

            return -1;
        }

        public virtual int IndexOfObject(TObject AObject)
        {
            for (int I = 0; I < GetCount(); I++)
                if (GetObject(I) == AObject)
                    return I;

            return -1;
        }

        public virtual void InsertObject(int Index, string S, TObject AObject)
        {
            Insert(Index, S);
            PutObject(Index, AObject);
        }

        public virtual void LoadFromFile(string FileName)
        {
        }

        public virtual void LoadFromFile(string FileName, TEncoding Encoding)
        {
        }

        //public virtual void LoadFromStream(TStream Stream)
        //public virtual LoadFromStream(TStream Stream; TEncoding Encoding)
        public virtual void Move(int CurIndex, int NewIndex)
        {
            if (CurIndex != NewIndex)
            {
                BeginUpdate();
                try
                {
                    var LString = Get(CurIndex);
                    var LObject = GetObject(CurIndex);
                    Delete(CurIndex);
                    InsertObject(NewIndex, LString, LObject);
                }
                finally
                {
                    EndUpdate();
                }
            }
        }

        public virtual void SaveToFile(string FileName)
        {
        }

        public virtual void SaveToFile(string FileName, TEncoding Encoding)
        {
        }

        //pubic virtual void SaveToStream(TStream Stream)
        //public virtual void SaveToStream(TStream Stream; TEncoding Encoding)
        //public virtual void SetText(Text: PChar)
        //public void TArray<string> ToStringArray()
        //public TArray<TObject> function ToObjectArray()

        public Boolean Updating
        {
            get
            {
                return GetUpdating();
            }
        }

        public int Capacity
        {
            get
            {
                return GetCapacity();
            }
            set
            {
                SetCapacity(value);
            }
        }

        public string CommaText
        {
            get
            {
                return GetCommaText();
            }
            set
            {
                SetCommaText(value);
            }
        }

        public int Count
        {
            get
            {
                return GetCount();
            }
        }

        public TEncoding DefaultEncoding
        {
            get
            {
                return FDefaultEncoding;
            }
            set
            {
                SetDefaultEncoding(value);
            }
        }

        public Char Delimiter
        {
            get
            {
                return FDelimiter;
            }
            set
            {
                FDelimiter = value;
            }
        }

        public string DelimitedText
        {
            get
            {
                return GetDelimitedText();
            }
            set
            {
                SetDelimitedText(value);
            }
        }

        public TEncoding Encoding
        {
            get
            {
                return FEncoding;
            }
        }

        public string LineBreak
        {
            get
            {
                return FLineBreak;
            }
            set
            {
                FLineBreak = value;
            }
        }

        //public property Names[Index: Integer]: string read GetName;
        //property KeyNames[Index: Integer]: string read GetKeyName;
        //property Objects[Index: Integer]: TObject read GetObject write PutObject;
        public Char QuoteChar
        {
            get
            {
                return FQuoteChar;
            }
            set
            {
                FQuoteChar = value;
            }
        }
        //property Values[const Name: string]: string read GetValue write SetValue;
        //property ValueFromIndex[Index: Integer]: string read GetValueFromIndex write SetValueFromIndex;
        public Char NameValueSeparator
        {
            get
            {
                return FNameValueSeparator;
            }
            set
            {
                FNameValueSeparator = value;
            }
        }

        public Boolean StrictDelimiter
        {
            get
            {
                return GetStrictDelimiter();
            }
            set
            {
                SetStrictDelimiter(value);
            }
        }
        //property Strings[Index: Integer]: string read Get write Put; default;
        public string Text
        {
            get
            {
                return GetTextStr();
            }
            set
            {
                SetTextStr(value);
            }
        }

        //property StringsAdapter: IStringsAdapter read FAdapter write SetStringsAdapter;
        public Boolean WriteBOM
        {
            get
            {
                return GetWriteBOM();
            }
            set
            {
                SetWriteBOM(value);
            }
        }

        public Boolean TrailingLineBreak
        {
            get
            {
                return GetTrailingLineBreak();
            }
            set
            {
                SetTrailingLineBreak(value);
            }
        }

        public Boolean UseLocale
        {
            get
            {
                return GetUseLocale();
            }
            set
            {
                SetUseLocale(value);
            }
        }

        public string this[int index]
        {
            get
            {
                return Get(index);
            }
            set
            {
                Put(index, value);
            }
        }

        public TStringsOptions Options
        {
            get
            {
                return FOptions;
            }
            set
            {
                FOptions = value;
            }
        }
    }

    public class TStringList : TStrings
    {
        private TList<Tuple<string, TObject>> FList;

        private Boolean fSorted;
        public Boolean Sorted
        {
            get
            {
                return fSorted;
            }
            set
            {
                // TODO
            }
        }

        protected virtual void Changing()
        {

        }

        protected virtual void Changed()
        {

        }

        protected override void SetUpdateState(Boolean Updating)
        {
            if (Updating)
                Changing();
            else
                Changed();
        }

        protected override void Put(int Index, string S)
        {
            FList[Index] = new Tuple<string, TObject>(S, null);
        }

        protected override int GetCount()
        {
            return FList.Count;
        }

        protected override string Get(int Index)
        {
            return FList[Index].Item1;
        }

        protected virtual void InsertItem(int Index, string S, TObject AObject)
        {
            Changing();
            FList.Insert(Index, new Tuple<string, TObject>(S, AObject));
            Changed();
        }

        public override int GetCapacity()
        {
            return FList.Count;
        }

        public override int Add(string S)
        {
            return AddObject(S, null);
        }

        public override int AddObject(string S, TObject AObject)
        {
            var LItem = new Tuple<string, TObject>(S, AObject);
            FList.Add(LItem);
            return FList.Count;
        }

        public override void Clear()
        {
            FList.Clear();
        }

        public override void Delete(int Index)
        {
            FList.Delete(Index);
        }

        public override void Exchange(int Index1, int Index2)
        {
            // TODO check index..

            var LItem = FList[Index1];
            FList[Index1] = FList[Index2];
            FList[Index2] = LItem;
        }

        public Boolean Find(string S, ref int Index)
        {
            return false;
        }

        public override int IndexOf(string S)
        {
            int LRes = 0;

            if (!Sorted)
                return base.IndexOf(S);
            else
                if (Find(S, ref LRes))
                return LRes;
            else
                return -1;
        }

        public override void Insert(int Index, string S)
        {
            FList.Insert(Index, new Tuple<string, TObject>(S, null));
        }

        public override void InsertObject(int Index, string S, TObject AObject)
        {
            // TODO
            //if (Sorted)
            //throw Exception(

            InsertItem(Index, S, AObject);
        }

        public new string this[int index]
        {
            get
            {
                return FList[index].Item1;
            }
        }

        public TStringList()
        {
            FList = new TList<Tuple<string, TObject>>();
        }
    }

    public enum TSeekOrigin { soBeginning = 0, soCurrent = 1, soEnd = 2 };

    public abstract class TStream : TObject
    {
        protected virtual Int64 GetSize()
        {
            Int64 LPos;
            LPos = Seek(0, TSeekOrigin.soCurrent);
            var LRes = Seek(0, TSeekOrigin.soEnd);
            Seek(LPos, TSeekOrigin.soBeginning);
            return LRes;
        }

        public virtual void SetSize(int NewSize)
        {
            // Do nothing
        }

        public virtual void SetSize(Int64 NewSize)
        {
            SetSize(NewSize);
        }

        public virtual int Read(byte[] Buffer, int Offset, int Count)
        {
            return 0;
        }

        public virtual int Write(byte[] Buffer, int Offset, int Count)
        {
            return 0;
        }

        public virtual int Read(byte[] Buffer, int Count)
        {
            return Read(Buffer, 0, Count);
        }

        public virtual int Write(byte[] Buffer, int Count)
        {
            return Write(Buffer, 0, Count);
        }

        public virtual long Seek(int Offset, Int16 Origin)
        {
            return Seek((Int64)Offset, (TSeekOrigin)Origin);
        }

        public virtual long Seek(Int64 Offset, TSeekOrigin Origin)
        {
            return 0;
        }

        public virtual long Seek(Int64 Offset, Int16 Origin)
        {
            return Seek(Offset, (TSeekOrigin)Origin);
        }

        public Int64 CopyFrom(TStream Source, Int64 Count)
        {
            var LBufSize = 16 * 1024;
            var LTotal = Count;
            var LBuffer = new byte[LBufSize];
            Int64 LIndex = 0;
            Int64 LToRead;

            while (LTotal > 0)
            {
                if (LBufSize > LTotal)
                    LToRead = LTotal;
                else
                    LToRead = LBufSize;
                Source.Read(LBuffer, (int)LIndex, (int)LToRead);
                Write(LBuffer, (int)LIndex, (int)LToRead);
                LTotal -= LToRead;
                LIndex += LToRead;
            }

            return Count;
        }

        public virtual Int64 GetPosition()
        {
            return Seek(0, TSeekOrigin.soCurrent);
        }

        public virtual void SetPosition(Int64 APos)
        {
            Seek(APos, TSeekOrigin.soBeginning);
        }

        public virtual Int64 Position
        {
            get
            {
                return GetPosition();
            }

            set
            {
                SetPosition(value);
            }
        }

        public virtual Int64 Size
        {
            get
            {
                return GetSize();
            }

            set
            {
                Size = value;
            }
        }

        public SeekOrigin ConvertSeekOrigin(Int16 Origin)
        {
			switch (Origin)
			{
				case (int)TSeekOrigin.soBeginning:
					return SeekOrigin.Begin;

				case (int)TSeekOrigin.soCurrent:
					return SeekOrigin.Current;

				case (int)TSeekOrigin.soEnd:
					return SeekOrigin.End;

                default: 
                    return SeekOrigin.Current;
			}
        }
    }

    public class THandleStream : TStream
    {
#if __IOS__ || __ANDROID
        protected FileStream FHandle;

        protected void SetHandle(FileStream AHandle)
        {
            FHandle = AHandle;
        }

        public override void SetSize(int NewSize)
        {
            SetSize((Int64)NewSize);    
        }

        public override void SetSize(Int64 NewSize)
        {
            FHandle.Seek(NewSize, SeekOrigin.Begin);
        }

        /*public THandleStream(FileStream AHandle): base()
        {
            SetHandle(AHandle);
        }*/

        public override int Read(byte[] Buffer, int Count)
        {
            return FHandle.Read(Buffer, 0, Count);
        }  

        public override int Write(byte[] Buffer, int Count)
        {
            FHandle.Write(Buffer, 0, Count);
            return Count;
        }

        public override int Read(byte[] Buffer, int Offset, int Count)
        {
            return FHandle.Read(Buffer, Offset, Count);
        }

        public override int Write(byte[] Buffer, int Offset, int Count)
        {
            FHandle.Write(Buffer, Offset, Count);
            return Count;
        }
                     
        public override long Seek(long Offset, short Origin)
        {
            SeekOrigin LOrigin = ConvertSeekOrigin(Origin);
            return FHandle.Seek(Offset, LOrigin);
        }

        public FileStream Handle
        {
            get
            {
                return FHandle;
            }
        }
#endif
    }

    public enum TFileOpenMode { fmOpenRead = 0, fmOpenWrite = 1, fmOpenReadWrite = 2, fmCreate = 0xff }

    public class TFileStream : THandleStream
    {
#if __IOS__ || __ANDROID
        private String FFileName;

        public TFileStream(String AFileName, Int16 Mode): base()
        {
            FileStream LFile;
            FileMode LFileMode = FileMode.Open;
            FileAccess LFileAccess = FileAccess.Read;

            switch(Mode)
            {
                case (int)TFileOpenMode.fmCreate:
                    LFileMode = FileMode.OpenOrCreate;
                    LFileAccess = FileAccess.Write;
                    break;

                case (int)TFileOpenMode.fmOpenRead:
                    LFileMode = FileMode.Open;
                    break;

                case (int)TFileOpenMode.fmOpenWrite:
                    LFileAccess = FileAccess.Write;
                    break;

                case (int)TFileOpenMode.fmOpenReadWrite:
                    LFileAccess = FileAccess.ReadWrite;
                    break;
            }

            FFileName = AFileName;
            LFile = new FileStream(AFileName, LFileMode, LFileAccess);
            SetHandle(LFile);
        }

        public TFileStream(String AFileName, Int16 Mode, uint Rights): this(AFileName, Mode)
        {
            
        }

        public String FileName
        {
            get
            {
                return FFileName;
            }
        }
#endif
    }

    public class TCustomMemoryStream : TStream
    {
#if __IOS__ || __ANDROID
        protected MemoryStream FInternalStream;

        public TCustomMemoryStream(): base()
        {
            FInternalStream = new MemoryStream();
        }

        public override int Read(byte[] Buffer, int Offset, int Count)
        {
            return FInternalStream.Read(Buffer, Offset, Count);
        }

        public override long Seek(int Offset, short Origin)
        {
            SeekOrigin LOrigin = ConvertSeekOrigin(Origin);
            return FInternalStream.Seek(Offset, LOrigin);
        }

        public void SaveToStream(TStream AStream)
        {
            var LBuffer = FInternalStream.GetBuffer();
            AStream.Write(LBuffer, 0, (int)FInternalStream.Length);
        }

        public void SaveToFile(string AFileName)
        {
            var LStream = new TFileStream(AFileName, (int)TFileOpenMode.fmOpenWrite);
            SaveToStream(LStream);
        }
#endif
    }

    public class TMemoryStream : TCustomMemoryStream
    {
#if __IOS__ || __ANDROID

		protected int Capacity
        {
            get
            {
                return FInternalStream.Capacity;
            }

            set
            {
                FInternalStream.Capacity = value;
            }
        }

        public void Clear()
        {
            FInternalStream.Capacity = 0;
        }

        public void LoadFromStream(TStream AStream)
        {
            Clear();
            CopyFrom(AStream, AStream.Size);
        }

        public void LoadFromFile(string AFileName)
        {
            var LStream = new TFileStream(AFileName, (int)TFileOpenMode.fmOpenRead);
            LoadFromStream(LStream);
        }

        public override void SetSize(int NewSize)
        {
            SetSize((long)NewSize);
        }

        public override void SetSize(long NewSize)
        {
            FInternalStream.Capacity = (int)NewSize;
        }

        public override int Write(byte[] Buffer, int Offset, int Count)
        {
            return base.Write(Buffer, Offset, Count);
        }
#endif
    }

    public class TBytesStream: TMemoryStream
    {
        public TBytesStream(byte[] ABytes): base()
        {
            
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

		/// <summary>
		/// Invokes an event using the invocation list
		/// </summary>
		/// <param name="AnEvent">An event with all the methods to call</param>
		/// <param name="sender">Sender to be sent</param>
		/// <param name="e">Arguments for the event</param>
		protected void DoEvent(Delegate AnEvent, object sender, EventArgs e)
		{
			var eventList = AnEvent.GetInvocationList().ToList();
			object[] args = { this, e };
			foreach (var item in eventList) {
				item.DynamicInvoke(args);
			}			
		}

		/// <summary>
		/// Called to call the handle for Components, not for Controls
		/// </summary>
		protected virtual void CreateNonVisualHandle()
		{
		}

		//Done
		public TComponent(TComponent AOwner)
		{
			CreateNonVisualHandle ();
			FComparer = new TComponentComparer ();
			FComponentState = new TComponentState ();
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
			FComponentState.Include (TComponentState.csFreeNotification);
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

        public virtual void Loaded()
        {
            
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

			if ((ComponentState.In(TComponentState.csDesigning)) && (Owner!=null))
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
			if ((ComponentState.In(TComponentState.csDesigning))) {
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
				FComponentState.Include(TComponentState.csDesigning);
			else
				FComponentState.Exclude(TComponentState.csDesigning);

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

