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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            const int width = 16;
            const int height = 9;

            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    //Erste erstellung der Zellen, Alle tot am anfang
                    Rectangle Cell = new Rectangle();
                    Cell.Width = can_gamefield.ActualWidth / width - 1.0;
                    Cell.Height = can_gamefield.ActualHeight / height - 1.0;
                    Cell.Fill = Brushes.Gray;
                    can_gamefield.Children.Add(Cell);
                    Canvas.SetLeft(Cell, y * can_gamefield.ActualWidth / width);
                    Canvas.SetTop(Cell, x * can_gamefield.ActualHeight / height);

                    //
                    Cell.MouseDown += Cell_MouseDown;

                }
            }

        }

        private void Cell_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(((Rectangle)sender).Fill == Brushes.Gray)
            {
                ((Rectangle)sender).Fill = Brushes.Green;
            }
            else
            {
                ((Rectangle)sender).Fill = Brushes.Gray;
            }

        }
    }
}
