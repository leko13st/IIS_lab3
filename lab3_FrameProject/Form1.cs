using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3_FrameProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Начальные настройки textBox'а
            //textBox1.Text += ">Выберите файл с данными. Меню -> Выбрать файл.\r\n>";
            //textBox1.SelectionStart = textBox1.Text.Length;
        }

        string pathFile = null; //Путь
        FrameManager frameManager = null; //Фрейм менеджер
        InputHandler inputHandler = null; //Обработчик ввода

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Введите знаний в слоты пустого фрейма,\r\n которые вам известны!");
        }

        private void ВыбратьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Выбор файла .xml
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathFile = openFileDialog1.FileName;
                frameManager = new FrameManager(pathFile);
                inputHandler = new InputHandler(frameManager);
                //textBox1.Text += "\r\n>Назовите признаки поломки ПК, например: странные звуки в системе, синий экран смерти и т.д.\r\n>";
                //textBox1.SelectionStart = textBox1.Text.Length;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Lines[textBox1.Lines.Length - 1]; //пользовательский ввод
            try
            {
                textBox1.Text += "\r\n" + inputHandler.Input(str); //ввод текста на обработку и получение ответа
            }
            catch { textBox1.Text += "\r\nНет данных! Укажите файл."; }

            textBox1.Text += "\r\n>";
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }        
    }
}
