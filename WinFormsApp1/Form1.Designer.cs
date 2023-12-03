namespace WinFormsApp1
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
            rotateImg_Dilate_Erode_Mask_Size_NumericUpDown = new NumericUpDown();
            rotateImg_ErodeFlagCheckBox = new CheckBox();
            rotateImg_DilateFlagCheckBox = new CheckBox();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            rotateBtn = new Button();
            label17 = new Label();
            rotateImg_InRangeLowerBoundLabel = new Label();
            rotateImg_InRangeUpperBoundLabel = new Label();
            rotateImg_InRangeLowerBoundScrollBar = new HScrollBar();
            rotateImg_InRangeUpperBoundScrollBar = new HScrollBar();
            CannyBtn = new Button();
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
            label18 = new Label();
            pixelInfoGroup.SuspendLayout();
            functionBtnGroup.SuspendLayout();
            parameterFileGroup.SuspendLayout();
            ConsoleGroupBox.SuspendLayout();
            TabGroup.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)rotateImg_Dilate_Erode_Mask_Size_NumericUpDown).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)blobDetect_Dilate_Erode_Mask_Size_NumericUpDown).BeginInit();
            blobDetect_imgBinaryTabCtrl.SuspendLayout();
            tabPage4.SuspendLayout();
            saveGroup.SuspendLayout();
            SuspendLayout();
            // 
            // openImgBtn
            // 
            openImgBtn.Location = new Point(19, 28);
            openImgBtn.Margin = new Padding(4);
            openImgBtn.Name = "openImgBtn";
            openImgBtn.Size = new Size(113, 35);
            openImgBtn.TabIndex = 0;
            openImgBtn.Text = "開啟影像";
            openImgBtn.UseVisualStyleBackColor = true;
            openImgBtn.Click += openImgBtn_Click;
            // 
            // saveImgBtn
            // 
            saveImgBtn.Location = new Point(473, 58);
            saveImgBtn.Margin = new Padding(4);
            saveImgBtn.Name = "saveImgBtn";
            saveImgBtn.Size = new Size(104, 29);
            saveImgBtn.TabIndex = 1;
            saveImgBtn.Text = "儲存影像";
            saveImgBtn.UseVisualStyleBackColor = true;
            saveImgBtn.Click += saveImgBtn_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Location = new Point(26, 25);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(697, 541);
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
            imgName.Location = new Point(6, 25);
            imgName.Margin = new Padding(4);
            imgName.Name = "imgName";
            imgName.Size = new Size(572, 27);
            imgName.TabIndex = 3;
            // 
            // newImgName
            // 
            newImgName.AccessibleName = "";
            newImgName.Location = new Point(8, 58);
            newImgName.Margin = new Padding(4);
            newImgName.Name = "newImgName";
            newImgName.Size = new Size(404, 27);
            newImgName.TabIndex = 4;
            newImgName.Text = "newImgName";
            // 
            // X_label
            // 
            X_label.AutoSize = true;
            X_label.Location = new Point(9, 30);
            X_label.Margin = new Padding(4, 0, 4, 0);
            X_label.Name = "X_label";
            X_label.Size = new Size(49, 19);
            X_label.TabIndex = 5;
            X_label.Text = "X座標";
            // 
            // Y_label
            // 
            Y_label.AutoSize = true;
            Y_label.Location = new Point(143, 30);
            Y_label.Margin = new Padding(4, 0, 4, 0);
            Y_label.Name = "Y_label";
            Y_label.Size = new Size(48, 19);
            Y_label.TabIndex = 6;
            Y_label.Text = "Y座標";
            // 
            // gray_label
            // 
            gray_label.AutoSize = true;
            gray_label.Location = new Point(275, 30);
            gray_label.Margin = new Padding(4, 0, 4, 0);
            gray_label.Name = "gray_label";
            gray_label.Size = new Size(54, 19);
            gray_label.TabIndex = 7;
            gray_label.Text = "灰階值";
            // 
            // YValueTextBox
            // 
            YValueTextBox.Location = new Point(199, 27);
            YValueTextBox.Margin = new Padding(4);
            YValueTextBox.Name = "YValueTextBox";
            YValueTextBox.Size = new Size(54, 27);
            YValueTextBox.TabIndex = 8;
            // 
            // XValueTextBox
            // 
            XValueTextBox.Location = new Point(67, 27);
            XValueTextBox.Margin = new Padding(4);
            XValueTextBox.Name = "XValueTextBox";
            XValueTextBox.Size = new Size(54, 27);
            XValueTextBox.TabIndex = 9;
            // 
            // pixelValueTextBox
            // 
            pixelValueTextBox.Location = new Point(338, 27);
            pixelValueTextBox.Margin = new Padding(4);
            pixelValueTextBox.Name = "pixelValueTextBox";
            pixelValueTextBox.Size = new Size(214, 27);
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
            pixelInfoGroup.Location = new Point(15, 668);
            pixelInfoGroup.Margin = new Padding(4);
            pixelInfoGroup.Name = "pixelInfoGroup";
            pixelInfoGroup.Padding = new Padding(4);
            pixelInfoGroup.Size = new Size(579, 76);
            pixelInfoGroup.TabIndex = 11;
            pixelInfoGroup.TabStop = false;
            pixelInfoGroup.Text = "pixel info";
            // 
            // functionBtnGroup
            // 
            functionBtnGroup.Controls.Add(rotateImg_Dilate_Erode_Mask_Size_NumericUpDown);
            functionBtnGroup.Controls.Add(parameterFileGroup);
            functionBtnGroup.Controls.Add(rotateImg_ErodeFlagCheckBox);
            functionBtnGroup.Controls.Add(ConsoleGroupBox);
            functionBtnGroup.Controls.Add(rotateImg_DilateFlagCheckBox);
            functionBtnGroup.Controls.Add(rotateBtn_test);
            functionBtnGroup.Controls.Add(label14);
            functionBtnGroup.Controls.Add(label6);
            functionBtnGroup.Controls.Add(label15);
            functionBtnGroup.Controls.Add(rotateAngleTextBox);
            functionBtnGroup.Controls.Add(label16);
            functionBtnGroup.Controls.Add(elementImgBtn);
            functionBtnGroup.Controls.Add(findElementBtn);
            functionBtnGroup.Controls.Add(label17);
            functionBtnGroup.Controls.Add(elementImgPanel);
            functionBtnGroup.Controls.Add(rotateImg_InRangeLowerBoundLabel);
            functionBtnGroup.Controls.Add(TabGroup);
            functionBtnGroup.Controls.Add(rotateImg_InRangeUpperBoundLabel);
            functionBtnGroup.Controls.Add(saveGroup);
            functionBtnGroup.Controls.Add(rotateImg_InRangeLowerBoundScrollBar);
            functionBtnGroup.Controls.Add(targetImgPanel);
            functionBtnGroup.Controls.Add(rotateImg_InRangeUpperBoundScrollBar);
            functionBtnGroup.Controls.Add(targetImgBtn);
            functionBtnGroup.Controls.Add(CannyBtn);
            functionBtnGroup.Controls.Add(cropImgBtn);
            functionBtnGroup.Controls.Add(label20);
            functionBtnGroup.Controls.Add(findTargetBtn);
            functionBtnGroup.Controls.Add(rectangleBtn);
            functionBtnGroup.Controls.Add(openImgBtn);
            functionBtnGroup.Location = new Point(787, 25);
            functionBtnGroup.Margin = new Padding(4);
            functionBtnGroup.Name = "functionBtnGroup";
            functionBtnGroup.Padding = new Padding(4);
            functionBtnGroup.Size = new Size(1095, 1175);
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
            parameterFileGroup.Location = new Point(660, 992);
            parameterFileGroup.Margin = new Padding(4);
            parameterFileGroup.Name = "parameterFileGroup";
            parameterFileGroup.Padding = new Padding(4);
            parameterFileGroup.Size = new Size(370, 98);
            parameterFileGroup.TabIndex = 27;
            parameterFileGroup.TabStop = false;
            parameterFileGroup.Text = "參數檔案";
            // 
            // openParameterFilePathLabel
            // 
            openParameterFilePathLabel.AccessibleName = "";
            openParameterFilePathLabel.Enabled = false;
            openParameterFilePathLabel.Location = new Point(13, 18);
            openParameterFilePathLabel.Margin = new Padding(4);
            openParameterFilePathLabel.Name = "openParameterFilePathLabel";
            openParameterFilePathLabel.Size = new Size(224, 27);
            openParameterFilePathLabel.TabIndex = 28;
            // 
            // openParameterFileBtn
            // 
            openParameterFileBtn.Location = new Point(246, 18);
            openParameterFileBtn.Margin = new Padding(4);
            openParameterFileBtn.Name = "openParameterFileBtn";
            openParameterFileBtn.Size = new Size(116, 32);
            openParameterFileBtn.TabIndex = 27;
            openParameterFileBtn.Text = "開啟參數檔";
            openParameterFileBtn.UseVisualStyleBackColor = true;
            openParameterFileBtn.Click += openParameterFileBtn_Click;
            // 
            // saveParameterLabel
            // 
            saveParameterLabel.AccessibleName = "";
            saveParameterLabel.Location = new Point(13, 61);
            saveParameterLabel.Margin = new Padding(4);
            saveParameterLabel.Name = "saveParameterLabel";
            saveParameterLabel.Size = new Size(193, 27);
            saveParameterLabel.TabIndex = 6;
            saveParameterLabel.Text = "iniFileName";
            // 
            // saveParameterBtn
            // 
            saveParameterBtn.Location = new Point(247, 58);
            saveParameterBtn.Margin = new Padding(4);
            saveParameterBtn.Name = "saveParameterBtn";
            saveParameterBtn.Size = new Size(116, 32);
            saveParameterBtn.TabIndex = 26;
            saveParameterBtn.Text = "儲存當前參數";
            saveParameterBtn.UseVisualStyleBackColor = true;
            saveParameterBtn.Click += saveParameterBtn_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(203, 71);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(29, 19);
            label13.TabIndex = 7;
            label13.Text = ".ini";
            // 
            // ConsoleGroupBox
            // 
            ConsoleGroupBox.Controls.Add(consoleLabel);
            ConsoleGroupBox.Location = new Point(620, 608);
            ConsoleGroupBox.Margin = new Padding(4);
            ConsoleGroupBox.Name = "ConsoleGroupBox";
            ConsoleGroupBox.Padding = new Padding(4);
            ConsoleGroupBox.Size = new Size(370, 338);
            ConsoleGroupBox.TabIndex = 24;
            ConsoleGroupBox.TabStop = false;
            ConsoleGroupBox.Text = "Console";
            // 
            // consoleLabel
            // 
            consoleLabel.AutoSize = true;
            consoleLabel.Location = new Point(8, 29);
            consoleLabel.Margin = new Padding(4, 0, 4, 0);
            consoleLabel.Name = "consoleLabel";
            consoleLabel.Size = new Size(35, 19);
            consoleLabel.TabIndex = 32;
            consoleLabel.Text = "null";
            // 
            // rotateBtn_test
            // 
            rotateBtn_test.Location = new Point(129, 218);
            rotateBtn_test.Margin = new Padding(4);
            rotateBtn_test.Name = "rotateBtn_test";
            rotateBtn_test.Size = new Size(54, 29);
            rotateBtn_test.TabIndex = 23;
            rotateBtn_test.Text = "旋轉";
            rotateBtn_test.UseVisualStyleBackColor = true;
            rotateBtn_test.Click += rotateBtn_test_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 195);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(69, 19);
            label6.TabIndex = 22;
            label6.Text = "旋轉角度";
            // 
            // rotateAngleTextBox
            // 
            rotateAngleTextBox.Location = new Point(19, 218);
            rotateAngleTextBox.Margin = new Padding(4);
            rotateAngleTextBox.Name = "rotateAngleTextBox";
            rotateAngleTextBox.Size = new Size(100, 27);
            rotateAngleTextBox.TabIndex = 21;
            rotateAngleTextBox.Text = "0";
            rotateAngleTextBox.TextChanged += rotateAngleTextBox_TextChanged;
            // 
            // elementImgBtn
            // 
            elementImgBtn.Location = new Point(672, 28);
            elementImgBtn.Margin = new Padding(4);
            elementImgBtn.Name = "elementImgBtn";
            elementImgBtn.Size = new Size(113, 35);
            elementImgBtn.TabIndex = 20;
            elementImgBtn.Text = "開啟元件影像";
            elementImgBtn.UseVisualStyleBackColor = true;
            elementImgBtn.Click += elementImgBtn_Click;
            // 
            // findElementBtn
            // 
            findElementBtn.Location = new Point(672, 79);
            findElementBtn.Margin = new Padding(4);
            findElementBtn.Name = "findElementBtn";
            findElementBtn.Size = new Size(114, 35);
            findElementBtn.TabIndex = 19;
            findElementBtn.Text = "找元件";
            findElementBtn.UseVisualStyleBackColor = true;
            findElementBtn.Click += findElementBtn_Click;
            // 
            // elementImgPanel
            // 
            elementImgPanel.BackColor = SystemColors.ControlDark;
            elementImgPanel.Location = new Point(793, 28);
            elementImgPanel.Margin = new Padding(4);
            elementImgPanel.Name = "elementImgPanel";
            elementImgPanel.Size = new Size(265, 234);
            elementImgPanel.TabIndex = 15;
            // 
            // TabGroup
            // 
            TabGroup.Controls.Add(tabPage2);
            TabGroup.Controls.Add(tabPage1);
            TabGroup.Location = new Point(17, 286);
            TabGroup.Name = "TabGroup";
            TabGroup.SelectedIndex = 0;
            TabGroup.Size = new Size(580, 660);
            TabGroup.TabIndex = 16;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label18);
            tabPage1.Controls.Add(rotateBtn);
            tabPage1.Location = new Point(4, 28);
            tabPage1.Margin = new Padding(4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4);
            tabPage1.Size = new Size(572, 628);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "轉正";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // rotateImg_Dilate_Erode_Mask_Size_NumericUpDown
            // 
            rotateImg_Dilate_Erode_Mask_Size_NumericUpDown.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            rotateImg_Dilate_Erode_Mask_Size_NumericUpDown.Location = new Point(846, 495);
            rotateImg_Dilate_Erode_Mask_Size_NumericUpDown.Margin = new Padding(4);
            rotateImg_Dilate_Erode_Mask_Size_NumericUpDown.Maximum = new decimal(new int[] { 17, 0, 0, 0 });
            rotateImg_Dilate_Erode_Mask_Size_NumericUpDown.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            rotateImg_Dilate_Erode_Mask_Size_NumericUpDown.Name = "rotateImg_Dilate_Erode_Mask_Size_NumericUpDown";
            rotateImg_Dilate_Erode_Mask_Size_NumericUpDown.Size = new Size(59, 27);
            rotateImg_Dilate_Erode_Mask_Size_NumericUpDown.TabIndex = 39;
            rotateImg_Dilate_Erode_Mask_Size_NumericUpDown.Value = new decimal(new int[] { 3, 0, 0, 0 });
            rotateImg_Dilate_Erode_Mask_Size_NumericUpDown.ValueChanged += rotateImg_Dilate_Erode_Mask_Size_NumericUpDown_ValueChanged;
            // 
            // rotateImg_ErodeFlagCheckBox
            // 
            rotateImg_ErodeFlagCheckBox.AutoSize = true;
            rotateImg_ErodeFlagCheckBox.Location = new Point(679, 500);
            rotateImg_ErodeFlagCheckBox.Margin = new Padding(4);
            rotateImg_ErodeFlagCheckBox.Name = "rotateImg_ErodeFlagCheckBox";
            rotateImg_ErodeFlagCheckBox.Size = new Size(61, 23);
            rotateImg_ErodeFlagCheckBox.TabIndex = 38;
            rotateImg_ErodeFlagCheckBox.Text = "侵蝕";
            rotateImg_ErodeFlagCheckBox.UseVisualStyleBackColor = true;
            rotateImg_ErodeFlagCheckBox.CheckedChanged += rotateImg_ErodeFlagCheckBox_CheckedChanged;
            // 
            // rotateImg_DilateFlagCheckBox
            // 
            rotateImg_DilateFlagCheckBox.AutoSize = true;
            rotateImg_DilateFlagCheckBox.Location = new Point(607, 500);
            rotateImg_DilateFlagCheckBox.Margin = new Padding(4);
            rotateImg_DilateFlagCheckBox.Name = "rotateImg_DilateFlagCheckBox";
            rotateImg_DilateFlagCheckBox.Size = new Size(61, 23);
            rotateImg_DilateFlagCheckBox.TabIndex = 37;
            rotateImg_DilateFlagCheckBox.Text = "膨脹";
            rotateImg_DilateFlagCheckBox.UseVisualStyleBackColor = true;
            rotateImg_DilateFlagCheckBox.CheckedChanged += rotateImg_DilateFlagCheckBox_CheckedChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(757, 501);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(80, 19);
            label14.TabIndex = 36;
            label14.Text = "mask 大小";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(602, 473);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(129, 19);
            label15.TabIndex = 35;
            label15.Text = "二值化膨脹與侵蝕";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(606, 413);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(98, 19);
            label16.TabIndex = 20;
            label16.Text = "lower bound";
            // 
            // rotateBtn
            // 
            rotateBtn.Location = new Point(442, 581);
            rotateBtn.Margin = new Padding(4);
            rotateBtn.Name = "rotateBtn";
            rotateBtn.Size = new Size(113, 35);
            rotateBtn.TabIndex = 34;
            rotateBtn.Text = "轉正";
            rotateBtn.UseVisualStyleBackColor = true;
            rotateBtn.Click += rotateImgBtn_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(606, 340);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(100, 19);
            label17.TabIndex = 19;
            label17.Text = "upper bound";
            // 
            // rotateImg_InRangeLowerBoundLabel
            // 
            rotateImg_InRangeLowerBoundLabel.AutoSize = true;
            rotateImg_InRangeLowerBoundLabel.Location = new Point(1000, 441);
            rotateImg_InRangeLowerBoundLabel.Name = "rotateImg_InRangeLowerBoundLabel";
            rotateImg_InRangeLowerBoundLabel.Size = new Size(27, 19);
            rotateImg_InRangeLowerBoundLabel.TabIndex = 4;
            rotateImg_InRangeLowerBoundLabel.Text = "50";
            // 
            // rotateImg_InRangeUpperBoundLabel
            // 
            rotateImg_InRangeUpperBoundLabel.AutoSize = true;
            rotateImg_InRangeUpperBoundLabel.Location = new Point(1000, 367);
            rotateImg_InRangeUpperBoundLabel.Name = "rotateImg_InRangeUpperBoundLabel";
            rotateImg_InRangeUpperBoundLabel.Size = new Size(36, 19);
            rotateImg_InRangeUpperBoundLabel.TabIndex = 3;
            rotateImg_InRangeUpperBoundLabel.Text = "200";
            // 
            // rotateImg_InRangeLowerBoundScrollBar
            // 
            rotateImg_InRangeLowerBoundScrollBar.LargeChange = 1;
            rotateImg_InRangeLowerBoundScrollBar.Location = new Point(604, 429);
            rotateImg_InRangeLowerBoundScrollBar.Maximum = 200;
            rotateImg_InRangeLowerBoundScrollBar.Name = "rotateImg_InRangeLowerBoundScrollBar";
            rotateImg_InRangeLowerBoundScrollBar.Size = new Size(383, 31);
            rotateImg_InRangeLowerBoundScrollBar.TabIndex = 2;
            rotateImg_InRangeLowerBoundScrollBar.Scroll += rotateImg_InRangeLowerBoundScrollBar_Scroll;
            // 
            // rotateImg_InRangeUpperBoundScrollBar
            // 
            rotateImg_InRangeUpperBoundScrollBar.LargeChange = 1;
            rotateImg_InRangeUpperBoundScrollBar.Location = new Point(604, 356);
            rotateImg_InRangeUpperBoundScrollBar.Maximum = 400;
            rotateImg_InRangeUpperBoundScrollBar.Minimum = 100;
            rotateImg_InRangeUpperBoundScrollBar.Name = "rotateImg_InRangeUpperBoundScrollBar";
            rotateImg_InRangeUpperBoundScrollBar.Size = new Size(383, 30);
            rotateImg_InRangeUpperBoundScrollBar.TabIndex = 1;
            rotateImg_InRangeUpperBoundScrollBar.Value = 100;
            rotateImg_InRangeUpperBoundScrollBar.Scroll += rotateImg_InRangeUpperBoundScrollBar_Scroll;
            // 
            // CannyBtn
            // 
            CannyBtn.Location = new Point(924, 489);
            CannyBtn.Margin = new Padding(4);
            CannyBtn.Name = "CannyBtn";
            CannyBtn.Size = new Size(134, 35);
            CannyBtn.TabIndex = 26;
            CannyBtn.Text = "邊緣二值化測試";
            CannyBtn.UseVisualStyleBackColor = true;
            CannyBtn.Click += CannyBtn_Click;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.ForeColor = SystemColors.ControlText;
            label20.Location = new Point(604, 314);
            label20.Margin = new Padding(4, 0, 4, 0);
            label20.Name = "label20";
            label20.Size = new Size(162, 19);
            label20.TabIndex = 27;
            label20.Text = "Canny 邊緣偵測二值化";
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
            tabPage2.Location = new Point(4, 28);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(572, 628);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "blob偵測";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // FindContoursWayComboBox
            // 
            FindContoursWayComboBox.FormattingEnabled = true;
            FindContoursWayComboBox.Items.AddRange(new object[] { "External", "List" });
            FindContoursWayComboBox.Location = new Point(109, 579);
            FindContoursWayComboBox.Margin = new Padding(4);
            FindContoursWayComboBox.Name = "FindContoursWayComboBox";
            FindContoursWayComboBox.Size = new Size(206, 27);
            FindContoursWayComboBox.TabIndex = 33;
            FindContoursWayComboBox.SelectedIndexChanged += FindContoursWayComboBox_SelectedIndexChanged;
            // 
            // blobDetect_Dilate_Erode_Mask_Size_NumericUpDown
            // 
            blobDetect_Dilate_Erode_Mask_Size_NumericUpDown.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            blobDetect_Dilate_Erode_Mask_Size_NumericUpDown.Location = new Point(269, 242);
            blobDetect_Dilate_Erode_Mask_Size_NumericUpDown.Margin = new Padding(4);
            blobDetect_Dilate_Erode_Mask_Size_NumericUpDown.Maximum = new decimal(new int[] { 17, 0, 0, 0 });
            blobDetect_Dilate_Erode_Mask_Size_NumericUpDown.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            blobDetect_Dilate_Erode_Mask_Size_NumericUpDown.Name = "blobDetect_Dilate_Erode_Mask_Size_NumericUpDown";
            blobDetect_Dilate_Erode_Mask_Size_NumericUpDown.Size = new Size(95, 27);
            blobDetect_Dilate_Erode_Mask_Size_NumericUpDown.TabIndex = 25;
            blobDetect_Dilate_Erode_Mask_Size_NumericUpDown.Value = new decimal(new int[] { 3, 0, 0, 0 });
            blobDetect_Dilate_Erode_Mask_Size_NumericUpDown.ValueChanged += Dilate_Erode_Mask_Size_NumericUpDown_ValueChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(19, 583);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(84, 19);
            label12.TabIndex = 32;
            label12.Text = "找輪廓方法";
            // 
            // blobDetect_ErodeFlagCheckBox
            // 
            blobDetect_ErodeFlagCheckBox.AutoSize = true;
            blobDetect_ErodeFlagCheckBox.Location = new Point(95, 247);
            blobDetect_ErodeFlagCheckBox.Margin = new Padding(4);
            blobDetect_ErodeFlagCheckBox.Name = "blobDetect_ErodeFlagCheckBox";
            blobDetect_ErodeFlagCheckBox.Size = new Size(61, 23);
            blobDetect_ErodeFlagCheckBox.TabIndex = 24;
            blobDetect_ErodeFlagCheckBox.Text = "侵蝕";
            blobDetect_ErodeFlagCheckBox.UseVisualStyleBackColor = true;
            blobDetect_ErodeFlagCheckBox.CheckedChanged += ErodeFlagCheckBox_CheckedChanged;
            // 
            // blob_AreaRatioLabel
            // 
            blob_AreaRatioLabel.AutoSize = true;
            blob_AreaRatioLabel.Location = new Point(413, 531);
            blob_AreaRatioLabel.Name = "blob_AreaRatioLabel";
            blob_AreaRatioLabel.Size = new Size(27, 19);
            blob_AreaRatioLabel.TabIndex = 31;
            blob_AreaRatioLabel.Text = "30";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(19, 500);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(175, 19);
            label9.TabIndex = 30;
            label9.Text = "外接圓面積與blob面積比";
            // 
            // blobDetect_DilateFlagCheckBox
            // 
            blobDetect_DilateFlagCheckBox.AutoSize = true;
            blobDetect_DilateFlagCheckBox.Location = new Point(23, 247);
            blobDetect_DilateFlagCheckBox.Margin = new Padding(4);
            blobDetect_DilateFlagCheckBox.Name = "blobDetect_DilateFlagCheckBox";
            blobDetect_DilateFlagCheckBox.Size = new Size(61, 23);
            blobDetect_DilateFlagCheckBox.TabIndex = 23;
            blobDetect_DilateFlagCheckBox.Text = "膨脹";
            blobDetect_DilateFlagCheckBox.UseVisualStyleBackColor = true;
            blobDetect_DilateFlagCheckBox.CheckedChanged += DilateFlagCheckBox_CheckedChanged;
            // 
            // blobAreaRatioBar
            // 
            blobAreaRatioBar.LargeChange = 1;
            blobAreaRatioBar.Location = new Point(19, 519);
            blobAreaRatioBar.Name = "blobAreaRatioBar";
            blobAreaRatioBar.Size = new Size(383, 24);
            blobAreaRatioBar.TabIndex = 29;
            blobAreaRatioBar.Scroll += blobAreaRatioBar_Scroll;
            // 
            // blob_maxRadiusLabel
            // 
            blob_maxRadiusLabel.AutoSize = true;
            blob_maxRadiusLabel.Location = new Point(413, 464);
            blob_maxRadiusLabel.Name = "blob_maxRadiusLabel";
            blob_maxRadiusLabel.Size = new Size(27, 19);
            blob_maxRadiusLabel.TabIndex = 28;
            blob_maxRadiusLabel.Text = "30";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(180, 248);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(80, 19);
            label11.TabIndex = 22;
            label11.Text = "mask 大小";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(19, 433);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(145, 19);
            label10.TabIndex = 27;
            label10.Text = "blob外接圓最大半徑";
            // 
            // blob_maxRadiusBar
            // 
            blob_maxRadiusBar.LargeChange = 1;
            blob_maxRadiusBar.Location = new Point(19, 452);
            blob_maxRadiusBar.Maximum = 1000;
            blob_maxRadiusBar.Name = "blob_maxRadiusBar";
            blob_maxRadiusBar.Size = new Size(383, 24);
            blob_maxRadiusBar.TabIndex = 26;
            blob_maxRadiusBar.Scroll += solderBall_maxRadiusBar_Scroll;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(18, 220);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(129, 19);
            label7.TabIndex = 21;
            label7.Text = "二值化膨脹與侵蝕";
            // 
            // blob_minRadiusLabel
            // 
            blob_minRadiusLabel.AutoSize = true;
            blob_minRadiusLabel.Location = new Point(413, 398);
            blob_minRadiusLabel.Name = "blob_minRadiusLabel";
            blob_minRadiusLabel.Size = new Size(27, 19);
            blob_minRadiusLabel.TabIndex = 25;
            blob_minRadiusLabel.Text = "10";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(19, 367);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(145, 19);
            label8.TabIndex = 24;
            label8.Text = "blob外接圓最小半徑";
            // 
            // blob_minRadiusBar
            // 
            blob_minRadiusBar.LargeChange = 1;
            blob_minRadiusBar.Location = new Point(19, 386);
            blob_minRadiusBar.Maximum = 1000;
            blob_minRadiusBar.Name = "blob_minRadiusBar";
            blob_minRadiusBar.Size = new Size(383, 24);
            blob_minRadiusBar.TabIndex = 23;
            blob_minRadiusBar.Scroll += solderBall_minRadiusBar_Scroll;
            // 
            // blob_maxAreaLabel
            // 
            blob_maxAreaLabel.AutoSize = true;
            blob_maxAreaLabel.Location = new Point(413, 332);
            blob_maxAreaLabel.Name = "blob_maxAreaLabel";
            blob_maxAreaLabel.Size = new Size(36, 19);
            blob_maxAreaLabel.TabIndex = 22;
            blob_maxAreaLabel.Text = "900";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 301);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(285, 19);
            label5.TabIndex = 21;
            label5.Text = "blob最大面積 pixel 平方(體積異常為紅圈)";
            // 
            // blobDetect_binaryImg
            // 
            blobDetect_binaryImg.Location = new Point(453, 236);
            blobDetect_binaryImg.Margin = new Padding(4);
            blobDetect_binaryImg.Name = "blobDetect_binaryImg";
            blobDetect_binaryImg.Size = new Size(113, 35);
            blobDetect_binaryImg.TabIndex = 10;
            blobDetect_binaryImg.Text = "二值化測試";
            blobDetect_binaryImg.UseVisualStyleBackColor = true;
            blobDetect_binaryImg.Click += blobDetect_binaryImg_Click;
            // 
            // blobDetect_imgBinaryTabCtrl
            // 
            blobDetect_imgBinaryTabCtrl.Controls.Add(tabPage4);
            blobDetect_imgBinaryTabCtrl.Controls.Add(tabPage3);
            blobDetect_imgBinaryTabCtrl.Location = new Point(18, 35);
            blobDetect_imgBinaryTabCtrl.Name = "blobDetect_imgBinaryTabCtrl";
            blobDetect_imgBinaryTabCtrl.SelectedIndex = 0;
            blobDetect_imgBinaryTabCtrl.Size = new Size(485, 182);
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
            tabPage4.Location = new Point(4, 28);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(477, 150);
            tabPage4.TabIndex = 1;
            tabPage4.Text = "InRange";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 80);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(98, 19);
            label4.TabIndex = 20;
            label4.Text = "lower bound";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 6);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 19);
            label2.TabIndex = 19;
            label2.Text = "upper bound";
            // 
            // blobDetect_InRangeLowerBoundLabel
            // 
            blobDetect_InRangeLowerBoundLabel.AutoSize = true;
            blobDetect_InRangeLowerBoundLabel.Location = new Point(408, 108);
            blobDetect_InRangeLowerBoundLabel.Name = "blobDetect_InRangeLowerBoundLabel";
            blobDetect_InRangeLowerBoundLabel.Size = new Size(27, 19);
            blobDetect_InRangeLowerBoundLabel.TabIndex = 4;
            blobDetect_InRangeLowerBoundLabel.Text = "50";
            // 
            // blobDetect_InRangeUpperBoundLabel
            // 
            blobDetect_InRangeUpperBoundLabel.AutoSize = true;
            blobDetect_InRangeUpperBoundLabel.Location = new Point(408, 34);
            blobDetect_InRangeUpperBoundLabel.Name = "blobDetect_InRangeUpperBoundLabel";
            blobDetect_InRangeUpperBoundLabel.Size = new Size(36, 19);
            blobDetect_InRangeUpperBoundLabel.TabIndex = 3;
            blobDetect_InRangeUpperBoundLabel.Text = "200";
            // 
            // blobDetect_InRangeLowerBoundScrollBar
            // 
            blobDetect_InRangeLowerBoundScrollBar.LargeChange = 1;
            blobDetect_InRangeLowerBoundScrollBar.Location = new Point(14, 99);
            blobDetect_InRangeLowerBoundScrollBar.Maximum = 255;
            blobDetect_InRangeLowerBoundScrollBar.Name = "blobDetect_InRangeLowerBoundScrollBar";
            blobDetect_InRangeLowerBoundScrollBar.Size = new Size(383, 31);
            blobDetect_InRangeLowerBoundScrollBar.TabIndex = 2;
            blobDetect_InRangeLowerBoundScrollBar.Scroll += lowerBoundScrollBar_Scroll;
            // 
            // blobDetect_InRangeUpperBoundScrollBar
            // 
            blobDetect_InRangeUpperBoundScrollBar.LargeChange = 1;
            blobDetect_InRangeUpperBoundScrollBar.Location = new Point(14, 25);
            blobDetect_InRangeUpperBoundScrollBar.Maximum = 255;
            blobDetect_InRangeUpperBoundScrollBar.Name = "blobDetect_InRangeUpperBoundScrollBar";
            blobDetect_InRangeUpperBoundScrollBar.Size = new Size(383, 30);
            blobDetect_InRangeUpperBoundScrollBar.TabIndex = 1;
            blobDetect_InRangeUpperBoundScrollBar.Scroll += upperBoundScrollBar_Scroll;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 28);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(477, 150);
            tabPage3.TabIndex = 0;
            tabPage3.Text = "Otsu";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // blob_maxAreaBar
            // 
            blob_maxAreaBar.LargeChange = 1;
            blob_maxAreaBar.Location = new Point(19, 320);
            blob_maxAreaBar.Maximum = 5000;
            blob_maxAreaBar.Name = "blob_maxAreaBar";
            blob_maxAreaBar.Size = new Size(383, 24);
            blob_maxAreaBar.TabIndex = 20;
            blob_maxAreaBar.Scroll += solderBall_maxAreaBar_Scroll;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 14);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(99, 19);
            label3.TabIndex = 17;
            label3.Text = "二值化演算法";
            // 
            // blobDetectButton
            // 
            blobDetectButton.Location = new Point(453, 583);
            blobDetectButton.Margin = new Padding(4);
            blobDetectButton.Name = "blobDetectButton";
            blobDetectButton.Size = new Size(113, 35);
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
            saveGroup.Location = new Point(17, 992);
            saveGroup.Name = "saveGroup";
            saveGroup.Size = new Size(584, 98);
            saveGroup.TabIndex = 15;
            saveGroup.TabStop = false;
            saveGroup.Text = "saveGroup";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(411, 65);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(44, 19);
            label1.TabIndex = 5;
            label1.Text = ".bmp";
            // 
            // targetImgPanel
            // 
            targetImgPanel.BackColor = SystemColors.ControlDark;
            targetImgPanel.Location = new Point(332, 28);
            targetImgPanel.Margin = new Padding(4);
            targetImgPanel.Name = "targetImgPanel";
            targetImgPanel.Size = new Size(265, 234);
            targetImgPanel.TabIndex = 14;
            // 
            // targetImgBtn
            // 
            targetImgBtn.Location = new Point(211, 28);
            targetImgBtn.Margin = new Padding(4);
            targetImgBtn.Name = "targetImgBtn";
            targetImgBtn.Size = new Size(113, 35);
            targetImgBtn.TabIndex = 13;
            targetImgBtn.Text = "開啟目標影像";
            targetImgBtn.UseVisualStyleBackColor = true;
            targetImgBtn.Click += targetImgBtn_Click;
            // 
            // cropImgBtn
            // 
            cropImgBtn.Location = new Point(19, 132);
            cropImgBtn.Margin = new Padding(4);
            cropImgBtn.Name = "cropImgBtn";
            cropImgBtn.Size = new Size(113, 35);
            cropImgBtn.TabIndex = 12;
            cropImgBtn.Text = "截圖";
            cropImgBtn.UseVisualStyleBackColor = true;
            cropImgBtn.Click += cropImgBtn_Click;
            // 
            // findTargetBtn
            // 
            findTargetBtn.Location = new Point(211, 79);
            findTargetBtn.Margin = new Padding(4);
            findTargetBtn.Name = "findTargetBtn";
            findTargetBtn.Size = new Size(114, 35);
            findTargetBtn.TabIndex = 11;
            findTargetBtn.Text = "找目標";
            findTargetBtn.UseVisualStyleBackColor = true;
            findTargetBtn.Click += findTargetBtn_Click;
            // 
            // rectangleBtn
            // 
            rectangleBtn.Location = new Point(19, 79);
            rectangleBtn.Margin = new Padding(4);
            rectangleBtn.Name = "rectangleBtn";
            rectangleBtn.Size = new Size(113, 35);
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
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(13, 26);
            label18.Margin = new Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new Size(429, 114);
            label18.TabIndex = 35;
            label18.Text = "請先至 blob偵測頁籤找尋想要轉正的目標物件\r\n如 晶片內較為方正的物件\r\n或 整個晶片較清楚之外輪廓\r\n當左方畫面中已圈出目標物件，則可再回到此頁籤按下轉正按鈕\r\n\r\n備註：blob偵測時，請調整參數將圈出的物件數量控制在1個\r\n";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 1175);
            Controls.Add(functionBtnGroup);
            Controls.Add(pixelInfoGroup);
            Controls.Add(panel1);
            Margin = new Padding(4);
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
            ((System.ComponentModel.ISupportInitialize)rotateImg_Dilate_Erode_Mask_Size_NumericUpDown).EndInit();
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
        private Button CannyBtn;
        private Label label16;
        private Label label17;
        private Label rotateImg_InRangeLowerBoundLabel;
        private Label rotateImg_InRangeUpperBoundLabel;
        private HScrollBar rotateImg_InRangeLowerBoundScrollBar;
        private HScrollBar rotateImg_InRangeUpperBoundScrollBar;
        private Label label20;
        private Button rotateBtn;
        private NumericUpDown rotateImg_Dilate_Erode_Mask_Size_NumericUpDown;
        private CheckBox rotateImg_ErodeFlagCheckBox;
        private CheckBox rotateImg_DilateFlagCheckBox;
        private Label label14;
        private Label label15;
        private Label label18;
    }
}