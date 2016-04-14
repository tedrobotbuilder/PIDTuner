using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.IO.Ports;
using ZedGraph;

namespace DataPlot3
{
    public partial class Form1 : Form
    {
        bool bDataSentToBot = false;
        bool bSpeedSent = false;
        bool bKpSent = false;
        bool bKiSent = false;
        bool bKdSent = false;
        String COMRx;
        int NoOfCurves, Samples;
        int[,] colourList = {{128,0,0},{0,128,0},{0,0,128},{0,128,128},{128,128,0},{255,0,0},{0,255,0},
                            {0,0,255},{255,255,0},{255,0,255},{0,255,255}};

        List<PointPairList> Data = new List<PointPairList>();

        delegate void SerialDataReceivedDelegate(object sender, SerialDataReceivedEventArgs e);

        delegate void SerialErrorReceivedDelegate(object sender, SerialErrorReceivedEventArgs e);
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set the titles and axis labels
            ZedGraphControl1.GraphPane.Title.Text = "";
            //ZedGraphControl1.GraphPane.Title.IsVisible = false;
            ZedGraphControl1.GraphPane.XAxis.Title.Text = "";
            ZedGraphControl1.GraphPane.YAxis.Title.Text = "";
            ZedGraphControl1.GraphPane.XAxis.Scale.MaxGrace = 0;
            ZedGraphControl1.GraphPane.YAxis.MajorGrid.IsVisible = true;
            ZedGraphControl1.GraphPane.XAxis.MajorGrid.IsVisible = true;
            ZedGraphControl1.GraphPane.Legend.Position = ZedGraph.LegendPos.Top;

            // Set defaults for UI
            PTermNumericUpDown.Value = Properties.Settings.Default.PTermSetting;
            ITermNumericUpDown.Value = Properties.Settings.Default.ITermSetting;
            DTermNumericUpDown.Value = Properties.Settings.Default.DTermSetting;
            SpeedNumericUpDown.Value = Properties.Settings.Default.SpeedSetting;
            NoOfDataNumericUpDown.Value = Properties.Settings.Default.DataSetsSetting;
            XTextBox.Text = Properties.Settings.Default.XScaleSetting;
            YTextBox.Text = Properties.Settings.Default.YScaleSetting;

            // Fill COMPortComboBox with available COM ports
            string[] saPorts = SerialPort.GetPortNames();
            bool foundCOMPortFlag = false;
            COMPortComboBox.DataSource = saPorts;
            foreach (string port in saPorts)
            {
                if (port == Properties.Settings.Default.COMPortSetting)
                {
                    COMPortComboBox.Text = Properties.Settings.Default.COMPortSetting;
                    foundCOMPortFlag = true;
                }
            }
            
            // We didn't find the COM port, so set to COM1
            if (foundCOMPortFlag == false) {
                COMPortComboBox.SelectedIndex = 0;
            }
        }

        private void COMConnectBtn_Click(object sender, EventArgs e)
        {
            COMConnectButton.Enabled = false;

            COMPortStatusLight.Value = 3;

            ZedGraphControl1.GraphPane.YAxis.Scale.Max = Convert.ToDouble(YTextBox.Text);
            ZedGraphControl1.GraphPane.YAxis.Scale.Min = -Convert.ToDouble(YTextBox.Text);

            if (SerialPort.IsOpen)//connection is already open, close it
            {
                timer1.Enabled = false;

                SerialPort.Close();

                COMPortStatusLight.Value = -1;
                COMConnectButton.Text = "Connect";
                COMSendButton.Enabled = false;
                NoOfDataNumericUpDown.Enabled = true;
            } else {//connection is closed, open it
                SerialPort.PortName = COMPortComboBox.Text;
                SerialPort.BaudRate = int.Parse(COMBaudComboBox.Text);

                try {
                    SerialPort.Open();
                } catch {
                    COMPortStatusLight.Value = -1;
                    MessageBox.Show("Could not open " + COMPortComboBox.Text);
                }

                if (SerialPort.IsOpen) {
                    COMPortStatusLight.Value = 1;
                    COMConnectButton.Text = "Disconnect";
                    COMSendButton.Enabled = true;
                    NoOfDataNumericUpDown.Enabled = false;

                    Data.Clear();
                    deleteCurves();
                    initCurves();

                    timer1.Enabled = true;
                }
            }

            COMConnectButton.Enabled = true;
        }

