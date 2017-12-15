//! Copyright (C) 2007 Phychips
//! 
//! PR9200 DEMO
//!
//! Description
//! 	PR9200 DEMO
//!-------------------------------------------------------------------
//! History
//!-------------------------------------------------------------------
//! 1.0	2007/09/01	Jinsung Yi		Initial Release

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Phychips.Rcp;
using Phychips.Helper;
using BarChart;

namespace Phychips.PR9200
{
    public partial class ucMPTest : UserControl
    {
        public ucMPTest()
        {
            InitializeComponent();
        }

        private void ucMPTest_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
        }

        public void SetTxPower(float power)
        {
            ByteBuilder bb = new ByteBuilder();

            bb.Append((UInt16)(power * 100));

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_TX_PWR, bb.GetByteArray()))) { }
        }

        private void button_TxPowerMinus1550_Click(object sender, EventArgs e)
        {
            SetTxPower(-15.5f);
        }

        private void button_TxPowerMinus1450_Click(object sender, EventArgs e)
        {
            SetTxPower(-14.5f);
        }

        private void button_TxPowerMinus1350_Click(object sender, EventArgs e)
        {
            SetTxPower(-13.5f);
        }

        private void button_TxPowerMinus1250_Click(object sender, EventArgs e)
        {
            SetTxPower(-12.5f);
        }

        private void button_TxPowerMinus1150_Click(object sender, EventArgs e)
        {
            SetTxPower(-11.5f);
        }

        private void button_TxPowerMinus1050_Click(object sender, EventArgs e)
        {
            SetTxPower(-10.5f);
        }

        private void button_TxPowerMinus950_Click(object sender, EventArgs e)
        {
            SetTxPower(-9.5f);
        }

        private void button_TxPowerMinus850_Click(object sender, EventArgs e)
        {
            SetTxPower(-8.5f);
        }

        private void button_TxPowerMinus750_Click(object sender, EventArgs e)
        {
            SetTxPower(-7.5f);
        }

        private void button_TxPowerMinus650_Click(object sender, EventArgs e)
        {
            SetTxPower(-6.5f);
        }

        private void button_TxPowerMinus550_Click(object sender, EventArgs e)
        {
            SetTxPower(-5.5f);
        }

        private void button_TxPowerMinus450_Click(object sender, EventArgs e)
        {
            SetTxPower(-4.5f);
        }

        private void button_TxPowerMinus350_Click(object sender, EventArgs e)
        {
            SetTxPower(-3.5f);
        }

        private void button_TxPowerMinus250_Click(object sender, EventArgs e)
        {
            SetTxPower(-2.5f);
        }

        private void button_TxPowerMinus150_Click(object sender, EventArgs e)
        {
            SetTxPower(-1.5f);
        }

        private void button_TxPowerMinus50_Click(object sender, EventArgs e)
        {
            SetTxPower(-0.5f);
        }

        private void button_TxPower50_Click(object sender, EventArgs e)
        {
            SetTxPower(0.5f);
        }

        private void button_TxPower150_Click(object sender, EventArgs e)
        {
            SetTxPower(1.5f);
        }

        private void button_TxPower250_Click(object sender, EventArgs e)
        {
            SetTxPower(2.5f);
        }

        private void button_TxPower350_Click(object sender, EventArgs e)
        {
            SetTxPower(3.5f);
        }

        private void button_TxPower450_Click(object sender, EventArgs e)
        {
            SetTxPower(4.5f);
        }

        private void button_TxPower550_Click(object sender, EventArgs e)
        {
            SetTxPower(5.5f);
        }

        private void button_TxPower650_Click(object sender, EventArgs e)
        {
            SetTxPower(6.5f);
        }

        private void button_TxPower750_Click(object sender, EventArgs e)
        {
            SetTxPower(7.5f);
        }

        double[] temp_Measure;

        public bool AddTable(int index, TextBox textbox)
        {
            try
            {
                double temp = (double)Convert.ToDouble(textbox.Text);

                temp_Measure[index] = temp;

                return true;
            }
            catch
            {
                return false;
            }
        }

        int[] temp_Estimate = new int[49];

        public bool EstimateUsingMeasureValue()
        {
            try
            {
                temp_Measure = new double[24];

                AddTable(0, textBox_MeasureAntennaPowerMinus13);
                AddTable(1, textBox_MeasureAntennaPowerMinus12);
                AddTable(2, textBox_MeasureAntennaPowerMinus11);
                AddTable(3, textBox_MeasureAntennaPowerMinus10);
                AddTable(4, textBox_MeasureAntennaPowerMinus9);
                AddTable(5, textBox_MeasureAntennaPowerMinus8);
                AddTable(6, textBox_MeasureAntennaPowerMinus7);
                AddTable(7, textBox_MeasureAntennaPowerMinus6);
                AddTable(8, textBox_MeasureAntennaPowerMinus5);
                AddTable(9, textBox_MeasureAntennaPowerMinus4);
                AddTable(10, textBox_MeasureAntennaPowerMinus3);
                AddTable(11, textBox_MeasureAntennaPowerMinus2);
                AddTable(12, textBox_MeasureAntennaPowerMinus1);
                AddTable(13, textBox_MeasureAntennaPower0);
                AddTable(14, textBox_MeasureAntennaPower1);
                AddTable(15, textBox_MeasureAntennaPower2);
                AddTable(16, textBox_MeasureAntennaPower3);
                AddTable(17, textBox_MeasureAntennaPower4);
                AddTable(18, textBox_MeasureAntennaPower5);
                AddTable(19, textBox_MeasureAntennaPower6);
                AddTable(20, textBox_MeasureAntennaPower7);
                AddTable(21, textBox_MeasureAntennaPower8);
                AddTable(22, textBox_MeasureAntennaPower9);
                AddTable(23, textBox_MeasureAntennaPower10);

                int curr_index = 0;
                double curr_value = 0;
                double dis = 0;
                int cnt = 0;

                for (int i = 0; i < temp_Measure.Length; i++)
                {
                    if (temp_Measure[i] != 0)
                    {
                        dis = temp_Measure[i] - curr_value;

                        if (cnt != 0)
                        {
                            int step = Convert.ToInt32(dis * 100) / (2 * cnt);

                            for (int k = (2 * curr_index); k < temp_Estimate.Length; k++)
                                temp_Estimate[k] = Convert.ToInt32(curr_value * 100) + ((k - (2 * curr_index)) * step) - (step / 2);
                        }

                        curr_index = i;
                        curr_value = temp_Measure[i];

                        cnt = 0;
                    }

                    cnt++;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Estimate()
        {
            if (EstimateUsingMeasureValue())
            {
                textBox_EstimateAntennaPowerMinus13.Text = Convert.ToString(temp_Estimate[0]);
                textBox_EstimateAntennaPowerMinus12.Text = Convert.ToString(temp_Estimate[2]);
                textBox_EstimateAntennaPowerMinus11.Text = Convert.ToString(temp_Estimate[4]);
                textBox_EstimateAntennaPowerMinus10.Text = Convert.ToString(temp_Estimate[6]);
                textBox_EstimateAntennaPowerMinus9.Text = Convert.ToString(temp_Estimate[8]);
                textBox_EstimateAntennaPowerMinus8.Text = Convert.ToString(temp_Estimate[10]);
                textBox_EstimateAntennaPowerMinus7.Text = Convert.ToString(temp_Estimate[12]);
                textBox_EstimateAntennaPowerMinus6.Text = Convert.ToString(temp_Estimate[14]);
                textBox_EstimateAntennaPowerMinus5.Text = Convert.ToString(temp_Estimate[16]);
                textBox_EstimateAntennaPowerMinus4.Text = Convert.ToString(temp_Estimate[18]);
                textBox_EstimateAntennaPowerMinus3.Text = Convert.ToString(temp_Estimate[20]);
                textBox_EstimateAntennaPowerMinus2.Text = Convert.ToString(temp_Estimate[22]);
                textBox_EstimateAntennaPowerMinus1.Text = Convert.ToString(temp_Estimate[24]);
                textBox_EstimateAntennaPower0.Text = Convert.ToString(temp_Estimate[26]);
                textBox_EstimateAntennaPower1.Text = Convert.ToString(temp_Estimate[28]);
                textBox_EstimateAntennaPower2.Text = Convert.ToString(temp_Estimate[30]);
                textBox_EstimateAntennaPower3.Text = Convert.ToString(temp_Estimate[32]);
                textBox_EstimateAntennaPower4.Text = Convert.ToString(temp_Estimate[34]);
                textBox_EstimateAntennaPower5.Text = Convert.ToString(temp_Estimate[36]);
                textBox_EstimateAntennaPower6.Text = Convert.ToString(temp_Estimate[38]);
                textBox_EstimateAntennaPower7.Text = Convert.ToString(temp_Estimate[40]);
                textBox_EstimateAntennaPower8.Text = Convert.ToString(temp_Estimate[42]);
                textBox_EstimateAntennaPower9.Text = Convert.ToString(temp_Estimate[44]);
                textBox_EstimateAntennaPower10.Text = Convert.ToString(temp_Estimate[46]);
            }
        }

        private void textBox_MeasureAntennaPowerMinus13_KeyUp(object sender, KeyEventArgs e)
        {
            Estimate();
        }

        private void textBox_MeasureAntennaPowerMinus12_KeyUp(object sender, KeyEventArgs e)
        {
            Estimate();
        }

        private void textBox_MeasureAntennaPowerMinus11_KeyUp(object sender, KeyEventArgs e)
        {
            Estimate();
        }

        private void textBox_MeasureAntennaPowerMinus10_KeyUp(object sender, KeyEventArgs e)
        {
            Estimate();
        }

        private void textBox_MeasureAntennaPowerMinus9_KeyUp(object sender, KeyEventArgs e)
        {
            Estimate();
        }

        private void textBox_MeasureAntennaPowerMinus8_KeyUp(object sender, KeyEventArgs e)
        {
            Estimate();
        }

        private void textBox_MeasureAntennaPowerMinus7_KeyUp(object sender, KeyEventArgs e)
        {
            Estimate();
        }

        private void textBox_MeasureAntennaPowerMinus6_KeyUp(object sender, KeyEventArgs e)
        {
            Estimate();
        }

        private void textBox_MeasureAntennaPowerMinus5_KeyUp(object sender, KeyEventArgs e)
        {
            Estimate();
        }

        private void textBox_MeasureAntennaPowerMinus4_KeyUp(object sender, KeyEventArgs e)
        {
            Estimate();
        }

        private void textBox_MeasureAntennaPowerMinus3_KeyUp(object sender, KeyEventArgs e)
        {
            Estimate();
        }

        private void textBox_MeasureAntennaPowerMinus2_KeyUp(object sender, KeyEventArgs e)
        {
            Estimate();
        }

        private void textBox_MeasureAntennaPowerMinus1_KeyUp(object sender, KeyEventArgs e)
        {
            Estimate();
        }

        private void textBox_MeasureAntennaPower0_KeyUp(object sender, KeyEventArgs e)
        {
            Estimate();
        }

        private void textBox_MeasureAntennaPower1_KeyUp(object sender, KeyEventArgs e)
        {
            Estimate();
        }

        private void textBox_MeasureAntennaPower2_KeyUp(object sender, KeyEventArgs e)
        {
            Estimate();
        }

        private void textBox_MeasureAntennaPower3_KeyUp(object sender, KeyEventArgs e)
        {
            Estimate();
        }

        private void textBox_MeasureAntennaPower4_KeyUp(object sender, KeyEventArgs e)
        {
            Estimate();
        }

        private void textBox_MeasureAntennaPower5_KeyUp(object sender, KeyEventArgs e)
        {
            Estimate();
        }

        private void textBox_MeasureAntennaPower6_KeyUp(object sender, KeyEventArgs e)
        {
            Estimate();
        }

        private void textBox_MeasureAntennaPower7_KeyUp(object sender, KeyEventArgs e)
        {
            Estimate();
        }

        private void textBox_MeasureAntennaPower8_KeyUp(object sender, KeyEventArgs e)
        {
            Estimate();
        }

        private void textBox_MeasureAntennaPower9_KeyUp(object sender, KeyEventArgs e)
        {
            Estimate();
        }

        private void textBox_MeasureAntennaPower10_KeyUp(object sender, KeyEventArgs e)
        {
            Estimate();
        }

        private void button_WriteModulePowerTable_Click(object sender, EventArgs e)
        {
            ByteBuilder bb = new ByteBuilder();

            for(int i=0; i<temp_Estimate.Length; i++)
            {
                bb.Append(Convert.ToByte((temp_Estimate[i]>>8) & 0xff));
                bb.Append(Convert.ToByte(temp_Estimate[i] & 0xff));
            }

            if (!RcpProtocol.Instance.SendBytePkt(RcpProtocol.Instance.BuildCmdPacketByte(RcpProtocol.RCP_MSG_CMD, RcpProtocol.RCP_CMD_SET_MODULE_TABLE, bb.GetByteArray()))) { }
        }
    }
}
