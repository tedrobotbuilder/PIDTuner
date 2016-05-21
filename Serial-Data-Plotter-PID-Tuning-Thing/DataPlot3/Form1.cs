using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO.Ports;
using ZedGraph;

namespace DataPlot3 {
    public partial class Form1 : Form {
        bool bStartReceived = false;
        bool bStopReceived = false;

        bool bDataSentToBot = false;
        bool bSpeedReceived = false;
        bool bKpReceived = false;
        bool bKiReceived = false;
        bool bKdReceived = false;
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

        private void Form1_Load(object sender, EventArgs e) {
            // Set the titles and axis labels
            ZedGraphControl1.GraphPane.Title.Text = "";
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
            SeriesLineSizeNumericUpDown.Value = Properties.Settings.Default.LineSizeSetting;

            // Fill COMPortComboBox with available COM ports
            string[] aosPorts = SerialPort.GetPortNames();
            bool foundCOMPortFlag = false;
            COMPortComboBox.DataSource = aosPorts;
            foreach (string port in aosPorts) {
                if (port == Properties.Settings.Default.COMPortSetting) {
                    COMPortComboBox.Text = port;
                    foundCOMPortFlag = true;
                }
            }
            
            // We didn't find the COM port, so set to COM1
            if (foundCOMPortFlag == false) {
                COMPortComboBox.SelectedIndex = 0;
            }
        }

        private void COMConnectBtn_Click(object sender, EventArgs e) {
            COMConnectButton.Enabled = false;// stop user from clicking again while this event works on the port

            COMPortStatusLight.Value = 3;

            ZedGraphControl1.GraphPane.YAxis.Scale.Max = Convert.ToDouble(YTextBox.Text);
            ZedGraphControl1.GraphPane.YAxis.Scale.Min = -Convert.ToDouble(YTextBox.Text);

            if (SerialPort.IsOpen) {//connection is already open, close it
                timer1.Enabled = false;
                timer2.Enabled = false;

                SerialPort.Close();

                COMPortStatusLight.Value = MyConstants.Red;
                COMConnectButton.Text = "Connect";
                COMSendButton.Enabled = false;
                COMSendStatusLight.Value = MyConstants.Red;
                StartStopButton.Enabled = false;
                NoOfDataNumericUpDown.Enabled = true;
            } else {//connection is closed, open it
                SerialPort.PortName = COMPortComboBox.Text;
                SerialPort.BaudRate = int.Parse(COMBaudComboBox.Text);

                try {
                    SerialPort.Open();
                } catch {
                    COMPortStatusLight.Value = MyConstants.Red;
                    MessageBox.Show("Could not open " + COMPortComboBox.Text);
                }

                if (SerialPort.IsOpen) {//successfully opened port
                    COMPortStatusLight.Value = MyConstants.Green;
                    COMConnectButton.Text = "Disconnect";
                    COMSendButton.Enabled = true;
                    COMSendStatusLight.Value = MyConstants.Green;
                    StartStopButton.Enabled = true;
                    NoOfDataNumericUpDown.Enabled = false;
                    SerialPort.WriteLine("bv1#");// ask for battery voltage on robot

                    Data.Clear();
                    deleteCurves();
                    initCurves();

                    timer1.Enabled = true;
                    timer2.Enabled = true;
                }
            }

            COMConnectButton.Enabled = true;// work is done, allow user to click again
        }

        private void initCurves() {
            Samples = int.Parse(XTextBox.Text);
            NoOfCurves = (int)NoOfDataNumericUpDown.Value;

            for (int j = 0; j < NoOfCurves; j++) {
                PointPairList tempppl = new PointPairList();

                for (double x = 0; x < Samples; x++) {
                    tempppl.Add(x, 0);
                }

                Data.Add(tempppl);
                ZedGraphControl1.GraphPane.AddCurve("Series " + j.ToString(), Data[j],
                    Color.FromArgb(colourList[j, 0], colourList[j, 1], colourList[j, 2]),
                        SymbolType.None).Line.Width = (float)SeriesLineSizeNumericUpDown.Value;
            }
        }

        private void deleteCurves() {
            ZedGraphControl1.GraphPane.CurveList.Clear();
        }

