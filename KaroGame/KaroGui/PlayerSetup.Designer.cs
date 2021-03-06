﻿namespace Karo.Gui
{
    partial class PlayerSetup
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.mAfreespace = new System.Windows.Forms.RadioButton();
            this.mAbetterone = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.mPlayerAMoveNo = new System.Windows.Forms.RadioButton();
            this.mPlayerAMoveYes = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.mPlayerATransNo = new System.Windows.Forms.RadioButton();
            this.mPlayerATransYes = new System.Windows.Forms.RadioButton();
            this.playerA_PlieBox = new System.Windows.Forms.GroupBox();
            this.mPlayerAPlieDepth = new System.Windows.Forms.NumericUpDown();
            this.playerA_AlgoBox = new System.Windows.Forms.GroupBox();
            this.mPlayerAAlgoComboBox = new System.Windows.Forms.ComboBox();
            this.playerA_AIBox = new System.Windows.Forms.GroupBox();
            this.mPlayerAAINo = new System.Windows.Forms.RadioButton();
            this.mPlayerAAIYes = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.mBfreespace = new System.Windows.Forms.RadioButton();
            this.mBbetterone = new System.Windows.Forms.RadioButton();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.mPlayerBMoveNo = new System.Windows.Forms.RadioButton();
            this.mPlayerBMoveYes = new System.Windows.Forms.RadioButton();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.mPlayerBTransNo = new System.Windows.Forms.RadioButton();
            this.mPlayerBTransYes = new System.Windows.Forms.RadioButton();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.mPlayerBPlieDepth = new System.Windows.Forms.NumericUpDown();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.mPlayerBAlgoComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.mPlayerBAINo = new System.Windows.Forms.RadioButton();
            this.mPlayerBAIYes = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.mAIMoves = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.playerA_PlieBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mPlayerAPlieDepth)).BeginInit();
            this.playerA_AlgoBox.SuspendLayout();
            this.playerA_AIBox.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mPlayerBPlieDepth)).BeginInit();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mAIMoves)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.playerA_PlieBox);
            this.groupBox1.Controls.Add(this.playerA_AlgoBox);
            this.groupBox1.Controls.Add(this.playerA_AIBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 208);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player A";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.mAfreespace);
            this.groupBox4.Controls.Add(this.mAbetterone);
            this.groupBox4.Location = new System.Drawing.Point(141, 133);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(129, 72);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Evaluation function";
            // 
            // mAfreespace
            // 
            this.mAfreespace.AutoSize = true;
            this.mAfreespace.Location = new System.Drawing.Point(6, 43);
            this.mAfreespace.Name = "mAfreespace";
            this.mAfreespace.Size = new System.Drawing.Size(78, 17);
            this.mAfreespace.TabIndex = 1;
            this.mAfreespace.Text = "Free space";
            this.mAfreespace.UseVisualStyleBackColor = true;
            // 
            // mAbetterone
            // 
            this.mAbetterone.AutoSize = true;
            this.mAbetterone.Checked = true;
            this.mAbetterone.Location = new System.Drawing.Point(6, 20);
            this.mAbetterone.Name = "mAbetterone";
            this.mAbetterone.Size = new System.Drawing.Size(74, 17);
            this.mAbetterone.TabIndex = 0;
            this.mAbetterone.TabStop = true;
            this.mAbetterone.Text = "Better one";
            this.mAbetterone.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.mPlayerAMoveNo);
            this.groupBox6.Controls.Add(this.mPlayerAMoveYes);
            this.groupBox6.Location = new System.Drawing.Point(141, 76);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(129, 51);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Use move ordering";
            // 
            // mPlayerAMoveNo
            // 
            this.mPlayerAMoveNo.AutoSize = true;
            this.mPlayerAMoveNo.Checked = true;
            this.mPlayerAMoveNo.Location = new System.Drawing.Point(55, 20);
            this.mPlayerAMoveNo.Name = "mPlayerAMoveNo";
            this.mPlayerAMoveNo.Size = new System.Drawing.Size(39, 17);
            this.mPlayerAMoveNo.TabIndex = 1;
            this.mPlayerAMoveNo.TabStop = true;
            this.mPlayerAMoveNo.Text = "No";
            this.mPlayerAMoveNo.UseVisualStyleBackColor = true;
            // 
            // mPlayerAMoveYes
            // 
            this.mPlayerAMoveYes.AutoSize = true;
            this.mPlayerAMoveYes.Location = new System.Drawing.Point(6, 20);
            this.mPlayerAMoveYes.Name = "mPlayerAMoveYes";
            this.mPlayerAMoveYes.Size = new System.Drawing.Size(43, 17);
            this.mPlayerAMoveYes.TabIndex = 0;
            this.mPlayerAMoveYes.Text = "Yes";
            this.mPlayerAMoveYes.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.mPlayerATransNo);
            this.groupBox5.Controls.Add(this.mPlayerATransYes);
            this.groupBox5.Location = new System.Drawing.Point(141, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(129, 51);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Use transposition table";
            // 
            // mPlayerATransNo
            // 
            this.mPlayerATransNo.AutoSize = true;
            this.mPlayerATransNo.Checked = true;
            this.mPlayerATransNo.Location = new System.Drawing.Point(55, 20);
            this.mPlayerATransNo.Name = "mPlayerATransNo";
            this.mPlayerATransNo.Size = new System.Drawing.Size(39, 17);
            this.mPlayerATransNo.TabIndex = 1;
            this.mPlayerATransNo.TabStop = true;
            this.mPlayerATransNo.Text = "No";
            this.mPlayerATransNo.UseVisualStyleBackColor = true;
            // 
            // mPlayerATransYes
            // 
            this.mPlayerATransYes.AutoSize = true;
            this.mPlayerATransYes.Location = new System.Drawing.Point(6, 20);
            this.mPlayerATransYes.Name = "mPlayerATransYes";
            this.mPlayerATransYes.Size = new System.Drawing.Size(43, 17);
            this.mPlayerATransYes.TabIndex = 0;
            this.mPlayerATransYes.Text = "Yes";
            this.mPlayerATransYes.UseVisualStyleBackColor = true;
            // 
            // playerA_PlieBox
            // 
            this.playerA_PlieBox.Controls.Add(this.mPlayerAPlieDepth);
            this.playerA_PlieBox.Location = new System.Drawing.Point(6, 133);
            this.playerA_PlieBox.Name = "playerA_PlieBox";
            this.playerA_PlieBox.Size = new System.Drawing.Size(129, 49);
            this.playerA_PlieBox.TabIndex = 15;
            this.playerA_PlieBox.TabStop = false;
            this.playerA_PlieBox.Text = "Plie depth";
            // 
            // mPlayerAPlieDepth
            // 
            this.mPlayerAPlieDepth.Location = new System.Drawing.Point(6, 19);
            this.mPlayerAPlieDepth.Name = "mPlayerAPlieDepth";
            this.mPlayerAPlieDepth.Size = new System.Drawing.Size(117, 20);
            this.mPlayerAPlieDepth.TabIndex = 5;
            this.mPlayerAPlieDepth.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // playerA_AlgoBox
            // 
            this.playerA_AlgoBox.Controls.Add(this.mPlayerAAlgoComboBox);
            this.playerA_AlgoBox.Location = new System.Drawing.Point(6, 76);
            this.playerA_AlgoBox.Name = "playerA_AlgoBox";
            this.playerA_AlgoBox.Size = new System.Drawing.Size(129, 51);
            this.playerA_AlgoBox.TabIndex = 14;
            this.playerA_AlgoBox.TabStop = false;
            this.playerA_AlgoBox.Text = "Algorithm";
            // 
            // mPlayerAAlgoComboBox
            // 
            this.mPlayerAAlgoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mPlayerAAlgoComboBox.FormattingEnabled = true;
            this.mPlayerAAlgoComboBox.Items.AddRange(new object[] {
            "Random",
            "MiniMax",
            "AlphaBeta"});
            this.mPlayerAAlgoComboBox.Location = new System.Drawing.Point(6, 19);
            this.mPlayerAAlgoComboBox.Name = "mPlayerAAlgoComboBox";
            this.mPlayerAAlgoComboBox.Size = new System.Drawing.Size(119, 21);
            this.mPlayerAAlgoComboBox.TabIndex = 4;
            // 
            // playerA_AIBox
            // 
            this.playerA_AIBox.Controls.Add(this.mPlayerAAINo);
            this.playerA_AIBox.Controls.Add(this.mPlayerAAIYes);
            this.playerA_AIBox.Location = new System.Drawing.Point(6, 19);
            this.playerA_AIBox.Name = "playerA_AIBox";
            this.playerA_AIBox.Size = new System.Drawing.Size(129, 51);
            this.playerA_AIBox.TabIndex = 13;
            this.playerA_AIBox.TabStop = false;
            this.playerA_AIBox.Text = "AI player";
            // 
            // mPlayerAAINo
            // 
            this.mPlayerAAINo.AutoSize = true;
            this.mPlayerAAINo.Location = new System.Drawing.Point(55, 20);
            this.mPlayerAAINo.Name = "mPlayerAAINo";
            this.mPlayerAAINo.Size = new System.Drawing.Size(39, 17);
            this.mPlayerAAINo.TabIndex = 1;
            this.mPlayerAAINo.Text = "No";
            this.mPlayerAAINo.UseVisualStyleBackColor = true;
            // 
            // mPlayerAAIYes
            // 
            this.mPlayerAAIYes.AutoSize = true;
            this.mPlayerAAIYes.Checked = true;
            this.mPlayerAAIYes.Location = new System.Drawing.Point(6, 20);
            this.mPlayerAAIYes.Name = "mPlayerAAIYes";
            this.mPlayerAAIYes.Size = new System.Drawing.Size(43, 17);
            this.mPlayerAAIYes.TabIndex = 0;
            this.mPlayerAAIYes.TabStop = true;
            this.mPlayerAAIYes.Text = "Yes";
            this.mPlayerAAIYes.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(414, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Accept);
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.button3.Location = new System.Drawing.Point(495, 276);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Exit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Close);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(306, 276);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 16;
            this.button4.Text = "Reset";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.ResetFields);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.groupBox13);
            this.groupBox7.Controls.Add(this.groupBox8);
            this.groupBox7.Controls.Add(this.groupBox9);
            this.groupBox7.Controls.Add(this.groupBox10);
            this.groupBox7.Controls.Add(this.groupBox11);
            this.groupBox7.Controls.Add(this.groupBox12);
            this.groupBox7.Location = new System.Drawing.Point(294, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(276, 208);
            this.groupBox7.TabIndex = 16;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Player B";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.mBfreespace);
            this.groupBox13.Controls.Add(this.mBbetterone);
            this.groupBox13.Location = new System.Drawing.Point(141, 133);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(129, 72);
            this.groupBox13.TabIndex = 16;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Evaluation function";
            // 
            // mBfreespace
            // 
            this.mBfreespace.AutoSize = true;
            this.mBfreespace.Location = new System.Drawing.Point(6, 43);
            this.mBfreespace.Name = "mBfreespace";
            this.mBfreespace.Size = new System.Drawing.Size(78, 17);
            this.mBfreespace.TabIndex = 1;
            this.mBfreespace.Text = "Free space";
            this.mBfreespace.UseVisualStyleBackColor = true;
            // 
            // mBbetterone
            // 
            this.mBbetterone.AutoSize = true;
            this.mBbetterone.Checked = true;
            this.mBbetterone.Location = new System.Drawing.Point(6, 20);
            this.mBbetterone.Name = "mBbetterone";
            this.mBbetterone.Size = new System.Drawing.Size(74, 17);
            this.mBbetterone.TabIndex = 0;
            this.mBbetterone.TabStop = true;
            this.mBbetterone.Text = "Better one";
            this.mBbetterone.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.mPlayerBMoveNo);
            this.groupBox8.Controls.Add(this.mPlayerBMoveYes);
            this.groupBox8.Location = new System.Drawing.Point(141, 76);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(129, 51);
            this.groupBox8.TabIndex = 14;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Use move ordering";
            // 
            // mPlayerBMoveNo
            // 
            this.mPlayerBMoveNo.AutoSize = true;
            this.mPlayerBMoveNo.Checked = true;
            this.mPlayerBMoveNo.Location = new System.Drawing.Point(55, 20);
            this.mPlayerBMoveNo.Name = "mPlayerBMoveNo";
            this.mPlayerBMoveNo.Size = new System.Drawing.Size(39, 17);
            this.mPlayerBMoveNo.TabIndex = 1;
            this.mPlayerBMoveNo.TabStop = true;
            this.mPlayerBMoveNo.Text = "No";
            this.mPlayerBMoveNo.UseVisualStyleBackColor = true;
            // 
            // mPlayerBMoveYes
            // 
            this.mPlayerBMoveYes.AutoSize = true;
            this.mPlayerBMoveYes.Location = new System.Drawing.Point(6, 20);
            this.mPlayerBMoveYes.Name = "mPlayerBMoveYes";
            this.mPlayerBMoveYes.Size = new System.Drawing.Size(43, 17);
            this.mPlayerBMoveYes.TabIndex = 0;
            this.mPlayerBMoveYes.Text = "Yes";
            this.mPlayerBMoveYes.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.mPlayerBTransNo);
            this.groupBox9.Controls.Add(this.mPlayerBTransYes);
            this.groupBox9.Location = new System.Drawing.Point(141, 19);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(129, 51);
            this.groupBox9.TabIndex = 14;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Use transposition table";
            // 
            // mPlayerBTransNo
            // 
            this.mPlayerBTransNo.AutoSize = true;
            this.mPlayerBTransNo.Location = new System.Drawing.Point(55, 20);
            this.mPlayerBTransNo.Name = "mPlayerBTransNo";
            this.mPlayerBTransNo.Size = new System.Drawing.Size(39, 17);
            this.mPlayerBTransNo.TabIndex = 1;
            this.mPlayerBTransNo.Text = "No";
            this.mPlayerBTransNo.UseVisualStyleBackColor = true;
            // 
            // mPlayerBTransYes
            // 
            this.mPlayerBTransYes.AutoSize = true;
            this.mPlayerBTransYes.Checked = true;
            this.mPlayerBTransYes.Location = new System.Drawing.Point(6, 20);
            this.mPlayerBTransYes.Name = "mPlayerBTransYes";
            this.mPlayerBTransYes.Size = new System.Drawing.Size(43, 17);
            this.mPlayerBTransYes.TabIndex = 0;
            this.mPlayerBTransYes.TabStop = true;
            this.mPlayerBTransYes.Text = "Yes";
            this.mPlayerBTransYes.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.mPlayerBPlieDepth);
            this.groupBox10.Location = new System.Drawing.Point(6, 133);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(129, 49);
            this.groupBox10.TabIndex = 15;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Plie depth";
            // 
            // mPlayerBPlieDepth
            // 
            this.mPlayerBPlieDepth.Location = new System.Drawing.Point(6, 19);
            this.mPlayerBPlieDepth.Name = "mPlayerBPlieDepth";
            this.mPlayerBPlieDepth.Size = new System.Drawing.Size(117, 20);
            this.mPlayerBPlieDepth.TabIndex = 5;
            this.mPlayerBPlieDepth.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.mPlayerBAlgoComboBox);
            this.groupBox11.Location = new System.Drawing.Point(6, 76);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(129, 51);
            this.groupBox11.TabIndex = 14;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Algorithm";
            // 
            // mPlayerBAlgoComboBox
            // 
            this.mPlayerBAlgoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mPlayerBAlgoComboBox.FormattingEnabled = true;
            this.mPlayerBAlgoComboBox.Items.AddRange(new object[] {
            "Random",
            "MiniMax",
            "AlphaBeta"});
            this.mPlayerBAlgoComboBox.Location = new System.Drawing.Point(6, 19);
            this.mPlayerBAlgoComboBox.Name = "mPlayerBAlgoComboBox";
            this.mPlayerBAlgoComboBox.Size = new System.Drawing.Size(119, 21);
            this.mPlayerBAlgoComboBox.TabIndex = 4;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.mPlayerBAINo);
            this.groupBox12.Controls.Add(this.mPlayerBAIYes);
            this.groupBox12.Location = new System.Drawing.Point(6, 19);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(129, 51);
            this.groupBox12.TabIndex = 13;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "AI player";
            // 
            // mPlayerBAINo
            // 
            this.mPlayerBAINo.AutoSize = true;
            this.mPlayerBAINo.Location = new System.Drawing.Point(55, 20);
            this.mPlayerBAINo.Name = "mPlayerBAINo";
            this.mPlayerBAINo.Size = new System.Drawing.Size(39, 17);
            this.mPlayerBAINo.TabIndex = 1;
            this.mPlayerBAINo.Text = "No";
            this.mPlayerBAINo.UseVisualStyleBackColor = true;
            // 
            // mPlayerBAIYes
            // 
            this.mPlayerBAIYes.AutoSize = true;
            this.mPlayerBAIYes.Checked = true;
            this.mPlayerBAIYes.Location = new System.Drawing.Point(6, 20);
            this.mPlayerBAIYes.Name = "mPlayerBAIYes";
            this.mPlayerBAIYes.Size = new System.Drawing.Size(43, 17);
            this.mPlayerBAIYes.TabIndex = 0;
            this.mPlayerBAIYes.TabStop = true;
            this.mPlayerBAIYes.Text = "Yes";
            this.mPlayerBAIYes.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.mAIMoves);
            this.groupBox2.Location = new System.Drawing.Point(12, 226);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 73);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Engine behaviour";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Refreshrate (ms)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Max ai moves";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(115, 45);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(117, 20);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // mAIMoves
            // 
            this.mAIMoves.Location = new System.Drawing.Point(115, 19);
            this.mAIMoves.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.mAIMoves.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mAIMoves.Name = "mAIMoves";
            this.mAIMoves.Size = new System.Drawing.Size(117, 20);
            this.mAIMoves.TabIndex = 6;
            this.mAIMoves.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // PlayerSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 305);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(593, 341);
            this.MinimumSize = new System.Drawing.Size(593, 341);
            this.Name = "PlayerSetup";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Player setup";
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.playerA_PlieBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mPlayerAPlieDepth)).EndInit();
            this.playerA_AlgoBox.ResumeLayout(false);
            this.playerA_AIBox.ResumeLayout(false);
            this.playerA_AIBox.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mPlayerBPlieDepth)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mAIMoves)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton mPlayerAAINo;
        private System.Windows.Forms.RadioButton mPlayerAAIYes;
        private System.Windows.Forms.ComboBox mPlayerAAlgoComboBox;
        private System.Windows.Forms.NumericUpDown mPlayerAPlieDepth;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton mPlayerAMoveNo;
        private System.Windows.Forms.RadioButton mPlayerAMoveYes;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton mPlayerATransNo;
        private System.Windows.Forms.RadioButton mPlayerATransYes;
        private System.Windows.Forms.GroupBox playerA_PlieBox;
        private System.Windows.Forms.GroupBox playerA_AlgoBox;
        private System.Windows.Forms.GroupBox playerA_AIBox;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RadioButton mPlayerBMoveNo;
        private System.Windows.Forms.RadioButton mPlayerBMoveYes;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RadioButton mPlayerBTransNo;
        private System.Windows.Forms.RadioButton mPlayerBTransYes;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.NumericUpDown mPlayerBPlieDepth;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.ComboBox mPlayerBAlgoComboBox;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.RadioButton mPlayerBAINo;
        private System.Windows.Forms.RadioButton mPlayerBAIYes;
        private System.Windows.Forms.NumericUpDown mAIMoves;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton mAfreespace;
        private System.Windows.Forms.RadioButton mAbetterone;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.RadioButton mBfreespace;
        private System.Windows.Forms.RadioButton mBbetterone;
    }
}