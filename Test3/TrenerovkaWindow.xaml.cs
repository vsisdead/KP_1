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
    public partial class TrenerovkaWindow : Window
    {
        Model1 db;
        public TrenerovkaWindow()
        {
            InitializeComponent();

            db = new Model1();
            db.TRENEROVKA.Load(); // загружаем данные
            trenerovkaGrid.ItemsSource = db.TRENEROVKA.Local.ToBindingList(); // устанавливаем привязку к кэшу

            this.Closing += TrenersWindow_Closing;
        }

        private void TrenersWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (trenerovkaGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < trenerovkaGrid.SelectedItems.Count; i++)
                {
                    TRENEROVKA trenerovka = trenerovkaGrid.SelectedItems[i] as TRENEROVKA;
                    if (trenerovka != null)
                    {
                        db.TRENEROVKA.Remove(trenerovka);
                    }
                }
            }
            db.SaveChanges();
        }
    }
}
