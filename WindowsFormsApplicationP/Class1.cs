using System;

namespace WindowsFormsApplicationP
{
    public class Matrix
    {
        private int[,] Mat;
        private int[] q;
        private int height, width, cbox;

        public Matrix(int[,] matrix, int height, int width, int cbox, int[] q)
        {
            this.heught = height;
            this.width = width;
            this.cbox = cbox;
            Mat = new int[height, width];
            this.Mat = matrix;
            q = new int[width];
            this.q = q;
        }

        public String dohodKlass()
        {
            return "По минимаксному критерию получается альтернатива - " + Convert.ToString(dohodminmax()) +
                "\nПо критерию Байеса-Лапласа получается альтернатива - " + Convert.ToString(dohodBL());
        }

        public int dohodminmax()
        {
            int rezi = -1, rezj;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    rezj = Math.Min(Mat[i, j]);
                }
                if (rezj > rezi) rezi = rezj;
            }
            return rezi;
        }

        public int dohodBL()
        {
            int sum = 0, rezi = -1;
            for (int i = 0; i < height; i++)
            {
                sum = 0;
                for (j = 0; j < width; j++)
                {
                    sum += Mat[i, j] * q[j];
                }
                if (sum > rezi) rezi = sum;
            }
            reteurn rezi;
        }

        public String dohodProiz()
        {
            return "";
        }

        public String poteraKlass()
        {
            return "По минимаксному критерию получается альтернатива - " + Convert.ToString(poteraminmax()) +
                "\nПо критерию Байеса-Лапласа получается альтернатива - " + Convert.ToString(poteraBL());
        }

        public int poteraminmax()
        {
            int rezi = 100000, rezj;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    rezj = Math.Max(Mat[i, j]);
                }
                if (rezj < rezi) rezi = rezj;
            }
            return rezi;
        }

        public int poteraBL()
        {
            int sum = 0, rezi = 100000;
            for (int i = 0; i < height; i++)
            {
                sum = 0;
                for (j = 0; j < width; j++)
                {
                    sum += Mat[i, j] * q[j];
                }
                if (sum < rezi) rezi = sum;
            }
            reteurn rezi;
        }

        public String poteraProiz()
        {
            return "";
        }

        public String dohod()
        {
            return dohodKlass() + dohodProiz();
        }

        public String potera()
        {
            return poteraKlass() + poteraProiz();
        }
    }
}