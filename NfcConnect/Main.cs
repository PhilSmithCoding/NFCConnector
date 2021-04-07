using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows;
using MessageBox = System.Windows.MessageBox;
using System.Windows.Media;
using Amazon.Polly;
using Amazon.Polly.Model;
using System.IO;
using NfcConnect.Properties;
using System.Xml;
using NfcConnect.Helpers;
using NfcConnect.Database;

namespace NfcConnect
{
    public partial class Main : Form
    {

        #region members

        private XMLConfigHelper _ConfigHelper;
        string _AWSAccessKeyId;
        string _AWSSecretAccessKey;
        private DatabaseConnect _DatabaseConnect;
        private MediaPlayer _MediaPlayer = new MediaPlayer();
        private NFCReader _NFCReader;

        #endregion

        #region constructor

        public Main()
        {
            InitializeComponent();
            _NFCReader = new NFCReader();
            _NFCReader.EstablishContext();
            _ConfigHelper = new XMLConfigHelper(ConfigurationManager.AppSettings["configurationFile"]);
            var AWSConfigHelper = new XMLConfigHelper(ConfigurationManager.AppSettings["AWSConfigurationFile"]);
            var nodes = AWSConfigHelper.GetConfigurationElements("Entries", out XmlNode xmlNode, "AWSConfiguration");
            _AWSAccessKeyId = ((XmlElement)nodes.SingleOrDefault(node => ((XmlElement) node).GetAttribute("key") == "awsAccessKeyId")).GetAttribute("value");
            _AWSSecretAccessKey = ((XmlElement)nodes.SingleOrDefault(node => ((XmlElement)node).GetAttribute("key") == "awsSecretAccessKey")).GetAttribute("value");
            _DatabaseConnect = new DatabaseConnect();
        }

        #endregion

        #region main actions

        private void Main_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            SetApplicationResolution();
            //FormBorderStyle = FormBorderStyle.None;
            timer1.Start();
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            _NFCReader.CloseReader();
        }

        #endregion

        #region ticker actions
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_NFCReader.ConnectCard())
            {
                timer1.Stop();
                string text = _NFCReader.VerifyCard("5"); // 5 - is the block we are reading
                string fileName = _NFCReader.GetcardUID();
                string command = _DatabaseConnect.GetCommandForCardID(_NFCReader.GetcardUID());
                label1.Text = command;
                AmazonPollyClient pc = new AmazonPollyClient(_AWSAccessKeyId, _AWSSecretAccessKey, Amazon.RegionEndpoint.EUWest3);

                SynthesizeSpeechRequest sreq = new SynthesizeSpeechRequest();
                sreq.OutputFormat = OutputFormat.Mp3;
                sreq.VoiceId = VoiceId.Marlene;
                sreq.Text = command;
                SynthesizeSpeechResponse sres = pc.SynthesizeSpeech(sreq);
                using (var fileStream = File.Create($@"C:\Users\pschm\Documents\Studium\mp3_output\{fileName}.mp3"))
                {
                    sres.AudioStream.CopyTo(fileStream);
                    fileStream.Flush();
                    fileStream.Close();
                }
                    string sFileName = $@"C:\Users\pschm\Documents\Studium\mp3_output\{fileName}.mp3";
                _MediaPlayer.Open(new Uri(sFileName));
                _MediaPlayer.Play();
                _MediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!_NFCReader.ConnectCard())
            {
                timer2.Stop();
                timer1.Start();
            }
        }

        #endregion

        #region media player actions

        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            _MediaPlayer.Close();
            _MediaPlayer.MediaEnded -= MediaPlayer_MediaEnded;
        }

        #endregion

        #region tabcontrol actions

        private void tabControlMain_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage.Name == "configurationPage")
            {
                LBAction.Items.Clear();
                LBSubjects.Items.Clear();
                LBLocation.Items.Clear();
                XmlNode subjectsNode;
                IEnumerable<XmlNode> items = _ConfigHelper.GetConfigurationElements("Subjects", out subjectsNode, "Configuration/ConstructionKit");
                foreach (XmlElement item in items)
                {
                    LBSubjects.Items.Add(item.GetAttribute("value"));
                }
                items = _ConfigHelper.GetConfigurationElements("Locations", out XmlNode locationNode, subjectsNode.FirstChild);
                foreach (XmlElement item in items)
                {
                    LBLocation.Items.Add(item.GetAttribute("value"));
                }
                items = _ConfigHelper.GetConfigurationElements("Actions", out XmlNode actionsNode, subjectsNode.FirstChild);
                foreach (XmlElement item in items)
                {
                    LBAction.Items.Add(item.GetAttribute("value"));
                }
            }
            LState.Text = Resources.LMainPageState;
        }

        #endregion

        #region button actions
        private void BBuildCommand_Click(object sender, EventArgs e)
        {
            TBCommand.Text = $"{(string)LBSubjects.SelectedItem} {(string)LBLocation.SelectedItem} {(string)LBAction.SelectedItem} ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_NFCReader.ConnectCard())// establish connection to the card: you've declared this from previous post
            {
                _NFCReader.SubmitText(TBCommand.Text, "5"); // 5 - is the block we are writing data on the card
                _DatabaseConnect.WriteCommandForCardID(_NFCReader.GetcardUID(), "",TBCommand.Text);
                _NFCReader.CloseReader();
            }
        }
        #endregion

        #region private methods

        private void SetApplicationResolution()
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            tabControlMain.Size = new System.Drawing.Size(screenWidth - 20, screenHeight - 100);
            tabControlMain.ItemSize = new System.Drawing.Size((int)(screenWidth - 23) / 2, 40);
        }

        #endregion

    }
}