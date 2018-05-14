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

namespace Test3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model1 db;
        public MainWindow(string userinfo)
        {
            InitializeComponent();
            label1.Header = userinfo;
            label1.Header = userinfo + ":";
            db = new Model1();
            db.DOCTOR.Load();
            db.SPORTSMENS.Load();
            db.OSMOTR.Load();
            db.SOSTAV.Load();
            //sostavGrid.ItemsSource = db.SOSTAV.Local.ToBindingList();
            //osmotrGrid.ItemsSource = db.OSMOTR.Local.ToBindingList();
            doctorGrid.ItemsSource = db.DOCTOR.Local.ToBindingList();
            sportsmenGrid.ItemsSource = db.SPORTSMENS.Local.ToBindingList();
            trenerovkaGrid.ItemsSource = db.DOCTOR.Local.ToBindingList();
            trenerGrid.ItemsSource = db.TRENER.Local.ToBindingList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddDoctorWindow adddoctorWindow = new AddDoctorWindow();
            adddoctorWindow.Show();
            //db.SaveChanges();
            db.DOCTOR.Load();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            db.DOCTOR.Load();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (doctorGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < doctorGrid.SelectedItems.Count; i++)
                {
                    DOCTOR doctor = doctorGrid.SelectedItems[i] as DOCTOR;
                    if (doctor != null)
                    {
                        db.DOCTOR.Remove(doctor);
                    }
                }
            }
            db.SaveChanges();
        }
        private void addButton_Click1(object sender, RoutedEventArgs e)
        {
            AddSportsmenWindow addsportsmenWindow = new AddSportsmenWindow();
            addsportsmenWindow.Show();
            //db.SaveChanges();
            db.SPORTSMENS.Load();
            //AddSportsmenWindow = addsportsmenWindow = new AddSportsmenWindow();
            //addsportsmenwindow.Show();
        }

        private void updateButton_Click1(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            db.SPORTSMENS.Load();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Powered by Vadim Samtsov, BSTU (c) 2018");
        }


        private void deleteButton_Click1(object sender, RoutedEventArgs e)
        {
            if (sportsmenGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < sportsmenGrid.SelectedItems.Count; i++)
                {
                    SPORTSMENS sportsmen = sportsmenGrid.SelectedItems[i] as SPORTSMENS;
                    if (sportsmen != null)
                    {
                        db.SPORTSMENS.Remove(sportsmen);
                    }
                }
            }
            db.SaveChanges();
        }

        private void addButton_Click2(object sender, RoutedEventArgs e)
        {
            AddTrenerWindow addtrenerWindow = new AddTrenerWindow();
            addtrenerWindow.Show();
            //db.SaveChanges();
            db.TRENER.Load();
        }

        private void updateButton_Click2(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            db.TRENER.Load();
        }

        private void deleteButton_Click2(object sender, RoutedEventArgs e)
        {
            if (trenerGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < trenerGrid.SelectedItems.Count; i++)
                {
                    TRENER trener = trenerGrid.SelectedItems[i] as TRENER;
                    if (trener != null)
                    {
                        db.TRENER.Remove(trener);
                    }
                }
            }
            db.SaveChanges();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            UsersWindow usersWindow = new UsersWindow();
            //usersWindow.Owner = this;
            usersWindow.Show();
        }
        private void trenerGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TRENER path = trenerGrid.SelectedItem as TRENER;
            MessageBox.Show(" ID: " + path.USER_ID);

            textBox1.Text = Convert.ToString(path.USER_ID); // Вывод в текстбокс
        
        }

        private void findButton_Click2(object sender, RoutedEventArgs e)
        {
            using (Model1 db = new Model1())
            {
                try
                {
                    if (textBox1.Text != null)
                    {
                        string uname = textBox1.Text;
                        trenerGrid.ItemsSource = db.TRENER.Where(p => p.TRENER_FAMIL == uname).ToList();
                    }
                    if (textBox1.Text == "")
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
    }
}