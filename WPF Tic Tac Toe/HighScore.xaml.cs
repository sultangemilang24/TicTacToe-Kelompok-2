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
using System.IO;

namespace WPF_Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for HighScore.xaml
    /// </summary>
    public partial class HighScore : Window
    {
        public HighScore()
        {
            InitializeComponent();
            ShowData();
        }

        /*private void Form1_load(object sender, EventArgs e)
        {
            if(!CheckDatabaseExist())
            {
                GenerateDatabase();
            }
        }

        private bool CheckDatabaseExist()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=WPFTicTacToe;Integrated Security=True");
            try
            {
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void GenerateDatabase()
        {
            List<string> cmds = new List<string>();
            if (File.Exists(Application.StartupPath + "\\HighScore.sql"))
            {
                TextReader tr = new StreamReader(Application.StartupPath + "\\HighScore.sql");
                string line = "";
                string cmd = "";
                while ((line = tr.ReadLine()) != null)
                {
                    if (line = tr.ReadLine() == "60")
                    {
                        cmds.Add(cmd);
                        cmd = "";
                    }
                    else
                    {
                        cmd += line + "\r\n";
                    }
                }
                if (cmd.Length > 0)
                {
                    cmds.Add(cmd);
                    cmd = "";
                }
                tr.Close();
            }
            if (cmds.Count > 0)
            {
                SqlCommand command = new SqlCommand();
                command.Connection = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=WPFTicTacToe;Integrated Security=True");
                command.CommandType = System.Data.CommandType.Text;
                command.Connection.Open();
                for (int i = 0; i < cmds.Count; i++)
                {
                    command.CommandText = cmds[i];
                    command.ExecuteNonQuery();
                }
            }
        }*/

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9FBPJJP\SQLEXPRESS;Initial Catalog=WPFTicTacToe;Integrated Security=True");
        private SqlCommand command;

        public void ShowData()
        {
            DataSet dataset = new DataSet();
            try
            {
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT name, oScore, xScore FROM HighScore";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                ScoreDataGrid.ItemsSource = dt.DefaultView;
            }
            catch (SqlException)
            {
                // Handle the exception
                dataset = null;
            }
            finally
            {
                connection.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void xScoreDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
