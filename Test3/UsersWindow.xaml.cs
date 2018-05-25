using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
          

        }
        private void UsersWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.SaveChanges();
                db.USERS.Load();
                usersGrid.ItemsSource = db.USERS.Local.ToBindingList();

            }
            catch (Exception)
            {

                MessageBox.Show("Введены неверные данные.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                //db.SPORTSMENS.Load();
                usersGrid.ItemsSource = db.USERS.Local.ToBindingList();

            }

        }

        private void deleteClick(object sender, RoutedEventArgs e)
        {
            try
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
                usersGrid.ItemsSource = db.USERS.Local.ToBindingList();
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите строку и повторите.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                usersGrid.ItemsSource = db.USERS.Local.ToBindingList();

            }
        }


        private void textBoxFind_TextChanged(object sender, TextChangedEventArgs e)
        {
            string uname = textBoxFind.Text;
            usersGrid.ItemsSource = db.USERS.Where(p => p.ROLE.StartsWith(uname)).ToList();
        }

        
       
    }
}
   