using System.Base;
using System.Classes;
using System.JSON;
using System;
using System.Net;
using System.IO;

namespace REST
{

	public class TRESTRequestParameter: TCollectionItem
	{
		public TRESTRequestParameter(TCollection ACollection) : base(ACollection)
		{
		}

		public override string ToString()
		{
			return "";
		}

		protected override string GetDisplayName()
		{
			return "";
		}

		private TRESTRequestParameterKind FKind;
		public TRESTRequestParameterKind Kind
		{
			get
			{
				return FKind;
			}
			set
			{
				// SetKind
				FKind = value;
			}
		}

		private string FName;
		public string Name
		{
			get
			{
				return FName;
			}
			set
			{
				// SetName
				FName = value;
			}
		}

		private TRESTRequestParameterOptions FOptions;
		public TRESTRequestParameterOptions Options
		{
			get
			{
				return FOptions;
			}
			set
			{
				// SetOptions
				FOptions = value;
			}
		}

		private string FValue;
		public string Value
		{
			get
			{
				return FValue;
			}
			set
			{
				// SetName
				FValue = value;
			}
		}

		private TRESTContentType FContentType;
		public TRESTContentType ContentType
		{
			get
			{
				return FContentType;
			}
			set
			{
				// SetContentType
				FContentType = value;
			}
		}
				
	}

	public class TRESTRequestBytesParameter : TRESTRequestParameter
	{
		private byte[] FBytes;

		public TRESTRequestBytesParameter(TCollection ACollection) : base(ACollection)
		{
		}

		public byte[] Bytes
		{
			get
			{
				return FBytes;
			}
			set
			{
				FBytes = value;
			}
		}
	}

	public class TRESTRequestParameterList : TOwnedCollection
	{
		protected new TRESTRequestParameter GetItem(int AIndex)
		{
			return (TRESTRequestParameter)base.GetItem(AIndex);
		}

		protected void SetItem(int AIndex, TRESTRequestParameter AValue)
		{
			base.SetItem(AIndex, AValue);
		}

		public TRESTRequestParameterList(TComponent AOwner): base(AOwner, typeof(TRESTRequestParameter))
		{
		}

		public TRESTRequestParameter AddCookie(string AName, string AValue)
		{
			return null;
		}

		public TRESTRequestParameter AddHeader(string AName, string AValue)
		{
			return null;
		}

		public void AddObject(TObject AObject)
		{
		}

		public void AddObject(TObject AObject, TStrings WhiteList)
		{
		}

		public TRESTRequestParameter AddItem()
		{
			return (TRESTRequestParameter)Add();
		}

		public TRESTRequestParameter AddItem(string AName, string AValue, TRESTRequestParameterKind AKind, TRESTRequestParameterOptions AOptions = null)
		{
			return AddItem(AName, AValue, AKind, AOptions, TRESTContentType.ctNone);
		}

		public new TRESTRequestParameter this[int Index]
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

		public void Delete(TRESTRequestParameter AParam)
		{
			var LIndex = IndexOf(AParam);
			if (LIndex > -1)
				Delete(LIndex);
		}

		public void Delete(string AName)
		{
			var LIndex = IndexOf(AName);
			if (LIndex > -1)
				Delete(LIndex);
		}

		public int IndexOf(TRESTRequestParameter AParam)
		{
			if (AParam == null)
				return -1;
			
			for (int I = 0; I < Count - 1; I++)
				if (AParam == GetItem(I))
					return I;

			return -1;
		}

		public int IndexOf(string AName)
		{
			if (AName == "")
				return -1;
			
			var LName = AName.ToLower();
			for (int I = 0; I < Count - 1; I++)
				if (LName == GetItem(I).Name.ToLower())
					return I;

			return -1;
		}

		public TRESTRequestParameter AddItem(string AName, string AValue)
		{
			return AddItem(AName, AValue, TRESTRequestParameterKind.pkGETorPOST);
		}

		public TRESTRequestParameter AddItem(string AName, string AValue, TRESTRequestParameterKind AKind, TRESTRequestParameterOptions AOptions, TRESTContentType AContentType)
		{			
			TRESTRequestParameter LParam;

			BeginUpdate();
			try
			{
				var I = IndexOf(AName);
				if (I == -1)
					LParam = (TRESTRequestParameter)base.Add();
				else
					LParam = GetItem(I);

				LParam.Name = AName;
				LParam.Value = AValue;
				LParam.Kind = AKind;
				LParam.Options = AOptions;
				LParam.ContentType = AContentType;

				return LParam;
			}
			finally
			{
				EndUpdate();
			}
		}

