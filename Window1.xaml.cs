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
using System.Data;

namespace авторизация_и_регистрация_буркин
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        String id;
        string connectionString;

        public Window1(String id = "")
        {
            InitializeComponent();
            this.id = id;

            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
        
        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string email = emailbox.Text.Trim();
            string pass = passbox.Password.Trim();

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                String query = $"SELECT * FROM Users  WHERE UserNumber LIKE '{email}' AND UserPassword LIKE '{pass}'";
                SqlCommand sqlCmd = new SqlCommand(query, connection);
                sqlCmd.CommandType = CommandType.Text;
                var result = sqlCmd.ExecuteReader();

                if (result.HasRows)
                {

                    while (result.Read())
                    {
                        String id = result.GetValue(0).ToString();

                        Window9 window9 = new Window9(id);
                        window9.Show();
                        Hide();
                    }

                }
                else
                {
                    MessageBox.Show("Пользователь не найден!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string email = emailbox.Text.Trim();
            string pass = passbox.Password.Trim();

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                String query = $"SELECT * FROM Admins  WHERE AdminNumber LIKE '{email}' AND AdminPassword LIKE '{pass}'";
                SqlCommand sqlCmd = new SqlCommand(query, connection);
                sqlCmd.CommandType = CommandType.Text;
                var result = sqlCmd.ExecuteReader();

                if (result.HasRows)
                {

                    while (result.Read())
                    {
                        String id = result.GetValue(0).ToString();

                        Window11 window11 = new Window11(id);
                        window11.Show();
                        Hide();
                    }

                }
                else
                {
                    MessageBox.Show("Пользователь не найден!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

        }


    }
}

