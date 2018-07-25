
using Xcl.Controls;
using System;
using Cairo; 

namespace Xcl.StdCtrls
{
#if __GTK__
    public partial class TButton : TCustomButton
    {
        
        public override void ToPaint(IDisposable context)
        {
            base.ToPaint(context);
            Cairo.Context ctx = (Cairo.Context)context;

            double a = 1;
            if (ControlStyle.In(TControlStyle.csDisplayDragImage))
                a = 0.4;
            ctx.Rectangle(Left, Top, Width, Height);

            if (DesignerPlatform == 0)
            {
                ctx.SetSourceColor(new Color(1, 1, 1, a));
                ctx.FillPreserve();
                ctx.SetSourceColor(new Color(0.2, 0.8, 1, a));
                ctx.LineWidth = 1;
                ctx.Stroke();

                ctx.SetSourceRGB(0, 0, 0);
                ctx.SelectFontFace("Georgia", Cairo.FontSlant.Normal, Cairo.FontWeight.Normal);
                ctx.SetFontSize(11);
                Cairo.TextExtents te = ctx.TextExtents(Caption);
                ctx.MoveTo((Left + (Width / 2)) - ((te.Width / 2) - te.XBearing), Top + 15);
            }
            else
            {
                ctx.SetSourceColor(new Color(1, 0.5, 1, a));
                ctx.FillPreserve();
                ctx.SetSourceColor(new Color(0.4, 0.4, 1, a));
                ctx.LineWidth = 1;
                ctx.Stroke();

                ctx.SetSourceRGB(0, 0, 0);
                ctx.SelectFontFace("Arial", Cairo.FontSlant.Normal, Cairo.FontWeight.Normal);
                ctx.SetFontSize(11);
                Cairo.TextExtents te = ctx.TextExtents(Caption);
                ctx.MoveTo((Left + (Width / 2)) - ((te.Width / 2) - te.XBearing), Top + 15);
                //(Top + (Height / 2)) - ((te.Height / 2) - te.YBearing));
            }
            ctx.ShowText(Caption);
        }
       
    }
#endif
}