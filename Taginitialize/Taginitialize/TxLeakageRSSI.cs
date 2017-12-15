using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Phychips.PR9200
{
    class TxLeakageRSSI
    {
        public TxLeakageRSSI Next;     //  Reference for type TxLeakageRSSI(Node of the Linked list)
        public int Ch;

        public double[,] TLRval = new double[32, 32];
        public byte[,] TLRrgb = new byte[32, 32];
        public byte[,] TLRrgbUpSampled = new byte[352, 352];

        public int MinDTC1, MinDTC2;

        public Bitmap tlrTorgb()
        {
            mkUpSampledMatrix();

            int width = 352;
            int height = 352;

            Bitmap bitmap = new Bitmap(width, height);
            Color temp = new Color();

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    if (TLRrgbUpSampled[x, y] < 10)     //  Black -> Blue Section
                    {
                        temp = Color.FromArgb(255, 0, 0, (byte)((double)28.3 * (double)TLRrgbUpSampled[x, y]));
                    }
                    else if ((10 <= TLRrgbUpSampled[x, y]) && (TLRrgbUpSampled[x, y] < 30)) //  Blue -> Teal Section
                    {                        
                        double r = GetColorFactor(x, y, 127 / (29 - 10), 10);
                        temp = Color.FromArgb(255, 0, (byte)r, 255 - (byte)r);
                    }
                    else if ((30 <= TLRrgbUpSampled[x, y]) && (TLRrgbUpSampled[x, y] < 50))     //  Teal -> Cyan Section
                    {
                        double r = GetColorFactor(x, y, 127 / (49 - 30), 30);
                        temp = Color.FromArgb(255, 0, 128 + (byte)r, 128 + (byte)r);
                    }
                    else if ((50 <= TLRrgbUpSampled[x, y]) && (TLRrgbUpSampled[x, y] < 70))     //  Cyan -> Spring Green Section
                    {
                        double r = GetColorFactor(x, y, 127 / (69 - 50), 50);
                        temp = Color.FromArgb(255, 0, 255, 255 - (byte)r);
                    }
                    else if ((70 <= TLRrgbUpSampled[x, y]) && (TLRrgbUpSampled[x, y] < 90))     // Spring green -> Lime Section
                    {
                        double r = GetColorFactor(x, y, 127 / (89 - 70), 70);
                        temp = Color.FromArgb(255, 0, 255, 127 - (byte)r);
                    }
                    else if ((90 <= TLRrgbUpSampled[x, y]) && (TLRrgbUpSampled[x, y] < 110))    // Lime -> Yellow Section
                    {                        
                        double r = GetColorFactor(x, y, 255 / (109 - 90), 90);
                        temp = Color.FromArgb(255, (byte)r, 255, 0);
                    }
                    else if ((110 <= TLRrgbUpSampled[x, y]) && (TLRrgbUpSampled[x, y] < 140))   // Yellow -> Orange Section
                    {                        
                        double r = GetColorFactor(x, y, 90 / (139 - 110), 110);
                        temp = Color.FromArgb(255, 255, 255 - (byte)r, 0);
                    }
                    else if ((140 <= TLRrgbUpSampled[x, y]) && (TLRrgbUpSampled[x, y] < 170))   // Orange -> Red Section
                    {                        
                        double r = GetColorFactor(x, y, 165 / (169 - 140), 140);
                        temp = Color.FromArgb(255, 255, 165 - (byte)r, 0);
                    }
                    else if (170 <= TLRrgbUpSampled[x, y])
                    {
                        temp = Color.FromArgb(255, 255, 0, 0);    //   red
                    }

                    bitmap.SetPixel(x, y, temp);
                }

            for (int i = 55; i < 352; i += 55)
            {
                i++;
                for (int j = 13; j < 297; j += 55)
                {
                    j++;
                    bitmap.SetPixel(i, j, Color.Black);
                    bitmap.SetPixel(i + 1, j, Color.Black);
                    bitmap.SetPixel(i, j + 1, Color.Black);
                    bitmap.SetPixel(i + 1, j + 1, Color.Black);
                }
            }

            return bitmap;
        }

        public void tlrTotxt(string path)
        {
            try
            {
                StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.Append));

                sw.Write("Channel : ");
                sw.WriteLine(Ch.ToString());

                for (int i = 0; i < 32; i++)
                {
                    for (int j = 0; j < 32; j++)
                    {
                        sw.Write(TLRval[j, i].ToString());
                        sw.Write("\t");
                    }
                    sw.WriteLine("");
                }
                sw.Close();
            }
            catch
            {

            }
        }

        public void mkUpSampledMatrix()
        {
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    TLRrgb[i, j] = (byte)TLRval[i, j];
                }
            }

            for (int i = 0; i < 352; i++)
            {
                for (int j = 0; j < 352; j++)
                {
                    TLRrgbUpSampled[i, j] = TLRrgb[i / 11, j / 11];
                }
            }

            // Bilinear Interpolation
            
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    BiLinearInterpolation(i, j);
                }
            }            
        }

        public void FindOptimzedDTC_Coordinate()
        {
            double temp = double.MaxValue;

            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    if (TLRval[i, j] < temp)
                    {
                        temp = TLRval[i, j];
                        MinDTC1 = i;
                        MinDTC2 = j;
                    }
                }
            }
        }

        private void BiLinearInterpolation(int Xoffset,int Yoffset)
        {
            double a, b,
                   p, q;

            byte valA, valB,
                 valC, valD;

            // set  A, B
            //      C, D

            int samplePointX = Xoffset * 11,
                samplePointY = Yoffset * 11;

            if ((samplePointX + 11 >= 352) && (samplePointY + 11 >= 352))
            {
                valA = TLRrgbUpSampled[samplePointX, samplePointY]; valB = TLRrgbUpSampled[samplePointX, samplePointY];
                valC = TLRrgbUpSampled[samplePointX, samplePointY]; valD = TLRrgbUpSampled[samplePointX, samplePointY];
            }
            else if (samplePointY + 11 >= 352)
            {
                valA = TLRrgbUpSampled[samplePointX, samplePointY]; valB = TLRrgbUpSampled[samplePointX + 11, samplePointY];
                valC = TLRrgbUpSampled[samplePointX, samplePointY]; valD = TLRrgbUpSampled[samplePointX + 11, samplePointY];
            }
            else if(samplePointX + 11 >= 352)
            {
                valA = TLRrgbUpSampled[samplePointX, samplePointY];      valB = TLRrgbUpSampled[samplePointX, samplePointY];
                valC = TLRrgbUpSampled[samplePointX, samplePointY + 11]; valD = TLRrgbUpSampled[samplePointX, samplePointY + 11];
            }
            else
            {
                valA = TLRrgbUpSampled[samplePointX, samplePointY];      valB = TLRrgbUpSampled[samplePointX + 11, samplePointY];
                valC = TLRrgbUpSampled[samplePointX, samplePointY + 11]; valD = TLRrgbUpSampled[samplePointX + 11, samplePointY + 11];
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

                    TLRrgbUpSampled[i, j] = (byte)((q*b*valA + q*a*valB + 
                                                    p*b*valC + p*a*valD)/121);
                }
            }
        }

        private double GetColorFactor(int x, int y, double val, double scale)
        {
            return val * TLRrgbUpSampled[x, y] - val * scale;
        }
    }
}
