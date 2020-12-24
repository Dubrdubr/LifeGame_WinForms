using LifeGame_WinForms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeGame_WinForms
{
    public partial class Form1 : Form
    {
        LifeGameModel GameModel;
        Random rnd = new Random();
        List<GameObject> gameObjects;
        public Form1()
        {
            InitializeComponent();
            GameModel = new LifeGameModel();
            FillRectanglesList();
            timer.Tick += Timer_Tick;
        }

        private void FillRectanglesList()
        {
            gameObjects = GameModel.gameObjects;
            //var foodObjects = GameModel.foodObjects;

            foreach (var item in gameObjects)
            {
                var pb = new PictureBox()
                {
                    Size = item.Size,
                    Location = item.Position,
                    BackColor = item.Color.Color
                };
                pictureBox1.Controls.Add(pb);
                pictureBox1.Update();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            GameObjectsMove();

        }

        private void GameObjectsMove()
        {
            EnemyMove();
            //EatFood();
        }

        private void EnemyMove()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i] is Enemy)
                {
                    if ((gameObjects[i] as Enemy).targetPoint != null && IsIntersect((gameObjects[i] as Enemy).targetPoint, (gameObjects[i] as Enemy)))
                    {
                        var food = gameObjects.FirstOrDefault(x => x == (gameObjects[i] as Enemy).targetPoint);

                        if (food != null)
                        {
                            food.IsAlive = false;
                            gameObjects.Remove(food);
                            var goFood = FindFood(food);
                            pictureBox1.Controls.Remove(goFood);
                        }
                    }

                    (gameObjects[i] as Enemy).Move(gameObjects.Where(x => x is Food).ToList());

                    pictureBox1.Controls[i].Location = (gameObjects[i] as Enemy).Position;
                    pictureBox1.Update();
                }
            }
        }

        private bool IsIntersect(GameObject go1, GameObject go2)
        {
            var x1 = go1.Position.X + go1.Size.Width;
            var y1 = go1.Position.Y + go1.Size.Height;

            var x2 = go2.Position.X + go2.Size.Height;
            var y2 = go2.Position.Y + go2.Size.Height;

            return !(go1.Position.X > x2 || go1.Position.Y > y2 || x1 < go2.Position.X || y1 < go2.Position.Y);
        }

        private PictureBox FindFood(GameObject food)
        {
            foreach(PictureBox control in pictureBox1.Controls)
            {
                if (control.BackColor == food.Color.Color && control.Location == food.Position)
                {
                    return control;
                }
            }

            return null;
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            if (!timer.Enabled)
            {
                timer.Start();
            }
            else
            {
                timer.Stop();
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillRectanglesList();
        }
    }
}
