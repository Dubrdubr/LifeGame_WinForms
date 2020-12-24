using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LifeGame_WinForms.Models
{
    public class LifeGameModel
    {
        /*Methods
         * 1lab:
         * - FillWithFood
         * - FillWithEnemy
         * 2 lab:
         * - OnCollisionEnter
         */

        static Random rnd = new Random();
        private TimeSpan timerInterval = TimeSpan.FromSeconds(0.1);
        public List<GameObject> gameObjects = new List<GameObject>();
        //public List<Enemy> enemyObjects = new List<Enemy>();
        public LifeGameModel()
        {
            FillWithEnemy(10);
            FillWithFood(10);
        }

        private void FillWithFood(int countFood)
        {
            Color customColor = Color.FromArgb(255, Color.Yellow);
            SolidBrush shadowBrush = new SolidBrush(customColor);

            for (int i = 0; i < countFood; i++)
            {
                gameObjects.Add(new Food(770, 370, shadowBrush, "food", countFood));
            }
        }

        private void FillWithEnemy(int countEnemy)
        {
            Color customColor = Color.FromArgb(255, Color.Red);
            SolidBrush shadowBrush = new SolidBrush(customColor);

            for (int i = 0; i < countEnemy; i++)
            {
                gameObjects.Add(new Enemy(770, 370, shadowBrush, "enemy",  countEnemy));
            }
        }

    }
}
