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
    public partial class AddTrenerWindow : Window
    {
        Model1 db;
        public AddTrenerWindow()
        {
            InitializeComponent();
            db = new Model1();
            db.TRENER.Load(); // загружаем данные
            ////doctorGrid.ItemsSource = db.DOCTOR.Local.ToBindingList(); // устанавливаем привязку к кэшу
            comboBox1.Items.Add("Беговая");
            comboBox1.Items.Add("Игровая");
            comboBox1.Items.Add("Плавание");
            comboBox1.Items.Add("Теоретическая");
            comboBox1.Items.Add("Тренажерная");
        }

        private void addtrenerButton_Click(object sender, RoutedEventArgs e)
        {
            using (Model1 db = new Model1())
            {
                try
                {
                    TRENER trener = new TRENER();
                    trener.TRENER_FAMIL = textBoxFamil.Text;
                    trener.TRENER_NAME = textBoxName.Text;
                    trener.TRENER_MIDDLE = textBoxMiddle.Text;
                    trener.TRENEROVKA_NAME = comboBox1.Text;
                    trener.USER_ID = Convert.ToInt32(textBoxID.Text);

                    db.TRENER.Add(trener);


                    db.SaveChanges();
                    MessageBox.Show("Добавлен новый пользователь " + trener.TRENER_FAMIL + " " + trener.TRENER_NAME);
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
            db.TRENER.Load();
        }
    }
}

