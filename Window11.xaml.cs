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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace авторизация_и_регистрация_буркин
{
    /// <summary>
    /// Логика взаимодействия для Window11.xaml
    /// </summary>
    public partial class Window11 : Window
    {
        String id;
        string connectionString;
        public Window11(String id = "")
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            this.id = id;
        }

        private void Load_table_txt_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                String query = "SELECT UserId, UserNumber, UserPassword, UserMail FROM Users";
                SqlCommand sqlCmd = new SqlCommand(query, connection);
                sqlCmd.CommandType = CommandType.Text;

                SqlDataAdapter dataApp = new SqlDataAdapter(sqlCmd);
                DataTable dt=new DataTable("Users");
                dataApp.Fill(dt);
                UsersGrid.ItemsSource = dt.DefaultView;
                dataApp.Update(dt);


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
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            string idDel = Idbox.Text;
            MessageBoxResult result = MessageBox.Show("Удалить пользователя?", "Удаление данных",
         MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {

                SqlConnection connection = null;
                try
                {

                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    String query = "DELETE FROM Users WHERE UserId = @UserId";

                    SqlCommand sqlCmd = new SqlCommand(query, connection);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@UserId", idDel);

                    sqlCmd.ExecuteReader();

                   
                    MessageBox.Show("Пользователь удален из БД");



                }

                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }
        }

        private void Idbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
