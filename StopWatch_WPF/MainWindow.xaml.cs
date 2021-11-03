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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Diagnostics;

namespace StopWatch_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dt = new DispatcherTimer();
        Stopwatch st = new Stopwatch();
        string currentTime = string.Empty;
        
        
        public MainWindow()
        {
            
            
            InitializeComponent();
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0,0,0,0);
        }

        private void dt_Tick(object sender, EventArgs e)
        {
            if(st.IsRunning)
            {
                TimeSpan time = st.Elapsed;
                currentTime = String.Format("{0:00}: {1:00}: {2:00}", time.Minutes, time.Seconds, time.Milliseconds);
                clocktxtblock.Text = currentTime;
            }
        }

        private void startbtn_Click(object sender, RoutedEventArgs e)
        {
            st.Start();
            dt.Start();
        }

        private void stopbtn_Click(object sender, RoutedEventArgs e)
        {
            if (st.IsRunning)
            {
                st.Stop();

                elapsedtimeitem.Items.Add(currentTime);
            }
            
        }

        private void resetbtn_Click(object sender, RoutedEventArgs e)
        {
            st.Reset();
            clocktxtblock.Text = string.Empty;
            
        }

        private void clearbtn_Click(object sender, RoutedEventArgs e)
        {
            elapsedtimeitem.Items.Clear();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
            
        }

        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void drag_click(object sender, MouseButtonEventArgs e)
        {
            Application.Current.MainWindow.DragMove();
        }
    }
}
