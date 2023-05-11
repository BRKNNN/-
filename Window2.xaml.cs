using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace авторизация_и_регистрация_буркин
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        string connectionString;

        public Window2()
        {

            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string number = numberbox.Text.Trim();
            string pass = passbox.Password.Trim();
            string email = emailbox.Text.ToLower().Trim();

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                String query = "INSERT INTO Users (UserNumber, UserPassword, UserMail) VALUES (@Number, @Pass, @Mail)";
                SqlCommand sqlCmd = new SqlCommand(query, connection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Number", number);
                sqlCmd.Parameters.AddWithValue("@Pass", pass);
                sqlCmd.Parameters.AddWithValue("@Mail", email);

                var result = sqlCmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }




            MessageBox.Show("Регистрация успешна!");


            Window1 window1 = new Window1();
            window1.Show();
            Hide();
        }




        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {


        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void ScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            Hide();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string number = numberbox.Text.Trim();
            string pass = passbox.Password.Trim();
            string email = emailbox.Text.ToLower().Trim();

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                String query = "INSERT INTO Admins (AdminNumber, AdminPassword, AdminMail) VALUES (@Number, @Pass, @Mail)";
                SqlCommand sqlCmd = new SqlCommand(query, connection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Number", number);
                sqlCmd.Parameters.AddWithValue("@Pass", pass);
                sqlCmd.Parameters.AddWithValue("@Mail", email);

                var result = sqlCmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }




            MessageBox.Show("Администратор добавлен");


            Window1 window1 = new Window1();
            window1.Show();
            Hide();
        }
    }
    
}
