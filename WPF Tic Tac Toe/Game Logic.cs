using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Tic_Tac_Toe
{
    public class Game_Logic
    {
        public string CurrentPlayer { get; set; } = X;
        private const string X = "X";
        private const string O = "O";

        public static bool IsPlaying { get; set; } = true;

        public void SetNextPlayer()
        {
            if(CurrentPlayer == X)
            {
                CurrentPlayer = O;
            }
            else
            {
                CurrentPlayer = X;
            }
        }

        public void NewGame()
        {
            CurrentPlayer = X;
        }

        public void sound()
        {
            if (IsPlaying == true)
            {
                IsPlaying = false;
            }
            else
            {
                IsPlaying = true;
            }
        }
    }
}
