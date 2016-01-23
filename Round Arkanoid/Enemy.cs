using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Round_Arkanoid
{
    class Enemy
    {
        int radius;
        Pen pen;
        Point center;
        float startAngle;
        float sweepAngle;
        bool clockWise;
        float angleShift;
        float middleAngle;
        public bool intersectedWithBall = false;

        public Enemy(int radius, Pen pen, Point center, float startAngle, float sweepAngle, bool clockWise, float angleShift)
        {
            this.radius = radius;
            this.pen = pen;
            this.center = center;
            this.startAngle = startAngle;
            this.sweepAngle = sweepAngle;
            this.clockWise = clockWise;
            this.angleShift = angleShift;

            middleAngle = MainWindow.AngleTo360DegreeSystem(startAngle + sweepAngle / 2);
        }

        public void Update(Ball ball)
        {
            startAngle = clockWise ? MainWindow.AngleTo360DegreeSystem(startAngle + angleShift) : MainWindow.AngleTo360DegreeSystem(startAngle - angleShift);
            middleAngle = MainWindow.AngleTo360DegreeSystem(startAngle + sweepAngle / 2);

            //CheckIntersect(ball);
            if ((int)(MainWindow.AngleTo360DegreeSystem(startAngle + sweepAngle) - MainWindow.AngleTo360DegreeSystem(startAngle)) == (int)sweepAngle ||
                (int)(MainWindow.AngleTo360DegreeSystem(startAngle + sweepAngle) - MainWindow.AngleTo360DegreeSystem(startAngle)) == (int)sweepAngle - 1)
            {
                if (ball.locationRadius <= radius + pen.Width / 2 + ball.diametr / 2 &&
                    ball.locationRadius >= radius &&
                    ball.movingAngle > startAngle &&
                    ball.movingAngle < MainWindow.AngleTo360DegreeSystem(startAngle + sweepAngle))
                {
                    ball.speed *= -1;
                    ball.angle = ball.movingAngle;
                    ball.shiftAngle *= -4;

                    intersectedWithBall = true;
                }
                else if (ball.locationRadius + ball.diametr / 2 >= radius - pen.Width / 2 && ball.locationRadius + ball.diametr / 2 < radius &&
                    ball.movingAngle > startAngle && ball.movingAngle < MainWindow.AngleTo360DegreeSystem(startAngle + sweepAngle))
                {
                    ball.speed *= -1;
                    ball.shiftAngle *= -4;

                    intersectedWithBall = true;
                }
            }
            else
            {
                if (ball.locationRadius <= radius + pen.Width / 2 + ball.diametr / 2 &&
                    ball.locationRadius >= radius &&
                    AngleToOver360DegreeSystem(ball.movingAngle, MainWindow.AngleTo360DegreeSystem(startAngle + sweepAngle)) > startAngle &&
                    AngleToOver360DegreeSystem(ball.movingAngle, MainWindow.AngleTo360DegreeSystem(startAngle + sweepAngle)) < startAngle + sweepAngle)
                {
                    ball.speed *= -1;
                    ball.angle = ball.movingAngle;
                    ball.shiftAngle *= -4;

                    intersectedWithBall = true;
                }
                else if (ball.locationRadius + ball.diametr / 2 >= radius - pen.Width / 2 &&
                    ball.locationRadius + ball.diametr / 2 < radius &&
                    AngleToOver360DegreeSystem(ball.movingAngle, MainWindow.AngleTo360DegreeSystem(startAngle + sweepAngle)) > startAngle &&
                    AngleToOver360DegreeSystem(ball.movingAngle, MainWindow.AngleTo360DegreeSystem(startAngle + sweepAngle)) < startAngle + sweepAngle)
                {
                    ball.speed *= -1;
                    ball.angle = ball.movingAngle;
                    ball.shiftAngle *= 2;

                    intersectedWithBall = true;
                }
            }
        }

        float AngleToOver360DegreeSystem(float angle, float compareAngle)
        {
            if (angle < 360 && angle < compareAngle)
                return 360 + angle;
            return angle;
        }

        public void Draw(Graphics g)
        {
            g.DrawArc(pen, new Rectangle(center.X - radius, center.Y - radius, radius * 2, radius * 2), startAngle, sweepAngle);
        }
    }
}
