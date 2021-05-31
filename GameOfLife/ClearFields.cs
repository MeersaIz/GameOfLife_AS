using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GameOfLife
{
    partial class MainWindow : Window
    {
        private void ClearFields()
        {
            //Für alle Zellen die Farbe Grau setzten
            foreach (Rectangle elements in can_gamefield.Children)
            {
                gen = 0;
                count_alive = 0;
                lbl_gen.Content = gen.ToString();
                lbl_countCells.Content = count_alive.ToString();
                elements.Fill = Brushes.Gray;
            }
        }
    }
}
