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


namespace Test3
{
    /// <summary>
    /// Логика взаимодействия для Approve.xaml
    /// </summary>
    public partial class Approve : Window
    {
        public Approve()
        {
            InitializeComponent();
            IEnumerable<USERS> U;
            using (Model1 UnApproveUser = new Model1())
            {
                U = from T in UnApproveUser.USERS
                    where T.STATUS == 0
                    select T;

                foreach (USERS T in U)
                {
                    Border border = new Border();
                    border.BorderThickness = new Thickness(0, 0, 0, 1);
                    border.BorderBrush = new SolidColorBrush(Colors.DarkBlue);
                    Grid Y = new Grid();
                    Y.Height = 50;
                    
                    
                    All.Children.Add(border);
                    Label username = new Label();
                    Label role = new Label();
                    
                    
                    username.Content = T.USERNAME;
                    role.Content = T.ROLE;
                  
                    username.HorizontalContentAlignment = HorizontalAlignment.Center;
                    role.HorizontalContentAlignment = HorizontalAlignment.Center;
                 
                    username.Padding = new Thickness(0);
                    role.Padding = new Thickness(0);
                   
                    username.FontSize = 14;
                    role.FontSize = 14;
                 
                    username.Width = 245;
                    role.Width = 245;
                   
                    username.Foreground = new SolidColorBrush(Colors.Black);
                    role.Foreground = new SolidColorBrush(Colors.Black);
                    
                    username.HorizontalAlignment = HorizontalAlignment.Left;
                    role.HorizontalAlignment = HorizontalAlignment.Left;
                   
                    username.Margin = new Thickness(3, 2, 0, 0);
                    role.Margin = new Thickness(3, 14, 0, 0);
                    
                    Button Accept = new Button();
                    Button Cancel = new Button();
                    Accept.Name = "Accept" + T.USERNAME;
                    Cancel.Name = "Cancel" + T.USERNAME;
                    Accept.HorizontalAlignment = HorizontalAlignment.Left;
                    Cancel.HorizontalAlignment = HorizontalAlignment.Left;
                    Accept.Height = 25;
                    Cancel.Height = 25;
                  
                    Accept.Width = 27;
                    Cancel.Width = 27;
                    Accept.VerticalAlignment = VerticalAlignment.Top;
                    Cancel.VerticalAlignment = VerticalAlignment.Top;
                    Accept.ToolTip = "Одобрить регистрацию";
                    Cancel.ToolTip = "Отклонить регистрацию";
                    Accept.Content = "+";
                    Cancel.Content = "-";
                    Accept.Click += AcceptUserName;
                    Cancel.Click += CancelUserName;
                    Accept.BorderThickness = new Thickness(0);
                    Cancel.BorderThickness = new Thickness(0);
                    Accept.Margin = new Thickness(248, 0, 0, 0);
                    Cancel.Margin = new Thickness(248, 25, 0, 0);
                   
                   
                    border.Child = Y;
                    Y.Children.Add(username);
                    Y.Children.Add(role);
                   
                    Y.Children.Add(Accept);
                    Y.Children.Add(Cancel);
                }
            }

        }
        public void AcceptUserName(object sender, RoutedEventArgs e)
        {
            using (Model1 users = new Model1())
            {
                users.USERS.Find(((Button)sender).Name.ToString().Substring(6)).STATUS = 1;
                users.SaveChanges();
                this.Close();
                Approve approve = new Approve();
                approve.Show();

            }
        }
        public void CancelUserName(object sender, RoutedEventArgs e)
        {
            using (Model1 users = new Model1())
            {
                users.USERS.Find(((Button)sender).Name.ToString().Substring(6)).STATUS = -1;
                users.SaveChanges();
                this.Close();
                Approve approve = new Approve();
                approve.Show();
            }
        }
    }
}
