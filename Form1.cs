using System;
using System.Windows.Forms;
using System.CodeDom.Compiler;

namespace BuildNow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "CSharp Files(*.cs)|*.cs";
            if (o.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = o.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Executable|*.exe";
            if (s.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = s.FileName;
            }
        }

        void CompileNow(string exportname, string file)
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters compars = new CompilerParameters();
            compars.GenerateExecutable = true;
            compars.GenerateInMemory = false;
            compars.TreatWarningsAsErrors = false;
            compars.OutputAssembly = exportname;
            CompilerResults res = provider.CompileAssemblyFromFile(compars, file);
            if (res.Errors.Count > 0)
            {
                foreach (CompilerError ce in res.Errors)
                {
                    MessageBox.Show(ce.ToString(), "Error");
                }
            }
            else
            {
                MessageBox.Show("Code Compiled!","Build Now");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CompileNow(textBox2.Text, textBox1.Text);
        }
    }
}
