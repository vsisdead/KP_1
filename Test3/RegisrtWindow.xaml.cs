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
using Test3.Models;

namespace Test3
{
    /// <summary>
    /// Логика взаимодействия для RegisrtWindow.xaml
    /// </summary>
    public partial class RegisrtWindow : Window
    {
        Model1 db;
        public RegisrtWindow()
        {
            InitializeComponent();
            db = new Model1();
            db.USERS.Load(); 
            comboBox1.Items.Add("Спортсмен");
            comboBox1.Items.Add("Тренер");
            comboBox1.Items.Add("Доктор");
        }

        private void registrButton_Click(object sender, RoutedEventArgs e)
        {
            using (Model1 db = new Model1())
            {
                validate.Visibility = Visibility.Hidden;
                
                if (textBoxLog.Text == "" || passwordBox.Password != passwordBox1.Password)
                {
                    validate.Visibility = Visibility.Visible;
                    textBoxLog.Clear();
                    passwordBox.Clear();
                    passwordBox1.Clear();
                    return;
                }
                else
                {
                    try
                    {
                        USERS users = new USERS();
                        users.USERNAME = textBoxLog.Text;
                        users.PASS = passwordBox.Password.GetHashCode().ToString();
                        users.ROLE = comboBox1.Text;
                        users.STATUS = 0;
                        db.USERS.Add(users);
                        db.SaveChanges();
                        MessageBox.Show("Ожидайте подтверждение администратора " + users.USERNAME);
                        this.Close();

                    }
                    catch (Exception)
                    {
                        validate.Visibility = Visibility.Visible;
                        textBoxLog.Clear();
                        passwordBox.Clear();
                        passwordBox1.Clear();
                    }
                }
            }
        }
    }
}