        private void initCurves()
        {
            Samples = int.Parse(XTextBox.Text);
            NoOfCurves = (int)NoOfDataNumericUpDown.Value;


            for (int j = 0; j < NoOfCurves; j++)
            {
                PointPairList tempppl = new PointPairList();

                for (double x = 0; x < Samples; x++)
                {
                    tempppl.Add(x, 0);
                }

                Data.Add(tempppl);
                ZedGraphControl1.GraphPane.AddCurve("Series " + j.ToString(), Data[j],
                    Color.FromArgb(colourList[j, 0], colourList[j, 1], colourList[j, 2]),
                        SymbolType.None).Line.Width = (float)SeriesLineSizeNumericUpDown.Value;
            }
        }

        private void deleteCurves()
        {
            ZedGraphControl1.GraphPane.CurveList.Clear();
        }

        // event handler for getting serial data
        private void ProcessCOMRx(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(COMRx))
            {
                // handel incoming info from bot
                if (COMRx.Contains("#"))
                {
                    //Console.WriteLine("COMRx:" + COMRx);
                    var vDataValue = COMRx.Substring(2, COMRx.IndexOf("#")-2);
                    //Console.WriteLine("vDataValue:" + vDataValue);

                    if (COMRx.StartsWith("kp"))
                    {
                        // Check off that speed was sent
                        bKpSent = true;
                        Console.WriteLine("got back kp");
                    }

                    if (COMRx.StartsWith("ki"))
                    {
                        // Check off that speed was sent
                        bKiSent = true;
                        Console.WriteLine("got back ki");
                    }

                    if (COMRx.StartsWith("kd"))
                    {
                        // Check off that speed was sent
                        bKdSent = true;
                        Console.WriteLine("got back kd");
                    }

                    if (COMRx.StartsWith("sp"))
                    {
                        // Check off that speed was sent
                        bSpeedSent = true;
                        Console.WriteLine("got back sp");
                    }
                    return;
                }

                // parse incoming data for graphing
                string[] parsed = COMRx.Split(',');
                int curveNo;

                if (parsed.Count() > ZedGraphControl1.GraphPane.CurveList.Count())
                {
                    // data count is more than stated - good
                    curveNo = ZedGraphControl1.GraphPane.CurveList.Count();
                }
                else
                {
                    // data count is not more than stated - bad
                    curveNo = parsed.Count();
                }

                for (int k = 0; k < curveNo; k++)
                {
                    for (int j = ZedGraphControl1.GraphPane.CurveList[k].NPts - 1; j > 0; j--)
                    {
                        ZedGraphControl1.GraphPane.CurveList[k].Points[j].Y = ZedGraphControl1.GraphPane.CurveList[k].Points[j - 1].Y;
                    }

                    double temp = 0;

                    try
                    {
                        temp = double.Parse(parsed[k]);
                    }
                    catch
                    {
                        RawTextBox.AppendText("Parse Error\n");
                    }

                    //RawTextBox.AppendText(temp.ToString() + "-" + k.ToString() + ", ");
                    ZedGraphControl1.GraphPane.CurveList[k].Points[0].X = 0;
                    ZedGraphControl1.GraphPane.CurveList[k].Points[0].Y = temp;
                }
                //RawTextBox.AppendText("\n");
                RawTextBox.AppendText(COMRx + '\n');
                COMRx = "";
            }

