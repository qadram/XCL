using System;
using Xcl.Forms;
using System.Classes;

#if __GTK__
using Gtk;
#endif

namespace Xcl.ExtCtrls
{
#if __GTK__
    public partial class TPanel : TCustomPanel
    {
        private Fixed FView;
        protected override void CreateNativeHandle()
        {
            FView = new Fixed();
            Handle = FView;
        }
    }

    public class TEventPanel : TComponent
    {
        Gtk.EventBox FBox = new Gtk.EventBox();

        public TEventPanel(object aOwner) : base(null)
        {
            
        }


    }
#endif
}
