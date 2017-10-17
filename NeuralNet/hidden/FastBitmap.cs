using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{


    public class FastBitmap : IDisposable
    {
        public Bitmap Bitmap { get; private set; }
        public byte[] Bits { get; private set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        protected GCHandle BitsHandle { get; private set; }

        public FastBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            Bits = new byte[width * height * 4];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            ClearWhite();
            Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppRgb, BitsHandle.AddrOfPinnedObject());
        }

        public void SetPixel(int x, int y, byte R, byte G, byte B)
        {
            if (x < 0) return;
            if (y < 0) return;
            if (x >= Width) return;
            if (y >= Height) return;

            int yy = Height - y - 1;
            int n = 4 * (yy * Width + x);
            Bits[n + 0] = B;
            Bits[n + 1] = G;
            Bits[n + 2] = R;
        }

        public Color GetPixel(int x, int y)
        {
            if (x < 0) { return Color.Black; }
            if (y < 0) { return Color.Black;  }
            if (x >= Width)  { return Color.Black;  }
            if (y >= Height) { return Color.Black; }

            int yy = Height - y - 1;
            int n = 4 * (yy * Width + x);
            int B = Bits[n + 0];
            int G = Bits[n + 1];
            int R = Bits[n + 2];
            return Color.FromArgb(R,G,B);
        }

       

        public void SetPixel(int x, int y, Color c)
        {
            if (x < 0) return;
            if (y < 0) return;
            if (x >= Width) return;
            if (y >= Height) return;

            int yy = Height - y - 1;
            int n = 4 * (yy * Width + x);
            Bits[n + 0] = c.B;
            Bits[n + 1] = c.G;
            Bits[n + 2] = c.R;
        }


        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }




        public void ClearWhite()
        {
            int n = Height * Width*4;
            for (int i = 0; i < n; i++)
                Bits[i] = 255;
        }

        public void ClearBlack()
        {
            int n = Height * Width * 4;
            for (int i = 0; i < n; i++)
                Bits[i] = 0;
        }



        public void Test()
        {
            ClearWhite();
            for (int i = 0; i < 400; i++)
            {
                SetPixel(i, i, Color.Red);
                SetPixel(399-i, i, Color.Blue);

                SetPixel(i, 0, Color.Green);
                SetPixel(i, 399, Color.Green);
                SetPixel(0, i, Color.Red);
                SetPixel(399, i, Color.Red);

            }
        }
    }
}
