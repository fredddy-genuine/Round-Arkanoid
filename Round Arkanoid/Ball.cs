using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Round_Arkanoid
{
    class Ball
    {
        public int diametr = 12;
        Brush brush = new SolidBrush(Color.Yellow);
        public PointF location = new PointF(0, 0);
        public bool started = false;
        Point center;
        float canvasRadius;
        public float speed = (float)5;
        public float angle = 0;
        public float movingAngle = 0;
        public float shiftAngle = 0;
        public float locationRadius;

        public int fault = 0;
        int score_subtrahend = 4;

        public Ball(float canvasRadius, Point center)
        {
            this.canvasRadius = canvasRadius;
            this.center = center;
        }

        public void UpdateOnPlatform(float newMouseAngle, PlayerPlatform playerPlatform)
        {
            location.X = (canvasRadius - playerPlatform.penPlatform.Width / 2 - diametr / 2) * (float)Math.Cos((Math.PI * newMouseAngle) / 180);
            location.Y = (canvasRadius - playerPlatform.penPlatform.Width / 2 - diametr / 2) * (float)Math.Sin((Math.PI * newMouseAngle) / 180);

            location.X += center.X -diametr / 2;
            location.Y += center.Y -diametr / 2;

            angle = newMouseAngle;
        }

        public void Click(float newMouseAngle, PlayerPlatform playerPlatform)
        {
            UpdateOnPlatform(newMouseAngle, playerPlatform);
            started = true;

            location.X -= 10 * (float)Math.Cos((Math.PI * angle) / 180);
            location.Y -= 10 * (float)Math.Sin((Math.PI * angle) / 180);

            if (MainWindow.AngleTo360DegreeSystem(playerPlatform.startAngle + playerPlatform.sweepAngle) - playerPlatform.startAngle != playerPlatform.sweepAngle)
                shiftAngle = 5;
            else
                shiftAngle = 0;

            score_subtrahend = 4;
        }
        
        public void Move(PlayerPlatform playerPlatform)
        {
            if (started)
            {
                location.X -= speed * (float)Math.Cos((Math.PI * angle + shiftAngle) / 180);
                location.Y -= speed * (float)Math.Sin((Math.PI * angle + shiftAngle) / 180);

                movingAngle = MainWindow.AngleTo360DegreeSystem(((float)Math.Atan2(location.Y - center.Y, location.X - center.X) * 180) / (float)Math.PI);
                locationRadius = (float)Math.Sqrt(Math.Pow(location.X + diametr/2 - center.X, 2) + Math.Pow(location.Y + diametr/2 - center.Y, 2));

                if ((int)(playerPlatform.endAngle - playerPlatform.startAngle) == (int)playerPlatform.sweepAngle || (int)(playerPlatform.endAngle - playerPlatform.startAngle) == (int)playerPlatform.sweepAngle-1)
                {
                    if (locationRadius + diametr / 2 >= playerPlatform.locationRadius && locationRadius + diametr / 2 < playerPlatform.locationRadius + playerPlatform.penPlatform.Width/2 && movingAngle > playerPlatform.startAngle && movingAngle < playerPlatform.endAngle)
                    {
                        location.X += speed / Math.Abs(speed) * 10 * (float)Math.Cos((Math.PI * angle + shiftAngle) / 180);
                        location.Y += speed / Math.Abs(speed) * 10 * (float)Math.Sin((Math.PI * angle + shiftAngle) / 180);

                        speed *= -1;

                        angle = angle/Math.Abs(angle) * playerPlatform.centerAngle;

                        shiftAngle = 4*(playerPlatform.centerAngle - movingAngle);
                    }
                }
                else
                {
                    if (locationRadius + diametr / 2 >= playerPlatform.locationRadius && 
                        ((movingAngle < 360 && movingAngle > playerPlatform.startAngle) || (movingAngle > 0 && movingAngle < playerPlatform.endAngle)))
                    {
                        speed *= -1;
                    }
                }

                if (locationRadius + diametr / 2 >= canvasRadius)
                {
                    MainWindow.score -= score_subtrahend;
                    score_subtrahend = 0;
                }

                if (locationRadius + diametr / 2 >= canvasRadius + 300)
                {
                    started = false;
                    fault++;
                }
            }
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.FromArgb(30, Color.Yellow)), new RectangleF(location.X - 5, location.Y - 5, diametr + 10, diametr + 10));
            g.FillEllipse(new SolidBrush(Color.FromArgb(60, Color.Yellow)), new RectangleF(location.X - 3, location.Y - 3, diametr + 6, diametr + 6));
            g.FillEllipse(brush, new Rectangle(new Point((int)location.X, (int)location.Y), new Size(diametr, diametr)));
        }
    }
}
