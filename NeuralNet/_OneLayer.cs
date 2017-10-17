using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNet
{
    class OneLayer
    {

        public static void Final(Graphique G)
        { 
            List<Element> data = Element.List;
            Form1.iteration.Text = "";

            int K = 3; // nombre de classes
            int D = 3; // dimension 2 + 1 for the biais
            Matrix W = new Matrix(K, D);
            W.RandomInit();
            double data_loss = 0;

            //////////////////////////////////////////////////////////////////////////////////////////////

            
            // gradient descent loop
            for (int round = 0; round < 200; round++)
            {
             
 

                /////////////////////////////////////////////////////////////////////////////////////////

                if (round % 10 == 0)
                {
                    G.ClearBlack();
                    DrawScore(W.matrix);
                    
                    G.DrawAxis();
                    G.DrawData();
                    Form1.Schema.Invalidate();
                    Form1.Schema.Update();
                    Form1.iteration.Text += "Iteration " + round + " : Loss = " + data_loss + "\r\n"; 
                    Form1.iteration.Update();
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////

        static public void LevelSet(float[,] W, float value)
        {
            Graphique G = Form1.G;

            for (int yecran = 0; yecran < G.GetH(); yecran++)
                for (int xecran = 0; xecran < G.GetL(); xecran++)
                {
                    float x = G.XPixToVal(xecran);
                    float y = G.YPixToVal(yecran);

                    float[] sco = new float[3];
                    for (int i = 0; i < 3; i++)
                        sco[i] = W[i, 0] * x + W[i, 1] * y + W[i, 2];

                    float mx = sco.Max();

                    if (Math.Abs(mx - value) < 0.001)
                        G.SetPixel(xecran, yecran, Color.Red);
                }
        }

        // draw the score function  f(x,y)=ax+by+c 
        static public void DrawScore(float[,] W)
        {
            Graphique G = Form1.G;

            for (int yecran = 0; yecran < G.GetH(); yecran++)
                for (int xecran = 0; xecran < G.GetL(); xecran++)
                {

                    float x = G.XPixToVal(xecran);
                    float y = G.YPixToVal(yecran);

                    float[] sco = new float[3];
                    for (int i = 0 ; i < 3 ; i++)
                        sco[i] = W[i,0]*x + W[i,1] * y + W[i,2];
                    int first = 0;
                    int second = 1;

                    // look for biggest and second biggest score
                    if ((sco[0] >= sco[1]) && (sco[1] >= sco[2])) { first = 0; second=1; }
                    if ((sco[0] >= sco[2]) && (sco[2] >= sco[1])) { first = 0; second=2; }
                    if ((sco[1] >= sco[0]) && (sco[0] >= sco[2])) { first = 1; second=0; }
                    if ((sco[1] >= sco[2]) && (sco[2] >= sco[0])) { first = 1; second=2; }
                    if ((sco[2] >= sco[0]) && (sco[0] >= sco[1])) { first = 2; second=0; }
                    if ((sco[2] >= sco[1]) && (sco[1] >= sco[0])) { first = 2; second=1; }

                    int cat = first;
                    float h = sco[first]-sco[second];
                    h *= 4;
                    Utils.Inside(0,1,ref h);
                    


                    int[,] Legende = { {150,150,255},
                                       {150,255,150},
                                       {255,150,150} };
                    
                    int RR = (int)(Legende[cat,0]*h);
                    int GG = (int)(Legende[cat,1]*h);
                    int BB = (int)(Legende[cat,2]*h);


                    Color c = Color.FromArgb(RR, GG, BB);
                    G.SetPixel(xecran, yecran, c);
                }
        }

    }
}
