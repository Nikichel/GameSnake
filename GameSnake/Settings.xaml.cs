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

namespace GameSnake
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
            backSounSlider.Value = MainWindow.backSound.Volume;
            eatSounSlider.Value = Snake.eatSound.Volume;
        }

        private void BackToMenu(object sender, MouseButtonEventArgs e)
        {
            //MainWindow.backSound.Stop();
            NavigationService.Navigate(new Menu());
                
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MainWindow.backSound.Volume = backSounSlider.Value;
        }

        private void eatSounSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Snake.eatSound.Volume =  eatSounSlider.Value;
        }
    }
}
