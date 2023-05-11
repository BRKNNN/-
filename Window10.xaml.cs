using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Configuration;

namespace авторизация_и_регистрация_буркин
{
    /// <summary>
    /// Логика взаимодействия для Window10.xaml
    /// </summary>
    public partial class Window10 : Window
    {
        string connectionString;
        string id;

        string password;
        public Window10(string id)
        {
            InitializeComponent();
            this.id = id;


            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                String query = $"SELECT * FROM Users  WHERE  UserId LIKE '{id}'";
                SqlCommand sqlCmd = new SqlCommand(query, connection);
                sqlCmd.CommandType = CommandType.Text;
                var result = sqlCmd.ExecuteReader();

                if (result.HasRows)
                {

                    while (result.Read())
                    {
                        numberNewbox.Text = result.GetValue(1).ToString();
                        this.password = result.GetValue(2).ToString();
                        emailNewbox.Text = result.GetValue(3).ToString();

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

        private void Button_Edit_Info_click(object sender, RoutedEventArgs e)
        {
            string number = numberNewbox.Text.Trim();
            string oldPass = passOldbox.Password.Trim();
            string pass = passNewbox.Password.Trim();
            string email = emailNewbox.Text.ToLower().Trim();

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                String query = "UPDATE Users  SET UserNumber = @Number, UserPassword = @Pass, UserMail = @Mail WHERE UserId = @UserId";

                SqlCommand sqlCmd = new SqlCommand(query, connection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Number", number);
                sqlCmd.Parameters.AddWithValue("@Pass", pass);
                sqlCmd.Parameters.AddWithValue("@Mail", email);
                sqlCmd.Parameters.AddWithValue("@UserId", this.id);

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




            MessageBox.Show("Ваши данные изменены");


            Window1 window1 = new Window1();
            window1.Show();
            Hide();
        }
    }
}
