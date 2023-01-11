using System;
using System.Data.SqlClient;
using System.Collections.Generic;
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

namespace WPF_Tic_Tac_Toe
{
    public partial class Game_Page : Window
    {
        Game_Logic _GameLogic = new Game_Logic();
        private int xWinsCount = 0;
        private int oWinsCount = 0;
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9FBPJJP\SQLEXPRESS;Initial Catalog=WPFTicTacToe;Integrated Security=True");

        public Game_Page()
        {
            InitializeComponent();
        }

        private void PlayingClick(object sender, RoutedEventArgs e)
        {
            var bt = (Button)sender;
            if (!String.IsNullOrWhiteSpace(bt.Content?.ToString())) return;
            bt.Content = _GameLogic.CurrentPlayer;
            bt.IsEnabled = false;
            bt.Foreground = Brushes.Black;

            GameOver(bt.Content.ToString());

            _GameLogic.SetNextPlayer();

        }

        private void GameOver(string btnContent)
        {

            if((btn1.Content == btnContent & btn2.Content == btnContent & btn3.Content == btnContent) |
                (btn1.Content == btnContent & btn4.Content == btnContent & btn7.Content == btnContent) |
                (btn1.Content == btnContent & btn5.Content == btnContent & btn9.Content == btnContent) |
                (btn2.Content == btnContent & btn5.Content == btnContent & btn8.Content == btnContent) |
                (btn3.Content == btnContent & btn6.Content == btnContent & btn9.Content == btnContent) |
                (btn4.Content == btnContent & btn5.Content == btnContent & btn6.Content == btnContent) |
                (btn7.Content == btnContent & btn8.Content == btnContent & btn9.Content == btnContent) |
                (btn3.Content == btnContent & btn5.Content == btnContent & btn7.Content == btnContent))
            {
                if (btnContent == "X")
                {
                    xWinsCount++;
                    lbWinner.Content = "Player X Win!";
                    lbxWin.Content = $"{xWinsCount}";

                    lbWinner.Visibility = Visibility.Visible;
                    Wait1SecAndRestart();
                    ResetButton();
                }
                else if (btnContent == "O")
                {
                    oWinsCount++;
                    lbWinner.Content = "Player O Win!";
                    lboWin.Content = $"{oWinsCount}";

                    lbWinner.Visibility = Visibility.Visible;
                    Wait1SecAndRestart();
                    ResetButton();
                }
            }
            else if (!btn1.IsEnabled && !btn2.IsEnabled && !btn3.IsEnabled &&
                     !btn3.IsEnabled && !btn4.IsEnabled && !btn5.IsEnabled &&
                     !btn7.IsEnabled && !btn8.IsEnabled && !btn9.IsEnabled)
            {
                lbWinner.Content = "NO ONE WIN!";
                lbWinner.Visibility = Visibility.Visible;
                Wait1SecAndRestart();
                ResetButton();
            }
        }

        private async void Wait1SecAndRestart()
        {
            await Task.Delay(1000);
            lbWinner.Visibility = Visibility.Hidden;
        }

        private void ResetButton()
        {
            btn1.Content = "";
            btn1.IsEnabled = true;
            btn2.Content = "";
            btn2.IsEnabled = true;
            btn3.Content = "";
            btn3.IsEnabled = true;
            btn4.Content = "";
            btn4.IsEnabled = true;
            btn5.Content = "";
            btn5.IsEnabled = true;
            btn6.Content = "";
            btn6.IsEnabled = true;
            btn7.Content = "";
            btn7.IsEnabled = true;
            btn8.Content = "";
            btn8.IsEnabled = true;
            btn9.Content = "";
            btn9.IsEnabled = true;
        }

        private void btn_Setting_Click(object sender, RoutedEventArgs e)
        {
            Setting_Page setting_Page = new Setting_Page();
            setting_Page.Show();
            Close();
        }
        
        private void btn_Click_Back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Button_Click_NewGame(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you Sure to Restart the Game ?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                _GameLogic.NewGame();
                ResetButton();
                xWinsCount = 0;
                oWinsCount = 0;
                lbxWin.Content = $"{xWinsCount}";
                lboWin.Content = $"{oWinsCount}";
            }
            else return;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PlayerX_SaveGameScore.Content = xWinsCount;
            PlayerO_SaveGameScore.Content = oWinsCount;

            SaveMenu.Visibility = Visibility.Visible;

            btnBack.IsHitTestVisible = false;
            btnHighScore.IsHitTestVisible = false;
            btnSetting.IsHitTestVisible = false;
        }

        public bool IsValid()
        {
            if (XName.Text == String.Empty)
            {
                MessageBox.Show("Please Insert X Name!", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (OName.Text == String.Empty)
            {
                MessageBox.Show("Please Insert O Name!", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else return true;
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            if (IsValid())
            {
                connection.Open();
                if (xWinsCount > 0)
                {
                    SqlCommand insertX = new SqlCommand("INSERT INTO HighScore VALUES (@name, @xScore, NULL)", connection);
                    insertX.CommandType = CommandType.Text;
                    insertX.Parameters.AddWithValue("@name", XName.Text);
                    insertX.Parameters.AddWithValue("@xScore", xWinsCount);

                    insertX.ExecuteNonQuery();

                    if (oWinsCount > 0)
                    {
                        SqlCommand insertO = new SqlCommand("INSERT INTO HighScore VALUES (@name, NULL, @oScore)", connection);
                        insertO.CommandType = CommandType.Text;
                        insertO.Parameters.AddWithValue("@name", OName.Text);
                        insertO.Parameters.AddWithValue("@oScore", oWinsCount);

                        insertO.ExecuteNonQuery();
                    }

                    MessageBox.Show("Your score has ben Saved", "Succesfull", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else if (oWinsCount > 0)
                {
                    SqlCommand insertO = new SqlCommand("INSERT INTO HighScore VALUES (@name, NULL, @oScore)", connection);
                    insertO.CommandType = CommandType.Text;
                    insertO.Parameters.AddWithValue("@name", OName.Text);
                    insertO.Parameters.AddWithValue("@oScore", oWinsCount);
                                       
                    insertO.ExecuteNonQuery();

                    MessageBox.Show("Your score has ben Saved", "Succesfull", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Sorry, maybe we can't input your data because both of you dont have score", "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                connection.Close();

                SaveMenu.Visibility = Visibility.Hidden;

                XName.Clear();
                OName.Clear();

                btnBack.IsHitTestVisible = true;
                btnHighScore.IsHitTestVisible = true;
                btnSetting.IsHitTestVisible = true;

                ResetButton();
                _GameLogic.NewGame();

                xWinsCount = 0;
                oWinsCount = 0;
                lbxWin.Content = $"{xWinsCount}";
                lboWin.Content = $"{oWinsCount}";
            }
        }

        private void Button_Click_CencelSave(object sender, RoutedEventArgs e)
        {
            SaveMenu.Visibility = Visibility.Hidden;

            XName.Clear();
            OName.Clear();

            btnBack.IsHitTestVisible = true;
            btnHighScore.IsHitTestVisible = true;
            btnSetting.IsHitTestVisible = true;
        }
    }
}
