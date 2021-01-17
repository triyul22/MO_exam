using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MO_Lab2
{
    class Matrix
    {
        int n;
        double[][] matrix;
        double[][] L_matrix;
        double[][] U_matrix;
        public Matrix(int n, double[] doubleArr)
        {
            this.n = n;
            matrix = new double[n][];
            int counter = 0;
            //double[] row;
            for (int i = 0; i < n; i++)
            {
                //row = new double[n];
                matrix[i] = new double[n];
                for (var j = 0; j < n; j++)
                {
                    matrix[i][j] = doubleArr[counter++];
                }
                //this.matrix[i] = row;
            }
        }

        public void LU()
        {
            U_matrix = matrix;
            L_matrix = new double[n][];

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    L_matrix[j] = new double[n];
                    L_matrix[j][i] = U_matrix[j][i] / U_matrix[i][i];
                }
            }

            for (int k = 1; k < n; k++)
            {
                for (int i = k - 1; i < n; i++)
                {
                    for (int j = i; j < n; j++)
                    {
                        L_matrix[j][i] = U_matrix[j][i] / U_matrix[i][i];
                    }
                }

                for (int i = k; i < n; i++)
                {
                    for (int j = k - 1; j < n; j++)
                    {
                        U_matrix[i][j] = U_matrix[i][j] - L_matrix[i][k - 1] * U_matrix[k - 1][j];
                    }
                }
            }
        }

        private void show(double[][] matrix)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($" {matrix[i][j]} ");
                }
                Console.WriteLine();
            }
        }

        public void showL()
        {
            show(L_matrix);
        }

        public void showU()
        {
            show(U_matrix);
        }

        public void showMatrix()
        {
            show(matrix);
        }
    }
}
