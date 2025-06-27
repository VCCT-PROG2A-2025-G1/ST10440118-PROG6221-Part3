using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PROG_POE_CYBERCHATBOT;

namespace PROG_POE_CYBERCHATBOT
{
    internal class IntroClass
    {
        //Variables
        private RichTextBox _output;
        private Questions _questionsHandler;
        public string UserName { get; private set; }
        public enum ChatState { AwaitingYesNo, AwaitingName, Chatting }
        public ChatState CurrentState { get; private set; }
        //------------------------------------------------------------------------------------------------------

        //Constructor that initializes the RichTextBox and Questions handler
        public IntroClass(RichTextBox output, TextBox input)
        {
            _output = output;
            _questionsHandler = new Questions(_output);  // pass the RichTextBox here!
            CurrentState = ChatState.AwaitingYesNo;
        }
        //------------------------------------------------------------------------------------------------------

        //Method to run the introduction of the chatbot
        public void RunIntro()
        {
            _output.AppendText("-------------------------------------------------------------\n");
            _output.AppendText("CYBER SECURITY CHATBOT\n");
            _output.AppendText("-------------------------------------------------------------\n");
            //ASCII art for the robot (refer to reference link for the art)
            string robotArt =
                @"
         __
 _(\    |@@|
(__/\__ \--/ __
   \___|----|  |   __
       \ }{ /\ )_ / _\
       /\__/\ \__O (__
      (--/\--)    \__/
      _)(  )(_
     `---''---`    ";

            //Display the robot art in the RichTextBox
            _output.AppendText(robotArt + Environment.NewLine);
            _output.AppendText("-------------------------------------------------------------\n");
            //------------------------------------------------------------------------------------------------------

            //Play the welcome sound
            try
            {
                SoundPlayer player = new SoundPlayer("Resources/Welcome.wav");
                player.PlaySync();
            }
            catch { }
            //Ask the user if they have any questions
            _output.AppendText("Do you have any questions for me? (yes/no): ");
            CurrentState = ChatState.AwaitingYesNo;
        }
        //------------------------------------------------------------------------------------------------------

        //Method to process user input based on the current state of the chat
        public void ProcessInput(string input)
        {
            switch (CurrentState)
            {
                //Reply to the user based on their input
                case ChatState.AwaitingYesNo:
                    if (input.Trim().ToLower() == "yes")
                    {
                        _output.AppendText("Great! What's your name?\n");
                        CurrentState = ChatState.AwaitingName;
                    }
                    else if (input.Trim().ToLower() == "no")
                    {
                        _output.AppendText("No problem! If you have questions later, just type them here.\n");
                        CurrentState = ChatState.Chatting;
                    }
                    else
                    {
                        _output.AppendText("Please answer 'yes' or 'no'.\n");
                    }
                    break;

                //If user has provided their name, store it and change the state to Chatting
                case ChatState.AwaitingName:
                    UserName = input.Trim();
                    _output.AppendText($"Nice to meet you, {UserName}! You can now ask me about cybersecurity.\n");
                    CurrentState = ChatState.Chatting;
                    break;

                //Call the Questions class to respond to the user's question
                case ChatState.Chatting:
                    _questionsHandler.RespondToQuestion(input); 
                    break;
            }
        }
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...------------------------------------------------------//