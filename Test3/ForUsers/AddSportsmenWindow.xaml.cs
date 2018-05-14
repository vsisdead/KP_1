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
    public partial class AddSportsmenWindow : Window
    {
        Model1 db;
        public AddSportsmenWindow()
        {
            InitializeComponent();
            db = new Model1();
            db.SPORTSMENS.Load(); // загружаем данные
            ////doctorGrid.ItemsSource = db.DOCTOR.Local.ToBindingList(); // устанавливаем привязку к кэшу
            comboBox1.Items.Add("Основной");
            comboBox1.Items.Add("Дублирующий");
            comboBox1.Items.Add("Молодежный");
            comboBox1.Items.Add("Юношеский");
            comboBox1.Items.Add("Детский");
        }

        private void addsportsmensButton_Click(object sender, RoutedEventArgs e)
        {
            using (Model1 db = new Model1())
            {
                try
                {
                    SPORTSMENS sportsmen = new SPORTSMENS();
                    sportsmen.SPORTSMEN_FAMIL = textBoxFamil.Text;
                    sportsmen.SPORTSMEN_NAME = textBoxName.Text;
                    sportsmen.SPORTSMEN_MIDDLE = textBoxMiddle.Text;
                    sportsmen.SOSTAV_NAME = comboBox1.Text;
                    sportsmen.USER_ID = Convert.ToInt32(textBoxID.Text);

                    db.SPORTSMENS.Add(sportsmen);


                    db.SaveChanges();
                    MessageBox.Show("Добавлен новый пользователь " + sportsmen.SPORTSMEN_FAMIL + " " + sportsmen.SPORTSMEN_NAME);
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
            db.SPORTSMENS.Load();
        }
    }
}

