using System;

namespace Xcl.Forms
{
#if __GTK__
    public partial class TForm
    {
        public override int DesignerPlatform { get; set; }
    }

#endif
}
