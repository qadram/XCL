using System;
using System.Base;
using Xcl.Forms;

namespace Xcl.Controls
{
    
#if __GTK__
    public partial class TControl
    {
        public virtual int DesignerPlatform
        {
            get
            {
                TForm frm = _.GetParentForm(this, false) as TForm;
                if (frm != null)
                    return frm.DesignerPlatform;
                else
                    return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual void ToPaint(IDisposable context)
        {
            Console.WriteLine("Tcontrol ToPain called");
        }
    }
#endif

}