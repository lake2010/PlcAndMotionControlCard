using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO ;
using System.IO .Ports;

namespace DEMO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckPorts();
            ComboBoxDefault();
        }
        string myTime = DateTime.Now.ToString();
        byte[] A = null;

        private void ComboBoxDefault() //comoboBox默认值
        {
            comboBox_baudRate.SelectedIndex = 5; //默认112500
            comboBox_Parity.SelectedIndex = 2; //默认奇校验
            comboBox_dataBits.SelectedIndex = 1; //默认8
            comboBox_stopBits.SelectedIndex = 0; //默认1
            comboBox_action.SelectedIndex = 0;
            comboBox_type.SelectedIndex = 0;
            comboBox_state.SelectedIndex = 0;
        }

        private void CheckPorts() //扫描端口
        {
            comboBox_portName.Items.Clear(); //清除comoboBox

            string[] allPorts = System.IO.Ports.SerialPort.GetPortNames(); //获取可用端口数组

            if (allPorts.Length > 0)
            {
                comboBox_portName.Enabled = true;
                comboBox_portName.Items.AddRange(allPorts); //想comoboBox写入可用端口
                comboBox_portName.SelectedIndex = 0;
            }
            else
            {
                comboBox_portName.Enabled = false; 
                toolStripStatusLabel1 .Text  = string .Format ( "没有可用端口");
               
            }
        }

        private int SelectedBaudRute() //波特率
        {
            int baudRate = 0;
            if (!(int .TryParse (comboBox_baudRate .SelectedItem .ToString (),out baudRate )))
            {
                baudRate = 112500;
  
            }
            return baudRate ;
        }

        private Parity SelectedParity() //校验位
        {
            
            Parity parity = Parity.None;
            switch (comboBox_Parity.SelectedItem.ToString())
            {
                case "无校验(None)":
                    {
                        parity = Parity.None;
                    }
                    break;
                case "偶校验(Even)":
                    {
                        parity = Parity.Even;
                    }
                    break;
                case "奇校验(Odd)":
                    {
                        parity = Parity.Odd;
                    }
                    break;
                case "保留为0(Space)":
                    {
                        parity = Parity.Space;
                    } 
                    break;
                case "保留为1(Mark)":
                    {
                        parity = Parity.Mark;
                    }
                    break;
            }
            return parity;
        }

        private int SelectedDataBits() //数据位
        {
            int dataBits = 8;
            if (!(int.TryParse(comboBox_dataBits.SelectedItem.ToString(), out dataBits)))
            {
                MessageBox.Show("数据位转换失败");
            }
            return dataBits;
        }

        private StopBits SelectedStopBits() //停止位
        {
           
            StopBits stopBits = StopBits.One;
            switch (comboBox_stopBits.SelectedItem.ToString())
            {
                case "1":
                    {
                        stopBits = StopBits.One;
                    }
                    break;
                case "2":
                    {
                        stopBits = StopBits.Two;
                    }
                    break;
            }
            return stopBits;
        }

        private void OpenSelectedPort()
        {
            try
            {
                mySerialPort.PortName = comboBox_portName.SelectedItem.ToString();//设置端口号
                mySerialPort.Open(); //打开端口
                toolStripStatusLabel1.Text = string.Format("打开{0}端口成功", mySerialPort.PortName);//更新状态栏
                button_openOrClosePort.Text = "关闭端口";  //更新按钮显示
                OpenSelectedPortSuccessfully(); //打开串口后，关闭端口设置使能

            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        } //打开串口

        private void OpenSelectedPortSuccessfully() //关闭端口设置使能
        {
            comboBox_portName.Enabled = false;
            comboBox_baudRate.Enabled = false;
            comboBox_Parity.Enabled = false;
            comboBox_dataBits.Enabled = false;
            comboBox_stopBits.Enabled = false;
        }

        private void CloseSelectedPort() //关闭串口
        {
            mySerialPort.Close(); //关闭串口
            toolStripStatusLabel1.Text = string.Format("关闭{0}端口成功", mySerialPort.PortName);//更新状态栏
            button_openOrClosePort.Text = "打开串口";//更新按钮
            CloseSelectedPortSuccessfully();//关闭串口后，打开端口设置使能
        }

        private void CloseSelectedPortSuccessfully()//打开端口设置使能
        {
            comboBox_portName.Enabled = true ;
            comboBox_baudRate.Enabled = true ;
            comboBox_Parity.Enabled = true ;
            comboBox_dataBits.Enabled = true ;
            comboBox_stopBits.Enabled = true ;
        }

        private void SetSerialPort() //设置端口
        {
            mySerialPort.BaudRate = SelectedBaudRute();
            mySerialPort.Parity  = SelectedParity();
            mySerialPort.DataBits = SelectedDataBits();
            mySerialPort.StopBits = SelectedStopBits() ;
            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(PortDataReceived);

            toolStripStatusLabel1.Text = string.Format("当前端口{0}，波特率{1}，校验：{2}，数据位：{3}，停止位：{4}。",
                mySerialPort.PortName, mySerialPort.BaudRate, mySerialPort.Parity, mySerialPort.DataBits, mySerialPort.StopBits);
        }

        private void button_openOrClosePort_Click(object sender, EventArgs e) //打开OR关闭端口开关
        {
            if (button_openOrClosePort.Text == "打开串口")
            {
                OpenSelectedPort();
                SetSerialPort();

            }
            else
            {
                CloseSelectedPort();
            }
        }

        private delegate void AddToListBox(string str);//声明委托添加记录到ListBox，安全线程
        private void AddTextToListBox(string msg) //添加记录到ListBox
        {
            if (listBox1.InvokeRequired)
            {
                AddToListBox d = AddTextToListBox;
                listBox1.Invoke(d, msg);
            }
            else
            {
                listBox1.Items.Add(msg);

            }
            try
            {
                listBox1.TopIndex = listBox1.Items.Count-1;
            }
            catch { }

        }

        private void PortDataReceived(object sender, SerialDataReceivedEventArgs e) //接受
        {
            SerialPort comReceived = (SerialPort)sender;
            string msgReceived = comReceived.ReadExisting();
            AddTextToListBox(myTime + " " + "接受" + " " + msgReceived );
            ProcessReceived(msgReceived );
            
        }
      
        private void ProcessReceived(string msg) //处理接收帧
        {
            if (msg.Length > 6)
            {
                string commandReceived = msg.Substring(0, msg.Length - 3);
                string BCCReceived = msg.Substring(msg.Length - 3, 2);
                byte[] cRd = System.Text.Encoding.ASCII.GetBytes(commandReceived);
                byte bycRd = 0;
                string xor = null;
                for (int i = 0; i < commandReceived.Length; i++)  //计算校验
                {
                    bycRd ^= cRd[i];
                }
                if (bycRd < 16)
                {
                    xor = "0"+bycRd.ToString("X");
                }
                else
                {
                    xor = bycRd.ToString("X");
                }

                if (xor == BCCReceived)   //判断校验
                {
                    AddTextToListBox("校验正确");
                    string replyState = commandReceived.Substring(3, 1);

                    if (replyState == "$")
                    {
                        AddTextToListBox("应答正确");
                        string action = commandReceived.Substring(4, 2);
                        switch (action)
                        {
                            case "RC":
                                {
                                    string state = commandReceived.Substring(6, 1);
                                    switch (state)
                                    {
                                        case "0":
                                            {
                                                AddTextToListBox("状态：OFF");

                                            }
                                            break;
                                        case "1":
                                            {
                                                AddTextToListBox("状态：ON");
                                            }
                                            break;
                                    }
                                }
                                break;
                            case "WC":
                                {
                                    AddTextToListBox("写入正确");
                                }
                                break;

                        }

                    }

                    else if (replyState == "!")
                    {
                        string errorCode = commandReceived.Substring(4, 2);
                        AddTextToListBox("指令错误：" + errorCode);
                    }

                }
                else
                {
                    AddTextToListBox("校验错误");
                }
            }
            else
            {
                AddTextToListBox("接收数据错误");
            }
        }

        public byte[] StrToAsc(string str) //带校验位string字符串转换为可发送byte数组
        {
            byte[] array = System.Text.Encoding.ASCII.GetBytes(str);
            byte[] arr = new byte[array.Length + 1];
          
            for (int i = 0; i < array.Length; i++)
            {
                arr[i] = array[i];
            }
            arr[array.Length ] = 13;
            array = arr; 
            return array;
        }

        private string  Xor(string str) //加入校验位
        { 
            string xor = null ;
            byte byMsg = 0;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(str);            
            for (int i = 0; i < msg.Length; i++)
            {
                byMsg ^= msg[i]; 
            }
            if (byMsg < 16)
            {

                xor = str +"0" +byMsg.ToString("X"); //加入以16进制显示的字符
            }
            else
            {
                xor = str + byMsg.ToString("X");
            }
            return xor;
            
        }

        public string ByteToString(byte[] sz) //ASII显示为string
        {
            string a = null;
            for (int i = 0; i < sz.Length; i++)
            {
                a += Convert.ToString(sz[i]) + " ";
            }
                return a ; 
        }

        private void button_send_Click(object sender, EventArgs e) //发送
        {
            getOrder();
            try
            {
                mySerialPort.Write(this.StrToAsc(Xor(textBox_msg.Text)), 0, Xor(textBox_msg.Text).Length + 1);
                AddTextToListBox(myTime + " " + "发送" + " " + ByteToString(StrToAsc(Xor(textBox_msg.Text))) + "(" + Xor(textBox_msg.Text)+"<CR>)");
                A = StrToAsc(textBox_msg.Text);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message );
            }
        }

        private void getOrder()
        {
            string stand = null;
            string action = null;
            string type = null;
            string firstAddress = null;
            string state = null;

            if ((textBox_stand.Text == "") | (textBox_firstAddress.Text == ""))
            {
                MessageBox.Show("参数输入错误！");

            }
            else
            {
                stand = textBox_stand.Text.Trim (); //站号
                firstAddress = textBox_firstAddress.Text.Trim ();//首地址
                type = comboBox_type.Text.Trim(); //触点类型
            }

            
            switch (comboBox_state.SelectedItem.ToString())
            {
                case "ON":
                    {
                        state = "1";
                    } 
                    break;
                case "OFF":
                    {
                        state = "0";
                    }
                    break;

            }

            switch (comboBox_action.SelectedItem.ToString()) //动作类型
            {
                case "读取":
                    {
                        action = "RCS";
                        textBox_msg.Text = "%" + stand + "#" + action +  type + firstAddress;

                    }
                    break;
                case "写入":
                    {
                        action = "WCS";
                        textBox_msg.Text = "%" + stand + "#" + action +  type + firstAddress + state ;

                    }
                    break;
            }

           

        } //获得不带校验指令

        

    }
}
