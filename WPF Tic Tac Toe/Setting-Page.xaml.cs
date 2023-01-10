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
using System.Windows.Shapes;

namespace WPF_Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for Setting_Page.xaml
    /// </summary>
    public partial class Setting_Page : Window
    {
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
    }
}
