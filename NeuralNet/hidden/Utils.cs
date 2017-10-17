using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{
    class Utils
    {

        static public float Max(float a, float b)
        {
            if (a > b) return a;
            else return b;
        }

        static public float Max(float a, float b, float c)
        {
            return Max(a,Max(b,c));
        }


        static Random _r = new Random();

        // return [-1,1]
        public static float RND()
        {
            return (float) _r.NextDouble()*2-1;
        }

        public static int RNDINT13()
        {
            return _r.Next(0,3);
        }


        public static void minmax(ref int min, ref int max)
        {
            if ( max >= min) return;
            int t = min;
            min = max;
            max = t;
        }

        public static void Inside(double min, double max, ref double val)
        {
            if ( val < min ) val = min;
            if (val > max) val = max;
        }

        public static void Inside(float min, float max, ref float val)
        {
            if (val < min) val = min;
            if (val > max) val = max;
        }

        public static double Max(double a, double b, double c)
        {
            if ((a >= b) && (a >= c)) return a;
            if ((b >= a) && (b >= c)) return b;
            return c;
        }

        public static double Min(double a, double b, double c)
        {
            if ((a <= b) && (a <= c)) return a;
            if ((b <= a) && (b <= c)) return b;
            return c;
        }

        
        //////////////////////////////////////////////////////////////
        //
        // conversion double => color / en fonction de la categorie
        //  
        // 0 => ColScale         : 0 0 0   à 255 200 200        

        public static float ColScale = 2;
        public static Color ScoreToColor(double v, int cat)
        {
            Inside(0, ColScale, ref v);
            v /= ColScale;
            
            int R = 200;
            int G = 200;
            int B = 200;
            if (cat == 0) R = 255;
            if (cat == 1) G = 255;
            if (cat == 2) B = 255;
            R = (int) (R*v); 
            B = (int)(B * v);
            G = (int)(G * v);
            return Color.FromArgb(R, G, B);
        }

        // op inverse
        public static float ColorToScore(Color c)
        {
            float R = c.R / 255.0f;
            float G = c.G / 255.0f;
            float B = c.B / 255.0f;
            
            return Utils.Max(R, G, B) * ColScale;
        }

        ////////////////////////////////////////////////////////////////
        //
        //  conversion double => HUE color 

        public static Color ScoreToHUE(double V)
        {
            Inside(0, 1, ref V);

            double H =  360- V * 360;

            // HSV to RGB with S=V=1  H = score
            //
            // C = 1
            // X = (1 - | (H / 60°) mod 2 - 1 |)
            // m = 0

            double HH = H / 60;
            while (HH > 2) HH -= 2;
            HH -= 1;
            double X = Math.Abs(HH);

            double R = 0, G = 0, B = 0;
                  
                                     
            if ((  0 <= H) && (H <=  60)) { R = 1-X/2; G = 0; B = 0; }
            if (( 60 <= H) && (H <= 120)) { R = 1; G = X; B = 0; }
            if ((120 <= H) && (H <= 180)) { R = X; G = 1; B = 0; }
            if ((180 <= H) && (H <= 240)) { R = 0; G = 1; B = X; }
            if ((240 <= H) && (H <= 300)) { R = 0; G = X; B = 1; }
            if ((300 <= H) && (H <= 360)) { R = 0; G = 0; B = 1-X*.8; }



            int RR = (int)(R * 255);
            int GG = (int)(G * 255);
            int BB = (int)(B * 255);

            return Color.FromArgb(RR, GG, BB);
        }

    }
}
