using System.Windows;
using System.Windows.Media;

namespace GameOfLife
{
    partial class MainWindow : Window
    {
        /// Methode für den Generationssprung, berechent welche Zellen Leben und welche Sterben
        private void NextGen(int width, int height)
        {
            set_score_gen();
            count_alive = 0;

            int[,] num_CellNeighbors = new int[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int CountNeighbors_alive = 0;

                    //Check Rand des Feldes + Setzten auf andere Seite des Feldes
                    int x_up = x - 1;
                    if (x_up < 0)
                    { x_up = width - 1; }

                    int x_down = x + 1;
                    if (x_down >= width)
                    { x_down = 0; }

                    int y_up = y - 1;
                    if (y_up < 0)
                    { y_up = height - 1; }

                    int y_down = y + 1;
                    if (y_down >= height)
                    { y_down = 0; }

                    // Check für Torus Regeln
                    if ((x == 0 || x == width || y == 0 || y == height) && !(bool)cb_torus.IsChecked)
                    {
                        Cells[x, y].Fill = Brushes.Gray;
                    }
                    else
                    {
                        //Nachbar Links Oben
                        if (Cells[x_up, y_up].Fill == Brushes.Green)
                        { CountNeighbors_alive++; }

                        //Nachbar Mitte Oben
                        if (Cells[x, y_up].Fill == Brushes.Green)
                        { CountNeighbors_alive++; }

                        //Nachbar Rechts Oben
                        if (Cells[x_down, y_up].Fill == Brushes.Green)
                        { CountNeighbors_alive++; }

                        //Nachbar Links Mitte
                        if (Cells[x_up, y].Fill == Brushes.Green)
                        { CountNeighbors_alive++; }

                        //Nachbar Rechts Mitte
                        if (Cells[x_down, y].Fill == Brushes.Green)
                        { CountNeighbors_alive++; }

                        //Nachbar Links Unten
                        if (Cells[x_up, y_down].Fill == Brushes.Green)
                        { CountNeighbors_alive++; }

                        //Nachbar Mitte Unten
                        if (Cells[x, y_down].Fill == Brushes.Green)
                        { CountNeighbors_alive++; }

                        //Nachbar Rechts Unten
                        if (Cells[x_down, y_down].Fill == Brushes.Green)
                        { CountNeighbors_alive++; }
                    }

                    //Speichern der Lebenden Nachbarn pro Zelle
                    num_CellNeighbors[y, x] = CountNeighbors_alive;
                }
            }

            //Berechnung Zelle Leben/Sterben
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (num_CellNeighbors[y, x] < 2 || num_CellNeighbors[y, x] > 3)
                    {
                        Cells[x, y].Fill = Brushes.Gray;
                    }
                    else if (num_CellNeighbors[y, x] == 3)
                    {
                        Cells[x, y].Fill = Brushes.Green;
                    }
                }
            }

            // Update - Lebende Zellen Label
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (Cells[x, y].Fill.Equals(Brushes.Green))
                    {
                        count_alive += 1;
                    }
                }
            }

            lbl_countCells.Content = count_alive.ToString();

            // Reset Generationscounter bei leerem Spielfeld
            if (count_alive <= 0)
            {
                gen = 0;
            }
        }
    }
}
