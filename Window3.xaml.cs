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
using System.Data.SqlClient;
using System.Configuration;

namespace авторизация_и_регистрация_буркин
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window4 frm = new Window4();
            frm.Show();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window5 frm = new Window5();
            frm.Show();
            Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window6 frm = new Window6();
            frm.Show();
            Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Window7 frm = new Window7();
            frm.Show();
            Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Window8 frm = new Window8();
            frm.Show();
            Close();
        }
    }
}
