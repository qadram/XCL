using Xcl.Forms;
using System.Classes;
using MenuForm;

namespace Xcl.Samples
{
	public partial class TSampleApplication:TApplication
	{
		public static TMenuForm MenuForm;

		public TSampleApplication(TComponent AOwner):base(AOwner)
		{
			MenuForm = new TMenuForm (this);
			MainForm = MenuForm;

		}	
	}
}