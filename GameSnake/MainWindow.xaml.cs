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
        Snake snake;
        Fruit fruit;
        int gameScore;
        int gameSpeed;
        DispatcherTimer timer;
        int lastScore;
        public MainWindow()
        {
            InitializeComponent();
            gameSpeed = 150;
            snake = new Snake(gameField);
            fruit = new Fruit(gameField);
            gameScore = 0;
            lastScore = 0;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(gameSpeed);
            timer.Tick += new EventHandler(update);
            timer.Start();
            this.KeyDown += new KeyEventHandler(KeyHandler);
        }

        private void update(object sender, EventArgs e)
        {
            gameField.Children.Clear();
            snake._update();
            if (snake.X == fruit.X && snake.Y == fruit.Y)
            {
                gameScore += fruit.Point;
                snake.eatFruct();
                fruit.generatorFruit();
            }
            if (snake.X>gameField.Width-snake.getWidth() || snake.X<0 || snake.Y>gameField.Height-snake.getHeight() || snake.Y<0 || snake.eatBody())
            {
                MessageBox.Show("Вы проиграли\n" + "Ваш счет: " + gameScore.ToString());
                gameScore = 0;
                snake.die();
                gameSpeed=150;
                timer.Interval = TimeSpan.FromMilliseconds(gameSpeed);
            }
            if (gameScore%30==0 && gameScore!=lastScore) 
            {
                lastScore = gameScore;
                gameSpeed -=10;
                if(gameSpeed>50)
                    timer.Interval = TimeSpan.FromMilliseconds(gameSpeed);
            }
            fruit._update();
            score.Text = "Score: " + gameScore.ToString();
        }
        private void KeyHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && snake.dX != 0)
            {
                snake.dY = -1;
                snake.dX = 0;
            }
            if (e.Key == Key.Down && snake.dX != 0)
            {
                snake.dY = 1;
                snake.dX = 0;
            }
            if (e.Key == Key.Left && snake.dY != 0)
            {
                snake.dX = -1;
                snake.dY = 0;
            }
            if (e.Key == Key.Right && snake.dY!=0)
            {
                snake.dX = 1;
                snake.dY = 0;
            }
        }

        private void gameLoaded(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
