namespace Model_Downsizer
{
    partial class mainForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxOrigin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxDestination = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBoxSaveName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.folderBrowserOrigin = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.button5 = new System.Windows.Forms.Button();
            this.listBoxSettings = new System.Windows.Forms.ListBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.closeModelDownsizer = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ExecutePreset5 = new System.Windows.Forms.Button();
            this.ExecutePreset4 = new System.Windows.Forms.Button();
            this.ExecutePreset3 = new System.Windows.Forms.Button();
            this.ExecutePreset2 = new System.Windows.Forms.Button();
            this.ExecutePreset1 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.SeePresetInfo = new System.Windows.Forms.Button();
            this.SetPreset3 = new System.Windows.Forms.Button();
            this.SetPreset2 = new System.Windows.Forms.Button();
            this.SetPreset1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SetPreset5 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.HelpButton = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(434, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Browse...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Model folder:";
            // 
            // textBoxOrigin
            // 
            this.textBoxOrigin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxOrigin.Location = new System.Drawing.Point(116, 17);
            this.textBoxOrigin.Name = "textBoxOrigin";
            this.textBoxOrigin.Size = new System.Drawing.Size(314, 20);
            this.textBoxOrigin.TabIndex = 2;
            this.textBoxOrigin.TextChanged += new System.EventHandler(this.textBoxOrigin_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Copy settings:";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(434, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxDestination
            // 
            this.textBoxDestination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDestination.Location = new System.Drawing.Point(116, 136);
            this.textBoxDestination.Name = "textBoxDestination";
            this.textBoxDestination.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxDestination.Size = new System.Drawing.Size(314, 20);
            this.textBoxDestination.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Save location:";
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(434, 75);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "New...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBoxSaveName
            // 
            this.textBoxSaveName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSaveName.Location = new System.Drawing.Point(116, 165);
            this.textBoxSaveName.Name = "textBoxSaveName";
            this.textBoxSaveName.Size = new System.Drawing.Size(314, 20);
            this.textBoxSaveName.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Save name:";
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(434, 133);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Browse...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button5.Location = new System.Drawing.Point(334, 204);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(196, 72);
            this.button5.TabIndex = 13;
            this.button5.Text = "Make a copy";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // listBoxSettings
            // 
            this.listBoxSettings.FormattingEnabled = true;
            this.listBoxSettings.Location = new System.Drawing.Point(116, 46);
            this.listBoxSettings.Name = "listBoxSettings";
            this.listBoxSettings.Size = new System.Drawing.Size(314, 82);
            this.listBoxSettings.TabIndex = 14;
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Location = new System.Drawing.Point(434, 104);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(96, 23);
            this.button6.TabIndex = 15;
            this.button6.Text = "Delete";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Location = new System.Drawing.Point(434, 162);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(96, 23);
            this.button7.TabIndex = 16;
            this.button7.Text = "Refresh name";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button8.Location = new System.Drawing.Point(224, 204);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(104, 46);
            this.button8.TabIndex = 17;
            this.button8.Text = "Add to auto copy...";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // closeModelDownsizer
            // 
            this.closeModelDownsizer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.closeModelDownsizer.Location = new System.Drawing.Point(446, 443);
            this.closeModelDownsizer.Name = "closeModelDownsizer";
            this.closeModelDownsizer.Size = new System.Drawing.Size(96, 26);
            this.closeModelDownsizer.TabIndex = 19;
            this.closeModelDownsizer.Text = "Close";
            this.closeModelDownsizer.UseVisualStyleBackColor = true;
            this.closeModelDownsizer.Click += new System.EventHandler(this.closeModelDownsizer_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ExecutePreset5);
            this.groupBox2.Controls.Add(this.ExecutePreset4);
            this.groupBox2.Controls.Add(this.ExecutePreset3);
            this.groupBox2.Controls.Add(this.ExecutePreset2);
            this.groupBox2.Controls.Add(this.ExecutePreset1);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(537, 112);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preset tasks";
            // 
            // ExecutePreset5
            // 
            this.ExecutePreset5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ExecutePreset5.Location = new System.Drawing.Point(434, 21);
            this.ExecutePreset5.Name = "ExecutePreset5";
            this.ExecutePreset5.Size = new System.Drawing.Size(96, 79);
            this.ExecutePreset5.TabIndex = 24;
            this.ExecutePreset5.Text = "[5]";
            this.ExecutePreset5.UseVisualStyleBackColor = true;
            this.ExecutePreset5.Click += new System.EventHandler(this.ExecutePreset5_Click);
            // 
            // ExecutePreset4
            // 
            this.ExecutePreset4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ExecutePreset4.Location = new System.Drawing.Point(332, 21);
            this.ExecutePreset4.Name = "ExecutePreset4";
            this.ExecutePreset4.Size = new System.Drawing.Size(96, 79);
            this.ExecutePreset4.TabIndex = 23;
            this.ExecutePreset4.Text = "[4]";
            this.ExecutePreset4.UseVisualStyleBackColor = true;
            this.ExecutePreset4.Click += new System.EventHandler(this.ExecutePreset4_Click);
            // 
            // ExecutePreset3
            // 
            this.ExecutePreset3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ExecutePreset3.Location = new System.Drawing.Point(224, 21);
            this.ExecutePreset3.Name = "ExecutePreset3";
            this.ExecutePreset3.Size = new System.Drawing.Size(102, 79);
            this.ExecutePreset3.TabIndex = 4;
            this.ExecutePreset3.Text = "[3]";
            this.ExecutePreset3.UseVisualStyleBackColor = true;
            this.ExecutePreset3.Click += new System.EventHandler(this.ExecutePreset3_Click);
            // 
            // ExecutePreset2
            // 
            this.ExecutePreset2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ExecutePreset2.Location = new System.Drawing.Point(116, 21);
            this.ExecutePreset2.Name = "ExecutePreset2";
            this.ExecutePreset2.Size = new System.Drawing.Size(102, 79);
            this.ExecutePreset2.TabIndex = 2;
            this.ExecutePreset2.Text = "[2]";
            this.ExecutePreset2.UseVisualStyleBackColor = true;
            this.ExecutePreset2.Click += new System.EventHandler(this.ExecutePreset2_Click);
            // 
            // ExecutePreset1
            // 
            this.ExecutePreset1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ExecutePreset1.Location = new System.Drawing.Point(9, 21);
            this.ExecutePreset1.Name = "ExecutePreset1";
            this.ExecutePreset1.Size = new System.Drawing.Size(101, 79);
            this.ExecutePreset1.TabIndex = 0;
            this.ExecutePreset1.Text = "[1]";
            this.ExecutePreset1.UseVisualStyleBackColor = true;
            this.ExecutePreset1.Click += new System.EventHandler(this.ExecutePreset1_Click);
            // 
            // button10
            // 
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button10.Location = new System.Drawing.Point(116, 230);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(102, 20);
            this.button10.TabIndex = 24;
            this.button10.Text = "Set to preset 4";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // SeePresetInfo
            // 
            this.SeePresetInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SeePresetInfo.Location = new System.Drawing.Point(116, 256);
            this.SeePresetInfo.Name = "SeePresetInfo";
            this.SeePresetInfo.Size = new System.Drawing.Size(102, 20);
            this.SeePresetInfo.TabIndex = 22;
            this.SeePresetInfo.Text = "Preset info...";
            this.SeePresetInfo.UseVisualStyleBackColor = true;
            this.SeePresetInfo.Click += new System.EventHandler(this.SeePresetInfo_Click);
            // 
            // SetPreset3
            // 
            this.SetPreset3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SetPreset3.Location = new System.Drawing.Point(9, 230);
            this.SetPreset3.Name = "SetPreset3";
            this.SetPreset3.Size = new System.Drawing.Size(101, 20);
            this.SetPreset3.TabIndex = 5;
            this.SetPreset3.Text = "Set to preset 3";
            this.SetPreset3.UseVisualStyleBackColor = true;
            this.SetPreset3.Click += new System.EventHandler(this.SetPreset3_Click);
            // 
            // SetPreset2
            // 
            this.SetPreset2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SetPreset2.Location = new System.Drawing.Point(116, 204);
            this.SetPreset2.Name = "SetPreset2";
            this.SetPreset2.Size = new System.Drawing.Size(102, 20);
            this.SetPreset2.TabIndex = 3;
            this.SetPreset2.Text = "Set to preset 2";
            this.SetPreset2.UseVisualStyleBackColor = true;
            this.SetPreset2.Click += new System.EventHandler(this.SetPreset2_Click);
            // 
            // SetPreset1
            // 
            this.SetPreset1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SetPreset1.Location = new System.Drawing.Point(9, 204);
            this.SetPreset1.Name = "SetPreset1";
            this.SetPreset1.Size = new System.Drawing.Size(101, 20);
            this.SetPreset1.TabIndex = 1;
            this.SetPreset1.Text = "Set to preset 1";
            this.SetPreset1.UseVisualStyleBackColor = true;
            this.SetPreset1.Click += new System.EventHandler(this.SetPreset1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.SetPreset5);
            this.groupBox3.Controls.Add(this.SeePresetInfo);
            this.groupBox3.Controls.Add(this.listBoxSettings);
            this.groupBox3.Controls.Add(this.button9);
            this.groupBox3.Controls.Add(this.button10);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button8);
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.SetPreset3);
            this.groupBox3.Controls.Add(this.SetPreset1);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.SetPreset2);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.textBoxDestination);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.textBoxSaveName);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textBoxOrigin);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(12, 139);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(537, 285);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Create task";
            // 
            // SetPreset5
            // 
            this.SetPreset5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SetPreset5.Location = new System.Drawing.Point(9, 256);
            this.SetPreset5.Name = "SetPreset5";
            this.SetPreset5.Size = new System.Drawing.Size(101, 20);
            this.SetPreset5.TabIndex = 25;
            this.SetPreset5.Text = "Set to preset 5";
            this.SetPreset5.UseVisualStyleBackColor = true;
            this.SetPreset5.Click += new System.EventHandler(this.SetPreset5_Click);
            // 
            // button9
            // 
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button9.Location = new System.Drawing.Point(224, 256);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(104, 20);
            this.button9.TabIndex = 18;
            this.button9.Text = "Auto copy list...";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // HelpButton
            // 
            this.HelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.HelpButton.Location = new System.Drawing.Point(346, 443);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(96, 26);
            this.HelpButton.TabIndex = 23;
            this.HelpButton.Text = "Help";
            this.HelpButton.UseVisualStyleBackColor = true;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 481);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.closeModelDownsizer);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "mainForm";
            this.Text = "Model Downsizer";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBoxSaveName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserOrigin;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        public System.Windows.Forms.TextBox textBoxOrigin;
        public System.Windows.Forms.TextBox textBoxDestination;
        public System.Windows.Forms.ListBox listBoxSettings;
        private System.Windows.Forms.Button closeModelDownsizer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button SetPreset1;
        private System.Windows.Forms.Button ExecutePreset1;
        private System.Windows.Forms.Button SetPreset3;
        private System.Windows.Forms.Button ExecutePreset3;
        private System.Windows.Forms.Button SetPreset2;
        private System.Windows.Forms.Button ExecutePreset2;
        private System.Windows.Forms.Button SeePresetInfo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button ExecutePreset4;
        private System.Windows.Forms.Button HelpButton;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button ExecutePreset5;
        private System.Windows.Forms.Button SetPreset5;
    }
}

