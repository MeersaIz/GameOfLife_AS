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
        //Global Cons
        const int width = 16;
        const int height = 9;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
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
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    

                }
            }

        }
    }
}
