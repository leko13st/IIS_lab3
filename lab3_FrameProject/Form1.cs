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
            textBox1.Text = ">Назовите признаки поломки ПК, например: странные звуки в системе, синий экран смерти и т.д.\r\n>";
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        string pathFile = null;
        FrameManager frameManager = null;
        InputHandler inputHandler = null;

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ВыбратьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathFile = openFileDialog1.FileName;
                frameManager = new FrameManager(pathFile);
                inputHandler = new InputHandler(frameManager);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Lines[textBox1.Lines.Length - 1];
            try
            {
                textBox1.Text += "\r\n" + inputHandler.Input(str);
            }
            catch { textBox1.Text += "\r\nНет данных! Укажите файл."; }

            textBox1.Text += "\r\n>";
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }
    }
}
