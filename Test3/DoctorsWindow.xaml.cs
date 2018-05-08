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
    /// Логика взаимодействия для SportsmensWindow.xaml
    /// </summary>
    public partial class DoctorsWindow : Window
    {
        Model1 db;
        public DoctorsWindow()
        {
            InitializeComponent();

            db = new Model1();
            db.DOCTOR.Load(); // загружаем данные
            doctorGrid.ItemsSource = db.DOCTOR.Local.ToBindingList(); // устанавливаем привязку к кэшу

            this.Closing += DoctorsWindow_Closing;
        }

        private void DoctorsWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
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
    }
}
