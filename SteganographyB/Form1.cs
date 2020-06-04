using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteganographyB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            richTextBox1.Text = "Слова и фр\nазы 1. Сло\nва и фразы 2. Слова и ф\nразы 3! Слова и фр\nазы 4? Слова и ф\nразы 5. Слова и фразы 6. Сл\nова и фразы 7. Слов\nа и фразы 8! Сло\nва и фразы 9? Сл\nова и фразы 10.";           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = "";
            string[] lines = richTextBox1.Lines;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Last() != ' ') break; 
                
                if(lines[i].Substring(lines[i].Length-2) == "  ")
                {
                    msg += "0";
                }
                else
                {
                    msg += "1";
                }
            }
            char c = (Char)(Convert.ToInt32(msg, 2));
            MessageBox.Show(c.ToString() + " " + msg);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") textBox1.Text="u";
            byte[] asciiBytes = Encoding.ASCII.GetBytes(textBox1.Text);
            char[] msgChars = (Convert.ToString(asciiBytes[0], 2)).ToCharArray();
            string msgD = "";
            for (int i = 0; i < msgChars.Length; i++)
            { msgD += msgChars[i]; }
            MessageBox.Show(msgD);

            string[] lines = richTextBox1.Lines;            
            for (int i= 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].TrimEnd();
            }

            for (int i = 0; i < msgChars.Length; i++)
            {
                if (msgChars[i] == '1')
                {
                    lines[i] = lines[i] + " ";
                }
                if (msgChars[i] == '0')
                {
                    lines[i] = lines[i] + "  ";
                }
            }

            for (int i = 0; i < lines.Length; i++)
            {
                richTextBox2.Text += lines[i] + "\n";               
            }
        }
    }
}
