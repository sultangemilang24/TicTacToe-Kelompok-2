using System.Media;
using System.Windows;

namespace WPF_Tic_Tac_Toe
{
    public partial class Setting_Page : Window
    {
        Game_Logic _GameLogic = new Game_Logic();
        public Setting_Page()
        {
            InitializeComponent();
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            Game_Page game_Page = new Game_Page();
            game_Page.Show();
            Close();
        }

        private void btn_Music_Clic(object sender, RoutedEventArgs e)
        {
            bool IsPlaying = Game_Logic.IsPlaying;

            if (IsPlaying)
            {
                _GameLogic.sound();

                SoundPlayer sp = new SoundPlayer();
                sp.SoundLocation = @".\sound\POL-full-hand-short.wav";
                sp.Stop();
            }
            else
            {
                _GameLogic.sound();

                SoundPlayer sp = new SoundPlayer();
                sp.SoundLocation = @".\sound\POL-full-hand-short.wav";
                sp.PlayLooping();
            }
        }
    }
}
