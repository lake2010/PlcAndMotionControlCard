using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.IO.Ports;
using System.Xml;
using System.Threading;

namespace complc
{
    public partial class comForm : Form
    {
        public comForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (axMSComm1.PortOpen == true)
            {
                axMSComm1.PortOpen = false;
            }          
            Application.Exit();
        }
        public string tobcc(string s)    //帧校验函数FCS 
        {
            int t = 0;
            char[] chars = s.ToCharArray();
            for (int i = 1; i <= s.Length - 1; i++)
            {
                t = t ^= (char)chars[i];
            }
            return t.ToString().Substring(1, 2);
        }
        private void button1_Click(object sender, EventArgs e)
        {
           textBox2.Text = null;
           if(axMSComm1.PortOpen)
           {
             try
             {
                 string ms, rd="";               
                 axMSComm1.InputLen = 0; //清除接收缓冲区 
                 axMSComm1.DTREnable = true;  //置DTR有效 
                 axMSComm1.RTSEnable = true;  //置RTS有效 
                 axMSComm1.InputMode = MSCommLib.InputModeConstants.comInputModeText; //置为二进制输入方式 
                 axMSComm1.RThreshold = 1;  //设置为接收缓冲区每接收一个字符将引发一次OnComm事件 
                 #region 字符不足补齐
                 int y = 0;
                 for (int i = 0; i < 4 - textBox1.TextLength; i++)
                 {
                     y++;
                 }
                 string aa = "0000";
                 aa = aa.Substring(aa.Length - y);
                 string bb = aa + textBox1.Text;
                 //MessageBox.Show(bb.ToString());      
                 #endregion
                 ms = "%01#" + comboBox7.Text + comboBox8.Text + bb +comboBox9.Text+ "**";  // 输入如：%01#RDD9001590016或%01#RDD0100601036     
                 //MessageBox.Show(ms);
                 axMSComm1.Output = ms + (char)13;
                 #region 隐藏
                 //axMSComm1.Output = ms + tobcc(ms) + (char)13;
                 //axMSComm1.Output = ms;
                 //int i;
                 //axMSComm1.InBufferSize = 1024;   //设置接收数据缓冲区
                 // axMSComm1.OutBufferSize = 512;  //设置发送数据缓冲区
                 //axMSComm1.InputMode=0; //设置以字符串形式接收数据              
                 // axMSComm1.InBufferCount = 0; // '清
                 // sleep(30); 
                 #endregion
                 rd = null;
                 rd += axMSComm1.Input;
                 textBox2.Text = null;
                 textBox2.Text = rd;
                 //axMSComm1.PortOpen = false;
             }
             catch (Exception err)
             {
                 MessageBox.Show(err.Message);
             }
           }
           else
           {
               MessageBox.Show("串口未打开","提示");
           }
        }

