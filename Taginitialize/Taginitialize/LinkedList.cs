using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Phychips.PR9200
{
    class LinkedList
    {
        public TxLeakageRSSI head;     //   TxLeakageRSSI <- Node
        public int numNodes;

        private byte[,] SharedMatrix = new byte[352, 352];

        public LinkedList()
        {
            head = null;
            numNodes = 0;        
        }

        public void addToHead(double[,] tlr, int i)
        {
            TxLeakageRSSI item = new TxLeakageRSSI();

            item.TLRval = tlr;
            item.Ch = i;
            item.Next = head;

            head = item;
            numNodes++;
        }

        public void valToTxt(string path)
        {
            for (TxLeakageRSSI i = head; i != null; i = i.Next)
            {
                i.tlrTotxt(path);
            }
        }

        public string GetPointInformation(int ch, int x, int y)
        {
            string result = string.Empty;

            for (TxLeakageRSSI i = head; i != null; i = i.Next)
            {
                if (ch == i.Ch)
                {
                    result = i.TLRval[x, y].ToString("N2");
                }
            }

            return result;
        }

        public string GetPointInformation(int x, int y)
        {
            string result = string.Empty;            

            for (TxLeakageRSSI i = head; i != null; i = i.Next)
            {
                if ( (x == i.MinDTC1) && (y == i.MinDTC2))
                {
                    result += "Channel : " + i.Ch.ToString() + "\r\n";
                    result += "(DTC1, DTC2) = " + "(" + i.MinDTC1.ToString() + ", " + i.MinDTC2.ToString() + ")"+"\r\n";
                    result += "RSSI : " + i.TLRval[x, y].ToString("N2") + "\r\n";      
                }                    
            }

            return result;
        }

        public string GetPointInformation(int x, int y, int[] array)
        {
            string result = string.Empty;
            bool Selected = false;

            for (TxLeakageRSSI i = head; i != null; i = i.Next)
            {
                for (int s = 0; s < array.Length; s++)
                {
                    if (array[s] == i.Ch)
                    {
                        Selected = true;
                        break;
                    }  
                }

                if (Selected == true)
                {
                    if ((x == i.MinDTC1) && (y == i.MinDTC2))
                    {
                        result += "Channel : " + i.Ch.ToString() + "\r\n";
                        result += "(DTC1, DTC2) = " + "(" + i.MinDTC1.ToString() + ", " + i.MinDTC2.ToString() + ")" + "\r\n";
                        result += "RSSI : " + i.TLRval[x, y].ToString("N2") + "\r\n";
                    }
                }
                Selected = false;
            }            
            return result;
        }

        public Bitmap SinglePlot(int ch)
        {
            Bitmap result = null;

            for (TxLeakageRSSI i = head; i != null; i = i.Next)
            {
                if (ch == i.Ch)
                {
                    result = i.tlrTorgb();
                }
            }

            return result;
        }

        public Bitmap MultiPlot(int[] array)
        {
            Bitmap result = null;
            bool Selected = false;

            //  Initialize Matrix with 0 (gonna be whited)
            for (int i = 0; i < 352; i++)
            {
                for (int j = 0; j < 352; j++)
                {
                    SharedMatrix[i, j] = 255;
                }
            }

            for (TxLeakageRSSI k = head; k != null; k = k.Next)
            {
                for (int s = 0; s < array.Length; s++)
                {
                    if (array[s] == k.Ch)
                    {
                        Selected = true;
                        break;
                    }
                }

                if (Selected == true)
                {                    
                    k.mkUpSampledMatrix();
                    
                    for (int i = 0; i < 352; i++)
                    {
                        for (int j = 0; j < 352; j++)
                        {
                            if (SharedMatrix[i, j] > k.TLRrgbUpSampled[i, j])
                            {
                                SharedMatrix[i, j] = k.TLRrgbUpSampled[i, j];
                            }
                        }
                    }
                }

                Selected = false;
            }           

            int width = 352,
                height = 352;

            result = new Bitmap(width, height);

            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    BiLinearInterpolation(i, j);
                }
            }

            Color temp = new Color();

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    if (SharedMatrix[x, y] < 10)     //  Black -> Blue Section
                    {
                        temp = Color.FromArgb(255, 0, 0, (byte)((double)28.3 * (double)SharedMatrix[x, y]));
                    }
                    else if ((10 <= SharedMatrix[x, y]) && (SharedMatrix[x, y] < 30)) //  Blue -> Teal Section
                    {
                        double r = GetColorFactor(x, y, 127 / (29 - 10), 10);
                        temp = Color.FromArgb(255, 0, (byte)r, 255 - (byte)r);
                    }
                    else if ((30 <= SharedMatrix[x, y]) && (SharedMatrix[x, y] < 50))     //  Teal -> Cyan
                    {                        
                        double r = GetColorFactor(x, y, 127 / (49 - 30), 30);
                        temp = Color.FromArgb(255, 0, 128 + (byte)r, 128 + (byte)r);
                    }
                    else if ((50 <= SharedMatrix[x, y]) && (SharedMatrix[x, y] < 70))     //  Cyan -> Spring Green
                    {                        
                        double r = GetColorFactor(x, y, 127 / (69 - 50), 50);
                        temp = Color.FromArgb(255, 0, 255, 255 - (byte)r);
                    }
                    else if ((70 <= SharedMatrix[x, y]) && (SharedMatrix[x, y] < 90))     // Spring green -> Lime
                    {
                        double r = GetColorFactor(x, y, 127 / (89 - 70), 70);
                        temp = Color.FromArgb(255, 0, 255, 127 - (byte)r);
                    }
                    else if ((90 <= SharedMatrix[x, y]) && (SharedMatrix[x, y] < 110))    // Lime -> Yellow
                    {                        
                        double r = GetColorFactor(x, y, 255 / (109 - 90), 90);
                        temp = Color.FromArgb(255, (byte)r, 255, 0);
                    }
                    else if ((110 <= SharedMatrix[x, y]) && (SharedMatrix[x, y] < 140))
                    {
                        double r = GetColorFactor(x, y, 90 / (139 - 110), 110);
                        temp = Color.FromArgb(255, 255, 255 - (byte)r, 0); // yellow
                    }
                    else if ((140 <= SharedMatrix[x, y]) && (SharedMatrix[x, y] < 170))   // Orange -> Red
                    {                        
                        double r = GetColorFactor(x, y, 165 / (169 - 140), 140);
                        temp = Color.FromArgb(255, 255, 165 - (byte)r, 0);
                    }
                    else if (170 <= SharedMatrix[x, y])
                    {
                        temp = Color.FromArgb(255, 255, 0, 0);    //   red
                    }

                    result.SetPixel(x, y, temp);
                }


            // make Point 
            for (TxLeakageRSSI i = head; i != null; i = i.Next)
            {
                for (int s = 0; s < array.Length; s++)
                {
                    if (array[s] == i.Ch)
                    {
                        Selected = true;
                        break;
                    }
                }

                if (Selected == true)
                {
                    // min DTC1,DTC2 gonna be setted

                    i.FindOptimzedDTC_Coordinate();

                    for (int j = 11 * i.MinDTC1; j < 11 * i.MinDTC1 + 11; j++)
                    {
                        for (int k = 11 * i.MinDTC2; k < 11 * i.MinDTC2 + 11; k++)
                        {
                            if (SharedMatrix[j, k] <= 30)
                            {
                                result.SetPixel(j, k, Color.Black);
                            }
                        }
                    }                                        
                }
                Selected = false;
            }

            for (int i = 55; i < 352; i += 55)
            {
                i++;
                for (int j = 13; j < 297; j += 55)
                {
                    j++;
                    result.SetPixel(i, j, Color.Black);     result.SetPixel(i + 1, j, Color.Black);
                    result.SetPixel(i, j + 1, Color.Black); result.SetPixel(i + 1, j + 1, Color.Black);
                }
            }

            return result;
        }

        private void BiLinearInterpolation(int Xoffset, int Yoffset)
        {
            double a, b,
                   p, q;

            byte valA, valB,
                 valC, valD;

            // set  A, B
            //      C, D
            // including the case of Edge

            int samplePointX = Xoffset * 11,
                samplePointY = Yoffset * 11;

            if ((samplePointX + 11 >= 352) && (samplePointY + 11 >= 352))
            {
                valA = SharedMatrix[samplePointX, samplePointY]; valB = SharedMatrix[samplePointX, samplePointY];
                valC = SharedMatrix[samplePointX, samplePointY]; valD = SharedMatrix[samplePointX, samplePointY];
            }

            else if (samplePointY + 11 >= 352)
            {
                valA = SharedMatrix[samplePointX, samplePointY]; valB = SharedMatrix[samplePointX + 11, samplePointY];
                valC = SharedMatrix[samplePointX, samplePointY]; valD = SharedMatrix[samplePointX + 11, samplePointY];
            }
            else if (samplePointX + 11 >= 352)
            {
                valA = SharedMatrix[samplePointX, samplePointY]; valB = SharedMatrix[samplePointX, samplePointY];
                valC = SharedMatrix[samplePointX, samplePointY + 11]; valD = SharedMatrix[samplePointX, samplePointY + 11];
            }
            else
            {
                valA = SharedMatrix[samplePointX, samplePointY]; valB = SharedMatrix[samplePointX + 11, samplePointY];
                valC = SharedMatrix[samplePointX, samplePointY + 11]; valD = SharedMatrix[samplePointX + 11, samplePointY + 11];
            }

            // set a,b
            // set p,
            //     q

            for (int i = (Xoffset * 11); i < (Xoffset * 11) + 11; i++)
            {
                for (int j = (Yoffset * 11); j < (Yoffset * 11) + 11; j++)
                {
                    a = (i - (Xoffset * 11));
                    b = (11 - a);

                    p = (j - (Yoffset * 11));
                    q = (11 - p);

                    SharedMatrix[i, j] = (byte)((q * b * valA + q * a * valB +
                                                 p * b * valC + p * a * valD) / 121);
                }
            }
        }

        private double GetColorFactor(int x, int y, double val, double scale)
        {
            return val * SharedMatrix[x, y] - val * scale;
        }
    }
}
