using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Dictionary<char, int> priora = new Dictionary<char, int>();
        public Form1()
        {
            InitializeComponent();
            priora.Add('+', 1);
            priora.Add('-', 2);
            priora.Add('/', 3);
            priora.Add('*', 4);
        }
        public void FindExpression(string str, int step)
        {
            textBox1.Text = FindValue(step, str, true) + str[step] + FindValue(step, str, false);
        }
        public string FindValue(int root, string str, bool isTrue)
        {
            int i;
            int barrier = root;
            if(isTrue)
                for (i = root + 1; i < str.Length; i++)
                {
                    try
                    {
                        Convert.ToDouble(str.Substring(barrier + 1, i - barrier));
                    }
                    catch(FormatException)
                    {
                        if (priora[str[i]] > priora[str[root]])
                            barrier = i;
                        else
                            return str.Substring(root + 1, i - 1);
                    }
                    if (i == str.Length - 2)
                        return str.Substring(root + 1, i - root);
                }
            else
                for (i = root - 1; i >= 0; i--)
                {
                    try
                    {
                        Convert.ToDouble(str.Substring(i, barrier - 1));
                    }
                    catch(FormatException)
                    {
                        if (priora[str[i]] > priora[str[root]])
                            barrier = i;
                        else
                            return str.Substring(root - 1, i + 1);
                    }
                    if(i == 1)
                        return str.Substring(0, root);
                }
            return string.Empty;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FindExpression(textBox1.Text, 2);
        }
    }
}
