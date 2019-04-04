namespace serialcom
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.comport = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.baud = new System.Windows.Forms.ComboBox();
            this.labelbuan = new System.Windows.Forms.Label();
            this.comopen = new System.Windows.Forms.Button();
            this.receivedbox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hexshow = new System.Windows.Forms.CheckBox();
            this.asciishow = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Clearall = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.deccheck = new System.Windows.Forms.CheckBox();
            this.remote = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Databox = new System.Windows.Forms.ComboBox();
            this.stopbox = new System.Windows.Forms.ComboBox();
            this.verifybox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.hexsend = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sendbt = new System.Windows.Forms.Button();
            this.spacesend = new System.Windows.Forms.CheckBox();
            this.sendclear = new System.Windows.Forms.Button();
            this.sendlabel = new System.Windows.Forms.Label();
            this.sendbox = new System.Windows.Forms.RichTextBox();
            this.test = new System.Windows.Forms.Button();
            this.controlbox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.staticnum = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.read_selec = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dynamic_selec = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.mode_selec = new System.Windows.Forms.ComboBox();
            this.local_permit = new System.Windows.Forms.CheckedListBox();
            this.elec_switch = new System.Windows.Forms.CheckedListBox();
            this.selec_elec = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dynamic_check = new System.Windows.Forms.CheckedListBox();
            this.V_A = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.T_A = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.V_B = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.T_B = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comport
            // 
            this.comport.FormattingEnabled = true;
            this.comport.Location = new System.Drawing.Point(126, 50);
            this.comport.Name = "comport";
            this.comport.Size = new System.Drawing.Size(121, 23);
            this.comport.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "串口号：";
            // 
            // baud
            // 
            this.baud.FormattingEnabled = true;
            this.baud.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200",
            "128000",
            "256000"});
            this.baud.Location = new System.Drawing.Point(353, 50);
            this.baud.Name = "baud";
            this.baud.Size = new System.Drawing.Size(121, 23);
            this.baud.TabIndex = 2;
            // 
            // labelbuan
            // 
            this.labelbuan.AutoSize = true;
            this.labelbuan.Location = new System.Drawing.Point(280, 58);
            this.labelbuan.Name = "labelbuan";
            this.labelbuan.Size = new System.Drawing.Size(67, 15);
            this.labelbuan.TabIndex = 3;
            this.labelbuan.Text = "波特率：";
            // 
            // comopen
            // 
            this.comopen.Location = new System.Drawing.Point(56, 12);
            this.comopen.Name = "comopen";
            this.comopen.Size = new System.Drawing.Size(83, 32);
            this.comopen.TabIndex = 0;
            this.comopen.Text = "打开串口";
            this.comopen.UseVisualStyleBackColor = true;
            this.comopen.Click += new System.EventHandler(this.comopen_Click);
            // 
            // receivedbox
            // 
            this.receivedbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.receivedbox.Location = new System.Drawing.Point(9, 39);
            this.receivedbox.Name = "receivedbox";
            this.receivedbox.Size = new System.Drawing.Size(481, 392);
            this.receivedbox.TabIndex = 5;
            this.receivedbox.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "接收窗口";
            // 
            // hexshow
            // 
            this.hexshow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hexshow.AutoSize = true;
            this.hexshow.Location = new System.Drawing.Point(28, 483);
            this.hexshow.Name = "hexshow";
            this.hexshow.Size = new System.Drawing.Size(89, 19);
            this.hexshow.TabIndex = 10;
            this.hexshow.Text = "十六进制";
            this.hexshow.UseVisualStyleBackColor = true;
            // 
            // asciishow
            // 
            this.asciishow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.asciishow.AutoSize = true;
            this.asciishow.Location = new System.Drawing.Point(136, 485);
            this.asciishow.Name = "asciishow";
            this.asciishow.Size = new System.Drawing.Size(99, 19);
            this.asciishow.TabIndex = 11;
            this.asciishow.Text = "ASCII显示";
            this.asciishow.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "已接收：0";
            // 
            // Clearall
            // 
            this.Clearall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Clearall.Location = new System.Drawing.Point(286, 477);
            this.Clearall.Name = "Clearall";
            this.Clearall.Size = new System.Drawing.Size(75, 23);
            this.Clearall.TabIndex = 13;
            this.Clearall.Text = "清空显示";
            this.Clearall.UseVisualStyleBackColor = true;
            this.Clearall.Click += new System.EventHandler(this.Clearall_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.deccheck);
            this.groupBox2.Controls.Add(this.receivedbox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.Clearall);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.asciishow);
            this.groupBox2.Controls.Add(this.hexshow);
            this.groupBox2.Location = new System.Drawing.Point(12, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(498, 508);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Resize += new System.EventHandler(this.Form1_Load);
            // 
            // deccheck
            // 
            this.deccheck.AutoSize = true;
            this.deccheck.Location = new System.Drawing.Point(28, 444);
            this.deccheck.Name = "deccheck";
            this.deccheck.Size = new System.Drawing.Size(74, 19);
            this.deccheck.TabIndex = 15;
            this.deccheck.Text = "十进制";
            this.deccheck.UseVisualStyleBackColor = true;
            // 
            // remote
            // 
            this.remote.Location = new System.Drawing.Point(9, 46);
            this.remote.Name = "remote";
            this.remote.Size = new System.Drawing.Size(92, 29);
            this.remote.TabIndex = 14;
            this.remote.Text = "远程操作";
            this.remote.UseVisualStyleBackColor = true;
            this.remote.Click += new System.EventHandler(this.remote_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "数据位：";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Databox
            // 
            this.Databox.FormattingEnabled = true;
            this.Databox.Items.AddRange(new object[] {
            "8"});
            this.Databox.Location = new System.Drawing.Point(126, 87);
            this.Databox.Name = "Databox";
            this.Databox.Size = new System.Drawing.Size(121, 23);
            this.Databox.TabIndex = 21;
            // 
            // stopbox
            // 
            this.stopbox.FormattingEnabled = true;
            this.stopbox.Items.AddRange(new object[] {
            "1"});
            this.stopbox.Location = new System.Drawing.Point(353, 86);
            this.stopbox.Name = "stopbox";
            this.stopbox.Size = new System.Drawing.Size(121, 23);
            this.stopbox.TabIndex = 22;
            // 
            // verifybox
            // 
            this.verifybox.FormattingEnabled = true;
            this.verifybox.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.verifybox.Location = new System.Drawing.Point(353, 116);
            this.verifybox.Name = "verifybox";
            this.verifybox.Size = new System.Drawing.Size(121, 23);
            this.verifybox.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(283, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 24;
            this.label6.Text = "停止位：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(283, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 25;
            this.label7.Text = "校验：";
            // 
            // hexsend
            // 
            this.hexsend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hexsend.AutoSize = true;
            this.hexsend.Location = new System.Drawing.Point(6, 604);
            this.hexsend.Name = "hexsend";
            this.hexsend.Size = new System.Drawing.Size(119, 19);
            this.hexsend.TabIndex = 14;
            this.hexsend.Text = "十六进制发送";
            this.hexsend.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "发送窗口";
            // 
            // sendbt
            // 
            this.sendbt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sendbt.AutoSize = true;
            this.sendbt.Location = new System.Drawing.Point(236, 598);
            this.sendbt.Name = "sendbt";
            this.sendbt.Size = new System.Drawing.Size(89, 25);
            this.sendbt.TabIndex = 9;
            this.sendbt.Text = "发送";
            this.sendbt.UseVisualStyleBackColor = true;
            this.sendbt.Click += new System.EventHandler(this.sendbt_Click);
            // 
            // spacesend
            // 
            this.spacesend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spacesend.AutoSize = true;
            this.spacesend.Location = new System.Drawing.Point(131, 604);
            this.spacesend.Name = "spacesend";
            this.spacesend.Size = new System.Drawing.Size(89, 19);
            this.spacesend.TabIndex = 15;
            this.spacesend.Text = "包含空格";
            this.spacesend.UseVisualStyleBackColor = true;
            // 
            // sendclear
            // 
            this.sendclear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sendclear.Location = new System.Drawing.Point(331, 599);
            this.sendclear.Name = "sendclear";
            this.sendclear.Size = new System.Drawing.Size(143, 23);
            this.sendclear.TabIndex = 17;
            this.sendclear.Text = "清空发送";
            this.sendclear.UseVisualStyleBackColor = true;
            this.sendclear.Click += new System.EventHandler(this.sendclear_Click);
            // 
            // sendlabel
            // 
            this.sendlabel.AutoSize = true;
            this.sendlabel.Location = new System.Drawing.Point(79, 21);
            this.sendlabel.Name = "sendlabel";
            this.sendlabel.Size = new System.Drawing.Size(68, 15);
            this.sendlabel.TabIndex = 16;
            this.sendlabel.Text = "已发送:0";
            // 
            // sendbox
            // 
            this.sendbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sendbox.Location = new System.Drawing.Point(9, 417);
            this.sendbox.Name = "sendbox";
            this.sendbox.Size = new System.Drawing.Size(434, 135);
            this.sendbox.TabIndex = 7;
            this.sendbox.Text = "";
            this.sendbox.TextChanged += new System.EventHandler(this.sendbox_TextChanged);
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(9, 560);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(85, 25);
            this.test.TabIndex = 26;
            this.test.Text = "test";
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // controlbox
            // 
            this.controlbox.FormattingEnabled = true;
            this.controlbox.Items.AddRange(new object[] {
            "设置最大输入电压",
            "设置最大输入电流",
            "设置最大输入功率",
            "设置负载定电流值",
            "设置负载定电压值",
            "设置负载定功率值",
            "设置负载定电阻值",
            "在定电压模式下的最小电压值"});
            this.controlbox.Location = new System.Drawing.Point(100, 88);
            this.controlbox.Name = "controlbox";
            this.controlbox.Size = new System.Drawing.Size(121, 23);
            this.controlbox.TabIndex = 27;
            this.controlbox.SelectedIndexChanged += new System.EventHandler(this.controlbox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.T_B);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.V_B);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.T_A);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.V_A);
            this.groupBox1.Controls.Add(this.dynamic_check);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.staticnum);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.read_selec);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.dynamic_selec);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.mode_selec);
            this.groupBox1.Controls.Add(this.local_permit);
            this.groupBox1.Controls.Add(this.remote);
            this.groupBox1.Controls.Add(this.elec_switch);
            this.groupBox1.Controls.Add(this.selec_elec);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.controlbox);
            this.groupBox1.Controls.Add(this.test);
            this.groupBox1.Controls.Add(this.sendbox);
            this.groupBox1.Controls.Add(this.sendlabel);
            this.groupBox1.Controls.Add(this.sendclear);
            this.groupBox1.Controls.Add(this.spacesend);
            this.groupBox1.Controls.Add(this.sendbt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.hexsend);
            this.groupBox1.Location = new System.Drawing.Point(514, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 629);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 308);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 15);
            this.label12.TabIndex = 39;
            this.label12.Text = "静态数值设置：";
            // 
            // staticnum
            // 
            this.staticnum.Location = new System.Drawing.Point(147, 305);
            this.staticnum.Name = "staticnum";
            this.staticnum.Size = new System.Drawing.Size(100, 25);
            this.staticnum.TabIndex = 38;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(233, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 15);
            this.label11.TabIndex = 37;
            this.label11.Text = "读取数值：";
            // 
            // read_selec
            // 
            this.read_selec.FormattingEnabled = true;
            this.read_selec.Items.AddRange(new object[] {
            "最大输入电压值",
            "最大输入电流值",
            "最大输入功率值",
            "定电流值",
            "定电压值",
            "定功率值",
            "定电阻值",
            "负载模式",
            "在定电压模式下的最小电压值",
            "远程测量模式",
            "读取负载相关状态",
            "动态电流参数值",
            "动态电压参数值",
            "动态功率参数值",
            "动态电阻参数值"});
            this.read_selec.Location = new System.Drawing.Point(322, 88);
            this.read_selec.Name = "read_selec";
            this.read_selec.Size = new System.Drawing.Size(121, 23);
            this.read_selec.TabIndex = 36;
            this.read_selec.SelectedIndexChanged += new System.EventHandler(this.read_selec_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 15);
            this.label10.TabIndex = 35;
            this.label10.Text = "设置动态：";
            // 
            // dynamic_selec
            // 
            this.dynamic_selec.FormattingEnabled = true;
            this.dynamic_selec.Items.AddRange(new object[] {
            "电流参数",
            "电压参数",
            "功率参数",
            "电阻参数"});
            this.dynamic_selec.Location = new System.Drawing.Point(100, 165);
            this.dynamic_selec.Name = "dynamic_selec";
            this.dynamic_selec.Size = new System.Drawing.Size(121, 23);
            this.dynamic_selec.TabIndex = 34;
            this.dynamic_selec.SelectedIndexChanged += new System.EventHandler(this.dynamic_selec_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 15);
            this.label9.TabIndex = 33;
            this.label9.Text = "设置模式：";
            // 
            // mode_selec
            // 
            this.mode_selec.FormattingEnabled = true;
            this.mode_selec.ItemHeight = 15;
            this.mode_selec.Items.AddRange(new object[] {
            "负载输入状态",
            "负载模式状态",
            "LOCAL是否允许",
            "运程测量模式"});
            this.mode_selec.Location = new System.Drawing.Point(100, 126);
            this.mode_selec.Name = "mode_selec";
            this.mode_selec.Size = new System.Drawing.Size(121, 23);
            this.mode_selec.TabIndex = 32;
            this.mode_selec.SelectedIndexChanged += new System.EventHandler(this.mode_selec_SelectedIndexChanged);
            // 
            // local_permit
            // 
            this.local_permit.CheckOnClick = true;
            this.local_permit.FormattingEnabled = true;
            this.local_permit.Items.AddRange(new object[] {
            "禁止",
            "允许"});
            this.local_permit.Location = new System.Drawing.Point(147, 255);
            this.local_permit.Name = "local_permit";
            this.local_permit.Size = new System.Drawing.Size(121, 44);
            this.local_permit.TabIndex = 31;
            this.local_permit.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.local_permit_ItemCheck);
            // 
            // elec_switch
            // 
            this.elec_switch.CheckOnClick = true;
            this.elec_switch.FormattingEnabled = true;
            this.elec_switch.Items.AddRange(new object[] {
            "OFF",
            "ON"});
            this.elec_switch.Location = new System.Drawing.Point(147, 205);
            this.elec_switch.Name = "elec_switch";
            this.elec_switch.Size = new System.Drawing.Size(121, 44);
            this.elec_switch.TabIndex = 30;
            this.elec_switch.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.elec_switch_ItemCheck);
            // 
            // selec_elec
            // 
            this.selec_elec.CheckOnClick = true;
            this.selec_elec.FormattingEnabled = true;
            this.selec_elec.Items.AddRange(new object[] {
            "CC",
            "CV",
            "CW",
            "CR"});
            this.selec_elec.Location = new System.Drawing.Point(9, 205);
            this.selec_elec.Name = "selec_elec";
            this.selec_elec.Size = new System.Drawing.Size(132, 84);
            this.selec_elec.TabIndex = 29;
            this.selec_elec.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.selec_elec_ItemCheck);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 28;
            this.label8.Text = "设置数值：";
            // 
            // dynamic_check
            // 
            this.dynamic_check.CheckOnClick = true;
            this.dynamic_check.FormattingEnabled = true;
            this.dynamic_check.Items.AddRange(new object[] {
            "continues",
            "pulse",
            "toggled"});
            this.dynamic_check.Location = new System.Drawing.Point(289, 205);
            this.dynamic_check.Name = "dynamic_check";
            this.dynamic_check.Size = new System.Drawing.Size(120, 84);
            this.dynamic_check.TabIndex = 40;
            this.dynamic_check.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.dynamic_check_ItemCheck);
            // 
            // V_A
            // 
            this.V_A.Location = new System.Drawing.Point(147, 348);
            this.V_A.Name = "V_A";
            this.V_A.Size = new System.Drawing.Size(100, 25);
            this.V_A.TabIndex = 41;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 358);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 15);
            this.label13.TabIndex = 42;
            this.label13.Text = "A电类值设置：";
            // 
            // T_A
            // 
            this.T_A.Location = new System.Drawing.Point(147, 386);
            this.T_A.Name = "T_A";
            this.T_A.Size = new System.Drawing.Size(100, 25);
            this.T_A.TabIndex = 43;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 396);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 15);
            this.label14.TabIndex = 44;
            this.label14.Text = "A时间值设置：";
            // 
            // V_B
            // 
            this.V_B.Location = new System.Drawing.Point(364, 348);
            this.V_B.Name = "V_B";
            this.V_B.Size = new System.Drawing.Size(100, 25);
            this.V_B.TabIndex = 45;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(253, 358);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(105, 15);
            this.label15.TabIndex = 46;
            this.label15.Text = "B电类值设置：";
            // 
            // T_B
            // 
            this.T_B.Location = new System.Drawing.Point(364, 385);
            this.T_B.Name = "T_B";
            this.T_B.Size = new System.Drawing.Size(100, 25);
            this.T_B.TabIndex = 47;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(256, 394);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(105, 15);
            this.label16.TabIndex = 48;
            this.label16.Text = "B时间值设置：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 666);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.verifybox);
            this.Controls.Add(this.stopbox);
            this.Controls.Add(this.Databox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comopen);
            this.Controls.Add(this.labelbuan);
            this.Controls.Add(this.baud);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comport);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox baud;
        private System.Windows.Forms.Label labelbuan;
        private System.Windows.Forms.Button comopen;
        private System.Windows.Forms.RichTextBox receivedbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox hexshow;
        private System.Windows.Forms.CheckBox asciishow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Clearall;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Databox;
        private System.Windows.Forms.ComboBox stopbox;
        private System.Windows.Forms.ComboBox verifybox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button remote;
        private System.Windows.Forms.CheckBox deccheck;
        private System.Windows.Forms.CheckBox hexsend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button sendbt;
        private System.Windows.Forms.CheckBox spacesend;
        private System.Windows.Forms.Button sendclear;
        private System.Windows.Forms.Label sendlabel;
        private System.Windows.Forms.RichTextBox sendbox;
        private System.Windows.Forms.Button test;
        private System.Windows.Forms.ComboBox controlbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox read_selec;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox dynamic_selec;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox mode_selec;
        private System.Windows.Forms.CheckedListBox local_permit;
        private System.Windows.Forms.CheckedListBox elec_switch;
        private System.Windows.Forms.CheckedListBox selec_elec;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox staticnum;
        private System.Windows.Forms.CheckedListBox dynamic_check;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox T_B;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox V_B;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox T_A;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox V_A;
    }
}

