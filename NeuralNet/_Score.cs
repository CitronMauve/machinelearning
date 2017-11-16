using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{
    class _Score
    {
        public static void test1(Graphique G)
        {
            G.ClearBlack();
            float[,] W = new float[3, 3]
            {
                {  1, 0, 0 },
                { -1, 0, 0 },
                {  0, 1, 0 }
            };

            OneLayer.DrawScore(W);
            G.DrawAxis();
        }

        public static void test2(Graphique G)
        {
            G.ClearBlack();

            float[,] W = new float[3, 3]
            {
                {  1, 0, 0 },
                { -1, 0, 0 },
                {  0, 1f, 0 }
            };
            OneLayer.DrawScore(W);
            OneLayer.LevelSet(W, 0.9f);

            G.DrawAxis();
        }

        public static void test3(Graphique G)
        {
            G.ClearBlack();
            float[,] W = new float[3, 3]
           {
                {  1, 0, 0 },
                { -1, 0, 1.5f },
                {  0, 1, 0 }
           };
            OneLayer.DrawScore(W);
            OneLayer.LevelSet(W, 0.5f);
            G.DrawAxis();
        }

        public static void test4(Graphique G)
        {
            G.ClearBlack();
            
            float[,] W = new float[3, 3]
            {
                {  1, 0, 0 },
                { -1, 0, 0 },
                {  1f, 1f, 0 }
            };
            
            /*float[,] W = new float[3, 3]
            {
                {  1, 0f, 0f },
                { -1, 0f, 0f },
                {  1f, 0.8f, 0f }
            };*/
            OneLayer.DrawScore(W);
            OneLayer.LevelSet(W, 0.4f);
            G.DrawAxis();
        }






        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////


        // draw the score function  f(x,y)=ax+by+c 
        static public void DrawScore(float a, float b, float c, int CAT)
        {
            Graphique G = Form1.G;

            for (int yecran = 0; yecran < G.GetH(); yecran++)
                for (int xecran = 0; xecran < G.GetL(); xecran++)
                {

                    float x = G.XPixToVal(xecran);
                    float y = G.YPixToVal(yecran);

                    float score = a * x + b * y + c;

                    Color cc = G.GetPixel(xecran, yecran);
                    float level = Utils.ColorToScore(cc);

                    if (score < level) continue;

                    G.SetPixel(xecran, yecran, Utils.ScoreToColor(score, CAT));
                }
        }

        /*
            fct scores_hinge(W, X, C, D)
            {
	            score = [];
	            for (k = 0; k < W.length; ++k)
	            {
		            s = 0;
		            for (n = 0; n < W[0].length; ++n)
		            {
			            s+= W[k, n] * X[n];
		            }
		            score.append(s);
	            }

	            HL = []
                for(int i = 0; i < W.length; i++){
                    hinge = 0
	                for(j = 0; j < W[0].length; ++j)
	                {
		                if(max != C)
                            hinge += max(0, D + score[j] - score[C])
	                }
                    HL.append(hinge)
                }

	            return score, HL
            }

            def gradL(H, X, C)
            {
                dL/dW
            }
         */



    }
}
