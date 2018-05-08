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

namespace Test3.ForUsers
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class DoctorMainWindow : Window
    {
        public DoctorMainWindow()
        {
            InitializeComponent();

        }
        public static int log;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SostavWindow sostavWindow = new SostavWindow();
            sostavWindow.Show();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SportsmensWindow sportsmensWindow = new SportsmensWindow();
            sportsmensWindow.Show();
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            DoctorsWindow doctorsWindow = new DoctorsWindow();
            doctorsWindow.Show();
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            OsmotrWindow osmotrWindow = new OsmotrWindow();
            osmotrWindow.Show();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }
    }
}
