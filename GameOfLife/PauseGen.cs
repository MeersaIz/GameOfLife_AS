using System.Windows;

namespace GameOfLife
{
    partial class MainWindow : Window
    {
        private void PauseGen() 
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
    }
}
