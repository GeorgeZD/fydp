using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using System.Runtime.InteropServices;
using System.Reflection;

namespace ECE498A
{
    public partial class Form1 : Form
    {

        private Capture _capture = null;
        public Form1()
        {
            var dllDirectory = @"D:\TestConsoleApplication\ECE498A\bin\x64";
            Environment.SetEnvironmentVariable("PATH", Environment.GetEnvironmentVariable("PATH") + ";" + dllDirectory);
            dllDirectory = @"D:\TestConsoleApplication\ECE498A\bin\x86";
            Environment.SetEnvironmentVariable("PATH", Environment.GetEnvironmentVariable("PATH") + ";" + dllDirectory);

            InitializeComponent();
            try
            {
                _capture = new Capture();
                _capture.ImageGrabbed += ProcessFrame;
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            Image<Bgr, Byte> frame = _capture.RetrieveBgrFrame();
            imageBox1.Image = frame;
        }

        private void ReleaseData()
        {
            if (_capture != null)
            {
                _capture.Stop();
                _capture.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _capture.Start();
        }
    }
}
