using Xcl.Forms;
using EntryForm;
using LoginForm;

namespace Xcl.Login.Sample
{
	public partial class App
	{
		public static TEntryForm EntryForm;
		public static TLoginForm LoginForm;

		public static void Run(object param)
		{
			TApplication.Initialize (param);
			TApplication.CreateForm<TEntryForm> (ref EntryForm);
			TApplication.CreateForm<TLoginForm> (ref LoginForm);
			TApplication.Run ();
		}
	}
}
