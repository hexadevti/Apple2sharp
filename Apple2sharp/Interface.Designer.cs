﻿using System.Drawing;
using System.Windows.Forms;

namespace Apple2
{



    partial class Interface
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interface));
            pictureBox1 = new PictureBox();
            disk1 = new TextBox();
            lbldisk1 = new Label();
            D1S = new Label();
            D1T = new Label();
            openFileDialog1 = new OpenFileDialog();
            btn_restart = new Button();
            richTextBox1 = new RichTextBox();
            btn1Mhz = new Button();
            openFileDialog2 = new OpenFileDialog();
            lblClockSpeed = new Label();
            richTextBox2 = new RichTextBox();
            tbSpeed = new TrackBar();
            cbslot0 = new ComboBox();
            drivePanel1 = new Panel();
            D1ON = new PictureBox();
            D1OFF = new PictureBox();
            panel1 = new Panel();
            D2ON = new PictureBox();
            D2OFF = new PictureBox();
            label1 = new Label();
            D2S = new Label();
            disk2 = new TextBox();
            D2T = new Label();
            panel2 = new Panel();
            cbslot1 = new ComboBox();
            cbslot2 = new ComboBox();
            cbslot3 = new ComboBox();
            cbslot4 = new ComboBox();
            cbslot5 = new ComboBox();
            cbslot6 = new ComboBox();
            cbslot7 = new ComboBox();
            btnTurbo = new Button();
            btnColor = new Button();
            btnScanLines = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbSpeed).BeginInit();
            drivePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)D1ON).BeginInit();
            ((System.ComponentModel.ISupportInitialize)D1OFF).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)D2ON).BeginInit();
            ((System.ComponentModel.ISupportInitialize)D2OFF).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Black;
            pictureBox1.Location = new Point(11, 11);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(803, 642);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // disk1
            // 
            disk1.BackColor = SystemColors.ActiveCaptionText;
            disk1.BorderStyle = BorderStyle.None;
            disk1.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            disk1.ForeColor = SystemColors.ControlLightLight;
            disk1.Location = new Point(12, 65);
            disk1.Margin = new Padding(0);
            disk1.Name = "disk1";
            disk1.Size = new Size(250, 19);
            disk1.TabIndex = 1;
            disk1.TextAlign = HorizontalAlignment.Center;
            disk1.Click += disk1_TextChanged;
            // 
            // lbldisk1
            // 
            lbldisk1.AutoSize = true;
            lbldisk1.Font = new Font("Lucida Sans Unicode", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbldisk1.ForeColor = SystemColors.ControlLightLight;
            lbldisk1.Location = new Point(28, 8);
            lbldisk1.Name = "lbldisk1";
            lbldisk1.Size = new Size(33, 34);
            lbldisk1.TabIndex = 6;
            lbldisk1.Text = "1";
            // 
            // D1S
            // 
            D1S.AutoSize = true;
            D1S.BackColor = Color.Transparent;
            D1S.Font = new Font("Lucida Sans Unicode", 9F);
            D1S.ForeColor = SystemColors.ControlLightLight;
            D1S.Location = new Point(229, 26);
            D1S.Name = "D1S";
            D1S.Size = new Size(26, 16);
            D1S.TabIndex = 4;
            D1S.Text = "S: ?";
            // 
            // D1T
            // 
            D1T.AutoSize = true;
            D1T.BackColor = Color.Transparent;
            D1T.Font = new Font("Lucida Sans Unicode", 9F);
            D1T.ForeColor = SystemColors.ControlLightLight;
            D1T.Location = new Point(190, 26);
            D1T.Name = "D1T";
            D1T.Size = new Size(28, 16);
            D1T.TabIndex = 3;
            D1T.Text = "T: ?";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_restart
            // 
            btn_restart.BackColor = Color.Salmon;
            btn_restart.Location = new Point(819, 12);
            btn_restart.Name = "btn_restart";
            btn_restart.Size = new Size(163, 33);
            btn_restart.TabIndex = 5;
            btn_restart.Text = "Power";
            btn_restart.UseVisualStyleBackColor = false;
            btn_restart.Click += btn_restart_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(0, 0);
            richTextBox1.Margin = new Padding(0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1, 2);
            richTextBox1.TabIndex = 7;
            richTextBox1.Text = "";
            // 
            // btn1Mhz
            // 
            btn1Mhz.BackColor = Color.Salmon;
            btn1Mhz.Location = new Point(819, 50);
            btn1Mhz.Margin = new Padding(2);
            btn1Mhz.Name = "btn1Mhz";
            btn1Mhz.Size = new Size(163, 33);
            btn1Mhz.TabIndex = 13;
            btn1Mhz.Text = "1Mhz";
            btn1Mhz.UseVisualStyleBackColor = false;
            btn1Mhz.Click += btnClockAdjust_Click;
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog1";
            // 
            // lblClockSpeed
            // 
            lblClockSpeed.AutoSize = true;
            lblClockSpeed.BackColor = SystemColors.ActiveCaptionText;
            lblClockSpeed.Font = new Font("Lucida Sans Unicode", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblClockSpeed.ForeColor = SystemColors.ControlLightLight;
            lblClockSpeed.Location = new Point(185, 11);
            lblClockSpeed.Name = "lblClockSpeed";
            lblClockSpeed.Size = new Size(47, 17);
            lblClockSpeed.TabIndex = 14;
            lblClockSpeed.Text = "? Mhz";
            lblClockSpeed.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // richTextBox2
            // 
            richTextBox2.BackColor = Color.Black;
            richTextBox2.Font = new Font("Consolas", 8F);
            richTextBox2.ForeColor = Color.White;
            richTextBox2.Location = new Point(563, 657);
            richTextBox2.Margin = new Padding(2);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(691, 158);
            richTextBox2.TabIndex = 15;
            richTextBox2.Text = "";
            // 
            // tbSpeed
            // 
            tbSpeed.BackColor = SystemColors.ControlText;
            tbSpeed.Location = new Point(3, 0);
            tbSpeed.Name = "tbSpeed";
            tbSpeed.Size = new Size(167, 45);
            tbSpeed.TabIndex = 16;
            tbSpeed.Value = 1;
            // 
            // cbslot0
            // 
            cbslot0.BackColor = Color.FromArgb(90, 64, 70);
            cbslot0.FlatStyle = FlatStyle.Flat;
            cbslot0.Font = new Font("Lucida Sans Unicode", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbslot0.ForeColor = SystemColors.ControlLightLight;
            cbslot0.FormattingEnabled = true;
            cbslot0.IntegralHeight = false;
            cbslot0.Location = new Point(995, 93);
            cbslot0.Margin = new Padding(0);
            cbslot0.Name = "cbslot0";
            cbslot0.Size = new Size(259, 36);
            cbslot0.TabIndex = 20;
            // 
            // drivePanel1
            // 
            drivePanel1.BackColor = Color.Transparent;
            drivePanel1.BackgroundImage = (Image)resources.GetObject("drivePanel1.BackgroundImage");
            drivePanel1.BackgroundImageLayout = ImageLayout.Zoom;
            drivePanel1.Controls.Add(D1ON);
            drivePanel1.Controls.Add(D1OFF);
            drivePanel1.Controls.Add(lbldisk1);
            drivePanel1.Controls.Add(D1S);
            drivePanel1.Controls.Add(disk1);
            drivePanel1.Controls.Add(D1T);
            drivePanel1.Location = new Point(11, 655);
            drivePanel1.Margin = new Padding(0);
            drivePanel1.Name = "drivePanel1";
            drivePanel1.Size = new Size(275, 169);
            drivePanel1.TabIndex = 35;
            // 
            // D1ON
            // 
            D1ON.BackgroundImage = (Image)resources.GetObject("D1ON.BackgroundImage");
            D1ON.BackgroundImageLayout = ImageLayout.Zoom;
            D1ON.Location = new Point(43, 104);
            D1ON.Name = "D1ON";
            D1ON.Size = new Size(30, 30);
            D1ON.TabIndex = 8;
            D1ON.TabStop = false;
            // 
            // D1OFF
            // 
            D1OFF.BackgroundImage = (Image)resources.GetObject("D1OFF.BackgroundImage");
            D1OFF.BackgroundImageLayout = ImageLayout.Zoom;
            D1OFF.Location = new Point(43, 104);
            D1OFF.Name = "D1OFF";
            D1OFF.Size = new Size(30, 30);
            D1OFF.TabIndex = 7;
            D1OFF.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Zoom;
            panel1.Controls.Add(D2ON);
            panel1.Controls.Add(D2OFF);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(D2S);
            panel1.Controls.Add(disk2);
            panel1.Controls.Add(D2T);
            panel1.Location = new Point(286, 655);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(275, 169);
            panel1.TabIndex = 36;
            // 
            // D2ON
            // 
            D2ON.BackgroundImage = (Image)resources.GetObject("D2ON.BackgroundImage");
            D2ON.BackgroundImageLayout = ImageLayout.Zoom;
            D2ON.Location = new Point(43, 104);
            D2ON.Name = "D2ON";
            D2ON.Size = new Size(30, 30);
            D2ON.TabIndex = 8;
            D2ON.TabStop = false;
            // 
            // D2OFF
            // 
            D2OFF.BackgroundImage = (Image)resources.GetObject("D2OFF.BackgroundImage");
            D2OFF.BackgroundImageLayout = ImageLayout.Zoom;
            D2OFF.Location = new Point(43, 104);
            D2OFF.Name = "D2OFF";
            D2OFF.Size = new Size(30, 30);
            D2OFF.TabIndex = 7;
            D2OFF.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lucida Sans Unicode", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(28, 8);
            label1.Name = "label1";
            label1.Size = new Size(33, 34);
            label1.TabIndex = 6;
            label1.Text = "2";
            // 
            // D2S
            // 
            D2S.AutoSize = true;
            D2S.BackColor = Color.Transparent;
            D2S.Font = new Font("Lucida Sans Unicode", 9F);
            D2S.ForeColor = SystemColors.ControlLightLight;
            D2S.Location = new Point(229, 26);
            D2S.Name = "D2S";
            D2S.Size = new Size(26, 16);
            D2S.TabIndex = 4;
            D2S.Text = "S: ?";
            // 
            // disk2
            // 
            disk2.BackColor = SystemColors.ActiveCaptionText;
            disk2.BorderStyle = BorderStyle.None;
            disk2.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            disk2.ForeColor = SystemColors.ControlLightLight;
            disk2.Location = new Point(12, 65);
            disk2.Margin = new Padding(0);
            disk2.Name = "disk2";
            disk2.Size = new Size(250, 19);
            disk2.TabIndex = 1;
            disk2.TextAlign = HorizontalAlignment.Center;
            disk2.Click += disk2_TextChanged;
            // 
            // D2T
            // 
            D2T.AutoSize = true;
            D2T.BackColor = Color.Transparent;
            D2T.Font = new Font("Lucida Sans Unicode", 9F);
            D2T.ForeColor = SystemColors.ControlLightLight;
            D2T.Location = new Point(190, 26);
            D2T.Name = "D2T";
            D2T.Size = new Size(28, 16);
            D2T.TabIndex = 3;
            D2T.Text = "T: ?";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaptionText;
            panel2.Controls.Add(tbSpeed);
            panel2.Controls.Add(lblClockSpeed);
            panel2.Location = new Point(995, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(258, 42);
            panel2.TabIndex = 37;
            // 
            // cbslot1
            // 
            cbslot1.BackColor = Color.FromArgb(90, 64, 70);
            cbslot1.FlatStyle = FlatStyle.Flat;
            cbslot1.Font = new Font("Lucida Sans Unicode", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbslot1.ForeColor = SystemColors.ControlLightLight;
            cbslot1.FormattingEnabled = true;
            cbslot1.IntegralHeight = false;
            cbslot1.Location = new Point(995, 169);
            cbslot1.Margin = new Padding(0);
            cbslot1.Name = "cbslot1";
            cbslot1.Size = new Size(259, 36);
            cbslot1.TabIndex = 38;
            // 
            // cbslot2
            // 
            cbslot2.BackColor = Color.FromArgb(90, 64, 70);
            cbslot2.FlatStyle = FlatStyle.Flat;
            cbslot2.Font = new Font("Lucida Sans Unicode", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbslot2.ForeColor = SystemColors.ControlLightLight;
            cbslot2.FormattingEnabled = true;
            cbslot2.IntegralHeight = false;
            cbslot2.Location = new Point(995, 242);
            cbslot2.Margin = new Padding(0);
            cbslot2.Name = "cbslot2";
            cbslot2.Size = new Size(259, 36);
            cbslot2.TabIndex = 39;
            // 
            // cbslot3
            // 
            cbslot3.BackColor = Color.FromArgb(90, 64, 70);
            cbslot3.FlatStyle = FlatStyle.Flat;
            cbslot3.Font = new Font("Lucida Sans Unicode", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbslot3.ForeColor = SystemColors.ControlLightLight;
            cbslot3.FormattingEnabled = true;
            cbslot3.IntegralHeight = false;
            cbslot3.Location = new Point(995, 315);
            cbslot3.Margin = new Padding(0);
            cbslot3.Name = "cbslot3";
            cbslot3.Size = new Size(259, 36);
            cbslot3.TabIndex = 40;
            // 
            // cbslot4
            // 
            cbslot4.BackColor = Color.FromArgb(90, 64, 70);
            cbslot4.FlatStyle = FlatStyle.Flat;
            cbslot4.Font = new Font("Lucida Sans Unicode", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbslot4.ForeColor = SystemColors.ControlLightLight;
            cbslot4.FormattingEnabled = true;
            cbslot4.IntegralHeight = false;
            cbslot4.Location = new Point(995, 388);
            cbslot4.Margin = new Padding(0);
            cbslot4.Name = "cbslot4";
            cbslot4.Size = new Size(259, 36);
            cbslot4.TabIndex = 41;
            // 
            // cbslot5
            // 
            cbslot5.BackColor = Color.FromArgb(90, 64, 70);
            cbslot5.FlatStyle = FlatStyle.Flat;
            cbslot5.Font = new Font("Lucida Sans Unicode", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbslot5.ForeColor = SystemColors.ControlLightLight;
            cbslot5.FormattingEnabled = true;
            cbslot5.IntegralHeight = false;
            cbslot5.Location = new Point(995, 463);
            cbslot5.Margin = new Padding(0);
            cbslot5.Name = "cbslot5";
            cbslot5.Size = new Size(259, 36);
            cbslot5.TabIndex = 42;
            // 
            // cbslot6
            // 
            cbslot6.BackColor = Color.FromArgb(90, 64, 70);
            cbslot6.FlatStyle = FlatStyle.Flat;
            cbslot6.Font = new Font("Lucida Sans Unicode", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbslot6.ForeColor = SystemColors.ControlLightLight;
            cbslot6.FormattingEnabled = true;
            cbslot6.IntegralHeight = false;
            cbslot6.Location = new Point(995, 536);
            cbslot6.Margin = new Padding(0);
            cbslot6.Name = "cbslot6";
            cbslot6.Size = new Size(259, 36);
            cbslot6.TabIndex = 43;
            // 
            // cbslot7
            // 
            cbslot7.BackColor = Color.FromArgb(90, 64, 70);
            cbslot7.FlatStyle = FlatStyle.Flat;
            cbslot7.Font = new Font("Lucida Sans Unicode", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbslot7.ForeColor = SystemColors.ControlLightLight;
            cbslot7.FormattingEnabled = true;
            cbslot7.IntegralHeight = false;
            cbslot7.Location = new Point(995, 608);
            cbslot7.Margin = new Padding(0);
            cbslot7.Name = "cbslot7";
            cbslot7.Size = new Size(259, 36);
            cbslot7.TabIndex = 44;
            // 
            // btnTurbo
            // 
            btnTurbo.Location = new Point(819, 87);
            btnTurbo.Margin = new Padding(2);
            btnTurbo.Name = "btnTurbo";
            btnTurbo.Size = new Size(163, 33);
            btnTurbo.TabIndex = 45;
            btnTurbo.Text = "Turbo";
            btnTurbo.UseVisualStyleBackColor = true;
            btnTurbo.Click += btnTurbo_Click;
            // 
            // btnColor
            // 
            btnColor.BackColor = Color.Salmon;
            btnColor.Location = new Point(819, 125);
            btnColor.Margin = new Padding(2);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(163, 33);
            btnColor.TabIndex = 46;
            btnColor.Text = "Color";
            btnColor.UseVisualStyleBackColor = false;
            btnColor.Click += btnColor_Click;
            // 
            // btnScanLines
            // 
            btnScanLines.BackColor = Color.Salmon;
            btnScanLines.Location = new Point(819, 162);
            btnScanLines.Margin = new Padding(2);
            btnScanLines.Name = "btnScanLines";
            btnScanLines.Size = new Size(163, 33);
            btnScanLines.TabIndex = 47;
            btnScanLines.Text = "Scan Lines";
            btnScanLines.UseVisualStyleBackColor = false;
            btnScanLines.Click += btnScanLines_Click;
            // 
            // Interface
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1283, 819);
            Controls.Add(btnScanLines);
            Controls.Add(btnColor);
            Controls.Add(btnTurbo);
            Controls.Add(cbslot7);
            Controls.Add(cbslot6);
            Controls.Add(cbslot5);
            Controls.Add(cbslot4);
            Controls.Add(cbslot3);
            Controls.Add(cbslot2);
            Controls.Add(cbslot1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(drivePanel1);
            Controls.Add(richTextBox2);
            Controls.Add(btn1Mhz);
            Controls.Add(richTextBox1);
            Controls.Add(btn_restart);
            Controls.Add(pictureBox1);
            Controls.Add(cbslot0);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "Interface";
            Text = "Apple II+";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbSpeed).EndInit();
            drivePanel1.ResumeLayout(false);
            drivePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)D1ON).EndInit();
            ((System.ComponentModel.ISupportInitialize)D1OFF).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)D2ON).EndInit();
            ((System.ComponentModel.ISupportInitialize)D2OFF).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox disk1;
        private OpenFileDialog openFileDialog1;
        private Button btn_restart;
        private RichTextBox richTextBox1;
        private Button btn1Mhz;
        private OpenFileDialog openFileDialog2;
        private Label lblClockSpeed;
        private RichTextBox richTextBox2;
        private Label D1S;
        private Label D1T;
        private TrackBar tbSpeed;
        private ComboBox cbslot0;
        private Label lbldisk1;
        private Panel drivePanel1;
        private PictureBox D1ON;
        private PictureBox D1OFF;
        private Panel panel1;
        private PictureBox D2ON;
        private PictureBox D2OFF;
        private Label label1;
        private Label D2S;
        private TextBox disk2;
        private Label D2T;
        private Panel panel2;
        private ComboBox cbslot1;
        private ComboBox cbslot2;
        private ComboBox cbslot3;
        private ComboBox cbslot4;
        private ComboBox cbslot5;
        private ComboBox cbslot6;
        private ComboBox cbslot7;
        private Button btnTurbo;
        private Button btnColor;
        private Button btnScanLines;
    }
}