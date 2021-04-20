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
using System.Windows.Threading;

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
        //Global Vars
        const int width = 16;
        const int height = 9;
        Rectangle[,] Cells = new Rectangle[width, height];
        DispatcherTimer Clock = new DispatcherTimer();

        /// Main
        public MainWindow()
        {
            //Konstruktor
            InitializeComponent();

            //Automatische Spielfeld erzeugung (Standart Werte)
            CreateGameField();

            //Einstellungen für Automatischen spielverlauf (Tickrate)
            Clock.Interval = TimeSpan.FromSeconds(0.1);
            Clock.Tick += Clock_Tick;

        }

        /// Methoden Aufruf von Uhr-Ticks Für den Automatischen Spielverlauf
        private void Clock_Tick(object sender, EventArgs e)
        {
            NextGen();
        }

        /// Button zum erzeugen von Benutzerdefinierte Spielfelder
        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            //Vars
            int w;
            int h;

            //Holen der Benutzer-Eingaben
            w = Convert.ToInt32(tb_width.Text);
            h = Convert.ToInt32(tb_hight.Text);

            //Anpassung für Global Array
            Cells = new Rectangle[w, h];

            //Benutzerdefinierte Spielfeldgröße
            CreateGameField(w, h);

        }

        /// Klickfunktion Farbe setzten
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

        /// Geneartionssprung via Button_Click
        private void btn_nextGen_Click(object sender, RoutedEventArgs e)
        {
            NextGen();

        }

        /// Start Pause Button
        private void btn_play_pause_Click(object sender, RoutedEventArgs e)
        {
            if (Clock.IsEnabled)
            {
                Clock.Stop();
                btn_play_pause.Content = "Start";
            }
            else if (!Clock.IsEnabled)
            {
                Clock.Start();
                btn_play_pause.Content = "Pause";
            }

        }


        /// Methode für die Spielfelderstellung, erzeugt die Zellen (Rechtecke)
        private void CreateGameField(int w = 16, int h = 9)
        {
            //Töte Kinder
            can_gamefield.Children.Clear();

            //Für die Automatische Spielfeld muss dieser Code einmal laufen
            //Ohne ihn ist sonst die ActualWidth/Height = 0
            can_gamefield.Measure(new Size(1.0, 1.0));
            can_gamefield.Arrange(new Rect(0.0, 0.0, can_gamefield.DesiredSize.Width, can_gamefield.DesiredSize.Height));

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

        /// Methode für den Generationssprung, berechent welche Zellen Leben und welche Sterben
        private void NextGen()
        {
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
        }

        /// Löschen Button, Setzte Alle Zellen auf Tod (Grau)
        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            //Für alle Zellen die Farbe Grau setzten
            foreach(Rectangle elements in can_gamefield.Children)
            {
                elements.Fill = Brushes.Gray;
            }

        }
    }
}
