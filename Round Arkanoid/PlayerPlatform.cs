using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Round_Arkanoid
{
    class PlayerPlatform
    {
        public Pen penOrbit = new Pen(new SolidBrush(Color.FromArgb(130, 255, 255, 255)), 8);
        public Pen penPlatform = new Pen(new SolidBrush(Color.FromArgb(255,Color.WhiteSmoke)), 14);
        public float radius = 280;
        Point center;
        public float sweepAngle = 20;
        public float locationRadius;
        public float startAngle;
        public float endAngle;
        public float centerAngle;

        public PlayerPlatform(Point center)
        {
            this.center = center;
        }
        
        public void DrawOrbit(Graphics g)
        {
            g.DrawEllipse(penOrbit, new RectangleF(center.X - radius, center.Y - radius, radius * 2, radius * 2));

            locationRadius = radius - penPlatform.Width / 2;
        }

        public void DrawPlatform(Graphics g, float newAngleLocation)
        {
            startAngle = MainWindow.AngleTo360DegreeSystem(newAngleLocation - sweepAngle / 2);
            endAngle = MainWindow.AngleTo360DegreeSystem(startAngle + sweepAngle);
            centerAngle = newAngleLocation;
            
            g.DrawArc(penPlatform, new RectangleF(center.X - radius, center.Y - radius, radius * 2, radius * 2), startAngle, sweepAngle);
        }
    }
}
