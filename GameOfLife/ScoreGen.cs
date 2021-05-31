using System.Windows;

namespace GameOfLife
{
    partial class MainWindow : Window
    {
        /// Berechenen des Highscore und setzten der Generation
        public void set_score_gen()
        {
            gen += 1;
            if (gen > score)
            {
                score = gen;
            }
            lbl_gen.Content = gen.ToString();
            lbl_highscore.Content = score.ToString();
        }
    }
}
