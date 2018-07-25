using Xcl.Forms;
using CatalogMain;
using CatalogDetailForm;

namespace CatalogApp
{
	public partial class App
	{
		public static TMainCatalog CatalogMain;
        public static TfmDetail CatalogDetail;

		public static void Run(object param)
		{
			TApplication.Initialize(param);
			TApplication.CreateForm<TMainCatalog>(ref CatalogMain);
            TApplication.CreateForm<TfmDetail>(ref CatalogDetail);
			TApplication.Run();
		}
	}
}