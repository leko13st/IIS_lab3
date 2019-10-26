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
        }

        string pathFile = null; //Путь
        FrameManager frameManager = null; //Фрейм менеджер
        InputHandler inputHandler = null; //Обработчик ввода
        int SlotCount = 0;

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Введите знания в слоты пустого фрейма,\r\nкоторые вам известны!");
        }

        private void ВыбратьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Выбор файла .xml
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathFile = openFileDialog1.FileName;
                frameManager = new FrameManager(pathFile);
                PrepareFrame(frameManager);
                inputHandler = new InputHandler(frameManager);
            }
        }

        List<List<string>> listValues;
        void PrepareFrame(FrameManager fm) //Подготовка фрейма для заполнения
        {
            listValues = fm.GetListValues();
            SlotCount = listValues.Count;

            for (int i = 0; i < listValues.Count; i++)
            {
                dataGridView1.Rows.Add();
                tmp_list.Add(1);
                if (listValues[i].Count > 0)
                {
                    FillComboBoxItems(i, i, true);
                }
                else if (listValues[i].Count == 0)
                {
                    FillComboBoxItems(i, i, false);
                }
                dataGridView1[0, i].Value = fm.GetFrameList()[0].Slot[i].Name;
            }
        }

        void FillComboBoxItems(int indexRow, int indexList, bool ComboBox) //Заполнение комбоксов ячеек значениями
        {
            if (ComboBox)
            {
                var cell = (DataGridViewComboBoxCell)dataGridView1.Rows[indexRow].Cells[1];
                for (int j = 0; j < listValues[indexList].Count; j++)
                    cell.Items.Add(listValues[indexList][j]);
            }
            else 
            {
                DataGridViewTextBoxCell textBoxCell = new DataGridViewTextBoxCell();
                dataGridView1.Rows[indexRow].Cells[1] = textBoxCell;
            }
        }

        private void button1_Click(object sender, EventArgs e) //подтверждение фрейма на обработку
        {
            List<Frame> correctFrames = inputHandler.FindCorrectFrames(InputList());
            double truthPercent = inputHandler.GetTruthPercent();
            PrintFrames(correctFrames, truthPercent);
        }

        List<string> InputList() //Считавание значений в dataGridView1 в коллекцию строк
        {
            List<string> list = new List<string>();
            for (int i = 0; i < tmp_list.Count; i++) 
                list.Add(null);
            for (int i = 0; i < SlotCount; i++)
            {
                try
                {
                    list[DefineIndexList(i)] += dataGridView1[1, i].Value.ToString() + "/";
                }
                catch { }
            }
            return list;
        }

        List<int> tmp_list = new List<int>();

        //Метод для того чтобы выбирать несколько значений в один слот фрейма.
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            for (int i = SlotCount - 1; i >= 0; i--)
                if (dataGridView1[1, i].Selected && (dataGridView1[1, i].Value == null || dataGridView1[1, i].Value.ToString() == ""))
                {
                    bool ComboBox = false;
                    int IndexList = DefineIndexList(i);
                    if (listValues[IndexList].Count > 0) ComboBox = true;

                    tmp_list[IndexList]++;
                    dataGridView1.Rows.Insert(i + 1);
                    FillComboBoxItems(i + 1, DefineIndexList(i + 1), ComboBox);
                    SlotCount++;
                }
        }
        int DefineIndexList(int index) //Метод определния к какому слоту относится выбранное значение
        {
            int k = 0;
            for (int i = 0; i < tmp_list.Count; i++)
            {
                k += tmp_list[i];
                if (k > index)
                    return i;
            }
            return 0;
        }

        void PrintFrames(List<Frame> frames, double truthPercent) //Метод вывода фреймов на экран
        {
            
        }
    }
}
