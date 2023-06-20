using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GameSnake
{
    class Fruit : Entity
    {
        Ellipse fruit;
        int points;
        public Fruit(Canvas gameField) : base(gameField)
        {
            points = 5;
            fruit = new Ellipse();
            generatorFruit();
        }
        private void createFruit()
        {
            fruit.Height = _height;
            fruit.Width = _width;
            fruit.Fill = Brushes.Red;
            fruit.Stroke = Brushes.Green;
            fruit.Margin = new Thickness(x, y, 0, 0);
        }
        public void generatorFruit()
        {
            Random random = new Random();
            x = random.Next(40, (int)gameField.Width-40);
            y = random.Next(40, (int)gameField.Height-40);
            x -= x % _width;
            y -= y % _height;
            createFruit();
        }

        public void _update()
        {
            gameField.Children.Add(fruit);
        }

        public int Point
        {
            get { return points; }
            set { points = value; }
        }
    }
}
