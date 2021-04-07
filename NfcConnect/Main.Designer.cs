
namespace NfcConnect
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LState = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BBuildCommand = new System.Windows.Forms.Button();
            this.LBAction = new System.Windows.Forms.ListBox();
            this.LBLocation = new System.Windows.Forms.ListBox();
            this.LBSubjects = new System.Windows.Forms.ListBox();
            this.TBCommand = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPage1);
            this.tabControlMain.Controls.Add(this.tabPage2);
            this.tabControlMain.ItemSize = new System.Drawing.Size(500, 40);
            this.tabControlMain.Location = new System.Drawing.Point(13, 3);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.Padding = new System.Drawing.Point(60, 3);
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1125, 721);
            this.tabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlMain.TabIndex = 1;
            this.tabControlMain.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControlMain_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.LState);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 44);
            this.tabPage1.Name = "readPage";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1117, 673);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Einlesen";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // LState
            // 
            this.LState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LState.AutoSize = true;
            this.LState.Location = new System.Drawing.Point(504, 112);
            this.LState.Name = "LState";
            this.LState.Size = new System.Drawing.Size(107, 17);
            this.LState.TabIndex = 12;
            this.LState.Text = "Aktueller Status";
            this.LState.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(536, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "label1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BBuildCommand);
            this.tabPage2.Controls.Add(this.LBAction);
            this.tabPage2.Controls.Add(this.LBLocation);
            this.tabPage2.Controls.Add(this.LBSubjects);
            this.tabPage2.Controls.Add(this.TBCommand);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Location = new System.Drawing.Point(4, 44);
            this.tabPage2.Name = "configurationPage";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1117, 673);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Konfiguration";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BBuildCommand
            // 
            this.BBuildCommand.Location = new System.Drawing.Point(259, 450);
            this.BBuildCommand.Name = "BBuildCommand";
            this.BBuildCommand.Size = new System.Drawing.Size(189, 45);
            this.BBuildCommand.TabIndex = 15;
            this.BBuildCommand.Text = "Bausteine einsetzen";
            this.BBuildCommand.UseVisualStyleBackColor = true;
            this.BBuildCommand.Click += new System.EventHandler(this.BBuildCommand_Click);
            // 
            // LBAction
            // 
            this.LBAction.FormattingEnabled = true;
            this.LBAction.ItemHeight = 16;
            this.LBAction.Location = new System.Drawing.Point(488, 23);
            this.LBAction.Name = "LBAction";
            this.LBAction.Size = new System.Drawing.Size(201, 356);
            this.LBAction.TabIndex = 14;
            // 
            // LBLocation
            // 
            this.LBLocation.FormattingEnabled = true;
            this.LBLocation.ItemHeight = 16;
            this.LBLocation.Location = new System.Drawing.Point(259, 23);
            this.LBLocation.Name = "LBLocation";
            this.LBLocation.Size = new System.Drawing.Size(201, 356);
            this.LBLocation.TabIndex = 13;
            // 
            // LBSubjects
            // 
            this.LBSubjects.FormattingEnabled = true;
            this.LBSubjects.ItemHeight = 16;
            this.LBSubjects.Location = new System.Drawing.Point(36, 23);
            this.LBSubjects.Name = "LBSubjects";
            this.LBSubjects.Size = new System.Drawing.Size(201, 356);
            this.LBSubjects.TabIndex = 12;
            // 
            // TBCommand
            // 
            this.TBCommand.Location = new System.Drawing.Point(36, 407);
            this.TBCommand.Name = "TBCommand";
            this.TBCommand.Size = new System.Drawing.Size(653, 22);
            this.TBCommand.TabIndex = 10;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(259, 510);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(189, 45);
            this.button3.TabIndex = 9;
            this.button3.Text = "Karte schreiben";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 736);
            this.Controls.Add(this.tabControlMain);
            this.Name = "Main";
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox TBCommand;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label LState;
        private System.Windows.Forms.ListBox LBSubjects;
        private System.Windows.Forms.ListBox LBAction;
        private System.Windows.Forms.ListBox LBLocation;
        private System.Windows.Forms.Button BBuildCommand;
    }
}

