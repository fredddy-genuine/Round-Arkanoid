using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Round_Arkanoid
{
    class ColorScheme
    {
        PictureBox pictureBox;
        Color[] colors;
        public Color SelectedColor;

        public ColorScheme(PictureBox pictureBox, Color[] colors)
        {
            this.pictureBox = pictureBox;
            this.colors = colors;
        }

        public void Update(Point point)
        {
            SelectedColor = (new Bitmap(pictureBox.Image, pictureBox.Width, pictureBox.Height)).GetPixel(point.X, point.Y);
        }

        public void Draw(Graphics g)
        {
            Bitmap bmp_image = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics graphics_bmp = Graphics.FromImage(bmp_image);

            //graphics_bmp.DrawString("Color scheme", new Font("Microsoft Sans Serif", 18, FontStyle.Bold), new SolidBrush(Color.White), new PointF(6, 10));
            int counter = 0;
            bool breakedFromJ = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (counter < colors.Length)
                        graphics_bmp.FillRectangle(new SolidBrush(colors[counter]), new Rectangle(10 + j*35, 40 + i * 35, 30, 30));
                    else
                        break;
                    counter++;
                }

                if (breakedFromJ)
                    break;
            }

            pictureBox.Image = bmp_image;
        }
    }
}