		public TRESTRequestParameter AddItem(string AName, byte[] AValue, TRESTRequestParameterKind AKind, TRESTRequestParameterOptions AOptions, TRESTContentType AContentType)
		{
			TRESTRequestParameter LToReturn;

			BeginUpdate();
			try
			{
				var I = IndexOf(AName);
				if (I == -1)
					LToReturn = new TRESTRequestBytesParameter(this);
				else
					LToReturn = GetItem(I);
				if (LToReturn is TRESTRequestBytesParameter)
					((TRESTRequestBytesParameter)LToReturn).Bytes = AValue;
				else
					throw new Exception("Parameter error");
				LToReturn.Kind = AKind;
				LToReturn.Name = AName;
				LToReturn.Options = AOptions;

				return LToReturn;
			}
			finally
			{
				EndUpdate();
			}
		}

		public void AddUrlSegment(string AName, string AValue)
		{
		}

		public TRESTRequestParameter ParameterByName(string AName)
		{
			TRESTRequestParameter LItem;

			for (int I = 0; I < Count; I++)
			{
				LItem = GetItem(I);
				if (string.Compare(AName, LItem.Name) == 0)
					return LItem;
			}
			return null;
		}

		public TRESTRequestParameter ParameterByIndex(int AIndex)
		{
			return GetItem(AIndex);
		}

		public bool ContainsParameter(string AName)
		{
			return IndexOf(AName) >= 0;
		}

		public bool CreateURLSegmentsFromString(string AUrlPath)
		{
			return false;
		}

		public void CreateGetparamsFromUrl(string AUrlPath)
		{
			
		}
	}

	public class TBodyParams : TObject
	{
		public static void Add(TRESTRequestParameterList AParams, string ABodyContent, TRESTContentType AContentType = TRESTContentType.ctNone)
		{
			
		}

		public static void Add(TRESTRequestParameterList AParams, TJSONObject AObject)
		{
		}
	}

	public class TBody : TObject
	{
		private TRESTRequestParameterList FParams;

		public TBody()
		{
			FParams = new TRESTRequestParameterList(null);
		}

		public void Add(string ABodyContent, TRESTContentType AContentType = TRESTContentType.ctNone)
		{
		}

		public void Add(TJSONObject AObject)
		{
		}

		//public void Add(TStream ABodyContent, TRESTContentType AContentType = TRESTContentType.ctNone)

		public void ClearBody()
		{
		}

		//public TJsonWriter JSONWriter;
	}

	public class TCustomRESTRequest : TComponent
	{
		private HttpWebRequest FInternalRequest;

		private void ProcessResponse(HttpWebResponse AResponse)
		{
			FResponse.ResetToDefaults();
			FResponse.FullRequestURI = AResponse.ResponseUri.ToString();
			FResponse.Server = AResponse.Headers["server"];
			FResponse.ContentType = AResponse.ContentType;
			FResponse.ContentEncoding = AResponse.Headers["Content-Encoding"];
			FResponse.StatusCode = (int)(AResponse.StatusCode);
			FResponse.StatusText = AResponse.StatusDescription;
			foreach (string LKey in AResponse.Headers)
				FResponse.Headers.Add(LKey + "=" + AResponse.Headers[LKey]);

			var LReader = new StreamReader(AResponse.GetResponseStream());
			var LContent = LReader.ReadToEnd();
			FResponse.SetContent(LContent);
			FResponse.SetRawBytes(LReader.BaseStream);
		}

		public TCustomRESTRequest(TComponent AOwner) : base(AOwner)
		{
			FParams = new TRESTRequestParameterList(this);
			FTransientParams = new TRESTRequestParameterList(this);
		}

		public TRESTContentType ContentType()
		{
			return TRESTContentType.ctNone;
		}

		public TRESTContentType ContentType(TRESTRequestParameter[] AParamsArray)
		{
			return TRESTContentType.ctNone;
		}

		public void AddParameter(string AName, string AValue)
		{
			AddParameter(AName, AValue, TRESTRequestParameterKind.pkGETorPOST, new TRESTRequestParameterOptions());
		}

		public void AddParameter(string AName, TJSONObject AJsonObject, bool AFreeJson = true)
		{
		}

		public void AddParameter(string AName, string AValue, TRESTRequestParameterKind AKind)
		{
			AddParameter(AName, AValue, AKind, new TRESTRequestParameterOptions());
		}

