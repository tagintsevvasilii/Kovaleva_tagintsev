using System;

namespace WindowsFormsApplicationP
{
    internal class Matrix
    {

        private int[,] Mat;
        private int[] rez;
        private double[] q;
        private int height, width, k;

        public Matrix(int[,] matrix, int height, int width, double[] qq)
        {
            this.height = height;
            this.width = width;
            Mat = new int[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Mat[i, j] = matrix[i, j];
                  
                }
            }
            q = new double[width];
            for (int i = 0; i < width; i++)
            {
                q[i] = qq[i];
                
            }
            rez = new int[height*width];
            k = 0;
        }
                
        public void dohodminmax()
        {
            //доп переменные
            int min, max;
            int[] dop1 = new int[height];//переменна для сохранения минимального значения в каждой строке
            Boolean flag = true;
            //алгоритм
            for (int i = 0; i < height; i++)
            {
                min = Mat[i, 0];
                for (int j = 0; j < width; j++)
                {
                    if (Mat[i, j] < min) min = Mat[i, j];
                }
                dop1[i] = min;
            }
            max = dop1[0];        
            for (int i = 0; i < height; i++)
            {
                if (dop1[i] > max) max = dop1[i];
            }
            for (int i=0;i< height; i++)
            {
                if (dop1[i] == max)
                {
                    for (int ii = 0; ii < k; ii++)
                    {
                        if (rez[ii] == i + 1) flag = false;
                    }
                    if (flag)
                    {
                        rez[k] = i + 1;
                        k++;
                    }
                }
                
            }
        }

