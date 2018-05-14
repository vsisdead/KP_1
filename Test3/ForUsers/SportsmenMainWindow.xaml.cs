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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test3.Models;
using Test3.ForUsers;

namespace Test3.ForUsers
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class SportsmenMainWindow : Window
    {
        Model1 db;
        public SportsmenMainWindow(string userinfo)
        {
            InitializeComponent();
            label1.Header = userinfo + ":";
            db = new Model1();
            db.TRENER.Load();
            db.SPORTSMENS.Load();
            db.TRENEROVKA.Load();
            db.SOSTAV.Load();
            db.DOCTOR.Load();
            db.OSMOTR.Load();
            doctorGrid.ItemsSource = db.DOCTOR.Local.ToBindingList();
            osmotrGrid.ItemsSource = db.OSMOTR.Local.ToBindingList();
            sostavGrid.ItemsSource = db.SOSTAV.Local.ToBindingList();
            trenerovkaGrid.ItemsSource = db.TRENEROVKA.Local.ToBindingList();
            trenerGrid.ItemsSource = db.TRENER.Local.ToBindingList();
            sportsmenGrid.ItemsSource = db.SPORTSMENS.Local.ToBindingList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddSportsmenWindow addsportsmenWindow = new AddSportsmenWindow();
            addsportsmenWindow.Show();
            //db.SaveChanges();
            db.SPORTSMENS.Load();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            db.SPORTSMENS.Load();
        }

        private void findButton_Click(object sender, RoutedEventArgs e)
        {
            using (Model1 db = new Model1())
            {
                try
                {
                    if (textBoxFind.Text != null)
                    {
                        string uname = textBoxFind.Text;
                        sportsmenGrid.ItemsSource = db.SPORTSMENS.Where(p => p.SPORTSMEN_FAMIL == uname).ToList();
                    }
                    if (textBoxFind.Text == "")
                    {
                        sportsmenGrid.ItemsSource = db.SPORTSMENS.ToList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void updateButton_Click1(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            db.SPORTSMENS.Load();
        }

        private void findButton_Click1(object sender, RoutedEventArgs e)
        {
            using (Model1 db = new Model1())
            {
                try
                {
                    if (textBoxFind1.Text != null)
                    {
                        string uname = textBoxFind1.Text;
                        trenerGrid.ItemsSource = db.TRENER.Where(p => p.TRENER_FAMIL == uname).ToList();
                    }
                    if (textBoxFind1.Text == "")
                    {
                        trenerGrid.ItemsSource = db.TRENER.ToList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void updateButton_Click2(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            db.DOCTOR.Load();
        }

        private void findButton_Click2(object sender, RoutedEventArgs e)
        {
            using (Model1 db = new Model1())
            {
                try
                {
                    if (textBoxFind2.Text != null)
                    {
                        string uname = textBoxFind2.Text;
                        doctorGrid.ItemsSource = db.DOCTOR.Where(p => p.DOCTOR_FAMIL == uname).ToList();
                    }
                    if (textBoxFind2.Text == "")
                    {
                        doctorGrid.ItemsSource = db.DOCTOR.ToList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Powered by Vadim Samtsov, BSTU (c) 2018");
        }

        private void updateButton_Click3(object sender, RoutedEventArgs e)
        {
            db.TRENEROVKA.Load();
            db.OSMOTR.Load();
            db.SOSTAV.Load();
        }
    }
}
