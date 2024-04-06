using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace process2
{
    public partial class MainWindow : Window
    {
        private Process _process;
        private DateTime _startTime;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LaunchProcess_Click(object sender, RoutedEventArgs e)
        {
            _process = new Process();
            _process.StartInfo.FileName = "cmd.exe"; 
            _process.StartInfo.Arguments = "/c tasklist /FI \"IMAGENAME eq svchost.exe\""; 
            _process.StartInfo.UseShellExecute = false;
            _process.StartInfo.RedirectStandardOutput = true;
            _process.EnableRaisingEvents = true;
            _process.OutputDataReceived += Process_OutputDataReceived;
            _process.Exited += Process_Exited;

            _startTime = DateTime.Now;

            _process.Start();
            _process.BeginOutputReadLine();
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                Dispatcher.Invoke(() =>
                {
                    ProcessRuntimeTextBlock.Text += e.Data + "\n";
                });
            }
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            TimeSpan runtime = DateTime.Now - _startTime;
            Dispatcher.Invoke(() =>
            {
                ProcessRuntimeTextBlock.Text += $"Процесс завершен. Время выполнения: {runtime.TotalSeconds} секунд";
            });
        }
    }
}
