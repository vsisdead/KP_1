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
    public partial class OsmotrWindow : Window
    {
        Model1 db;
        public OsmotrWindow()
        {
            InitializeComponent();

            db = new Model1();
            db.OSMOTR.Load(); // загружаем данные
            osmotrGrid.ItemsSource = db.OSMOTR.Local.ToBindingList(); // устанавливаем привязку к кэшу

            this.Closing += OsmotrWindow_Closing;
        }

        private void OsmotrWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (osmotrGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < osmotrGrid.SelectedItems.Count; i++)
                {
                    OSMOTR osmotr = osmotrGrid.SelectedItems[i] as OSMOTR;
                    if (osmotr != null)
                    {
                        db.OSMOTR.Remove(osmotr);
                    }
                }
            }
            db.SaveChanges();
        }
    }
}
