using System.Base;

namespace REST
{
	public enum TRESTContentType { ctNone, ctIMAGE_PNG };

	public enum TRESTRequestParameterKind { pkCOOKIE, pkGETorPOST, pkURLSEGMENT, plHTTPHeader, plREQUESTBODY }

	public class TRESTRequestParameterOptions : TSet
	{
		public static int poDoNotEncode = 1;
		public static int poTransient = 2;
		public static int poAutoCreated = 4;
	}

	public enum TRESTConentType
	{
		ctNone, ctAPPLICATION_ATOM_XML, ctAPPLICATION_ECMASCRIPT, ctAPPLICATION_EDI_X12,
		ctAPPLICATION_EDIFACT, ctAPPLICATION_JSON, ctAPPLICATION_JAVASCRIPT, ctAPPLICATION_OCTET_STREAM, ctAPPLICATION_OGG,
		ctAPPLICATION_PDF, ctAPPLICATION_POSTSCRIPT, ctAPPLICATION_RDF_XML, ctAPPLICATION_RSS_XML, ctAPPLICATION_SOAP_XML,
		ctAPPLICATION_FONT_WOFF, ctAPPLICATION_XHTML_XML, ctAPPLICATION_XML, ctAPPLICATION_XML_DTD, ctAPPLICATION_XOP_XML,
		ctAPPLICATION_ZIP, ctAPPLICATION_GZIP, ctTEXT_CMD, ctTEXT_CSS, ctTEXT_CSV, ctTEXT_HTML, ctTEXT_JAVASCRIPT,
		ctTEXT_PLAIN, ctTEXT_VCARD, ctTEXT_XML, ctAUDIO_BASIC, ctAUDIO_L24, ctAUDIO_MP4, ctAUDIO_MPEG, ctAUDIO_OGG,
		ctAUDIO_VORBIS, ctAUDIO_VND_RN_REALAUDIO, ctAUDIO_VND_WAVE, ctAUDIO_WEBM, ctIMAGE_GIF, ctIMAGE_JPEG, ctIMAGE_PJPEG,
		ctIMAGE_PNG, ctIMAGE_SVG_XML, ctIMAGE_TIFF, ctMESSAGE_HTTP, ctMESSAGE_IMDN_XML, ctMESSAGE_PARTIAL, ctMESSAGE_RFC822,
		ctMODEL_EXAMPLE, ctMODEL_IGES, ctMODEL_MESH, ctMODEL_VRML, ctMODEL_X3D_BINARY, ctMODEL_X3D_VRML, ctMODEL_X3D_XML,
		ctMULTIPART_MIXED, ctMULTIPART_ALTERNATIVE, ctMULTIPART_RELATED, ctMULTIPART_FORM_DATA, ctMULTIPART_SIGNED,
		ctMULTIPART_ENCRYPTED, ctVIDEO_MPEG, ctVIDEO_MP4, ctVIDEO_OGG, ctVIDEO_QUICKTIME, ctVIDEO_WEBM, ctVIDEO_X_MATROSKA,
		ctVIDEO_X_MS_WMV, ctVIDEO_X_FLV, ctAPPLICATION_VND_OASIS_OPENDOCUMENT_TEXT,
		ctAPPLICATION_VND_OASIS_OPENDOCUMENT_SPREADSHEET, ctAPPLICATION_VND_OASIS_OPENDOCUMENT_PRESENTATION,
		ctAPPLICATION_VND_OASIS_OPENDOCUMENT_GRAPHICS, ctAPPLICATION_VND_MS_EXCEL,
		ctAPPLICATION_VND_OPENXMLFORMATS_OFFICEDOCUMENT_SPREADSHEETML_SHEET, ctAPPLICATION_VND_MS_POWERPOINT,
		ctAPPLICATION_VND_OPENXMLFORMATS_OFFICEDOCUMENT_PRESENTATIONML_PRESENTATION,
		ctAPPLICATION_VND_OPENXMLFORMATS_OFFICEDOCUMENT_WORDPROCESSINGML_DOCUMENT, ctAPPLICATION_VND_MOZILLA_XUL_XML,
		ctAPPLICATION_VND_GOOGLE_EARTH_KML_XML, ctAPPLICATION_VND_GOOGLE_EARTH_KMZ, ctAPPLICATION_VND_DART,
		ctAPPLICATION_VND_ANDROID_PACKAGE_ARCHIVE, ctAPPLICATION_X_DEB, ctAPPLICATION_X_DVI, ctAPPLICATION_X_FONT_TTF,
		ctAPPLICATION_X_JAVASCRIPT, ctAPPLICATION_X_LATEX, ctAPPLICATION_X_MPEGURL, ctAPPLICATION_X_RAR_COMPRESSED,
		ctAPPLICATION_X_SHOCKWAVE_FLASH, ctAPPLICATION_X_STUFFIT, ctAPPLICATION_X_TAR, ctAPPLICATION_X_WWW_FORM_URLENCODED,
		ctAPPLICATION_X_XPINSTALL, ctAUDIO_X_AAC, ctAUDIO_X_CAF, ctIMAGE_X_XCF, ctTEXT_X_GWT_RPC, ctTEXT_X_JQUERY_TMPL,
		ctTEXT_X_MARKDOWN, ctAPPLICATION_X_PKCS12, ctAPPLICATION_X_PKCS7_CERTIFICATES, ctAPPLICATION_X_PKCS7_CERTREQRESP,
		ctAPPLICATION_X_PKCS7_MIME, ctAPPLICATION_X_PKCS7_SIGNATURE
	}

