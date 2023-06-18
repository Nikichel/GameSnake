using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Ellipse fruit;
        private int fX, fY;

        private Rectangle cube;
        private int _height;
        private int _width;
        private int curX, curY;
        private int dX, dY;
        DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            _height = 20;
            _width = 20;

            curX = (int)gameField.Width/2;
            curY = (int)gameField.Height/2;
            curX -= curX % _width;
            curY -= curY % _height;

            dY = 0;
            dX = 1;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(300);
            timer.Tick += new EventHandler(update);
            timer.Start();
            this.KeyDown += new KeyEventHandler(KeyHandler);
        }

        private void generatorFruit()
        {
            Random random = new Random();
            fX = random.Next(30, (int)gameField.Width-30);
            fY = random.Next(30, (int)gameField.Height-30);
            fX -= fX % _width;
            fY -= fY % _height;

            /*            fY -= _height / 2;
                        fX -= _width / 2;*/

            fruit = new Ellipse();
            createFruit();

            gameField.Children.Add(fruit);
        }

        private void createFruit()
        {
            fruit.Height = _height;
            fruit.Width = _width;
            fruit.Fill = Brushes.Red;
            fruit.Stroke = Brushes.Green;
            fruit.Margin = new Thickness(fX, fY, 0, 0);
        }

        private void update(object sender, EventArgs e)
        {
            gameField.Children.Clear();
            curY += _height*dY;
            curX += _width*dX;
            cube.Margin = new Thickness(curX, curY, 0, 0);
            gameField.Children.Add(cube);
            if (curX == fX && curY == fY)
                MessageBox.Show("Взял!");
            gameField.Children.Add(fruit);
        }
        private void KeyHandler(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    dY = -1;
                    dX = 0;
                    break;
                case Key.Down:
                    dY = 1;
                    dX = 0;
                    break;
                case Key.Right:
                    dX = 1;
                    dY = 0;
                    break;
                case Key.Left:
                    dX = -1;
                    dY = 0;
                    break;
            }
        }
        private void createCube()
        {
            cube.Height = _height;
            cube.Width = _width;
            cube.Fill = new SolidColorBrush(Colors.Violet);
            cube.Stroke = new SolidColorBrush(Colors.Violet);
            cube.Margin = new Thickness(curX, curY, 0, 0);
        }

        private void gameLoaded(object sender, RoutedEventArgs e)
        {
            generatorFruit();
            cube = new Rectangle();
            createCube();
            gameField.Children.Add(cube);
        }
    }
}
