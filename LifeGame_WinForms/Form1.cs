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
                    (gameObjects[i] as Enemy).Move(gameObjects.Where(x => x is Food).ToList());

                    pictureBox1.Controls[i].Location = (gameObjects[i] as Enemy).Position;
                    pictureBox1.Update();
                }
            }
        }

        private void EatFood()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i] is Food)
                {
                    if ((gameObjects[i] as Food).Eat(gameObjects.Where(x => x is Enemy).ToList()))
                    {
                        var x = rnd.Next(770);
                        var y = rnd.Next(370);
                        pictureBox1.Controls[i].Location = new Point(x, y);
                        pictureBox1.Update();
                    }
                }

            }
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
