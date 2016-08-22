using FaceMaker.Data;
using FaceMaker.Properties;
using RC.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FaceMaker.UI
{
    public partial class MainForm : Form
	{
		private IContainer components;

		private PictureBox picImage;

		private GroupBox grpParts;

		private Label lblTotalPartsCount;

		private Label lblThrash;

		private Label lblCurrentPartsNo;

		private ComboBox cmbParts;

		private Button btnIncriment;

		private Button btnDecriment;

		private GroupBox grpLocation;

		private Button btnRight;

		private Button btnLeft;

		private Button btnClockwise;

		private Button btnCounterclockwise;

		private Button btnDown;

		private Button btnCenter;

		private Button btnUp;

		private GroupBox grpColor;

		private TrackBar tbContrast;

		private TextBox txtContrast;

		private TextBox txtBrightness;

		private TextBox txtBlue;

		private TextBox txtGreen;

		private TextBox txtRed;

		private PictureBox picContrast;

		private PictureBox picBrightness;

		private PictureBox picBlue;

		private PictureBox picGreen;

		private PictureBox picRed;

		private TrackBar tbBrightness;

		private TrackBar tbBlue;

		private TrackBar tbGreen;

		private TrackBar tbRed;

		private Button btnRandom;

		private Button btnSave;

		private Button btnQuit;

		private Button btnSetDefault;

		private Button btnDefault;

		private SaveFileDialog sfd;

		private TextBox txtSize;

		private GroupBox grpSaveSize;

		private Label label1;

		private Label lblPixel;

		private Label label2;

		private Panel panel1;

		private RadioButton radIndivisible;

		private RadioButton radVisible;

		private CheckBox checkMirror;

		private Button btnSaveSetting;

		private SaveFileDialog sfdSaveSetting;

		private Button btnLoadSetting;

		private OpenFileDialog sfdLoadSetting;

		private Label label3;

		private ComboBox cmbColorParent;

		private GroupBox grpRelation;

		private Label label4;

		private ComboBox cmbPositionParent;

		private Button btnLoadWall;

		private OpenFileDialog sfdWallImage;

		public List<Parts> Parts;

		private int DispPartsID;

		private int DispPartsNo;

		private int DispPartsTotal;

		private int DispRed;

		private int DispGreen;

		private int DispBlue;

		private int DispBrightness;

		private int DispContrast;

		private int saveSize;

		private bool reloadImage;

		private bool changeTb;

		private bool changeTxt;

		private bool checkMirrorFlag;

		private Bitmap WallBitmap;

		private Bitmap DummyBitmap;

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.grpParts = new System.Windows.Forms.GroupBox();
            this.lblTotalPartsCount = new System.Windows.Forms.Label();
            this.lblThrash = new System.Windows.Forms.Label();
            this.lblCurrentPartsNo = new System.Windows.Forms.Label();
            this.cmbParts = new System.Windows.Forms.ComboBox();
            this.btnIncriment = new System.Windows.Forms.Button();
            this.btnDecriment = new System.Windows.Forms.Button();
            this.grpLocation = new System.Windows.Forms.GroupBox();
            this.checkMirror = new System.Windows.Forms.CheckBox();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnClockwise = new System.Windows.Forms.Button();
            this.btnCounterclockwise = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnCenter = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.grpColor = new System.Windows.Forms.GroupBox();
            this.tbContrast = new System.Windows.Forms.TrackBar();
            this.txtContrast = new System.Windows.Forms.TextBox();
            this.txtBrightness = new System.Windows.Forms.TextBox();
            this.txtBlue = new System.Windows.Forms.TextBox();
            this.txtGreen = new System.Windows.Forms.TextBox();
            this.txtRed = new System.Windows.Forms.TextBox();
            this.picContrast = new System.Windows.Forms.PictureBox();
            this.picBrightness = new System.Windows.Forms.PictureBox();
            this.picBlue = new System.Windows.Forms.PictureBox();
            this.picGreen = new System.Windows.Forms.PictureBox();
            this.picRed = new System.Windows.Forms.PictureBox();
            this.tbBrightness = new System.Windows.Forms.TrackBar();
            this.tbBlue = new System.Windows.Forms.TrackBar();
            this.tbGreen = new System.Windows.Forms.TrackBar();
            this.tbRed = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbColorParent = new System.Windows.Forms.ComboBox();
            this.btnRandom = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnSetDefault = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.grpSaveSize = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radIndivisible = new System.Windows.Forms.RadioButton();
            this.radVisible = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPixel = new System.Windows.Forms.Label();
            this.btnSaveSetting = new System.Windows.Forms.Button();
            this.sfdSaveSetting = new System.Windows.Forms.SaveFileDialog();
            this.btnLoadSetting = new System.Windows.Forms.Button();
            this.sfdLoadSetting = new System.Windows.Forms.OpenFileDialog();
            this.grpRelation = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPositionParent = new System.Windows.Forms.ComboBox();
            this.btnLoadWall = new System.Windows.Forms.Button();
            this.sfdWallImage = new System.Windows.Forms.OpenFileDialog();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.grpParts.SuspendLayout();
            this.grpLocation.SuspendLayout();
            this.grpColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRed)).BeginInit();
            this.grpSaveSize.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpRelation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // grpParts
            // 
            this.grpParts.Controls.Add(this.lblTotalPartsCount);
            this.grpParts.Controls.Add(this.lblThrash);
            this.grpParts.Controls.Add(this.lblCurrentPartsNo);
            this.grpParts.Controls.Add(this.cmbParts);
            this.grpParts.Controls.Add(this.btnIncriment);
            this.grpParts.Controls.Add(this.btnDecriment);
            this.grpParts.Location = new System.Drawing.Point(212, 13);
            this.grpParts.Name = "grpParts";
            this.grpParts.Size = new System.Drawing.Size(142, 70);
            this.grpParts.TabIndex = 0;
            this.grpParts.TabStop = false;
            this.grpParts.Text = "Parts";
            // 
            // lblTotalPartsCount
            // 
            this.lblTotalPartsCount.Location = new System.Drawing.Point(77, 40);
            this.lblTotalPartsCount.Name = "lblTotalPartsCount";
            this.lblTotalPartsCount.Size = new System.Drawing.Size(23, 25);
            this.lblTotalPartsCount.TabIndex = 9;
            this.lblTotalPartsCount.Text = "000";
            this.lblTotalPartsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblThrash
            // 
            this.lblThrash.Location = new System.Drawing.Point(71, 40);
            this.lblThrash.Name = "lblThrash";
            this.lblThrash.Size = new System.Drawing.Size(9, 25);
            this.lblThrash.TabIndex = 9;
            this.lblThrash.Text = "/";
            this.lblThrash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentPartsNo
            // 
            this.lblCurrentPartsNo.Location = new System.Drawing.Point(47, 40);
            this.lblCurrentPartsNo.Name = "lblCurrentPartsNo";
            this.lblCurrentPartsNo.Size = new System.Drawing.Size(23, 25);
            this.lblCurrentPartsNo.TabIndex = 9;
            this.lblCurrentPartsNo.Text = "000";
            this.lblCurrentPartsNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbParts
            // 
            this.cmbParts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParts.FormattingEnabled = true;
            this.cmbParts.Items.AddRange(new object[] {
            "Kontur",
            "Neck",
            "Eyes",
            "Pupil",
            "Nose",
            "Mouth",
            "Eyebrows",
            "Beard",
            "Ears",
            "Hair (front)",
            "Hair (back)",
            "Cloth",
            "Hat",
            "Accessoire 1",
            "Accessoire 2"});
            this.cmbParts.Location = new System.Drawing.Point(17, 14);
            this.cmbParts.Name = "cmbParts";
            this.cmbParts.Size = new System.Drawing.Size(109, 21);
            this.cmbParts.TabIndex = 0;
            this.cmbParts.SelectedIndexChanged += new System.EventHandler(this.cmbParts_SelectedIndexChanged);
            // 
            // btnIncriment
            // 
            this.btnIncriment.Location = new System.Drawing.Point(101, 38);
            this.btnIncriment.Name = "btnIncriment";
            this.btnIncriment.Size = new System.Drawing.Size(25, 27);
            this.btnIncriment.TabIndex = 2;
            this.btnIncriment.Text = ">>";
            this.btnIncriment.UseVisualStyleBackColor = true;
            this.btnIncriment.Click += new System.EventHandler(this.btnIncDec_Click);
            // 
            // btnDecriment
            // 
            this.btnDecriment.Location = new System.Drawing.Point(16, 38);
            this.btnDecriment.Name = "btnDecriment";
            this.btnDecriment.Size = new System.Drawing.Size(25, 27);
            this.btnDecriment.TabIndex = 1;
            this.btnDecriment.Text = "<<";
            this.btnDecriment.UseVisualStyleBackColor = true;
            this.btnDecriment.Click += new System.EventHandler(this.btnIncDec_Click);
            // 
            // grpLocation
            // 
            this.grpLocation.Controls.Add(this.checkMirror);
            this.grpLocation.Controls.Add(this.btnRight);
            this.grpLocation.Controls.Add(this.btnLeft);
            this.grpLocation.Controls.Add(this.btnClockwise);
            this.grpLocation.Controls.Add(this.btnCounterclockwise);
            this.grpLocation.Controls.Add(this.btnDown);
            this.grpLocation.Controls.Add(this.btnCenter);
            this.grpLocation.Controls.Add(this.btnUp);
            this.grpLocation.Location = new System.Drawing.Point(212, 90);
            this.grpLocation.Name = "grpLocation";
            this.grpLocation.Size = new System.Drawing.Size(142, 103);
            this.grpLocation.TabIndex = 1;
            this.grpLocation.TabStop = false;
            this.grpLocation.Text = "Position && Rotation";
            // 
            // checkMirror
            // 
            this.checkMirror.AutoSize = true;
            this.checkMirror.Location = new System.Drawing.Point(86, 79);
            this.checkMirror.Name = "checkMirror";
            this.checkMirror.Size = new System.Drawing.Size(61, 17);
            this.checkMirror.TabIndex = 8;
            this.checkMirror.Text = "reverse";
            this.checkMirror.UseVisualStyleBackColor = true;
            this.checkMirror.CheckedChanged += new System.EventHandler(this.checkMirror_CheckedChanged);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(79, 46);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(25, 27);
            this.btnRight.TabIndex = 4;
            this.btnRight.Text = "→";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnPosition_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(30, 46);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(25, 27);
            this.btnLeft.TabIndex = 3;
            this.btnLeft.Text = "←";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnPosition_Click);
            // 
            // btnClockwise
            // 
            this.btnClockwise.Location = new System.Drawing.Point(79, 20);
            this.btnClockwise.Name = "btnClockwise";
            this.btnClockwise.Size = new System.Drawing.Size(47, 27);
            this.btnClockwise.TabIndex = 6;
            this.btnClockwise.Text = "clk";
            this.btnClockwise.UseVisualStyleBackColor = true;
            this.btnClockwise.Click += new System.EventHandler(this.btnPosition_Click);
            // 
            // btnCounterclockwise
            // 
            this.btnCounterclockwise.Location = new System.Drawing.Point(17, 20);
            this.btnCounterclockwise.Name = "btnCounterclockwise";
            this.btnCounterclockwise.Size = new System.Drawing.Size(38, 27);
            this.btnCounterclockwise.TabIndex = 5;
            this.btnCounterclockwise.Text = "cclk";
            this.btnCounterclockwise.UseVisualStyleBackColor = true;
            this.btnCounterclockwise.Click += new System.EventHandler(this.btnPosition_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(55, 72);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(25, 27);
            this.btnDown.TabIndex = 2;
            this.btnDown.Text = "↓";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnPosition_Click);
            // 
            // btnCenter
            // 
            this.btnCenter.Location = new System.Drawing.Point(55, 46);
            this.btnCenter.Name = "btnCenter";
            this.btnCenter.Size = new System.Drawing.Size(25, 27);
            this.btnCenter.TabIndex = 0;
            this.btnCenter.Text = "◎";
            this.btnCenter.UseVisualStyleBackColor = true;
            this.btnCenter.Click += new System.EventHandler(this.btnPosition_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(55, 20);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(25, 27);
            this.btnUp.TabIndex = 1;
            this.btnUp.Text = "↑";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnPosition_Click);
            // 
            // grpColor
            // 
            this.grpColor.Controls.Add(this.tbContrast);
            this.grpColor.Controls.Add(this.txtContrast);
            this.grpColor.Controls.Add(this.txtBrightness);
            this.grpColor.Controls.Add(this.txtBlue);
            this.grpColor.Controls.Add(this.txtGreen);
            this.grpColor.Controls.Add(this.txtRed);
            this.grpColor.Controls.Add(this.picContrast);
            this.grpColor.Controls.Add(this.picBrightness);
            this.grpColor.Controls.Add(this.picBlue);
            this.grpColor.Controls.Add(this.picGreen);
            this.grpColor.Controls.Add(this.picRed);
            this.grpColor.Controls.Add(this.tbBrightness);
            this.grpColor.Controls.Add(this.tbBlue);
            this.grpColor.Controls.Add(this.tbGreen);
            this.grpColor.Controls.Add(this.tbRed);
            this.grpColor.Location = new System.Drawing.Point(12, 228);
            this.grpColor.Name = "grpColor";
            this.grpColor.Size = new System.Drawing.Size(342, 159);
            this.grpColor.TabIndex = 4;
            this.grpColor.TabStop = false;
            this.grpColor.Text = "Color";
            // 
            // tbContrast
            // 
            this.tbContrast.AutoSize = false;
            this.tbContrast.Location = new System.Drawing.Point(29, 126);
            this.tbContrast.Maximum = 100;
            this.tbContrast.Minimum = -100;
            this.tbContrast.Name = "tbContrast";
            this.tbContrast.Size = new System.Drawing.Size(270, 25);
            this.tbContrast.TabIndex = 4;
            this.tbContrast.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbContrast.Scroll += new System.EventHandler(this.tb_Scroll);
            // 
            // txtContrast
            // 
            this.txtContrast.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtContrast.Location = new System.Drawing.Point(296, 128);
            this.txtContrast.MaxLength = 4;
            this.txtContrast.Name = "txtContrast";
            this.txtContrast.Size = new System.Drawing.Size(35, 20);
            this.txtContrast.TabIndex = 9;
            this.txtContrast.Text = "0";
            this.txtContrast.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContrast.WordWrap = false;
            this.txtContrast.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtBrightness
            // 
            this.txtBrightness.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtBrightness.Location = new System.Drawing.Point(296, 102);
            this.txtBrightness.MaxLength = 4;
            this.txtBrightness.Name = "txtBrightness";
            this.txtBrightness.Size = new System.Drawing.Size(35, 20);
            this.txtBrightness.TabIndex = 8;
            this.txtBrightness.Text = "0";
            this.txtBrightness.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBrightness.WordWrap = false;
            this.txtBrightness.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtBlue
            // 
            this.txtBlue.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtBlue.Location = new System.Drawing.Point(296, 76);
            this.txtBlue.MaxLength = 4;
            this.txtBlue.Name = "txtBlue";
            this.txtBlue.Size = new System.Drawing.Size(35, 20);
            this.txtBlue.TabIndex = 7;
            this.txtBlue.Text = "0";
            this.txtBlue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBlue.WordWrap = false;
            this.txtBlue.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtGreen
            // 
            this.txtGreen.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtGreen.Location = new System.Drawing.Point(296, 50);
            this.txtGreen.MaxLength = 4;
            this.txtGreen.Name = "txtGreen";
            this.txtGreen.Size = new System.Drawing.Size(35, 20);
            this.txtGreen.TabIndex = 6;
            this.txtGreen.Text = "0";
            this.txtGreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGreen.WordWrap = false;
            this.txtGreen.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtRed
            // 
            this.txtRed.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtRed.Location = new System.Drawing.Point(296, 24);
            this.txtRed.MaxLength = 4;
            this.txtRed.Name = "txtRed";
            this.txtRed.Size = new System.Drawing.Size(35, 20);
            this.txtRed.TabIndex = 5;
            this.txtRed.Text = "0";
            this.txtRed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRed.WordWrap = false;
            this.txtRed.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // picContrast
            // 
            this.picContrast.BackColor = System.Drawing.Color.Transparent;
            this.picContrast.Image = global::Properties.Resources.picContrast;
            this.picContrast.Location = new System.Drawing.Point(7, 129);
            this.picContrast.Name = "picContrast";
            this.picContrast.Size = new System.Drawing.Size(16, 17);
            this.picContrast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picContrast.TabIndex = 1;
            this.picContrast.TabStop = false;
            // 
            // picBrightness
            // 
            this.picBrightness.BackColor = System.Drawing.Color.Transparent;
            this.picBrightness.Image = global::Properties.Resources.picBrightness;
            this.picBrightness.Location = new System.Drawing.Point(7, 103);
            this.picBrightness.Name = "picBrightness";
            this.picBrightness.Size = new System.Drawing.Size(16, 17);
            this.picBrightness.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBrightness.TabIndex = 1;
            this.picBrightness.TabStop = false;
            // 
            // picBlue
            // 
            this.picBlue.BackColor = System.Drawing.Color.Transparent;
            this.picBlue.Image = global::Properties.Resources.picBlue;
            this.picBlue.Location = new System.Drawing.Point(7, 77);
            this.picBlue.Name = "picBlue";
            this.picBlue.Size = new System.Drawing.Size(16, 17);
            this.picBlue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBlue.TabIndex = 1;
            this.picBlue.TabStop = false;
            // 
            // picGreen
            // 
            this.picGreen.BackColor = System.Drawing.Color.Transparent;
            this.picGreen.Image = global::Properties.Resources.picGreen;
            this.picGreen.Location = new System.Drawing.Point(7, 51);
            this.picGreen.Name = "picGreen";
            this.picGreen.Size = new System.Drawing.Size(16, 17);
            this.picGreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picGreen.TabIndex = 1;
            this.picGreen.TabStop = false;
            // 
            // picRed
            // 
            this.picRed.BackColor = System.Drawing.Color.Transparent;
            this.picRed.Image = global::Properties.Resources.picRed;
            this.picRed.Location = new System.Drawing.Point(7, 25);
            this.picRed.Name = "picRed";
            this.picRed.Size = new System.Drawing.Size(16, 17);
            this.picRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picRed.TabIndex = 1;
            this.picRed.TabStop = false;
            // 
            // tbBrightness
            // 
            this.tbBrightness.AutoSize = false;
            this.tbBrightness.Location = new System.Drawing.Point(29, 101);
            this.tbBrightness.Maximum = 100;
            this.tbBrightness.Minimum = -100;
            this.tbBrightness.Name = "tbBrightness";
            this.tbBrightness.Size = new System.Drawing.Size(270, 25);
            this.tbBrightness.TabIndex = 3;
            this.tbBrightness.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbBrightness.Scroll += new System.EventHandler(this.tb_Scroll);
            // 
            // tbBlue
            // 
            this.tbBlue.AutoSize = false;
            this.tbBlue.Location = new System.Drawing.Point(29, 76);
            this.tbBlue.Maximum = 100;
            this.tbBlue.Minimum = -100;
            this.tbBlue.Name = "tbBlue";
            this.tbBlue.Size = new System.Drawing.Size(270, 25);
            this.tbBlue.TabIndex = 2;
            this.tbBlue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbBlue.Scroll += new System.EventHandler(this.tb_Scroll);
            // 
            // tbGreen
            // 
            this.tbGreen.AutoSize = false;
            this.tbGreen.Location = new System.Drawing.Point(29, 49);
            this.tbGreen.Maximum = 100;
            this.tbGreen.Minimum = -100;
            this.tbGreen.Name = "tbGreen";
            this.tbGreen.Size = new System.Drawing.Size(270, 25);
            this.tbGreen.TabIndex = 1;
            this.tbGreen.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbGreen.Scroll += new System.EventHandler(this.tb_Scroll);
            // 
            // tbRed
            // 
            this.tbRed.AutoSize = false;
            this.tbRed.Location = new System.Drawing.Point(29, 24);
            this.tbRed.Maximum = 100;
            this.tbRed.Minimum = -100;
            this.tbRed.Name = "tbRed";
            this.tbRed.Size = new System.Drawing.Size(270, 25);
            this.tbRed.TabIndex = 0;
            this.tbRed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbRed.Scroll += new System.EventHandler(this.tb_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "color";
            // 
            // cmbColorParent
            // 
            this.cmbColorParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColorParent.FormattingEnabled = true;
            this.cmbColorParent.Items.AddRange(new object[] {
            "Kontur",
            "Neck",
            "Eyes",
            "Pupil",
            "Nose",
            "Mouth",
            "Eyebrows",
            "Beard",
            "Ears",
            "Hair (front)",
            "Hair (back)",
            "Cloth",
            "Hat",
            "Accessoire 1",
            "Accessoire 2"});
            this.cmbColorParent.Location = new System.Drawing.Point(52, 22);
            this.cmbColorParent.Name = "cmbColorParent";
            this.cmbColorParent.Size = new System.Drawing.Size(77, 21);
            this.cmbColorParent.TabIndex = 10;
            this.cmbColorParent.SelectedIndexChanged += new System.EventHandler(this.cmbColorParent_SelectedIndexChanged);
            // 
            // btnRandom
            // 
            this.btnRandom.Location = new System.Drawing.Point(212, 196);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(70, 25);
            this.btnRandom.TabIndex = 2;
            this.btnRandom.Text = "random";
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(267, 463);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 25);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(267, 525);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(87, 25);
            this.btnQuit.TabIndex = 12;
            this.btnQuit.Text = "quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnSetDefault
            // 
            this.btnSetDefault.Location = new System.Drawing.Point(166, 463);
            this.btnSetDefault.Name = "btnSetDefault";
            this.btnSetDefault.Size = new System.Drawing.Size(95, 25);
            this.btnSetDefault.TabIndex = 7;
            this.btnSetDefault.Text = "set default";
            this.btnSetDefault.UseVisualStyleBackColor = true;
            this.btnSetDefault.Click += new System.EventHandler(this.btnSetDefault_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(284, 196);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(70, 25);
            this.btnDefault.TabIndex = 3;
            this.btnDefault.Text = "reset";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // sfd
            // 
            this.sfd.DefaultExt = "bmp";
            this.sfd.Filter = "24bits Bitmap(*.bmp)|*.bmp|Portable Network Graphics(*.png)|*.png";
            this.sfd.RestoreDirectory = true;
            // 
            // txtSize
            // 
            this.txtSize.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSize.Location = new System.Drawing.Point(80, 20);
            this.txtSize.MaxLength = 3;
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(26, 20);
            this.txtSize.TabIndex = 10;
            this.txtSize.Text = "192";
            this.txtSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSize.WordWrap = false;
            this.txtSize.TextChanged += new System.EventHandler(this.txtSixe_TextChanged);
            // 
            // grpSaveSize
            // 
            this.grpSaveSize.Controls.Add(this.panel1);
            this.grpSaveSize.Controls.Add(this.label2);
            this.grpSaveSize.Controls.Add(this.label1);
            this.grpSaveSize.Controls.Add(this.lblPixel);
            this.grpSaveSize.Controls.Add(this.txtSize);
            this.grpSaveSize.Location = new System.Drawing.Point(12, 456);
            this.grpSaveSize.Name = "grpSaveSize";
            this.grpSaveSize.Size = new System.Drawing.Size(141, 80);
            this.grpSaveSize.TabIndex = 5;
            this.grpSaveSize.TabStop = false;
            this.grpSaveSize.Text = "Save options";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radIndivisible);
            this.panel1.Controls.Add(this.radVisible);
            this.panel1.Location = new System.Drawing.Point(52, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(86, 28);
            this.panel1.TabIndex = 14;
            // 
            // radIndivisible
            // 
            this.radIndivisible.AutoSize = true;
            this.radIndivisible.Location = new System.Drawing.Point(48, 5);
            this.radIndivisible.Name = "radIndivisible";
            this.radIndivisible.Size = new System.Drawing.Size(37, 17);
            this.radIndivisible.TabIndex = 15;
            this.radIndivisible.TabStop = true;
            this.radIndivisible.Text = "no";
            this.radIndivisible.UseVisualStyleBackColor = true;
            this.radIndivisible.CheckedChanged += new System.EventHandler(this.radVisible_CheckedChanged);
            // 
            // radVisible
            // 
            this.radVisible.AutoSize = true;
            this.radVisible.Location = new System.Drawing.Point(3, 4);
            this.radVisible.Name = "radVisible";
            this.radVisible.Size = new System.Drawing.Size(41, 17);
            this.radVisible.TabIndex = 14;
            this.radVisible.TabStop = true;
            this.radVisible.Text = "yes";
            this.radVisible.UseVisualStyleBackColor = true;
            this.radVisible.CheckedChanged += new System.EventHandler(this.radVisible_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 30);
            this.label2.TabIndex = 13;
            this.label2.Text = "bg visible";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "save size";
            // 
            // lblPixel
            // 
            this.lblPixel.AutoSize = true;
            this.lblPixel.Location = new System.Drawing.Point(112, 27);
            this.lblPixel.Name = "lblPixel";
            this.lblPixel.Size = new System.Drawing.Size(18, 13);
            this.lblPixel.TabIndex = 11;
            this.lblPixel.Text = "px";
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Location = new System.Drawing.Point(267, 494);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(87, 25);
            this.btnSaveSetting.TabIndex = 10;
            this.btnSaveSetting.Text = "save settings";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // sfdSaveSetting
            // 
            this.sfdSaveSetting.DefaultExt = "kgm";
            this.sfdSaveSetting.Filter = "FaceMaker config file|*.kgm";
            this.sfdSaveSetting.RestoreDirectory = true;
            // 
            // btnLoadSetting
            // 
            this.btnLoadSetting.Location = new System.Drawing.Point(166, 494);
            this.btnLoadSetting.Name = "btnLoadSetting";
            this.btnLoadSetting.Size = new System.Drawing.Size(95, 25);
            this.btnLoadSetting.TabIndex = 9;
            this.btnLoadSetting.Text = "load settings";
            this.btnLoadSetting.UseVisualStyleBackColor = true;
            this.btnLoadSetting.Click += new System.EventHandler(this.btnLoadSetting_Click);
            // 
            // sfdLoadSetting
            // 
            this.sfdLoadSetting.Filter = "FaceMaker config file|*.kgm";
            // 
            // grpRelation
            // 
            this.grpRelation.Controls.Add(this.label4);
            this.grpRelation.Controls.Add(this.cmbPositionParent);
            this.grpRelation.Controls.Add(this.label3);
            this.grpRelation.Controls.Add(this.cmbColorParent);
            this.grpRelation.Location = new System.Drawing.Point(12, 391);
            this.grpRelation.Name = "grpRelation";
            this.grpRelation.Size = new System.Drawing.Size(342, 59);
            this.grpRelation.TabIndex = 15;
            this.grpRelation.TabStop = false;
            this.grpRelation.Text = "Linked part to";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "position && rotation";
            // 
            // cmbPositionParent
            // 
            this.cmbPositionParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPositionParent.FormattingEnabled = true;
            this.cmbPositionParent.Items.AddRange(new object[] {
            "Kontur",
            "Neck",
            "Eyes",
            "Pupil",
            "Nose",
            "Mouth",
            "Eyebrows",
            "Beard",
            "Ears",
            "Hair (front)",
            "Hair (back)",
            "Cloth",
            "Hat",
            "Accessoire 1",
            "Accessoire 2"});
            this.cmbPositionParent.Location = new System.Drawing.Point(249, 22);
            this.cmbPositionParent.Name = "cmbPositionParent";
            this.cmbPositionParent.Size = new System.Drawing.Size(77, 21);
            this.cmbPositionParent.TabIndex = 12;
            this.cmbPositionParent.SelectedIndexChanged += new System.EventHandler(this.cmbPositionParent_SelectedIndexChanged);
            // 
            // btnLoadWall
            // 
            this.btnLoadWall.Location = new System.Drawing.Point(166, 525);
            this.btnLoadWall.Name = "btnLoadWall";
            this.btnLoadWall.Size = new System.Drawing.Size(95, 25);
            this.btnLoadWall.TabIndex = 11;
            this.btnLoadWall.Text = "load background";
            this.btnLoadWall.UseVisualStyleBackColor = true;
            this.btnLoadWall.Click += new System.EventHandler(this.btnLoadWall_Click);
            // 
            // sfdWallImage
            // 
            this.sfdWallImage.Filter = "24bits Bitmap(*.bmp)|*.bmp|Portable Network Graphics(*.png)|*.png";
            // 
            // picImage
            // 
            this.picImage.BackgroundImage = global::FaceMaker.Properties.Resources.back;
            this.picImage.Location = new System.Drawing.Point(12, 21);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(192, 192);
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 563);
            this.Controls.Add(this.btnLoadWall);
            this.Controls.Add(this.grpRelation);
            this.Controls.Add(this.btnLoadSetting);
            this.Controls.Add(this.btnSaveSetting);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSetDefault);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.btnRandom);
            this.Controls.Add(this.grpSaveSize);
            this.Controls.Add(this.grpColor);
            this.Controls.Add(this.grpLocation);
            this.Controls.Add(this.grpParts);
            this.Controls.Add(this.picImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FaceMaker.Net";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpParts.ResumeLayout(false);
            this.grpLocation.ResumeLayout(false);
            this.grpLocation.PerformLayout();
            this.grpColor.ResumeLayout(false);
            this.grpColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRed)).EndInit();
            this.grpSaveSize.ResumeLayout(false);
            this.grpSaveSize.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpRelation.ResumeLayout(false);
            this.grpRelation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

		}

		public MainForm()
		{
			this.InitializeComponent();
			string text = Path.Combine(Const.partsDir, "wall.png");
			if (!File.Exists(text))
			{
				MessageBox.Show("wall.png does not exist!", "FaceMaker.NET", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Environment.Exit(0);
			}
			this.WallBitmap = new Bitmap(text);
			text = Path.Combine(Const.partsDir, "dummy.png");
			if (!File.Exists(text))
			{
				MessageBox.Show("dummy.png does not exist!", "FaceMaker.NET", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Environment.Exit(0);
			}
			this.DummyBitmap = new Bitmap(text);
			this.Parts = new List<Parts>();
			this.Parts.Add(new Parts("face", Settings.Default.ParentColor_face, Settings.Default.ParentPos_face));
			this.Parts.Add(new Parts("neck", Settings.Default.ParentColor_neck, Settings.Default.ParentPos_neck));
			this.Parts.Add(new Parts("eye", Settings.Default.ParentColor_eye, Settings.Default.ParentPos_eye));
			this.Parts.Add(new Parts("iris", Settings.Default.ParentColor_iris, Settings.Default.ParentPos_iris));
			this.Parts.Add(new Parts("nose", Settings.Default.ParentColor_nose, Settings.Default.ParentPos_nose));
			this.Parts.Add(new Parts("mouth", Settings.Default.ParentColor_mouth, Settings.Default.ParentPos_mouth));
			this.Parts.Add(new Parts("brow", Settings.Default.ParentColor_brow, Settings.Default.ParentPos_brow));
			this.Parts.Add(new Parts("beard", Settings.Default.ParentColor_beard, Settings.Default.ParentPos_beard));
			this.Parts.Add(new Parts("ear", Settings.Default.ParentColor_ear, Settings.Default.ParentPos_ear));
			this.Parts.Add(new Parts("fhair1", Settings.Default.ParentColor_fhair, Settings.Default.ParentPos_fhair));
			this.Parts.Add(new Parts("bhair1", Settings.Default.ParentColor_bhair, Settings.Default.ParentPos_bhair));
			this.Parts.Add(new Parts("cloth1", Settings.Default.ParentColor_cloth, Settings.Default.ParentPos_cloth));
			this.Parts.Add(new Parts("hat1", Settings.Default.ParentColor_hat, Settings.Default.ParentPos_hat));
			this.Parts.Add(new Parts("acc", Settings.Default.ParentColor_acc, Settings.Default.ParentPos_acc));
			this.Parts.Add(new Parts("band", Settings.Default.ParentColor_band, Settings.Default.ParentPos_band));
			this.Parts.Add(new Parts("eyesh", Settings.Default.ParentColor_eye2, Settings.Default.ParentPos_eye2));
			this.Parts.Add(new Parts("mouthop", Settings.Default.ParentColor_mouth2, Settings.Default.ParentPos_mouth2));
			this.Parts.Add(new Parts("fhair2", Settings.Default.ParentColor_fhair2, Settings.Default.ParentPos_fhair2));
			this.Parts.Add(new Parts("shadow", Settings.Default.ParentColor_shadow, Settings.Default.ParentPos_shadow));
			this.Parts.Add(new Parts("bhair2", Settings.Default.ParentColor_bhair2, Settings.Default.ParentPos_bhair2));
			this.Parts.Add(new Parts("bhair3", Settings.Default.ParentColor_bhair3, Settings.Default.ParentPos_bhair3));
			this.Parts.Add(new Parts("cloth2", Settings.Default.ParentColor_cloth2, Settings.Default.ParentPos_cloth2));
			this.Parts.Add(new Parts("hat2", Settings.Default.ParentColor_hat2, Settings.Default.ParentPos_hat2));
			this.Parts.Add(new Parts("hat3", Settings.Default.ParentColor_hat3, Settings.Default.ParentPos_hat3));
			this.DispPartsID = 0;
			this.DispPartsNo = 1;
			this.DispPartsTotal = this.Parts[this.DispPartsID].TotalPartsNum;
			this.DispRed = 0;
			this.DispGreen = 0;
			this.DispBlue = 0;
			this.DispBrightness = 0;
			this.DispContrast = 0;
			this.saveSize = Const.ImageOutputSize.Width;
			this.radVisible.Checked = true;
			this.reloadImage = false;
			this.checkMirrorFlag = false;
			this.Parts[0].CurrentNo = Settings.Default.PartsNo_face;
			this.Parts[1].CurrentNo = Settings.Default.PartsNo_neck;
			this.Parts[2].CurrentNo = Settings.Default.PartsNo_eye;
			this.Parts[3].CurrentNo = Settings.Default.PartsNo_iris;
			this.Parts[4].CurrentNo = Settings.Default.PartsNo_nose;
			this.Parts[5].CurrentNo = Settings.Default.PartsNo_mouth;
			this.Parts[6].CurrentNo = Settings.Default.PartsNo_brow;
			this.Parts[7].CurrentNo = Settings.Default.PartsNo_beard;
			this.Parts[8].CurrentNo = Settings.Default.PartsNo_ear;
			this.Parts[9].CurrentNo = Settings.Default.PartsNo_fhair;
			this.Parts[10].CurrentNo = Settings.Default.PartsNo_bhair;
			this.Parts[11].CurrentNo = Settings.Default.PartsNo_cloth;
			this.Parts[12].CurrentNo = Settings.Default.PartsNo_hat;
			this.Parts[13].CurrentNo = Settings.Default.PartsNo_acc;
			this.Parts[14].CurrentNo = Settings.Default.PartsNo_band;
			this.Parts[15].CurrentNo = Settings.Default.PartsNo_eye2;
			this.Parts[16].CurrentNo = Settings.Default.PartsNo_mouth2;
			this.Parts[17].CurrentNo = Settings.Default.PartsNo_fhair2;
			this.Parts[18].CurrentNo = Settings.Default.PartsNo_shadow;
			this.Parts[19].CurrentNo = Settings.Default.PartsNo_bhair2;
			this.Parts[20].CurrentNo = Settings.Default.PartsNo_bhair3;
			this.Parts[21].CurrentNo = Settings.Default.PartsNo_cloth2;
			this.Parts[22].CurrentNo = Settings.Default.PartsNo_hat2;
			this.Parts[23].CurrentNo = Settings.Default.PartsNo_hat3;
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			this.SetImage(0, 0, "face");
			this.SetImage(1, 1, "neck");
			this.SetImage(2, 2, "eye");
			this.SetImage(15, 2, "eyesh");
			this.SetImage(3, 3, "iris");
			this.SetImage(4, 4, "nose");
			this.SetImage(5, 5, "mouth");
			this.SetImage(16, 5, "mouthop");
			this.SetImage(6, 6, "brow");
			this.SetImage(7, 7, "beard");
			this.SetImage(8, 8, "ear");
			this.SetImage(9, 9, "fhair1");
			this.SetImage(17, 9, "fhair2");
			this.SetImage(18, 9, "shadow");
			this.SetImage(10, 10, "bhair1");
			this.SetImage(19, 10, "bhair2");
			this.SetImage(20, 10, "bhair3");
			this.SetImage(11, 11, "cloth1");
			this.SetImage(21, 11, "cloth2");
			this.SetImage(12, 12, "hat1");
			this.SetImage(22, 12, "hat2");
			this.SetImage(23, 12, "hat3");
			this.SetImage(13, 13, "acc");
			this.SetImage(14, 14, "band");
			this.cmbParts.SelectedIndex = this.DispPartsID;
			this.lblCurrentPartsNo.Text = this.DispPartsNo.ToString();
			this.lblTotalPartsCount.Text = this.DispPartsTotal.ToString();
			this.tbRed.Value = this.DispRed;
			this.tbGreen.Value = this.DispGreen;
			this.tbBlue.Value = this.DispBlue;
			this.tbBrightness.Value = this.DispBrightness;
			this.tbContrast.Value = this.DispContrast;
			this.txtRed.Text = this.DispRed.ToString();
			this.txtGreen.Text = this.DispGreen.ToString();
			this.txtBlue.Text = this.DispBlue.ToString();
			this.txtBrightness.Text = this.DispBrightness.ToString();
			this.txtContrast.Text = this.DispContrast.ToString();
			this.txtSize.Text = this.saveSize.ToString();
			this.cmbColorParent.SelectedIndex = 0;
			this.cmbPositionParent.SelectedIndex = 0;
			this.reloadImage = true;
			if (this.reloadImage)
			{
				this.ChangeColor(true);
				this.ChangeImageAlpha(3, 15);
				this.DrawImage();
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (MessageBox.Show("Do you want to close?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				e.Cancel = true;
			}
		}

		private void btnQuit_Click(object sender, EventArgs e)
		{
            Close();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			Bitmap bitmap;
			if (this.saveSize != Const.ImageOutputSize.Width)
			{
				bitmap = new Bitmap(this.saveSize, this.saveSize, PixelFormat.Format32bppArgb);
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.DrawImage(this.picImage.Image, 0, 0, this.saveSize, this.saveSize);
				graphics.Dispose();
			}
			else
			{
				bitmap = new Bitmap(this.picImage.Image);
			}
			if (this.sfd.ShowDialog() == DialogResult.OK)
			{
				ImageFormat format = ImageFormat.Bmp;
				switch (this.sfd.FilterIndex)
				{
				case 1:
					format = ImageFormat.Bmp;
					break;
				case 2:
					format = ImageFormat.Png;
					break;
				}
				Image image = bitmap;
				image.Save(this.sfd.FileName, format);
			}
		}

		private void txtSixe_TextChanged(object sender, EventArgs e)
		{
			this.saveSize = int.Parse(this.txtSize.Text);
			if (this.saveSize > Const.MaxSaveSize)
			{
				this.saveSize = Const.MaxSaveSize;
				this.txtSize.Text = Const.MaxSaveSize.ToString();
			}
			if (this.saveSize < Const.MinSaveSize)
			{
				this.saveSize = Const.MinSaveSize;
				this.txtSize.Text = Const.MinSaveSize.ToString();
			}
		}

		private void cmbParts_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.reloadImage = false;
			this.DispPartsID = this.cmbParts.SelectedIndex;
			this.DispPartsNo = this.Parts[this.DispPartsID].CurrentNo + 1;
			this.DispPartsTotal = this.Parts[this.DispPartsID].TotalPartsNum;
			this.DispRed = this.Parts[this.DispPartsID].Attribute.Color.Red;
			this.DispGreen = this.Parts[this.DispPartsID].Attribute.Color.Green;
			this.DispBlue = this.Parts[this.DispPartsID].Attribute.Color.Blue;
			this.DispBrightness = this.Parts[this.DispPartsID].Attribute.Color.Brightness;
			this.DispContrast = this.Parts[this.DispPartsID].Attribute.Color.Contrast;
			this.lblCurrentPartsNo.Text = this.DispPartsNo.ToString();
			this.lblTotalPartsCount.Text = this.DispPartsTotal.ToString();
			this.cmbColorParent.SelectedIndex = this.Parts[this.DispPartsID].colorParentPartsID;
			this.cmbPositionParent.SelectedIndex = this.Parts[this.DispPartsID].positionParentPartsID;
			this.tbRed.Value = this.DispRed;
			this.tbGreen.Value = this.DispGreen;
			this.tbBlue.Value = this.DispBlue;
			this.tbBrightness.Value = this.DispBrightness;
			this.tbContrast.Value = this.DispContrast;
			this.txtRed.Text = this.DispRed.ToString();
			this.txtGreen.Text = this.DispGreen.ToString();
			this.txtBlue.Text = this.DispBlue.ToString();
			this.txtBrightness.Text = this.DispBrightness.ToString();
			this.txtContrast.Text = this.DispContrast.ToString();
			this.reloadImage = true;
		}

		private void btnIncDec_Click(object sender, EventArgs e)
		{
			if (sender == this.btnIncriment)
			{
				if (this.Parts[this.DispPartsID].CurrentNo < this.Parts[this.DispPartsID].TotalPartsNum - 1)
				{
					this.Parts[this.DispPartsID].CurrentNo++;
				}
				else
				{
					this.Parts[this.DispPartsID].CurrentNo = 0;
				}
			}
			else if (sender == this.btnDecriment)
			{
				if (this.Parts[this.DispPartsID].CurrentNo > 0)
				{
					this.Parts[this.DispPartsID].CurrentNo--;
				}
				else
				{
					this.Parts[this.DispPartsID].CurrentNo = this.Parts[this.DispPartsID].TotalPartsNum - 1;
				}
			}
			this.DispPartsNo = this.Parts[this.DispPartsID].CurrentNo + 1;
			this.lblCurrentPartsNo.Text = this.DispPartsNo.ToString();
			switch (this.DispPartsID)
			{
			case 0:
				this.SetImage(0, 0, "face");
				break;
			case 1:
				this.SetImage(1, 1, "neck");
				break;
			case 2:
				this.SetImage(2, 2, "eye");
				this.SetImage(15, 2, "eyesh");
				this.SetImage(3, 3, "iris");
				this.ChangeImageAlpha(3, 15);
				break;
			case 3:
				this.SetImage(3, 3, "iris");
				this.ChangeImageAlpha(3, 15);
				break;
			case 4:
				this.SetImage(4, 4, "nose");
				break;
			case 5:
				this.SetImage(5, 5, "mouth");
				this.SetImage(16, 5, "mouthop");
				break;
			case 6:
				this.SetImage(6, 6, "brow");
				break;
			case 7:
				this.SetImage(7, 7, "beard");
				break;
			case 8:
				this.SetImage(8, 8, "ear");
				break;
			case 9:
				this.SetImage(9, 9, "fhair1");
				this.SetImage(17, 9, "fhair2");
				this.SetImage(18, 9, "shadow");
				break;
			case 10:
				this.SetImage(10, 10, "bhair1");
				this.SetImage(19, 10, "bhair2");
				this.SetImage(20, 10, "bhair3");
				break;
			case 11:
				this.SetImage(11, 11, "cloth1");
				this.SetImage(21, 11, "cloth2");
				break;
			case 12:
				this.SetImage(12, 12, "hat1");
				this.SetImage(22, 12, "hat2");
				this.SetImage(23, 12, "hat3");
				break;
			case 13:
				this.SetImage(13, 13, "acc");
				break;
			case 14:
				this.SetImage(14, 14, "band");
				break;
			}
			if (this.reloadImage)
			{
				this.ChangeColor(false);
				this.ChangeImageAlpha(3, 15);
				this.DrawImage();
			}
		}

		private void btnPosition_Click(object sender, EventArgs e)
		{
			int x = this.Parts[this.DispPartsID].Attribute.Position.X;
			int y = this.Parts[this.DispPartsID].Attribute.Position.Y;
			int direction = this.Parts[this.DispPartsID].Attribute.Position.Direction;
			if (sender == this.btnUp)
			{
				this.MoveImage(x, y - 1);
			}
			else if (sender == this.btnDown)
			{
				this.MoveImage(x, y + 1);
			}
			else if (sender == this.btnLeft)
			{
				this.MoveImage(x - 1, y);
			}
			else if (sender == this.btnRight)
			{
				this.MoveImage(x + 1, y);
			}
			else if (sender == this.btnClockwise)
			{
				this.RotateImage(direction + 2);
			}
			else if (sender == this.btnCounterclockwise)
			{
				this.RotateImage(direction - 2);
			}
			else if (sender == this.btnCenter)
			{
				this.MoveImage((Const.ImageOutputSize.Width - Const.ImageSize.Width) / 2, (Const.ImageOutputSize.Height - Const.ImageSize.Height) / 2);
				this.RotateImage(0);
			}
			if (this.reloadImage)
			{
				this.ChangeImageAlpha(3, 15);
				this.DrawImage();
			}
		}

		private void checkMirror_CheckedChanged(object sender, EventArgs e)
		{
			this.checkMirrorFlag = true;
			this.DrawImage();
		}

		private void btnRandom_Click(object sender, EventArgs e)
		{
			Random random = new Random();
			this.Parts[0].CurrentNo = random.Next(this.Parts[0].TotalPartsNum);
			this.Parts[2].CurrentNo = random.Next(this.Parts[2].TotalPartsNum);
			this.Parts[3].CurrentNo = random.Next(this.Parts[3].TotalPartsNum);
			this.Parts[4].CurrentNo = random.Next(this.Parts[4].TotalPartsNum);
			this.Parts[5].CurrentNo = random.Next(this.Parts[5].TotalPartsNum);
			this.Parts[6].CurrentNo = random.Next(this.Parts[6].TotalPartsNum);
			this.Parts[9].CurrentNo = random.Next(this.Parts[9].TotalPartsNum);
			this.Parts[10].CurrentNo = random.Next(this.Parts[10].TotalPartsNum);
			this.SetImage(0, 0, "face");
			this.SetImage(2, 2, "eye");
			this.SetImage(15, 2, "eyesh");
			this.SetImage(3, 3, "iris");
			this.SetImage(4, 4, "nose");
			this.SetImage(5, 5, "mouth");
			this.SetImage(16, 5, "mouthop");
			this.SetImage(6, 6, "brow");
			this.SetImage(9, 9, "fhair1");
			this.SetImage(17, 9, "fhair2");
			this.SetImage(18, 9, "shadow");
			this.SetImage(10, 10, "bhair1");
			this.SetImage(19, 10, "bhair2");
			this.SetImage(20, 10, "bhair3");
			this.DispPartsNo = this.Parts[this.DispPartsID].CurrentNo + 1;
			this.lblCurrentPartsNo.Text = this.DispPartsNo.ToString();
			if (this.reloadImage)
			{
				this.ChangeColor(false);
				this.ChangeImageAlpha(3, 15);
				this.DrawImage();
			}
		}

		private void tb_Scroll(object sender, EventArgs e)
		{
			if (!this.changeTxt)
			{
				this.changeTb = true;
			}
			if (sender == this.tbRed)
			{
				this.DispRed = this.tbRed.Value;
				this.txtRed.Text = this.DispRed.ToString();
			}
			else if (sender == this.tbGreen)
			{
				this.DispGreen = this.tbGreen.Value;
				this.txtGreen.Text = this.DispGreen.ToString();
			}
			else if (sender == this.tbBlue)
			{
				this.DispBlue = this.tbBlue.Value;
				this.txtBlue.Text = this.DispBlue.ToString();
			}
			else if (sender == this.tbBrightness)
			{
				this.DispBrightness = this.tbBrightness.Value;
				this.txtBrightness.Text = this.DispBrightness.ToString();
			}
			else if (sender == this.tbContrast)
			{
				this.DispContrast = this.tbContrast.Value;
				this.txtContrast.Text = this.DispContrast.ToString();
			}
			if (this.changeTb && this.reloadImage)
			{
				this.ChangeColor(false);
				this.DrawImage();
				this.Refresh();
			}
			this.changeTb = false;
		}

		private void txt_TextChanged(object sender, EventArgs e)
		{
			if (!this.changeTb)
			{
				this.changeTxt = true;
			}
			if (sender == this.txtRed)
			{
				if (Check.IsInt(this.txtRed.Text))
				{
					this.DispRed = int.Parse(this.txtRed.Text);
					if (this.DispRed > Const.MaxValue)
					{
						this.DispRed = Const.MaxValue;
						this.txtRed.Text = Const.MaxValue.ToString();
					}
					if (this.DispRed < Const.MinValue)
					{
						this.DispRed = Const.MinValue;
						this.txtRed.Text = Const.MinValue.ToString();
					}
					this.tbRed.Value = this.DispRed;
				}
			}
			else if (sender == this.txtGreen)
			{
				if (Check.IsInt(this.txtGreen.Text))
				{
					this.DispGreen = int.Parse(this.txtGreen.Text);
					if (this.DispGreen > Const.MaxValue)
					{
						this.DispGreen = Const.MaxValue;
						this.txtGreen.Text = Const.MaxValue.ToString();
					}
					if (this.DispGreen < Const.MinValue)
					{
						this.DispGreen = Const.MinValue;
						this.txtGreen.Text = Const.MinValue.ToString();
					}
					this.tbGreen.Value = this.DispGreen;
				}
			}
			else if (sender == this.txtBlue)
			{
				if (Check.IsInt(this.txtBlue.Text))
				{
					this.DispBlue = int.Parse(this.txtBlue.Text);
					if (this.DispBlue > Const.MaxValue)
					{
						this.DispBlue = Const.MaxValue;
						this.txtBlue.Text = Const.MaxValue.ToString();
					}
					if (this.DispBlue < Const.MinValue)
					{
						this.DispBlue = Const.MinValue;
						this.txtBlue.Text = Const.MinValue.ToString();
					}
					this.tbBlue.Value = this.DispBlue;
				}
			}
			else if (sender == this.txtBrightness)
			{
				if (Check.IsInt(this.txtBrightness.Text))
				{
					this.DispBrightness = int.Parse(this.txtBrightness.Text);
					if (this.DispBrightness > Const.MaxValue)
					{
						this.DispBrightness = Const.MaxValue;
						this.txtBrightness.Text = Const.MaxValue.ToString();
					}
					if (this.DispBrightness < Const.MinValue)
					{
						this.DispBrightness = Const.MinValue;
						this.txtBrightness.Text = Const.MinValue.ToString();
					}
					this.tbBrightness.Value = this.DispBrightness;
				}
			}
			else if (sender == this.txtContrast && Check.IsInt(this.txtBrightness.Text))
			{
				this.DispContrast = int.Parse(this.txtContrast.Text);
				if (this.DispContrast > Const.MaxValue)
				{
					this.DispContrast = Const.MaxValue;
					this.txtContrast.Text = Const.MaxValue.ToString();
				}
				if (this.DispContrast < Const.MinValue)
				{
					this.DispContrast = Const.MinValue;
					this.txtContrast.Text = Const.MinValue.ToString();
				}
				this.tbContrast.Value = this.DispContrast;
			}
			if (this.changeTxt && this.reloadImage)
			{
				this.ChangeColor(false);
				this.DrawImage();
			}
			this.changeTxt = false;
		}

		private void radVisible_CheckedChanged(object sender, EventArgs e)
		{
			if (this.reloadImage)
			{
				this.DrawImage();
			}
		}

		private void SetImage(int partsID, int partsParentID, string partsName)
		{
			if (partsID < 15)
			{
				this.Parts[partsID].BaseBitmap = new Bitmap(this.Parts[partsID].Files[this.Parts[partsID].CurrentNo]);
				this.Parts[partsID].WorkBitmap = new Bitmap(this.Parts[partsID].Files[this.Parts[partsID].CurrentNo]);
				return;
			}
			string fileName = Path.GetFileName(this.Parts[partsParentID].Files[this.Parts[partsParentID].CurrentNo]);
			fileName = Path.Combine(Const.partsDir, partsName, fileName);
			int num = this.Parts[partsID].Files.FindIndex((string p) => p == fileName);
			if (num != -1)
			{
				this.Parts[partsID].BaseBitmap = new Bitmap(this.Parts[partsID].Files[num]);
				this.Parts[partsID].WorkBitmap = new Bitmap(this.Parts[partsID].Files[num]);
				return;
			}
			this.Parts[partsID].BaseBitmap = this.DummyBitmap;
			this.Parts[partsID].WorkBitmap = this.DummyBitmap;
		}

		private void DrawImage()
		{
			Bitmap bitmap = new Bitmap(Const.ImageOutputSize.Width, Const.ImageOutputSize.Height, PixelFormat.Format32bppArgb);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			if (this.checkMirrorFlag)
			{
				this.WallBitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
			}
			if (!this.radIndivisible.Checked)
			{
				graphics.DrawImage(this.WallBitmap, 0, 0, Const.ImageOutputSize.Width, Const.ImageOutputSize.Height);
			}
			this.checkMirrorFlag = false;
			for (int i = 0; i < this.Parts.Count; i++)
			{
				int index = Layer.LayerNum[i];
				graphics.ResetTransform();
				graphics.RotateTransform((float)this.Parts[index].Attribute.Position.Direction);
				float num = 1f;
				float num2 = 0f;
				float num3 = (float)this.Parts[index].Attribute.Color.Red / 100f;
				float num4 = (float)this.Parts[index].Attribute.Color.Green / 100f;
				float num5 = (float)this.Parts[index].Attribute.Color.Blue / 100f;
				num3 += (float)this.Parts[index].Attribute.Color.Brightness / 100f;
				num4 += (float)this.Parts[index].Attribute.Color.Brightness / 100f;
				num5 += (float)this.Parts[index].Attribute.Color.Brightness / 100f;
				if (this.Parts[index].Attribute.Color.Contrast != 0)
				{
					if (this.Parts[index].Attribute.Color.Contrast != 100)
					{
						num = (float)Math.Tan((double)(this.Parts[index].Attribute.Color.Contrast * 45 / 100 + 45) * 3.1415926535897931 / 180.0);
					}
					else
					{
						num = 100f;
					}
					num2 = -0.5f * num + 0.5f;
				}
				float[][] array = new float[5][];
				float[][] arg_23A_0 = array;
				int arg_23A_1 = 0;
				float[] array2 = new float[5];
				array2[0] = num;
				arg_23A_0[arg_23A_1] = array2;
				float[][] arg_24E_0 = array;
				int arg_24E_1 = 1;
				float[] array3 = new float[5];
				array3[1] = num;
				arg_24E_0[arg_24E_1] = array3;
				float[][] arg_262_0 = array;
				int arg_262_1 = 2;
				float[] array4 = new float[5];
				array4[2] = num;
				arg_262_0[arg_262_1] = array4;
				float[][] arg_279_0 = array;
				int arg_279_1 = 3;
				float[] array5 = new float[5];
				array5[3] = 1f;
				arg_279_0[arg_279_1] = array5;
				array[4] = new float[]
				{
					num3 + num2,
					num4 + num2,
					num5 + num2,
					0f,
					1f
				};
				float[][] newColorMatrix = array;
				ColorMatrix colorMatrix = new ColorMatrix(newColorMatrix);
				ImageAttributes imageAttributes = new ImageAttributes();
				imageAttributes.SetColorMatrix(colorMatrix);
				graphics.DrawImage(this.Parts[index].WorkBitmap, new Rectangle(this.Parts[index].Attribute.Position.X, this.Parts[index].Attribute.Position.Y, Const.ImageSize.Width, Const.ImageSize.Height), 0, 0, Const.ImageSize.Width, Const.ImageSize.Height, GraphicsUnit.Pixel, imageAttributes);
				GC.Collect();
			}
			if (this.checkMirror.Checked)
			{
				bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
			}
			this.picImage.Image = bitmap;
			graphics.Dispose();
		}

		private void cmbColorParent_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.Parts[this.DispPartsID].colorParentPartsID = this.cmbColorParent.SelectedIndex;
			int dispPartsID = this.DispPartsID;
			if (dispPartsID != 0)
			{
				switch (dispPartsID)
				{
				case 5:
					this.Parts[16].colorParentPartsID = this.cmbColorParent.SelectedIndex;
					return;
				case 6:
				case 7:
				case 8:
					break;
				case 9:
					this.Parts[17].colorParentPartsID = this.cmbColorParent.SelectedIndex;
					return;
				case 10:
					this.Parts[19].colorParentPartsID = this.cmbColorParent.SelectedIndex;
					this.Parts[20].colorParentPartsID = this.cmbColorParent.SelectedIndex;
					return;
				case 11:
					this.Parts[21].colorParentPartsID = this.cmbColorParent.SelectedIndex;
					return;
				case 12:
					this.Parts[22].colorParentPartsID = this.cmbColorParent.SelectedIndex;
					this.Parts[23].colorParentPartsID = this.cmbColorParent.SelectedIndex;
					break;
				default:
					return;
				}
				return;
			}
			this.Parts[18].colorParentPartsID = this.cmbColorParent.SelectedIndex;
		}

		private void cmbPositionParent_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.Parts[this.DispPartsID].positionParentPartsID = this.cmbPositionParent.SelectedIndex;
			switch (this.DispPartsID)
			{
			case 0:
			case 1:
			case 3:
			case 4:
			case 6:
			case 7:
			case 8:
				break;
			case 2:
				this.Parts[15].positionParentPartsID = this.cmbPositionParent.SelectedIndex;
				return;
			case 5:
				this.Parts[16].positionParentPartsID = this.cmbPositionParent.SelectedIndex;
				return;
			case 9:
				this.Parts[17].positionParentPartsID = this.cmbPositionParent.SelectedIndex;
				this.Parts[18].positionParentPartsID = this.cmbPositionParent.SelectedIndex;
				return;
			case 10:
				this.Parts[19].positionParentPartsID = this.cmbPositionParent.SelectedIndex;
				this.Parts[20].positionParentPartsID = this.cmbPositionParent.SelectedIndex;
				return;
			case 11:
				this.Parts[21].positionParentPartsID = this.cmbPositionParent.SelectedIndex;
				return;
			case 12:
				this.Parts[22].positionParentPartsID = this.cmbPositionParent.SelectedIndex;
				this.Parts[23].positionParentPartsID = this.cmbPositionParent.SelectedIndex;
				break;
			default:
				return;
			}
		}

		private void ChangeColor(bool ChangeAll)
		{
			if (ChangeAll)
			{
				for (int i = 0; i < this.Parts.Count; i++)
				{
					this.ChangePartsColor(i);
				}
				return;
			}
			for (int j = 0; j < this.Parts.Count; j++)
			{
				if (this.Parts[j].colorParentPartsID == this.DispPartsID)
				{
					this.ChangePartsColor(j);
				}
			}
		}

		private void MoveImage(int x, int y)
		{
			for (int i = 0; i < this.Parts.Count; i++)
			{
				if (this.Parts[i].positionParentPartsID == this.DispPartsID)
				{
					this.Parts[i].Attribute.Position.X = x;
					this.Parts[i].Attribute.Position.Y = y;
				}
			}
		}

		private void RotateImage(int deg)
		{
			for (int i = 0; i < this.Parts.Count; i++)
			{
				if (this.Parts[i].positionParentPartsID == this.DispPartsID)
				{
					this.Parts[i].Attribute.Position.Direction = deg;
				}
			}
		}

		private void ChangePartsColor(int PartsNo)
		{
			this.Parts[PartsNo].Attribute.Color.Red = this.DispRed;
			this.Parts[PartsNo].Attribute.Color.Green = this.DispGreen;
			this.Parts[PartsNo].Attribute.Color.Blue = this.DispBlue;
			this.Parts[PartsNo].Attribute.Color.Brightness = this.DispBrightness;
			this.Parts[PartsNo].Attribute.Color.Contrast = this.DispContrast;
			this.Parts[PartsNo].WorkBitmap = this.Parts[PartsNo].BaseBitmap.Clone(new Rectangle(0, 0, Const.ImageSize.Width, Const.ImageSize.Height), PixelFormat.Format32bppArgb);
		}

		private void ChangeImageAlpha(int partsID, int partsMaskID)
		{
			this.Parts[partsID].WorkBitmap = this.Parts[partsID].BaseBitmap.Clone(new Rectangle(0, 0, Const.ImageSize.Width, Const.ImageSize.Height), PixelFormat.Format32bppArgb);
			Bitmap bitmap = this.Parts[partsID].WorkBitmap.Clone(new Rectangle(0, 0, Const.ImageSize.Width, Const.ImageSize.Height), PixelFormat.Format32bppArgb);
			Bitmap bitmap2 = this.Parts[partsMaskID].WorkBitmap.Clone(new Rectangle(0, 0, Const.ImageSize.Width, Const.ImageSize.Height), PixelFormat.Format32bppArgb);
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, Const.ImageSize.Width, Const.ImageSize.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
			BitmapData bitmapData2 = bitmap2.LockBits(new Rectangle(0, 0, Const.ImageSize.Width, Const.ImageSize.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
			byte[] array = new byte[Const.ImageSize.Width * Const.ImageSize.Height * 4];
			byte[] array2 = new byte[Const.ImageSize.Width * Const.ImageSize.Height * 4];
			Marshal.Copy(bitmapData.Scan0, array, 0, array.Length);
			Marshal.Copy(bitmapData2.Scan0, array2, 0, array.Length);
			int num = this.Parts[partsID].Attribute.Position.X - this.Parts[partsMaskID].Attribute.Position.X;
			int num2 = this.Parts[partsID].Attribute.Position.Y - this.Parts[partsMaskID].Attribute.Position.Y;
			for (int i = 0; i < Const.ImageSize.Height; i++)
			{
				for (int j = 0; j < Const.ImageSize.Width; j++)
				{
					if (0 <= i + num2 && i + num2 < Const.ImageSize.Height && 0 <= j + num && j + num < Const.ImageSize.Width)
					{
						byte b = array[(i * Const.ImageSize.Width + j) * 4 + 3];
						byte b2 = array2[((i + num2) * Const.ImageSize.Width + (j + num)) * 4 + 3];
						if (b != 0 && b2 == 0)
						{
							array[(i * Const.ImageSize.Width + j) * 4 + 3] = array2[((i + num2) * Const.ImageSize.Width + (j + num)) * 4 + 3];
						}
					}
				}
			}
			Marshal.Copy(array, 0, bitmapData.Scan0, array.Length);
			bitmap.UnlockBits(bitmapData);
			this.Parts[partsID].WorkBitmap = bitmap;
		}

		public float Bound(float x)
		{
			if (x > 1f)
			{
				return 1f;
			}
			if (x < -1f)
			{
				return -1f;
			}
			return x;
		}

		private void btnSetDefault_Click(object sender, EventArgs e)
		{
			Settings.Default.PartsNo_face = this.Parts[0].CurrentNo;
			Settings.Default.PartsNo_neck = this.Parts[1].CurrentNo;
			Settings.Default.PartsNo_eye = this.Parts[2].CurrentNo;
			Settings.Default.PartsNo_iris = this.Parts[3].CurrentNo;
			Settings.Default.PartsNo_nose = this.Parts[4].CurrentNo;
			Settings.Default.PartsNo_mouth = this.Parts[5].CurrentNo;
			Settings.Default.PartsNo_brow = this.Parts[6].CurrentNo;
			Settings.Default.PartsNo_beard = this.Parts[7].CurrentNo;
			Settings.Default.PartsNo_ear = this.Parts[8].CurrentNo;
			Settings.Default.PartsNo_fhair = this.Parts[9].CurrentNo;
			Settings.Default.PartsNo_bhair = this.Parts[10].CurrentNo;
			Settings.Default.PartsNo_cloth = this.Parts[11].CurrentNo;
			Settings.Default.PartsNo_hat = this.Parts[12].CurrentNo;
			Settings.Default.PartsNo_acc = this.Parts[13].CurrentNo;
			Settings.Default.PartsNo_band = this.Parts[14].CurrentNo;
			Settings.Default.PartsNo_eye2 = this.Parts[15].CurrentNo;
			Settings.Default.PartsNo_mouth2 = this.Parts[16].CurrentNo;
			Settings.Default.PartsNo_fhair2 = this.Parts[17].CurrentNo;
			Settings.Default.PartsNo_shadow = this.Parts[18].CurrentNo;
			Settings.Default.PartsNo_bhair2 = this.Parts[19].CurrentNo;
			Settings.Default.PartsNo_bhair3 = this.Parts[20].CurrentNo;
			Settings.Default.PartsNo_cloth2 = this.Parts[21].CurrentNo;
			Settings.Default.PartsNo_hat2 = this.Parts[22].CurrentNo;
			Settings.Default.PartsNo_hat3 = this.Parts[23].CurrentNo;
			Settings.Default.ParentColor_face = this.Parts[0].colorParentPartsID;
			Settings.Default.ParentColor_neck = this.Parts[1].colorParentPartsID;
			Settings.Default.ParentColor_eye = this.Parts[2].colorParentPartsID;
			Settings.Default.ParentColor_iris = this.Parts[3].colorParentPartsID;
			Settings.Default.ParentColor_nose = this.Parts[4].colorParentPartsID;
			Settings.Default.ParentColor_mouth = this.Parts[5].colorParentPartsID;
			Settings.Default.ParentColor_brow = this.Parts[6].colorParentPartsID;
			Settings.Default.ParentColor_beard = this.Parts[7].colorParentPartsID;
			Settings.Default.ParentColor_ear = this.Parts[8].colorParentPartsID;
			Settings.Default.ParentColor_fhair = this.Parts[9].colorParentPartsID;
			Settings.Default.ParentColor_bhair = this.Parts[10].colorParentPartsID;
			Settings.Default.ParentColor_cloth = this.Parts[11].colorParentPartsID;
			Settings.Default.ParentColor_hat = this.Parts[12].colorParentPartsID;
			Settings.Default.ParentColor_acc = this.Parts[13].colorParentPartsID;
			Settings.Default.ParentColor_band = this.Parts[14].colorParentPartsID;
			Settings.Default.ParentColor_eye2 = this.Parts[15].colorParentPartsID;
			Settings.Default.ParentColor_mouth2 = this.Parts[16].colorParentPartsID;
			Settings.Default.ParentColor_fhair2 = this.Parts[17].colorParentPartsID;
			Settings.Default.ParentColor_shadow = this.Parts[18].colorParentPartsID;
			Settings.Default.ParentColor_bhair2 = this.Parts[19].colorParentPartsID;
			Settings.Default.ParentColor_bhair3 = this.Parts[20].colorParentPartsID;
			Settings.Default.ParentColor_cloth2 = this.Parts[21].colorParentPartsID;
			Settings.Default.ParentColor_hat2 = this.Parts[22].colorParentPartsID;
			Settings.Default.ParentColor_hat3 = this.Parts[23].colorParentPartsID;
			Settings.Default.ParentPos_face = this.Parts[0].positionParentPartsID;
			Settings.Default.ParentPos_neck = this.Parts[1].positionParentPartsID;
			Settings.Default.ParentPos_eye = this.Parts[2].positionParentPartsID;
			Settings.Default.ParentPos_iris = this.Parts[3].positionParentPartsID;
			Settings.Default.ParentPos_nose = this.Parts[4].positionParentPartsID;
			Settings.Default.ParentPos_mouth = this.Parts[5].positionParentPartsID;
			Settings.Default.ParentPos_brow = this.Parts[6].positionParentPartsID;
			Settings.Default.ParentPos_beard = this.Parts[7].positionParentPartsID;
			Settings.Default.ParentPos_ear = this.Parts[8].positionParentPartsID;
			Settings.Default.ParentPos_fhair = this.Parts[9].positionParentPartsID;
			Settings.Default.ParentPos_bhair = this.Parts[10].positionParentPartsID;
			Settings.Default.ParentPos_cloth = this.Parts[11].positionParentPartsID;
			Settings.Default.ParentPos_hat = this.Parts[12].positionParentPartsID;
			Settings.Default.ParentPos_acc = this.Parts[13].positionParentPartsID;
			Settings.Default.ParentPos_band = this.Parts[14].positionParentPartsID;
			Settings.Default.ParentPos_eye2 = this.Parts[15].positionParentPartsID;
			Settings.Default.ParentPos_mouth2 = this.Parts[16].positionParentPartsID;
			Settings.Default.ParentPos_fhair2 = this.Parts[17].positionParentPartsID;
			Settings.Default.ParentPos_shadow = this.Parts[18].positionParentPartsID;
			Settings.Default.ParentPos_bhair2 = this.Parts[19].positionParentPartsID;
			Settings.Default.ParentPos_bhair3 = this.Parts[20].positionParentPartsID;
			Settings.Default.ParentPos_cloth2 = this.Parts[21].positionParentPartsID;
			Settings.Default.ParentPos_hat2 = this.Parts[22].positionParentPartsID;
			Settings.Default.ParentPos_hat3 = this.Parts[23].positionParentPartsID;
			Settings.Default.Save();
		}

		private void btnDefault_Click(object sender, EventArgs e)
		{
			this.reloadImage = false;
			this.Parts[0].CurrentNo = Settings.Default.PartsNo_face;
			this.Parts[1].CurrentNo = Settings.Default.PartsNo_neck;
			this.Parts[2].CurrentNo = Settings.Default.PartsNo_eye;
			this.Parts[3].CurrentNo = Settings.Default.PartsNo_iris;
			this.Parts[4].CurrentNo = Settings.Default.PartsNo_nose;
			this.Parts[5].CurrentNo = Settings.Default.PartsNo_mouth;
			this.Parts[6].CurrentNo = Settings.Default.PartsNo_brow;
			this.Parts[7].CurrentNo = Settings.Default.PartsNo_beard;
			this.Parts[8].CurrentNo = Settings.Default.PartsNo_ear;
			this.Parts[9].CurrentNo = Settings.Default.PartsNo_fhair;
			this.Parts[10].CurrentNo = Settings.Default.PartsNo_bhair;
			this.Parts[11].CurrentNo = Settings.Default.PartsNo_cloth;
			this.Parts[12].CurrentNo = Settings.Default.PartsNo_hat;
			this.Parts[13].CurrentNo = Settings.Default.PartsNo_acc;
			this.Parts[14].CurrentNo = Settings.Default.PartsNo_band;
			this.Parts[15].CurrentNo = Settings.Default.PartsNo_eye2;
			this.Parts[16].CurrentNo = Settings.Default.PartsNo_mouth2;
			this.Parts[17].CurrentNo = Settings.Default.PartsNo_fhair2;
			this.Parts[18].CurrentNo = Settings.Default.PartsNo_shadow;
			this.Parts[19].CurrentNo = Settings.Default.PartsNo_bhair2;
			this.Parts[20].CurrentNo = Settings.Default.PartsNo_bhair3;
			this.Parts[21].CurrentNo = Settings.Default.PartsNo_cloth2;
			this.Parts[22].CurrentNo = Settings.Default.PartsNo_hat2;
			this.Parts[23].CurrentNo = Settings.Default.PartsNo_hat3;
			this.Parts[0].colorParentPartsID = Settings.Default.ParentColor_face;
			this.Parts[1].colorParentPartsID = Settings.Default.ParentColor_neck;
			this.Parts[2].colorParentPartsID = Settings.Default.ParentColor_eye;
			this.Parts[3].colorParentPartsID = Settings.Default.ParentColor_iris;
			this.Parts[4].colorParentPartsID = Settings.Default.ParentColor_nose;
			this.Parts[5].colorParentPartsID = Settings.Default.ParentColor_mouth;
			this.Parts[6].colorParentPartsID = Settings.Default.ParentColor_brow;
			this.Parts[7].colorParentPartsID = Settings.Default.ParentColor_beard;
			this.Parts[8].colorParentPartsID = Settings.Default.ParentColor_ear;
			this.Parts[9].colorParentPartsID = Settings.Default.ParentColor_fhair;
			this.Parts[10].colorParentPartsID = Settings.Default.ParentColor_bhair;
			this.Parts[11].colorParentPartsID = Settings.Default.ParentColor_cloth;
			this.Parts[12].colorParentPartsID = Settings.Default.ParentColor_hat;
			this.Parts[13].colorParentPartsID = Settings.Default.ParentColor_acc;
			this.Parts[14].colorParentPartsID = Settings.Default.ParentColor_band;
			this.Parts[15].colorParentPartsID = Settings.Default.ParentColor_eye2;
			this.Parts[16].colorParentPartsID = Settings.Default.ParentColor_mouth2;
			this.Parts[17].colorParentPartsID = Settings.Default.ParentColor_fhair2;
			this.Parts[18].colorParentPartsID = Settings.Default.ParentColor_shadow;
			this.Parts[19].colorParentPartsID = Settings.Default.ParentColor_bhair2;
			this.Parts[20].colorParentPartsID = Settings.Default.ParentColor_bhair3;
			this.Parts[21].colorParentPartsID = Settings.Default.ParentColor_cloth2;
			this.Parts[22].colorParentPartsID = Settings.Default.ParentColor_hat2;
			this.Parts[23].colorParentPartsID = Settings.Default.ParentColor_hat3;
			this.Parts[0].positionParentPartsID = Settings.Default.ParentPos_face;
			this.Parts[1].positionParentPartsID = Settings.Default.ParentPos_neck;
			this.Parts[2].positionParentPartsID = Settings.Default.ParentPos_eye;
			this.Parts[3].positionParentPartsID = Settings.Default.ParentPos_iris;
			this.Parts[4].positionParentPartsID = Settings.Default.ParentPos_nose;
			this.Parts[5].positionParentPartsID = Settings.Default.ParentPos_mouth;
			this.Parts[6].positionParentPartsID = Settings.Default.ParentPos_brow;
			this.Parts[7].positionParentPartsID = Settings.Default.ParentPos_beard;
			this.Parts[8].positionParentPartsID = Settings.Default.ParentPos_ear;
			this.Parts[9].positionParentPartsID = Settings.Default.ParentPos_fhair;
			this.Parts[10].positionParentPartsID = Settings.Default.ParentPos_bhair;
			this.Parts[11].positionParentPartsID = Settings.Default.ParentPos_cloth;
			this.Parts[12].positionParentPartsID = Settings.Default.ParentPos_hat;
			this.Parts[13].positionParentPartsID = Settings.Default.ParentPos_acc;
			this.Parts[14].positionParentPartsID = Settings.Default.ParentPos_band;
			this.Parts[15].positionParentPartsID = Settings.Default.ParentPos_eye2;
			this.Parts[16].positionParentPartsID = Settings.Default.ParentPos_mouth2;
			this.Parts[17].positionParentPartsID = Settings.Default.ParentPos_fhair2;
			this.Parts[18].positionParentPartsID = Settings.Default.ParentPos_shadow;
			this.Parts[19].positionParentPartsID = Settings.Default.ParentPos_bhair2;
			this.Parts[20].positionParentPartsID = Settings.Default.ParentPos_bhair3;
			this.Parts[21].positionParentPartsID = Settings.Default.ParentPos_cloth2;
			this.Parts[22].positionParentPartsID = Settings.Default.ParentPos_hat2;
			this.Parts[23].positionParentPartsID = Settings.Default.ParentPos_hat3;
			this.SetImage(0, 0, "face");
			this.SetImage(1, 1, "neck");
			this.SetImage(2, 2, "eye");
			this.SetImage(15, 2, "eyesh");
			this.SetImage(3, 3, "iris");
			this.SetImage(4, 4, "nose");
			this.SetImage(5, 5, "mouth");
			this.SetImage(16, 5, "mouthop");
			this.SetImage(6, 6, "brow");
			this.SetImage(7, 7, "beard");
			this.SetImage(8, 8, "ear");
			this.SetImage(9, 9, "fhair1");
			this.SetImage(17, 9, "fhair2");
			this.SetImage(18, 9, "shadow");
			this.SetImage(10, 10, "bhair1");
			this.SetImage(19, 10, "bhair2");
			this.SetImage(20, 10, "bhair3");
			this.SetImage(11, 11, "cloth1");
			this.SetImage(21, 11, "cloth2");
			this.SetImage(12, 12, "hat1");
			this.SetImage(22, 12, "hat2");
			this.SetImage(23, 12, "hat3");
			this.SetImage(13, 13, "acc");
			this.SetImage(14, 14, "band");
			this.DispPartsNo = this.Parts[this.DispPartsID].CurrentNo + 1;
			this.lblCurrentPartsNo.Text = this.DispPartsNo.ToString();
			this.cmbColorParent.SelectedIndex = this.Parts[this.DispPartsID].colorParentPartsID;
			this.cmbPositionParent.SelectedIndex = this.Parts[this.DispPartsID].positionParentPartsID;
			this.reloadImage = true;
			if (this.reloadImage)
			{
				this.ChangeColor(true);
				this.ChangeImageAlpha(3, 15);
				this.DrawImage();
			}
		}

		private void btnSaveSetting_Click(object sender, EventArgs e)
		{
			if (this.sfdSaveSetting.ShowDialog() == DialogResult.OK)
			{
				SettingConfigFile settingConfigFile = new SettingConfigFile(this.sfdSaveSetting.FileName);
				for (int i = 0; i < this.Parts.Count; i++)
				{
					settingConfigFile.WriteString(this.Parts[i].partsName, "partsNo", this.Parts[i].CurrentNo.ToString());
					settingConfigFile.WriteString(this.Parts[i].partsName, "X", this.Parts[i].Attribute.Position.X.ToString());
					settingConfigFile.WriteString(this.Parts[i].partsName, "Y", this.Parts[i].Attribute.Position.Y.ToString());
					settingConfigFile.WriteString(this.Parts[i].partsName, "Direction", this.Parts[i].Attribute.Position.Direction.ToString());
					settingConfigFile.WriteString(this.Parts[i].partsName, "Red", this.Parts[i].Attribute.Color.Red.ToString());
					settingConfigFile.WriteString(this.Parts[i].partsName, "Green", this.Parts[i].Attribute.Color.Green.ToString());
					settingConfigFile.WriteString(this.Parts[i].partsName, "Blue", this.Parts[i].Attribute.Color.Blue.ToString());
					settingConfigFile.WriteString(this.Parts[i].partsName, "Brightness", this.Parts[i].Attribute.Color.Brightness.ToString());
					settingConfigFile.WriteString(this.Parts[i].partsName, "Contrast", this.Parts[i].Attribute.Color.Contrast.ToString());
				}
			}
		}

		private void btnLoadSetting_Click(object sender, EventArgs e)
		{
			this.reloadImage = false;
			if (this.sfdLoadSetting.ShowDialog() == DialogResult.OK)
			{
				SettingConfigFile settingConfigFile = new SettingConfigFile(this.sfdLoadSetting.FileName);
				for (int i = 0; i < this.Parts.Count; i++)
				{
					this.Parts[i].CurrentNo = Tools.AnyToInt(settingConfigFile.ReadString(this.Parts[i].partsName, "partsNo"));
					this.Parts[i].Attribute.Position.X = Tools.AnyToInt(settingConfigFile.ReadString(this.Parts[i].partsName, "X"));
					this.Parts[i].Attribute.Position.Y = Tools.AnyToInt(settingConfigFile.ReadString(this.Parts[i].partsName, "Y"));
					this.Parts[i].Attribute.Position.Direction = Tools.AnyToInt(settingConfigFile.ReadString(this.Parts[i].partsName, "Direction"));
					this.Parts[i].Attribute.Color.Red = Tools.AnyToInt(settingConfigFile.ReadString(this.Parts[i].partsName, "Red"));
					this.Parts[i].Attribute.Color.Green = Tools.AnyToInt(settingConfigFile.ReadString(this.Parts[i].partsName, "Green"));
					this.Parts[i].Attribute.Color.Blue = Tools.AnyToInt(settingConfigFile.ReadString(this.Parts[i].partsName, "Blue"));
					this.Parts[i].Attribute.Color.Brightness = Tools.AnyToInt(settingConfigFile.ReadString(this.Parts[i].partsName, "Brightness"));
					this.Parts[i].Attribute.Color.Contrast = Tools.AnyToInt(settingConfigFile.ReadString(this.Parts[i].partsName, "Contrast"));
				}
				if (this.Parts[15].Attribute.Color.Red == 255)
				{
					for (int j = 0; j < this.Parts.Count; j++)
					{
						this.Parts[j].Attribute.Color.Red = this.Parts[j].Attribute.Color.Red * 100 / 255 - 100;
						this.Parts[j].Attribute.Color.Green = this.Parts[j].Attribute.Color.Green * 100 / 255 - 100;
						this.Parts[j].Attribute.Color.Blue = this.Parts[j].Attribute.Color.Blue * 100 / 255 - 100;
					}
				}
				this.SetImage(0, 0, "face");
				this.SetImage(1, 1, "neck");
				this.SetImage(2, 2, "eye");
				this.SetImage(15, 2, "eyesh");
				this.SetImage(3, 3, "iris");
				this.SetImage(4, 4, "nose");
				this.SetImage(5, 5, "mouth");
				this.SetImage(16, 5, "mouthop");
				this.SetImage(6, 6, "brow");
				this.SetImage(7, 7, "beard");
				this.SetImage(8, 8, "ear");
				this.SetImage(9, 9, "fhair1");
				this.SetImage(17, 9, "fhair2");
				this.SetImage(18, 9, "shadow");
				this.SetImage(10, 10, "bhair1");
				this.SetImage(19, 10, "bhair2");
				this.SetImage(20, 10, "bhair3");
				this.SetImage(11, 11, "cloth1");
				this.SetImage(21, 11, "cloth2");
				this.SetImage(12, 12, "hat1");
				this.SetImage(22, 12, "hat2");
				this.SetImage(23, 12, "hat3");
				this.SetImage(13, 13, "acc");
				this.SetImage(14, 14, "band");
				this.DispPartsID = this.cmbParts.SelectedIndex;
				this.DispPartsNo = this.Parts[this.DispPartsID].CurrentNo + 1;
				this.DispPartsTotal = this.Parts[this.DispPartsID].TotalPartsNum;
				this.DispRed = this.Parts[this.DispPartsID].Attribute.Color.Red;
				this.DispGreen = this.Parts[this.DispPartsID].Attribute.Color.Green;
				this.DispBlue = this.Parts[this.DispPartsID].Attribute.Color.Blue;
				this.DispBrightness = this.Parts[this.DispPartsID].Attribute.Color.Brightness;
				this.DispContrast = this.Parts[this.DispPartsID].Attribute.Color.Contrast;
				this.lblCurrentPartsNo.Text = this.DispPartsNo.ToString();
				this.lblTotalPartsCount.Text = this.DispPartsTotal.ToString();
				this.tbRed.Value = this.DispRed;
				this.tbGreen.Value = this.DispGreen;
				this.tbBlue.Value = this.DispBlue;
				this.tbBrightness.Value = this.DispBrightness;
				this.tbContrast.Value = this.DispContrast;
				this.txtRed.Text = this.DispRed.ToString();
				this.txtGreen.Text = this.DispGreen.ToString();
				this.txtBlue.Text = this.DispBlue.ToString();
				this.txtBrightness.Text = this.DispBrightness.ToString();
				this.txtContrast.Text = this.DispContrast.ToString();
				this.reloadImage = true;
				if (this.reloadImage)
				{
					this.ChangeImageAlpha(3, 15);
					this.DrawImage();
				}
			}
		}

		private void btnLoadWall_Click(object sender, EventArgs e)
		{
			if (this.sfdWallImage.ShowDialog() == DialogResult.OK)
			{
				this.WallBitmap.Dispose();
				this.WallBitmap = new Bitmap(this.sfdWallImage.FileName);
				this.ChangeImageAlpha(3, 15);
				this.DrawImage();
			}
		}
	}
}
