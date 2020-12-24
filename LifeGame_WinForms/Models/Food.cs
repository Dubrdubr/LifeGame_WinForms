using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame_WinForms.Models
{
    public class Food : GameObject
    {
        public Food(int maxX, int maxY, SolidBrush color, string type, int count)
            : base(maxX, maxY, color, type, count) { }

        public Boolean Eat(List<GameObject> foodPoints)
        {
            var around = false;
            foreach (var item in foodPoints)
            {
                //if (item is Enemy) continue;

                var distance = GetDistance(item);
                var diag1 = Math.Pow(Size.Width, 2);
                var diag2 = Math.Pow(item.Size.Width, 2);

                if ((int)Math.Sqrt(diag1 + diag2) < distance)
                    around = true;
            }

            return around;
        }
    }
}
