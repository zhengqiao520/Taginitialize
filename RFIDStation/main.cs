using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RFIDStation
{
    public partial class main : Form
    {
        private int serialDevice;                   //串口设备
        private int hHR2000DLLModule;               //dll句柄
        private System.Timers.Timer readerTimer;    //定时器
        private bool bOperatingSerial;              //是否正在操作串口
        private bool bSerialOpen;                   //串口是否被打开

        public main()
        {
            InitializeComponent();

            hHR2000DLLModule = 0;
            hHR2000DLLModule = HR2000Dll.LoadLibrary("HR2000.dll");

            if (hHR2000DLLModule <= 0)
            {
                MessageBox.Show("装载HR2000.dll文件失败，请确认HR2000.dll文件是否存在");
                System.Environment.Exit(0);
            }

            serialDevice = -1;
            bSerialOpen = false;
            bOperatingSerial = false;

            this.comboBoxBaudrate.SelectedIndex = 1;
            this.comboBoxComPort.SelectedIndex = 0;
            this.comboBoxTool.SelectedIndex = 0;
            this.comboBoxTagOp.SelectedIndex = 0;
            this.comboBoxDeviceType.SelectedIndex = 0;



            //初始化定时器，
//             readerTimer = new System.Timers.Timer(300);//实例化Timer类，设置间隔时间为100毫秒；
//             readerTimer.Elapsed += new System.Timers.ElapsedEventHandler(readerTimerOut); //到达时间的时候执行事件； 
//             readerTimer.AutoReset = true;  //设置是执行一次（false）还是一直执行(true)； 
        }

        private void buttonOpenSerial_Click(object sender, EventArgs e)
        {
            if (serialDevice <= 0)
            {
                serialDevice = HR2000Dll.openPort(this.comboBoxComPort.SelectedItem.ToString(), this.comboBoxBaudrate.SelectedItem.ToString());
                if (serialDevice > 0)
                {
                    this.buttonOpenSerial.Text = "关闭";
                    this.comboBoxComPort.Enabled = false;
                    this.comboBoxBaudrate.Enabled = false;

                    //开启定时器
                    //readerTimer.Enabled = true;     //是否执行System.Timers.Timer.Elapsed事件； 
                }
                else
                {
                    MessageBox.Show("打开串口失败", "提示");
                }
            }
            else
            {
                int op = HR2000Dll.closePort(serialDevice);
                if (op >= 0)
                {
                    this.buttonOpenSerial.Text = "打开";
                    this.comboBoxComPort.Enabled = true;
                    this.comboBoxBaudrate.Enabled = true;

                    //关闭定时器
                    //readerTimer.Enabled = false;     //是否执行System.Timers.Timer.Elapsed事件； 
                }
                serialDevice = -1;
            }
        }


    }
}