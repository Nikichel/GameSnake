using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Media;

namespace GameSnake
{
    class Snake : Entity
    {
        public static MediaPlayer eatSound;
        private List<Rectangle> body;
        public Snake(Canvas gameField) : base(gameField)
        {
            eatSound = new MediaPlayer();
            eatSound.Open(new Uri(@"D:\Проекты\GameSnake\GameSnake\Sounds\chomp.wav"));
            eatSound.Volume = 1;

            body = new List<Rectangle>();
            increaseLength();
        
            x = (int)gameField.Width/2;
            y = (int)gameField.Height/2;
            x -= x % _width;
            y -= y % _height;

            dx = 1; dy = 0;
        }

        public List<Rectangle> Body
        {
            get { return body; }
            set { body = value; }
        }

        private void increaseLength()
        {
            body.Add(createPart(x, y));
        }
        private Rectangle createPart(int startX, int startY)
        {
            Rectangle cube = new Rectangle();
            cube.Height = _height;
            cube.Width = _width;

            byte b = Convert.ToByte(0);
            if (143-2*body.Count>0)
            {
                b=Convert.ToByte(143-body.Count);
            }

            cube.Fill = new SolidColorBrush(Color.FromRgb(121, 48, b));
            cube.Stroke = new SolidColorBrush(Color.FromRgb(48, 33, 79));
            cube.Margin = new Thickness(startX, startY, 0, 0);
            return cube;
        }

        private void move()
        {
            for (int i = body.Count-1; i>0; i--)
            {
                body.ElementAt(i).Margin = body.ElementAt(i-1).Margin;
            }
            x += _width*dX;
            y += _height*dY;
            body.ElementAt(0).Margin = new Thickness(x, y, 0, 0);
        }
        public void eatFruct()
        {
            eatSound.Play();
            eatSound.Position = TimeSpan.Zero;
            switch (dX)
            {
                case -1:
                    body.Add(createPart(x + _width, y));
                    break;
                case 1:
                    body.Add(createPart(x - _width, y));
                    break;
            }
            switch (dY)
            {
                case -1:
                    body.Add(createPart(x, y + _height));
                    break;
                case 1:
                    body.Add(createPart(x, y + _height));
                    break;
            }
        }

        public bool eatBody()
        {
            for (int i = 1; i<body.Count; i++)
            {
                if (body.ElementAt(0).Margin == body.ElementAt(i).Margin)
                    return true;
            }
            return false;
        }

        public void _update()
        {
            move();
            eatBody();
            foreach (Rectangle rectangle in body)
            {
                gameField.Children.Add(rectangle);
            }
        }

        public void die()
        {
            x = (int)gameField.Width/2;
            y = (int)gameField.Height/2;
            x -= x % _width;
            y -= y % _height;

            body.Clear();
            increaseLength();
        }
    }
}
