using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace Round_Arkanoid
{
    public partial class MainWindow : Form
    {
        float mouseAngle;
        Point center;
        Point mouseLocation = new Point(0, 0);

        PlayerPlatform playerPlatform;
        Ball ball;
        bool gameStarted = false;
        //Enemy enemy;
        Enemies enemies1;
        Enemies enemies2;
        Enemies enemies3;
        Enemies enemies4;

        Enemies enemies5;
        Enemies enemies6;
        Enemies enemies7;
        Enemies enemies8;
        Stopwatch stopWatch = new Stopwatch();

        float scoreDestructor = 0;

        ColorScheme colorScheme;

        bool DifficultyCyberSport = false;

        public MainWindow()
        {
            InitializeComponent();

            center = new Point(Canvas.Width / 2, Canvas.Height / 2);

            playerPlatform = new PlayerPlatform(center);
            ball = new Ball(playerPlatform.radius, center);

            SetBackground(Color.LightSeaGreen);
            SetBackgroundMainMenu(Color.LightSeaGreen);

            enemies1 = new Enemies(7, 50, new Pen(new SolidBrush(Color.FromArgb(200, 255, 186, 2)), 25), center, true, (float)0.2, 7);
            enemies2 = new Enemies(4, 90, new Pen(new SolidBrush(Color.FromArgb(200, 217, 68, 48)), 20), center, false, (float)0.3, 5);
            enemies3 = new Enemies(8, 120, new Pen(new SolidBrush(Color.FromArgb(200, 23, 109, 237)), 22), center, true, (float)0.4, 4);
            enemies4 = new Enemies(10, 145, new Pen(new SolidBrush(Color.FromArgb(200, 0, 155, 87)), 16), center, false, (float)0.5, 1);

            ball.speed = 3;
            playerPlatform.sweepAngle = 40;

            colorScheme = new ColorScheme(ColourScheme, new[] { Color.LightSeaGreen, Color.FromArgb(114, 34, 114),
                Color.FromArgb(67, 67, 170), Color.FromArgb(201, 68, 68), Color.FromArgb(34, 102, 34),
                Color.Firebrick, Color.FromArgb(39, 28, 39), Color.FromArgb(99, 55, 99), Color.Beige, Color.FromArgb(21, 21, 66),
            Color.FromArgb(44, 120, 120), Color.FromArgb(187, 187, 92), Color.FromArgb(166, 166, 212), Color.FromArgb(32, 189, 189),
            Color.FromArgb(200, 200, 40), Color.FromArgb(77, 77, 46), Color.FromArgb(190, 55, 55), Color.FromArgb(58, 58, 185),
            Color.FromArgb(112, 62, 62), Color.FromArgb(54, 54, 60)});

            colorScheme.Draw(ColourScheme.CreateGraphics());
        }

        void SetBackground(Color color)
        {
            Bitmap bmp_image = new Bitmap(Canvas.Width, Canvas.Height);
            Graphics g = Graphics.FromImage(bmp_image);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int rect_width = 1120;

            for (int i = 0; i < 360; i += 36)
            {
                g.FillPie(new SolidBrush(Color.Black), new Rectangle(center.X - (int)rect_width / 2, center.Y - (int)rect_width / 2, (int)rect_width, (int)rect_width), i, 18);
            }

            GraphicsPath gp = new GraphicsPath();

            gp.AddEllipse(center.X - rect_width / 2 - 40, center.Y - rect_width / 2, rect_width, rect_width);
            gp.CloseFigure();

            PathGradientBrush pgb = new PathGradientBrush(gp);
            pgb.CenterColor = Color.FromArgb(220, /*152, 35, 149*/color);
            pgb.SurroundColors = new Color[] { Color.FromArgb(30, Color.White) };
            g.FillPath(pgb, gp);

            Canvas.BackgroundImage = bmp_image;
        }

        void SetBackgroundMainMenu(Color color)
        {
            Bitmap bmp_image = new Bitmap(Canvas.Width, Canvas.Height);
            Graphics g = Graphics.FromImage(bmp_image);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int width = MenuSettings.Width;
            int height = MenuSettings.Height;

            int k = 25;
            int k2 = 25;

            for (int i = 0; i < (height / 30) * 2; i++)
            {
                for (int j = 0; j < (width / 30); j++)
                {
                    if (i % 2 == 0)
                    {
                        g.FillClosedCurve(new SolidBrush(Color.Black), new[] { new PointF(0 + 2*k*j, 0 + k2*i), new PointF(10 + 2*k*j, -5 + k2*i), new PointF(20 + 2*k*j, -5 + k2*i), new PointF(30 + 2*k*j, 0 + k2*i),
                                      new PointF(30 + 2*k*j, 20 + k2*i), new PointF(20 + 2*k*j, 25 + k2*i), new PointF(10 + 2*k*j, 25 + k2*i), new PointF(0 + 2*k*j, 20 + k2*i)});
                    }
                    else
                    {
                        g.FillClosedCurve(new SolidBrush(Color.Black), new[] { new PointF(0 - k + 2*k*j, 0 + k2*i), new PointF(10- k + 2*k*j, -5 + k2*i), new PointF(20- k + 2*k*j, -5 + k2*i), new PointF(30- k + 2*k*j, 0 + k2*i),
                                      new PointF(30- k + 2*k*j, 20 + k2*i), new PointF(20- k + 2*k*j, 25 + k2*i), new PointF(10- k + 2*k*j, 25 + k2*i), new PointF(0- k + 2*k*j, 20 + k2*i)});
                    }
                }
            }

            GraphicsPath gp = new GraphicsPath();

            gp.AddRectangle(new Rectangle(-160, -160, width + 320, height + 320));
            gp.CloseFigure();

            PathGradientBrush pgb = new PathGradientBrush(gp);
            pgb.CenterColor = Color.FromArgb(255, /*152, 35, 149*/color);
            pgb.SurroundColors = new Color[] { Color.FromArgb(30, Color.White) };
            g.FillPath(pgb, gp);
            g.DrawRectangle(new Pen(new SolidBrush(Color.Black), 1), new Rectangle(19, 284, 206, 193));

            MenuSettings.BackgroundImage = bmp_image;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(e.X, e.Y);
            mouseAngle = (float)Math.Atan2(mouseLocation.Y - center.Y, mouseLocation.X - center.X);

            if(!ball.started)
                ball.UpdateOnPlatform(AngleTo360DegreeSystem(180 * mouseAngle / (float)Math.PI), playerPlatform);
        }
        
        public static int score = 0;
        int elapsSecondsOld = 0;
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            playerPlatform.DrawOrbit(e.Graphics);

            playerPlatform.DrawPlatform(e.Graphics, AngleTo360DegreeSystem(180 * mouseAngle / (float)Math.PI));
            ball.Draw(e.Graphics);
            //enemy.Draw(e.Graphics);
            enemies1.Draw(e.Graphics, ball);
            enemies2.Draw(e.Graphics, ball);
            enemies3.Draw(e.Graphics, ball);
            enemies4.Draw(e.Graphics, ball);

            if (DifficultyCyberSport)
            {
                enemies5.Draw(e.Graphics, ball);
                enemies6.Draw(e.Graphics, ball);
                enemies7.Draw(e.Graphics, ball);
                enemies8.Draw(e.Graphics, ball);
            }

            if (gameStarted)
            {
                if ((int)stopWatch.Elapsed.TotalSeconds > 60)
                {
                    if (elapsSecondsOld != (int)stopWatch.Elapsed.Seconds)
                    {
                        scoreDestructor += (float)0.1;
                        elapsSecondsOld = (int)stopWatch.Elapsed.Seconds;
                    }
                    score -= (int)scoreDestructor;
                    if (scoreDestructor > 1)
                        scoreDestructor = (float)0;
                }
                
                elapsSecondsOld = (int)stopWatch.Elapsed.Seconds;

                e.Graphics.DrawString("score: " + score.ToString(), new Font("Arial", 25), new SolidBrush(Color.White), new PointF(50, 50));
                e.Graphics.DrawString("Time: " + ((int)stopWatch.Elapsed.TotalSeconds).ToString(), new Font("Arial", 22), new SolidBrush(Color.White), new PointF(650, 50));
                //e.Graphics.DrawString("Faults: " + ball.fault.ToString(), new Font("Arial", 22), new SolidBrush(Color.White), new PointF(50, 130));

                if(!DifficultyCyberSport)
                if (enemies1.enemies.Count == 0 &&
                    enemies2.enemies.Count == 0 &&
                    enemies3.enemies.Count == 0 &&
                    enemies4.enemies.Count == 0)
                {
                    stopWatch.Stop();
                    ball.started = false;
                    ball.UpdateOnPlatform(mouseAngle, playerPlatform);
                    e.Graphics.DrawString("You Have Won", new Font("Arial", 42), new SolidBrush(Color.White), new PointF(230, 300));
                }
                else if (enemies1.enemies.Count == 0 &&
                    enemies2.enemies.Count == 0 &&
                    enemies3.enemies.Count == 0 &&
                    enemies4.enemies.Count == 0 &&
                    enemies5.enemies.Count == 0 &&
                    enemies6.enemies.Count == 0 &&
                    enemies7.enemies.Count == 0 &&
                    enemies8.enemies.Count == 0)
                {
                    stopWatch.Stop();
                    ball.started = false;
                    ball.UpdateOnPlatform(mouseAngle, playerPlatform);
                    e.Graphics.DrawString("You Have Won", new Font("Arial", 42), new SolidBrush(Color.White), new PointF(230, 300));
                }
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            ball.Move(playerPlatform);
            //enemy.Update(ball);
            enemies1.Update(ball);
            enemies2.Update(ball);
            enemies3.Update(ball);
            enemies4.Update(ball);

            if (DifficultyCyberSport)
            {
                enemies5.Update(ball);
                enemies6.Update(ball);
                enemies7.Update(ball);
                enemies8.Update(ball);
            }
            Canvas.Invalidate();
        }

        public static float AngleTo360DegreeSystem(float angle)
        {
            if (angle < 0)
                return 180 + (180 + angle);
            if (angle > 360)
                return angle - 360;
            return angle;
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if(!ball.started)
                ball.Click(AngleTo360DegreeSystem(180 * mouseAngle / (float)Math.PI), playerPlatform);
            stopWatch.Start();
            gameStarted = true;
        }

        private void ColourScheme_MouseClick(object sender, MouseEventArgs e)
        {
            colorScheme.Update(new Point(e.X, e.Y));

            SetBackground(colorScheme.SelectedColor);
            SetBackgroundMainMenu(colorScheme.SelectedColor);
        }

        private void buttonEasy_Click(object sender, EventArgs e)
        {
            score = 0;
            stopWatch.Reset();
            ball.started = false;
            ball.UpdateOnPlatform(mouseAngle, playerPlatform);

            SetBackground(Color.LightSeaGreen);
            SetBackgroundMainMenu(Color.LightSeaGreen);

            enemies1 = new Enemies(7, 50, new Pen(new SolidBrush(Color.FromArgb(200, 255, 186, 2)), 25), center, true, (float)0.2, 7);
            enemies2 = new Enemies(4, 90, new Pen(new SolidBrush(Color.FromArgb(200, 217, 68, 48)), 20), center, false, (float)0.3, 5);
            enemies3 = new Enemies(8, 120, new Pen(new SolidBrush(Color.FromArgb(200, 23, 109, 237)), 22), center, true, (float)0.4, 4);
            enemies4 = new Enemies(10, 145, new Pen(new SolidBrush(Color.FromArgb(200, 0, 155, 87)), 16), center, false, (float)0.5, 1);

            ball.speed = 3;
            playerPlatform.sweepAngle = 40;
            playerPlatform.penPlatform.Width = 14;

            DifficultyCyberSport = false;
        }

        private void buttonMedium_Click(object sender, EventArgs e)
        {
            score = 0;
            stopWatch.Reset();
            ball.started = false;
            ball.UpdateOnPlatform(mouseAngle, playerPlatform);

            SetBackground(Color.FromArgb(44, 120, 120));
            SetBackgroundMainMenu(Color.FromArgb(44, 120, 120));

            enemies1 = new Enemies(9, 50, new Pen(new SolidBrush(Color.FromArgb(200, 255, 186, 2)), 25), center, true, (float)0.3, 7);
            enemies2 = new Enemies(7, 90, new Pen(new SolidBrush(Color.FromArgb(200, 217, 68, 48)), 20), center, false, (float)0.4, 5);
            enemies3 = new Enemies(10, 120, new Pen(new SolidBrush(Color.FromArgb(200, 23, 109, 237)), 22), center, true, (float)0.6, 4);
            enemies4 = new Enemies(18, 145, new Pen(new SolidBrush(Color.FromArgb(200, 0, 155, 87)), 16), center, false, (float)0.6, 1);

            ball.speed = 4;
            playerPlatform.sweepAngle = 30;
            playerPlatform.penPlatform.Width = 14;

            DifficultyCyberSport = false;
        }

        private void buttonHard_Click(object sender, EventArgs e)
        {
            score = 0;
            stopWatch.Reset();
            ball.started = false;
            ball.UpdateOnPlatform(mouseAngle, playerPlatform);

            SetBackground(Color.FromArgb(21, 21, 66));
            SetBackgroundMainMenu(Color.FromArgb(21, 21, 66));

            enemies1 = new Enemies(8, 50, new Pen(new SolidBrush(Color.FromArgb(200, 255, 186, 2)), 25), center, true, (float)0.4, 7);
            enemies2 = new Enemies(10, 90, new Pen(new SolidBrush(Color.FromArgb(200, 217, 68, 48)), 20), center, false, (float)0.6, 5);
            enemies3 = new Enemies(10, 120, new Pen(new SolidBrush(Color.FromArgb(200, 23, 109, 237)), 22), center, true, (float)0.8, 4);
            enemies4 = new Enemies(30, 145, new Pen(new SolidBrush(Color.FromArgb(200, 0, 155, 87)), 16), center, false, (float)1, 1);

            ball.speed = 5;
            playerPlatform.sweepAngle = 20;
            playerPlatform.penPlatform.Width = 14;

            DifficultyCyberSport = false;
        }

        private void buttonVeryHard_Click(object sender, EventArgs e)
        {
            score = 0;
            stopWatch.Reset();
            ball.started = false;
            ball.UpdateOnPlatform(mouseAngle, playerPlatform);

            SetBackground(Color.FromArgb(54, 54, 60));
            SetBackgroundMainMenu(Color.FromArgb(54, 54, 60));

            enemies1 = new Enemies(10, 50, new Pen(new SolidBrush(Color.FromArgb(200, 255, 186, 2)), 25), center, true, (float)0.6, 7);
            enemies2 = new Enemies(15, 90, new Pen(new SolidBrush(Color.FromArgb(200, 217, 68, 48)), 20), center, false, (float)0.8, 5);
            enemies3 = new Enemies(12, 120, new Pen(new SolidBrush(Color.FromArgb(200, 23, 109, 237)), 22), center, true, (float)1, 4);
            enemies4 = new Enemies(36, 145, new Pen(new SolidBrush(Color.FromArgb(200, 0, 155, 87)), 16), center, false, (float)1.2, 1);

            ball.speed = 6;
            playerPlatform.sweepAngle = 14;
            playerPlatform.penPlatform.Width = 14;

            DifficultyCyberSport = false;
        }

        private void buttonCyberSport_Click(object sender, EventArgs e)
        {
            score = 0;
            stopWatch.Reset();
            ball.started = false;
            ball.UpdateOnPlatform(mouseAngle, playerPlatform);

            SetBackground(Color.Black);
            SetBackgroundMainMenu(Color.Black);
            enemies1 = new Enemies(4, 30, new Pen(new SolidBrush(Color.FromArgb(200, 255, 186, 2)), 14), center, true, (float)0.9, 7);
            enemies2 = new Enemies(6, 50, new Pen(new SolidBrush(Color.FromArgb(200, 217, 68, 48)), 12), center, false, (float)1.1, 5);
            enemies3 = new Enemies(8, 70, new Pen(new SolidBrush(Color.FromArgb(200, 23, 109, 237)), 14), center, true, (float)1.3, 4);
            enemies4 = new Enemies(10, 90, new Pen(new SolidBrush(Color.FromArgb(200, 0, 155, 87)), 10), center, false, (float)1.5, 1);

            enemies5 = new Enemies(8, 110, new Pen(new SolidBrush(Color.FromArgb(200, 33, 112, 230)), 14), center, true, (float)0.9, 7);
            enemies6 = new Enemies(6, 130, new Pen(new SolidBrush(Color.FromArgb(200, 15, 92, 222)), 12), center, false, (float)1.1, 5);
            enemies7 = new Enemies(8, 150, new Pen(new SolidBrush(Color.FromArgb(200, 46, 122, 220)), 14), center, true, (float)1.3, 4);
            enemies8 = new Enemies(4, 170, new Pen(new SolidBrush(Color.FromArgb(200, 10, 85, 210)), 10), center, false, (float)1.5, 1);


            ball.speed = 8;
            playerPlatform.sweepAngle = 11;
            playerPlatform.penPlatform.Width = 18;

            DifficultyCyberSport = true;
        }
    }
}
