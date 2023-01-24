using System.Windows;
using System.Media;

namespace WPF_Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SoundPlayer sp = new SoundPlayer(Properties.Resources.POL_full_hand_short);

        Setting_Page Setting_Page = new Setting_Page();
        bool IsPlaying = Setting_Page.IsPlaying;
        public MainWindow()
        {
            InitializeComponent();
            if (IsPlaying == false)
            {
                sp.PlayLooping();
            }
            else sp.Stop();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Game_Page Game_Page = new Game_Page();
            Game_Page.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            Setting_Page.Show();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            HighScore highScore = new HighScore();
            highScore.Show();
            Close();
        }
    }
}
