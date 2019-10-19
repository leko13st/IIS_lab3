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
            textBox1.Text = ">";
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
            string str = textBox1.Lines[textBox1.Lines.Length - 2];
            textBox1.Text += inputHandler.Input(str);

            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }
    }
}
