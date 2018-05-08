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
        }

        private void UsersWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
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

    }
}
