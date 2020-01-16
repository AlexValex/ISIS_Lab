using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Лаб.раб._1
{
	public partial class Form2 : Form
	{
        string ne = "";
        string[] names;
        public Form2()
		{
            
			InitializeComponent();
		}

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            richTextBox1.Text = "";
            richTextBox2.Text = "";
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Multiselect = true;
                openFile.Filter = "Файлы txt|*.txt";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string[] filenames = openFile.FileNames;
                    names = filenames;
                    richTextBox1.Text = File.ReadAllText(filenames[0], Encoding.GetEncoding(1251));
                    richTextBox2.Text = File.ReadAllText(filenames[1], Encoding.GetEncoding(1251));
                    label1.Text = Path.GetFileName(filenames[0]);
                    label2.Text = Path.GetFileName(filenames[1]);
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i;
            string text = "";

            //Если кол-во строк равно
            if (richTextBox1.Lines.Length == richTextBox2.Lines.Length)
            {
                for (i = 0; i < richTextBox1.Lines.Length; i++)
                {
                    if (richTextBox1.Lines[i] != richTextBox2.Lines[i])
                    {
                        richTextBox1.SelectionStart = richTextBox1.GetFirstCharIndexFromLine(i);
                        richTextBox1.SelectionLength = richTextBox1.Lines[i].Length;
                        richTextBox1.SelectionColor = Color.Red;
                        text += richTextBox1.Lines[i].ToString() + Environment.NewLine;

                        richTextBox2.SelectionStart = richTextBox2.GetFirstCharIndexFromLine(i);
                        richTextBox2.SelectionLength = richTextBox2.Lines[i].Length;
                        richTextBox2.SelectionColor = Color.Red;
                        text += richTextBox2.Lines[i].ToString() + Environment.NewLine;
                    }
                }
            }
            //Если количество строк больше в richTextBox1
            else if (richTextBox1.Lines.Length > richTextBox2.Lines.Length)
            {
                for (i = 0; i < richTextBox2.Lines.Length; i++)
                {
                    if (richTextBox1.Lines[i] != richTextBox2.Lines[i])
                    {
                        richTextBox1.SelectionStart = richTextBox1.GetFirstCharIndexFromLine(i);
                        richTextBox1.SelectionLength = richTextBox1.Lines[i].Length;
                        richTextBox1.SelectionColor = Color.Red;
                        text += richTextBox1.Lines[i].ToString() + Environment.NewLine;

                        richTextBox2.SelectionStart = richTextBox2.GetFirstCharIndexFromLine(i);
                        richTextBox2.SelectionLength = richTextBox2.Lines[i].Length;
                        richTextBox2.SelectionColor = Color.Red;
                        text += richTextBox2.Lines[i].ToString() + Environment.NewLine;
                    }
                }
                for (i = richTextBox2.Lines.Length; i < richTextBox1.Lines.Length; i++)
                {
                    richTextBox1.SelectionStart = richTextBox1.GetFirstCharIndexFromLine(i);
                    richTextBox1.SelectionLength = richTextBox1.Lines[i].Length;
                    richTextBox1.SelectionColor = Color.Red;
                    text += richTextBox1.Lines[i].ToString() + Environment.NewLine;
                }
            }
            //Если количество строк больше в richTextBox2
            else
            {
                for (i = 0; i < richTextBox1.Lines.Length; i++)
                {
                    if (richTextBox1.Lines[i] != richTextBox2.Lines[i])
                    {
                        richTextBox1.SelectionStart = richTextBox1.GetFirstCharIndexFromLine(i);
                        richTextBox1.SelectionLength = richTextBox1.Lines[i].Length;
                        richTextBox1.SelectionColor = Color.Red;
                        text += richTextBox1.Lines[i].ToString() + Environment.NewLine;

                        richTextBox2.SelectionStart = richTextBox2.GetFirstCharIndexFromLine(i);
                        richTextBox2.SelectionLength = richTextBox2.Lines[i].Length;
                        richTextBox2.SelectionColor = Color.Red;
                        text += richTextBox2.Lines[i].ToString() + Environment.NewLine;
                    }
                }
                for (i = richTextBox1.Lines.Length; i < richTextBox2.Lines.Length; i++)
                {
                    richTextBox2.SelectionStart = richTextBox2.GetFirstCharIndexFromLine(i);
                    richTextBox2.SelectionLength = richTextBox2.Lines[i].Length;
                    richTextBox2.SelectionColor = Color.Red;
                    text += richTextBox2.Lines[i].ToString() + Environment.NewLine;                
                }
            }
            ne = text;
            MessageBox.Show("Сравнение проведено успешно!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"F:\\NoEquals.rtf", ne, Encoding.UTF8);
            MessageBox.Show("Сохранено успешно!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Файлы rtf|*.rtf";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFile.FileName, ne, Encoding.UTF8);
                MessageBox.Show("Успешно сохранено в " + saveFile.FileName + " !");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            File.WriteAllText(names[0], richTextBox1.Text, Encoding.UTF8);
            File.WriteAllText(names[1], richTextBox2.Text, Encoding.UTF8);
            MessageBox.Show("Тексты сохранены успешно!");
        }

        private void newTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i;

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Multiselect = true;
            openFile.Filter = "Файлы txt|*.txt";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string[] filenames = openFile.FileNames;
                names = filenames;
                richTextBox1.Text = File.ReadAllText(filenames[0], Encoding.UTF8);
                richTextBox2.Text = File.ReadAllText(filenames[1], Encoding.UTF8);
                label1.Text = Path.GetFileName(filenames[0]);
                label2.Text = Path.GetFileName(filenames[1]);
            }

            for (i = 0; i < richTextBox1.Lines.Length; i++)
            {
                richTextBox1.SelectionStart = richTextBox1.GetFirstCharIndexFromLine(i);
                richTextBox1.SelectionLength = richTextBox1.Lines[i].Length;
                richTextBox1.SelectionColor = Color.Black;
            }
            for (i = 0; i < richTextBox2.Lines.Length; i++)
            {
                richTextBox2.SelectionStart = richTextBox2.GetFirstCharIndexFromLine(i);
                richTextBox2.SelectionLength = richTextBox2.Lines[i].Length;
                richTextBox2.SelectionColor = Color.Black;
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}

