using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Phychips.Rcp;

namespace Phychips.PR9200
{
    class LeakGuidance
    {
        private byte  _idt, _dtc1, _dtc2, _ch;

        public byte IDT
        {
            get
            {
                return _idt;
            }
            set
            {
                _idt = value;
            }
        }

        public byte DTC1
        {
            get
            {
                return _dtc1;
            }
            set
            {
                _dtc1 = value;
            }
        }

        public byte DTC2
        {
            get
            {
                return _dtc2;
            }
            set
            {
                _dtc2 = value;
            }
        }

        public byte CH
        {
            get
            {
                return _ch;
            }
            set
            {
                _ch = value;
            }
        }

        public LeakGuidance()
        {
 
        }

        public LeakGuidance(byte idt, byte dtc1, byte dtc2, byte ch)
        {
            this._idt = idt;
            this._dtc1 = dtc1;
            this._dtc2 = dtc2;
            this._ch = ch;
        }
    }
}