		public void AddParameter(string AName, string AValue, TRESTRequestParameterKind AKind, TRESTRequestParameterOptions AOptions)
		{
			if (AOptions != null && AOptions.In(TRESTRequestParameterOptions.poTransient))
			{
				if (TransientParams.ParameterByName(AName) != null)
					TransientParams.Delete(AName);
				TransientParams.AddItem(AName, AValue, AKind, AOptions);
			}
			else
			{
				if (Params.ParameterByName(AName) != null)
					Params.Delete(AName);
				Params.AddItem(AName, AValue, AKind, AOptions);
			}
		}

		public void AddAuthParameter(string AName, string AValue, TRESTRequestParameterKind AKind, TRESTRequestParameterOptions AOptions)
		{
			AOptions.Include(TRESTRequestParameterOptions.poTransient);
			AddParameter(AName, AValue, AKind, AOptions);
		}

		public TRESTRequestParameter[] CreateUnionParameterList()
		{
			return null;
		}

		public void AddBody(string ABodyContent, TRESTContentType AContentType = TRESTContentType.ctNone)
		{
		}

		//public void AddBody(TStream ABodyContent, TRestContentType AContentType = TRestContentType.ctNone)

		public void ClearBody()
		{
		}

		public void ResetToDefaults()
		{
			Method = TRESTRequestMethod.rmGET;
			Resource = "";
			ResourceSuffix = "";
			Timeout = 30000;
			Accept = TContentTypeConsts.CONTENTTYPE_APPLICATION_JSON + ", " + TContentTypeConsts.CONTENTTYPE_TEXT_PLAIN + ";q=0.9, " +
									   TContentTypeConsts.CONTENTTYPE_TEXT_HTML + ";q=0.8,";
			AcceptCharset = "UTF-8, *;q=0.8";
			HandleRedirects = true;
			FURLAlreadyEncoded = false;
			FParams.Clear();
			FTransientParams.Clear();
			FBody.ClearBody();
			if (FClient != null)
				FClient.ContentType = "";
			if (FResponse != null)
				FResponse.ResetToDefaults();				
		}

		private static void ReadCallback(IAsyncResult asyncResult)
		{
		}

		public void Execute()
		{
			if (FResponse == null)
				FResponse = new TCustomRESTResponse(this);
			
			var LRequestURL = GetFullRequestURL();
			FInternalRequest = (HttpWebRequest)HttpWebRequest.Create(LRequestURL);
			FInternalRequest.ContentType = "application/json";
			FInternalRequest.Method = "GET";

			var LAsync = FInternalRequest.BeginGetResponse(new AsyncCallback(ReadCallback), FInternalRequest);
			var LResponse = (HttpWebResponse) FInternalRequest.EndGetResponse(LAsync);
			ProcessResponse(LResponse);
		}

		//public TRestExecutionThread ExecuteAsync

		public string GetFullRequestURL(bool AIncludeParams = true)
		{
			var LUrl = FClient.BaseURL + FResource;
			if (AIncludeParams)
			{
				if (Params.Count > 0)
					LUrl = LUrl + "?";

				for (var I = 0; I < Params.Count; I++)
				{
					LUrl = LUrl + Params[I].Name + "=" + Params[I].Value;
					if (I < Params.Count - 1)
						LUrl = LUrl + "&";
				}
			}
			return LUrl;
		}

		private TRESTRequestParameterList FTransientParams;
		public TRESTRequestParameterList TransientParams
		{
			get
			{
				return FTransientParams;
			}
		}

		private bool FAutoCreateParams = true;
		public bool AutoCreateParams
		{
			get
			{
				return FAutoCreateParams;
			}
			set
			{
				FAutoCreateParams = value;
			}
		}

		private string FAccept;
		public string Accept
		{
			get
			{
				return FAccept;
			}
			set
			{
				// SetAccept
				FAccept = value;
			}
		}

		private string FAcceptCharset;
		public string AcceptCharset
		{
			get
			{
				return FAcceptCharset;
			}
			set
			{
				// SetAcceptCharset
				FAcceptCharset = value;
			}
		}

		private string FAcceptEncoding;
		public string AcceptEncoding
		{
			get
			{
				return FAcceptEncoding;
			}
			set
			{
				// SetAcceptEncoding
				FAcceptEncoding = value;
			}
		}

		private bool FHandleRedirects;
		public bool HandleRedirects
		{
			get
			{
				return FHandleRedirects;
			}
			set
			{
				// SetHandleRedirects
				FHandleRedirects = value;
			}
		}

		private TCustomRESTClient FClient;
		public TCustomRESTClient Client
		{
			get
			{
				// GetClient
				return FClient;
			}
			set
			{
				// SetClient
				FClient = value;
			}
		}

