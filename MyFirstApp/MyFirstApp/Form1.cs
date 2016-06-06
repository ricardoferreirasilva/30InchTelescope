using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Device;
using System.Device.Location;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace MyFirstApp
{
    public partial class Form1 : Form
    {
        // Current point coordenates
        RightAscension currentRightAscension;
        Declination currentDeclination;
        // Expected point coordenates, the coordenates de screen is telling us to go to.
        RightAscension expectedRightAscension;
        Declination expectedDeclination;
        // Degrees need to adjust the telescope to new position
        float degreesRA;
        float degreesDEC;

        // Port names for the encoders
        static string encoder1_port = "COM6";
        static string encoder2_port = "COM6";
        static string encoder3_port = "COM6";
        // Serial ports for the encoders.
        SerialPort encoder1;
        SerialPort encoder2;
        SerialPort encoder3;
        //update encoders timer.
        private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer siderealTimer = new System.Windows.Forms.Timer();
        //bool value
        static bool encodersConnected = false;
        // Values of serial ports.
        static public int encoder1_value = 0;
        static public int encoder2_value = 0;
        static public int encoder3_value = 0;
        //Calculated encoder values
        static public int encoder1_supposed = -10000;
        static public int encoder2_supposed = -10000;
        static public int encoder3_supposed = -10000;
        //Value of conversion to encoder units.
        static public double unitFactorRA1 = 0.4854541944;
        static public double unitFactorRA2 = 0.4867266667;
        static public double unitFactorDEC = 0.1857816206;
        //Astro Clock and sidereal time related.
        AstroClock.ClockForm astroform = new AstroClock.ClockForm();
        //Sidereal Time.
        TimeSpan siderealTime;
        //Forms
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            initializeTimers();
            getCOMS();
            siderealTimer.Start();
            new Task(stellariumlListen).Start();
        }
        private void initializeTimers()
        {
            //Initializing timer of encoder update function
            timer1.Tick += new EventHandler(updateEncoders);
            timer1.Interval = 250; // in miliseconds
            //Initializing timer of sidereal time update function
            siderealTimer.Tick += new EventHandler(updateST);
            siderealTimer.Interval = 250; // in miliseconds
        }
        //This function gets the com ports to the interface
        private void getCOMS()
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comhold1.Items.Add(port);
            }
        }
        ///When the calculate button is clicked.
        private void button1_Click(object sender, EventArgs e)
        {
            bool canCalculate = true;
            if(currentDeclination == null || currentRightAscension == null)
            {
                canCalculate = false;
                richTextBox_result.AppendText("No reference starting point. Please initialize.\n");
            }
            if(text_ra_h.TextLength > 0 && text_ra_m.TextLength >0 && text_ra_s.TextLength>0)
            {
                TimeSpan ra_time = TimeSpan.Parse(text_ra_h.Text + ":" + text_ra_m.Text + ":" + text_ra_s.Text);
                TimeSpan difference = siderealTime.Subtract(ra_time);
                double hoursDifference = difference.TotalHours;
                richTextBox_result.AppendText(String.Format("{0:0.00}", hoursDifference) + " hours difference. 1\n");
                //Fixing hours.
                if (hoursDifference <= -8) hoursDifference += 24;
                else if (hoursDifference >= 8) hoursDifference -= 24;
                richTextBox_result.AppendText(String.Format("{0:0.00}", hoursDifference) + " hours difference.(Fixed)  \n");
                if (hoursDifference >= 8)
                {
                    richTextBox_result.AppendText("Chosen right ascension is not visible.\n");
                    canCalculate = false;
                }
                int hours = Convert.ToInt16(text_ra_h.Text);
                float minutes = float.Parse(text_ra_m.Text, CultureInfo.InvariantCulture);
                float seconds = float.Parse(text_ra_s.Text, CultureInfo.InvariantCulture);
                expectedRightAscension = new RightAscension(hours, minutes, seconds);
            }
            else
            {
                canCalculate = false;
                richTextBox_result.AppendText("Invalid input in RA.\n");
            }
            if (text_dec_degrees.TextLength > 0 && text_dec_arcmins.TextLength > 0 && text_dec_arcsecs.TextLength > 0)
            {
                int degrees = Convert.ToInt16(text_dec_degrees.Text);
                float arcmins = float.Parse(text_dec_arcmins.Text, CultureInfo.InvariantCulture);
                float arcsecs = float.Parse(text_dec_arcsecs.Text, CultureInfo.InvariantCulture);
                expectedDeclination = new Declination(degrees, arcmins, arcsecs);
            }
            else
            {
                canCalculate = false;
                richTextBox_result.AppendText("Invalid input in DEC.\n");
            }
            if(canCalculate)
            {
                richTextBox_result.AppendText("[LOG]: SUCCESS\n");
                richTextBox_result.AppendText("---> POINT COORDINATES (degrees).\n");
                richTextBox_result.AppendText("RA: " + expectedRightAscension.degrees + "\n");
                richTextBox_result.AppendText("DEC: " + expectedDeclination.degreesPrecision + "\n");
                // Calculating the deferences in degrees of the current position and desired position.
                degreesRA = expectedRightAscension.degrees - currentRightAscension.degrees;
                degreesDEC = expectedDeclination.degreesPrecision - currentDeclination.degreesPrecision;
                //richTextBox_result.AppendText("---> ADJUST LEVELS (degrees)\n");
                //richTextBox_result.AppendText("-> RA: " + degreesRA + "\n");
                //richTextBox_result.AppendText("-> DEC: " + degreesDEC + "\n");
                //Making adjustments to get the smallest correction angle.
                if (degreesRA < -180) degreesRA += 360;
                else if (degreesRA > 180) degreesRA -= 360;
                if (degreesDEC < -180) degreesRA += 360;
                else if (degreesDEC > 180) degreesRA -= 360;
                richTextBox_result.AppendText("---> ADJUST LEVELS (degrees)\n");
                richTextBox_result.AppendText("-> RA: " + degreesRA + "\n");
                richTextBox_result.AppendText("-> DEC: " + degreesDEC + "\n");

                float secondsToAdjustRA = expectedRightAscension.totalSeconds - currentRightAscension.totalSeconds;
                float secondsToAdjustDEC = expectedDeclination.totalSeconds - currentDeclination.totalSeconds;
                //richTextBox_result.AppendText("-> SECONDS TO ADJUST: " + secondsToAdjust + "\n");
                if (secondsToAdjustRA >= 12 * 60 * 60)
                {
                    secondsToAdjustRA = - (24 * 60 * 60 - secondsToAdjustRA);
                }
                richTextBox_result.AppendText("-> Seconds to Adjust on RA axis. " + secondsToAdjustRA + "\n");
                richTextBox_result.AppendText("-> Seconds(arc) to Adjust on DEC axis. " + secondsToAdjustDEC + "\n");

                encoder1_supposed = (encoder1_value + (int)(secondsToAdjustRA*unitFactorRA1));
                encoder2_supposed = (encoder2_value + (int)(secondsToAdjustRA * unitFactorRA2));
                encoder3_supposed = (encoder3_value + (int)(secondsToAdjustDEC * unitFactorDEC));

                //Encoder values
                expected1_text.Text = ""+encoder1_supposed;
                expected2_text.Text = "" + encoder2_supposed;
                expected3_text.Text = "" + encoder3_supposed;
            }
            else
            {
                richTextBox_result.AppendText("[LOG]: ERROR");
            }
            
        }
        //When initiate button is clicked.
        private void button_init_Click(object sender, EventArgs e)
        {       
            currentRightAscension = new RightAscension(siderealTime.Hours,siderealTime.Minutes,+siderealTime.Seconds);
            currentDeclination = new Declination(90, 0, 0);
            richTextBox_result.AppendText("Aligned to the Celestial Pole.\n");
        }
        //When the clear button is clicked.
        private void button_clear_Click(object sender, EventArgs e)
        {
            richTextBox_result.Clear();
        }
        //When we press sync
        private void button_sync_Click(object sender, EventArgs e)
        {
            currentRightAscension = expectedRightAscension;
            currentDeclination = expectedDeclination;
            expected1_text.Text = "";
            expected2_text.Text = "";
            expected3_text.Text = "";
            richTextBox_result.AppendText("Synced.\n");

        }

        private void exitMenuButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Update sidereal time function
        private void updateST(object sender,EventArgs e)
        {
            string time = astroform.getST();
            siderealTime = TimeSpan.Parse(time);
            sidereal_time.Text = siderealTime+"\n";
        }
        //Update encoder values in form function
        private void updateEncoders(object sender, EventArgs e)
        {
            encoder1_text.Text = "" + encoder1_value;
            encoder2_text.Text = "" + encoder2_value;
            encoder3_text.Text = "" + encoder3_value;
            if(Math.Abs(encoder1_supposed - encoder1_value) <= 500)
            {
                panel1.BackColor = Color.Green;
            }
            else
            {
                panel1.BackColor = Color.Red;
            }
            if (Math.Abs(encoder2_supposed - encoder1_value) <= 500)
            {
                panel1.BackColor = Color.Green;
            }
            else
            {
                panel1.BackColor = Color.Red;
            }
            if (Math.Abs(encoder3_supposed - encoder1_value) <= 500)
            {
                panel1.BackColor = Color.Green;
            }
            else
            {
                panel1.BackColor = Color.Red;
            }
        }

        //Connect encoders button
        private void connect_encoders_Click(object sender, EventArgs e)
        {
            if(encodersConnected == false)
            {
                encoder1_port = comhold1.Text;
                comhold1.Enabled = false;
                connectEncoders();
                timer1.Start();
                connect_encoders.Text = "Disconnect Encoders";
                encodersConnected = true;
                encoder1_text.Text = "";
                encoder2_text.Text = "";
                encoder3_text.Text = "";
            }
            else
            {
                timer1.Stop();
                disconnectEncoders();
                connect_encoders.Text = "Connect Encoders";
                encodersConnected = false;
                encoder1_text.Text = "";
                encoder2_text.Text = "";
                encoder3_text.Text = "";
                comhold1.Enabled = true;
            }
        }
        //connectEncoders Function.
        private void disconnectEncoders()
        {
            try
            {
                encoder1.Close();
                richTextBox_result.AppendText("Encoder 1 disconnected\n");
            }
            catch(Exception ex)
            {
                richTextBox_result.AppendText("Encoder 1 could not be disconnected.\n");
            }

        }
        private void connectEncoders()
        {
            //SerialPort
            encoder1 = new SerialPort(encoder1_port);
            encoder1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler_encoder1);
            encoder1.BaudRate = 115200;
            encoder1.Parity = Parity.None;
            encoder1.StopBits = StopBits.One;
            encoder1.DataBits = 8;
            encoder1.Handshake = Handshake.None;
            encoder1.RtsEnable = true;
            try
            {
                encoder1.Open();
                richTextBox_result.AppendText("Encoder 1 connected\n");
            }
            catch(Exception ex)
            {
                richTextBox_result.AppendText("Encoder 1 could not be connected.\n");
            }
            //SerialPort
        }
        //Data received event handler for encoder 1
        static void DataReceivedHandler_encoder1(
                       object sender,
                       SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string data = sp.ReadLine();
            string[] split = data.Split(new string[] { ":" }, StringSplitOptions.None);
            string number;
            if (split.Length > 1)
            {
                number = split[1];
            }
            else
            {
                number = "Unparsed";
            }
            int data_int;    
            if(Int32.TryParse(number,out data_int))
            {
                System.Diagnostics.Debug.Write("[Parsed]: "+split[0]+" : " + data_int + "\n");
                if(split[0] == "E1")
                {
                    encoder1_value = data_int;
                }
                else if (split[0] == "E2")
                {
                    encoder2_value = data_int;
                }
                else if (split[0] == "E3")
                {
                    encoder3_value = data_int;
                }
            }
            else
            {
                System.Diagnostics.Debug.Write("[Unparsed]:" + data + "\n");
            }
            //Clear buffer.
            sp.DiscardInBuffer();
        }
        //Shows or hides astroClock application.
        private void astro_button_Click(object sender, EventArgs e)
        {
            if (astroform.Visible)
            {
                astroform.Hide();
                astro_button.Text = "Astro Clock";
            }
            else
            {

                astroform.Show();
                astro_button.Text = "Exit";
            }
        }
        //This function is launched as a thread and it listens to stellarium and updates UI upon receiving values.
        public void stellariumlListen()
        {

            TcpListener serverSocket = new TcpListener(6666);
            int requestCount = 0;
            TcpClient clientSocket = default(TcpClient);
            serverSocket.Start();
            Console.WriteLine(" >> Server Started");
            clientSocket = serverSocket.AcceptTcpClient();
            clientSocket.ReceiveBufferSize = 20;
            Console.WriteLine(" >> Accept connection from client");
            requestCount = 0;

            while ((true))
            {
                try
                {
                    requestCount = requestCount + 1;
                    NetworkStream netStream = clientSocket.GetStream();
                    // Reads NetworkStream into a byte buffer.
                    byte[] bytes = new byte[clientSocket.ReceiveBufferSize];

                    // Read can return anything from 0 to numBytesToRead. 
                    // This method blocks until at least one byte is read.
                    netStream.Read(bytes, 0, clientSocket.ReceiveBufferSize);
                    //We got the bytes
                    long ra = 0L | bytes[15] << 24 | (bytes[14] & 0xFF) << 16 | (bytes[13] & 0xFF) << 8 | (bytes[12] & 0xFF);
                    long dec = 0L | bytes[19] << 24 | (bytes[18] & 0xFF) << 16 | (bytes[17] & 0xFF) << 8 | (bytes[16] & 0xFF);

                    double raf = 12 * (double)ra / 2147483648.0f;
                    raf = (raf < 0f) ? 24.0f + raf : raf;

                    double decf = 90 * (double)dec / 1073741824.0f;

                    double raf_hour = Math.Floor(raf);
                    raf = 60.0f * (raf - raf_hour);
                    double raf_min = Math.Floor(raf);
                    raf = 60.0f * (raf - raf_min);
                    double raf_sec = Math.Floor(raf);

                    char sign = (decf < 0) ? '-' : '+';
                    decf = Math.Abs(decf);
                    double decf_deg = Math.Floor(decf);
                    decf = 60.0f * (decf - decf_deg);
                    double decf_min = Math.Floor(decf);
                    decf = 60.0f * (decf - decf_min);
                    double decf_sec = Math.Floor(decf);

                    Console.WriteLine("RA: " + (int)raf_hour + " " + (int)raf_min + " " + (int)raf_sec + "\n");
                    Console.WriteLine("DEC: " + (int)decf_deg + " " + (int)decf_min + " " + (int)decf_sec + "\n");
                    this.Invoke((MethodInvoker)delegate {
                        // runs on UI thread
                        text_ra_h.Text = ""+(int)raf_hour;
                        text_ra_m.Text = "" + (int)raf_min;
                        text_ra_s.Text = "" + (int)raf_sec;
                        text_dec_degrees.Text = "" + (int)decf_deg;
                        text_dec_arcmins.Text = "" + (int)decf_min;
                        text_dec_arcsecs.Text = "" + (int)decf_sec;
                    });
                    netStream.Flush();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            clientSocket.Close();
            serverSocket.Stop();
            Console.WriteLine(" >> exit");
            Console.ReadLine();
        }
        private void updateValues(int raf_hour)
        {
            text_ra_h.Text = "" + raf_hour;
        }
    }
    //A class to represent a right ascension value.
    public class RightAscension
    {
        //Hours,Minutes,Seconds Format for RightAscension
        int hours;
        float minutes;
        float seconds;
        //Deegres format for RightAscension
        public float degrees;
        public float totalSeconds;
        //Constructor
        public RightAscension(int hours,float minutes,float seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
            // 24 hours -> 360 deegres, so 1 hour -> 15 degrees.
            // We convert the RA to hours and multiply by 15.
            degrees = hours*15 + (minutes / 60)*15 + (seconds / 3600) * 15;
            totalSeconds = (hours * 60 * 60 + minutes * 60 + seconds);
        }

    }
    //A class to represent a declination value.
    public class Declination
    {
        //Degrees,Minutes of arc,Seconds of arc format for declination
        int degrees;
        float minutesArc;
        float secondsArc;
        // Degrees format for declination
        public float degreesPrecision;
        public float totalSeconds;
        public Declination(int degrees,float minutesArc,float secondsArc)
        {
            this.degrees = degrees;
            this.minutesArc = minutesArc;
            this.secondsArc = secondsArc;
            // 60 Minutes of Arc -> 1 degree and 60 seconds of Arc -> 1 Minute of Arc
            degreesPrecision = degrees + (minutesArc/ 60) + (secondsArc/ 60 / 60);
            totalSeconds = degrees * 60 * 60 + minutesArc * 60 + secondsArc;
        }
    }
}
