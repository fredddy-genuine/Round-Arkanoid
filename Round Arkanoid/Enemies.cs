using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Round_Arkanoid
{
    class Enemies
    {
        public List<Enemy> enemies = new List<Enemy>();

        public Enemies(int count, int radius, Pen pen, Point center, bool clockWise, float angleShift, float margin)
        {
            int k = 360 / count;

            for (int i = 0; i < count; i++)
            {
                if(i%2 == 0)
                enemies.Add(new Enemy(radius, pen, center, i * k, k - margin, clockWise, angleShift));
                else
                    enemies.Add(new Enemy(radius, new Pen(new SolidBrush(pen.Color), pen.Width + 5), center, i * k, k - margin, clockWise, angleShift));
            }
        }
        
        public void Draw(Graphics g, Ball ball)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Draw(g);
            }
        }

        public void Update(Ball ball)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Update(ball);
            }

            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].intersectedWithBall)
                {
                    enemies.RemoveAt(i);
                    MainWindow.score += 1;
                }
            }
        }
    }
}
