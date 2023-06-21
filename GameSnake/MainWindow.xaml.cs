using System;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Input;

namespace GameSnake
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int startGame = 0;
        public static int stopGame = 0;

        Snake snake;
        Fruit fruit;
        int gameScore;
        int gameSpeed;
        DispatcherTimer timer;
        int lastScore;
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.NavigationService.Navigate(new Menu());

            gameSpeed = 150;
            gameScore = 0;
            lastScore = 0;

            timer = new DispatcherTimer();
            snake = new Snake(gameField);
            fruit = new Fruit(gameField);

            timer.Interval = TimeSpan.FromMilliseconds(gameSpeed);
            timer.Tick += new EventHandler(update);
            timer.Start();
            this.KeyDown += new KeyEventHandler(KeyHandler);
        }

        private void update(object sender, EventArgs e)
        {
            if (startGame == 1) 
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
                    startGame = 0;
                    MessageBox.Show("Вы проиграли\n" + "Ваш счет: " + gameScore.ToString());
                    snake.die();

                    gameSpeed = 150;
                    gameScore = 0;
                    timer.Interval = TimeSpan.FromMilliseconds(gameSpeed);

                    mainFrame.NavigationService.Navigate(new Menu());
                }
                if (gameScore%30==0 && gameScore!=lastScore)
                {
                    lastScore = gameScore;
                    gameSpeed -=10;
                    if (gameSpeed>50)
                        timer.Interval = TimeSpan.FromMilliseconds(gameSpeed);
                }
                fruit._update();
                score.Text = "Score: " + gameScore.ToString();
            }
            if (stopGame == 1)
                this.Close();
        }
        private void KeyHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && snake.dX != 0)
            {
                snake.dY = -1;
                snake.dX = 0;
            }
            else if (e.Key == Key.Down && snake.dX != 0)
            {
                snake.dY = 1;
                snake.dX = 0;
            }
            else if (e.Key == Key.Left && snake.dY != 0)
            {
                snake.dX = -1;
                snake.dY = 0;
            }
            else if (e.Key == Key.Right && snake.dY!=0)
            {
                snake.dX = 1;
                snake.dY = 0;
            }
            if(e.Key == Key.Escape && startGame == 1)
            {
                startGame = 0;
                mainFrame.NavigationService.Navigate(new Menu());
            }
        }

        private void gameLoaded(object sender, RoutedEventArgs e)
        {
            //backSound.PlayLooping();
        }
    }
}