	public class TContentTypeConsts
	{

		public const string CONTENTTYPE_NONE = "";
		public const string CONTENTTYPE_APPLICATION_ATOM_XML = "application/atom+xml";
		public const string CONTENTTYPE_APPLICATION_ECMASCRIPT = "application/ecmascript";
		public const string CONTENTTYPE_APPLICATION_EDI_X12 = "application/EDI-X12";
		public const string CONTENTTYPE_APPLICATION_EDIFACT = "application/EDIFACT";
		public const string CONTENTTYPE_APPLICATION_JSON = "application/json";
		public const string CONTENTTYPE_APPLICATION_JAVASCRIPT = "application/javascript";
		public const string CONTENTTYPE_APPLICATION_OCTET_STREAM = "application/octet-stream";
		public const string CONTENTTYPE_APPLICATION_OGG = "application/ogg";
		public const string CONTENTTYPE_APPLICATION_PDF = "application/pdf";
		public const string CONTENTTYPE_APPLICATION_POSTSCRIPT = "application/postscript";
		public const string CONTENTTYPE_APPLICATION_RDF_XML = "application/rdf+xml";
		public const string CONTENTTYPE_APPLICATION_RSS_XML = "application/rss+xml";
		public const string CONTENTTYPE_APPLICATION_SOAP_XML = "application/soap+xml";
		public const string CONTENTTYPE_APPLICATION_FONT_WOFF = "application/font-woff";
		public const string CONTENTTYPE_APPLICATION_XHTML_XML = "application/xhtml+xml";
		public const string CONTENTTYPE_APPLICATION_XML = "application/xml";
		public const string CONTENTTYPE_APPLICATION_XML_DTD = "application/xml-dtd";
		public const string CONTENTTYPE_APPLICATION_XOP_XML = "application/xop+xml";
		public const string CONTENTTYPE_APPLICATION_ZIP = "application/zip";
		public const string CONTENTTYPE_APPLICATION_GZIP = "application/gzip";
		public const string CONTENTTYPE_TEXT_CMD = "text/cmd";
		public const string CONTENTTYPE_TEXT_CSS = "text/css";
		public const string CONTENTTYPE_TEXT_CSV = "text/csv";
		public const string CONTENTTYPE_TEXT_HTML = "text/html";
		public const string CONTENTTYPE_TEXT_JAVASCRIPT = "text/javascript";
		public const string CONTENTTYPE_TEXT_PLAIN = "text/plain";
		public const string CONTENTTYPE_TEXT_VCARD = "text/vcard";
		public const string CONTENTTYPE_TEXT_XML = "text/xml";
		public const string CONTENTTYPE_AUDIO_BASIC = "audio/basic";
		public const string CONTENTTYPE_AUDIO_L24 = "audio/L24";
		public const string CONTENTTYPE_AUDIO_MP4 = "audio/mp4";
		public const string CONTENTTYPE_AUDIO_MPEG = "audio/mpeg";
		public const string CONTENTTYPE_AUDIO_OGG = "audio/ogg";
		public const string CONTENTTYPE_AUDIO_VORBIS = "audio/vorbis";
		public const string CONTENTTYPE_AUDIO_VND_RN_REALAUDIO = "audio/vnd.rn-realaudio";
		public const string CONTENTTYPE_AUDIO_VND_WAVE = "audio/vnd.wave";
		public const string CONTENTTYPE_AUDIO_WEBM = "audio/webm";
		public const string CONTENTTYPE_IMAGE_GIF = "image/gif";
		public const string CONTENTTYPE_IMAGE_JPEG = "image/jpeg";
		public const string CONTENTTYPE_IMAGE_PJPEG = "image/pjpeg";
		public const string CONTENTTYPE_IMAGE_PNG = "image/png";
		public const string CONTENTTYPE_IMAGE_SVG_XML = "image/svg+xml";
		public const string CONTENTTYPE_IMAGE_TIFF = "image/tiff";
		public const string CONTENTTYPE_MESSAGE_HTTP = "message/http";
		public const string CONTENTTYPE_MESSAGE_IMDN_XML = "message/imdn+xml";
		public const string CONTENTTYPE_MESSAGE_PARTIAL = "message/partial";
		public const string CONTENTTYPE_MESSAGE_RFC822 = "message/rfc822";
		public const string CONTENTTYPE_MODEL_EXAMPLE = "model/example";
		public const string CONTENTTYPE_MODEL_IGES = "model/iges";
		public const string CONTENTTYPE_MODEL_MESH = "model/mesh";
		public const string CONTENTTYPE_MODEL_VRML = "model/vrml";
		public const string CONTENTTYPE_MODEL_X3D_BINARY = "model/x3d+binary";
		public const string CONTENTTYPE_MODEL_X3D_VRML = "model/x3d+vrml";
		public const string CONTENTTYPE_MODEL_X3D_XML = "model/x3d+xml";
		public const string CONTENTTYPE_MULTIPART_MIXED = "multipart/mixed";
		public const string CONTENTTYPE_MULTIPART_ALTERNATIVE = "multipart/alternative";
		public const string CONTENTTYPE_MULTIPART_RELATED = "multipart/related";
		public const string CONTENTTYPE_MULTIPART_FORM_DATA = "multipart/form-data";
		public const string CONTENTTYPE_MULTIPART_SIGNED = "multipart/signed";
		public const string CONTENTTYPE_MULTIPART_ENCRYPTED = "multipart/encrypted";
		public const string CONTENTTYPE_VIDEO_MPEG = "video/mpeg";
		public const string CONTENTTYPE_VIDEO_MP4 = "video/mp4";
		public const string CONTENTTYPE_VIDEO_OGG = "video/ogg";
		public const string CONTENTTYPE_VIDEO_QUICKTIME = "video/quicktime";
		public const string CONTENTTYPE_VIDEO_WEBM = "video/webm";
		public const string CONTENTTYPE_VIDEO_X_MATROSKA = "video/x-matroska";
		public const string CONTENTTYPE_VIDEO_X_MS_WMV = "video/x-ms-wmv";
		public const string CONTENTTYPE_VIDEO_X_FLV = "video/x-flv";
		public const string CONTENTTYPE_APPLICATION_VND_OASIS_OPENDOCUMENT_TEXT = "application/vnd.oasis.opendocument.text";
		public const string CONTENTTYPE_APPLICATION_VND_OASIS_OPENDOCUMENT_SPREADSHEET = "application/vnd.oasis.opendocument.spreadsheet";
		public const string CONTENTTYPE_APPLICATION_VND_OASIS_OPENDOCUMENT_PRESENTATION = "application/vnd.oasis.opendocument.presentation";
		public const string CONTENTTYPE_APPLICATION_VND_OASIS_OPENDOCUMENT_GRAPHICS = "application/vnd.oasis.opendocument.graphics";
		public const string CONTENTTYPE_APPLICATION_VND_MS_EXCEL = "application/vnd.ms-excel";
		public const string CONTENTTYPE_APPLICATION_VND_OPENXMLFORMATS_OFFICEDOCUMENT_SPREADSHEETML_SHEET = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
		public const string CONTENTTYPE_APPLICATION_VND_MS_POWERPOINT = "application/vnd.ms-powerpoint";
		public const string CONTENTTYPE_APPLICATION_VND_OPENXMLFORMATS_OFFICEDOCUMENT_PRESENTATIONML_PRESENTATION = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
		public const string CONTENTTYPE_APPLICATION_VND_OPENXMLFORMATS_OFFICEDOCUMENT_WORDPROCESSINGML_DOCUMENT = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
		public const string CONTENTTYPE_APPLICATION_VND_MOZILLA_XUL_XML = "application/vnd.mozilla.xul+xml";
		public const string CONTENTTYPE_APPLICATION_VND_GOOGLE_EARTH_KML_XML = "application/vnd.google-earth.kml+xml";
		public const string CONTENTTYPE_APPLICATION_VND_GOOGLE_EARTH_KMZ = "application/vnd.google-earth.kmz";
		public const string CONTENTTYPE_APPLICATION_VND_DART = "application/vnd.dart";
		public const string CONTENTTYPE_APPLICATION_VND_ANDROID_PACKAGE_ARCHIVE = "application/vnd.android.package-archive";
		public const string CONTENTTYPE_APPLICATION_X_DEB = "application/x-deb";
		public const string CONTENTTYPE_APPLICATION_X_DVI = "application/x-dvi";
		public const string CONTENTTYPE_APPLICATION_X_FONT_TTF = "application/x-font-ttf";
		public const string CONTENTTYPE_APPLICATION_X_JAVASCRIPT = "application/x-javascript";
		public const string CONTENTTYPE_APPLICATION_X_LATEX = "application/x-latex";
		public const string CONTENTTYPE_APPLICATION_X_MPEGURL = "application/x-mpegURL";
		public const string CONTENTTYPE_APPLICATION_X_RAR_COMPRESSED = "application/x-rar-compressed";
		public const string CONTENTTYPE_APPLICATION_X_SHOCKWAVE_FLASH = "application/x-shockwave-flash";
		public const string CONTENTTYPE_APPLICATION_X_STUFFIT = "application/x-stuffit";
		public const string CONTENTTYPE_APPLICATION_X_TAR = "application/x-tar";
		public const string CONTENTTYPE_APPLICATION_X_WWW_FORM_URLENCODED = "application/x-www-form-urlencoded";
		public const string CONTENTTYPE_APPLICATION_X_XPINSTALL = "application/x-xpinstall";
		public const string CONTENTTYPE_AUDIO_X_AAC = "audio/x-aac";
		public const string CONTENTTYPE_AUDIO_X_CAF = "audio/x-caf";
		public const string CONTENTTYPE_IMAGE_X_XCF = "image/x-xcf";
		public const string CONTENTTYPE_TEXT_X_GWT_RPC = "text/x-gwt-rpc";
		public const string CONTENTTYPE_TEXT_X_JQUERY_TMPL = "text/x-jquery-tmpl";
		public const string CONTENTTYPE_TEXT_X_MARKDOWN = "text/x-markdown";
		public const string CONTENTTYPE_APPLICATION_X_PKCS12 = "application/x-pkcs12";
		public const string CONTENTTYPE_APPLICATION_X_PKCS7_CERTIFICATES = "application/x-pkcs7-certificates";
		public const string CONTENTTYPE_APPLICATION_X_PKCS7_CERTREQRESP = "application/x-pkcs7-certreqresp";
		public const string CONTENTTYPE_APPLICATION_X_PKCS7_MIME = "application/x-pkcs7-mime";
		public const string CONTENTTYPE_APPLICATION_X_PKCS7_SIGNATURE = "application/x-pkcs7-signature";
	}

	public enum TRESTRequestMethod
	{
		rmPOST, rmPUT, rmGET, rmDelete, rmPATCH
	}
}