using System;
using System.Base;
using System.Threading.Tasks;

namespace CatalogMain
{
	public class TProduct: TObject
	{
		public int ID;
		public string ImageURL;
		public string Title;
		public int ImageIndex = -1;
        public TProductDetails Details = null;
	}

    public class TProductDetails: TObject
    {
        public string Title;
        public string Description;
        public string Manufacturer;
        public string[] Images;
    }

	public class TImageDownloader
	{

		public static /*async Task<byte[]>*/ byte[] DownloadAsync(string strURL)
		{
            System.Net.WebClient LClient = new System.Net.WebClient();
            var LBytes = LClient.DownloadData(strURL);

            return LBytes;

            /*System.Net.Http.HttpClient LClient = new System.Net.Http.HttpClient();
            LClient.Timeout = TimeSpan.FromSeconds(30);
            LClient.
            var LString = await LClient.GetStringAsync("https://www.google.es");
			var LBytes = LClient.GetByteArrayAsync(strURL);
            await LBytes;

            return LBytes.Result;
            */
		}
	}
}