        public void dohodBL()
        {
            //
            double[] dop = new double[height];//переменная для сохранения сумм
            double max;
            Boolean flag = true;
            //
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    dop[i] += Mat[i, j] * q[j];
                }
            }
            max = dop[0];
            for (int i = 0; i < height; i++)
            {
                if (dop[i] > max) max = dop[i];
            }
            for (int i = 0; i < height; i++)
            {
                if (dop[i] == max)
                {
                    for (int ii = 0; ii < k; ii++)
                    {
                        if (rez[ii] == i + 1) flag = false;
                    }
                    if (flag)
                    {
                        rez[k] = i + 1;
                        k++;
                    }
                }
            }
        }

        public void dohodHL()
        {
            //
            double c = 0.4;
            double max;
            double[] sum = new double[height];
            int sumI = 0;
            int min;
            Boolean flag = true;
            //
            for (int i = 0; i < height; i++)
            {
                sumI = 0;
                min = Mat[i, 0];
                for (int j = 0; j < width; j++)
                {
                    sumI += Mat[i, j];
                    if (Mat[i, j] < min) min = Mat[i, j];
                }
                sum[i] = sumI * c + (1- c)*min;
            }
            max = sum[0];
            for (int i = 0; i < height; i++)
            {
                if (sum[i] > max) max = sum[i];
            }
            for (int i = 0; i < height; i++)
            {
                if (sum[i] == max)
                {
                    for (int ii = 0; ii < k; ii++)
                    {
                        if (rez[ii] == i + 1) flag = false;
                    }
                    if (flag)
                    {
                        rez[k] = i + 1;
                        k++;
                    }
                }
            }
        }

        public void dohodProiz()
        {
            //
            int[] proiz = new int[height];
            int max;
            Boolean flag = true;
            //
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    proiz[i] *= Mat[i, j];
                }
            }
            max = proiz[0];
            for (int i = 0; i < height; i++)
            {
                if (proiz[i] > max) max = proiz[i];
            }
            for (int i = 0; i < height; i++)
            {
                if (proiz[i] == max)
                {
                    for (int ii = 0; ii < k; ii++)
                    {
                        if (rez[ii] == i + 1) flag = false;
                    }
                    if (flag)
                    {
                        rez[k] = i + 1;
                        k++;
                    }
                }
            }
        }

        public void poteraminmax()
        {
            //доп переменные
            int min, max;
            int[] dop1 = new int[height];//переменна для сохранения минимального значения в каждой строке
            Boolean flag = true;
            //алгоритм
            for (int i = 0; i < height; i++)
            {
                min = Mat[i, 0];
                for (int j = 0; j < width; j++)
                {
                    if (Mat[i, j] > min) min = Mat[i, j];
                }
                dop1[i] = min;
            }
            max = dop1[0];
            for (int i = 0; i < height; i++)
            {
                if (dop1[i] < max) max = dop1[i];
            }
            for (int i = 0; i < height; i++)
            {
                if (dop1[i] == max)
                {
                    for (int ii = 0; ii < k; ii++)
                    {
                        if (rez[ii] == i + 1) flag = false;
                    }
                    if (flag)
                    {
                        rez[k] = i + 1;
                        k++;
                    }
                }

            }
        }

        public void poteraBL()
        {
            //
            double[] dop = new double[height];//переменная для сохранения сумм
            double max;
            Boolean flag = true;
            //
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    dop[i] += Mat[i, j] * q[j];
                }
            }
            max = dop[0];
            for (int i = 0; i < height; i++)
            {
                if (dop[i] < max) max = dop[i];
            }
            for (int i = 0; i < height; i++)
            {
                if (dop[i] == max)
                {
                    for (int ii = 0; ii < k; ii++)
                    {
                        if (rez[ii] == i + 1) flag = false;
                    }
                    if (flag)
                    {
                        rez[k] = i + 1;
                        k++;
                    }
                }
            }
        }

        public void poteraHL()
        {
            //
            double c = 0.4; ;
            double max;
            double[] sum = new double[height];
            int sumI = 0;
            int min;
            Boolean flag = true;
            //
            for (int i = 0; i < height; i++)
            {
                sumI = 0;
                min = Mat[i, 0];
                for (int j = 0; j < width; j++)
                {
                    sumI += Mat[i, j];
                    if (Mat[i, j] > min) min = Mat[i, j];
                }
                sum[i] = sumI * c + (1 - c) * min;
            }
            max = sum[0];
            for (int i = 0; i < height; i++)
            {
                if (sum[i] < max) max = sum[i];
            }
            for (int i = 0; i < height; i++)
            {
                if (sum[i] == max)
                {
                    for (int ii = 0; ii < k; ii++)
                    {
                        if (rez[ii] == i + 1) flag = false;
                    }
                    if (flag)
                    {
                        rez[k] = i + 1;
                        k++;
                    }
                }
            }
        }

        public void poteraProiz()
        {
            //
            int[] proiz = new int[height];
            int max;
            Boolean flag = true;
            //
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    proiz[i] *= Mat[i, j];
                }
            }
            max = proiz[0];
            for (int i = 0; i < height; i++)
            {
                if (proiz[i] < max) max = proiz[i];
            }
            for (int i = 0; i < height; i++)
            {
                if (proiz[i] == max)
                {
                    for (int ii = 0; ii < k; ii++)
                    {
                        if (rez[ii] == i + 1) flag = false;
                    }
                    if (flag)
                    {
                        rez[k] = i + 1;
                        k++;
                    }
                }
            }
        }

        public String dohod()
        {
            //
            String s = "";
            //
            dohodminmax();
            dohodBL();
            dohodHL();
            dohodProiz();
            for (int i = 0; i < k-1; i++)
            {
                for (int j= i + 1; j < k; j++)
                {
                    if (rez[i] > rez[j])
                    {
                        rez[i] = rez[i] + rez[j];
                        rez[j] = rez[i] - rez[j];
                        rez[i] = rez[i] - rez[j];
                    }
                }
            }
            
            for (int i = 0; i < k; i++)
            {
                s += Convert.ToString(rez[i])+", ";
            }
            if (s.EndsWith(", ")) s = s.Remove(s.Length - 2);
            return "Оптимизированные альтернативы - " + s;
        }

        public String potera()
        {
            //
            String s = "";
            //
            poteraminmax();
            poteraBL();
            poteraHL();
            poteraProiz();
            for (int i = 0; i < k - 1; i++)
            {
                for (int j = i + 1; j < k; j++)
                {
                    if (rez[i] > rez[j])
                    {
                        rez[i] = rez[i] + rez[j];
                        rez[j] = rez[i] - rez[j];
                        rez[i] = rez[i] - rez[j];
                    }
                }
            }

            for (int i = 0; i < k; i++)
            {
                s += Convert.ToString(rez[i]) + ", ";
            }
            if (s.EndsWith(", ")) s = s.Remove(s.Length - 2);
            return "Оптимизированные альтернативы - " + s;
        }
    }
}