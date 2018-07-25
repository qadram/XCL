using Gtk;
using GLib;
using Pango;
using System.UITypes;
      
namespace Xcl.Graphics
{
#if __GTK__
    public partial class TFont: TGraphicsObject
    {
        public Pango.FontDescription handle;

        partial void NativeInitializeFont()
        {
            FName = "Helvetica";
            FSize = 10;
            FColor = new TColor (TColors.clBlack);
        }

        public void NotifyChanged()
        {
            if (Notifier!=null) Notifier.Changed();
        }

        partial void SetName(string AName)
        {
            handle = Pango.FontDescription.FromString(AName);
            Handle = handle;
            NotifyChanged();
        }

        partial void SetSize(float ASize)
        {
            handle.Size = (int)ASize;
            Handle = handle;
            NotifyChanged();
        }

        partial void SetColor(TColor AColor)
        {
            NotifyChanged();
        }

    }
#endif
}