using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.IO.Ports;
using System.Threading;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Calibration
{
    /// <summary>
    /// Interaction logic for ComPortWindow.xaml
    /// </summary>
    public partial class ComPortWindow : Window
    {
        public byte[] statusMessageOut = Convert.FromHexString("FABBFACE0001000500000001007ADEADBEEF");
        public byte[] statusMessageIn;
        public byte[] versionMessageOut = Convert.FromHexString("FABBFACE0001000000000001007ADEADBEEF");
        public byte[] versionMessageIn;
        public byte[] stopMessageOut = Convert.FromHexString("FABBFACE00000001000000010000007ADEADBEEF");
        public byte[] stopMessageIn;

        static SerialPort _serialPort;

        public ComPortWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void Button_Click_Send_Status(object sender, RoutedEventArgs e)
        {
            SentData.Text = "FABBFACE0001000500000001007ADEADBEEF";
        }

        private void Button_Click_Send_Stop(object sender, RoutedEventArgs e)
        {
            SentData.Text = "FABBFACE00000001000000010000007ADEADBEEF";
        }

        private void Button_Click_Send_Version(object sender, RoutedEventArgs e)
        {
            SentData.Text = "FABBFACE0001000000000001007ADEADBEEF";
        }

        private void Button_Click_Connect_To_COMPORT(object sender, RoutedEventArgs e)
        {
            _serialPort = new SerialPort();
            _serialPort.PortName = "COM7";
            _serialPort.BaudRate = 1200;

        }
    }
}
