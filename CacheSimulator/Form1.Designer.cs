namespace CacheSimulator
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.memSizeText = new System.Windows.Forms.TextBox();
            this.speedText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.wordCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lineLenText1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.setText1 = new System.Windows.Forms.TextBox();
            this.lineSize1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.radio3 = new System.Windows.Forms.RadioButton();
            this.radio2 = new System.Windows.Forms.RadioButton();
            this.radio1 = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.speedText1 = new System.Windows.Forms.TextBox();
            this.sizeText1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.instructionText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.logText = new System.Windows.Forms.TextBox();
            this.locTrack = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.locLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.viewPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.locTrack)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // memSizeText
            // 
            this.memSizeText.Location = new System.Drawing.Point(49, 19);
            this.memSizeText.Name = "memSizeText";
            this.memSizeText.Size = new System.Drawing.Size(100, 21);
            this.memSizeText.TabIndex = 0;
            this.memSizeText.Text = "1024";
            // 
            // speedText
            // 
            this.speedText.Location = new System.Drawing.Point(49, 46);
            this.speedText.Name = "speedText";
            this.speedText.Size = new System.Drawing.Size(100, 21);
            this.speedText.TabIndex = 1;
            this.speedText.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Memory";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.wordCombo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.speedText);
            this.panel1.Controls.Add(this.memSizeText);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 73);
            this.panel1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(156, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Word";
            // 
            // wordCombo
            // 
            this.wordCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wordCombo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.wordCombo.FormattingEnabled = true;
            this.wordCombo.Items.AddRange(new object[] {
            "32bit",
            "64bit"});
            this.wordCombo.Location = new System.Drawing.Point(259, 19);
            this.wordCombo.Name = "wordCombo";
            this.wordCombo.Size = new System.Drawing.Size(60, 20);
            this.wordCombo.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Speed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Size";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lineLenText1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.setText1);
            this.panel2.Controls.Add(this.lineSize1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.radio3);
            this.panel2.Controls.Add(this.radio2);
            this.panel2.Controls.Add(this.radio1);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.speedText1);
            this.panel2.Controls.Add(this.sizeText1);
            this.panel2.Location = new System.Drawing.Point(12, 91);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(322, 102);
            this.panel2.TabIndex = 4;
            // 
            // lineLenText1
            // 
            this.lineLenText1.Location = new System.Drawing.Point(219, 18);
            this.lineLenText1.Name = "lineLenText1";
            this.lineLenText1.Size = new System.Drawing.Size(100, 21);
            this.lineLenText1.TabIndex = 14;
            this.lineLenText1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(155, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "Line Len";
            // 
            // setText1
            // 
            this.setText1.Location = new System.Drawing.Point(247, 72);
            this.setText1.Name = "setText1";
            this.setText1.ReadOnly = true;
            this.setText1.Size = new System.Drawing.Size(72, 21);
            this.setText1.TabIndex = 12;
            this.setText1.TabStop = false;
            // 
            // lineSize1
            // 
            this.lineSize1.Location = new System.Drawing.Point(219, 45);
            this.lineSize1.Name = "lineSize1";
            this.lineSize1.Size = new System.Drawing.Size(100, 21);
            this.lineSize1.TabIndex = 11;
            this.lineSize1.Text = "64";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(155, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "Line Size";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "Speed";
            // 
            // radio3
            // 
            this.radio3.AutoSize = true;
            this.radio3.Location = new System.Drawing.Point(163, 77);
            this.radio3.Name = "radio3";
            this.radio3.Size = new System.Drawing.Size(78, 16);
            this.radio3.TabIndex = 6;
            this.radio3.Text = "Set-Asctv";
            this.radio3.UseVisualStyleBackColor = true;
            this.radio3.CheckedChanged += new System.EventHandler(this.radio3_CheckedChanged);
            // 
            // radio2
            // 
            this.radio2.AutoSize = true;
            this.radio2.Location = new System.Drawing.Point(68, 77);
            this.radio2.Name = "radio2";
            this.radio2.Size = new System.Drawing.Size(88, 16);
            this.radio2.TabIndex = 5;
            this.radio2.Text = "Associative";
            this.radio2.UseVisualStyleBackColor = true;
            // 
            // radio1
            // 
            this.radio1.AutoSize = true;
            this.radio1.Checked = true;
            this.radio1.Location = new System.Drawing.Point(7, 77);
            this.radio1.Name = "radio1";
            this.radio1.Size = new System.Drawing.Size(55, 16);
            this.radio1.TabIndex = 4;
            this.radio1.TabStop = true;
            this.radio1.Text = "Direct";
            this.radio1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "Size";
            // 
            // speedText1
            // 
            this.speedText1.Location = new System.Drawing.Point(49, 46);
            this.speedText1.Name = "speedText1";
            this.speedText1.Size = new System.Drawing.Size(100, 21);
            this.speedText1.TabIndex = 1;
            this.speedText1.Text = "1";
            // 
            // sizeText1
            // 
            this.sizeText1.Location = new System.Drawing.Point(49, 19);
            this.sizeText1.Name = "sizeText1";
            this.sizeText1.Size = new System.Drawing.Size(100, 21);
            this.sizeText1.TabIndex = 0;
            this.sizeText1.Text = "1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "Cache 0";
            // 
            // instructionText
            // 
            this.instructionText.Location = new System.Drawing.Point(440, 9);
            this.instructionText.Name = "instructionText";
            this.instructionText.Size = new System.Drawing.Size(100, 21);
            this.instructionText.TabIndex = 5;
            this.instructionText.Text = "1000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(340, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "Instructions";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(465, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // logText
            // 
            this.logText.BackColor = System.Drawing.SystemColors.Window;
            this.logText.Location = new System.Drawing.Point(342, 59);
            this.logText.Multiline = true;
            this.logText.Name = "logText";
            this.logText.ReadOnly = true;
            this.logText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logText.Size = new System.Drawing.Size(200, 133);
            this.logText.TabIndex = 7;
            // 
            // locTrack
            // 
            this.locTrack.Location = new System.Drawing.Point(436, 36);
            this.locTrack.Name = "locTrack";
            this.locTrack.Size = new System.Drawing.Size(104, 45);
            this.locTrack.TabIndex = 6;
            this.locTrack.Value = 8;
            this.locTrack.Scroll += new System.EventHandler(this.locTrack_Scroll);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(340, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 12);
            this.label11.TabIndex = 10;
            this.label11.Text = "Locality";
            // 
            // locLabel
            // 
            this.locLabel.AutoSize = true;
            this.locLabel.Location = new System.Drawing.Point(409, 40);
            this.locLabel.Name = "locLabel";
            this.locLabel.Size = new System.Drawing.Size(21, 12);
            this.locLabel.TabIndex = 11;
            this.locLabel.Text = "0.8";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label14.Location = new System.Drawing.Point(543, 101);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(13, 12);
            this.label14.TabIndex = 14;
            this.label14.Text = ">";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // viewPanel
            // 
            this.viewPanel.Location = new System.Drawing.Point(559, 8);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Size = new System.Drawing.Size(124, 212);
            this.viewPanel.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(384, 198);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.정보ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // 정보ToolStripMenuItem
            // 
            this.정보ToolStripMenuItem.Name = "정보ToolStripMenuItem";
            this.정보ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.정보ToolStripMenuItem.Text = "정보";
            this.정보ToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(555, 232);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.viewPanel);
            this.Controls.Add(this.locLabel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.logText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.instructionText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.locTrack);
            this.Controls.Add(this.label14);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Cache Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.locTrack)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox memSizeText;
        private System.Windows.Forms.TextBox speedText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox wordCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox setText1;
        private System.Windows.Forms.TextBox lineSize1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radio3;
        private System.Windows.Forms.RadioButton radio2;
        private System.Windows.Forms.RadioButton radio1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox speedText1;
        private System.Windows.Forms.TextBox sizeText1;
        private System.Windows.Forms.TextBox instructionText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox logText;
        private System.Windows.Forms.TextBox lineLenText1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar locTrack;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label locLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel viewPanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 정보ToolStripMenuItem;
    }
}

