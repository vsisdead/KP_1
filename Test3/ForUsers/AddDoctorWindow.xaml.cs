using System;
using System.Collections.Generic;
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
using System.Data.Entity;

namespace Test3.ForUsers
{
    /// <summary>
    /// Логика взаимодействия для AddDoctorWindow.xaml
    /// </summary>
    public partial class AddDoctorWindow : Window
    {
        Model1 db;
        public AddDoctorWindow()
        {
            InitializeComponent();
            db = new Model1();
            db.DOCTOR.Load(); // загружаем данные
            ////doctorGrid.ItemsSource = db.DOCTOR.Local.ToBindingList(); // устанавливаем привязку к кэшу
            comboBox1.Items.Add("Внеочередной");
            comboBox1.Items.Add("Переодический");
            comboBox1.Items.Add("Предварительный");
        }

        private void adddoctorButton_Click(object sender, RoutedEventArgs e)
        {
            using (Model1 db = new Model1())
            {
                try
                {
                    DOCTOR doctor = new DOCTOR();
                    doctor.DOCTOR_FAMIL = textBoxFamil.Text;
                    doctor.DOCTOR_NAME = textBoxName.Text;
                    doctor.DOCTOR_MIDDLE = textBoxMiddle.Text;
                    doctor.OSMOTR_NAME = comboBox1.Text;
                    doctor.USER_ID = Convert.ToInt32(textBoxID.Text);

                    db.DOCTOR.Add(doctor);


                    db.SaveChanges();
                    MessageBox.Show("Добавлен новый пользователь " + doctor.DOCTOR_FAMIL + " " + doctor.DOCTOR_NAME);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //this.Close();
                }



            }
            textBoxID.Clear();
            textBoxFamil.Clear();
            textBoxName.Clear();
            textBoxMiddle.Clear();
            db.DOCTOR.Load();
        }
    }
}

