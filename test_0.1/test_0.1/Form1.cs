using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_0._1
{
    public partial class Form1 : Form
    {
        int quection_count;
        int correct_answer;
        int wrong_answer;

        string[] array;

        int correct_answer_number;
        int selected_response;

        System.IO.StreamReader Read; // считываем файл



        public Form1()
        {
            InitializeComponent();


        }

        void start(string path)
        {
            var encoding = System.Text.Encoding.GetEncoding(65001); // чтение кирилицой DDR8

            try
            {
                Read = new System.IO.StreamReader(path, encoding) // Экземпляр чтения кейс - файла

                this.Text = Read.ReadLine();
                quection_count = -1;
                correct_answer = 0;
                wrong_answer = 0;
                array = new string[10];
            }

            catch(Exception)
            {
                MessageBox.Show("ошибка 1");
            }

            quaction();

        }



        void quaction() //смена вопроса
        {
            label1.Text = Read.ReadLine();

            radioButton1.Text = Read.ReadLine();
            radioButton2.Text = Read.ReadLine();

            //correct_answer = int.Parse(Read.ReadLine()); // Считывание информации

            radioButton1.Checked = false;
            radioButton2.Checked = false;

            button1.Enabled = false;

            quection_count = quection_count + 1; // 

            if (radioButton1.Checked == true) button1.Text = "завершить";
            if (radioButton2.Checked == true) quaction();

            /*if (Read.EndOfStream == true)
                Read.Close();
                var encoding = System.Text.Encoding.GetEncoding(65001); // чтение кирилицой DDR8
                Read = new System.IO.StreamReader("E:/Учёба/прога/test_0.1/t1.txt", encoding); // Экземпляр чтения кейс - файла*/
        }

        void состояние_переключение(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button1.Focus();
            RadioButton p = (RadioButton) sender; //Процесс переключение проверка
            var t = p.Name;

            correct_answer = int.Parse(t.Substring(11));
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selected_response == correct_answer_number)
            {
                correct_answer = correct_answer + 1;
            }
            else
            {
                wrong_answer = wrong_answer + 1;
                array[wrong_answer] = label1.Text;
            }

            if (button1.Text == "Начать заного")
            {
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                start("C:/Users/aveng/Source/Repos/individual_work/test_0.1/test_0.1/t.txt");
                return;
            }
            if (button1.Text == "завершить")
            {
                Read.Close();
                radioButton1.Visible = false;
                radioButton2.Visible = false;

                label1.Text = String.Format("Вы годны");
            }
            
            if (Read.EndOfStream == true)
            {
                start("C:/Users/aveng/Source/Repos/individual_work/test_0.1/test_0.1/t.txt");
            }

            quaction();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Следующий вопрос";
            button2.Text = "Выход";
            label1.Text = "Хотите ли вы служить в армии?";

            radioButton1.CheckedChanged += new EventHandler(состояние_переключение); //упр событиями
            radioButton2.CheckedChanged += new EventHandler(состояние_переключение);

            start("C:/Users/aveng/Source/Repos/individual_work/test_0.1/test_0.1/t.txt");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
