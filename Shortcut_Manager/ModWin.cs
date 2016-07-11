using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shortcut_Manager
{
    public partial class ModWin : Form
    {
        internal string siteName, siteUrl, winTitle, nameLabel, urlLabel, okBtn, cancelBtn;

        public ModWin()
        {
            InitializeComponent();
        }

        private void ModWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainWin.siteName = nameTextBox.Text;
            mainWin.siteURL = urlTextBox.Text;
        }

        private void ModWin_Load(object sender, EventArgs e)
        {
            nameTextBox.Text = siteName;
            urlTextBox.Text = siteUrl;
            this.Text = winTitle;
            nameLbl.Text = nameLabel;
            urlLbl.Text = urlLabel;
            okButton.Text = okBtn;
            cancelButton.Text = cancelBtn;
        }
    }
}
