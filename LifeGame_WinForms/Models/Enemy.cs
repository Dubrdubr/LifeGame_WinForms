using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame_WinForms.Models
{
    public class Enemy : GameObject
    {
        
        public Enemy(int maxX, int maxY, SolidBrush color, string type, int count) 
            : base(maxX, maxY, color, type, count) {   }

        public GameObject targetPoint = null;
        int speed = 1;

        private void FindClosest(List<GameObject> points)
        {
            GameObject closest = null;
            int lastDistance = int.MaxValue;

            foreach (var item in points)
            {
                if (item is Enemy) continue;

                var distance = GetDistance(item);

                if (distance < lastDistance)
                {
                    lastDistance = distance;
                    closest = item;
                }

                targetPoint = closest;
            }
        }

        private Point MoveToTargetPoint()
        {
            if (targetPoint == null)
                return Position;

            var dx = Position.X > targetPoint.Position.X ? -speed : speed;
            var dy = Position.Y > targetPoint.Position.Y ? -speed : speed;

            var pos = Position;
            pos.Offset(dx, dy);
            Position = pos;

            return Position;
        }

        private void FindTarget(List<GameObject> gamePoints)
        {
            foreach (var item in gamePoints)
            {
                if (item is Food)
                {
                    FindClosest(gamePoints);
                }                    
            }                   
        }

        public Point Move(List<GameObject> gamePoints)
        {
            if (targetPoint?.IsAlive == false)
                targetPoint = null;

            FindTarget(gamePoints);
            MoveToTargetPoint();

            return Position;
        }

        
    }
}
