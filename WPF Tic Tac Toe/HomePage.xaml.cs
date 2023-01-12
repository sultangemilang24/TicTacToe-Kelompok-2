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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;

namespace WPF_Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = @".\sound\POL-full-hand-short.wav";
            sp.PlayLooping();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Game_Page Game_Page = new Game_Page();
            SoundPlayer sfx = new SoundPlayer(@".\sound\Click.wav");
            sfx.Play();
            Game_Page.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Setting_Page Setting_Page = new Setting_Page();
            //SoundPlayer sfx = new SoundPlayer(@".\sound\Click.wav");
            //sfx.Play();
            Setting_Page.Show();
            Close();
        }

        private void HomPage_Load(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
