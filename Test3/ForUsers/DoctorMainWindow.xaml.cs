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
    public partial class DoctorMainWindow : Window
    {
        Model1 db;
        public DoctorMainWindow(string userinfo)
        {
            InitializeComponent();
            label1.Header = userinfo + ":";
            db = new Model1();
            db.DOCTOR.Load(); 
            db.SPORTSMENS.Load();
            db.OSMOTR.Load();
            db.SOSTAV.Load();
            sostavGrid.ItemsSource = db.SOSTAV.Local.ToBindingList();
            osmotrGrid.ItemsSource = db.OSMOTR.Local.ToBindingList(); 
            doctorGrid.ItemsSource = db.DOCTOR.Local.ToBindingList();
            sportsmenGrid.ItemsSource = db.SPORTSMENS.Local.ToBindingList();
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }
        //private void Button_Click7(object sender, RoutedEventArgs e)
        //{
        //    SostavWindow sostavWindow = new SostavWindow();
        //    sostavWindow.Show();
        //}

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

        //private void deleteButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (doctorGrid.SelectedItems.Count > 0)
        //    {
        //        for (int i = 0; i < doctorGrid.SelectedItems.Count; i++)
        //        {
        //            DOCTOR doctor = doctorGrid.SelectedItems[i] as DOCTOR;
        //            if (doctor != null)
        //            {
        //                db.DOCTOR.Remove(doctor);
        //            }
        //        }
        //    }
        //    db.SaveChanges();
        //}
        //private void addButton_Click1(object sender, RoutedEventArgs e)
        //{
        //    AddSportsmenWindow addsportsmenWindow = new AddSportsmenWindow();
        //    addsportsmenWindow.Show();
        //    //db.SaveChanges();
        //    db.SPORTSMENS.Load();
        //    //AddSportsmenWindow = addsportsmenWindow = new AddSportsmenWindow();
        //    //addsportsmenwindow.Show();
        //}

        private void updateButton_Click1(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            db.SPORTSMENS.Load();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Powered by Vadim Samtsov, BSTU (c) 2018");
        }

       

        private void updateButton_Click3(object sender, RoutedEventArgs e)
        {
            try
            {
                db.SaveChanges();
                db.OSMOTR.Load();
                db.SOSTAV.Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Введены неверные данные.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                osmotrGrid.ItemsSource = db.OSMOTR.ToList();
            }
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
                        doctorGrid.ItemsSource = db.DOCTOR.Where(p => p.DOCTOR_FAMIL == uname).ToList();
                    }
                    if (textBoxFind.Text == "")
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

        private void findButton_Click1(object sender, RoutedEventArgs e)
        {
            using (Model1 db = new Model1())
            {
                try
                {
                    if (textBoxFind1.Text != null)
                    {
                        string uname = textBoxFind1.Text;
                        sportsmenGrid.ItemsSource = db.SPORTSMENS.Where(p => p.SPORTSMEN_FAMIL == uname).ToList();
                    }
                    if (textBoxFind1.Text == "")
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


        //private void deleteButton_Click1(object sender, RoutedEventArgs e)
        //{
        //    if (sportsmenGrid.SelectedItems.Count > 0)
        //    {
        //        for (int i = 0; i < sportsmenGrid.SelectedItems.Count; i++)
        //        {
        //            SPORTSMENS sportsmen = sportsmenGrid.SelectedItems[i] as SPORTSMENS;
        //            if (sportsmen != null)
        //            {
        //                db.SPORTSMENS.Remove(sportsmen);
        //            }
        //        }
        //    }
        //    db.SaveChanges();
        //}
    }
}
