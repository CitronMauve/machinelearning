using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//http://vision.stanford.edu/teaching/cs231n/linear-classify-demo/

namespace NeuralNet
{
    public partial class Form1 : Form
    {

        static public Graphique G = new Graphique(600, 600);
        static public PictureBox Schema;
        static public TextBox iteration;
    

        static public TextBox iteration2;
       


        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = G.Bitmap;
            Schema = pictureBox1;
            iteration = textBox1;
            
            iteration2 = this.textBox2;
           
        }


        public static int GetMyCategorie(double x1, double x2)
        {
            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //G.DrawCat(GetMyCategorie);
            G.DrawAxis();
            pictureBox1.Invalidate();
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }
 

        private void button3_Click_1(object sender, EventArgs e)
        {
            _Score.test1(G);
           pictureBox1.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _Score.test2(G);
            pictureBox1.Invalidate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _Score.test3(G);
            pictureBox1.Invalidate();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _Score.test4(G);
            pictureBox1.Invalidate();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _gradient.GradEstimation(G);
            pictureBox1.Invalidate();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _gradient.GradLitteral(G);
            pictureBox1.Invalidate();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            _gradient.Optim2D(G);
            pictureBox1.Invalidate();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            _gradient.Optim2Dmax(G);  
            pictureBox1.Invalidate();
        }
 

        private void button11_Click(object sender, EventArgs e)
        {
            OneLayer.Final(G);
            pictureBox1.Invalidate();
        }

        private void DrawData(object sender, EventArgs e)
        {
            G.ClearWhite();
            G.DrawAxis();
            G.DrawData();
            Form1.Schema.Invalidate();
            Form1.Schema.Update();
        }

        int categorie()
        {
            if (radioButton3.Checked) return 0;
            if (radioButton2.Checked) return 1;
            return 2;
        }

        private void AddRandom(object sender, EventArgs e)
        {

            Element.List.Add(new Element(Utils.RND(), Utils.RND(), categorie()));
            DrawData(null, null);
        }

        
        private void ClickOnPicture(object sender, MouseEventArgs e)
        {
            float x = e.X;
            float y = e.Y;
            float xx = x / pictureBox1.Width *2 - 1;
            float yy =  (y / pictureBox1.Height *2 - 1);
            yy =  - yy;
            Element.List.Add(new NeuralNet.Element( xx, yy, categorie() ));
            DrawData(null, null);


        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            _multi.Final(G);
            pictureBox1.Invalidate();
        }

        private void iter_Click(object sender, EventArgs e)
        {

        }

        private void labelloss_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      
    }
}
