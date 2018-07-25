using System;
using System.Base;
using System.Classes;
using Xcl.Controls;
using System.UITypes;

#if __GTK__
using Gtk;
#endif

namespace Xcl.Controls
{
#if __GTK__


    public partial class TFocusControl : TControl
    {
        /*public Widget control
        {
            get
            {
                return (Handle as Widget);
            }
        }*/

        protected override void NativeEvent(bool Add, string EventName, EventHandler value)
        {
            //TODO: Review bubbling this or not through a boolean return
            base.NativeEvent(Add, EventName, value);

            /*if (Add)
            {
                if (EventName == "OnMouseDown") control.TouchDown += value;
                else if (EventName == "OnClick") control.TouchUpInside += value;
                else if (EventName == "OnTouchDown") control.TouchDown += value;
                else if (EventName == "OnTouchDownRepeat") control.TouchDownRepeat += value;
                else if (EventName == "OnTouchDragEnter") control.TouchDragEnter += value;
                else if (EventName == "OnTouchDragExit") control.TouchDragExit += value;
                else if (EventName == "OnTouchDragInside") control.TouchDragInside += value;
                else if (EventName == "OnTouchDragOutside") control.TouchDragOutside += value;
                else if (EventName == "OnTouchUpInside") control.TouchUpInside += value;
                else if (EventName == "OnTouchUpOutside") control.TouchUpOutside += value;
            }
            else
            {
                if (EventName == "OnMouseDown") control.TouchDown -= value;
                else if (EventName == "OnClick") control.TouchUpInside -= value;
                else if (EventName == "OnTouchDown") control.TouchDown -= value;
                else if (EventName == "OnTouchDownRepeat") control.TouchDownRepeat -= value;
                else if (EventName == "OnTouchDragEnter") control.TouchDragEnter -= value;
                else if (EventName == "OnTouchDragExit") control.TouchDragExit -= value;
                else if (EventName == "OnTouchDragInside") control.TouchDragInside -= value;
                else if (EventName == "OnTouchDragOutside") control.TouchDragOutside -= value;
                else if (EventName == "OnTouchUpInside") control.TouchUpInside -= value;
                else if (EventName == "OnTouchUpOutside") control.TouchUpOutside -= value;

            }*/
        }
    }

    public partial class TControl : TComponent
    {
        public Gtk.Fixed container
        {
            get
            {
                return (Handle as Gtk.Fixed);
            }
        }

        public Widget control
        {
            get
            {
                return (Handle as Widget);
            }
        }

        partial void NativeSetColor(TColor AColor)
        {
            //view.BackgroundColor = AColor.handle as UIColor;
        }

        partial void NativeSetVisible(bool value)
        {
            control.Visible = value;
        }

        partial void NativeUpdateBounds()
        {
            control.SetSizeRequest((int)FWidth, (int)FHeight);
        }
    }

    public partial class TFocusControl : TControl
    {

        partial void NativeSetParent(TControl AControl)
        {
            container.Put(AControl.Handle as Widget, (int)AControl.Left, (int)AControl.Top);
        }
    }



#endif
}
