using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Phychips.Helper;

namespace Phychips.PR9200
{
    public partial class FormTagInfoTidEpc : Form
    {
        public FormTagInfoTidEpc()
        {
            InitializeComponent();
        }

        public System.Windows.Forms.TextBox TextBoxAc
        {
            get { return textBoxAc; }         
        }

        public System.Windows.Forms.TextBox TextBoxXtid
        {
            get { return textBoxXtid; }            
        }

        public System.Windows.Forms.TextBox TextBoxMdidCode
        {
            get { return textBoxMdidCode; }            
        }

        public System.Windows.Forms.TextBox TextBoxModelNumberCode
        {
            get { return textBoxModelNumberCode; }            
        }

        public System.Windows.Forms.TextBox TextBoxXtidHeader
        {
            get { return textBoxXtidHeader; }            
        }

        public System.Windows.Forms.TextBox TextBoxSn
        {
            get { return textBoxSn; }            
        }

        public System.Windows.Forms.TextBox TextBoxOptionalCmd
        {
            get { return textBoxOptionalCmd; }            
        }

        public System.Windows.Forms.TextBox TextBoxBlockWrtErase
        {
            get { return textBoxBlockWrtErase; }            
        }

        public System.Windows.Forms.TextBox TextBoxBlockPermalock
        {
            get { return textBoxBlockPermalock; }            
        }
        
        public void SetMdidModel()
        {
            string MdidCode = textBoxMdidCode.Text.TrimEnd(new char[] { ' ' });
            string ModelNumberCode = textBoxModelNumberCode.Text.TrimEnd(new char[] { ' ' });
                        
            switch (MdidCode)
            {
                case "001": textBoxMdidName.Text = "Impinj"; break;
                case "002": textBoxMdidName.Text = "Texas Instruments"; break;
                case "003": 
                    textBoxMdidName.Text = "Alien Technology";
                    SetAlienModel(ModelNumberCode);
                    break;
                case "004": textBoxMdidName.Text = "Intelleflex"; break;
                case "005": textBoxMdidName.Text = "Atmel"; break;
                case "006": textBoxMdidName.Text = "NXP Semiconductors";
                    SetNxpModel(ModelNumberCode);
                    break;
                case "007": textBoxMdidName.Text = "ST Microelectronics"; break;
                case "008": textBoxMdidName.Text = "EP Microelectronics"; break;
                case "009": textBoxMdidName.Text = "Motorola (formerly Symbol Technologies)"; break;
                case "00A": textBoxMdidName.Text = "Sentech Snd Bhd"; break;
                case "00B": textBoxMdidName.Text = "EM Microelectronics"; break;
                case "00C": textBoxMdidName.Text = "Renesas Technology Corp."; break;
                case "00D": textBoxMdidName.Text = "Mstar"; break;
                case "00E": textBoxMdidName.Text = "Tyco International"; break;
                case "00F": textBoxMdidName.Text = "Quanray Electronics	"; break;
                case "010": textBoxMdidName.Text = "Fujitsu"; break;
                case "011": textBoxMdidName.Text = "LSIS"; break;
                case "012": textBoxMdidName.Text = "CAEN RFID srl"; break;
                case "013": textBoxMdidName.Text = "Productivity Engineering Gesellschaft fuer IC Design mbH"; break;
                case "014": textBoxMdidName.Text = "Federal Electric Corp."; break;
                case "015": textBoxMdidName.Text = "ON Semiconductor"; break;
                case "016": textBoxMdidName.Text = "Ramtron"; break;
                case "017": textBoxMdidName.Text = "Tego"; break;
                case "018": textBoxMdidName.Text = "Ceitec S.A."; break;
                case "019": textBoxMdidName.Text = "CPA Wernher von Braun"; break;
                case "01A": textBoxMdidName.Text = "TransCore"; break;
                case "01B": textBoxMdidName.Text = "Nationz"; break;
                case "01C": textBoxMdidName.Text = "Invengo"; break;
                case "01D": textBoxMdidName.Text = "Kiloway"; break;
                case "01E": textBoxMdidName.Text = "Longjing Microelectronics Co. Ltd."; break;
                case "01F": textBoxMdidName.Text = "Chipus Microelectronics"; break;
            }
        }

        private void SetAlienModel(string ModelNumberCode)
        {
            switch (ModelNumberCode)
            {
                case "410": textBoxModelNumberName.Text = "Higgs 1"; break;
                case "411": textBoxModelNumberName.Text = "Higgs 2"; break;
                case "412": textBoxModelNumberName.Text = "Higgs 3"; break;
                case "413": textBoxModelNumberName.Text = "Higgs 4"; break;
            }
        }

        private void SetNxpModel(string ModelNumberCode)
        {
            switch (ModelNumberCode)
            {
                case "003": textBoxModelNumberName.Text = "Ucode G2XM"; break;
                case "004": textBoxModelNumberName.Text = "Ucode G2XL"; break;
                case "806": textBoxModelNumberName.Text = "Ucode G2iL"; break;
                case "807": textBoxModelNumberName.Text = "Ucode G2iL+"; break;
                case "80A": textBoxModelNumberName.Text = "Ucode G2iM"; break;
                case "80B": textBoxModelNumberName.Text = "Ucode G2iM+"; break;                
            }
        }

        private void SetImpinjModel(string ModelNumberCode)
        {
            switch (ModelNumberCode)
            {
                case "093": textBoxModelNumberName.Text = "Monza 3"; break;

                case "105": textBoxModelNumberName.Text = "Monza 4QT"; break;
                case "10C": textBoxModelNumberName.Text = "Monza 4E"; break;
                case "100": textBoxModelNumberName.Text = "Monza 4D"; break;                
                
                case "120": textBoxModelNumberName.Text = "Monza X-2K"; break;
                case "130": textBoxModelNumberName.Text = "Monza 5"; break;
            }
        }
    }
}
