using Gdk;

namespace System.UITypes
{
    #if __GTK__
    public partial class TColor
    {
		partial void NativeFromRGB(byte R, byte G, byte B)
		{
			handle = new Gdk.Color(R, G, B);

		}

        partial void CreateHandle(TColors AColor)
		{
			switch (AColor)
			{
				case
				TColors.clBlack:
                    handle = new Gdk.Color(0, 0, 0);
					break;
				case
				TColors.clMaroon:
					handle = new Gdk.Color(0x80, 0, 0);
					break;
				case
				TColors.clGreen:
					handle = new Gdk.Color(0, 0x80, 0);
					break;
				case
				TColors.clOlive:
					handle = new Gdk.Color(0x80, 0x80, 0);
					break;
				case
				TColors.clNavy:
					handle = new Gdk.Color(0, 0, 0x80);
					break;
				case
				TColors.clPurple:
					handle = new Gdk.Color(0x80, 0, 0x80);
					break;
				case
				TColors.clTeal:
					handle = new Gdk.Color(0, 0x80, 0x80);
					break;
				case
				TColors.clGray:
					handle = new Gdk.Color(0x80, 0x80, 0x80);
					break;
				case
				TColors.clSilver:
					handle = new Gdk.Color(0XD3, 0xD3, 0xD3);
					break;
				case
				TColors.clRed:
					handle = new Gdk.Color(0XFF, 0, 0);
					break;
				case
				TColors.clLime:
					handle = new Gdk.Color(0, 0x80, 0);
					break;
				case
				TColors.clYellow:
					handle = new Gdk.Color(0XFF, 0xFF, 0);
					break;
				case
				TColors.clBlue:
					handle = new Gdk.Color(0, 0, 0xFF);
					break;
				case
				TColors.clFuchsia:
					handle = new Gdk.Color(0XFF, 0, 0XFF);
					break;
				case
				TColors.clAqua:
					handle = new Gdk.Color(0, 0xFF, 0xFF);
					break;
				case
				TColors.clLtGray:
					handle = new Gdk.Color(0XD3, 0xD3, 0xD3);
					break;
				case
				TColors.clDkGray:
					handle = new Gdk.Color(0XA9, 0xA9, 0xA9); 
					break;
				case
				TColors.clWhite:
					handle = new Gdk.Color(0XFF, 0xFF, 0xFF); 
					break;

				default:
					handle = new Gdk.Color(0, 0, 0);
					break;
			}
		}

    }
    #endif
}