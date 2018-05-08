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
    public partial class SostavWindow : Window
    {
        Model1 db;
        public SostavWindow()
        {
            InitializeComponent();

            db = new Model1();
            db.SOSTAV.Load(); // загружаем данные
            sostavGrid.ItemsSource = db.SOSTAV.Local.ToBindingList(); // устанавливаем привязку к кэшу

            this.Closing += SostavWindow_Closing;
        }

        private void SostavWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (sostavGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < sostavGrid.SelectedItems.Count; i++)
                {
                    SOSTAV sostav = sostavGrid.SelectedItems[i] as SOSTAV;
                    if (sostav != null)
                    {
                        db.SOSTAV.Remove(sostav);
                    }
                }
            }
            db.SaveChanges();
        }
    }
}
