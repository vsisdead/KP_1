using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using Test3.Models;
using Test3.ForUsers;

namespace Test3
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();           
        }
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (Model1 db = new Model1())
            {
                string username = textBoxLog.Text;
                string password = passwordBox.Password;                                
                var user = db.USERS.FirstOrDefault(u => u.USERNAME.Equals(username) && u.PASS.Equals(password));
                // куча ифов
                if (user == null)
                {
                    MessageBox.Show("Неверный логин или пароль.", "Error", MessageBoxButton.OK, MessageBoxImage.Error); //error window
                    textBoxLog.Clear();
                    passwordBox.Clear();
                    return;
                }
                if (user.ROLE  == "Администратор")
                {
                    MainWindow mainWindow = new MainWindow(user.ROLE + " " + user.USERNAME + " ID: " + user.ID);
                    mainWindow.Show();
                    this.Close();
                }
                if (user.ROLE == "Доктор")
                {
                    DoctorMainWindow doctormainWindow = new DoctorMainWindow(user.ROLE + " " + user.USERNAME + " ID: " + user.ID); // with label in doctormainwindow
                    doctormainWindow.Show();
                    this.Close();
                }
                if (user.ROLE == "Тренер")
                {
                    TrenersMainWindow trenersmainWindow = new TrenersMainWindow(user.ROLE + " " + user.USERNAME + " ID: " + user.ID);
                    trenersmainWindow.Show();
                    this.Close();
                }
                if (user.ROLE == "Спортсмен")
                {
                    SportsmenMainWindow sportsmenmainWindow = new SportsmenMainWindow(user.ROLE + " " + user.USERNAME + " ID: " + user.ID);
                    sportsmenmainWindow.Show();
                    this.Close();
                }

                //MessageBox.Show(user.ID + " authenticated");
            }


        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            textBoxLog.Clear();
            passwordBox.Clear();
        }
        private void ButtonClick_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(sender, e);
            }
        }
    }
}
