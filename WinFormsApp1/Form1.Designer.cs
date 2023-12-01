﻿namespace WinFormsApp1
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            openImgBtn = new Button();
            saveImgBtn = new Button();
            panel1 = new Panel();
            openFileDialog1 = new OpenFileDialog();
            imgName = new TextBox();
            newImgName = new TextBox();
            X_label = new Label();
            Y_label = new Label();
            gray_label = new Label();
            YValueTextBox = new TextBox();
            XValueTextBox = new TextBox();
            pixelValueTextBox = new TextBox();
            pixelInfoGroup = new GroupBox();
            functionBtnGroup = new GroupBox();
            parameterFileGroup = new GroupBox();
            openParameterFilePathLabel = new TextBox();
            openParameterFileBtn = new Button();
            saveParameterLabel = new TextBox();
            saveParameterBtn = new Button();
            label13 = new Label();
            ConsoleGroupBox = new GroupBox();
            consoleLabel = new Label();
            rotateBtn_test = new Button();
            label6 = new Label();
            rotateAngleTextBox = new TextBox();
            elementImgBtn = new Button();
            findElementBtn = new Button();
            elementImgPanel = new Panel();
            TabGroup = new TabControl();
            tabPage1 = new TabPage();
            rotateBtn = new Button();
            numericUpDown1 = new NumericUpDown();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            label14 = new Label();
            label15 = new Label();
            button1 = new Button();
            tabControl1 = new TabControl();
            tabPage5 = new TabPage();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            label19 = new Label();
            hScrollBar1 = new HScrollBar();
            hScrollBar2 = new HScrollBar();
            tabPage6 = new TabPage();
            label20 = new Label();
            tabPage2 = new TabPage();
            FindContoursWayComboBox = new ComboBox();
            blobDetect_Dilate_Erode_Mask_Size_NumericUpDown = new NumericUpDown();
            label12 = new Label();
            blobDetect_ErodeFlagCheckBox = new CheckBox();
            blob_AreaRatioLabel = new Label();
            label9 = new Label();
            blobDetect_DilateFlagCheckBox = new CheckBox();
            blobAreaRatioBar = new HScrollBar();
            blob_maxRadiusLabel = new Label();
            label11 = new Label();
            label10 = new Label();
            blob_maxRadiusBar = new HScrollBar();
            label7 = new Label();
            blob_minRadiusLabel = new Label();
            label8 = new Label();
            blob_minRadiusBar = new HScrollBar();
            blob_maxAreaLabel = new Label();
            label5 = new Label();
            blobDetect_binaryImg = new Button();
            blobDetect_imgBinaryTabCtrl = new TabControl();
            tabPage4 = new TabPage();
            label4 = new Label();
            label2 = new Label();
            blobDetect_InRangeLowerBoundLabel = new Label();
            blobDetect_InRangeUpperBoundLabel = new Label();
            blobDetect_InRangeLowerBoundScrollBar = new HScrollBar();
            blobDetect_InRangeUpperBoundScrollBar = new HScrollBar();
            tabPage3 = new TabPage();
            blob_maxAreaBar = new HScrollBar();
            label3 = new Label();
            blobDetectButton = new Button();
            saveGroup = new GroupBox();
            label1 = new Label();
            targetImgPanel = new Panel();
            targetImgBtn = new Button();
            cropImgBtn = new Button();
            findTargetBtn = new Button();
            rectangleBtn = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            pixelInfoGroup.SuspendLayout();
            functionBtnGroup.SuspendLayout();
            parameterFileGroup.SuspendLayout();
            ConsoleGroupBox.SuspendLayout();
            TabGroup.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage5.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)blobDetect_Dilate_Erode_Mask_Size_NumericUpDown).BeginInit();
            blobDetect_imgBinaryTabCtrl.SuspendLayout();
            tabPage4.SuspendLayout();
            saveGroup.SuspendLayout();
            SuspendLayout();
            // 
            // openImgBtn
            // 
            openImgBtn.Location = new Point(15, 22);
            openImgBtn.Name = "openImgBtn";
            openImgBtn.Size = new Size(88, 28);
            openImgBtn.TabIndex = 0;
            openImgBtn.Text = "開啟影像";
            openImgBtn.UseVisualStyleBackColor = true;
            openImgBtn.Click += openImgBtn_Click;
            // 
            // saveImgBtn
            // 
            saveImgBtn.Location = new Point(368, 46);
            saveImgBtn.Name = "saveImgBtn";
            saveImgBtn.Size = new Size(81, 23);
            saveImgBtn.TabIndex = 1;
            saveImgBtn.Text = "儲存影像";
            saveImgBtn.UseVisualStyleBackColor = true;
            saveImgBtn.Click += saveImgBtn_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(542, 427);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            panel1.MouseUp += panel1_MouseUp;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // imgName
            // 
            imgName.Enabled = false;
            imgName.Location = new Point(5, 20);
            imgName.Name = "imgName";
            imgName.Size = new Size(446, 23);
            imgName.TabIndex = 3;
            // 
            // newImgName
            // 
            newImgName.AccessibleName = "";
            newImgName.Location = new Point(6, 46);
            newImgName.Name = "newImgName";
            newImgName.Size = new Size(315, 23);
            newImgName.TabIndex = 4;
            newImgName.Text = "newImgName";
            // 
            // X_label
            // 
            X_label.AutoSize = true;
            X_label.Location = new Point(7, 24);
            X_label.Name = "X_label";
            X_label.Size = new Size(39, 15);
            X_label.TabIndex = 5;
            X_label.Text = "X座標";
            // 
            // Y_label
            // 
            Y_label.AutoSize = true;
            Y_label.Location = new Point(111, 24);
            Y_label.Name = "Y_label";
            Y_label.Size = new Size(38, 15);
            Y_label.TabIndex = 6;
            Y_label.Text = "Y座標";
            // 
            // gray_label
            // 
            gray_label.AutoSize = true;
            gray_label.Location = new Point(214, 24);
            gray_label.Name = "gray_label";
            gray_label.Size = new Size(43, 15);
            gray_label.TabIndex = 7;
            gray_label.Text = "灰階值";
            // 
            // YValueTextBox
            // 
            YValueTextBox.Location = new Point(155, 21);
            YValueTextBox.Name = "YValueTextBox";
            YValueTextBox.Size = new Size(43, 23);
            YValueTextBox.TabIndex = 8;
            // 
            // XValueTextBox
            // 
            XValueTextBox.Location = new Point(52, 21);
            XValueTextBox.Name = "XValueTextBox";
            XValueTextBox.Size = new Size(43, 23);
            XValueTextBox.TabIndex = 9;
            // 
            // pixelValueTextBox
            // 
            pixelValueTextBox.Location = new Point(263, 21);
            pixelValueTextBox.Name = "pixelValueTextBox";
            pixelValueTextBox.Size = new Size(167, 23);
            pixelValueTextBox.TabIndex = 10;
            // 
            // pixelInfoGroup
            // 
            pixelInfoGroup.Controls.Add(YValueTextBox);
            pixelInfoGroup.Controls.Add(pixelValueTextBox);
            pixelInfoGroup.Controls.Add(gray_label);
            pixelInfoGroup.Controls.Add(Y_label);
            pixelInfoGroup.Controls.Add(XValueTextBox);
            pixelInfoGroup.Controls.Add(X_label);
            pixelInfoGroup.Location = new Point(12, 527);
            pixelInfoGroup.Name = "pixelInfoGroup";
            pixelInfoGroup.Size = new Size(450, 60);
            pixelInfoGroup.TabIndex = 11;
            pixelInfoGroup.TabStop = false;
            pixelInfoGroup.Text = "pixel info";
            // 
            // functionBtnGroup
            // 
            functionBtnGroup.Controls.Add(parameterFileGroup);
            functionBtnGroup.Controls.Add(ConsoleGroupBox);
            functionBtnGroup.Controls.Add(rotateBtn_test);
            functionBtnGroup.Controls.Add(label6);
            functionBtnGroup.Controls.Add(rotateAngleTextBox);
            functionBtnGroup.Controls.Add(elementImgBtn);
            functionBtnGroup.Controls.Add(findElementBtn);
            functionBtnGroup.Controls.Add(elementImgPanel);
            functionBtnGroup.Controls.Add(TabGroup);
            functionBtnGroup.Controls.Add(saveGroup);
            functionBtnGroup.Controls.Add(targetImgPanel);
            functionBtnGroup.Controls.Add(targetImgBtn);
            functionBtnGroup.Controls.Add(cropImgBtn);
            functionBtnGroup.Controls.Add(findTargetBtn);
            functionBtnGroup.Controls.Add(rectangleBtn);
            functionBtnGroup.Controls.Add(openImgBtn);
            functionBtnGroup.Location = new Point(612, 20);
            functionBtnGroup.Name = "functionBtnGroup";
            functionBtnGroup.Size = new Size(852, 928);
            functionBtnGroup.TabIndex = 12;
            functionBtnGroup.TabStop = false;
            functionBtnGroup.Text = "functionBtnGroup";
            // 
            // parameterFileGroup
            // 
            parameterFileGroup.Controls.Add(openParameterFilePathLabel);
            parameterFileGroup.Controls.Add(openParameterFileBtn);
            parameterFileGroup.Controls.Add(saveParameterLabel);
            parameterFileGroup.Controls.Add(saveParameterBtn);
            parameterFileGroup.Controls.Add(label13);
            parameterFileGroup.Location = new Point(513, 783);
            parameterFileGroup.Name = "parameterFileGroup";
            parameterFileGroup.Size = new Size(288, 77);
            parameterFileGroup.TabIndex = 27;
            parameterFileGroup.TabStop = false;
            parameterFileGroup.Text = "參數檔案";
            // 
            // openParameterFilePathLabel
            // 
            openParameterFilePathLabel.AccessibleName = "";
            openParameterFilePathLabel.Enabled = false;
            openParameterFilePathLabel.Location = new Point(10, 14);
            openParameterFilePathLabel.Name = "openParameterFilePathLabel";
            openParameterFilePathLabel.Size = new Size(175, 23);
            openParameterFilePathLabel.TabIndex = 28;
            // 
            // openParameterFileBtn
            // 
            openParameterFileBtn.Location = new Point(191, 14);
            openParameterFileBtn.Name = "openParameterFileBtn";
            openParameterFileBtn.Size = new Size(90, 25);
            openParameterFileBtn.TabIndex = 27;
            openParameterFileBtn.Text = "開啟參數檔";
            openParameterFileBtn.UseVisualStyleBackColor = true;
            openParameterFileBtn.Click += openParameterFileBtn_Click;
            // 
            // saveParameterLabel
            // 
            saveParameterLabel.AccessibleName = "";
            saveParameterLabel.Location = new Point(10, 48);
            saveParameterLabel.Name = "saveParameterLabel";
            saveParameterLabel.Size = new Size(151, 23);
            saveParameterLabel.TabIndex = 6;
            saveParameterLabel.Text = "iniFileName";
            // 
            // saveParameterBtn
            // 
            saveParameterBtn.Location = new Point(192, 46);
            saveParameterBtn.Name = "saveParameterBtn";
            saveParameterBtn.Size = new Size(90, 25);
            saveParameterBtn.TabIndex = 26;
            saveParameterBtn.Text = "儲存當前參數";
            saveParameterBtn.UseVisualStyleBackColor = true;
            saveParameterBtn.Click += saveParameterBtn_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(158, 56);
            label13.Name = "label13";
            label13.Size = new Size(23, 15);
            label13.TabIndex = 7;
            label13.Text = ".ini";
            // 
            // ConsoleGroupBox
            // 
            ConsoleGroupBox.Controls.Add(consoleLabel);
            ConsoleGroupBox.Location = new Point(482, 480);
            ConsoleGroupBox.Name = "ConsoleGroupBox";
            ConsoleGroupBox.Size = new Size(288, 267);
            ConsoleGroupBox.TabIndex = 24;
            ConsoleGroupBox.TabStop = false;
            ConsoleGroupBox.Text = "Console";
            // 
            // consoleLabel
            // 
            consoleLabel.AutoSize = true;
            consoleLabel.Location = new Point(6, 23);
            consoleLabel.Name = "consoleLabel";
            consoleLabel.Size = new Size(27, 15);
            consoleLabel.TabIndex = 32;
            consoleLabel.Text = "null";
            // 
            // rotateBtn_test
            // 
            rotateBtn_test.Location = new Point(100, 172);
            rotateBtn_test.Name = "rotateBtn_test";
            rotateBtn_test.Size = new Size(42, 23);
            rotateBtn_test.TabIndex = 23;
            rotateBtn_test.Text = "旋轉";
            rotateBtn_test.UseVisualStyleBackColor = true;
            rotateBtn_test.Click += rotateBtn_test_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 154);
            label6.Name = "label6";
            label6.Size = new Size(55, 15);
            label6.TabIndex = 22;
            label6.Text = "旋轉角度";
            // 
            // rotateAngleTextBox
            // 
            rotateAngleTextBox.Location = new Point(15, 172);
            rotateAngleTextBox.Name = "rotateAngleTextBox";
            rotateAngleTextBox.Size = new Size(79, 23);
            rotateAngleTextBox.TabIndex = 21;
            rotateAngleTextBox.Text = "0";
            rotateAngleTextBox.TextChanged += rotateAngleTextBox_TextChanged;
            // 
            // elementImgBtn
            // 
            elementImgBtn.Location = new Point(523, 22);
            elementImgBtn.Name = "elementImgBtn";
            elementImgBtn.Size = new Size(88, 28);
            elementImgBtn.TabIndex = 20;
            elementImgBtn.Text = "開啟元件影像";
            elementImgBtn.UseVisualStyleBackColor = true;
            elementImgBtn.Click += elementImgBtn_Click;
            // 
            // findElementBtn
            // 
            findElementBtn.Location = new Point(523, 62);
            findElementBtn.Name = "findElementBtn";
            findElementBtn.Size = new Size(89, 28);
            findElementBtn.TabIndex = 19;
            findElementBtn.Text = "找元件";
            findElementBtn.UseVisualStyleBackColor = true;
            findElementBtn.Click += findElementBtn_Click;
            // 
            // elementImgPanel
            // 
            elementImgPanel.BackColor = SystemColors.ControlDark;
            elementImgPanel.Location = new Point(617, 22);
            elementImgPanel.Name = "elementImgPanel";
            elementImgPanel.Size = new Size(206, 185);
            elementImgPanel.TabIndex = 15;
            // 
            // TabGroup
            // 
            TabGroup.Controls.Add(tabPage1);
            TabGroup.Controls.Add(tabPage2);
            TabGroup.Location = new Point(13, 226);
            TabGroup.Margin = new Padding(2);
            TabGroup.Name = "TabGroup";
            TabGroup.SelectedIndex = 0;
            TabGroup.Size = new Size(451, 521);
            TabGroup.TabIndex = 16;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(rotateBtn);
            tabPage1.Controls.Add(numericUpDown1);
            tabPage1.Controls.Add(checkBox1);
            tabPage1.Controls.Add(checkBox2);
            tabPage1.Controls.Add(label14);
            tabPage1.Controls.Add(label15);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(tabControl1);
            tabPage1.Controls.Add(label20);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(443, 493);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "轉正";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // rotateBtn
            // 
            rotateBtn.Location = new Point(344, 459);
            rotateBtn.Name = "rotateBtn";
            rotateBtn.Size = new Size(88, 28);
            rotateBtn.TabIndex = 34;
            rotateBtn.Text = "轉正";
            rotateBtn.UseVisualStyleBackColor = true;
            rotateBtn.Click += rotateBtn_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown1.Location = new Point(201, 183);
            numericUpDown1.Maximum = new decimal(new int[] { 17, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(74, 23);
            numericUpDown1.TabIndex = 33;
            numericUpDown1.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(66, 187);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(50, 19);
            checkBox1.TabIndex = 32;
            checkBox1.Text = "侵蝕";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(10, 187);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(50, 19);
            checkBox2.TabIndex = 31;
            checkBox2.Text = "膨脹";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(132, 188);
            label14.Name = "label14";
            label14.Size = new Size(63, 15);
            label14.TabIndex = 30;
            label14.Text = "mask 大小";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(6, 166);
            label15.Name = "label15";
            label15.Size = new Size(103, 15);
            label15.TabIndex = 29;
            label15.Text = "二值化膨脹與侵蝕";
            // 
            // button1
            // 
            button1.Location = new Point(344, 178);
            button1.Name = "button1";
            button1.Size = new Size(88, 28);
            button1.TabIndex = 26;
            button1.Text = "二值化測試";
            button1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage6);
            tabControl1.Location = new Point(6, 20);
            tabControl1.Margin = new Padding(2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(377, 144);
            tabControl1.TabIndex = 28;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(label16);
            tabPage5.Controls.Add(label17);
            tabPage5.Controls.Add(label18);
            tabPage5.Controls.Add(label19);
            tabPage5.Controls.Add(hScrollBar1);
            tabPage5.Controls.Add(hScrollBar2);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Margin = new Padding(2);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(2);
            tabPage5.Size = new Size(369, 116);
            tabPage5.TabIndex = 1;
            tabPage5.Text = "InRange";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(13, 65);
            label16.Name = "label16";
            label16.Size = new Size(79, 15);
            label16.TabIndex = 20;
            label16.Text = "lower bound";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(13, 7);
            label17.Name = "label17";
            label17.Size = new Size(82, 15);
            label17.TabIndex = 19;
            label17.Text = "upper bound";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(319, 87);
            label18.Margin = new Padding(2, 0, 2, 0);
            label18.Name = "label18";
            label18.Size = new Size(21, 15);
            label18.TabIndex = 4;
            label18.Text = "50";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(319, 29);
            label19.Margin = new Padding(2, 0, 2, 0);
            label19.Name = "label19";
            label19.Size = new Size(28, 15);
            label19.TabIndex = 3;
            label19.Text = "200";
            // 
            // hScrollBar1
            // 
            hScrollBar1.LargeChange = 1;
            hScrollBar1.Location = new Point(11, 78);
            hScrollBar1.Maximum = 255;
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(298, 31);
            hScrollBar1.TabIndex = 2;
            // 
            // hScrollBar2
            // 
            hScrollBar2.LargeChange = 1;
            hScrollBar2.Location = new Point(11, 20);
            hScrollBar2.Maximum = 255;
            hScrollBar2.Name = "hScrollBar2";
            hScrollBar2.Size = new Size(298, 30);
            hScrollBar2.TabIndex = 1;
            // 
            // tabPage6
            // 
            tabPage6.Location = new Point(4, 24);
            tabPage6.Margin = new Padding(2);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new Padding(2);
            tabPage6.Size = new Size(369, 116);
            tabPage6.TabIndex = 0;
            tabPage6.Text = "Otsu";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(6, 3);
            label20.Name = "label20";
            label20.Size = new Size(79, 15);
            label20.TabIndex = 27;
            label20.Text = "二值化演算法";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(FindContoursWayComboBox);
            tabPage2.Controls.Add(blobDetect_Dilate_Erode_Mask_Size_NumericUpDown);
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(blobDetect_ErodeFlagCheckBox);
            tabPage2.Controls.Add(blob_AreaRatioLabel);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(blobDetect_DilateFlagCheckBox);
            tabPage2.Controls.Add(blobAreaRatioBar);
            tabPage2.Controls.Add(blob_maxRadiusLabel);
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(blob_maxRadiusBar);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(blob_minRadiusLabel);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(blob_minRadiusBar);
            tabPage2.Controls.Add(blob_maxAreaLabel);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(blobDetect_binaryImg);
            tabPage2.Controls.Add(blobDetect_imgBinaryTabCtrl);
            tabPage2.Controls.Add(blob_maxAreaBar);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(blobDetectButton);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(2);
            tabPage2.Size = new Size(443, 493);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "blob偵測";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // FindContoursWayComboBox
            // 
            FindContoursWayComboBox.FormattingEnabled = true;
            FindContoursWayComboBox.Items.AddRange(new object[] { "External", "List" });
            FindContoursWayComboBox.Location = new Point(85, 457);
            FindContoursWayComboBox.Name = "FindContoursWayComboBox";
            FindContoursWayComboBox.Size = new Size(161, 23);
            FindContoursWayComboBox.TabIndex = 33;
            FindContoursWayComboBox.SelectedIndexChanged += FindContoursWayComboBox_SelectedIndexChanged;
            // 
            // blobDetect_Dilate_Erode_Mask_Size_NumericUpDown
            // 
            blobDetect_Dilate_Erode_Mask_Size_NumericUpDown.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            blobDetect_Dilate_Erode_Mask_Size_NumericUpDown.Location = new Point(209, 191);
            blobDetect_Dilate_Erode_Mask_Size_NumericUpDown.Maximum = new decimal(new int[] { 17, 0, 0, 0 });
            blobDetect_Dilate_Erode_Mask_Size_NumericUpDown.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            blobDetect_Dilate_Erode_Mask_Size_NumericUpDown.Name = "blobDetect_Dilate_Erode_Mask_Size_NumericUpDown";
            blobDetect_Dilate_Erode_Mask_Size_NumericUpDown.Size = new Size(74, 23);
            blobDetect_Dilate_Erode_Mask_Size_NumericUpDown.TabIndex = 25;
            blobDetect_Dilate_Erode_Mask_Size_NumericUpDown.Value = new decimal(new int[] { 3, 0, 0, 0 });
            blobDetect_Dilate_Erode_Mask_Size_NumericUpDown.ValueChanged += Dilate_Erode_Mask_Size_NumericUpDown_ValueChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(15, 460);
            label12.Name = "label12";
            label12.Size = new Size(67, 15);
            label12.TabIndex = 32;
            label12.Text = "找輪廓方法";
            // 
            // blobDetect_ErodeFlagCheckBox
            // 
            blobDetect_ErodeFlagCheckBox.AutoSize = true;
            blobDetect_ErodeFlagCheckBox.Location = new Point(74, 195);
            blobDetect_ErodeFlagCheckBox.Name = "blobDetect_ErodeFlagCheckBox";
            blobDetect_ErodeFlagCheckBox.Size = new Size(50, 19);
            blobDetect_ErodeFlagCheckBox.TabIndex = 24;
            blobDetect_ErodeFlagCheckBox.Text = "侵蝕";
            blobDetect_ErodeFlagCheckBox.UseVisualStyleBackColor = true;
            blobDetect_ErodeFlagCheckBox.CheckedChanged += ErodeFlagCheckBox_CheckedChanged;
            // 
            // blob_AreaRatioLabel
            // 
            blob_AreaRatioLabel.AutoSize = true;
            blob_AreaRatioLabel.Location = new Point(321, 419);
            blob_AreaRatioLabel.Margin = new Padding(2, 0, 2, 0);
            blob_AreaRatioLabel.Name = "blob_AreaRatioLabel";
            blob_AreaRatioLabel.Size = new Size(21, 15);
            blob_AreaRatioLabel.TabIndex = 31;
            blob_AreaRatioLabel.Text = "30";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(15, 395);
            label9.Name = "label9";
            label9.Size = new Size(142, 15);
            label9.TabIndex = 30;
            label9.Text = "外接圓面積與blob面積比";
            // 
            // blobDetect_DilateFlagCheckBox
            // 
            blobDetect_DilateFlagCheckBox.AutoSize = true;
            blobDetect_DilateFlagCheckBox.Location = new Point(18, 195);
            blobDetect_DilateFlagCheckBox.Name = "blobDetect_DilateFlagCheckBox";
            blobDetect_DilateFlagCheckBox.Size = new Size(50, 19);
            blobDetect_DilateFlagCheckBox.TabIndex = 23;
            blobDetect_DilateFlagCheckBox.Text = "膨脹";
            blobDetect_DilateFlagCheckBox.UseVisualStyleBackColor = true;
            blobDetect_DilateFlagCheckBox.CheckedChanged += DilateFlagCheckBox_CheckedChanged;
            // 
            // blobAreaRatioBar
            // 
            blobAreaRatioBar.LargeChange = 1;
            blobAreaRatioBar.Location = new Point(15, 410);
            blobAreaRatioBar.Name = "blobAreaRatioBar";
            blobAreaRatioBar.Size = new Size(298, 24);
            blobAreaRatioBar.TabIndex = 29;
            blobAreaRatioBar.Scroll += blobAreaRatioBar_Scroll;
            // 
            // blob_maxRadiusLabel
            // 
            blob_maxRadiusLabel.AutoSize = true;
            blob_maxRadiusLabel.Location = new Point(321, 366);
            blob_maxRadiusLabel.Margin = new Padding(2, 0, 2, 0);
            blob_maxRadiusLabel.Name = "blob_maxRadiusLabel";
            blob_maxRadiusLabel.Size = new Size(21, 15);
            blob_maxRadiusLabel.TabIndex = 28;
            blob_maxRadiusLabel.Text = "30";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(140, 196);
            label11.Name = "label11";
            label11.Size = new Size(63, 15);
            label11.TabIndex = 22;
            label11.Text = "mask 大小";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(15, 342);
            label10.Name = "label10";
            label10.Size = new Size(118, 15);
            label10.TabIndex = 27;
            label10.Text = "blob外接圓最大半徑";
            // 
            // blob_maxRadiusBar
            // 
            blob_maxRadiusBar.LargeChange = 1;
            blob_maxRadiusBar.Location = new Point(15, 357);
            blob_maxRadiusBar.Maximum = 1000;
            blob_maxRadiusBar.Name = "blob_maxRadiusBar";
            blob_maxRadiusBar.Size = new Size(298, 24);
            blob_maxRadiusBar.TabIndex = 26;
            blob_maxRadiusBar.Scroll += solderBall_maxRadiusBar_Scroll;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 174);
            label7.Name = "label7";
            label7.Size = new Size(103, 15);
            label7.TabIndex = 21;
            label7.Text = "二值化膨脹與侵蝕";
            // 
            // blob_minRadiusLabel
            // 
            blob_minRadiusLabel.AutoSize = true;
            blob_minRadiusLabel.Location = new Point(321, 314);
            blob_minRadiusLabel.Margin = new Padding(2, 0, 2, 0);
            blob_minRadiusLabel.Name = "blob_minRadiusLabel";
            blob_minRadiusLabel.Size = new Size(21, 15);
            blob_minRadiusLabel.TabIndex = 25;
            blob_minRadiusLabel.Text = "10";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 290);
            label8.Name = "label8";
            label8.Size = new Size(118, 15);
            label8.TabIndex = 24;
            label8.Text = "blob外接圓最小半徑";
            // 
            // blob_minRadiusBar
            // 
            blob_minRadiusBar.LargeChange = 1;
            blob_minRadiusBar.Location = new Point(15, 305);
            blob_minRadiusBar.Name = "blob_minRadiusBar";
            blob_minRadiusBar.Size = new Size(298, 24);
            blob_minRadiusBar.TabIndex = 23;
            blob_minRadiusBar.Scroll += solderBall_minRadiusBar_Scroll;
            // 
            // blob_maxAreaLabel
            // 
            blob_maxAreaLabel.AutoSize = true;
            blob_maxAreaLabel.Location = new Point(321, 262);
            blob_maxAreaLabel.Margin = new Padding(2, 0, 2, 0);
            blob_maxAreaLabel.Name = "blob_maxAreaLabel";
            blob_maxAreaLabel.Size = new Size(28, 15);
            blob_maxAreaLabel.TabIndex = 22;
            blob_maxAreaLabel.Text = "900";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 238);
            label5.Name = "label5";
            label5.Size = new Size(231, 15);
            label5.TabIndex = 21;
            label5.Text = "blob最大面積 pixel 平方(體積異常為紅圈)";
            // 
            // blobDetect_binaryImg
            // 
            blobDetect_binaryImg.Location = new Point(352, 186);
            blobDetect_binaryImg.Name = "blobDetect_binaryImg";
            blobDetect_binaryImg.Size = new Size(88, 28);
            blobDetect_binaryImg.TabIndex = 10;
            blobDetect_binaryImg.Text = "二值化測試";
            blobDetect_binaryImg.UseVisualStyleBackColor = true;
            blobDetect_binaryImg.Click += blobDetect_binaryImg_Click;
            // 
            // blobDetect_imgBinaryTabCtrl
            // 
            blobDetect_imgBinaryTabCtrl.Controls.Add(tabPage4);
            blobDetect_imgBinaryTabCtrl.Controls.Add(tabPage3);
            blobDetect_imgBinaryTabCtrl.Location = new Point(14, 28);
            blobDetect_imgBinaryTabCtrl.Margin = new Padding(2);
            blobDetect_imgBinaryTabCtrl.Name = "blobDetect_imgBinaryTabCtrl";
            blobDetect_imgBinaryTabCtrl.SelectedIndex = 0;
            blobDetect_imgBinaryTabCtrl.Size = new Size(377, 144);
            blobDetect_imgBinaryTabCtrl.TabIndex = 18;
            blobDetect_imgBinaryTabCtrl.SelectedIndexChanged += imgBinaryTabCtrl_SelectedIndexChanged;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(label4);
            tabPage4.Controls.Add(label2);
            tabPage4.Controls.Add(blobDetect_InRangeLowerBoundLabel);
            tabPage4.Controls.Add(blobDetect_InRangeUpperBoundLabel);
            tabPage4.Controls.Add(blobDetect_InRangeLowerBoundScrollBar);
            tabPage4.Controls.Add(blobDetect_InRangeUpperBoundScrollBar);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Margin = new Padding(2);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(2);
            tabPage4.Size = new Size(369, 116);
            tabPage4.TabIndex = 1;
            tabPage4.Text = "InRange";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 63);
            label4.Name = "label4";
            label4.Size = new Size(79, 15);
            label4.TabIndex = 20;
            label4.Text = "lower bound";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 5);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 19;
            label2.Text = "upper bound";
            // 
            // blobDetect_InRangeLowerBoundLabel
            // 
            blobDetect_InRangeLowerBoundLabel.AutoSize = true;
            blobDetect_InRangeLowerBoundLabel.Location = new Point(317, 85);
            blobDetect_InRangeLowerBoundLabel.Margin = new Padding(2, 0, 2, 0);
            blobDetect_InRangeLowerBoundLabel.Name = "blobDetect_InRangeLowerBoundLabel";
            blobDetect_InRangeLowerBoundLabel.Size = new Size(21, 15);
            blobDetect_InRangeLowerBoundLabel.TabIndex = 4;
            blobDetect_InRangeLowerBoundLabel.Text = "50";
            // 
            // blobDetect_InRangeUpperBoundLabel
            // 
            blobDetect_InRangeUpperBoundLabel.AutoSize = true;
            blobDetect_InRangeUpperBoundLabel.Location = new Point(317, 27);
            blobDetect_InRangeUpperBoundLabel.Margin = new Padding(2, 0, 2, 0);
            blobDetect_InRangeUpperBoundLabel.Name = "blobDetect_InRangeUpperBoundLabel";
            blobDetect_InRangeUpperBoundLabel.Size = new Size(28, 15);
            blobDetect_InRangeUpperBoundLabel.TabIndex = 3;
            blobDetect_InRangeUpperBoundLabel.Text = "200";
            // 
            // blobDetect_InRangeLowerBoundScrollBar
            // 
            blobDetect_InRangeLowerBoundScrollBar.LargeChange = 1;
            blobDetect_InRangeLowerBoundScrollBar.Location = new Point(11, 78);
            blobDetect_InRangeLowerBoundScrollBar.Maximum = 255;
            blobDetect_InRangeLowerBoundScrollBar.Name = "blobDetect_InRangeLowerBoundScrollBar";
            blobDetect_InRangeLowerBoundScrollBar.Size = new Size(298, 31);
            blobDetect_InRangeLowerBoundScrollBar.TabIndex = 2;
            blobDetect_InRangeLowerBoundScrollBar.Scroll += lowerBoundScrollBar_Scroll;
            // 
            // blobDetect_InRangeUpperBoundScrollBar
            // 
            blobDetect_InRangeUpperBoundScrollBar.LargeChange = 1;
            blobDetect_InRangeUpperBoundScrollBar.Location = new Point(11, 20);
            blobDetect_InRangeUpperBoundScrollBar.Maximum = 255;
            blobDetect_InRangeUpperBoundScrollBar.Name = "blobDetect_InRangeUpperBoundScrollBar";
            blobDetect_InRangeUpperBoundScrollBar.Size = new Size(298, 30);
            blobDetect_InRangeUpperBoundScrollBar.TabIndex = 1;
            blobDetect_InRangeUpperBoundScrollBar.Scroll += upperBoundScrollBar_Scroll;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Margin = new Padding(2);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(2);
            tabPage3.Size = new Size(369, 116);
            tabPage3.TabIndex = 0;
            tabPage3.Text = "Otsu";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // blob_maxAreaBar
            // 
            blob_maxAreaBar.LargeChange = 1;
            blob_maxAreaBar.Location = new Point(15, 253);
            blob_maxAreaBar.Maximum = 5000;
            blob_maxAreaBar.Name = "blob_maxAreaBar";
            blob_maxAreaBar.Size = new Size(298, 24);
            blob_maxAreaBar.TabIndex = 20;
            blob_maxAreaBar.Scroll += solderBall_maxAreaBar_Scroll;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 11);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 17;
            label3.Text = "二值化演算法";
            // 
            // blobDetectButton
            // 
            blobDetectButton.Location = new Point(352, 460);
            blobDetectButton.Name = "blobDetectButton";
            blobDetectButton.Size = new Size(88, 28);
            blobDetectButton.TabIndex = 9;
            blobDetectButton.Text = "blob偵測";
            blobDetectButton.UseVisualStyleBackColor = true;
            blobDetectButton.Click += blobDetectButton_Click;
            // 
            // saveGroup
            // 
            saveGroup.Controls.Add(imgName);
            saveGroup.Controls.Add(newImgName);
            saveGroup.Controls.Add(label1);
            saveGroup.Controls.Add(saveImgBtn);
            saveGroup.Location = new Point(13, 783);
            saveGroup.Margin = new Padding(2);
            saveGroup.Name = "saveGroup";
            saveGroup.Padding = new Padding(2);
            saveGroup.Size = new Size(454, 77);
            saveGroup.TabIndex = 15;
            saveGroup.TabStop = false;
            saveGroup.Text = "saveGroup";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(320, 51);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 5;
            label1.Text = ".bmp";
            // 
            // targetImgPanel
            // 
            targetImgPanel.BackColor = SystemColors.ControlDark;
            targetImgPanel.Location = new Point(258, 22);
            targetImgPanel.Name = "targetImgPanel";
            targetImgPanel.Size = new Size(206, 185);
            targetImgPanel.TabIndex = 14;
            // 
            // targetImgBtn
            // 
            targetImgBtn.Location = new Point(164, 22);
            targetImgBtn.Name = "targetImgBtn";
            targetImgBtn.Size = new Size(88, 28);
            targetImgBtn.TabIndex = 13;
            targetImgBtn.Text = "開啟目標影像";
            targetImgBtn.UseVisualStyleBackColor = true;
            targetImgBtn.Click += targetImgBtn_Click;
            // 
            // cropImgBtn
            // 
            cropImgBtn.Location = new Point(15, 104);
            cropImgBtn.Name = "cropImgBtn";
            cropImgBtn.Size = new Size(88, 28);
            cropImgBtn.TabIndex = 12;
            cropImgBtn.Text = "截圖";
            cropImgBtn.UseVisualStyleBackColor = true;
            cropImgBtn.Click += cropImgBtn_Click;
            // 
            // findTargetBtn
            // 
            findTargetBtn.Location = new Point(164, 62);
            findTargetBtn.Name = "findTargetBtn";
            findTargetBtn.Size = new Size(89, 28);
            findTargetBtn.TabIndex = 11;
            findTargetBtn.Text = "找目標";
            findTargetBtn.UseVisualStyleBackColor = true;
            findTargetBtn.Click += findTargetBtn_Click;
            // 
            // rectangleBtn
            // 
            rectangleBtn.Location = new Point(15, 62);
            rectangleBtn.Name = "rectangleBtn";
            rectangleBtn.Size = new Size(88, 28);
            rectangleBtn.TabIndex = 7;
            rectangleBtn.Text = "四方形選取";
            rectangleBtn.UseVisualStyleBackColor = true;
            rectangleBtn.Click += rectangleBtn_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1476, 932);
            Controls.Add(functionBtnGroup);
            Controls.Add(pixelInfoGroup);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            pixelInfoGroup.ResumeLayout(false);
            pixelInfoGroup.PerformLayout();
            functionBtnGroup.ResumeLayout(false);
            functionBtnGroup.PerformLayout();
            parameterFileGroup.ResumeLayout(false);
            parameterFileGroup.PerformLayout();
            ConsoleGroupBox.ResumeLayout(false);
            ConsoleGroupBox.PerformLayout();
            TabGroup.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)blobDetect_Dilate_Erode_Mask_Size_NumericUpDown).EndInit();
            blobDetect_imgBinaryTabCtrl.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            saveGroup.ResumeLayout(false);
            saveGroup.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button openImgBtn;
        private Button saveImgBtn;
        private Panel panel1;
        private OpenFileDialog openFileDialog1;
        private TextBox imgName;
        private TextBox newImgName;
        private Label X_label;
        private Label Y_label;
        private Label gray_label;
        private TextBox YValueTextBox;
        private TextBox XValueTextBox;
        private TextBox pixelValueTextBox;
        private GroupBox pixelInfoGroup;
        private GroupBox functionBtnGroup;
        private Label label1;
        private Button rectangleBtn;
        private ContextMenuStrip contextMenuStrip1;
        private Button blobDetectButton;
        private Button blobDetect_binaryImg;
        private Button findTargetBtn;
        private Button cropImgBtn;
        private Button targetImgBtn;
        private Panel targetImgPanel;
        private GroupBox saveGroup;
        private TabControl TabGroup;
        private TabPage tabPage2;
        private Label label3;
        private TabControl blobDetect_imgBinaryTabCtrl;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private HScrollBar blobDetect_InRangeUpperBoundScrollBar;
        private Label blobDetect_InRangeLowerBoundLabel;
        private Label blobDetect_InRangeUpperBoundLabel;
        private HScrollBar blobDetect_InRangeLowerBoundScrollBar;
        private Label label2;
        private Label label4;
        private Label blob_maxAreaLabel;
        private Label label5;
        private HScrollBar blob_maxAreaBar;
        private Label blob_maxRadiusLabel;
        private Label label10;
        private HScrollBar blob_maxRadiusBar;
        private Label blob_minRadiusLabel;
        private Label label8;
        private HScrollBar blob_minRadiusBar;
        private Button elementImgBtn;
        private Button findElementBtn;
        private Panel elementImgPanel;
        private Label label6;
        private TextBox rotateAngleTextBox;
        private Button rotateBtn_test;
        private Label blob_AreaRatioLabel;
        private Label label9;
        private HScrollBar blobAreaRatioBar;
        private GroupBox ConsoleGroupBox;
        private Label consoleLabel;
        private CheckBox blobDetect_DilateFlagCheckBox;
        private Label label11;
        private Label label7;
        private CheckBox blobDetect_ErodeFlagCheckBox;
        private NumericUpDown blobDetect_Dilate_Erode_Mask_Size_NumericUpDown;
        private ComboBox FindContoursWayComboBox;
        private Label label12;
        private Button saveParameterBtn;
        private GroupBox parameterFileGroup;
        private TextBox saveParameterLabel;
        private Label label13;
        private Button openParameterFileBtn;
        private TextBox openParameterFilePathLabel;
        private TabPage tabPage1;
        private NumericUpDown numericUpDown1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Label label14;
        private Label label15;
        private Button button1;
        private TabControl tabControl1;
        private TabPage tabPage5;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private HScrollBar hScrollBar1;
        private HScrollBar hScrollBar2;
        private TabPage tabPage6;
        private Label label20;
        private Button rotateBtn;
    }
}