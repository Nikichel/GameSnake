using System.Windows.Controls;

namespace GameSnake
{
    class Entity
    {
        protected int x, y;
        protected int dx, dy;
        protected Canvas gameField;
        protected int _width, _height;

        public Entity(Canvas gameField)
        {
            this.gameField = gameField;
            _width = 20;
            _height = 20;
            x = 0; y = 0;
            dx = 0; dy = 0;
        }

        public int getWidth()
        {
            return _width;
        }

        public int getHeight()
        {
            return _height;
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int dX
        {
            get { return dx; }
            set { dx = value; }
        }

        public int dY
        {
            get { return dy; }
            set { dy = value; }
        }
    }
}
