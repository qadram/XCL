using Gtk;
using Xcl.Graphics;
using Xcl.Controls;
using System.Classes;

namespace Xcl.StdCtrls
{
#if __GTK__
    public partial class TCustomButton 
    {
        public Gtk.Button fbutton;

        protected override void CreateNativeHandle()
		{
			//Creates the native handle
			fbutton = new Gtk.Button();

			//Assign native handles to manage through the wrappers
            FFont.handle = fbutton.Style.FontDescription;
            FFont.Color.handle = fbutton.Style.Text(StateType.Normal);
			NativeChanged();
			Handle = fbutton;
		}

		public override void NativeSetEnabled()
		{
            fbutton.Sensitive = Enabled;
		}

		public override void NativeChanged()
		{
            fbutton.ModifyFont(FFont.handle);
            fbutton.ModifyFg(StateType.Normal, (Gdk.Color)FFont.Color.handle);
		}


		public override void SetText(string Value)
		{
			base.SetText(Value);
            fbutton.Label = Value;
		}

    }

	public partial class TButton : TCustomButton
	{		
        public TButton() : base(null)
        {
            
        }
	}

    public partial class TCustomCombo : TCustomListControl
    {
        public Gtk.ComboBox fCombo;
        public ListStore fModel;

        partial void NativeSetItemIndex(int Index)
        {
            fCombo.Active = Index;
        }

        partial void NativeGetItemIndex(ref int Index)
        {
            Index = fCombo.Active;            
        }
    }

    public partial class TCustomComboBox : TCustomCombo
    {        
        protected override void CreateNativeHandle()
        {
            string[] values = new string[] { "" };
            fCombo = new Gtk.ComboBox(values);
            fCombo.RemoveText(0);
            Handle = fCombo;
        }

        partial void NativeAdd(string NewItem)
        {
            fCombo.AppendText(NewItem);
        }

        partial void NativeInsert(int Pos, string NewItem)
        {
            fCombo.InsertText(Pos, NewItem);
        }

        partial void NativeClear()
        {
            fCombo.Clear();  
        }

        partial void NativeDelete(int Index)
        {
            fCombo.RemoveText(Index);
        }
    }

    public partial class TLabel : TCustomLabel
    {
        public Gtk.Label fLabel;

        protected override void CreateNativeHandle()
        {
            fLabel = new Gtk.Label();
            Handle = fLabel;
        }

        public override void SetText(string Value)
        {
            base.SetText(Value);
            fLabel.Text = Value;
        }

        public override string GetText()
        {
            return fLabel.Text;
        }
    }

    public partial class TCustomEdit : TFocusControl
    {
        public Gtk.TextView fTextView;

        protected override void CreateNativeHandle()
        {
            fTextView = new Gtk.TextView();
            Handle = fTextView;
        }

        public override void SetText(string Value)
        {
            base.SetText(Value);
            fTextView.Buffer.Text = Value;
        }

        public override string GetText()
        {
            return fTextView.Buffer.Text;
        }
    }

#endif
}