//Grace Berrill
//ST10440118
//Group 1

//REFRENCES
//https://ascii.co.uk/art/robot
//GITHUB Copilght

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//Allows .wav file to play
using System.Media;
//Allows the use of Windows Forms for GUI
using System.Windows.Forms;

namespace PROG_POE_CYBERCHATBOT
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start the Windows GUI Forms application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new IntroGUIPage());
        }
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...------------------------------------------------------//