        // event handler for getting serial data
        private void ProcessCOMRx(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(COMRx)) {
                // handel incoming info from bot
                if (COMRx.Contains("#")) {// Hande non-series date here
                    //Console.WriteLine("COMRx:" + COMRx);
                    var vDataValue = COMRx.Substring(2, COMRx.IndexOf("#")-2);
                    //Console.WriteLine("vDataValue:" + vDataValue);

                    if (COMRx.StartsWith("bv")) {
                        BattVoltsLabel.Text = vDataValue + " Volts";
                        Console.WriteLine("got back bv");
                    }

                    if (COMRx.StartsWith("lt")) {
                        lapTimeTextBox.Text = vDataValue;
                        Console.WriteLine("got back lap-time");
                    }

                    if (COMRx.StartsWith("ss")) {
                        if (vDataValue == MyConstants.Stop) {
                            Console.WriteLine("got back Stop");
                            bStopReceived = true;
                        }
                        else {
                            Console.WriteLine("got back Start");
                            bStartReceived = true;
                        }
                    }

                    if (COMRx.StartsWith("kp")) {
                        // Check off that speed was sent
                        bKpReceived = true;
                        Console.WriteLine("got back kp");
                    }

                    if (COMRx.StartsWith("ki")) {
                        // Check off that speed was sent
                        bKiReceived = true;
                        Console.WriteLine("got back ki");
                    }

                    if (COMRx.StartsWith("kd")) {
                        // Check off that speed was sent
                        bKdReceived = true;
                        Console.WriteLine("got back kd");
                    }

                    if (COMRx.StartsWith("sp")) {
                        // Check off that speed was sent
                        bSpeedReceived = true;
                        Console.WriteLine("got back sp");
                    }
                    //return;// exit because rest of code here is for series data
                }

                if (!COMRx.Contains("#")) {// parse incoming series data                    
                    string[] parsed = COMRx.Split(',');
                    int curveNo;

                    if (parsed.Count() > ZedGraphControl1.GraphPane.CurveList.Count()) {
                        // data series count is more than stated - good
                        curveNo = ZedGraphControl1.GraphPane.CurveList.Count();
                    }
                    else {
                        // data series count is not more than stated - bad
                        curveNo = parsed.Count();
                    }

                    for (int k = 0; k < curveNo; k++) {
                        for (int j = ZedGraphControl1.GraphPane.CurveList[k].NPts - 1; j > 0; j--) {
                            ZedGraphControl1.GraphPane.CurveList[k].Points[j].Y = ZedGraphControl1.GraphPane.CurveList[k].Points[j - 1].Y;
                        }

                        double temp = 0;

                        try {
                            temp = double.Parse(parsed[k]);
                        }
                        catch {
                            RawTextBox.AppendText("Parse Error\n");
                        }

                        ZedGraphControl1.GraphPane.CurveList[k].Points[0].X = 0;
                        ZedGraphControl1.GraphPane.CurveList[k].Points[0].Y = temp;
                    }
                    RawTextBox.AppendText(COMRx + '\n');
                    COMRx = "";
                }
            }// end if (!string.IsNullOrEmpty(COMRx))

            if (bDataSentToBot == true) {// check if all data sent to bot got sent, resent if not
                if (!bSpeedReceived) {
                    SerialPort.WriteLine("sp" + SpeedNumericUpDown.Value + "#");
                    Console.WriteLine("resent sp");
                }

                if (!bKpReceived) { 
                    SerialPort.WriteLine("kp" + PTermNumericUpDown.Value + "#");
                    Console.WriteLine("resent kp");
                }

                if (!bKiReceived) {
                    SerialPort.WriteLine("ki" + ITermNumericUpDown.Value + "#");
                    Console.WriteLine("resent ki");
                }

                if (!bKdReceived) {
                    SerialPort.WriteLine("kd" + DTermNumericUpDown.Value + "#");
                    Console.WriteLine("resent kd");
                }

                if (bSpeedReceived && bKiReceived && bKdReceived && bKpReceived) {
                    // Everything came back so reset the flag
                    bDataSentToBot = false;
                    Console.WriteLine("got back all and reset bDataSentToBot flag");
                    COMSendStatusLight.Value = MyConstants.Green;
                }
            }
        }

        private void ReadLineError(object sender, EventArgs e) {
            RawTextBox.AppendText("Read Line Error\n");
        }

        private void SerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e) {
            // Process incoming serial data one line at a time

            int BufferLength = SerialPort.BytesToRead;

            while (BufferLength > 0 && SerialPort.IsOpen) {// while we have data and open port
                try {
                    COMRx = SerialPort.ReadLine();// load a single line of date

                    this.BeginInvoke(new EventHandler(ProcessCOMRx));// process that line

                    if (SerialPort.IsOpen) BufferLength = SerialPort.BytesToRead;

                } catch {
                    this.BeginInvoke(new EventHandler(ReadLineError));
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            ZedGraphControl1.AxisChange();
            ZedGraphControl1.Invalidate();
        }

        private void COMSendButton_Click(object sender, EventArgs e) {
            COMSendStatusLight.Value = MyConstants.Red;
            
            SerialPort.WriteLine("sp" + SpeedNumericUpDown.Value + "#");
            SerialPort.WriteLine("kp" + PTermNumericUpDown.Value + "#");
            SerialPort.WriteLine("ki" + ITermNumericUpDown.Value + "#");
            SerialPort.WriteLine("kd" + DTermNumericUpDown.Value + "#");
            
            // set send/receive flags 
            bDataSentToBot = true;
            bSpeedReceived = false;
            bKpReceived = false;
            bKiReceived = false;
            bKdReceived = false; 
        }

        private void StartStopButton_Click(object sender, EventArgs e) {
            Console.WriteLine("Hit SS");

            if (StartStopButton.Text == "Start Robot") {
                StartStopButton.Text = "Stop Robot";
                // Send start command to robot
                SerialPort.WriteLine("ss" + MyConstants.Start + "#");
                bStartReceived = false;
                Console.WriteLine("Hit Start");
            } else {
                StartStopButton.Text = "Start Robot";
                // Send stop command to robot
                SerialPort.WriteLine("ss" + MyConstants.Stop + "#");
                bStopReceived = false;
                Console.WriteLine("Hit Stop");
            }
        }

        private void timer2_Tick(object sender, EventArgs e) {
            SerialPort.WriteLine("bv1#");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            // save settings to default value storage
            Properties.Settings.Default.COMPortSetting = COMPortComboBox.Text;
            Properties.Settings.Default.PTermSetting = PTermNumericUpDown.Value;
            Properties.Settings.Default.ITermSetting = ITermNumericUpDown.Value;
            Properties.Settings.Default.DTermSetting = DTermNumericUpDown.Value;
            Properties.Settings.Default.SpeedSetting = SpeedNumericUpDown.Value;
            Properties.Settings.Default.DataSetsSetting = NoOfDataNumericUpDown.Value;
            Properties.Settings.Default.XScaleSetting = XTextBox.Text;
            Properties.Settings.Default.YScaleSetting = YTextBox.Text;
            Properties.Settings.Default.LineSizeSetting = SeriesLineSizeNumericUpDown.Value;
            
            Properties.Settings.Default.Save();
        }
    }
}