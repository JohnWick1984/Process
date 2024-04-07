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
        private Process process;
        private DateTime startTime;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LaunchButton_Click(object sender, RoutedEventArgs e)
        {
            process = new Process();
            process.StartInfo.FileName = @"C:\\Users\\Евгений\\Documents\\Учеба Академия ТОР\\Системное программирование\\Process\\Process\\bin\\Debug\\net8.0\\Process.exe"; 
            process.EnableRaisingEvents = true;
            process.Exited += Process_Exited;

            startTime = DateTime.Now;
            process.Start();
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                TimeSpan duration = DateTime.Now - startTime;
                DurationTextBlock.Text = $"Продолжительность выполнения: {duration.TotalSeconds} секунд";
            });
        }
    }
}
