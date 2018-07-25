using System.Reflection;

namespace Xcl.Design
{
	public class RegisterComponents : IRegisterComponent
	{
		public RegisterComponents()
		{
		}

		public void Register()
		{
			IdeComponents.Add(Assembly.GetExecutingAssembly(),
							  "Xcl.StdCtrls.TButton", "Button", "Standard Controls", "target version",
							  "Xcl.Gtk.Resources.image-x-generic.png");
		}

	}
}