		private TRESTRequestMethod FMethod;
		public TRESTRequestMethod Method
		{
			get
			{
				return FMethod;
			}
			set
			{
				FMethod = value;
			}
		}

		private TRESTRequestParameterList FParams;
		public TRESTRequestParameterList Params
		{
			get
			{
				// SetParams
				return FParams;
			}
			set
			{
				// SetParams
				FParams = value;
			}
		}

		private TBody FBody;
		public TBody Body
		{
			get
			{
				return FBody;
			}
		}

		private string FResource;
		public string Resource
		{
			get
			{
				// GetResource
				return FResource;
			}
			set
			{
				// SetResource
				FResource = value;
			}
		}

		private string FResourceSuffix;
		public string ResourceSuffix
		{
			get
			{
				return FResourceSuffix;
			}
			set
			{
				// SetResourceSuffix
				FResourceSuffix = value;
			}
		}

		public string FullResource
		{
			get
			{
				return FResource + FResourceSuffix;
			}
		}

		private TCustomRESTResponse FResponse;
		public TCustomRESTResponse Response
		{
			get
			{
				// GetResponse
				return FResponse;
			}
			set
			{
				// SetResponse
				FResponse = value;
			}
		}

		private int FTimeout = 30000;
		public int Timeout
		{
			get
			{
				// GetTimeout
				return FTimeout;
			}
			set
			{
				// SetTimeout
				FTimeout = value;
			}
		}

		//OnAfterExecute
		// ExecutionPerformance
		//SynchronizedEvents
		//OnHTTPProtocolError
		//BindSource
		private bool FURLAlreadyEncoded;
		public bool URLAlreadyEncoded
		{
			get
			{
				return FURLAlreadyEncoded;
			}
			set
			{
				FURLAlreadyEncoded = value;
			}
		}
	}

	public class TRESTRequest : TCustomRESTRequest
	{
		public TRESTRequest(TComponent AOwner) : base(AOwner)
		{
		}	
	}

	public class TCustomRESTResponse:TComponent
	{
		public TCustomRESTResponse(TComponent AOwner) : base(AOwner)
		{
			FHeaders = new TStringList();
		}

		public Boolean GetSimpleValue(string AName, ref string AValue)
		{
			return false;
		}

		public void ResetToDefaults()
		{
		}

		private string FContentEncoding;
		public string ContentEncoding
		{
			get
			{
				return FContentEncoding;
			}
			set
			{
				FContentEncoding = value;
			}
		}

		public int ContentLength
		{
			get
			{
				return -1;
			}
		}

		private string FContentType;
		public string ContentType
		{
			get
			{
				return FContentType;
			}

			set
			{
				FContentType = value;
			}
		}

		private string FErrorMessage;
		public string ErrorMessage
		{
			get
			{
				return FErrorMessage;

			}

			set
			{
				FErrorMessage = value;

			}
		}

		private TStrings FHeaders;
		public TStrings Headers
		{
			get
			{
				return FHeaders;
			}
		}

		// JSONValue
		// JSONText
		// JSONReader

		public void SetRawBytes(Stream AStream)
		{
			FRawBytes = new Byte[AStream.Length];
			AStream.Read(FRawBytes, 0, FRawBytes.Length);
		}

		private Byte[] FRawBytes;
		public Byte[] RawBytes
		{
			get
			{
				return FRawBytes;
			}
		}

		private string FFullRequestURI;
		public string FullRequestURI
		{
			get
			{
				return FFullRequestURI;
			}
			set
			{
				FFullRequestURI = value;
			}
		}


		private string FServer;
		public string Server
		{
			get
			{
				return FServer;
			}
			set
			{
				FServer = value;
			}
		}

		private int FStatusCode;
		public int StatusCode
		{
			get
			{
				return FStatusCode;
			}
			set
			{
				FStatusCode = value;
			}
		}

		private string FStatusText;
		public string StatusText
		{
			get
			{
				return FStatusText;
			}
			set
			{
				FStatusText = value;
			}
		}

		public void SetContent(string AContent)
		{
			FContent = AContent;
		}
		private string FContent;
		public string Content
		{
			get
			{
				return FContent;
			}
		}

		private string FRootElement;
		public string RootElement
		{
			get
			{
				return FRootElement;
			}
			set
			{
				FRootElement = value;
			}
		}

		//BindSource
		//NotifyList
		//Status
	}

	public class TRESTResponse:TCustomRESTResponse
	{
		public TRESTResponse(TComponent AOwner) : base(AOwner)
		{
		}
	}

	public class TCustomRESTClient:TComponent
	{
		private TStringList FCookies;
		private TStringList FCustomHeaders;

