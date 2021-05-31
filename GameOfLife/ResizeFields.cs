using System.Windows;
using System.Windows.Controls;

namespace GameOfLife
{
    partial class MainWindow : Window
    {
        private void ResizeFields()
        {
            can_gamefield.Height = MainGrid.ActualHeight - 55;
            can_gamefield.Width = MainGrid.ActualWidth - 250;

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    Cells[x, y].Width = can_gamefield.ActualWidth / w - 1.0;
                    Cells[x, y].Height = can_gamefield.ActualHeight / h - 1.0;
                    Canvas.SetLeft(Cells[x, y], x * can_gamefield.ActualWidth / w);
                    Canvas.SetTop(Cells[x, y], y * can_gamefield.ActualHeight / h);
                }
            }
        }
        
    }
}
