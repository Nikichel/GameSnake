using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Media;
using System.Windows;
using System.Windows.Media;
using System;

namespace GameSnake
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    /// 
    
    public partial class Menu : Page
    {

        //public static SoundPlayer backSound;

        //public static MediaPlayer backSound = new MediaPlayer();

        public Menu()
        {
            InitializeComponent();
        }
        private void Play(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new EmptyPage());
            MainWindow.backSound.Stop();
        }
        private void Setting(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Settings());
        }
        private void QuitFromGame(object sender, MouseButtonEventArgs e)
        {
            MainWindow.stopGame = 1;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