		private void InternalCreate()
		{
			FParams = new TRESTRequestParameterList(this);
			FTransientParams = new TRESTRequestParameterList(this);
			ResetToDefaults();
			FCookies = new TStringList();
			FCustomHeaders = new TStringList();			
		}

		public TCustomRESTClient(TComponent AOwner) : base(AOwner)
		{
			InternalCreate();
		}

		public TCustomRESTClient(string ABaseApiURL) : base(null)
		{
			InternalCreate();
			BaseURL = ABaseApiURL;
		}

		public void AddParameter(string AName, string AValue)
		{
			AddParameter(AName, AValue, TRESTRequestParameterKind.pkGETorPOST, new TRESTRequestParameterOptions());
		}

		public void AddParameter(string AName, string AValue, TRESTRequestParameterKind AKind)
		{
			AddParameter(AName, AValue, AKind, new TRESTRequestParameterOptions());
		}

		public void AddParameter(string AName, string AValue, TRESTRequestParameterKind AKind, TRESTRequestParameterOptions AOptions)
		{
			if (AOptions != null && AOptions.In(TRESTRequestParameterOptions.poTransient))
			{
				var LIndex = TransientParams.IndexOf(AName);
				if (LIndex >= 0)
					TransientParams.Delete(LIndex);
				TransientParams.AddItem(AName, AValue, AKind, AOptions);		
			}
			else
			{
				var LIndex = Params.IndexOf(AName);
				if (LIndex >= 0)
					Params.Delete(LIndex);
				Params.AddItem(AName, AValue, AKind, AOptions);
			}
		}

		public void AddAuthParameter(string AName, string AValue, TRESTRequestParameterKind AKind, TRESTRequestParameterOptions AOptions = null)
		{
			TRESTRequestParameterOptions LOptions;
			if (AOptions == null)
				LOptions = new TRESTRequestParameterOptions();
			else
				LOptions = AOptions;
			LOptions.Include(TRESTRequestParameterOptions.poTransient);
			AddParameter(AName, AValue, AKind, LOptions);
		}

		public void SetCookie(string Data, string CookieURL)
		{
			FCookies.Add(CookieURL + "=" + Data);
		}

		public void SetHTTPHeader(string AName, string AValue)
		{
			FCustomHeaders.Add(AName + "=" + AValue); 
		}

		public void ResetToDefaults()
		{
			BaseURL = "";
			ProxyServer = "";
			ProxyPort = 0;
			ProxyUsername = "";
			ProxyPassword = "";
			UserAgent = "RadX RESTClient/1.0";
			FallbackCharsetEncoding = "UTF-8";
			//SynchronizedEvents = true;
			RaiseExceptionOn500 = true;
			FAutoCreateParams = true;
			FParams.Clear();
			FTransientParams.Clear();
		}

		public void Disconnect()
		{
		}

		private TRESTRequestParameterList FTransientParams;
		public TRESTRequestParameterList TransientParams
		{
			get
			{
				return FTransientParams;
			}
		}

		private bool FAutoCreateParams;
		public bool AutoCreateParams
		{
			get
			{
				return FAutoCreateParams;
			}
			set
			{
				FAutoCreateParams = value;
			}
		}

		// Authenticator

		public string Accept { get; set; }

		public string AcceptCharset { get; set; }

		public string AcceptEncoding { get; set; }

		public bool AllowCookies { get; set; }

		private string FBaseURL;
		public string BaseURL
		{
			get
			{
				// GetBaseURL
				return FBaseURL;
			}
			set
			{
				// SetBaseURL
				FBaseURL = value;
			}
		}

		public string ContentType { get; set; }

		private string FFallbackCharsetEncoding;
		public string FallbackCharsetEncoding
		{
			get
			{
				return FFallbackCharsetEncoding;
			}
			set
			{
				FFallbackCharsetEncoding = value;
			}
		}

		private TRESTRequestParameterList FParams;
		public TRESTRequestParameterList Params
		{
			get
			{
				return FParams;
			}
			set
			{
				FParams = value;
			}
		}

		public bool HandleRedirects { get; set; }

		public string ProxyServer { get; set; }

		public int ProxyPort { get; set; }

		public string ProxyUsername { get; set; }

		public string ProxyPassword { get; set; }

		public bool RaiseExceptionOn500 { get; set; }

		public bool SynchronizedEvents { get; set; }

		public string UserAgent { get; set; }

		// OnHTTPProtocolError
		// BindSource
		// OnValidateCertificate			
	}

	public class TRESTClient: TCustomRESTClient
	{
		public TRESTClient(TComponent AOwner) : base(AOwner)
		{
		}
	}
}
