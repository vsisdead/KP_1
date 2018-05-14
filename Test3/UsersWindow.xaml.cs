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
    /// Логика взаимодействия для UsersWindow.xaml
    /// </summary>
    public partial class UsersWindow : Window
    {
        Model1 db;
        public UsersWindow()
        {
            InitializeComponent();

            db = new Model1();
            db.USERS.Load(); // загружаем данные
            usersGrid.ItemsSource = db.USERS.Local.ToBindingList(); // устанавливаем привязку к кэшу
            this.Closing += UsersWindow_Closing;
            comboBox1.Items.Add("Администратор");
            comboBox1.Items.Add("Спортсмен");
            comboBox1.Items.Add("Тренер");
            comboBox1.Items.Add("Доктор");

        }
        private void UsersWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            db.USERS.Load();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (usersGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < usersGrid.SelectedItems.Count; i++)
                {
                    USERS users = usersGrid.SelectedItems[i] as USERS;
                    if (users != null)
                    {
                        db.USERS.Remove(users);
                    }
                }
            }
            db.SaveChanges();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            using (Model1 db = new Model1())
            {
                USERS users = new USERS();
                users.ROLE = comboBox1.Text;
                users.USERNAME = textBoxLog.Text;
                users.PASS = passwordBox.Password;
                users.ID = Convert.ToInt32(textBoxID.Text);

                db.USERS.Add(users);
                try
                {
                    
                    db.SaveChanges();
                    MessageBox.Show("Добавлен новый пользователь " + users.USERNAME);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //this.Close();
                }
            }
            textBoxID.Clear();
            textBoxLog.Clear();
            passwordBox.Clear();
            db.USERS.Load();
        }

        private void findButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBoxLog.Text != null)
                {
                    string uname = textBoxLog.Text;
                    usersGrid.ItemsSource = db.USERS.Where(p => p.USERNAME == uname).ToList();
                }
                if(textBoxLog.Text == "")
                {
                    usersGrid.ItemsSource = db.USERS.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
    }
}
   