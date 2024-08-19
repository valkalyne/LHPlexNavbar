using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;





namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);

        [DllImport("user32.dll")]
        static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Toolbar window = new Toolbar();
            window.ShowActivated = true;
            HwndSourceParameters parameters = new HwndSourceParameters();
            parameters.WindowStyle = 0x10000000 | 0x40000000;
            parameters.SetPosition(0, 0);
            parameters.SetSize((int)window.Width, (int)window.Height);
            var explorerwindow = FindWindow("CabinetWClass", null);
            parameters.ParentWindow = explorerwindow;
            parameters.UsesPerPixelOpacity = true;
            HwndSource src = new HwndSource(parameters);
            src.CompositionTarget.BackgroundColor = Colors.Transparent;
            src.RootVisual = (Visual)window.Content;
            var navbar = FindWindowEx(explorerwindow, 0, "WorkerW", null);
            SetWindowLong(navbar, -16, 0x46000000);
            Show();
            
        }
    }
}
