﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Test3.Models;


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
            db.TRENER.Load();
            db.SPORTSMENS.Load();
            db.TRENEROVKA.Load();
            db.SOSTAV.Load();
            db.DOCTOR.Load();
            db.OSMOTR.Load();
            doctorGrid.ItemsSource = db.DOCTOR.Local.ToBindingList();
            osmotrGrid.ItemsSource = db.OSMOTR.Local.ToBindingList();
            sostavGrid1.ItemsSource = db.SOSTAV.Local.ToBindingList();
            
            sportsmenGrid.ItemsSource = db.SPORTSMENS.Local.ToBindingList();
            sportsmenGrid1.ItemsSource = db.SPORTSMENS.Local.ToBindingList();
            comboBox1.Items.Add("Все");
            comboBox1.Items.Add("Основной");
            comboBox1.Items.Add("Дублирующий");
            comboBox1.Items.Add("Молодежный");
            comboBox1.Items.Add("Юношеский");
            comboBox1.Items.Add("Детский");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            UsersWindow usersWindow = new UsersWindow();
            //usersWindow.Owner = this;
            usersWindow.Show();
        }


        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Approve approve = new Approve();
            approve.Show();

        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.SaveChanges();
                db.SPORTSMENS.Load();
                sportsmenGrid.ItemsSource = db.SPORTSMENS.Local.ToBindingList();

            }
            catch (Exception)
            {

                MessageBox.Show("Введены неверные данные.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                //db.SPORTSMENS.Load();
                sportsmenGrid.ItemsSource = db.SPORTSMENS.Local.ToBindingList();

            }
        }

        private void updateButton_Click2(object sender, RoutedEventArgs e)
        {
            try
            {
                db.SaveChanges();
                db.DOCTOR.Load();
                
                //doctorGrid.ItemsSource = db.DOCTOR.Local.ToBindingList();

            }
            catch (Exception)
            {
                MessageBox.Show("Введены неверные данные.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                doctorGrid.ItemsSource = db.DOCTOR.Local.ToBindingList();
            }
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
                //db.TRENEROVKA.Load();
                db.OSMOTR.Load();
                osmotrGrid.ItemsSource = db.OSMOTR.Local.ToBindingList();


            }
            catch (Exception)
            {
                MessageBox.Show("Введены неверные данные.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                osmotrGrid.ItemsSource = db.OSMOTR.Local.ToBindingList();
                //trenerovkaGrid.ItemsSource = db.TRENEROVKA.ToList();
            }
        }

        private void MouseDouble_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                SOSTAV sostav = sostavGrid1.SelectedItem as SOSTAV;
                string sost = sostav.SOSTAV_NAME;
                sportsmenGrid1.ItemsSource = db.SPORTSMENS.Where(u => u.SOSTAV_NAME.StartsWith(sost)).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Выбрана пустая строка.");
            }
        }
        private void updateButton_Click4(object sender, RoutedEventArgs e)
        {
            try
            {
                db.SaveChanges();
                db.SPORTSMENS.Load();
                db.SOSTAV.Load();
                //sostavGrid1.ItemsSource = db.SOSTAV.Local.ToBindingList();
                //sportsmenGrid1.ItemsSource = db.SPORTSMENS.Local.ToBindingList();
                
            }
            catch (Exception)
            {
                MessageBox.Show("Введены неверные данные.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                sostavGrid1.ItemsSource = db.SOSTAV.Local.ToBindingList();
                sportsmenGrid1.ItemsSource = db.SPORTSMENS.Local.ToBindingList();
            }
        }

        private void textBoxFind_TextChanged(object sender, TextChangedEventArgs e)
        {
            string uname = textBoxFind.Text;
            sportsmenGrid.ItemsSource = db.SPORTSMENS.Where(p => p.SPORTSMEN_FAMIL.StartsWith(uname)).ToList();

        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Object selectedItem = comboBox1.SelectedItem;
            string sname = selectedItem.ToString();
            if (sname == "Все")
            {
                sportsmenGrid.ItemsSource = db.SPORTSMENS.Local.ToBindingList();
            }
            else
            {
                sportsmenGrid.ItemsSource = db.SPORTSMENS.Where(p => p.SOSTAV_NAME.StartsWith(sname)).ToList();
            }
        }

       

        private void textBoxFind2_TextChanged(object sender, TextChangedEventArgs e)
        {
            string uname = textBoxFind2.Text;
            doctorGrid.ItemsSource = db.DOCTOR.Where(p => p.DOCTOR_FAMIL.StartsWith(uname)).ToList();
        }


    }
}
