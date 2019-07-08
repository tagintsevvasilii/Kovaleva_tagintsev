using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplicationP
{
    public partial class Form1 : Form
    {
        private int height, width;
        private int[,] Mat;
        private double[] q;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            comboBox1.SelectedIndex = -1;
            textBox1.Text = "";
            textBox2.Text = "";
            for (int j = 0; j < width + 1; j++)
                {
                    dataGridView1.Columns.RemoveAt(0);
                }
            for (int i = 0; i < width; i++)
            {
                dataGridView2.Columns.RemoveAt(0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Mat = new int[height, width];
            //q = new double[width];
            //проверка на введеную таблицу
            Boolean flagT = true;
            /*for (int i = 1; i < height + 1; i++)
            {
                for (int j = 1; j < width + 1; j++)
                {
                    if (Convert.ToString(dataGridView1.Rows[i].Cells[j].Value) == "") flagT = false;
                }
            }
            */
            //проверка на введеную таблицу q

            Boolean flagQ = true;
            /*for (int i = 1; i < width; i++)
            {
                if (Convert.ToString(dataGridView2.Rows[1].Cells[i].Value) == "") flagQ = false; 
            }
            */        
            if (!flagQ||!flagT) MessageBox.Show("Не все поля в таблице заполнены!");
            else
            {
                //заполнение матриц данными из таблиц
                for (int i = 0; i < height ; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                         dataGridView1.Rows[i + 1].Cells[j + 1].Value = Convert.ToString(Mat[i, j]) ;
                    }
                }
                
                for (int i = 0; i < width; i++)
                {
                    dataGridView2.Rows[1].Cells[i].Value = Convert.ToString(q[i]);
                }
                // создание объекта класса Matrix
                Matrix matrix = new Matrix(Mat, height, width, q);
                //ввод исходов, если 1 - доход, если 2 - потеря
                
                if (comboBox1.SelectedIndex <= -1) MessageBox.Show("Выберите тип исходов!");
                if (comboBox1.SelectedIndex == 0)
                {
                    MessageBox.Show(matrix.dohod());
                }
                else
                {
                    MessageBox.Show(matrix.potera());
                }
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //проверка на вводимые кол-во альтернатив и внешних состояний
            if (textBox1.Text == "") MessageBox.Show("Введите количество альтернатив");
            if (textBox2.Text == "") MessageBox.Show("Введите количество внешних состояний");
            if (Convert.ToInt32(textBox1.Text) <= 0) MessageBox.Show("Неверное число кол-ва альтернатив");
            else if (Convert.ToInt32(textBox2.Text) <= 0) MessageBox.Show("Неверное число кол-ва внешних состояний");
            //ввод кол-ва строк и столбцов таблицы
            height = Convert.ToInt32(textBox1.Text);
            width = Convert.ToInt32(textBox2.Text);
            //постройка таблицы для ввода данных
            //var Str = new String();
            for (int i = 0; i < width+1; i++)
            {
                var column = new DataGridViewColumn();
                column.CellTemplate = new DataGridViewTextBoxCell();
                dataGridView1.Columns.Add(column);
            }
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            for (int i = 0; i < height+1; i++)
            {
                dataGridView1.Rows.Add();
            }
            //заполнение заголовков строк
            for (int i = 1; i < height + 1; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = "X" + Convert.ToString(i);
            }
            //заполнение заголовков солбцов
            for (int i = 1; i < width + 1; i++)
            {
                dataGridView1.Rows[0].Cells[i].Value = "Z" + Convert.ToString(i);
            }
            //постройка таблицы q
            for (int i = 0; i < width; i++)
            {
                var column = new DataGridViewColumn();
                column.CellTemplate = new DataGridViewTextBoxCell();
                dataGridView2.Columns.Add(column);
            }
            dataGridView2.AllowUserToAddRows = false;
            for (int i = 0; i < 2; i++)
            {
                dataGridView2.Rows.Add();
                
            }
            for (int i = 0; i < width; i++)
            {
                dataGridView2.Rows[0].Cells[i].Value = "q" + Convert.ToString(i+1);
            }
            button1.Visible = false;
            //тестовые случаи
            if ((height == 4) && (width == 5))
            {
                Mat =  new int [,] { {4,3,2,5,2 }, {2,3,5,5,3 }, {1,3,2,4,4 }, {2,1,1,5,4 } };
                q = new double[] { 0.1, 0.2, 0.3, 0.1, 0.3};
            }
            if (height == 3 && width == 2)
            {
                Mat = new int[,] { { 2, 2 }, { 1, 4 }, { 4, 1}};
                q = new double[] { 0.4, 0.6 };
            }
        }
    }
}
