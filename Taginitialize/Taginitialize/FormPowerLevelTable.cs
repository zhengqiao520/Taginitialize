using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phychips.PR9200
{
    public partial class FormPowerLevellTable : Form
    {
        private const int SIZE_MAX = 21;
        private int m_nSize = 0;
        private UInt16[] m_aPower = null;
        

        public UInt16[] APower
        {
            get { return m_aPower; }
            set { m_aPower = value; }
        }




        public FormPowerLevellTable()
        {
            InitializeComponent();
        }

        public UInt16[] GetPowerLevelTable()
        {
            return m_aPower;
            
        }       

        private void FormPowerLevellTable_Load(object sender, EventArgs e)
        {
            
            this.listViewEx1.textBoxLeave += validate_powerLevel;


        }

        private double[] arrayCalPwrStep = null;
        private double[] tmpCalSetp = new double[21];
      //  private double[] arrayCalPwrStep = null;
      //  private double[] tmpCalSetp = null;

        public void SetPowerLevel(UInt16[] arrayPowerLevel, double[] arrayCalStep)        
        {

            tmpCalSetp = (double[])arrayCalStep.Clone();

            m_nSize = arrayPowerLevel.Length;
            
            arrayCalPwrStep = new double[m_nSize];
                        

            for (int i = 0; i < m_nSize; i++)
            {
                //arrayCalPwrStep[i] = arrayCalStep[i];
                ListViewItem lvi = new ListViewItem(Convert.ToString(-(0.5*i)));               
                lvi.SubItems.Add(Convert.ToString(arrayPowerLevel[i]));
                lvi.SubItems.Add(Convert.ToString(arrayPowerLevel[Convert.ToInt16(i)]));
                arrayCalPwrStep[i] = Convert.ToDouble(arrayPowerLevel[i] - 200) / 10d; 
                lvi.SubItems.Add(Convert.ToString(arrayCalPwrStep[Convert.ToInt16(i)]));
                this.listViewEx1.Items.Add(lvi);
                this.listViewEx1.AddEditableCell(Convert.ToInt16(i), 1);
               // this.listViewEx1.AddEditableCell(Convert.ToInt16(i), 3);
                
            }
 
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            if (m_nSize >= SIZE_MAX) return;

            ListViewItem lvi = new ListViewItem(Convert.ToString(-(0.5 * this.listViewEx1.Items.Count)));  
           // lvi.SubItems.Add("1");
            lvi.SubItems.Add(Convert.ToString("0"));
            lvi.SubItems.Add(Convert.ToString("0"));
            lvi.SubItems.Add(Convert.ToString("0"));
            this.listViewEx1.Items.Add(lvi);
            this.listViewEx1.AddEditableCell(this.listViewEx1.Items.Count - 1, 1);
            //this.listViewEx1.AddEditableCell(this.listViewEx1.Items.Count - 1, 3);

            m_nSize++;
        }

        private void buttonRemoveItem_Click(object sender, EventArgs e)
        {
            if (this.listViewEx1.SelectedItems == null || this.listViewEx1.SelectedItems.Count == 0)
            {
                if (this.listViewEx1.Items.Count > 0)
                {
                    this.listViewEx1.Items.Remove(this.listViewEx1.Items[this.listViewEx1.Items.Count - 1]);
                }                
            }
            else
            {
                this.Visible = false;
                this.listViewEx1.Items.Remove(this.listViewEx1.SelectedItems[0]);

                for (int i = 0; i < this.listViewEx1.Items.Count; i++)
                {
                    this.listViewEx1.Items[i].SubItems[0].Text = (-(0.5 * i)).ToString("D2");
                }
                this.Visible = true;
            }

            m_nSize--;
        }

        private void buttonUpdateTable_Click(object sender, EventArgs e)
        {
            m_aPower = new UInt16[this.listViewEx1.Items.Count];

            for (int i = 0; i < this.listViewEx1.Items.Count; i++)
            {
                try
                {
                    m_aPower[i] = Convert.ToUInt16(this.listViewEx1.Items[i].SubItems[1].Text);      
                }
                catch
                {

                }
            }            
        }  

        public void validate_powerLevel(object sender, EventArgs e)
        {
            CustomListView.ListViewEx.TextBoxLeaveEventArg te = (CustomListView.ListViewEx.TextBoxLeaveEventArg)e;

            try
            {
                //double pwrLv = byte.Parse(this.listViewEx1.Items[te.Row].SubItems[te.Col].Text);
                double pwrVal;
                double criteriaVal = 200;
                double minPwrLv = -10d;
                
                pwrVal =  (( Convert.ToDouble(this.listViewEx1.Items[te.Row].SubItems[te.Col].Text)) -criteriaVal) / 10d ;
                this.listViewEx1.Items[te.Row].SubItems[3].Text = Convert.ToString(pwrVal);

                double pwrLv = Convert.ToDouble(this.listViewEx1.Items[te.Row].SubItems[te.Col].Text);
                if (pwrLv < minPwrLv)
                {
                    this.listViewEx1.Items[te.Row].SubItems[3].Text = "Invalid  Power";
                }
            }
            catch
            {
                this.listViewEx1.Items[te.Row].SubItems[te.Col].Text = "Invalid Power 2";
            }
        }
         
        private void button_load_CalPwrSTP_Click(object sender, EventArgs e)
        {

            try
            {
                double pwrVal;
                double criteriaVal = 200;
                double minPwrLv = -10d;

           
                for (int i = 0; i <  tmpCalSetp.Length; i++)
                //for (int i = 0; i < m_nSize; i++)
                {
                    this.listViewEx1.Items[i].SubItems[3].Text = Convert.ToString(tmpCalSetp[Convert.ToInt16(i)]);
                    pwrVal = criteriaVal + (Convert.ToDouble(this.listViewEx1.Items[i].SubItems[3].Text) * 10d);
                    this.listViewEx1.Items[i].SubItems[1].Text = Convert.ToString(pwrVal);

                    double pwrLv = Convert.ToDouble(this.listViewEx1.Items[i].SubItems[3].Text);
                    if (pwrLv < minPwrLv)
                    {
                        this.listViewEx1.Items[i].SubItems[3].Text = "Invalid  Power";
                    }
                }
            }
            catch
            {
                this.listViewEx1.Items[0].SubItems[3].Text = "Invalid  Power";
            }
        }
    }
}
