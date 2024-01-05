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
            rotateImg_Dilate_Erode_Mask_Size_NumericUpDown = new NumericUpDown();
            parameterFileGroup = new GroupBox();
            openParameterFilePathLabel = new TextBox();
            openParameterFileBtn = new Button();
            saveParameterLabel = new TextBox();
            saveParameterBtn = new Button();
            label13 = new Label();
            rotateImg_ErodeFlagCheckBox = new CheckBox();
            ConsoleGroupBox = new GroupBox();
            consoleLabel = new Label();
            rotateImg_DilateFlagCheckBox = new CheckBox();
            rotateBtn_test = new Button();
            label14 = new Label();
            label6 = new Label();
            label15 = new Label();
            rotateAngleTextBox = new TextBox();
            label16 = new Label();
            elementImgBtn = new Button();
            findElementBtn = new Button();
            label17 = new Label();
            elementImgPanel = new Panel();
            rotateImg_InRangeLowerBoundLabel = new Label();
            TabGroup = new TabControl();
            tabPage2 = new TabPage();
            invertBinaryFlagCheckBox = new CheckBox();
            Dilate_Erode_Direction_ComboBox = new ComboBox();
            label21 = new Label();
            FindContoursWayComboBox = new ComboBox();
            Dilate_Erode_Mask_Size_NumericUpDown = new NumericUpDown();
            label12 = new Label();
            ErodeFlagCheckBox = new CheckBox();
            blob_AreaRatioLabel = new Label();
            label9 = new Label();
            DilateFlagCheckBox = new CheckBox();
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
            binaryImgBtn = new Button();
            blobDetect_imgBinaryTabCtrl = new TabControl();
            tabPage4 = new TabPage();
            label4 = new Label();
            label2 = new Label();
            InRangeLowerBoundLabel = new Label();
            InRangeUpperBoundLabel = new Label();
            InRangeLowerBoundScrollBar = new HScrollBar();
            InRangeUpperBoundScrollBar = new HScrollBar();
            tabPage3 = new TabPage();
            blob_maxAreaBar = new HScrollBar();
            label3 = new Label();
            blobDetectButton = new Button();
            tabPage1 = new TabPage();
            label19 = new Label();
            rotateWayComboBox = new ComboBox();
            label18 = new Label();
            rotateBtn = new Button();
            rotateImg_InRangeUpperBoundLabel = new Label();
            saveGroup = new GroupBox();
            label1 = new Label();
            rotateImg_InRangeLowerBoundScrollBar = new HScrollBar();
            targetImgPanel = new Panel();
            rotateImg_InRangeUpperBoundScrollBar = new HScrollBar();
            targetImgBtn = new Button();
            CannyBtn = new Button();
            cropImgBtn = new Button();
            label20 = new Label();
            findTargetBtn = new Button();
            rectangleBtn = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            pixelInfoGroup.SuspendLayout();
            functionBtnGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)rotateImg_Dilate_Erode_Mask_Size_NumericUpDown).BeginInit();
            parameterFileGroup.SuspendLayout();
            ConsoleGroupBox.SuspendLayout();
            TabGroup.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Dilate_Erode_Mask_Size_NumericUpDown).BeginInit();
            blobDetect_imgBinaryTabCtrl.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPage1.SuspendLayout();
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
            functionBtnGroup.Location = new Point(612, 20);
            functionBtnGroup.Name = "functionBtnGroup";
            functionBtnGroup.Size = new Size(852, 928);
            functionBtnGroup.TabIndex = 12;
            functionBtnGroup.TabStop = false;
            functionBtnGroup.Text = "functionBtnGroup";
            // 
            // rotateImg_Dilate_Erode_Mask_Size_NumericUpDown
            // 
            rotateImg_Dilate_Erode_Mask_Size_NumericUpDown.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            rotateImg_Dilate_Erode_Mask_Size_NumericUpDown.Location = new Point(658, 391);
            rotateImg_Dilate_Erode_Mask_Size_NumericUpDown.Maximum = new decimal(new int[] { 17, 0, 0, 0 });
            rotateImg_Dilate_Erode_Mask_Size_NumericUpDown.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            rotateImg_Dilate_Erode_Mask_Size_NumericUpDown.Name = "rotateImg_Dilate_Erode_Mask_Size_NumericUpDown";
            rotateImg_Dilate_Erode_Mask_Size_NumericUpDown.Size = new Size(46, 23);
            rotateImg_Dilate_Erode_Mask_Size_NumericUpDown.TabIndex = 39;
            rotateImg_Dilate_Erode_Mask_Size_NumericUpDown.Value = new decimal(new int[] { 3, 0, 0, 0 });
            rotateImg_Dilate_Erode_Mask_Size_NumericUpDown.ValueChanged += rotateImg_Dilate_Erode_Mask_Size_NumericUpDown_ValueChanged;
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
            // rotateImg_ErodeFlagCheckBox
            // 
            rotateImg_ErodeFlagCheckBox.AutoSize = true;
            rotateImg_ErodeFlagCheckBox.Location = new Point(528, 395);
            rotateImg_ErodeFlagCheckBox.Name = "rotateImg_ErodeFlagCheckBox";
            rotateImg_ErodeFlagCheckBox.Size = new Size(50, 19);
            rotateImg_ErodeFlagCheckBox.TabIndex = 38;
            rotateImg_ErodeFlagCheckBox.Text = "侵蝕";
            rotateImg_ErodeFlagCheckBox.UseVisualStyleBackColor = true;
            rotateImg_ErodeFlagCheckBox.CheckedChanged += rotateImg_ErodeFlagCheckBox_CheckedChanged;
            // 
            // ConsoleGroupBox
            // 
            ConsoleGroupBox.Controls.Add(consoleLabel);
            ConsoleGroupBox.Location = new Point(482, 480);
            ConsoleGroupBox.Name = "ConsoleGroupBox";
            ConsoleGroupBox.Size = new Size(288, 295);
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
            // rotateImg_DilateFlagCheckBox
            // 
            rotateImg_DilateFlagCheckBox.AutoSize = true;
            rotateImg_DilateFlagCheckBox.Location = new Point(472, 395);
            rotateImg_DilateFlagCheckBox.Name = "rotateImg_DilateFlagCheckBox";
            rotateImg_DilateFlagCheckBox.Size = new Size(50, 19);
            rotateImg_DilateFlagCheckBox.TabIndex = 37;
            rotateImg_DilateFlagCheckBox.Text = "膨脹";
            rotateImg_DilateFlagCheckBox.UseVisualStyleBackColor = true;
            rotateImg_DilateFlagCheckBox.CheckedChanged += rotateImg_DilateFlagCheckBox_CheckedChanged;
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
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(589, 396);
            label14.Name = "label14";
            label14.Size = new Size(63, 15);
            label14.TabIndex = 36;
            label14.Text = "mask 大小";
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
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(468, 373);
            label15.Name = "label15";
            label15.Size = new Size(103, 15);
            label15.TabIndex = 35;
            label15.Text = "二值化膨脹與侵蝕";
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
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(471, 326);
            label16.Name = "label16";
            label16.Size = new Size(79, 15);
            label16.TabIndex = 20;
            label16.Text = "lower bound";
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
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(471, 268);
            label17.Name = "label17";
            label17.Size = new Size(82, 15);
            label17.TabIndex = 19;
            label17.Text = "upper bound";
            // 
            // elementImgPanel
            // 
            elementImgPanel.BackColor = SystemColors.ControlDark;
            elementImgPanel.Location = new Point(617, 22);
            elementImgPanel.Name = "elementImgPanel";
            elementImgPanel.Size = new Size(206, 185);
            elementImgPanel.TabIndex = 15;
            // 
            // rotateImg_InRangeLowerBoundLabel
            // 
            rotateImg_InRangeLowerBoundLabel.AutoSize = true;
            rotateImg_InRangeLowerBoundLabel.Location = new Point(778, 348);
            rotateImg_InRangeLowerBoundLabel.Margin = new Padding(2, 0, 2, 0);
            rotateImg_InRangeLowerBoundLabel.Name = "rotateImg_InRangeLowerBoundLabel";
            rotateImg_InRangeLowerBoundLabel.Size = new Size(21, 15);
            rotateImg_InRangeLowerBoundLabel.TabIndex = 4;
            rotateImg_InRangeLowerBoundLabel.Text = "50";
            // 
            // TabGroup
            // 
            TabGroup.Controls.Add(tabPage2);
            TabGroup.Controls.Add(tabPage1);
            TabGroup.Location = new Point(13, 226);
            TabGroup.Margin = new Padding(2);
            TabGroup.Name = "TabGroup";
            TabGroup.SelectedIndex = 0;
            TabGroup.Size = new Size(451, 553);
            TabGroup.TabIndex = 16;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(invertBinaryFlagCheckBox);
            tabPage2.Controls.Add(Dilate_Erode_Direction_ComboBox);
            tabPage2.Controls.Add(label21);
            tabPage2.Controls.Add(FindContoursWayComboBox);
            tabPage2.Controls.Add(Dilate_Erode_Mask_Size_NumericUpDown);
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(ErodeFlagCheckBox);
            tabPage2.Controls.Add(blob_AreaRatioLabel);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(DilateFlagCheckBox);
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
            tabPage2.Controls.Add(binaryImgBtn);
            tabPage2.Controls.Add(blobDetect_imgBinaryTabCtrl);
            tabPage2.Controls.Add(blob_maxAreaBar);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(blobDetectButton);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(2);
            tabPage2.Size = new Size(443, 525);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "blob偵測";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // invertBinaryFlagCheckBox
            // 
            invertBinaryFlagCheckBox.AutoSize = true;
            invertBinaryFlagCheckBox.Location = new Point(354, 138);
            invertBinaryFlagCheckBox.Name = "invertBinaryFlagCheckBox";
            invertBinaryFlagCheckBox.Size = new Size(86, 19);
            invertBinaryFlagCheckBox.TabIndex = 37;
            invertBinaryFlagCheckBox.Text = "二值化反轉";
            invertBinaryFlagCheckBox.UseVisualStyleBackColor = true;
            invertBinaryFlagCheckBox.CheckedChanged += blobDetect_invertBinaryFlagCheckBox_CheckedChanged;
            // 
            // Dilate_Erode_Direction_ComboBox
            // 
            Dilate_Erode_Direction_ComboBox.FormattingEnabled = true;
            Dilate_Erode_Direction_ComboBox.Items.AddRange(new object[] { "X", "Y", "XY" });
            Dilate_Erode_Direction_ComboBox.Location = new Point(352, 198);
            Dilate_Erode_Direction_ComboBox.Name = "Dilate_Erode_Direction_ComboBox";
            Dilate_Erode_Direction_ComboBox.Size = new Size(85, 23);
            Dilate_Erode_Direction_ComboBox.TabIndex = 35;
            Dilate_Erode_Direction_ComboBox.SelectedIndexChanged += Dilate_Erode_Direction_ComboBox_SelectedIndexChanged;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(269, 201);
            label21.Name = "label21";
            label21.Size = new Size(84, 15);
            label21.TabIndex = 34;
            label21.Text = "膨脹/侵蝕方向";
            label21.Click += label21_Click;
            // 
            // FindContoursWayComboBox
            // 
            FindContoursWayComboBox.FormattingEnabled = true;
            FindContoursWayComboBox.Items.AddRange(new object[] { "External", "List" });
            FindContoursWayComboBox.Location = new Point(85, 485);
            FindContoursWayComboBox.Name = "FindContoursWayComboBox";
            FindContoursWayComboBox.Size = new Size(161, 23);
            FindContoursWayComboBox.TabIndex = 33;
            FindContoursWayComboBox.SelectedIndexChanged += FindContoursWayComboBox_SelectedIndexChanged;
            // 
            // Dilate_Erode_Mask_Size_NumericUpDown
            // 
            Dilate_Erode_Mask_Size_NumericUpDown.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            Dilate_Erode_Mask_Size_NumericUpDown.Location = new Point(200, 197);
            Dilate_Erode_Mask_Size_NumericUpDown.Maximum = new decimal(new int[] { 17, 0, 0, 0 });
            Dilate_Erode_Mask_Size_NumericUpDown.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            Dilate_Erode_Mask_Size_NumericUpDown.Name = "Dilate_Erode_Mask_Size_NumericUpDown";
            Dilate_Erode_Mask_Size_NumericUpDown.Size = new Size(44, 23);
            Dilate_Erode_Mask_Size_NumericUpDown.TabIndex = 25;
            Dilate_Erode_Mask_Size_NumericUpDown.Value = new decimal(new int[] { 3, 0, 0, 0 });
            Dilate_Erode_Mask_Size_NumericUpDown.ValueChanged += Dilate_Erode_Mask_Size_NumericUpDown_ValueChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(15, 488);
            label12.Name = "label12";
            label12.Size = new Size(67, 15);
            label12.TabIndex = 32;
            label12.Text = "找輪廓方法";
            // 
            // ErodeFlagCheckBox
            // 
            ErodeFlagCheckBox.AutoSize = true;
            ErodeFlagCheckBox.Location = new Point(71, 201);
            ErodeFlagCheckBox.Name = "ErodeFlagCheckBox";
            ErodeFlagCheckBox.Size = new Size(50, 19);
            ErodeFlagCheckBox.TabIndex = 24;
            ErodeFlagCheckBox.Text = "侵蝕";
            ErodeFlagCheckBox.UseVisualStyleBackColor = true;
            ErodeFlagCheckBox.CheckedChanged += ErodeFlagCheckBox_CheckedChanged;
            // 
            // blob_AreaRatioLabel
            // 
            blob_AreaRatioLabel.AutoSize = true;
            blob_AreaRatioLabel.Location = new Point(321, 447);
            blob_AreaRatioLabel.Margin = new Padding(2, 0, 2, 0);
            blob_AreaRatioLabel.Name = "blob_AreaRatioLabel";
            blob_AreaRatioLabel.Size = new Size(21, 15);
            blob_AreaRatioLabel.TabIndex = 31;
            blob_AreaRatioLabel.Text = "30";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(15, 423);
            label9.Name = "label9";
            label9.Size = new Size(142, 15);
            label9.TabIndex = 30;
            label9.Text = "外接圓面積與blob面積比";
            // 
            // DilateFlagCheckBox
            // 
            DilateFlagCheckBox.AutoSize = true;
            DilateFlagCheckBox.Location = new Point(18, 201);
            DilateFlagCheckBox.Name = "DilateFlagCheckBox";
            DilateFlagCheckBox.Size = new Size(50, 19);
            DilateFlagCheckBox.TabIndex = 23;
            DilateFlagCheckBox.Text = "膨脹";
            DilateFlagCheckBox.UseVisualStyleBackColor = true;
            DilateFlagCheckBox.CheckedChanged += DilateFlagCheckBox_CheckedChanged;
            // 
            // blobAreaRatioBar
            // 
            blobAreaRatioBar.LargeChange = 1;
            blobAreaRatioBar.Location = new Point(15, 438);
            blobAreaRatioBar.Name = "blobAreaRatioBar";
            blobAreaRatioBar.Size = new Size(298, 24);
            blobAreaRatioBar.TabIndex = 29;
            blobAreaRatioBar.Scroll += blobAreaRatioBar_Scroll;
            // 
            // blob_maxRadiusLabel
            // 
            blob_maxRadiusLabel.AutoSize = true;
            blob_maxRadiusLabel.Location = new Point(321, 394);
            blob_maxRadiusLabel.Margin = new Padding(2, 0, 2, 0);
            blob_maxRadiusLabel.Name = "blob_maxRadiusLabel";
            blob_maxRadiusLabel.Size = new Size(21, 15);
            blob_maxRadiusLabel.TabIndex = 28;
            blob_maxRadiusLabel.Text = "30";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(137, 202);
            label11.Name = "label11";
            label11.Size = new Size(63, 15);
            label11.TabIndex = 22;
            label11.Text = "mask 大小";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(15, 370);
            label10.Name = "label10";
            label10.Size = new Size(118, 15);
            label10.TabIndex = 27;
            label10.Text = "blob外接圓最大半徑";
            // 
            // blob_maxRadiusBar
            // 
            blob_maxRadiusBar.LargeChange = 1;
            blob_maxRadiusBar.Location = new Point(15, 385);
            blob_maxRadiusBar.Maximum = 1000;
            blob_maxRadiusBar.Name = "blob_maxRadiusBar";
            blob_maxRadiusBar.Size = new Size(298, 24);
            blob_maxRadiusBar.TabIndex = 26;
            blob_maxRadiusBar.Scroll += solderBall_maxRadiusBar_Scroll;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 184);
            label7.Name = "label7";
            label7.Size = new Size(103, 15);
            label7.TabIndex = 21;
            label7.Text = "二值化膨脹與侵蝕";
            // 
            // blob_minRadiusLabel
            // 
            blob_minRadiusLabel.AutoSize = true;
            blob_minRadiusLabel.Location = new Point(321, 342);
            blob_minRadiusLabel.Margin = new Padding(2, 0, 2, 0);
            blob_minRadiusLabel.Name = "blob_minRadiusLabel";
            blob_minRadiusLabel.Size = new Size(21, 15);
            blob_minRadiusLabel.TabIndex = 25;
            blob_minRadiusLabel.Text = "10";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 318);
            label8.Name = "label8";
            label8.Size = new Size(118, 15);
            label8.TabIndex = 24;
            label8.Text = "blob外接圓最小半徑";
            // 
            // blob_minRadiusBar
            // 
            blob_minRadiusBar.LargeChange = 1;
            blob_minRadiusBar.Location = new Point(15, 333);
            blob_minRadiusBar.Maximum = 1000;
            blob_minRadiusBar.Name = "blob_minRadiusBar";
            blob_minRadiusBar.Size = new Size(298, 24);
            blob_minRadiusBar.TabIndex = 23;
            blob_minRadiusBar.Scroll += solderBall_minRadiusBar_Scroll;
            // 
            // blob_maxAreaLabel
            // 
            blob_maxAreaLabel.AutoSize = true;
            blob_maxAreaLabel.Location = new Point(321, 290);
            blob_maxAreaLabel.Margin = new Padding(2, 0, 2, 0);
            blob_maxAreaLabel.Name = "blob_maxAreaLabel";
            blob_maxAreaLabel.Size = new Size(28, 15);
            blob_maxAreaLabel.TabIndex = 22;
            blob_maxAreaLabel.Text = "900";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 266);
            label5.Name = "label5";
            label5.Size = new Size(231, 15);
            label5.TabIndex = 21;
            label5.Text = "blob最大面積 pixel 平方(體積異常為紅圈)";
            // 
            // binaryImgBtn
            // 
            binaryImgBtn.Location = new Point(352, 230);
            binaryImgBtn.Name = "binaryImgBtn";
            binaryImgBtn.Size = new Size(88, 28);
            binaryImgBtn.TabIndex = 10;
            binaryImgBtn.Text = "二值化測試";
            binaryImgBtn.UseVisualStyleBackColor = true;
            binaryImgBtn.Click += blobDetect_binaryImg_Click;
            // 
            // blobDetect_imgBinaryTabCtrl
            // 
            blobDetect_imgBinaryTabCtrl.Controls.Add(tabPage4);
            blobDetect_imgBinaryTabCtrl.Controls.Add(tabPage3);
            blobDetect_imgBinaryTabCtrl.Location = new Point(14, 28);
            blobDetect_imgBinaryTabCtrl.Margin = new Padding(2);
            blobDetect_imgBinaryTabCtrl.Name = "blobDetect_imgBinaryTabCtrl";
            blobDetect_imgBinaryTabCtrl.SelectedIndex = 0;
            blobDetect_imgBinaryTabCtrl.Size = new Size(339, 133);
            blobDetect_imgBinaryTabCtrl.TabIndex = 18;
            blobDetect_imgBinaryTabCtrl.SelectedIndexChanged += imgBinaryTabCtrl_SelectedIndexChanged;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(label4);
            tabPage4.Controls.Add(label2);
            tabPage4.Controls.Add(InRangeLowerBoundLabel);
            tabPage4.Controls.Add(InRangeUpperBoundLabel);
            tabPage4.Controls.Add(InRangeLowerBoundScrollBar);
            tabPage4.Controls.Add(InRangeUpperBoundScrollBar);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Margin = new Padding(2);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(2);
            tabPage4.Size = new Size(331, 105);
            tabPage4.TabIndex = 1;
            tabPage4.Text = "InRange";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 55);
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
            // InRangeLowerBoundLabel
            // 
            InRangeLowerBoundLabel.AutoSize = true;
            InRangeLowerBoundLabel.Location = new Point(298, 77);
            InRangeLowerBoundLabel.Margin = new Padding(2, 0, 2, 0);
            InRangeLowerBoundLabel.Name = "InRangeLowerBoundLabel";
            InRangeLowerBoundLabel.Size = new Size(21, 15);
            InRangeLowerBoundLabel.TabIndex = 4;
            InRangeLowerBoundLabel.Text = "50";
            // 
            // InRangeUpperBoundLabel
            // 
            InRangeUpperBoundLabel.AutoSize = true;
            InRangeUpperBoundLabel.Location = new Point(295, 27);
            InRangeUpperBoundLabel.Margin = new Padding(2, 0, 2, 0);
            InRangeUpperBoundLabel.Name = "InRangeUpperBoundLabel";
            InRangeUpperBoundLabel.Size = new Size(28, 15);
            InRangeUpperBoundLabel.TabIndex = 3;
            InRangeUpperBoundLabel.Text = "200";
            InRangeUpperBoundLabel.Click += InRangeUpperBoundLabel_Click;
            // 
            // InRangeLowerBoundScrollBar
            // 
            InRangeLowerBoundScrollBar.LargeChange = 1;
            InRangeLowerBoundScrollBar.Location = new Point(11, 70);
            InRangeLowerBoundScrollBar.Maximum = 255;
            InRangeLowerBoundScrollBar.Name = "InRangeLowerBoundScrollBar";
            InRangeLowerBoundScrollBar.Size = new Size(284, 31);
            InRangeLowerBoundScrollBar.TabIndex = 2;
            InRangeLowerBoundScrollBar.Scroll += lowerBoundScrollBar_Scroll;
            // 
            // InRangeUpperBoundScrollBar
            // 
            InRangeUpperBoundScrollBar.LargeChange = 1;
            InRangeUpperBoundScrollBar.Location = new Point(11, 20);
            InRangeUpperBoundScrollBar.Maximum = 255;
            InRangeUpperBoundScrollBar.Name = "InRangeUpperBoundScrollBar";
            InRangeUpperBoundScrollBar.Size = new Size(284, 30);
            InRangeUpperBoundScrollBar.TabIndex = 1;
            InRangeUpperBoundScrollBar.Scroll += upperBoundScrollBar_Scroll;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Margin = new Padding(2);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(2);
            tabPage3.Size = new Size(331, 105);
            tabPage3.TabIndex = 0;
            tabPage3.Text = "Otsu";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // blob_maxAreaBar
            // 
            blob_maxAreaBar.LargeChange = 1;
            blob_maxAreaBar.Location = new Point(15, 281);
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
            blobDetectButton.Location = new Point(352, 488);
            blobDetectButton.Name = "blobDetectButton";
            blobDetectButton.Size = new Size(88, 28);
            blobDetectButton.TabIndex = 9;
            blobDetectButton.Text = "blob偵測";
            blobDetectButton.UseVisualStyleBackColor = true;
            blobDetectButton.Click += blobDetectButton_Click;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label19);
            tabPage1.Controls.Add(rotateWayComboBox);
            tabPage1.Controls.Add(label18);
            tabPage1.Controls.Add(rotateBtn);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(443, 525);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "轉正";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Enabled = false;
            label19.Location = new Point(218, 442);
            label19.Name = "label19";
            label19.Size = new Size(79, 15);
            label19.TabIndex = 38;
            label19.Text = "選擇轉正方法";
            label19.Visible = false;
            // 
            // rotateWayComboBox
            // 
            rotateWayComboBox.FormattingEnabled = true;
            rotateWayComboBox.Items.AddRange(new object[] { "oneBlob", "multiBlob" });
            rotateWayComboBox.Location = new Point(217, 463);
            rotateWayComboBox.Name = "rotateWayComboBox";
            rotateWayComboBox.Size = new Size(121, 23);
            rotateWayComboBox.TabIndex = 37;
            rotateWayComboBox.Visible = false;
            rotateWayComboBox.SelectedIndexChanged += rotateWayComboBox_SelectedIndexChanged;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label18.Location = new Point(21, 19);
            label18.Name = "label18";
            label18.Size = new Size(317, 72);
            label18.TabIndex = 35;
            label18.Text = "請先至 blob偵測頁籤找尋想要轉正的目標物件(群)\r\n(記得要按下 blob 偵測按鈕)\r\n轉正方法會先找出物件(群)的最小外接矩形\r\n再藉由此矩形進行角度旋轉\r\n";
            // 
            // rotateBtn
            // 
            rotateBtn.Location = new Point(344, 459);
            rotateBtn.Name = "rotateBtn";
            rotateBtn.Size = new Size(88, 28);
            rotateBtn.TabIndex = 34;
            rotateBtn.Text = "轉正";
            rotateBtn.UseVisualStyleBackColor = true;
            rotateBtn.Click += rotateImgBtn_Click;
            // 
            // rotateImg_InRangeUpperBoundLabel
            // 
            rotateImg_InRangeUpperBoundLabel.AutoSize = true;
            rotateImg_InRangeUpperBoundLabel.Location = new Point(778, 290);
            rotateImg_InRangeUpperBoundLabel.Margin = new Padding(2, 0, 2, 0);
            rotateImg_InRangeUpperBoundLabel.Name = "rotateImg_InRangeUpperBoundLabel";
            rotateImg_InRangeUpperBoundLabel.Size = new Size(28, 15);
            rotateImg_InRangeUpperBoundLabel.TabIndex = 3;
            rotateImg_InRangeUpperBoundLabel.Text = "200";
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
            // rotateImg_InRangeLowerBoundScrollBar
            // 
            rotateImg_InRangeLowerBoundScrollBar.LargeChange = 1;
            rotateImg_InRangeLowerBoundScrollBar.Location = new Point(470, 339);
            rotateImg_InRangeLowerBoundScrollBar.Maximum = 200;
            rotateImg_InRangeLowerBoundScrollBar.Name = "rotateImg_InRangeLowerBoundScrollBar";
            rotateImg_InRangeLowerBoundScrollBar.Size = new Size(298, 31);
            rotateImg_InRangeLowerBoundScrollBar.TabIndex = 2;
            rotateImg_InRangeLowerBoundScrollBar.Scroll += rotateImg_InRangeLowerBoundScrollBar_Scroll;
            // 
            // targetImgPanel
            // 
            targetImgPanel.BackColor = SystemColors.ControlDark;
            targetImgPanel.Location = new Point(258, 22);
            targetImgPanel.Name = "targetImgPanel";
            targetImgPanel.Size = new Size(206, 185);
            targetImgPanel.TabIndex = 14;
            // 
            // rotateImg_InRangeUpperBoundScrollBar
            // 
            rotateImg_InRangeUpperBoundScrollBar.LargeChange = 1;
            rotateImg_InRangeUpperBoundScrollBar.Location = new Point(470, 281);
            rotateImg_InRangeUpperBoundScrollBar.Maximum = 400;
            rotateImg_InRangeUpperBoundScrollBar.Minimum = 100;
            rotateImg_InRangeUpperBoundScrollBar.Name = "rotateImg_InRangeUpperBoundScrollBar";
            rotateImg_InRangeUpperBoundScrollBar.Size = new Size(298, 30);
            rotateImg_InRangeUpperBoundScrollBar.TabIndex = 1;
            rotateImg_InRangeUpperBoundScrollBar.Value = 100;
            rotateImg_InRangeUpperBoundScrollBar.Scroll += rotateImg_InRangeUpperBoundScrollBar_Scroll;
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
            // CannyBtn
            // 
            CannyBtn.Location = new Point(719, 386);
            CannyBtn.Name = "CannyBtn";
            CannyBtn.Size = new Size(104, 28);
            CannyBtn.TabIndex = 26;
            CannyBtn.Text = "邊緣二值化測試";
            CannyBtn.UseVisualStyleBackColor = true;
            CannyBtn.Click += CannyBtn_Click;
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
            // label20
            // 
            label20.AutoSize = true;
            label20.ForeColor = SystemColors.ControlText;
            label20.Location = new Point(470, 248);
            label20.Name = "label20";
            label20.Size = new Size(129, 15);
            label20.TabIndex = 27;
            label20.Text = "Canny 邊緣偵測二值化";
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
            ClientSize = new Size(1476, 928);
            Controls.Add(functionBtnGroup);
            Controls.Add(pixelInfoGroup);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            pixelInfoGroup.ResumeLayout(false);
            pixelInfoGroup.PerformLayout();
            functionBtnGroup.ResumeLayout(false);
            functionBtnGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)rotateImg_Dilate_Erode_Mask_Size_NumericUpDown).EndInit();
            parameterFileGroup.ResumeLayout(false);
            parameterFileGroup.PerformLayout();
            ConsoleGroupBox.ResumeLayout(false);
            ConsoleGroupBox.PerformLayout();
            TabGroup.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Dilate_Erode_Mask_Size_NumericUpDown).EndInit();
            blobDetect_imgBinaryTabCtrl.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
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
        private Button binaryImgBtn;
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
        private HScrollBar InRangeUpperBoundScrollBar;
        private Label InRangeLowerBoundLabel;
        private Label InRangeUpperBoundLabel;
        private HScrollBar InRangeLowerBoundScrollBar;
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
        private CheckBox DilateFlagCheckBox;
        private Label label11;
        private Label label7;
        private CheckBox ErodeFlagCheckBox;
        private NumericUpDown Dilate_Erode_Mask_Size_NumericUpDown;
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
        private ComboBox rotateWayComboBox;
        private Label label19;
        private Label label21;
        private ComboBox Dilate_Erode_Direction_ComboBox;
        private CheckBox invertBinaryFlagCheckBox;
    }
}