using System.Media;
using System.Windows;

namespace WPF_Tic_Tac_Toe
{
    public partial class Setting_Page : Window
    {
        Game_Logic _GameLogic = new Game_Logic();

        /*bool IsPlaying = Game_Logic.IsPlaying;*/

        public static bool IsPlaying { get; private set; }

        SoundPlayer sp = new SoundPlayer(Properties.Resources.POL_full_hand_short);

        public Setting_Page()
        {
            InitializeComponent();

            if (IsPlaying == false)
            {
                imgDisable.Visibility = Visibility.Hidden;
                imgEnable.Visibility = Visibility.Visible;
            }
            else
            {
                imgDisable.Visibility = Visibility.Visible;
                imgEnable.Visibility = Visibility.Hidden;
            }
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            Game_Page game_Page = new Game_Page();
            game_Page.Show();
            Close();
        }

        private void btn_Music_Clic(object sender, RoutedEventArgs e)
        {
            if (IsPlaying == false)
            {
                /*_GameLogic.sound();*/

                IsPlaying = true;

                imgDisable.Visibility = Visibility.Visible;
                imgEnable.Visibility = Visibility.Hidden;
                                
                sp.Stop();
            }
            else
            {
                /*_GameLogic.sound();*/

                IsPlaying = false;

                imgDisable.Visibility = Visibility.Hidden;
                imgEnable.Visibility = Visibility.Visible;

                sp.PlayLooping();
            }
        }
    }
}