        private void comForm_Load(object sender, EventArgs e)
        {
            loadPortsName();
            comboBox2.Text = "9600";
            comboBox3.Text = "8";
            comboBox4.Text = "None";
            comboBox5.Text = "1";
            comboBox6.Text = "1";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (button3.Text=="打开")
            {
              
                try
                {
                    #region 设置COM端口的值

                    if (comboBox1.Text == "COM1")
                    {
                        axMSComm1.CommPort = System.Convert.ToInt16(1);    //设为com
                    }
                    else if (comboBox1.Text == "COM2")
                    {
                        axMSComm1.CommPort = System.Convert.ToInt16(2);    //设为com
                    }
                    else if (comboBox1.Text == "COM3")
                    {
                        axMSComm1.CommPort = System.Convert.ToInt16(3);    //设为com
                    }
                    else if (comboBox1.Text == "COM4")
                    {
                        axMSComm1.CommPort = System.Convert.ToInt16(4);    //设为com
                    }
                    else if (comboBox1.Text == "COM5")
                    {
                        axMSComm1.CommPort = System.Convert.ToInt16(5);    //设为com
                    }
                    else if (comboBox1.Text == "COM6")
                    {
                        axMSComm1.CommPort = System.Convert.ToInt16(6);    //设为com
                    }
                    else if (comboBox1.Text == "COM7")
                    {
                        axMSComm1.CommPort = System.Convert.ToInt16(7);    //设为com
                    }
                    else if (comboBox1.Text == "COM8")
                    {
                        axMSComm1.CommPort = System.Convert.ToInt16(8);    //设为com
                    }
                    else if (comboBox1.Text == "COM9")
                    {
                        axMSComm1.CommPort = System.Convert.ToInt16(9);    //设为com
                    }
                    else if (comboBox1.Text == "COM10")
                    {
                        axMSComm1.CommPort = System.Convert.ToInt16(10);    //设为com1
                    }
                    #endregion
                    string a = comboBox2.SelectedItem.ToString();
                    string b;
                    #region 设置奇偶校验位
                    switch (comboBox4.SelectedItem.ToString())
                    {
                        case "None":
                            { b = "N"; }
                            break;
                        case "Odd":
                            { b = "O"; }
                            break;
                        case "Even":
                            { b = "E"; }
                            break;
                        case "Mark":
                            { b = "M"; }
                            break;
                        case "Space":
                            { b = "S"; }
                            break;
                        default:
                            b = "N";
                            break;
                    }
                    #endregion
                    string c = comboBox3.SelectedItem.ToString();
                    string d = comboBox5.SelectedItem.ToString();                                  
                    string set = a + "," + b + "," + c + "," + d;
                    //MessageBox.Show(set);
                    axMSComm1.Settings = set;
                    axMSComm1.InputLen = 0; //清除接收缓冲区 
                    axMSComm1.OutBufferSize = 0;
                    axMSComm1.DTREnable = true;  //置DTR有效 
                    axMSComm1.RTSEnable = true;  //置RTS有效 
                    axMSComm1.InputMode = MSCommLib.InputModeConstants.comInputModeText; //置为二进制输入方式 
                    //axMSComm1.InputMode = MSCommLib.InputModeConstants.comInputModeBinary;
                    axMSComm1.RThreshold = 1;  //设置为接收缓冲区每接收一个字符将引发一次OnComm事件    
    
                    if (axMSComm1.PortOpen)
                    {
                        axMSComm1.PortOpen = false;
                        axMSComm1.PortOpen = true;
                    }
                    else
                    {
                        axMSComm1.PortOpen = true;
                    }
                    button3.Text = "关闭";
                    button3.ForeColor = Color.Red;
                }
                catch (Exception)
                {
                    button3.Text = "打开";
                    button3.ForeColor = Color.Green;
                    MessageBox.Show("串口打开失败" + "\n" + "1.请检查配置的参数是否正确" + "\n" + "2.外围设备是否没有连接" + "\n" + "3.串口是否已经打开或被占用" + "\n" + "4.串口驱动是否没有安装");
                }
            }
            else if (button3.Text == "关闭")
            {
                button3.Text = "打开";
                button3.ForeColor = Color.Green;
                if (axMSComm1.PortOpen == true)
                {
                    axMSComm1.PortOpen = false;
                }

               
            }
        }
        #region 加载串口端口名
        private void loadPortsName()
        {
            comboBox1.Items.Clear();            
            string[] allAvailablePorts = SerialPort.GetPortNames();
            //判断是否有可用的端口
            if (allAvailablePorts.Length > 0)
            {

                //使能控件portNamesComboBox，openOrCloseButton               
                //依次添加可用的串口
                comboBox1.Items.AddRange(allAvailablePorts);                
                //默认选中第一个项
                comboBox1.SelectedIndex = 0;               
            }
            else
            {
                MessageBox.Show("未找到扫描枪接口", "提示");
            }
        }
        #endregion

       

       

        private void button4_Click(object sender, EventArgs e)
        {
           
            try
            {
                string ms=null, rd = null;                  
                //ms = textBox3.Text.Trim();                 
                ms = textBox3.Text + "**";  // 输入如：%01#RDD9001590016或%01#RDD0100601036     
                //MessageBox.Show(ms);
                axMSComm1.Output = ms + (char)13;
                rd += axMSComm1.Input;
                textBox2.Text = rd;
                
                // axMSComm1.PortOpen = false;                

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                string ms = null, ms1 = null, rd = null;
                //ms = textBox3.Text.Trim();                 
                ms = "%01#WCSR00301**";  // 输入如：%01#RDD9001590016或%01#RDD0100601036     
                ms1 = "%01#WCSR00300**";
                //MessageBox.Show(ms);
                axMSComm1.Output = ms + (char)13;
                Thread.Sleep(5);
                axMSComm1.Output = ms1 + (char)13;
                textBox2.Text = rd;

                // axMSComm1.PortOpen = false;                

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string ms = null, ms1=null, rd = null;
                //ms = textBox3.Text.Trim();                 
                ms = "%01#WCSR00311**";  // 输入如：%01#RDD9001590016或%01#RDD0100601036     
                ms1 = "%01#WCSR00310**";
                //MessageBox.Show(ms);
                axMSComm1.Output = ms + (char)13;
                Thread.Sleep(5);
                axMSComm1.Output = ms1 + (char)13;
                textBox2.Text = rd;

                // axMSComm1.PortOpen = false;                

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            try
            {
                string ms = null, ms1 = null, rd = null;
                //ms = textBox3.Text.Trim();                 
                ms = "%01#WCSR10051**";  // 输入如：%01#RDD9001590016或%01#RDD0100601036     
                ms1 = "%01#WCSR10050**";
                //MessageBox.Show(ms);
                axMSComm1.Output = ms + (char)13;
                Thread.Sleep(100);
                axMSComm1.Output = ms1 + (char)13;
                textBox2.Text = rd;

                // axMSComm1.PortOpen = false;                

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

       



    }
}
