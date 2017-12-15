using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;


namespace Phychips.PR9200
{
    class CodeToMsgTable
    {
        public static string CMDRSPDecoder(string[] s)
        {
            string Result = "";

            switch (s[3])
            {
                case "00":
                    Result = CMDDecoder(s);
                    break;
                case "01":
                    Result = RSPDecoder(s);
                    break;
                case "02":
                    if (s[4].Equals("2A") && !s[6].Equals("01"))
                        Result = RSPDecoder(s);
                    break;
            }
            return Result;
        }

        private static string CMDDecoder(string[] s)
        {
            string Result = "";
            
            StringBuilder sb = new StringBuilder();
            sb.Clear();

            switch (s[4])
            {
                case "01":
                    sb.Clear();
                    sb.Append("Set Reader Power Control : ");

                    if (s[7] == "00")
                    {
                        sb.AppendLine("Sleep");
                    }
                    else if (s[7] == "01")
                    {
                        sb.AppendLine("Deep Sleep");
                    }
                    Result = sb.ToString();

                    sb.Clear();
                    break;

                case "03":
                    sb.Clear();
                    sb.Append("Get Reader Information");

                    if (s[7] == "00")
                    {
                        sb.AppendLine(" : Model");
                    }
                    else if (s[7] == "01")
                    {
                        sb.AppendLine(" : FW Version");
                    }
                    else if (s[7] == "02")
                    {
                        sb.AppendLine(" : Manufacturer");
                    }
                    else if (s[7] == "03")
                    {
                        sb.AppendLine(" : Frequency");
                    }
                    else if (s[7] == "04")
                    {
                        sb.AppendLine(" : Tag Type");
                    }
                    else if (s[7] == "B0")
                    {
                        sb.AppendLine(" : Detail");
                    }
                    Result = sb.ToString();

                    sb.Clear();
                    break;

                case "06":
                    sb.Clear();
                    sb.AppendLine("Get Region");

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "07":
                    sb.Clear();
                    sb.Append("Set Region : ");

                    if (s[7] == "11")
                    {
                        sb.AppendLine("Korea");
                    }
                    else if (s[7] == "21")
                    {
                        sb.AppendLine("NA");
                    }
                    else if (s[7] == "22")
                    {
                        sb.AppendLine("US");
                    }
                    else if (s[7] == "31")
                    {
                        sb.AppendLine("Europe");
                    }
                    else if (s[7] == "41")
                    {
                        sb.AppendLine("Japan");
                    }
                    else if (s[7] == "51")
                    {
                        sb.AppendLine("China1");
                    }
                    else if (s[7] == "52")
                    {
                        sb.AppendLine("China");
                    }
                    Result = sb.ToString();

                    sb.Clear();
                    break;

                case "08":
                    sb.Clear();

                    sb.AppendLine("Set System Reset");
                    Result = sb.ToString();

                    sb.Clear();
                    break;

                case "0B":
                    sb.Clear();

                    sb.AppendLine("Get Type C A/I Select Parameter");
                    Result = sb.ToString();


                    sb.Clear();
                    break;

                case "0C":
                    sb.Clear();

                    sb.AppendLine("Set Type C A/I Select Parameter : ");
                    sb.Append("Target = ");
                    int val;

                    val = Convert.ToInt32(s[7], 16);
                    if ((val >> 5) == 0)
                    {
                        sb.AppendLine("S0");
                    }
                    else if ((val >> 5) == 1)
                    {
                        sb.AppendLine("S1");
                    }
                    else if ((val >> 5) == 2)
                    {
                        sb.AppendLine("S2");
                    }
                    else if ((val >> 5) == 3)
                    {
                        sb.AppendLine("S3");
                    }
                    else if ((val >> 5) == 4)
                    {
                        sb.AppendLine("SL");
                    }
                    
                    sb.Append("Action = ");
                    sb.AppendLine( ((val >> 2) & 7).ToString());

                    sb.Append("MemoryBank = ");
                    if ( (val & 3) == 0)
                    {
                        sb.AppendLine("RFU");
                    }
                    else if ((val & 3) == 1)
                    {
                        sb.AppendLine("EPC");
                    }
                    else if ((val & 3) == 2)
                    {
                        sb.AppendLine("TID");
                    }
                    else if ((val & 3) == 3)
                    {
                        sb.AppendLine("USER");
                    }

                    sb.Append("Pointer = ");
                    sb.AppendLine(s[8]+s[9]+s[10]+s[11]);

                    sb.Append("Length = ");
                    val = Convert.ToInt32(s[12], 16);
                    sb.AppendLine(val.ToString());

                    sb.Append("Truncate = ");
                    val = (Convert.ToByte(s[13], 16) >> 7);
                    if (val == 1)
                    {
                        sb.AppendLine("Enabled");
                    }
                    else if (val == 0)
                    {
                        sb.AppendLine("Disabled");
                    }

                    sb.Append("Reserve = ");
                    val = (Convert.ToByte(s[13], 16) & 127);
                    sb.AppendLine(val.ToString());

                    sb.Append("Mask = ");
                    val = (Convert.ToByte(s[5], 16) << 8) + Convert.ToByte(s[6], 16) - 7;

                    for (int i = 0; i < val; i++)
                    {
                        sb.Append(s[14+i]);    
                    }
                    sb.Append("\r\n");
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "0D":
                    sb.Clear();

                    sb.AppendLine("Get Type C A/I Query Parameter");
                    Result = sb.ToString();

                    sb.Clear();
                    break;

                case "0E":
                    sb.Clear();

                    sb.AppendLine("Set Type C A/I Query Parameter");
                    val = Convert.ToByte(s[7], 16);

                    sb.Append("DR = ");
                    if ((val>>7) == 1)
	                {
                        sb.AppendLine("64/3");
	                }
                    else if ((val >> 7) == 0)
                    {
                        sb.AppendLine("8");
                    }

                    sb.Append("M = ");
                    if (((val >> 5) & 3) == 0) 
                    {
                        sb.AppendLine("1");
                    }
                    else if (((val >> 5) & 3) == 1)
                    {
                        sb.AppendLine("2");
                    }
                    else if (((val >> 5) & 3) == 2)
                    {
                        sb.AppendLine("4");
                    }
                    else if (((val >> 5) & 3) == 3)
                    {
                        sb.AppendLine("8");
                    }

                    sb.Append("TRext = ");
                    if (((val >> 4) & 1) == 0)
                    {
                        sb.AppendLine("No pilot tone");
                    }
                    else if (((val >> 4) & 1) == 1)
                    {
                        sb.AppendLine("Use pilot tone");
                    }

                    sb.Append("Sel = ");
                    if (((val >> 2) & 3) == 2)
                    {
                        sb.AppendLine("~SL");
                    }
                    else if (((val >> 2) & 3) == 3)
                    {
                        sb.AppendLine("SL");
                    }
                    else
                    {
                        sb.AppendLine("All");
                    }

                    sb.Append("Session = ");
                    if (((val) & 3) == 0)
                    {
                        sb.AppendLine("S0");
                    }
                    else if (((val) & 3) == 1)
                    {
                        sb.AppendLine("S1");
                    }
                    else if (((val) & 3) == 2)
                    {
                        sb.AppendLine("S2");
                    }
                    else if (((val) & 3) == 3)
                    {
                        sb.AppendLine("S3");
                    }

                    val = Convert.ToByte(s[8], 16);

                    sb.Append("Target = ");
                    if (((val >> 7) & 1) == 0)
                    {
                        sb.AppendLine("A");
                    }
                    else if (((val >> 7) & 1) == 1)
                    {
                        sb.AppendLine("B");
                    }

                    sb.Append("Q = ");
                    sb.AppendLine(((val >> 3) & 15).ToString());

                    Result = sb.ToString();

                    sb.Clear();
                    break;

                case "11":
                    sb.Clear();

                    sb.AppendLine("Get current RF Channel");
                    Result = sb.ToString();

                    sb.Clear();
                    break;

                case "12":
                    sb.Clear();

                    sb.AppendLine("Set current RF Channel");
                    sb.AppendLine("Channel Number = " + Convert.ToByte(s[7], 16));
                    sb.AppendLine("Channel Offset = " + Convert.ToByte(s[8], 16));

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "13":
                    sb.Clear();
                    sb.AppendLine("Get FH and LBT Parameters");
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "14":
                    sb.Clear();

                    sb.AppendLine("Set FH and LBT Parameters");
           
                    val = (Convert.ToByte(s[7], 16) << 8) + Convert.ToByte(s[8], 16);
                    sb.Append("Read Time = ");
                    sb.AppendLine(val.ToString() + " [ms]");

                    val = (Convert.ToByte(s[9], 16) << 8) + Convert.ToByte(s[10], 16);
                    sb.Append("Idle Time = ");
                    sb.AppendLine(val.ToString() + " [ms]");

                    val = (Convert.ToByte(s[11], 16) << 8) + Convert.ToByte(s[12], 16);
                    sb.Append("CW Sense Time = ");
                    sb.AppendLine(val.ToString() + " [ms]");

                    val = (Convert.ToByte(s[13],16) << 8) + Convert.ToByte(s[14],16);

                    float val_f;
                    val_f = (float)((Int16)val) / 10;
                    sb.Append("LBT RF Level = ");
                    sb.AppendLine(val_f.ToString()+" [dBm]");

                    if (s[15] == "01" && s[16] == "00" && s[17] == "00")
                    {
                        sb.AppendLine("Frequency Hopping(Only) Enable");
                    }
                    else if (s[15] == "00" && s[16] == "01" && s[17] == "00")
                    {
                        sb.AppendLine("LBT(Only) Enable");
                    }
                    else if (s[15] == "02" && s[16] == "01" && s[17] == "00")
                    {
                        sb.AppendLine("Frequency Hopping(with LBT) Enable");
                    }
                    else if (s[15] == "01" && s[16] == "02" && s[17] == "00")
                    {
                        sb.AppendLine("LBT(with FH) Enable");
                    }

                    Result = sb.ToString();

                    sb.Clear();
                    break;

                case "15":
                    sb.Clear();

                    sb.AppendLine("Get Tx Power Level");
                    Result = sb.ToString();

                    sb.Clear();
                    break;

                case "16":
                    sb.Clear();

                    sb.AppendLine("Set Tx Power Level");
                    val = (Convert.ToByte(s[7], 16) << 8) + Convert.ToByte(s[8], 16);
                    val_f = (float)val / 10;
                    sb.AppendLine(val_f.ToString() + " [dBm]");
                    Result = sb.ToString();

                    sb.Clear();
                    break;

                case "17":
                    sb.Clear();

                    sb.AppendLine("RF CW signal control");
                    if (s[7] == "FF")
                    {
                        sb.AppendLine("RF CW signal On");
                    }
                    else
                    {
                        sb.AppendLine("Rf CW signal Off");
                    }
                    Result = sb.ToString();

                    sb.Clear();
                    break;

                case "1B":
                    sb.Clear();

                    sb.Clear();
                    break;

                case "22":
                    sb.Clear();

                    sb.AppendLine("Read Type C UII");
                    Result = sb.ToString();

                    sb.Clear();
                    break;

                case "25":
                    sb.Clear();

                    sb.AppendLine("Read Type C UII TID");
                    Result = sb.ToString();

                    sb.Clear();
                    break;

                case "27":
                    sb.Clear();

                    sb.AppendLine("Start Auto Read");
                    val = (Convert.ToByte(s[8], 16) << 8) + (Convert.ToByte(s[9], 16));

                    if (val == 0)
                    {
                        sb.AppendLine("Repeat Cycle = Infinite");
                    }
                    else
                    {
                        sb.AppendLine("Repeat Cycle = " + val.ToString());
                    }
                    Result = sb.ToString();

                    sb.Clear();
                    break;

                case "28":
                    sb.Clear();

                    sb.AppendLine("Stop Auto Read");
                    Result = sb.ToString();

                    sb.Clear();
                    break;

                case "29":
                    sb.Clear();

                    sb.AppendLine("Read Type C Tag Data");

                    sb.Append("Access Password = ");
                    sb.AppendLine(s[7]+s[8]+s[9]+s[10]);

                    sb.Append("Target tag's EPC length = ");
                    val = (Convert.ToByte(s[11], 16) << 8) + Convert.ToByte(s[12], 16);
                    sb.AppendLine(val.ToString());

                    sb.Append("Target tag's EPC = ");
                    for (int i = 0; i < val; i++)
                    {
                        sb.Append(s[13+i]+" ");
                        if (i == (val-1))
                        {
                            sb.Append("\r\nTarget Memory bank = ");
                            if (s[13 + val] == "00")
                            {
                                sb.AppendLine("RFU");
                            }
                            else if (s[13 + val] == "01")
                            {
                                sb.AppendLine("EPC");
                            }
                            else if (s[13 + val] == "02")
                            {
                                sb.AppendLine("TID");
                            }
                            else if (s[13 + val] == "03")
                            {
                                sb.AppendLine("User");
                            }

                            sb.Append("Starting Address word pointer = ");
                            sb.AppendLine(((Convert.ToByte(s[14 + val], 16) << 8) + Convert.ToByte(s[15 + val], 16)).ToString());

                            sb.Append("Data length(Word Count) = ");
                            sb.AppendLine(((Convert.ToByte(s[16 + val], 16) << 8) + Convert.ToByte(s[17 + val], 16)).ToString());
                        }
                    }

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "2A":
                    sb.Clear();

                    sb.AppendLine("Read Type C Tag Data (Long)");

                    sb.Append("Access Password = ");
                    sb.AppendLine(s[7] + s[8] + s[9] + s[10]);

                    sb.Append("Target tag's EPC length = ");
                    val = (Convert.ToByte(s[11], 16) << 8) + Convert.ToByte(s[12], 16);
                    sb.AppendLine(val.ToString());

                    sb.Append("Target tag's EPC = ");
                    for (int i = 0; i < val; i++)
                    {
                        sb.Append(s[13 + i] + " ");
                        if (i == (val - 1))
                        {
                            sb.Append("\r\nTarget Memory bank = ");
                            if (s[13 + val] == "00")
                            {
                                sb.AppendLine("RFU");
                            }
                            else if (s[13 + val] == "01")
                            {
                                sb.AppendLine("EPC");
                            }
                            else if (s[13 + val] == "02")
                            {
                                sb.AppendLine("TID");
                            }
                            else if (s[13 + val] == "03")
                            {
                                sb.AppendLine("User");
                            }

                            sb.Append("Starting Address word pointer = ");
                            sb.AppendLine(((Convert.ToByte(s[14 + val], 16) << 8) + Convert.ToByte(s[15 + val], 16)).ToString());

                            sb.Append("Data length(Word Count) = ");
                            sb.AppendLine(((Convert.ToByte(s[16 + val], 16) << 8) + Convert.ToByte(s[17 + val], 16)).ToString());
                        }
                    }

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "2E":
                    sb.Clear();
                    sb.AppendLine("Get Session");
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "2F":
                    sb.Clear();
                    sb.AppendLine("Set Session");
                    switch (s[7])
                    {
                        case "F0":
                            sb.AppendLine("Session = Dev.mode");
                            break;
                        case "00":
                            sb.AppendLine("Session = S0");
                            break;
                        case "01":
                            sb.AppendLine("Session = S1");
                            break;
                        case "02":
                            sb.AppendLine("Session = S2");
                            break;
                        case "03":
                            sb.AppendLine("Session = S3");
                            break;
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "30":
                    sb.Clear();

                    sb.AppendLine("Get Frequency Hopping Table");
                    
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "31":
                    sb.Clear();

                    sb.AppendLine("Set Frequency Hopping Table");

                    sb.Append("Table Size = ");
                    val = Convert.ToByte(s[7], 16);
                    sb.AppendLine(val.ToString());

                    sb.Append("Channel Numbers = ");
                    for (int i = 0; i < val; i++)
                    {
                        sb.Append(Convert.ToByte(s[8 + i],16) +" ");
                    }
                    sb.Append("\r\n");

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "32":
                    sb.Clear();

                    sb.AppendLine("Get Modulation Mode");
                    Result = sb.ToString();

                    sb.Clear();
                    break;

                case "33":
                    sb.Clear();

                    sb.AppendLine("Set Modulation Mode");


                    if (s[7] == "FF")
                    {
                        sb.Append("BLF = ");
                        sb.Append(((Convert.ToByte(s[8], 16) << 8) + (Convert.ToByte(s[9], 16))).ToString());
                        sb.AppendLine(" [kHz]");

                        if (s[10] == "00")
                        {
                            sb.AppendLine("Modulation Mode = FM0");
                        }
                        else if (s[10] == "01")
                        {
                            sb.AppendLine("Modulation Mode = M2");
                        }
                        else if (s[10] == "02")
                        {
                            sb.AppendLine("Modulation Mode = M4");
                        }
                        else if (s[10] == "03")
                        {
                            sb.AppendLine("Modulation Mode = M8");
                        }

                        if (s[11] == "00")
                        {
                            sb.AppendLine("DR = 8");
                        }
                        else
                        {
                            sb.AppendLine("DR = 64/3");
                        }
                    }

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "34":
                    sb.Clear();
                    sb.AppendLine("Get Anti-Collision Mode");
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "35":
                    sb.Clear();
                    sb.AppendLine("Set Anti-Collision Mode");

                    sb.Append("Anti Collision Mode = ");
                    sb.AppendLine(int.Parse(s[7]).ToString());

                    sb.Append("Start Q Value = ");
                    sb.AppendLine(int.Parse(s[8]).ToString());

                    sb.Append("Maximum Q Value = ");
                    sb.AppendLine(int.Parse(s[9]).ToString());

                    sb.Append("Minimum Q Value = ");
                    sb.AppendLine(int.Parse(s[10]).ToString());

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "36":
                    sb.Clear();
                    sb.AppendLine("Start Auto Read2");
                    
                    sb.Append("Tag Type = ");                   
                    if (s[7] == "01")
                    {
                        sb.AppendLine("type B Tag");
                    }
                    else
                    {
                        sb.AppendLine("type C Tag");
                    }

                    if (s[8] != "00")
                    {
                        sb.Append("Maximum number of tag to read = ");
                        sb.AppendLine(Convert.ToByte(s[8],16).ToString());
                    }

                    if (s[9] != "00")
                    {
                        sb.Append("Maximum elapsed time to tagging (sec) = ");
                        sb.AppendLine(Convert.ToByte(s[9], 16).ToString());
                    }

                    sb.Append("Repeat Cycle = ");
                    val = (Convert.ToByte(s[10], 16) << 8) + Convert.ToByte(s[11], 16);
                    if (val == 0)
                    {
                        sb.AppendLine(" Continuous mode");
                    }
                    else
                    {
                        sb.AppendLine(val.ToString());
                    }

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "37":
                    sb.Clear();
                    sb.AppendLine("Stop Auto Read2");
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "38":
                    sb.Clear();
                    sb.AppendLine("Start Auto Read with Tag RSSI");
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "46":
                    sb.Clear();
                    sb.AppendLine("Write Type C Tag Data");

                    sb.Append("Access Password = ");
                    sb.AppendLine(s[7]+s[8]+s[9]+s[10]);

                    sb.Append("Target tag's EPC length = ");
                    val = (Convert.ToByte(s[11], 16) << 8) + Convert.ToByte(s[12], 16);
                    sb.AppendLine(val.ToString());

                    sb.Append("Target tag's EPC = ");
                    for (int i = 0; i < val; i++)
                    {
                        sb.Append(s[13+i]+" ");
                        if (i == (val-1))
                        {
                            sb.Append("\r\nTarget Memory bank = ");
                            if (s[13 + val] == "00")
                            {
                                sb.AppendLine("RFU");
                            }
                            else if (s[13 + val] == "01")
                            {
                                sb.AppendLine("EPC");
                            }
                            else if (s[13 + val] == "02")
                            {
                                sb.AppendLine("TID");
                            }
                            else if (s[13 + val] == "03")
                            {
                                sb.AppendLine("User");
                            }

                            sb.Append("Starting Address word pointer = ");
                            sb.AppendLine(((Convert.ToByte(s[14 + val], 16) << 8) + Convert.ToByte(s[15 + val], 16)).ToString());

                            sb.Append("Data length(Word Count) = ");
                            sb.AppendLine(((Convert.ToByte(s[16 + val], 16) << 8) + Convert.ToByte(s[17 + val], 16)).ToString());

                            sb.Append("Data to Write = ");
                            int val_2;
                            val_2 = (Convert.ToByte(s[16 + val], 16) << 8) + Convert.ToByte(s[17 + val], 16);
                            for (int j = 0; j < (val_2 * 2); j++)
                            {
                                sb.Append(s[18 +j + val] + " ");
                            }
                            sb.Append("\r\n");
                        }
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "47":
                    sb.Clear();
                    sb.AppendLine("BlockWrite Type C Tag Data");

                    sb.Append("Access Password = ");
                    sb.AppendLine(s[7]+s[8]+s[9]+s[10]);

                    sb.Append("Target tag's EPC length = ");
                    val = (Convert.ToByte(s[11], 16) << 8) + Convert.ToByte(s[12], 16);
                    sb.AppendLine(val.ToString());

                    sb.Append("Target tag's EPC = ");
                    for (int i = 0; i < val; i++)
                    {
                        sb.Append(s[13+i]+" ");
                        if (i == (val-1))
                        {
                            sb.Append("\r\nTarget Memory bank = ");
                            if (s[13 + val] == "00")
                            {
                                sb.AppendLine("RFU");
                            }
                            else if (s[13 + val] == "01")
                            {
                                sb.AppendLine("EPC");
                            }
                            else if (s[13 + val] == "02")
                            {
                                sb.AppendLine("TID");
                            }
                            else if (s[13 + val] == "03")
                            {
                                sb.AppendLine("User");
                            }

                            sb.Append("Starting Address word pointer = ");
                            sb.AppendLine(((Convert.ToByte(s[14 + val], 16) << 8) + Convert.ToByte(s[15 + val], 16)).ToString());

                            sb.Append("Data length(Word Count) = ");
                            sb.AppendLine(((Convert.ToByte(s[16 + val], 16) << 8) + Convert.ToByte(s[17 + val], 16)).ToString());

                            sb.Append("Data to Write = ");
                            int val_2;
                            val_2 = (Convert.ToByte(s[16 + val], 16) << 8) + Convert.ToByte(s[17 + val], 16);
                            for (int j = 0; j < (val_2 * 2); j++)
                            {
                                sb.Append(s[18 +j + val] + " ");
                            }
                            sb.Append("\r\n");
                        }
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "48":
                    sb.Clear();
                    sb.AppendLine("BlockErase Type C Tag Data");

                    sb.Append("Access Password = ");
                    sb.AppendLine(s[7]+s[8]+s[9]+s[10]);

                    sb.Append("Target tag's EPC length = ");
                    val = (Convert.ToByte(s[11], 16) << 8) + Convert.ToByte(s[12], 16);
                    sb.AppendLine(val.ToString());

                    sb.Append("Target tag's EPC = ");
                    for (int i = 0; i < val; i++)
                    {
                        sb.Append(s[13+i]+" ");
                        if (i == (val-1))
                        {
                            sb.Append("\r\nTarget Memory bank = ");
                            if (s[13 + val] == "00")
                            {
                                sb.AppendLine("RFU");
                            }
                            else if (s[13 + val] == "01")
                            {
                                sb.AppendLine("EPC");
                            }
                            else if (s[13 + val] == "02")
                            {
                                sb.AppendLine("TID");
                            }
                            else if (s[13 + val] == "03")
                            {
                                sb.AppendLine("User");
                            }

                            sb.Append("Starting Address word pointer = ");
                            sb.AppendLine(((Convert.ToByte(s[14 + val], 16) << 8) + Convert.ToByte(s[15 + val], 16)).ToString());

                            sb.Append("Data length(Word Count) = ");
                            sb.AppendLine(((Convert.ToByte(s[16 + val], 16) << 8) + Convert.ToByte(s[17 + val], 16)).ToString());
                        }
                    }

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "83":
                    sb.Clear();
                    sb.AppendLine("BlockPermalock Type C Tag");

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "65":
                    sb.Clear();
                    sb.AppendLine("Kill/Recom Type C Tag");

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "82":
                    sb.Clear();
                    sb.AppendLine("Lock Type C Tag Data");

                    sb.Append("Access Password = ");
                    sb.AppendLine(s[7]+s[8]+s[9]+s[10]);

                    sb.Append("Target tag's EPC length = ");
                    val = (Convert.ToByte(s[11], 16) << 8) + Convert.ToByte(s[12], 16);
                    sb.AppendLine(val.ToString());

                    sb.Append("Target tag's EPC = ");
                    for (int i = 0; i < val; i++)
                    {
                        sb.Append(s[13+i]+" ");
                        if (i == (val-1))
                        {
                            sb.Append("\r\n");
                            sb.Append("Lock mask and action flag = ");
                            sb.Append(s[13 + val] + " ");
                            sb.Append(s[14 + val] + " ");
                            sb.Append(s[15 + val] + " ");
                            sb.Append("\r\n");
                        }
                    }

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "AC":
                    sb.Clear();

                    sb.AppendLine("Check Antenna Connection");
                    
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "B7":
                    sb.Clear();

                    sb.AppendLine("Get Temperature");
                    Result = sb.ToString();

                    sb.Clear();
                    break;

                case "C5":
                    sb.Clear();

                    sb.AppendLine("Get RSSI Level");
                    Result = sb.ToString();

                    sb.Clear();
                    break;

                case "C6":
                    sb.Clear();

                    sb.AppendLine("Scan RSSI");
                    Result = sb.ToString();

                    sb.Clear();
                    break;

                case "D2":
                    sb.Clear();
                    sb.AppendLine("Update Registry");

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "D3":
                    sb.Clear();
                    sb.AppendLine("Erase Registry");

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "D4":
                    sb.Clear();
                    sb.Append("Get Registry Item : ");
                    val = (Convert.ToByte(s[7], 16) << 8) + Convert.ToByte(s[8], 16);

                    if (val == 0)
                    {
                        sb.AppendLine("Registry Version");
                    }
                    else if (val == 1)
                    {
                        sb.AppendLine("Firmware Date");
                    }
                    else if (val == 2)
                    {
                        sb.AppendLine("Band");
                    }
                    else if (val == 3)
                    {
                        sb.AppendLine("Tx Power");
                    }
                    else if (val == 4)
                    {
                        sb.AppendLine("FH/LBT");
                    }
                    else if (val == 5)
                    {
                        sb.AppendLine("Anti-collision Mode");
                    }
                    else if (val == 6)
                    {
                        sb.AppendLine("Modulation Mode");
                    }
                    else if (val == 7)
                    {
                        sb.AppendLine("Query");
                    }
                    else if (val == 8)
                    {
                        sb.AppendLine("Frequency Hopping Table");
                    }
                    else if (val == 9)
                    {
                        sb.AppendLine("Tx Power Table");
                    }
                    else
                    {
                        sb.AppendLine("Restricted Item");
                    }

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "E4":
                    sb.Clear();
                    sb.AppendLine("Set Optimimum Frequency Hopping Table");

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "E5":
                    sb.Clear();
                    sb.AppendLine("Get Frequency Hopping Mode");                    
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "E6":
                    sb.Clear();
                    sb.AppendLine("Set Frequency Hopping Mode");

                    if (s[7] == "01")
                    {
                        sb.AppendLine("Optimized Frequency Hopping");
                    }
                    else
                    {
                        sb.AppendLine("Normal Frequency Hopping");
                    }
                    
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "E7":
                    sb.Clear();
                    sb.AppendLine("Get Frequency Hopping Ref. Level");
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "E8":
                    sb.Clear();
                    sb.AppendLine("Set Frequency Hopping Ref. Level");
                    sb.AppendLine("Ref. Level = " + Convert.ToByte(s[7], 16));
                    
                    Result = sb.ToString();
                    sb.Clear();
                    break;
            }
            if (Result != "")
            {
                return "CMD > " + Result;
            }
            else
            {
                return "";
            }
        }

        private static string RSPDecoder(string[] s)
        {
            int val;
            float val_f = 0;

            StringBuilder sb = new StringBuilder();
            sb.Clear();

            string Result = "";

            switch (s[4])
            {
                case "01":
                    sb.Clear();
                    sb.Append("Reader Power Control : ");
                    if (s[7] == "00")
                    {
                        sb.AppendLine("Success");
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "03":
                    sb.Clear();
                    sb.Append("Get Reader Information : ");
                    val = (Convert.ToByte(s[5], 16) << 8) + Convert.ToByte(s[6], 16);

                    if (s[7] == "B0")
                    {
                        sb.AppendLine("");

                        int startIndex = 7;
                        sb.Append("Region : ");

                        switch (s[startIndex + 1])
                        {
                            case "11":
                                sb.AppendLine("Korea");
                                break;
                            case "21":
                                sb.AppendLine("NA");
                                break;
                            case "22":
                                sb.AppendLine("US");
                                break;
                            case "31":
                                sb.AppendLine("Europe");
                                break;
                            case "41":
                                sb.AppendLine("Japan");
                                break;
                            case "51":
                                sb.AppendLine("China1");
                                break;
                            case "52":
                                sb.AppendLine("China");
                                break;
                        }

                        sb.Append("Channel : ");
                        sb.AppendLine(Convert.ToInt32(s[startIndex + 2],16).ToString());

                        sb.Append("Read Time : ");
                        sb.Append(((Convert.ToUInt16(s[startIndex + 3], 16) << 8) | (Convert.ToUInt16(s[startIndex + 4],16))).ToString());
                        sb.AppendLine(" [ms]");

                        sb.Append("Idle Time : ");
                        sb.Append(((Convert.ToUInt16(s[startIndex + 5], 16) << 8) | (Convert.ToUInt16(s[startIndex + 6], 16))).ToString());
                        sb.AppendLine(" [ms]");

                        sb.Append("CW Sense Time : ");
                        sb.Append(((Convert.ToUInt16(s[startIndex + 7], 16) << 8) | (Convert.ToUInt16(s[startIndex + 8], 16))).ToString());
                        sb.AppendLine(" [ms]");
                                                 
                        sb.Append("LBT RF Level : ");
                        sb.Append((((float)((Int16)((Convert.ToByte(s[startIndex + 9], 16) << 8) | (Convert.ToByte(s[startIndex + 10], 16))))) / (float)10).ToString("N1"));
                        sb.AppendLine(" [dBm]");                                                                                                                                               

                        sb.Append("Current Setted RF Tx Power : ");
                        sb.Append(((float)((Convert.ToUInt16(s[startIndex + 14], 16) << 8) | (Convert.ToUInt16(s[startIndex + 15], 16))) / (float)10).ToString("N1"));
                        sb.AppendLine(" [dBm]");

                        sb.Append("Minimum RF Tx Power : ");
                        sb.Append(((float)((Convert.ToUInt16(s[startIndex + 16], 16) << 8) | (Convert.ToUInt16(s[startIndex + 17], 16))) / (float)10).ToString("N1"));
                        sb.AppendLine(" [dBm]");

                        sb.Append("Maximum RF Tx Power : ");
                        sb.Append(((float)((Convert.ToUInt16(s[startIndex + 18], 16) << 8) | (Convert.ToUInt16(s[startIndex + 19], 16))) / (float)10).ToString("N1"));
                        sb.AppendLine(" [dBm]");

                        sb.Append("BLF : ");
                        sb.Append(((Convert.ToUInt16(s[startIndex + 20], 16) << 8) | (Convert.ToUInt16(s[startIndex + 21], 16))).ToString());
                        sb.AppendLine(" [kHz]");                        

                        sb.Append("Modulation : ");
                        switch(s[startIndex + 22])
                        {
                            case "00":
                                sb.AppendLine("FM0");
                                break;
                            case "01":
                                sb.AppendLine("M2");
                                break;
                            case "02":
                                sb.AppendLine("M4");
                                break;
                            case "03":
                                sb.AppendLine("M8");
                                break;
                        }

                        sb.Append("DR : ");
                        switch(s[startIndex + 23])
                        {
                            case "00":
                                sb.AppendLine(" 8");
                                break;
                            case "01":
                                sb.AppendLine(" 64/3");
                                break;
                        }

                        sb.Append("Session : ");
                        switch (s[startIndex + 24])
                        {
                            case "F0":
                                sb.AppendLine("Dev.mode");
                                break;
                            case "00":
                                sb.AppendLine("S0");
                                break;
                            case "01":
                                sb.AppendLine("S1");
                                break;
                            case "02":
                                sb.AppendLine("S2");
                                break;
                            case "03":
                                sb.AppendLine("S3");
                                break;
                        }                        
                    }
                    else
                    {
                        sb.AppendLine(s[val + 10]);
                    }                                        
                    
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "06":
                    sb.Clear();
                    sb.AppendLine("Get Region : Success");
                    if (s[7] == "11")
                    {
                        sb.AppendLine("Korea");
                    }
                    else if (s[7] == "21")
                    {
                        sb.AppendLine("US");
                    }
                    else if (s[7] == "22")
                    {
                        sb.AppendLine("US2");
                    }
                    else if (s[7] == "31")
                    {
                        sb.AppendLine("Europe");
                    }
                    else if (s[7] == "41")
                    {
                        sb.AppendLine("Japan");
                    }
                    else if (s[7] == "51")
                    {
                        sb.AppendLine("China1");
                    }
                    else if (s[7] == "52")
                    {
                        sb.AppendLine("China2");
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "07":
                    sb.Clear();
                    if (s[7] == "00")
                    {
                        sb.Append("Set Region : Success");
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "08":
                    sb.Clear();
                    if (s[7] == "00")
                    {
                        sb.Append("Set System Reset : Success");
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "0B":
                    sb.Clear();
                    sb.AppendLine("Get Type C A/I Select Parameter : Success");
                    sb.Append("Target = ");

                    val = Convert.ToInt32(s[7],16);
                    if ((val >> 5) == 0)
                    {
                        sb.AppendLine("S0");
                    }
                    else if ((val >> 5) == 1)
                    {
                        sb.AppendLine("S1");
                    }
                    else if ((val >> 5) == 2)
                    {
                        sb.AppendLine("S2");
                    }
                    else if ((val >> 5) == 3)
                    {
                        sb.AppendLine("S3");
                    }
                    else if ((val >> 5) == 4)
                    {
                        sb.AppendLine("SL");
                    }
                    
                    sb.Append("Action = ");
                    sb.AppendLine( ((val >> 2) & 7).ToString());

                    sb.Append("MemoryBank = ");
                    if ( (val & 3) == 0)
                    {
                        sb.AppendLine("RFU");
                    }
                    else if ((val & 3) == 1)
                    {
                        sb.AppendLine("EPC");
                    }
                    else if ((val & 3) == 2)
                    {
                        sb.AppendLine("TID");
                    }
                    else if ((val & 3) == 3)
                    {
                        sb.AppendLine("USER");
                    }

                    sb.Append("Pointer = ");
                    sb.AppendLine(s[8]+s[9]+s[10]+s[11]);

                    sb.Append("Length = ");
                    val = Convert.ToInt32(s[12], 16);
                    sb.AppendLine(val.ToString());

                    sb.Append("Truncate = ");
                    val = (Convert.ToByte(s[13], 16) >> 7);
                    if (val == 1)
                    {
                        sb.AppendLine("Enabled");
                    }
                    else if (val == 0)
                    {
                        sb.AppendLine("Disabled");
                    }

                    sb.Append("Reserve = ");
                    val = (Convert.ToByte(s[13], 16) & 127);
                    sb.AppendLine(val.ToString());

                    sb.Append("Mask = ");
                    val = (Convert.ToByte(s[5], 16) << 8) + Convert.ToByte(s[6], 16) - 7;

                    for (int i = 0; i < val; i++)
                    {
                        sb.Append(s[14+i]);    
                    }
                    sb.Append("\r\n");
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "0C":
                    sb.Clear();
                    if (s[7] == "00")
                    {
                        sb.Append("Set Type C A/I Select Parameters : Success");
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "0D":
                    sb.Clear();
                    sb.AppendLine("Get Type C A/I Query Parameter : Success");
                    
                    val = Convert.ToByte(s[7], 16);
                    sb.Append("DR = ");
                    if ((val>>7) == 1)
	                {
                        sb.AppendLine("64/3");
	                }
                    else if ((val >> 7) == 0)
                    {
                        sb.AppendLine("8");
                    }

                    sb.Append("M = ");
                    if (((val >> 5) & 3) == 0) 
                    {
                        sb.AppendLine("1");
                    }
                    else if (((val >> 5) & 3) == 1)
                    {
                        sb.AppendLine("2");
                    }
                    else if (((val >> 5) & 3) == 2)
                    {
                        sb.AppendLine("4");
                    }
                    else if (((val >> 5) & 3) == 3)
                    {
                        sb.AppendLine("8");
                    }

                    sb.Append("TRext = ");
                    if (((val >> 4) & 1) == 0)
                    {
                        sb.AppendLine("No pilot tone");
                    }
                    else if (((val >> 4) & 1) == 1)
                    {
                        sb.AppendLine("Use pilot tone");
                    }

                    sb.Append("Sel = ");
                    if (((val >> 2) & 3) == 2)
                    {
                        sb.AppendLine("~SL");
                    }
                    else if (((val >> 2) & 3) == 3)
                    {
                        sb.AppendLine("SL");
                    }
                    else
                    {
                        sb.AppendLine("All");
                    }

                    sb.Append("Session = ");
                    if (((val) & 3) == 0)
                    {
                        sb.AppendLine("S0");
                    }
                    else if (((val) & 3) == 1)
                    {
                        sb.AppendLine("S1");
                    }
                    else if (((val) & 3) == 2)
                    {
                        sb.AppendLine("S2");
                    }
                    else if (((val) & 3) == 3)
                    {
                        sb.AppendLine("S3");
                    }

                    val = Convert.ToByte(s[8], 16);

                    sb.Append("Target = ");
                    if (((val >> 7) & 1) == 0)
                    {
                        sb.AppendLine("A");
                    }
                    else if (((val >> 7) & 1) == 1)
                    {
                        sb.AppendLine("B");
                    }

                    sb.Append("Q = ");
                    sb.AppendLine(((val >> 3) & 15).ToString());
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "0E":
                    sb.Clear();
                    if (s[7] == "00")
                    {
                        sb.Append("Set Type C A/I Query Parameters : Success");
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "11":
                    sb.Clear();
                    sb.AppendLine("Get current RF Channel : Success");
                    sb.AppendLine("Channel Number = " + Convert.ToByte(s[7], 16));
                    sb.AppendLine("Channel Offset = " + Convert.ToByte(s[8], 16));
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "12":
                    sb.Clear();
                    if (s[7] == "00")
                    {
                        sb.Append("Set current RF Channel : Success");
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "13":
                    sb.Clear();
                    sb.AppendLine("Get FH and LBT Parameters : Success");
           
                    val = (Convert.ToByte(s[7], 16) << 8) + Convert.ToByte(s[8], 16);
                    sb.Append("Read Time = ");
                    sb.AppendLine(val.ToString() + " [ms]");

                    val = (Convert.ToByte(s[9], 16) << 8) + Convert.ToByte(s[10], 16);
                    sb.Append("Idle Time = ");
                    sb.AppendLine(val.ToString() + " [ms]");

                    val = (Convert.ToByte(s[11], 16) << 8) + Convert.ToByte(s[12], 16);
                    sb.Append("CW Sense Time = ");
                    sb.AppendLine(val.ToString() + " [ms]");

                    val = (Convert.ToByte(s[13],16) << 8) + Convert.ToByte(s[14],16);
                    val_f = (float)((Int16)val) / 10;
                    sb.Append("LBT RF Level = ");
                    sb.AppendLine(val_f.ToString()+" [dBm]");

                    if (s[15] == "01" && s[16] == "00" && s[17] == "00")
                    {
                        sb.AppendLine("Frequency Hopping(Only) Enable");
                    }
                    else if (s[15] == "00" && s[16] == "01" && s[17] == "00")
                    {
                        sb.AppendLine("LBT(Only) Enable");
                    }
                    else if (s[15] == "02" && s[16] == "01" && s[17] == "00")
                    {
                        sb.AppendLine("Frequency Hopping(with LBT) Enable");
                    }
                    else if (s[15] == "01" && s[16] == "02" && s[17] == "00")
                    {
                        sb.AppendLine("LBT(with FH) Enable");
                    }

                    Result = sb.ToString();

                    sb.Clear();
                    break;

                case "14":
                    sb.Clear();
                    if (s[7] == "00")
                    {
                        sb.AppendLine("Set FH and LBT Parameters : Success");
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "15":
                    sb.Clear();
                    sb.AppendLine("Get Tx Power Level");
                    val = (Convert.ToByte(s[7], 16) << 8) + Convert.ToByte(s[8], 16);
                    val_f = (float)val / 10;
                    sb.AppendLine(val_f.ToString() + " [dBm]");
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "16":
                    sb.Clear();
                    if (s[7] == "00")
                    {
                        sb.Append("Set Tx Power Level : Success");
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "17":
                    sb.Clear();
                    if (s[7] == "00")
                    {
                        sb.Append("RF CW signal control : Success");
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "1B":
                     sb.Clear();

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "22":
                    sb.Clear();
                    sb.AppendLine("Read Type C UII");
                    
                    sb.Append("PC : ");
                    sb.AppendLine(s[7] + s[8]);

                    sb.Append("EPC : ");
                    val = (Convert.ToByte(s[5], 16) << 8) + Convert.ToByte(s[6], 16);

                    for (int i = 0; i < val; i++)
                    {
                        sb.Append(s[9 + i] + " ");
                    }
                    sb.Append("\r\n");

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "25":
                    sb.Clear();

                    sb.AppendLine("Read Type C UII TID : Success");
                    Result = sb.ToString();

                    sb.Clear();
                    break;

                case "27":
                    sb.Clear();
                    if (s[7] == "00")
                    {
                        sb.Append("Start Auto Read : Success");
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "28":
                    sb.Clear();
                    if (s[7] == "00")
                    {
                        sb.Append("Stop Auto Read : Success");
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "29":
                    sb.Clear();
                    sb.AppendLine("Read Type C Tag Data : Success");
                    
                    sb.Append("Target Memory Value = ");

                    val = (Convert.ToByte(s[5], 16) << 8) + Convert.ToByte(s[6], 16);
                    
                    for (int i = 0; i < val; i++)
                    {
                        sb.Append(s[7 + i] + " ");
                    }
                    sb.Append("\r\n");

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "2A":
                    sb.Clear();
                    if (s[3].Equals("01"))
                    {
                        sb.AppendLine("Read Type C Tag Data (Long) : Success");
                        sb.Append("Target Memory Value = ");
                    }
                    else
                    {
                        val = (Convert.ToByte(s[5], 16) << 8) + Convert.ToByte(s[6], 16);

                        for (int i = 0; i < val; i++)
                        {
                            sb.Append(s[7 + i] + " ");
                        }
                    }

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "2E":
                    sb.Clear();
                    sb.AppendLine("Get Session");
                    switch (s[7])
                    {
                        case "F0":
                            sb.AppendLine("Session = Dev.mode");
                            break;
                        case "00":
                            sb.AppendLine("Session = S0");
                            break;
                        case "01":
                            sb.AppendLine("Session = S1");
                            break;
                        case "02":
                            sb.AppendLine("Session = S2");
                            break;
                        case "03":
                            sb.AppendLine("Session = S3");
                            break;
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "2F":
                    sb.Clear();
                    sb.AppendLine("Set Session : Success");
                    Result = sb.ToString();
                    sb.Clear();
                    break;
                case "30":
                    sb.Clear();

                    sb.AppendLine("Get Frequency Hopping Table");

                    sb.Append("Table Size = ");
                    val = Convert.ToByte(s[7], 16);
                    sb.AppendLine(val.ToString());

                    sb.Append("Channel Numbers = ");
                    for (int i = 0; i < val; i++)
                    {
                        sb.Append(Convert.ToByte(s[8 + i],16) +" ");
                    }
                    sb.Append("\r\n");

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "31":
                    sb.Clear();
                    if (s[7] == "00")
                    {
                        sb.Append("Set Frequency Hopping Table");
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "32":
                    sb.Clear();
                    sb.AppendLine("Get Modulation Mode : Success");

                    sb.Append("BLF = ");
                    sb.Append(((Convert.ToByte(s[7], 16) << 8) + (Convert.ToByte(s[8], 16))).ToString());
                    sb.AppendLine(" [kHz]");

                    if (s[9] == "00")
                    {
                        sb.AppendLine("Modulation Mode = FM0");
                    }
                    else if (s[9] == "01")
                    {
                        sb.AppendLine("Modulation Mode = M2");
                    }
                    else if (s[9] == "02")
                    {
                        sb.AppendLine("Modulation Mode = M4");
                    }
                    else if (s[9] == "03")
                    {
                        sb.AppendLine("Modulation Mode = M8");
                    }

                    if (s[10] == "00")
                    {
                        sb.AppendLine("DR = 8");
                    }
                    else
                    {
                        sb.AppendLine("DR = 64/3");
                    }    
                    
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "33":
                    sb.Clear();
                    if (s[7] == "00")
                    {
                        sb.AppendLine("Set Modulation Mode : Success");
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "34":
                    try
                    {
                        sb.Clear();
                        sb.AppendLine("Get Anti-Collision Mode");

                        sb.Append("Anti Collision Mode = ");
                        sb.AppendLine(int.Parse(s[7]).ToString());

                        sb.Append("Start Q Value = ");
                        sb.AppendLine(int.Parse(s[8]).ToString());

                        sb.Append("Maximum Q Value = ");
                        sb.AppendLine(int.Parse(s[9]).ToString());

                        sb.Append("Minimum Q Value = ");
                        sb.AppendLine(int.Parse(s[10]).ToString());

                        Result = sb.ToString();
                        sb.Clear();
                    }
                    catch {

                    }
                    break;

                case "35":
                    sb.Clear();
                    if (s[7] == "00")
                    {
                        sb.AppendLine("Set Anti-Collision Mode : Success");
                    }
                    
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "36":
                    sb.Clear();
                    if (s[7] == "00")
                    {
                        sb.AppendLine("Start Auto Read2 : Success");
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "37":
                    sb.Clear();
                    if (s[7] == "00")
                    {
                        sb.AppendLine("Stop Auto Read2 : Success");
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "38":
                    sb.Clear();
                    if (s[7] == "00")
                    {
                        sb.AppendLine("Start Auto Read with Tag RSSI : Success");
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "46":
                    sb.Clear();
                    if (s[7] == "00")
                    {
                        sb.AppendLine("Write Type C Tag Data : Success");
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "47":
                    sb.Clear();
                    if (s[7] == "00")
                    {
                        sb.Append("BlockWrite Type C Tag Data : Success");
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "48":
                    sb.Clear();
                    if (s[7] == "00")
                    {
                        sb.Append("BlockErase Type C Tag Data : Success");
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "83":
                    sb.Clear();
                    if (s[7] == "00")
                    {
                        sb.Append("BlockPermalock Type C Tag : Success");
                    }
                    else if ( (s[5] == "00") && s[6] == "00")
                    {
                        sb.Append("BlockPermalock Type C Tag : Success");
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "65":
                    sb.Clear();
                    if (s[7] == "00")
                    {
                        sb.Append("Kill/Recom Type C Tag : Success");
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "82":
                    sb.Clear();
                    if (s[7] == "00")
                    {
                        sb.Append("Lock Type C Tag Data : Success");
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "AC":
                    sb.Clear();                    

                    if (s[7] == "00")
                    {
                        sb.AppendLine("Antenna Connection Status: Normal");
                    }
                    else
                    {

                    }

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "B7":
                    sb.Clear();
                    sb.AppendLine("Get Temperature : Success");
                    sb.Append("Temperature = ");
                    sb.Append(Convert.ToByte(s[7], 16).ToString());
                    sb.AppendLine(" 'C");
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "C5":
                    sb.Clear();
                    sb.AppendLine("Get RSSI : Success");
                    sb.Append("RSSI Value = ");
                    val = (Convert.ToByte(s[7], 16) << 8) + Convert.ToByte(s[8], 16);

                    val_f = (float)((Int16)val);
                    val_f /= 10;
                    sb.Append("-");
                    sb.Append(val_f.ToString());
                    sb.AppendLine(" [dBm]");
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "C6":
                    sb.Clear();
                    sb.AppendLine("Scan RSSI : Success");
                    
                    sb.Append("Start Channel = Ch ");
                    sb.AppendLine(Convert.ToByte(s[7], 16).ToString());

                    sb.Append("Stop Channel = Ch ");
                    sb.AppendLine(Convert.ToByte(s[8], 16).ToString());

                    sb.Append("Best Channel = Ch ");
                    sb.AppendLine(Convert.ToByte(s[9], 16).ToString());

                    val = (Convert.ToByte(s[5], 16) << 8) + Convert.ToByte(s[6], 16);

                    for (int i = 0; i < val-3; i++)
                    {
                        sb.AppendLine("RSSI" + (Convert.ToByte(s[7], 16) + i).ToString() + " = " + "-"+Convert.ToByte(s[10+i],16).ToString() + " [dBm]");
                    }

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "D2":
                    sb.Clear();
                    if (s[7] == "00")
                    {
                        sb.Append("Update Registry : Success");
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "D3":
                    sb.Clear();
                    if (s[7] == "00")
                    {
                        sb.Append("Erase Registry : Success");
                    }
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "D4":
                    sb.Clear();
                    sb.AppendLine("Get Registry Item : Success");

                    sb.Append("Registry item status = ");
                    if (s[7] == "00")
                    {
                        sb.AppendLine("Inactive");
                    }
                    else if (s[7] == "BC")
                    {
                        sb.AppendLine("Read-Only");
                    }
                    else if (s[7] == "A5")
                    {
                        sb.AppendLine("Active");
                    }

                    sb.Append("Data(Hex) = ");
                    val = (Convert.ToByte(s[5], 16) << 8) + Convert.ToByte(s[6], 16);
                    for (int i = 0; i < val-1; i++)
                    {
                        sb.Append(s[8+i] + " ");
                    }
                    sb.Append("\r\n");
                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "E4":
                    sb.Clear();
                    sb.AppendLine("Set Optimimum Frequency Hopping Table : Sucess");

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "E5":
                    sb.Clear();
                    sb.AppendLine("Get Frequency Hopping Mode : Success");

                    if (s[7] == "01")
                    {
                        sb.AppendLine("Optimized Frequency Hopping");
                    }
                    else
                    {
                        sb.AppendLine("Normal Frequency Hopping");
                    }

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "E6":
                    sb.Clear();
                    sb.AppendLine("Set Frequency Hopping Mode : Success");

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "E7":
                    sb.Clear();
                    sb.AppendLine("Get Frequency Hopping Ref. Level");
                    sb.AppendLine(Convert.ToByte(s[7], 16).ToString());

                    Result = sb.ToString();
                    sb.Clear();
                    break;

                case "E8":
                    sb.Clear();
                    sb.AppendLine("Set Frequency Hopping Ref. Level :  Success");                    

                    Result = sb.ToString();
                    sb.Clear();
                    break;
            }
            if (Result != "")
            {
                Result += "\r\n";
                return "RSP > " + Result;    
            }
            else
            {
                return "";
            }
        }

        public static Hashtable htCommand = new Hashtable()
        {
            {"01", "Set Reader Power Control"},
            {"03", "Get Reader Information"},
            {"06", "Get Region"},
            {"07", "Set Region"},
            {"08", "Set System Reset"},
            {"0B", "Get Type C A/I Select Parameters"},
            {"0C", "Set Type C A/I Select Parameters"},
            {"0D", "Get Type C A/I Query Related Parameters"},
            {"0E", "Set Type C A/I Query Related Parameters"},
            {"11", "Get Current RF Channel"},
            {"12", "Set Current RF Channel"},
            {"13", "Get FH and LBT Parameters"},
            {"14", "Set FH and LBT Parameters"},
            {"15", "Get Tx Power Level"},
            {"16", "Set Tx Power Level"},
            {"17", "RF CW Signal Control"},
            {"1B", "Set Antenna"},
            {"22", "Read Type C UII"},
            {"23", "Read Type C UII RSSI"},
            {"24", "Read Type C User Data"},
            {"25", "Read Type C UII TID"},
            {"27", "Start Auto Read"},
            {"28", "Stop Auto Read"},
            {"29", "Read Type C Tag Data"},
            {"2A", "Read Type C Tag Data2"},
            {"2E", "Get Session"},
            {"2F", "Set Session"},
            {"30", "Get Frequency Hopping Table"},
            {"31", "Set Frequency Hopping Table"},
            {"32", "Get Modulation"},
            {"33", "Set Modulation"},
            {"34", "Get Anti-Collision Mode"},
            {"35", "Set Anti-Collision Mode"},
            {"36", "Start Auto Read2"},
            {"37", "Stop Auto Read2"},
            {"38", "Start Auto Read RSSI"},
            {"39", "Stop Auto Read RSSI"},
            {"3A", "Start Auto Read Ex2"},
            {"46", "Write Type C Tag Data"},
            {"47", "BlockWrite Type C Tag Data"},
            {"48", "BlockErase Type C Tag Data"},
            {"52", "NXP ReadProtect"},
            {"53", "NXP Reset ReadProtect"},
            {"54", "NXP Change EAS"},
            {"55", "NXP EAS Alarm"},
            {"56", "NXP Calibrate"},
            {"57", "ISP Data"},
            {"65", "Kill/Recom Type C Tag"},
            {"82", "Lock Type C Tag"},
            {"83", "BlockPermalock Type C Tag"},
            {"A6", "Set Modem Register"},
            {"A7", "Set RF Register"},
            {"A8", "Get Modem Register"},
            {"A9", "Get RF Register"},
            {"B1", "ISP Download"},
            {"B3", "ISP Dump"},
            {"B4", "Set Antenna Path"},
            {"B5", "Set Leakage Cal. Mode"},
            {"B6", "Get IAP Version"},
            {"B7", "Get Temperature"},
            {"C5", "Get RSSI"},
            {"C6", "Scan RSSI"},
            {"D2", "Update Registry"},
            {"D3", "Erase Registry"},
            {"D4", "Get Registry Item"},
            {"D5", "Set Registry Item"},            
        };

        public static Hashtable htFailure = new Hashtable()
        {
            {"00", "EPC G2v2 Error Message : Other error"},
            {"01", "EPC G2v2 Error Message : Not supported"},
            {"02", "EPC G2v2 Error Message : Insufficient privileges"},
            {"03", "EPC G2v2 Error Message : Memory overrun"},
            {"04", "EPC G2v2 Error Message : Memory locked"},
            {"05", "EPC G2v2 Error Message : Crypto suite error"},
            {"06", "EPC G2v2 Error Message : Command not encapsulated"},
            {"07", "EPC G2v2 Error Message : ResponseBuffer overflow"},
            {"08", "EPC G2v2 Error Message : Security timeout"},
            {"0B", "EPC G2v2 Error Message : Insufficient power"},
            {"0F", "EPC G2v2 Error Message : Non-specific error"},
            {"11", "Vendor Specific : Sensor scheduling configuration"},
            {"12", "Vendor Specific : Tag busy"},
            {"13", "Vendor Specific : Measurement type not supported"},
            {"80", "Protocol : No tag detected"},
            {"81", "Protocol : Handle acquisition failure"},
            {"82", "Protocol : Access password failure"},
            {"83", "Protocol : Kill password failure"},
            {"90", "Modem : CRC error"},
            {"91", "Modem : Rx timeout"},
            {"A0", "Registry : Registry update failure"},
            {"A1", "Registry : Registry erase failure"},
            {"A2", "Registry : Registry write failure"},
            {"A3", "Registry : Registry not exist"},
            {"B0", "Peripheral : UART failure"},
            {"B1", "Peripheral : SPI failure"},
            {"B2", "Peripheral : I2C failure"},
            {"B3", "Peripheral : GPIO failure"},
            {"E0", "Custom : Not supported command"},
            {"E1", "Custom : Undefined command"},
            {"E2", "Custom : Invalid parameter"},
            {"E3", "Custom : Too high parameter"},
            {"E4", "Custom : Too low parameter"},
            {"E5", "Custom : Failure automatic read operation"},
            {"E6", "Custom : Not automatic read mode"},
            {"E7", "Custom : Failure to get last response"},
            {"E8", "Custom : Failure to control test"},
            {"E9", "Custom : Failure to reset reader"},
            {"EA", "Custom : RFID block control failure"},
            {"EB", "Custom : PR9200 busy"},
            {"F0", "Custom : Command failure"},
            {"F1", "Custom : Verify failure"},
            {"FC", "Antenna Connection Status: Abnormal"},
            {"FF", "Custom : Error none"}
        };

        public static string FailCase(string[] s)
        {
            string tmpCommand, tmpFailure = "";

            if (s.Length < 13)
            {
                return "The packet does not fit the format.";
            }
            else
            {
                try
                {
                    tmpCommand = (string)htCommand[s[8]];
                }
                catch
                {
                    tmpCommand = "Unknown code";
                }

                try
                {
                    tmpFailure = (string)htFailure[s[9]];
                }
                catch
                {
                    tmpFailure = "Unknown code";
                }

                return "ERROR > [" + s[8] + "] " + tmpCommand + ", [" + s[9] + "] " + tmpFailure + "\r\n";
            }
        }
    }
}
