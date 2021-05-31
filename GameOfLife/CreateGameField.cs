using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GameOfLife
{
    partial class MainWindow : Window
    {
        /// Methode für die Spielfelderstellung, erzeugt die Zellen (Rechtecke)
        private void CreateGameField(int w = 16, int h = 9)
        {
            //zurücksetzten der gen
            gen = 0;
            score = 0;
            count_alive = 0;
            lbl_gen.Content = gen.ToString();
            lbl_highscore.Content = score.ToString();
            lbl_countCells.Content = count_alive.ToString();

            //Töte Kinder
            can_gamefield.Children.Clear();

            //Für die Automatische Spielfeld muss dieser Code einmal laufen
            //Ohne ihn ist sonst die ActualWidth/Height = 0
            can_gamefield.Measure(new Size(1.0, 1.0));
            can_gamefield.Arrange(new Rect(0.0, 0.0, can_gamefield.DesiredSize.Width, can_gamefield.DesiredSize.Height));

            GenerateCells(w,h);
        }

        private void GenerateCells(int w, int h)
        {
            //Zellen Generierung
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    //Erste erstellung der Zellen, Alle tot am anfang
                    Rectangle Cell = new Rectangle();

                    //Größe der Zellen (-1 für einen Rand)
                    Cell.Width = can_gamefield.ActualWidth / w - 1.0;
                    Cell.Height = can_gamefield.ActualHeight / h - 1.0;

                    //Farbe setzen (grau = tot)
                    Cell.Fill = Brushes.Gray;

                    //Zellen der Leinwand(Canvas) hinzufügen
                    can_gamefield.Children.Add(Cell);

                    //Position der Zellen bestimmen/ setzten
                    Canvas.SetLeft(Cell, x * can_gamefield.ActualWidth / w);
                    Canvas.SetTop(Cell, y * can_gamefield.ActualHeight / h);

                    //Positions-Bennung der Zellen
                    Cells[x, y] = Cell;

                    //Klickfunktion Zelle (tod/lebend) erstellen
                    Cell.MouseDown += Cell_MouseDown;

                }
            }
        }
    }
}
