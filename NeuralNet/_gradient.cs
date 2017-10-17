using System;
using System.Drawing;
 

namespace NeuralNet
{
    class _gradient
    {
        const double E = 0.1;

        public static double f(double x) { return Math.Tanh(Math.Tan(x + Math.Sin(x) / 100)) * x - .7; }
        public static double df(double x) { return (f(x + E) - f(x)) / E; }
    

        public static void GradEstimation(Graphique G)
        {
            G.ClearWhite();
            DrawFnt(f, Color.Red);
            double x = 0.7;
            double gamma = 0.01; // step size multiplier
            double precision = 0.001; // range limit
            double previous_step_size = x;

            while (previous_step_size > precision)
            {
                double prev_x = x;
                x += -gamma * df(prev_x);
                previous_step_size = Math.Abs(x - prev_x);
                G.Cross(x, f(x), Color.Blue);
            }

        }


        public static double g(double x) { return x * x - 0.4 * x - 0.5; }

        public static double dg(double x) { return 2 * x - 0.4; }

        public static void GradLitteral(Graphique G)
        {
            G.ClearWhite();
            DrawFnt(g, Color.Red);
            double x = 1;
            double gamma = 0.01; // step size multiplier
            double precision = 0.001; // range limit
            double previous_step_size = x;

            while (previous_step_size > precision)
            {
                double prev_x = x;
                x += -gamma * dg(prev_x);
                previous_step_size = Math.Abs(x - prev_x);
                G.Cross(x, g(x), Color.Blue);
            }
        }



        public static double Fnt(double x, double y)
        { return x * x + 0.4 * y * y + 0.2 * x - 0.2 * x * y + 0.1; }
        public static double dFntx(double x, double y) { return 2 * x + 0.2 - 0.2 * y; }
        public static double dFnty(double x, double y) { return 0.4 * 2 * y - 0.2 * x; }


        public static void Optim2D(Graphique G)
        {
            G.ClearWhite();
            DrawFnt2D(Fnt);
            G.DrawAxis();
            double gamma = 0.00000001; // step size multiplier
            double precision = 0.00001; // range limit

            double x = 0;
            double y = 0;
            double z = Fnt(x, y);

            while (z > precision)
            {
                x += x - gamma * dFntx(x, y);
                y += y - gamma * dFnty(x, y);
                z = Fnt(x, y);
                G.Cross(x, y, Color.White);
            }
        }
        
        public static double Fntmax(double x, double y)
        {
            double v1 = x*x + 0.4*y*y + 0.1;
            double v2 = 0.5 * x + 0.4 * y + 0.2;

            return Math.Max(v1, v2);
        }

        public static void Optim2Dmax(Graphique G)
        {
            G.ClearWhite();
            DrawFnt2D(Fntmax);
            G.DrawAxis();

            double x = Utils.RND();
            double y = Utils.RND();
            G.Cross(x, y, Color.White);

            ///////////////////////////////////////////////////////////////////


            ///////////////////////////////////////////////////////////////////
        }


        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////

        public delegate double FntX(double x);
        static public void DrawFnt(FntX F, Color c)
        {
            Graphique G = Form1.G;
            for (int xecran = 1; xecran < G.GetH(); xecran++)
            {
                double x = G.XPixToVal(xecran - 1);
                double y = F(x);
                int yecran = G.YValToPix(y);

                double x2 = G.XPixToVal(xecran);
                double y2 = F(x2);
                int yecran2 = G.YValToPix(y2);

                Utils.minmax(ref yecran, ref yecran2);

                for (int yy = yecran; yy <= yecran2; yy++)
                    G.SetPixel(xecran, yy, c);
            }

            G.DrawAxis();
        }

        
        //////////////////////////////////////////////
        
        public delegate double FntXY(double x, double y);


        public static void DrawFnt2D(FntXY Score)
        {
            Graphique G = Form1.G;
            for (int yecran = 0; yecran < G.GetL(); yecran++)
                for (int xecran = 0; xecran < G.GetH(); xecran++)

                {
                    double x = Form1.G.XPixToVal(xecran);
                    double y = Form1.G.YPixToVal(yecran);
                    double s = Score(x, y);
                    Color C = Utils.ScoreToHUE(s);
                    Form1.G.SetPixel(xecran, yecran, C);
                }

        }
    }
}
