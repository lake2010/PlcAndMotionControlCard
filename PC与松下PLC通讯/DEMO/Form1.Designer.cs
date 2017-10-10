namespace DEMO
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label_portName = new System.Windows.Forms.Label();
            this.label_baudRuta = new System.Windows.Forms.Label();
            this.comboBox_baudRate = new System.Windows.Forms.ComboBox();
            this.comboBox_portName = new System.Windows.Forms.ComboBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button_openOrClosePort = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.mySerialPort = new System.IO.Ports.SerialPort(this.components);
            this.textBox_msg = new System.Windows.Forms.TextBox();
            this.button_send = new System.Windows.Forms.Button();
            this.comboBox_Parity = new System.Windows.Forms.ComboBox();
            this.comboBox_dataBits = new System.Windows.Forms.ComboBox();
            this.label_dataBits = new System.Windows.Forms.Label();
            this.label_Parity = new System.Windows.Forms.Label();
            this.label_stopBits = new System.Windows.Forms.Label();
            this.comboBox_stopBits = new System.Windows.Forms.ComboBox();
            this.label_stand = new System.Windows.Forms.Label();
            this.textBox_stand = new System.Windows.Forms.TextBox();
            this.label_action = new System.Windows.Forms.Label();
            this.comboBox_action = new System.Windows.Forms.ComboBox();
            this.label_type = new System.Windows.Forms.Label();
            this.comboBox_type = new System.Windows.Forms.ComboBox();
            this.textBox_firstAddress = new System.Windows.Forms.TextBox();
            this.label_firstAddress = new System.Windows.Forms.Label();
            this.label_count = new System.Windows.Forms.Label();
            this.comboBox_state = new System.Windows.Forms.ComboBox();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_portName
            // 
            this.label_portName.AutoSize = true;
            this.label_portName.Location = new System.Drawing.Point(23, 34);
            this.label_portName.Name = "label_portName";
            this.label_portName.Size = new System.Drawing.Size(41, 12);
            this.label_portName.TabIndex = 0;
            this.label_portName.Text = "端  口";
            // 
            // label_baudRuta
            // 
            this.label_baudRuta.AutoSize = true;
            this.label_baudRuta.Location = new System.Drawing.Point(23, 77);
            this.label_baudRuta.Name = "label_baudRuta";
            this.label_baudRuta.Size = new System.Drawing.Size(41, 12);
            this.label_baudRuta.TabIndex = 1;
            this.label_baudRuta.Text = "波特率";
            // 
            // comboBox_baudRate
            // 
            this.comboBox_baudRate.FormattingEnabled = true;
            this.comboBox_baudRate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400"});
            this.comboBox_baudRate.Location = new System.Drawing.Point(85, 69);
            this.comboBox_baudRate.Name = "comboBox_baudRate";
            this.comboBox_baudRate.Size = new System.Drawing.Size(121, 20);
            this.comboBox_baudRate.TabIndex = 2;
            // 
            // comboBox_portName
            // 
            this.comboBox_portName.FormattingEnabled = true;
            this.comboBox_portName.Location = new System.Drawing.Point(85, 26);
            this.comboBox_portName.Name = "comboBox_portName";
            this.comboBox_portName.Size = new System.Drawing.Size(121, 20);
            this.comboBox_portName.TabIndex = 2;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 353);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(868, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "状态显示";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(53, 17);
            this.toolStripStatusLabel1.Text = "状态显示";
            // 
            // button_openOrClosePort
            // 
            this.button_openOrClosePort.Location = new System.Drawing.Point(85, 279);
            this.button_openOrClosePort.Name = "button_openOrClosePort";
            this.button_openOrClosePort.Size = new System.Drawing.Size(75, 23);
            this.button_openOrClosePort.TabIndex = 4;
            this.button_openOrClosePort.Text = "打开串口";
            this.button_openOrClosePort.UseVisualStyleBackColor = true;
            this.button_openOrClosePort.Click += new System.EventHandler(this.button_openOrClosePort_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(249, 26);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(592, 208);
            this.listBox1.TabIndex = 6;
            // 
            // textBox_msg
            // 
            this.textBox_msg.Location = new System.Drawing.Point(330, 305);
            this.textBox_msg.Name = "textBox_msg";
            this.textBox_msg.Size = new System.Drawing.Size(247, 21);
            this.textBox_msg.TabIndex = 7;
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(653, 303);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(75, 23);
            this.button_send.TabIndex = 8;
            this.button_send.Text = "发送";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // comboBox_Parity
            // 
            this.comboBox_Parity.FormattingEnabled = true;
            this.comboBox_Parity.Items.AddRange(new object[] {
            "无校验(None)",
            "偶校验(Even)",
            "奇校验(Odd)",
            "保留为0(Space)",
            "保留为1(Mark)"});
            this.comboBox_Parity.Location = new System.Drawing.Point(85, 111);
            this.comboBox_Parity.Name = "comboBox_Parity";
            this.comboBox_Parity.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Parity.TabIndex = 11;
            // 
            // comboBox_dataBits
            // 
            this.comboBox_dataBits.FormattingEnabled = true;
            this.comboBox_dataBits.Items.AddRange(new object[] {
            "7",
            "8"});
            this.comboBox_dataBits.Location = new System.Drawing.Point(85, 154);
            this.comboBox_dataBits.Name = "comboBox_dataBits";
            this.comboBox_dataBits.Size = new System.Drawing.Size(121, 20);
            this.comboBox_dataBits.TabIndex = 12;
            // 
            // label_dataBits
            // 
            this.label_dataBits.AutoSize = true;
            this.label_dataBits.Location = new System.Drawing.Point(23, 162);
            this.label_dataBits.Name = "label_dataBits";
            this.label_dataBits.Size = new System.Drawing.Size(41, 12);
            this.label_dataBits.TabIndex = 10;
            this.label_dataBits.Text = "数据位";
            // 
            // label_Parity
            // 
            this.label_Parity.AutoSize = true;
            this.label_Parity.Location = new System.Drawing.Point(23, 119);
            this.label_Parity.Name = "label_Parity";
            this.label_Parity.Size = new System.Drawing.Size(41, 12);
            this.label_Parity.TabIndex = 9;
            this.label_Parity.Text = "校验位";
            // 
            // label_stopBits
            // 
            this.label_stopBits.AutoSize = true;
            this.label_stopBits.Location = new System.Drawing.Point(23, 208);
            this.label_stopBits.Name = "label_stopBits";
            this.label_stopBits.Size = new System.Drawing.Size(41, 12);
            this.label_stopBits.TabIndex = 10;
            this.label_stopBits.Text = "停止位";
            // 
            // comboBox_stopBits
            // 
            this.comboBox_stopBits.FormattingEnabled = true;
            this.comboBox_stopBits.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comboBox_stopBits.Location = new System.Drawing.Point(85, 200);
            this.comboBox_stopBits.Name = "comboBox_stopBits";
            this.comboBox_stopBits.Size = new System.Drawing.Size(121, 20);
            this.comboBox_stopBits.TabIndex = 12;
            // 
            // label_stand
            // 
            this.label_stand.AutoSize = true;
            this.label_stand.Location = new System.Drawing.Point(268, 270);
            this.label_stand.Name = "label_stand";
            this.label_stand.Size = new System.Drawing.Size(29, 12);
            this.label_stand.TabIndex = 13;
            this.label_stand.Text = "站号";
            // 
            // textBox_stand
            // 
            this.textBox_stand.Location = new System.Drawing.Point(303, 262);
            this.textBox_stand.Name = "textBox_stand";
            this.textBox_stand.Size = new System.Drawing.Size(38, 21);
            this.textBox_stand.TabIndex = 14;
            // 
            // label_action
            // 
            this.label_action.AutoSize = true;
            this.label_action.Location = new System.Drawing.Point(367, 268);
            this.label_action.Name = "label_action";
            this.label_action.Size = new System.Drawing.Size(29, 12);
            this.label_action.TabIndex = 15;
            this.label_action.Text = "动作";
            // 
            // comboBox_action
            // 
            this.comboBox_action.FormattingEnabled = true;
            this.comboBox_action.Items.AddRange(new object[] {
            "读取",
            "写入"});
            this.comboBox_action.Location = new System.Drawing.Point(402, 262);
            this.comboBox_action.Name = "comboBox_action";
            this.comboBox_action.Size = new System.Drawing.Size(72, 20);
            this.comboBox_action.TabIndex = 16;
            // 
            // label_type
            // 
            this.label_type.AutoSize = true;
            this.label_type.Location = new System.Drawing.Point(493, 268);
            this.label_type.Name = "label_type";
            this.label_type.Size = new System.Drawing.Size(29, 12);
            this.label_type.TabIndex = 17;
            this.label_type.Text = "类型";
            // 
            // comboBox_type
            // 
            this.comboBox_type.FormattingEnabled = true;
            this.comboBox_type.Items.AddRange(new object[] {
            "R",
            "X",
            "Y"});
            this.comboBox_type.Location = new System.Drawing.Point(528, 263);
            this.comboBox_type.Name = "comboBox_type";
            this.comboBox_type.Size = new System.Drawing.Size(49, 20);
            this.comboBox_type.TabIndex = 18;
            // 
            // textBox_firstAddress
            // 
            this.textBox_firstAddress.Location = new System.Drawing.Point(653, 261);
            this.textBox_firstAddress.Name = "textBox_firstAddress";
            this.textBox_firstAddress.Size = new System.Drawing.Size(59, 21);
            this.textBox_firstAddress.TabIndex = 19;
            // 
            // label_firstAddress
            // 
            this.label_firstAddress.AutoSize = true;
            this.label_firstAddress.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_firstAddress.Location = new System.Drawing.Point(603, 268);
            this.label_firstAddress.Name = "label_firstAddress";
            this.label_firstAddress.Size = new System.Drawing.Size(29, 12);
            this.label_firstAddress.TabIndex = 20;
            this.label_firstAddress.Text = "地址";
            // 
            // label_count
            // 
            this.label_count.AutoSize = true;
            this.label_count.Location = new System.Drawing.Point(735, 269);
            this.label_count.Name = "label_count";
            this.label_count.Size = new System.Drawing.Size(29, 12);
            this.label_count.TabIndex = 21;
            this.label_count.Text = "状态";
            // 
            // comboBox_state
            // 
            this.comboBox_state.FormattingEnabled = true;
            this.comboBox_state.Items.AddRange(new object[] {
            "ON",
            "OFF"});
            this.comboBox_state.Location = new System.Drawing.Point(770, 261);
            this.comboBox_state.Name = "comboBox_state";
            this.comboBox_state.Size = new System.Drawing.Size(48, 20);
            this.comboBox_state.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 375);
            this.Controls.Add(this.comboBox_state);
            this.Controls.Add(this.label_count);
            this.Controls.Add(this.label_firstAddress);
            this.Controls.Add(this.textBox_firstAddress);
            this.Controls.Add(this.comboBox_type);
            this.Controls.Add(this.label_type);
            this.Controls.Add(this.comboBox_action);
            this.Controls.Add(this.label_action);
            this.Controls.Add(this.textBox_stand);
            this.Controls.Add(this.label_stand);
            this.Controls.Add(this.comboBox_Parity);
            this.Controls.Add(this.comboBox_stopBits);
            this.Controls.Add(this.comboBox_dataBits);
            this.Controls.Add(this.label_stopBits);
            this.Controls.Add(this.label_dataBits);
            this.Controls.Add(this.label_Parity);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.textBox_msg);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button_openOrClosePort);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.comboBox_portName);
            this.Controls.Add(this.comboBox_baudRate);
            this.Controls.Add(this.label_baudRuta);
            this.Controls.Add(this.label_portName);
            this.Name = "Form1";
            this.Text = "串口通讯";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_portName;
        private System.Windows.Forms.Label label_baudRuta;
        private System.Windows.Forms.ComboBox comboBox_baudRate;
        private System.Windows.Forms.ComboBox comboBox_portName;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Button button_openOrClosePort;
        private System.Windows.Forms.ListBox listBox1;
        private System.IO.Ports.SerialPort mySerialPort;
        private System.Windows.Forms.TextBox textBox_msg;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.ComboBox comboBox_Parity;
        private System.Windows.Forms.ComboBox comboBox_dataBits;
        private System.Windows.Forms.Label label_dataBits;
        private System.Windows.Forms.Label label_Parity;
        private System.Windows.Forms.Label label_stopBits;
        private System.Windows.Forms.ComboBox comboBox_stopBits;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label_stand;
        private System.Windows.Forms.TextBox textBox_stand;
        private System.Windows.Forms.Label label_action;
        private System.Windows.Forms.ComboBox comboBox_action;
        private System.Windows.Forms.Label label_type;
        private System.Windows.Forms.ComboBox comboBox_type;
        private System.Windows.Forms.TextBox textBox_firstAddress;
        private System.Windows.Forms.Label label_firstAddress;
        private System.Windows.Forms.Label label_count;
        private System.Windows.Forms.ComboBox comboBox_state;
    }
}

