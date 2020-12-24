using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame_WinForms.Models
{
    public abstract class GameObject
    {
        static Random rnd = new Random();

        public Size Size;
        public Point Position;
        public SolidBrush Color;
        public string type;
        public bool IsAlive = true;

        public GameObject(int maxX, int maxY, SolidBrush color, string type, int count)
        {
            Color = color;
            InitializePosition(maxX, maxY);
            InitializeSize(type);     
        }

        private void InitializePosition(int maxX, int maxY)
        {
            var x = rnd.Next(0, maxX);
            var y = rnd.Next(0, maxY);
            Position = new Point(x, y);
        }

        private void InitializeSize(string type)
        {
            if (type == "food")
            {
                Size = new Size(10, 10);
            }
            else if (type == "enemy")
            {
                var enemyWidth = rnd.Next(10, 30);
                Size = new Size(enemyWidth, enemyWidth);
            }
        }

        public int GetDistance(GameObject point)
        {
            var deltax = Position.X - point.Position.X;
            var deltay = Position.Y - point.Position.Y;

            var deltax2 = Math.Pow(deltax, 2);
            var deltay2 = Math.Pow(deltay, 2);

            return (int)Math.Sqrt(deltax2 + deltay2);
        }



        /* Методы
         *2lab
         *-IntersectWith
         */


        /* 1 лаба
         * - унаследовать объект Enemy от класса GameObject
         * 2 лаба
         * - унаследовать класс Food от класса GameObject
         */

    }
}
