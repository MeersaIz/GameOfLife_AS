using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
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
        int gen = 0;
        int score = 0;
        int count_alive = 0;
        int w = 16;
        int h = 9;
        Rectangle[,] Cells = new Rectangle[16, 9];
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
            NextGen(w, h);
        }

        /// Button zum erzeugen von Benutzerdefinierte Spielfelder
        private void Btn_create_Click(object sender, RoutedEventArgs e)
        {
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
            if (((Rectangle)sender).Fill == Brushes.Gray)
            {
                ((Rectangle)sender).Fill = Brushes.Green;
            }
            else
            {
                ((Rectangle)sender).Fill = Brushes.Gray;
            }
        }

        /// Geneartionssprung via Button_Click
        private void Btn_nextGen_Click(object sender, RoutedEventArgs e)
        {
            NextGen(w, h);
        }

        /// Start Pause Button
        private void Btn_play_pause_Click(object sender, RoutedEventArgs e)
        {
            PauseGen();
        }

        /// Löschen Button, Setzte Alle Zellen auf Tod (Grau)
        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        /// Random Button, Zufälliges befüllen der Zellen
        private void Btn_rndGame_Click(object sender, RoutedEventArgs e)
        {
            Rnd_game();
        }

        private void Window_Resize(object sender, SizeChangedEventArgs e)
        {
            ResizeFields();
        }
    }
}
