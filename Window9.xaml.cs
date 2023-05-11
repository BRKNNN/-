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
    /// Логика взаимодействия для Window9.xaml
    /// </summary>
    public partial class Window9 : Window
    {
        String id;
        string connectionString;
        public Window9(String id = "")
        {
            InitializeComponent();
            this.id = id;

            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void Button_Delite_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Удалить все данные?", "Удаление данных",
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
                    sqlCmd.Parameters.AddWithValue("@UserId", this.id);

                    sqlCmd.ExecuteReader();

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Hide();



                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            Window10 window10 = new Window10(this.id);
            window10.Show();
            Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window3 window3 = new Window3();
            window3.Show();
            Hide();
        }
    }
}
