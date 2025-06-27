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
            //Initialize the RichTextBox and TextBox controls
            textBox1.KeyDown += textBox1_KeyDown;
        }
        //------------------------------------------------------------------------------------------------------

        //Method to run the introduction of the chatbot
        private void btnGo_Click(object sender, EventArgs e)
        {
            //Display the welcome message and ASCII art in the RichTextBox
            intro = new IntroClass(richTextBox1, textBox1);
            intro.RunIntro(); 
            textBox1.Focus();

            //Make buttons visible or invisible based on the state of the chatbot
            btnGo.Visible = false;
            btnAsk.Visible = true;
        }
        //------------------------------------------------------------------------------------------------------

        private void CHATBOTGUIIIII_Load(object sender, EventArgs e)
        {
        }

        //Method to handle key down events in the TextBox
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && intro != null)
            {
                //Process the input when Enter is pressed
                intro.ProcessInput(textBox1.Text);
                textBox1.Clear();
                e.SuppressKeyPress = true;
            }
        }
        //------------------------------------------------------------------------------------------------------

        //Method to handle the Ask button click 
        private void btnAsk_Click(object sender, EventArgs e)
        {
            if (intro != null)
            {
                intro.ProcessInput(textBox1.Text);
                textBox1.Clear();
                textBox1.Focus();
            }
        }
        //------------------------------------------------------------------------------------------------------
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...------------------------------------------------------//