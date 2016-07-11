using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Shortcut_Manager
{
    public partial class mainWin : Form
    {
        private string tempUrl;
        internal static string siteName, siteURL;
        private static bool IsURLFile = false;
        private static string aboutText = "This program is created by: Katie Delaney" + Environment.NewLine + Environment.NewLine + "Version: 1.5";
        private static string aboutTitle = "About This Program";
        private static string closingText = "Are you sure you wish to quit?";
        private static string closingTitle = "Closing...";
        private static string thisWinTitle = "Shortcut Manager";

        public mainWin()
        {
            InitializeComponent();

            string[] args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
            {
                LoadOnOpen(args[1]);
            }
            else
            {
                LoadOnOpen("");
            }
        }

        private void LoadOnOpen(string target)
        {
            if (target == "")
            {
                target = Directory.GetCurrentDirectory() + @"\" + "sl_list.tdl";
            }

            try
            {
                string line = "";
                string[] items;
                ListViewItem listItem;

                if (loadDefaultListOnStartToolStripMenuItem.Checked)
                {
                    using (StreamReader reader = new StreamReader(target))
                    {
                        //While there are lines to read.
                        while ((line = reader.ReadLine()) != null)
                        {
                            items = line.Split('\t'); //Split the line.
                            listItem = new ListViewItem(); //"Row" object.

                            //For each item in the line.
                            for (int i = 0; i < items.Length; i++)
                            {
                                if (i == 0)
                                {
                                    listItem.Text = items[i]; //First item is not a "subitem".
                                }
                                else
                                {
                                    listItem.SubItems.Add(items[i]); //Add it to the "Row" object.
                                }
                            }

                            shortcutLV.Items.Add(listItem); //Add the row object to the listview.
                        }
                    }
                }
            }
            catch
            { }  
        }

        private void ocButton_Click(object sender, EventArgs e)
        {
            ocButton.Enabled = false;
            edButton.Enabled = true;
            ddButton.Enabled = true;

            addButton.Enabled = false;
            modButton.Enabled = false;
            delButton.Enabled = false;

            UrlTextBox.Enabled = false;
        }

        private void ddButton_Click(object sender, EventArgs e)
        {
            ddButton.Enabled = false;
            ocButton.Enabled = true;
            edButton.Enabled = true;

            addButton.Enabled = false;
            modButton.Enabled = false;
            delButton.Enabled = false;

            UrlTextBox.Enabled = false;
        }

        private void edButton_Click(object sender, EventArgs e)
        {
            edButton.Enabled = false;
            ocButton.Enabled = true;
            ddButton.Enabled = true;

            addButton.Enabled = true;
            modButton.Enabled = true;
            delButton.Enabled = true;

            UrlTextBox.Enabled = true;
        }

        private string CorrectName(string originalName)
        {
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                originalName = originalName.Replace(c, '-');
            }
            return originalName;
        }

        public static bool CheckForInternetConnection()
        {
            string url = "http://www.google.com";
            try
            {
                System.Net.WebRequest myRequest = System.Net.WebRequest.Create(url);
                System.Net.WebResponse myResponse = myRequest.GetResponse();
            }
            catch (System.Net.WebException)
            {
                return false;
            }
            return true;
        }

        private static string StripPrefix(string text, string prefix)
        {
            return text.StartsWith(prefix) ? text.Substring(prefix.Length) : text;
        }

        private static string StripPrefix(string text)
        {
            string prefix = "";
            if (text.StartsWith("http://"))
                prefix = "http://";
            else if (text.StartsWith("https://"))
                prefix = "https://";

            return text.StartsWith(prefix) ? text.Substring(prefix.Length) : text;
        }

        private static string GetDomainName(string url)
        {
            Uri myUri = new Uri(url);
            return myUri.Host;
        }

        private void GetWebPageIcon(string url)
        {
            var client = new System.Net.WebClient();
            string strippedUrl = GetDomainName(url);
            strippedUrl = StripPrefix(strippedUrl);
            try
            {
                client.DownloadFile(@"http://www.google.com/s2/favicons?domain_url=" + strippedUrl, strippedUrl + ".ico");
            }
            catch { }
            shortcutIL.Images.Add(Image.FromFile(strippedUrl + ".ico"));
        }

        private static string GetWebPageTitle(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest.Create(url) as HttpWebRequest);
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                HttpWebResponse response = (request.GetResponse() as HttpWebResponse);

                using (Stream stream = response.GetResponseStream())
                {
                    // compiled regex to check for <title></title> block
                    Regex titleCheck = new Regex(@"<title>\s*(.+?)\s*</title>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                    int bytesToRead = 8092;
                    byte[] buffer = new byte[bytesToRead];
                    string contents = "";
                    int length = 0;
                    while ((length = stream.Read(buffer, 0, bytesToRead)) > 0)
                    {
                        // convert the byte-array to a string and add it to the rest of the
                        // contents that have been downloaded so far
                        contents += Encoding.UTF8.GetString(buffer, 0, length);

                        Match m = titleCheck.Match(contents);
                        if (m.Success)
                        {
                            // we found a <title></title> match =]
                            return m.Groups[1].Value.ToString();
                            break;
                        }
                        else if (contents.Contains("</head>"))
                        {
                            // reached end of head-block; no title found =[
                            return null;
                            break;
                        }
                    }
                    return null;
                }
            }
            catch
            {
                return "error404";
            }
        }

        private static string DecodeTitle(string encodedStr)
        {
            //string decodedStr = WebUtility.HtmlDecode(encodedStr);
            //string decodedStr = System.Web.HttpUtility.HtmlDecode(encodedStr);
            //return decodedStr;

            return System.Web.HttpUtility.HtmlDecode(encodedStr);
        }

        /// <summary>The name of the ASCII URL data format in the drag-and-drop data.</summary>
        private const string _asciiUrlDataFormatName = "UniformResourceLocator";

        /// <summary>The text encoding used to read ASCII URLs from the drag-and-drop data.</summary>
        private static readonly Encoding _asciiUrlEncoding = Encoding.ASCII;

        /// <summary>The name of the Unicode URL data format in the drag-and-drop data.</summary>
        private const string _unicodeUrlDataFormatName = "UniformResourceLocatorW";

        /// <summary>The text encoding used to read Unicode URLs from the drag-and-drop data.</summary>
        private static readonly Encoding _unicodeUrlEncoding = Encoding.Unicode;

        /// <summary>Tests whether drag-and-drop data contains a URL.</summary>
        /// <param name="data">The drag-and-drop data.</param>
        /// <returns><see langword="true"/> if <paramref name="data"/> contains a URL,
        /// <see langword="false"/> otherwise.</returns>
        private static bool DoesDragDropDataContainUrl(IDataObject data)
        {
            // Test for both Unicode and ASCII URLs
            return
                DoesDragDropDataContainUrl(data, _unicodeUrlDataFormatName) ||
                DoesDragDropDataContainUrl(data, _asciiUrlDataFormatName);
        }

        /// <summary>Tests whether drag-and-drop data contains a URL using a particular text encoding.</summary>
        /// <param name="data">The drag-and-drop data.</param>
        /// <param name="urlDataFormatName">The data format name of the URL type.</param>
        /// <returns><see langword="true"/> if <paramref name="data"/> contains a URL of the correct type,
        /// <see langword="false"/> otherwise.</returns>
        private static bool DoesDragDropDataContainUrl(IDataObject data, string urlDataFormatName)
        {
            return data != null && data.GetDataPresent(urlDataFormatName);
        }

        /// <summary>Reads a URL from drag-and-drop data.</summary>
        /// <param name="data">The drag-and-drop data.</param>
        /// <returns>A URL, or <see langword="null"/> if <paramref name="data"/> does not contain a URL.</returns>
        private string ReadUrlFromDragDropData(IDataObject data)
        {
            // Try to read a Unicode URL from the data
            string unicodeUrl = ReadUrlFromDragDropData(data, _unicodeUrlDataFormatName, _unicodeUrlEncoding);
            if (unicodeUrl != null)
            {
                return unicodeUrl;
            }

            // Try to read an ASCII URL from the data
            return ReadUrlFromDragDropData(data, _asciiUrlDataFormatName, _asciiUrlEncoding);
        }

        /// <summary>Reads a URL using a particular text encoding from drag-and-drop data.</summary>
        /// <param name="data">The drag-and-drop data.</param>
        /// <param name="urlDataFormatName">The data format name of the URL type.</param>
        /// <param name="urlEncoding">The text encoding of the URL type.</param>
        /// <returns>A URL, or <see langword="null"/> if <paramref name="data"/> does not contain a URL
        /// of the correct type.</returns>
        private string ReadUrlFromDragDropData(IDataObject data, string urlDataFormatName, Encoding urlEncoding)
        {
            // Check whether the data contains a URL
            if (!DoesDragDropDataContainUrl(data, urlDataFormatName))
            {
                return null;
            }

            // Read the URL from the data
            string url;
            using (Stream urlStream = (Stream)data.GetData(urlDataFormatName))
            {
                using (TextReader reader = new StreamReader(urlStream, urlEncoding))
                {
                    url = reader.ReadToEnd();
                }
            }

            // URLs in drag/drop data are often padded with null characters so remove these
            return url.TrimEnd('\0');
        }



        private void UrlTextBox_DragEnter(object sender, DragEventArgs e)
        {//http://stackoverflow.com/questions/32241770/c-sharp-how-to-detect-and-process-a-url-file-type-on-dragdrop-event
            //http://jamespreston.co.uk/Articles/UrlDragAndDropNotes.html
            string tempDataName = e.Data.ToString();
            // Display a suitable icon if the drag-and-drop data contains a URL

            if (DoesDragDropDataContainUrl(e.Data) )
            {
                e.Effect = DragDropEffects.Link;
                IsURLFile = false;
            }
            else
            {
                string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (file.Length != 1)
                { e.Effect = DragDropEffects.None; }
                else
                {
                    if (Path.GetExtension(file[0]) == ".url" || Path.GetExtension(file[0]) == ".website")
                    {
                        e.Effect = DragDropEffects.Link;
                        IsURLFile = true;
                    }
                }
            }
        }

        private void UrlTextBox_DragDrop(object sender, DragEventArgs e)
        {//http://stackoverflow.com/questions/32241770/c-sharp-how-to-detect-and-process-a-url-file-type-on-dragdrop-event
            //http://jamespreston.co.uk/Articles/UrlDragAndDropNotes.html
            if (IsURLFile)
            {
                string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);

                string tempTitle = Path.GetFileNameWithoutExtension(file[0]);
                string tempURL = ""; ;
                using (StreamReader reader = new StreamReader(file[0]))
                {
                    while (reader.Peek() != -1)
                    {
                        string tempRead = reader.ReadLine();
                        if (tempRead.Contains("URL="))
                        {
                            tempURL = tempRead.Substring("URL=".Length);
                            break;
                        }
                    }
                }

                if (IsValidUrl(tempURL) && !tempURL.Contains(".exe") && !tempURL.Contains(".msi"))
                { }
                else
                {
                    if (englishToolStripMenuItem.Checked)
                        MessageBox.Show("The provided link is not in the proper URL format!" + Environment.NewLine + Environment.NewLine + "It should start with either \"http://\" or \"https://\"", "Invalid URL Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("你所给的链接目标有格式错误！" + Environment.NewLine + Environment.NewLine + "因该用 \"http://\" 或 \"https://\" 开始！", "无效的格式", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ListViewItem tempLVI = new ListViewItem(new string[] { tempTitle, tempURL }, 0);

                shortcutLV.Items.Add(tempLVI);

                if (autodeleteURLFilesToolStripMenuItem.Checked)
                {
                    File.Delete(file[0]);
                }
            }
            else
            {
                // Check whether a URL was dropped on this text box and display it if found. Be very careful
                // how long you take in this method - the source application for the URL is blocked until you
                // exit the method.

                string droppedUrl = ReadUrlFromDragDropData(e.Data);
                if (droppedUrl != null && droppedUrl.Trim().Length != 0)
                {
                    //UrlTextBox.Text = droppedUrl;
                    tempUrl = droppedUrl;
                    getTitleTimer.Start();
                    UrlTextBox.Enabled = false;
                    ddButton.Enabled = false;
                    ocButton.Enabled = false;
                }
            }
        }

        private void getTitleTimer_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string tempTitle = GetWebPageTitle(tempUrl);
            if (tempTitle == "error404")
            {
                getTitleTimer.Stop();
                getTitleTimer.Stop();
                if (englishToolStripMenuItem.Checked)
                    MessageBox.Show("You are not connected to the internet!", "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("您现在没有连接到网络！", "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tempTitle = DecodeTitle(tempTitle);
            ListViewItem tempLVI = new ListViewItem(new string[] { tempTitle, tempUrl }, 0);
            //GetWebPageIcon(tempUrl);
            getTitleTimer.Stop();
            shortcutLV.Items.Add(tempLVI);

            this.Cursor = Cursors.Default;
            UrlTextBox.Enabled = true;
            ddButton.Enabled = true;
            ocButton.Enabled = true;

            //}
            //catch
            //{
            //    getTitleTimer.Stop();
            //    getTitleTimer.Stop();

            //    if (englishToolStripMenuItem.Checked)
            //        MessageBox.Show("You are not connected to the internet currently!", "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    else //if (chineseToolStripMenuItem.Checked)
            //        MessageBox.Show("您现在没有连接到网络！", "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            if (shortcutLV.SelectedIndices.Count == 1)
            {
                if (shortcutLV.SelectedIndices[0] != -1)
                    shortcutLV.Items.RemoveAt(shortcutLV.SelectedIndices[0]);
            }
            else if (shortcutLV.SelectedIndices.Count > 1)
            {
                for (int i = 0; i < shortcutLV.Items.Count; i++)
                {
                    if (shortcutLV.Items[i].Selected)
                    {
                        shortcutLV.Items[i].Remove();
                        i--;
                    }
                }
            }
            else
            {
                if (englishToolStripMenuItem.Checked)
                    MessageBox.Show("You must select an entry before deleting!", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (chineseToolStripMenuItem.Checked)
                    MessageBox.Show("不可以那么做！!", "不应许！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modButton_Click(object sender, EventArgs e)
        {
            if (shortcutLV.SelectedIndices.Count == 1)
            {
                int modIndex = shortcutLV.SelectedIndices[0];
                ModWin objMod;

                if (englishToolStripMenuItem.Checked)
                {
                    objMod = new ModWin
                    {
                        winTitle = "Modifying Entry",
                        siteName = shortcutLV.Items[modIndex].Text,
                        siteUrl = shortcutLV.Items[modIndex].SubItems[1].Text,
                        okBtn = "OK",
                        cancelBtn = "Cancel",
                        nameLabel = "Site Name:",
                        urlLabel = "URL:"
                    };
                }
                else //if (chineseToolStripMenuItem.Checked)
                {
                    objMod = new ModWin
                    {
                        winTitle = "修改资料",
                        siteName = shortcutLV.Items[modIndex].Text,
                        siteUrl = shortcutLV.Items[modIndex].SubItems[1].Text,
                        okBtn = "好的",
                        cancelBtn = "取消",
                        nameLabel = "网站名字：",
                        urlLabel = "网站地址："
                    };
                }

                if (objMod.ShowDialog() == DialogResult.OK)
                {  
                    shortcutLV.Items[modIndex].Text = siteName;
                    shortcutLV.Items[modIndex].SubItems[1].Text = siteURL;
                }
            }
            else if (shortcutLV.SelectedIndices.Count == 0)
            {
                if (englishToolStripMenuItem.Checked)
                    MessageBox.Show("You have to select an entry before modifying it!", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (chineseToolStripMenuItem.Checked)
                    MessageBox.Show("不可以那么做！!", "不应许！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (englishToolStripMenuItem.Checked)
                    MessageBox.Show("You cannot modify more than one entry at a time!", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (chineseToolStripMenuItem.Checked)
                    MessageBox.Show("不可以那么做！!", "不应许！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            ModWin objAdd;

            if (englishToolStripMenuItem.Checked)
            {
                objAdd = new ModWin
                {
                    winTitle = "Add Entry",
                    siteName = "",
                    siteUrl = "",
                    okBtn = "OK",
                    cancelBtn = "Cancel",
                    nameLabel = "Site Name:",
                    urlLabel = "URL:"
                };
            }
            else //if (chineseToolStripMenuItem.Checked)
            {
                objAdd = new ModWin
                {
                    winTitle = "添加资料",
                    okBtn = "好的",
                    siteName = "",
                    siteUrl = "",
                    cancelBtn = "取消",
                    nameLabel = "网站名字：",
                    urlLabel = "网站地址："
                };
            }

            if (objAdd.ShowDialog() == DialogResult.OK)
            {
                if (IsValidUrl(siteURL) && !siteURL.Contains(".exe") && !siteURL.Contains(".msi"))
                {
                    ListViewItem addListItem = new ListViewItem(new string[] { siteName, siteURL }, 0);
                    shortcutLV.Items.Add(addListItem);
                }
                else
                {
                    if (englishToolStripMenuItem.Checked)
                        MessageBox.Show("The provided link is not in the proper URL format!" + Environment.NewLine + Environment.NewLine + "It should start with either \"http://\" or \"https://\"", "Invalid URL Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("你所给的链接目标有格式错误！" + Environment.NewLine + Environment.NewLine + "因该用 \"http://\" 或 \"https://\" 开始！", "无效的格式", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void shortcutLV_DoubleClick(object sender, EventArgs e)
        {
            if (shortcutLV.SelectedIndices.Count == 1)
            {
                if (!ocButton.Enabled)
                {
                    int opIndex = shortcutLV.SelectedIndices[0];
                    System.Diagnostics.Process.Start(shortcutLV.Items[opIndex].SubItems[1].Text);
                }
            }
        }

        private bool IsValidUrl(string uriName)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(uriName, UriKind.Absolute, out uriResult)
                          && (uriResult.Scheme == Uri.UriSchemeHttp
                              || uriResult.Scheme == Uri.UriSchemeHttps);
            return result;
        }

        private void shortcutLV_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (shortcutLV.SelectedIndices.Count == 1 && !ddButton.Enabled)
            {
                ListViewItem item = e.Item as ListViewItem;
                if (item != null)
                {
                    //create FileGroupDescriptor stream with the title of the link
                    string newTitle = CorrectName(item.SubItems[0].Text);
                    Byte[] title = System.Text.Encoding.ASCII.GetBytes(newTitle + ".url");
                    Byte[] fileGroupDescriptor = new Byte[336];
                    title.CopyTo(fileGroupDescriptor, 76);

                    //add the magic numbers!
                    fileGroupDescriptor[0] = 0x1;
                    fileGroupDescriptor[4] = 0x40;
                    fileGroupDescriptor[5] = 0x80;
                    fileGroupDescriptor[72] = 0x78;//seems to vary but is needed or WinXP drag wont work
                    MemoryStream fileGroupDescriptorStream = new MemoryStream(fileGroupDescriptor);

                    //Create the url stream
                    String url = item.SubItems[1].Text; //get the url string
                    Byte[] urlByteArray = System.Text.Encoding.ASCII.GetBytes(url);
                    MemoryStream urlStream = new MemoryStream(urlByteArray);

                    //create filecontents see http://www.cyanwerks.com/file-format-url.html for full format of this file
                    string contents;
                    if (googleChromeToolStripMenuItem.Checked)
                        contents = "[InternetShortcut]" + Environment.NewLine + "URL=" + url + Environment.NewLine;
                    else
                    {
                        contents = "[InternetShortcut]" + Environment.NewLine + "URL=" + url + 
                            Environment.NewLine + "IDList=" + "" + Environment.NewLine + "HotKey=" + "0" + 
                            Environment.NewLine + "IconFile=" + "" + Environment.NewLine + "IconIndex=" + "0";
                    }
                    Byte[] contentsByteArray = System.Text.Encoding.ASCII.GetBytes(contents);
                    MemoryStream contentsStream = new MemoryStream(contentsByteArray);

                    //Add everything to the dataobject
                    DataObject data = new DataObject();
                    data.SetData("FileGroupDescriptor", fileGroupDescriptorStream); //becomes title of link on desktop
                    data.SetData("FileContents", contentsStream); //becomes contents of the .url file
                    data.SetData("UniformResourceLocator", urlStream); //used for dragging to other browsers
                    this.DoDragDrop(data, DragDropEffects.Link);
                }
            }
        }

        private void UrlTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string target = Directory.GetCurrentDirectory() + @"\" + "sl_list.tdl";

            using (StreamWriter s_w = new StreamWriter(target))
            {
                //s_w.WriteLine("Firstname \t Lastname \t Age");
                for (int intSaveLinks = 0; intSaveLinks < shortcutLV.Items.Count; intSaveLinks++)
                {
                    s_w.WriteLine("{0}\t{1}", shortcutLV.Items[intSaveLinks].SubItems[0].Text, shortcutLV.Items[intSaveLinks].SubItems[1].Text);
                }
            }
        }

        private void UrlTextBox_Click(object sender, EventArgs e)
        {
            focusLabel.Focus();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsFile();
        }

        private bool SaveAsFile()
        {
            string target = "sl_list.tdl";
            bool SavedFile = false;
            SaveFileDialog saveFD;

            if (englishToolStripMenuItem.Checked)
            {
                saveFD = new SaveFileDialog
                {
                    Title = "Save as...",
                    Filter = "TDL List|*.tdl",
                    FileName = "sl_list.tdl"
                };
            }
            else
            {
                saveFD = new SaveFileDialog
                {
                    Title = "另存为。。。",
                    Filter = "TDL List|*.tdl",
                    FileName = "sl_list.tdl"
                };
            }

            if (saveFD.ShowDialog() == DialogResult.OK)
            {
                target = saveFD.FileName;
                SavedFile = true;
            }
            else
                return SavedFile;

            using (StreamWriter s_w = new StreamWriter(target))
            {
                //s_w.WriteLine("Firstname \t Lastname \t Age");
                for (int intSaveLinks = 0; intSaveLinks < shortcutLV.Items.Count; intSaveLinks++)
                {
                    s_w.WriteLine("{0}\t{1}", shortcutLV.Items[intSaveLinks].SubItems[0].Text, shortcutLV.Items[intSaveLinks].SubItems[1].Text);
                }
            }
            this.Text = thisWinTitle + " - " + Path.GetFileNameWithoutExtension(target);

            return SavedFile;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string target = "";
                string line = "";
                string[] items;
                ListViewItem listItem;
                OpenFileDialog openFD;

                if (englishToolStripMenuItem.Checked)
                {
                    openFD = new OpenFileDialog
                    {
                        Title = "Select TDL Shortcuts List to load...",
                        Filter = "TDL List|*.tdl"
                    };
                }
                else //if (chineseToolStripMenuItem.Checked)
                {
                    openFD = new OpenFileDialog
                    {
                        Title = "选择TDL链接文件列表来开。。。",
                        Filter = "TDL List|*.tdl"
                    };
                }

                if (openFD.ShowDialog() == DialogResult.OK)
                {
                    target = openFD.FileName;
                    if (!appendWhenLoadingToolStripMenuItem.Checked)
                        shortcutLV.Items.Clear();
                }
                else
                    return;

                using (StreamReader reader = new StreamReader(target))
                {
                    //While there are lines to read.
                    while ((line = reader.ReadLine()) != null)
                    {
                        items = line.Split('\t'); //Split the line.
                        listItem = new ListViewItem(); //"Row" object.

                        //For each item in the line.
                        for (int i = 0; i < items.Length; i++)
                        {
                            if (i == 0)
                            {
                                listItem.Text = items[i]; //First item is not a "subitem".
                            }
                            else
                            {
                                listItem.SubItems.Add(items[i]); //Add it to the "Row" object.
                            }
                        }

                        shortcutLV.Items.Add(listItem); //Add the row object to the listview.
                    }
                }
            }
            catch { }
        }

        private void clearListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shortcutLV.Items.Clear();
            this.Text = thisWinTitle;
        }

        private void showDragDropPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showDragDropPanelToolStripMenuItem.Checked)
            {
                showDragDropPanelToolStripMenuItem.Checked = false;
                dragdropParentPanel.Visible = false;
            }
            else
            {
                showDragDropPanelToolStripMenuItem.Checked = true;
                dragdropParentPanel.Visible = true;
            }
        }

        private void SaveConfig()
        {
            try
            {
                string target = Directory.GetCurrentDirectory() + @"\" + "settings.ini";
                using (StreamWriter s_w = new StreamWriter(target))
                {
                    s_w.WriteLine("[Configuration File]");
                    s_w.WriteLine("LoadDefaultListOnStart=" + loadDefaultListOnStartToolStripMenuItem.Checked.ToString());
                    s_w.WriteLine("ShowDragDropPanel=" + showDragDropPanelToolStripMenuItem.Checked.ToString());
                    s_w.WriteLine("AppendWhenLoading=" + appendWhenLoadingToolStripMenuItem.Checked.ToString());
                    s_w.WriteLine("AutoDeleteUrlFiles=" + autodeleteURLFilesToolStripMenuItem.Checked.ToString());
                    s_w.WriteLine("AlwaysOnTop=" + alwaysOnTopToolStripMenuItem.Checked.ToString()); 
                    if (englishToolStripMenuItem.Checked)
                        s_w.WriteLine("Language=" + "english");
                    else if (chineseToolStripMenuItem.Checked)
                        s_w.WriteLine("Language=" + "chinese");
                }
            }
            catch
            { }
        }

        private void mainWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig();

            if (shortcutLV.Items.Count != 0)
            {
                var CheckResult = MessageBox.Show(closingText, closingTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (CheckResult == DialogResult.Yes)
                {
                    if (!SaveAsFile())
                        e.Cancel = true;
                }
                else if (CheckResult == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void mainWin_Load(object sender, EventArgs e)
        {
            try
            {
                string target = Directory.GetCurrentDirectory() + @"\" + "settings.ini";

                using (StreamReader reader = new StreamReader(target))
                {
                    while (reader.Peek() != -1)
                    {
                        string tempRead = reader.ReadLine();
                        if (tempRead.Contains("LoadDefaultListOnStart="))
                        {
                            loadDefaultListOnStartToolStripMenuItem.Checked = bool.Parse(tempRead.Substring("loadDefaultListOnStart=".Length));
                        }
                        else if (tempRead.Contains("ShowDragDropPanel="))
                        {
                            showDragDropPanelToolStripMenuItem.Checked = bool.Parse(tempRead.Substring("showDragDropPanel=".Length));
                        }
                        else if (tempRead.Contains("AppendWhenLoading="))
                        {
                            appendWhenLoadingToolStripMenuItem.Checked = bool.Parse(tempRead.Substring("appendWhenLoading=".Length));
                        }
                        else if (tempRead.Contains("AutoDeleteUrlFiles="))
                        {
                            autodeleteURLFilesToolStripMenuItem.Checked = bool.Parse(tempRead.Substring("autodeleteurlfiles=".Length));
                        }
                        else if (tempRead.Contains("AlwaysOnTop="))
                        {
                            this.TopMost = alwaysOnTopToolStripMenuItem.Checked = bool.Parse(tempRead.Substring("AlwaysOnTop=".Length));
                        }
                        else if (tempRead.Contains("Language="))
                        {
                            string langString = tempRead.Substring("Language=".Length);

                            if (langString.ToLower() == "chinese")
                                ChangeToChinese();
                            else if (langString.ToLower() == "english")
                                ChangeToEnglish();
                        }
                    }
                }
            }
            catch
            { }

            //LoadOnOpen("");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(aboutText, aboutTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void chineseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!chineseToolStripMenuItem.Checked)
            {
                ChangeToChinese();
            }
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!englishToolStripMenuItem.Checked)
            {
                ChangeToEnglish();
            }
        }

        private void ChangeToChinese()
        {
            englishToolStripMenuItem.Checked = false;
            chineseToolStripMenuItem.Checked = true;

            englishToolStripMenuItem.Text = "英语";
            chineseToolStripMenuItem.Text = "简体中文";
            languageToolStripMenuItem.Text = "语言";

            delButton.Text = "删除";
            modButton.Text = "修改";
            addButton.Text = "加入";

            edButton.Text = "改变";
            ocButton.Text = "在点击打开";
            ddButton.Text = "拉和放";

            modeGroupBox.Text = "模式";
            editGroupBox.Text = "编辑";

            aboutText = "制作者：妍凌" + Environment.NewLine + "翻译者：妍凌" + Environment.NewLine + Environment.NewLine + "版本号： 1.5";
            aboutTitle = "关于这个软件";

            aboutToolStripMenuItem.Text = "关于软件";
            settingsToolStripMenuItem.Text = "设置";

            appendWhenLoadingToolStripMenuItem.Text = "加载时追加";
            showDragDropPanelToolStripMenuItem.Text = "显示拉和放面板";
            loadDefaultListOnStartToolStripMenuItem.Text = "在启动加载数据";

            toolsToolStripMenuItem.Text = "工具";
            fileToolStripMenuItem.Text = "文件";
            saveAsToolStripMenuItem.Text = "保存为";
            saveToolStripMenuItem.Text = "保存";
            clearListToolStripMenuItem.Text = "清除所有";
            openToolStripMenuItem.Text = "打开文件";
            exitToolStripMenuItem.Text = "离开";

            dragdropGB.Text = "拉和放链接文件在这里";
            UrlTextBox.Text = Environment.NewLine + Environment.NewLine + "一个接一个的拉和放链接文件在这里";

            listGroupBox.Text = "链接文件列表";

            columnHeaderSite.Text = "网站名字";
            columnHeaderURL.Text = "网站地址";

            closingText = "你要保存文件吗？";
            closingTitle = "正在关闭。。。";

            testForInternetToolStripMenuItem.Text = "网络测试";
            autodeleteURLFilesToolStripMenuItem.Text = "自动删除链接文件";
            uRLCreationFormatToolStripMenuItem.Text = "创建格式";
            mozillaFirefoxToolStripMenuItem.Text = "火狐浏览器";
            googleChromeToolStripMenuItem.Text = "谷歌浏览器";
            alwaysOnTopToolStripMenuItem.Text = "每次在上面";

            thisWinTitle = "捷径经理";
            this.Text = thisWinTitle;
        }

        private void ChangeToEnglish()
        {
            englishToolStripMenuItem.Checked = true;
            chineseToolStripMenuItem.Checked = false;

            aboutText = "This program is created by: Katie Delaney" + Environment.NewLine + Environment.NewLine + "Version: 1.5";
            aboutTitle = "About This Program";

            ddButton.Text = "Drag && Drop";
            ocButton.Text = "Open on click";
            edButton.Text = "Editing";
            addButton.Text = "Add";
            modButton.Text = "Modify";
            delButton.Text = "Delete";

            UrlTextBox.Text = Environment.NewLine + Environment.NewLine + "Drag and drop shortcuts here, one-by-one!";
            dragdropGB.Text = "Drag && Drop Shortcuts Here";
            listGroupBox.Text = "Shortcuts List";
            modeGroupBox.Text = "Mode";
            editGroupBox.Text = "Editing";
            fileToolStripMenuItem.Text = "File";
            saveAsToolStripMenuItem.Text = "Save As";
            saveToolStripMenuItem.Text = "Save";
            openToolStripMenuItem.Text = "Load";
            clearListToolStripMenuItem.Text = "Clear List";
            exitToolStripMenuItem.Text = "Exit";
            toolsToolStripMenuItem.Text = "Tools";
            settingsToolStripMenuItem.Text = "Settings";
            aboutToolStripMenuItem.Text = "About";
            appendWhenLoadingToolStripMenuItem.Text = "Append when loading";
            showDragDropPanelToolStripMenuItem.Text = "Show Drag-&&-Drop Panel";
            loadDefaultListOnStartToolStripMenuItem.Text = "Load Default List on Start";
            languageToolStripMenuItem.Text = "Language";
            englishToolStripMenuItem.Text = "English";
            chineseToolStripMenuItem.Text = "Simplified Chinese";
            testForInternetToolStripMenuItem.Text = "Test for Internet";

            closingText = "Do you want to save your list?";
            closingTitle = "Closing...";
            autodeleteURLFilesToolStripMenuItem.Text = "Auto-delete URL Files";
            uRLCreationFormatToolStripMenuItem.Text = "URL Creation Format";
            googleChromeToolStripMenuItem.Text = "Google Chrome";
            mozillaFirefoxToolStripMenuItem.Text = "Mozilla Firefox";
            alwaysOnTopToolStripMenuItem.Text = "Always on Top";

            columnHeaderSite.Text = "Site";
            columnHeaderURL.Text = "URL";

            thisWinTitle = "Shortcut Manager";
            this.Text = thisWinTitle;
        }

        private void testForInternetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InternetTestWin objTest;

            if (englishToolStripMenuItem.Checked)
            {
                objTest = new InternetTestWin
                {
                    winTitle = "Internet Test",
                    winDesc = "Testing for internet connection",
                    winDots = ".",
                    cancelBtn = "Cancel",
                    winLanguage = "en"
                };
            }
            else
            {
                objTest = new InternetTestWin
                {
                    winTitle = "网络测试",
                    winDesc = "正在试你的网络状态",
                    winDots = "。",
                    cancelBtn = "取消",
                    winLanguage = "ch"
                };
            }

            objTest.ShowDialog();
        }

        private void mozillaFirefoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!mozillaFirefoxToolStripMenuItem.Checked)
            {
                mozillaFirefoxToolStripMenuItem.Checked = true;
                googleChromeToolStripMenuItem.Checked = false;
            }
        }

        private void googleChromeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!googleChromeToolStripMenuItem.Checked)
            {
                googleChromeToolStripMenuItem.Checked = true;
                mozillaFirefoxToolStripMenuItem.Checked = false;
            }
        }

        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = alwaysOnTopToolStripMenuItem.Checked = !alwaysOnTopToolStripMenuItem.Checked;
        }
    }
}
