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

namespace GameOfLife
{
    /// <summary>
    /// Main Window
    /// Projekt Game of Life
    /// von
    /// Wesierski, Daniel | Wolf, Rico Wotan
    /// AS
    /// </summary>

    public partial class MainWindow : Window
    {
        //Global Cons/ Vars
        const int width = 16;
        const int height = 9;
        Rectangle[,] Cells = new Rectangle[width, height];

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            //Töte Kinder
            can_gamefield.Children.Clear();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //Erste erstellung der Zellen, Alle tot am anfang
                        Rectangle Cell = new Rectangle();

                        //Größe der Zellen (-1 für einen Rand)
                        Cell.Width = can_gamefield.ActualWidth / width - 1.0;
                        Cell.Height = can_gamefield.ActualHeight / height - 1.0;

                        //Farbe setzen (grau = tot)
                        Cell.Fill = Brushes.Gray;

                        //Zellen der Leinwand(Canvas) hinzufügen
                        can_gamefield.Children.Add(Cell);

                        //Position der Zellen bestimmen/ setzten
                        Canvas.SetLeft(Cell, x * can_gamefield.ActualWidth / width);
                        Canvas.SetTop(Cell, y * can_gamefield.ActualHeight / height);

                    //Positions-Bennung der Zellen
                    Cells[x, y] = Cell;

                    //Klickfunktion Zelle (tod/lebend) erstellen
                    Cell.MouseDown += Cell_MouseDown;

                }
            }

        }

        //Klickfunktion Farbe setzten
        private void Cell_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Switch der Fraben (Wenn Grau --> Grün | Wenn Grün --> Grau)
            if(((Rectangle)sender).Fill == Brushes.Gray)
            {
                ((Rectangle)sender).Fill = Brushes.Green;
            }
            else
            {
                ((Rectangle)sender).Fill = Brushes.Gray;
            }

        }

        //Geneartionssprung via Button_Click
        private void btn_nextGen_Click(object sender, RoutedEventArgs e)
        {
            int[,] num_CellNeighbors = new int[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int CountNeighbors_alive = 0;

                    //Check Rand des Feldes + Setzten auf andere Seite des Feldes
                    int x_up = x - 1;
                    if(x_up < 0)
                    { x_up = width - 1; }

                    int x_down = x + 1;
                    if(x_down >= width)
                    { x_down = 0; }

                    int y_up = y - 1;
                    if (y_up < 0)
                    { y_up = height - 1; }

                    int y_down = y + 1;
                    if (y_down >= height)
                    { y_down = 0; }


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

                    //Speichern der Lebenden Nachbarn pro Zelle
                    num_CellNeighbors[y, x] = CountNeighbors_alive;
                }
            }

        }
    }
}
