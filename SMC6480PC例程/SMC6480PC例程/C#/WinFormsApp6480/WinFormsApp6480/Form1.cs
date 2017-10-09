using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using csSMC6X;

namespace WinFormsApp6480
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Timer1 = new Timer();
            //Timer1.Interval = 200;
            //Timer1.Tick = new EventHandler()
        }

        IntPtr m_handle;  //连接标识

        private void OnLink(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int iret =-1;
            if (btn.Name == "LinkEth")
            {
                string ipStr = "192.168.1.11";
                iret = SMC6X.SMCOpenEth(ipStr, ref m_handle); //连接网络
            }
            else if (btn.Name == "LinkCom")
            {
                iret = SMC6X.SMCOpenCom(1, ref m_handle); //连接网络
            }
            
            if (0 != iret )
            {
                MessageBox.Show("连接失败");
                return;
            }

            timer2.Start();
        }

        private void PMove_Click(object sender, EventArgs e)
        {
            if (m_handle == (IntPtr)(0))
            {
                MessageBox.Show("请先连接控制器！");
                return;
            }
            Button btn = (Button)sender;
            SMC6X.SMCSetLocateSpeed(m_handle, 0, 1000); //设置运动速度，1000 Pulse/s;
            SMC6X.SMCSetLocateAcceleration(m_handle, 0, 2000); //设置运动加速度，2000 Pulse/s2;
           if (btn.Name == ("PMovePlus"))
           {
               SMC6X.SMCPMovePluses(m_handle, 0, 10000, 0);  //向正方向运动10000个脉冲；
           }
           else if (btn.Name == ("PMoveReverse"))
           {
               SMC6X.SMCPMovePluses(m_handle, 0, -10000, 0);  //向负方向运动10000个脉冲；
           }
            
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            SMC6X.SMCDecelStop(m_handle,0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_handle = (IntPtr)(0);       
        }


        private void OnTick(object sender, EventArgs e)
        {
            Int32 pos = 0;
            SMC6X.SMCGetPositionPulses(m_handle, 0, ref pos);
            POSX.Text = Convert.ToString(pos);            
        }

        private void CloseConnect_Click(object sender, EventArgs e)
        {
            SMC6X.SMCClose(m_handle);
            m_handle = (IntPtr)(0); 
        }

    }
}
