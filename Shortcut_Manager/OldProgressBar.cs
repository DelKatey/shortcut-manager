using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Shortcut_Manager
{
    public partial class OldProgressBar : System.Windows.Forms.ProgressBar
    {//http://stackoverflow.com/questions/298486/how-do-i-disable-visual-styles-for-just-one-control-and-not-its-children
        [DllImportAttribute("uxtheme.dll")]
        private static extern int SetWindowTheme(IntPtr hWnd, string appname, string idlist);

        protected override void OnHandleCreated(EventArgs e)
        {
            SetWindowTheme(this.Handle, "", "");
            base.OnHandleCreated(e);
        }

        public OldProgressBar()
        {
            InitializeComponent();
        }

        public OldProgressBar(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
