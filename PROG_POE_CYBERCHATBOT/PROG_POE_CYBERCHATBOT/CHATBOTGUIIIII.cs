using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROG_POE_CYBERCHATBOT
{
    public partial class CHATBOTGUIIIII : Form
    {
        private IntroClass intro;

        public CHATBOTGUIIIII()
        {
            InitializeComponent();
            //Attach KeyDown event handler
            textBox1.KeyDown += textBox1_KeyDown; 
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            intro = new IntroClass(richTextBox1);
            intro.ShowIntro();
            textBox1.Focus();
        }

        private void CHATBOTGUIIIII_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && intro != null)
            {
                intro.ProcessInput(textBox1.Text);
                textBox1.Clear();
                e.SuppressKeyPress = true;
            }
        }
    }
}
