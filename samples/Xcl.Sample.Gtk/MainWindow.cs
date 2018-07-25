using System;
using System.Base;
using System.Classes;
using System.UITypes;
using Xcl.StdCtrls;
using Xcl.Controls;
using Xcl.ComCtrls;
using Xcl.Graphics;
using Xcl.Forms;
using System.Generics.Collections;
using System.Security.Policy;
using System.Text;
using System.IO;

namespace Xcl.Sample.Gtk
{
    public class TMainWindow : TForm
    {
        public TComboBox cbCombo;


        public TMainWindow(TComponent AOwner) : base(AOwner)
        {

        }

        public void CreateComponents()
        {
            cbCombo = new TComboBox(this);
            cbCombo.Width = 100;
            cbCombo.Height = 25;
            cbCombo.Top = 10;
            cbCombo.Left = 10;
            cbCombo.Parent = this;
        }

        public override void Loaded()
        {
            base.Loaded();
            CreateComponents();
        }
    }
}