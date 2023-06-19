﻿using System;
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
    class Snake : Entity
    {
        private List<Rectangle> body;
        public Snake(Canvas gameField) : base(gameField)
        {
            body = new List<Rectangle>();
            increaseLength();
        
            x = (int)gameField.Width/2;
            y = (int)gameField.Height/2;
            x -= x % _width;
            y -= y % _height;

            dx = 1; dy = 0;
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

            byte g = Convert.ToByte(0);
            if (113-5*body.Count>0)
            {
                g=Convert.ToByte(113-5*body.Count);
            }

            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(238, g, 214));
            cube.Fill = brush;
            cube.Stroke = Brushes.Violet;
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
