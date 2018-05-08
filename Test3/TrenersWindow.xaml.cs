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
    public partial class TrenersWindow : Window
    {
        Model1 db;
        public TrenersWindow()
        {
            InitializeComponent();

            db = new Model1();
            db.TRENER.Load(); // загружаем данные
            trenerGrid.ItemsSource = db.TRENER.Local.ToBindingList(); // устанавливаем привязку к кэшу

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
            if (trenerGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < trenerGrid.SelectedItems.Count; i++)
                {
                    TRENER trener = trenerGrid.SelectedItems[i] as TRENER;
                    if (trener != null)
                    {
                        db.TRENER.Remove(trener);
                    }
                }
            }
            db.SaveChanges();
        }
    }
}
