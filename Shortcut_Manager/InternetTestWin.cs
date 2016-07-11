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
    public partial class InternetTestWin : Form
    {
        internal string winTitle, winDesc, winDots, cancelBtn, winLanguage;
        private int dotCount = 0, initializeCount = 0;
        private bool InternetConnected = false, CloseClicked = false;

        public InternetTestWin()
        {
            InitializeComponent();
        }

        private void testTimer_Tick(object sender, EventArgs e)
        {
            initializeCount++;
        }

        private void InternetTest_Load(object sender, EventArgs e)
        {
            //Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NonClientAreaEnabled;

            this.Text = winTitle;
            descLabel.Text = winDesc;
            cancelButton.Text = cancelBtn;

            testProgressBar.Value = 10;
            testProgressBar.Style = ProgressBarStyle.Marquee;
            //testTimer.Start();
            testBackgroundWorker.RunWorkerAsync();
        }

        private void movingDotsTimer_Tick(object sender, EventArgs e)
        {
            if (dotCount == 1)
                descLabel.Text = winDesc + winDots;
            else if (dotCount == 2)
                descLabel.Text = winDesc + winDots + winDots;
            else if (dotCount == 3)
            {
                descLabel.Text = winDesc + winDots + winDots + winDots;
                dotCount = -1;
            }
            else
                descLabel.Text = winDesc;

            dotCount++;
        }

        private void testBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (initializeCount < 3)
            { }
            InternetConnected = mainWin.CheckForInternetConnection();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            testBackgroundWorker.CancelAsync();
            CloseClicked = true;
            this.Close();
        }

        private void testBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            movingDotsTimer.Enabled = false;
            if (InternetConnected)
            {
                testProgressBar.Value = 100;
                testProgressBar.Style = ProgressBarStyle.Continuous;
                testProgressBar.ForeColor = Color.Lime;
                if (winLanguage == "en")
                    descLabel.Text = "You are connected to the internet!";
                else if (winLanguage == "ch")
                    descLabel.Text = "你已连接到网络了！";
            }
            else
            {
                testProgressBar.Value = 100;
                testProgressBar.Style = ProgressBarStyle.Continuous;
                testProgressBar.ForeColor = Color.Red;
                if (winLanguage == "en")
                    descLabel.Text = "You are not connected to the internet!";
                else if (winLanguage == "ch")
                    descLabel.Text = "你没有连接到网络！";
            }

            if (winLanguage == "en")
                cancelButton.Text = "Close";
            else if (winLanguage == "ch")
                cancelButton.Text = "关闭";
        }

        private void InternetTestWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CloseClicked)
                e.Cancel = true;
        }
    }
}
