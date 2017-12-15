using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ZedGraph;

namespace Phychips.PR9200
{
    public partial class FormReadRangeCalculator : Form
    {
        static double ReaderSens,
                      ReaderAntennaGain,                      
                      deltaLreader,
                      lambda,
                      TagSens,
                      TagAntennaGain,
                      deltaLtag,
                      pathLoss;              

        GraphPane ReadRange = new GraphPane();
        
        public FormReadRangeCalculator()
        {
            InitializeComponent();
            
            ReadRange = zedGraphControl.GraphPane;   
            setPlotOption();
            setParameter();

            Draw();         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (buttonDetails.Text == "Details")
            {
                CtrlDetailView();
            }
            else if (buttonDetails.Text == "Fold")
            {
                CtrlBriefView();
            }
        }

        private void CtrlDetailView()
        {
            groupBoxParameter.Height = 215;

            groupBoxReaderParameter.Height = 189;
            groupBoxTagParameter.Height = 189;

            this.Height = 632;

            buttonDetails.Text = "Fold";

            buttonDetails.Location = new System.Drawing.Point(163, 160);
        }

        private void CtrlBriefView()
        {
            groupBoxParameter.Height = 123;

            groupBoxReaderParameter.Height = 97;
            groupBoxTagParameter.Height = 97;

            this.Height = 536;

            buttonDetails.Text = "Details";

            buttonDetails.Location = new System.Drawing.Point(163, 73);
        }

        private void plotLocus(object sender, EventArgs args)
        {
            try
            {                
                zedGraphControl.GraphPane.CurveList.Clear();
                zedGraphControl.GraphPane.GraphObjList.Clear();
                zedGraphControl.Refresh();
                
                ReadRange = zedGraphControl.GraphPane;
                setPlotOption();
                setParameter();

                Draw();     
            }
            catch (Exception)
            {
                return;
            }        
        }

        private void setParameter()        
        {
            FormReadRangeCalculator.ReaderSens = double.Parse(numericUpDownReaderSens.Value.ToString());
            FormReadRangeCalculator.ReaderAntennaGain = radioButtonLinearAntenna.Checked ? double.Parse(textBoxReaderAntennaGain.Text) : (double.Parse(textBoxReaderAntennaGain.Text) - (double)3);            
            FormReadRangeCalculator.deltaLreader = double.Parse(textBoxdeltaLeader.Text);
            FormReadRangeCalculator.lambda = double.Parse(textBoxLambda.Text);

            FormReadRangeCalculator.TagSens = double.Parse(numericUpDownTagSens.Value.ToString());
            FormReadRangeCalculator.TagAntennaGain = double.Parse(textBoxTagAntennaGain.Text);
            FormReadRangeCalculator.deltaLtag = double.Parse(textBoxdeltaLtag.Text);
            FormReadRangeCalculator.pathLoss = double.Parse(textBoxPathLoss.Text);            
        }

        private void setPlotOption()
        {
            ReadRange.Title.Text = "Read Range vs Tx Output Power";
            ReadRange.XAxis.Title.Text = "Tx output Power @ antenna port[dBm]";
            ReadRange.YAxis.Title.Text = "Read Range[m]";

            ReadRange.XAxis.Scale.Min = 0;
            ReadRange.XAxis.Scale.Max = 34;
            ReadRange.XAxis.Scale.MinorStep = 1;
            ReadRange.XAxis.Scale.MajorStep = 5;
            ReadRange.XAxis.MajorGrid.IsVisible = true;       

            ReadRange.YAxis.Scale.Min = 0;
            ReadRange.YAxis.Scale.Max = 10;
            ReadRange.YAxis.Scale.MinorStep = 0.5;
            ReadRange.YAxis.Scale.MajorStep = 1;
            ReadRange.YAxis.MajorGrid.IsVisible = true;

            ReadRange.Legend.Position = LegendPos.InsideTopRight;            
            //ReadRange.Legend.Location = new Location(0.95f, 0.15f, CoordType.PaneFraction, AlignH.Right, AlignV.Top);
            ReadRange.Legend.FontSpec.Size = 10f;
            ReadRange.Legend.IsHStack = false;             
        }

        private void Draw()
        {
            PointPairList listReaderlimit = new PointPairList();
            PointPairList listTaglimit = new PointPairList();
            PointPairList listDistance = new PointPairList();

            LineItem ReaderLimit;
            LineItem TagLimit;
            LineItem Distance;

            if (checkBoxReaderLimit.Checked == true)
            {
                for (int i = 0; i < 35; i++)
                {
                    listReaderlimit.Add(i, readerLimit((double)i));
                }

                ReaderLimit = ReadRange.AddCurve("Reader Limit", listReaderlimit, Color.Red, SymbolType.Circle);
            }

            if (checkBoxTagLimit.Checked == true)
            {
                for (int i = 0; i < 35; i++)
                {
                    listTaglimit.Add(i, tagLimit((double)i));
                }

                TagLimit = ReadRange.AddCurve("Tag Limit", listTaglimit, Color.Blue, SymbolType.Diamond);
            }

            for (int i = 0; i < 35; i++)
            {
                listDistance.Add(i, ReadRangeCalculator((double)i));
            }

            Distance = ReadRange.AddCurve("Read Range", listDistance, Color.Black, SymbolType.XCross);

            zedGraphControl.Refresh();   
        }

        private double tagLimit(double power)
        {
            double result;

            double TS,
                   TAG,
                   dL,
                   PL;

            double RAG;

            TS = Math.Pow(10, (FormReadRangeCalculator.TagSens - 30) / 10);

            TAG = Math.Pow(10, FormReadRangeCalculator.TagAntennaGain / 10);
            dL = Math.Pow(10, FormReadRangeCalculator.deltaLtag / 10);
            PL = Math.Pow(10, FormReadRangeCalculator.pathLoss / 10);

            RAG = Math.Pow(10, FormReadRangeCalculator.ReaderAntennaGain / 10);

            result = FormReadRangeCalculator.lambda / (double)4 / Math.PI * Math.Sqrt(RAG * TAG / PL / TS);
            result = result * Math.Sqrt(Math.Pow(10, (power - 30) / 10));
            result = Math.Round(result, 2);

            return result;
        }

        private double readerLimit(double power)
        {
            double result;

            double RS,
                   RAG,
                   dL,
                   PL;

            double TAG;

            RS = Math.Pow(10, (FormReadRangeCalculator.ReaderSens - 30) / 10);

            RAG = Math.Pow(10, FormReadRangeCalculator.ReaderAntennaGain / 10);
            dL = Math.Pow(10, FormReadRangeCalculator.deltaLreader / 10);
            PL = Math.Pow(10, FormReadRangeCalculator.pathLoss / 10);

            TAG = Math.Pow(10, FormReadRangeCalculator.TagAntennaGain / 10);

            result = FormReadRangeCalculator.lambda / (double)4 / Math.PI * Math.Sqrt(RAG * TAG / PL) * Math.Sqrt(Math.Sqrt(dL / RS));
            result = result * Math.Sqrt(Math.Sqrt(Math.Pow(10, (power - 30) / 10)));
            result = Math.Round(result, 2);

            return result;
        }

        private double ReadRangeCalculator(double power)
        {
            double result;
            
            if (tagLimit(power) < readerLimit(power))
            {
                result = tagLimit(power);
            }
            else
            {
                result = readerLimit(power);
            }

            return result;
        }
    }
}
