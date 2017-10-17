using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
 


namespace NeuralNet
{
    class _multi
    {
        static Matrix L_W;
        static Matrix hMax;
        static Matrix L_W2;
        
        static int h = 1000; // size of hidden layer 
        static int D = 3; // dimension (+1 for bias)
        static int K = 3; // number of categories
        static int delta = 4;


        public static void Final(Graphique G)
       {
            Element.InitSpirale();
            List<Element> data = Element.List;

            ////////////////////////////////////////////////////////////////////////
       
            int round_nbr = 2000;
    
 

            // gradient descent loop
            for (int round = 0; round < round_nbr; round++)
            {
                float data_loss = 0;

              
 

                if (round % 20 == 0)
                {
                    G.ClearBlack();
                    DrawScore();

                    G.DrawAxis();
                    G.DrawData();
                    Form1.Schema.Invalidate();
                    Form1.Schema.Update();
                    Form1.iteration2.Text += "Iteration " + round + " : Loss = " + data_loss + "\r\n";
                    Form1.iteration2.Update();
                }
            }
        }


        static public float[] compute_score(float _x, float _y)
        {
            Matrix x = new Matrix(3, 1);

            float[] ret = new float[3];

            ret[0] = 0;
            ret[1] = 0;
            ret[2] = 0;

            return ret;
        }

        // draw the score function  f(x,y)=ax+by+c 
        static public void DrawScore()
        {
            Graphique G = Form1.G;
            int pas = 3;

            for (int yecran = 0; yecran < G.GetH(); yecran+=pas)
            {
                for (int xecran = 0; xecran < G.GetL(); xecran+=pas)
                {

                    float x = G.XPixToVal(xecran);
                    float y = G.YPixToVal(yecran);

                    // on calcule le score pour chaque pixel de l'ecran
                    float[] sco = compute_score(x, y);
                    int first = 0;
                    int second = 1;

                    // look for biggest and second biggest score
                    if ((sco[0] >= sco[1]) && (sco[1] >= sco[2])) { first = 0; second = 1; }
                    if ((sco[0] >= sco[2]) && (sco[2] >= sco[1])) { first = 0; second = 2; }
                    if ((sco[1] >= sco[0]) && (sco[0] >= sco[2])) { first = 1; second = 0; }
                    if ((sco[1] >= sco[2]) && (sco[2] >= sco[0])) { first = 1; second = 2; }
                    if ((sco[2] >= sco[0]) && (sco[0] >= sco[1])) { first = 2; second = 0; }
                    if ((sco[2] >= sco[1]) && (sco[1] >= sco[0])) { first = 2; second = 1; }

                    int cat = first;
                    float h = sco[first] - sco[second];
                    h *= 4;
                    Utils.Inside(0f, 1f, ref h);



                    int[,] Legende = { {150,150,255},
                                       {150,255,150},
                                       {255,150,150} };

                    int RR = (int)(Legende[cat, 0] * h);
                    int GG = (int)(Legende[cat, 1] * h);
                    int BB = (int)(Legende[cat, 2] * h);


                    Color c = Color.FromArgb(RR, GG, BB);
                    for (int xx = 0; xx < pas; xx++)
                    for (int yy = 0; yy < pas; yy++)
                        G.SetPixel(xecran+xx, yecran+yy, c);
                }
            }
                
        }

    }
}
