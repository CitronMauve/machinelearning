using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{

    class Element
    {
        public float u1;
        public float u2;
        public int ID;
        public Element(float uu1, float uu2, int t) { u1 = uu1; u2 = uu2; ID = t; }

        // 0 : blue
        // 1 : green
        // 2 : red
        // 3  : nothing
        public static List<Element> List = new List<Element>()

        {
                new Element(  0.50f,  0.40f,  0 ),
                new Element(  0.80f,  0.30f,  0 ),
                new Element(  0.30f,  0.80f,  0 ),
                new Element( -0.40f,  0.30f,  1 ),
                new Element( -0.30f,  0.70f,  1 ),
                new Element( -0.70f,  0.20f,  1 ),
                new Element(  0.70f, -0.40f,  2 ),
                new Element(  0.50f, -0.60f,  2 ),
                new Element( -0.40f, -0.50f,  1 )
        };

        public static void InitSpirale()
        {
            List.Clear();

            int N = 100;   //number of points per class
         
            int K = 3;      //number of classes

            for (int i = 0; i < N; i++)
            {
                float r = (float)i / (float)N;

                for (int k = 0; k < K; k++)
                {
                    float t = ((float)i * 4.0f / (float)N) + ((float)k * 4.0f) + (float)Utils.RND() * 0.2f;

                    List.Add(new Element( (float) (r * Math.Sin(t)),
                                          (float) (r * Math.Cos(t)), k));
                }
            }

        }

        



    }
}