            if (bDataSentToBot == true)
            {
                if (!bSpeedSent) {
                    SerialPort.WriteLine("sp" + SpeedNumericUpDown.Value + "#");
                    Console.WriteLine("resent sp");
                }

                if (!bKpSent) { 
                    SerialPort.WriteLine("kp" + PTermNumericUpDown.Value + "#");
                    Console.WriteLine("resent kp");
                }

                if (!bKiSent) {
                    SerialPort.WriteLine("ki" + ITermNumericUpDown.Value + "#");
                    Console.WriteLine("resent ki");
                }

                if (!bKdSent) {
                    SerialPort.WriteLine("kd" + DTermNumericUpDown.Value + "#");
                    Console.WriteLine("resent kd");
                }


                if (bSpeedSent && bKiSent && bKdSent && bKpSent)
                {
                    // Everything came back so reset the flags
                    bDataSentToBot = false;
                    Console.WriteLine("got back all and reset bDataSentToBot flag");
                    COMPortSendStatusLight.Value = 0;
                }
            }
        }

        private void ReadLineError(object sender, EventArgs e)
        {
            RawTextBox.AppendText("Read Line Error\n");
        }

        private void SerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int BufferLength = SerialPort.BytesToRead;
            //StringBuilder tempS = new StringBuilder();

            while (BufferLength > 0 && SerialPort.IsOpen)
            {
                try
                {
                    //tempS.Append(MAASerialPort.ReadLine());
                    COMRx = SerialPort.ReadLine();
                    //Console.Write("COMRx:");
                    //Console.Write(COMRx);
                    //Console.WriteLine(":");
                    //tempS.Length = 0;

                    this.BeginInvoke(new EventHandler(ProcessCOMRx));

                    if (SerialPort.IsOpen)
                        BufferLength = SerialPort.BytesToRead;
                }
                catch
                {
                    this.BeginInvoke(new EventHandler(ReadLineError));
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ZedGraphControl1.AxisChange();
            ZedGraphControl1.Invalidate();
        }

        private void COMSendButton_Click(object sender, EventArgs e)
        {
            COMPortSendStatusLight.Value = -1;

            //SerialPort.WriteLine("sp" + SpeedNumericUpDown.Value + "#");
            //SerialPort.WriteLine("kp" + PTermNumericUpDown.Value + "#");
            //SerialPort.WriteLine("ki" + ITermNumericUpDown.Value + "#");
            //SerialPort.WriteLine("kd" + DTermNumericUpDown.Value + "#");
            SerialPort.WriteLine("sp" + SpeedNumericUpDown.Value + "#");
            SerialPort.WriteLine("kp" + PTermNumericUpDown.Value + "#");
            SerialPort.WriteLine("ki" + ITermNumericUpDown.Value + "#");
            SerialPort.WriteLine("kd" + DTermNumericUpDown.Value + "#");
            //System.Threading.Thread.Sleep(1);
            
            // set send/receive flags 
            bDataSentToBot = true;
            bSpeedSent = false;
            bKpSent = false;
            bKiSent = false;
            bKdSent = false; 
            
            Console.WriteLine("Sent");

            //label2.Text = PTermNumericUpDown.Value.ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // save settings to default value storage
            Properties.Settings.Default.COMPortSetting = COMPortComboBox.Text;
            Properties.Settings.Default.PTermSetting = PTermNumericUpDown.Value;
            Properties.Settings.Default.ITermSetting = ITermNumericUpDown.Value;
            Properties.Settings.Default.DTermSetting = DTermNumericUpDown.Value;
            Properties.Settings.Default.SpeedSetting = SpeedNumericUpDown.Value;
            Properties.Settings.Default.DataSetsSetting = NoOfDataNumericUpDown.Value;
            Properties.Settings.Default.XScaleSetting = XTextBox.Text;
            Properties.Settings.Default.YScaleSetting = YTextBox.Text;

            Properties.Settings.Default.Save();
        }

    }
}