using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace WPF_Tic_Tac_Toe
{
    public partial class Game_Page : Window
    {
        Game_Logic _GameLogic = new Game_Logic();
        private int xWinsCount = 0;
        private int oWinsCount = 0;
        SqlConnection connection = new SqlConnection(@"Data Source=ADHITAMA;Initial Catalog=WPFTicTacToe;Integrated Security=True");

        DispatcherTimer _timerX;
        DispatcherTimer _timerO;
        TimeSpan _timeX;
        TimeSpan _timeO;

        string content = "X";

        bool TimesUp = false;

        public Game_Page()
        {
            InitializeComponent();

            _timeX = TimeSpan.FromSeconds(4);

            _timerX = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                tbTimeX.Text = _timeX.ToString("c");
                if (_timeX == TimeSpan.Zero)
                {
                    TimesUp = true;
                    if (TimesUp)
                    {
                        WinnerTimesUp(content);
                    }
                    _timerX.Stop();
                }
                _timeX = _timeX.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);
            _timerX.Stop();


            _timeO = TimeSpan.FromSeconds(4);

            _timerO = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                tbTimeO.Text = _timeO.ToString("c");
                if (_timeO == TimeSpan.Zero)
                {
                    TimesUp = true;
                    if (TimesUp)
                    {
                        WinnerTimesUp(content);
                    }
                    _timerO.Stop();
                }
                _timeO = _timeO.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);
            _timerO.Stop();
        }



        private void PlayingClick(object sender, RoutedEventArgs e)
        {
            var bt = (Button)sender;

            if (!String.IsNullOrWhiteSpace(bt.Content?.ToString())) return;

            bt.Content = _GameLogic.CurrentPlayer;
            bt.IsEnabled = false;
            bt.Foreground = Brushes.Black;

            content = _GameLogic.CurrentPlayer.ToString();

            GameOver(bt.Content.ToString());

            if (content == "O")
            {
                _timeX = TimeSpan.FromSeconds(4);
                _timerO.Stop();
                _timerX.Start();
            }
            else
            {
                _timeO = TimeSpan.FromSeconds(4);
                _timerX.Stop();
                _timerO.Start();
            }

            

            _GameLogic.SetNextPlayer();

        }

        private void WinnerTimesUp(string Content)
        {
            if (Content == "X")
            {
                MessageBox.Show("Times Up!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show("Times Up!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show("Player X Win!", "Congratulation", MessageBoxButton.OK, MessageBoxImage.Information);

                xWinsCount++;
                lbxWin.Content = $"{xWinsCount}";

                TimesUp = false;

                ResetButton();
            }
            else if (Content == "O")
            {
                MessageBox.Show("Times Up!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show("Player O Win!", "Congratulation", MessageBoxButton.OK, MessageBoxImage.Information);

                oWinsCount++;
                lboWin.Content = $"{oWinsCount}";

                TimesUp = false;

                ResetButton();
            }
        }

        private void GameOver(string btnContent)
        {
            if ((btn1.Content == btnContent & btn2.Content == btnContent & btn3.Content == btnContent) |
                (btn1.Content == btnContent & btn4.Content == btnContent & btn7.Content == btnContent) |
                (btn1.Content == btnContent & btn5.Content == btnContent & btn9.Content == btnContent) |
                (btn2.Content == btnContent & btn5.Content == btnContent & btn8.Content == btnContent) |
                (btn3.Content == btnContent & btn6.Content == btnContent & btn9.Content == btnContent) |
                (btn4.Content == btnContent & btn5.Content == btnContent & btn6.Content == btnContent) |
                (btn7.Content == btnContent & btn8.Content == btnContent & btn9.Content == btnContent) |
                (btn3.Content == btnContent & btn5.Content == btnContent & btn7.Content == btnContent))
            {
                _timerX.Stop();
                _timerO.Stop();
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
                _timerX.Stop();
                _timerO.Stop();
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

        private void Button_Click_NewGame(object sender, RoutedEventArgs e)
        {
            _timerX.Stop();
            _timerO.Stop();
            if (MessageBox.Show("Are you Sure to Restart the Game ?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                _GameLogic.NewGame();
                ResetButton();
                xWinsCount = 0;
                oWinsCount = 0;
                lbxWin.Content = $"{xWinsCount}";
                lboWin.Content = $"{oWinsCount}";
                _timeX = TimeSpan.FromSeconds(4);
                tbTimeX.Text = "";
                _timeO = TimeSpan.FromSeconds(4);
                tbTimeO.Text = "";
            }
            else
            {
                if (content == "O")
                {
                    _timerX.Start();
                }
                else
                {
                    _timerO.Start();
                }
                return;
            }
        }

        private void Button_Click_SaveGame(object sender, RoutedEventArgs e)
        {
            PlayerX_SaveGameScore.Content = xWinsCount;
            PlayerO_SaveGameScore.Content = oWinsCount;

            SaveMenu.Visibility = Visibility.Visible;

            btnBack.IsHitTestVisible = false;
            btnHighScore.IsHitTestVisible = false;
            btnSetting.IsHitTestVisible = false;

            _timerX.Stop();
            _timerO.Stop();
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

        private void Button_Click_CancelSave(object sender, RoutedEventArgs e)
        {
            SaveMenu.Visibility = Visibility.Hidden;

            XName.Clear();
            OName.Clear();

            btnBack.IsHitTestVisible = true;
            btnHighScore.IsHitTestVisible = true;
            btnSetting.IsHitTestVisible = true;
            if (content == "O")
            {
                _timerX.Start();
            }
            else
            {
                _timerO.Start();
            }
        }

        private void btn_Setting_Click(object sender, RoutedEventArgs e)
        {
            Setting_Page setting_Page = new Setting_Page();
            _timerX.Stop();
            _timerO.Stop();
            setting_Page.Show();
            Close();
        }

        private void btn_Click_Back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            _timerX.Stop();
            _timerO.Stop();
            mainWindow.Show();
            Close();
        }

        private void btn_HighScore_Click(object sender, RoutedEventArgs e)
        {
            HighScore highScore = new HighScore();
            _timerX.Stop();
            _timerO.Stop();
            highScore.Show();
            Close();
        }
    }
}
