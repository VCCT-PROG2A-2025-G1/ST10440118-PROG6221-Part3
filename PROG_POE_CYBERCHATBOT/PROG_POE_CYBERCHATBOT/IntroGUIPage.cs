using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROG_POE_CYBERCHATBOT
{
    public partial class IntroGUIPage : Form
    {
        //Method to initialize the form components
        public IntroGUIPage()
        {
            InitializeComponent();
        }
        //------------------------------------------------------------------------------------------------------

        private void lblWelcomeText_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void lblDesc_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
        }

        //Method to handle the Yes button click 
        private void btnYes_Click(object sender, EventArgs e)
        {
            //Open the chatbot GUI and hide the intro page
            CHATBOTGUIIIII chatbotWindow = new CHATBOTGUIIIII();
            chatbotWindow.Show();
            this.Hide();
        }
        //------------------------------------------------------------------------------------------------------
    }
}//------------------------------------------...ooo000 END OF FILE 000ooo...------------------------------------------------------//
