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
    public partial class SportsmensWindow : Window
    {
        Model1 db;
        public SportsmensWindow()
        {
            InitializeComponent();

            db = new Model1();
            db.SPORTSMENS.Load(); // загружаем данные
            sportsmenGrid.ItemsSource = db.SPORTSMENS.Local.ToBindingList(); // устанавливаем привязку к кэшу

            this.Closing += SportsmensWindow_Closing;
        }

        private void SportsmensWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (sportsmenGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < sportsmenGrid.SelectedItems.Count; i++)
                {
                    SPORTSMENS sportsmens = sportsmenGrid.SelectedItems[i] as SPORTSMENS;
                    if (sportsmens != null)
                    {
                        db.SPORTSMENS.Remove(sportsmens);
                    }
                }
            }
            db.SaveChanges();
        }
    }
}
