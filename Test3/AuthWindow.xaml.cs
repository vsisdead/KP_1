using System.Linq;
using System.Windows;
using System.Windows.Input;
using Test3.Models;
using Test3.ForUsers;
using System;

namespace Test3
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        //Model1 db;
        public AuthWindow()
        {
            InitializeComponent();
            //using (Model1 db = new Model1())
            //{
            //    USERS users = new USERS();
            //    users.USERNAME = "administrator";
            //    users.ROLE = "Администратор";
            //    string upass = "administrator";
            //    users.PASS = upass.GetHashCode().ToString();
            //    users.STATUS = 1;
            //    db.USERS.Add(users);
            //    db.SaveChanges();
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (Model1 db = new Model1())
            {
                string username = textBoxLog.Text;
                string password = passwordBox.Password.GetHashCode().ToString();

                var user = db.USERS.FirstOrDefault(u => u.USERNAME.Equals(username) && u.PASS.Equals(password));
                if (user == null)
                {

                    validate.Visibility = Visibility.Visible;
                    textBoxLog.Clear();
                    passwordBox.Clear();
                    return;
                }
                if (user.STATUS == -1)
                {
                    MessageBox.Show("Ваша заявка отклонена", "Error", MessageBoxButton.OK, MessageBoxImage.Error); //error window
                    textBoxLog.Clear();
                    passwordBox.Clear();
                    return;
                }
                if (user.STATUS == 0)
                {
                    MessageBox.Show("Ожидайте подтверждения администратора.", "Error", MessageBoxButton.OK, MessageBoxImage.Error); //error window
                    textBoxLog.Clear();
                    passwordBox.Clear();
                    return;
                }
                if (user.ROLE == "Администратор")
                {
                    MainWindow mainWindow = new MainWindow(user.ROLE + " " + user.USERNAME);
                    mainWindow.Show();
                    this.Close();
                }
                if (user.ROLE == "Доктор")
                {
                    DoctorMainWindow doctormainWindow = new DoctorMainWindow(user.ROLE + " " + user.USERNAME); // with label in doctormainwindow
                    doctormainWindow.Show();
                    this.Close();
                }
                if (user.ROLE == "Тренер")
                {
                    TrenersMainWindow trenersmainWindow = new TrenersMainWindow(user.ROLE + " " + user.USERNAME);
                    trenersmainWindow.Show();
                    this.Close();
                }
                if (user.ROLE == "Спортсмен")
                {
                    SportsmenMainWindow sportsmenmainWindow = new SportsmenMainWindow(user.ROLE + " " + user.USERNAME);
                    sportsmenmainWindow.Show();
                    this.Close();
                }
            }
        }


        private void ButtonClick_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(sender, e);
            }
        }

        private void registrButton_Click(object sender, RoutedEventArgs e)
        {
            RegisrtWindow registrWindow = new RegisrtWindow();
            registrWindow.Show();
        }
    }
}
