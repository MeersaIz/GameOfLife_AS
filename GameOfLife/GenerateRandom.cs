using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GameOfLife
{
    partial class MainWindow : Window
    {
        /// Random Spielffeld Erzeugung
        public void Rnd_game()
        {
            Random rnd = new Random();

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    if (rnd.Next(2) == 1)
                    {
                        Cells[x, y].Fill = Brushes.Green;
                    }
                    else
                    {
                        Cells[x, y].Fill = Brushes.Gray;
                    }
                }
            }
        }
    }
}
