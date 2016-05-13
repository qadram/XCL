using System.Base;
using System.Classes;
using Xcl.Forms;
using MenuForm;

namespace Xcl.Samples
{
	//Samples Application Class
	public partial class App: TApplication
	{
		public static TMenuForm MenuForm;

		public App (TComponent AOwner) : base (AOwner)
		{
		}

		public override void DoCreateForms()
		{
			MenuForm = new TMenuForm (_.Application);
			_.Application.MainForm = MenuForm;
		}
	}
}