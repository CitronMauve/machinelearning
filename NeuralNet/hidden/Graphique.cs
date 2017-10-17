using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNet
{
    public class Graphique : FastBitmap
    {
        public Graphique(int W, int H) : base(W,H)
        {
            centreX = W / 2;
            centreY = H / 2;
        }
        private int L = 600;
        private int H = 600;
        private int centreX;
        private int centreY;
        private float scaleX = 2;
        private float scaleY = 2;

       
        public int GetL() { return L; }
        public int GetH() { return H; }

        

        Color[] CatColor = { Color.Blue, Color.Green, Color.Red };

        public float XPixToVal(int x) { return ((float)(x - centreX)) / L * scaleX; }
        public float YPixToVal(int y) { return ((float)(y - centreY)) / H * scaleY; }

        public int XValToPix(double x) { return (int) (x / scaleX * L + centreX);  }
        public int YValToPix(double y) { return (int) (y / scaleY * H  + centreY); }



        

        // draw a cross
        public void Cross(double x, double y, Color c)
        {
            int pixX = XValToPix(x);
            int pixY = YValToPix(y);
            for(int i = -5; i <= 5; i++)
            {
                SetPixel(pixX+i, pixY+i, c);
                SetPixel(pixX+i, pixY-i, c);
            }
        }

        // draw a circle
        public void Rond(double x, double y, Color c)
        {
            int pixX = XValToPix(x);
            int pixY = YValToPix(y);
            for (int xx = -10; xx <= 10; xx++)
            for (int yy = -10; yy <= 10; yy++)
            if ( xx*xx+yy*yy<30)
                SetPixel(pixX + xx, pixY + yy, c);
        }

        public void DrawData()
        {
            foreach (Element E in Element.List)
                Rond(E.u1, E.u2, CatColor[E.ID]);
        }

        public void DrawAxis()
        {
            for (int i = 0; i < H; i++)
                SetPixel(centreX, i, Color.Black);

            for (int i = 0; i < L; i++)
                SetPixel(i, centreY,  Color.Black);
        }

        
        // draw the straight-line ax+by+c=0   0x-1y+0 = 0 => y = 0
        public void DrawLine(double a, double b, double c, Color coul)
        {
            double epsilon = 0.00001;
            double ma = Math.Abs(a);
            double mb = Math.Abs(b);
            if (ma + mb < epsilon) return;

            if (ma < epsilon)  // droite hoz
            {
                for (int i = 0; i < L; i++)
                {
                    int test = YValToPix(-c / b);
                    SetPixel(i, YValToPix(-c / b), coul);
                }
                return;
            }
            if (mb < epsilon) // droite vert
            {
                for (int i = 0; i < H; i++)
                    SetPixel(XValToPix(-c / a), i, coul);
                return;
            }

            if (ma < mb)  // cadran G/D
            {
                double aa = -a / b;
                double bb = -c / b;
                for (int x = 0; x < L; x++)
                {
                    double xx = XPixToVal(x);
                    double yy = -a / b * xx - c / b;
                    SetPixel(x, YValToPix(yy), coul);
                    SetPixel(x, YValToPix(yy)+1, coul);
                    SetPixel(x, YValToPix(yy)-1, coul);
                }
            }
            else  // cadran H/B
            {
                double aa = -a / b;
                double bb = -c / b;
                for (int y = 0; y < H; y++)
                {
                    double yy = YPixToVal(y);
                    double xx = -b / a * yy - c / a;
                    SetPixel(YValToPix(xx), y, coul);
                    SetPixel(YValToPix(xx)+1, y, coul);
                    SetPixel(YValToPix(xx)-1, y, coul);
                }
            }
        } 
    
        

    }
}
 