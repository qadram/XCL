using System;
using System.Base;
using System.Classes;
using Xcl.Controls;
using System.UITypes;

#if __GTK__
using Gtk;
#endif

namespace Xcl.Forms
{
#if __GTK__
	public partial class TApplication : TComponent
	{
		partial void NativeInitialize(object param)
		{
            Gtk.Application.Init();
		}

		partial void NativeRun()
		{
            MainForm.Show();
            Gtk.Application.Run();
		}
	}


	public partial class TScreen : TComponent
	{
		partial void NativeGetWidth()
		{
			//TODO: Use nfloat everywhere
			//FWidth = (float)UIScreen.MainScreen.Bounds.Width;
		}

		partial void NativeGetHeight()
		{
			//TODO: Use nfloat everywhere
			//FHeight = (float)UIScreen.MainScreen.Bounds.Height;
		}
	}


    public partial class TCustomForm : TScrollingControl
    {
        public Gtk.Window FWindow;
        public Gtk.Fixed FClient;

        protected override void CreateNativeHandle()
        {
            FWindow = new Gtk.Window(0);
            Gdk.Size lDefault = new Gdk.Size(300, 300);
            FWindow.DefaultSize = lDefault;
            FClient = new Gtk.Fixed();
            FWindow.Add(FClient);
            Handle = FClient;
        }

        /*public override void SetParent(TControl AControl)
        {
            FClient.Add(AControl.Handle as Widget);
        }*/

        protected override void SetColor(TColor AColor)
        {
            //handle.View.SetBackgroundColor((Color)AColor.handle);
        }

        public override void UpdateBounds()
        {

        }
    }

    public partial class TForm
    {
        partial void Initialize()
        {
            Loaded();
        }

        public override void Show()
        {
            FWindow.ShowAll();
            DoShow();
        }
    }
#endif
}
