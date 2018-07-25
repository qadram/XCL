using System;
using Gtk;
using Xcl.Forms;

namespace Xcl.Sample.Gtk
{
    class MainClass
    {
        public static TMainWindow MainWindow;

        public static void Main(string[] args)
        {
            TApplication.Initialize(null);
            TApplication.CreateForm<TMainWindow>(ref MainWindow);
            TApplication.Run();
        }
    }
}
