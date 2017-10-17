using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 

namespace NeuralNet
{
    class Matrix
    {
        private int NBcolumns;
        private int NBRows;
        public float[,] matrix;

        // copy constructor
        public Matrix(Matrix M) : this(M.matrix)
        {
        }

        public Matrix(int nbRow, int nbCols)
        {
            this.NBcolumns = nbCols;
            this.NBRows = nbRow;
            this.matrix = new float[this.NBRows, this.NBcolumns];
        }

        public Matrix(float[,] tab)
        {
            this.NBcolumns = tab.GetLength(1);
            this.NBRows = tab.GetLength(0);
            this.matrix = tab;
        }

        public void Init()
        {
            for (int i = 0; i < this.NBRows; i++)
            for (int j = 0; j < this.NBcolumns; j++)
                    this.matrix[i, j] = 0;
        }

        public void RandomInit()
        {
            for (int i = 0; i < this.NBRows; i++)
            for (int j = 0; j < this.NBcolumns; j++)
                 this.matrix[i, j] = Utils.RND();
        }

        public float this[int indexrow, int indexcol]
        {
            get { return matrix[indexrow, indexcol]; }
            set { matrix[indexrow, indexcol] = value; }
        }


        public Matrix Transpose()
        {
            float[,] tableau_temp = new float[this.NBcolumns, this.NBRows];

            for (int j = 0; j < this.NBRows; j++)
            for (int i = 0; i < this.NBcolumns; i++)
                    tableau_temp[i, j] = this.matrix[j, i];

            return new Matrix(tableau_temp);
        }


        public static Matrix operator +(Matrix A, Matrix B)
        {
            try
            {
                if (A.NBRows == B.NBRows && A.NBcolumns == B.NBcolumns)
                {
                    Matrix C = new Matrix(A.NBRows, A.NBcolumns);
                    for (int i = 0; i < A.NBRows; i++)
                    for (int j = 0; j < A.NBcolumns; j++)
                       C[i, j] = A[i, j] + B[i, j];
                    return C;
                }
                else
                    throw new Exception("ADD matrix size problem");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("" + e);
                return null;
            }
        }

        public static Matrix operator -(Matrix A, Matrix B)
        {
            try
            {
                if (A.NBRows == B.NBRows && A.NBcolumns == B.NBcolumns)
                {
                    Matrix C = new Matrix(A.NBRows, A.NBcolumns);
                    for (int i = 0; i < A.NBRows; i++)
                    for (int j = 0; j < A.NBcolumns; j++)
                            C[i, j] = A[i, j] - B[i, j];
                    return C;
                }
                else
                {
                    throw new Exception("SUB matrix size problem");
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("" + e);
                return null;
            }
        }


        public static Matrix operator *(Matrix A, Matrix B)
        {
            try
            {
                if (A.NBcolumns == B.NBRows)
                {
                    Matrix C = new Matrix(A.NBRows, B.NBcolumns);
                    float[,] cc = C.matrix;
                    float[,] aa = A.matrix;
                    float[,] bb = B.matrix;
                    int Anb_lignes = A.NBRows;
                    int Bnb_colonnes = B.NBcolumns;
                    int Anb_colonnes = A.NBcolumns;

                    for (int i = 0; i < Anb_lignes; i++)
                    for (int j = 0; j < Bnb_colonnes; j++)
                    for (int k = 0; k < Anb_colonnes; k++)
                        cc[i, j] += aa[i, k] * bb[k, j];
                  
                    return C;
                }
                else
                {
                    throw new Exception("MUL matrix size problem");
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("" + e);
                return null;
            }
        }

        public static Matrix operator *(float n, Matrix A)
        {
            Matrix B = new Matrix(A.NBRows, A.NBcolumns);

            for (int i = 0; i < A.NBRows; i++)
            for (int j = 0; j < A.NBcolumns; j++)
                B[i, j] = n * A[i, j];

            return B;
        }

        public static Matrix operator *(Matrix A, float n)
        {
            Matrix B = n * A;
            return B;
        }

        public static Matrix operator /(Matrix A, float n)
        {
            Matrix B = new Matrix(A.NBRows, A.NBcolumns);

            for (int i = 0; i < A.NBRows; i++)
            for (int j = 0; j < A.NBcolumns; j++)
               B[i, j] = A[i, j] / n;
         

            return B;
        }
    }
}
