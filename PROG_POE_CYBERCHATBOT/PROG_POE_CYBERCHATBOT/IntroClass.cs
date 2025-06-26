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
        private RichTextBox _output;
        private Questions _questionsHandler;
        public string UserName { get; private set; }
        public enum ChatState { AwaitingYesNo, AwaitingName, Chatting }
        public ChatState CurrentState { get; private set; }

        public IntroClass(RichTextBox output, TextBox input)
        {
            _output = output;
            _questionsHandler = new Questions();
            CurrentState = ChatState.AwaitingYesNo;
        }

        public void RunIntro()
        {
            //Instantiate the Questions class
            Questions questionsHandler = new Questions();

            //ASCII art along with welcome message
            //ASCII art created by https://www.asciiart.eu/electronics/robots#google_vignette
            _output.Clear();
            _output.AppendText("-------------------------------------------------------------\n");
            _output.AppendText("CYBER SECURITY CHATBOT\n");
            _output.AppendText("-------------------------------------------------------------");
            // richTextBox1.AppendText();
            _output.AppendText(@"                                  
  [_|_/ 
   //
 _//    __
(_|)   |@@|
 \ \__ \--/ __
  \o__|----|  |   __
      \ }{ /\ )_ / _\
      /\__/\ \__O (__
     (--/\--)    \__/
     _)(  )(_
    `---''---`             ");

            _output.AppendText("-------------------------------------------------------------");
            //-------------------------------------------------------------------------------------------------------------------------

            try
            {
                //Welcome message using custom.wav file
                SoundPlayer player = new SoundPlayer("Resources/Welcome.wav");
                player.PlaySync();
            }
            catch { }
            //-------------------------------------------------------------------------------------------------------------------------

            _output.AppendText("Do you have any questions for me? (yes/no): ");
            CurrentState = ChatState.AwaitingYesNo;
        }
        public void ProcessInput(string input)
        {
            input = input.Trim().ToLower();

            switch (CurrentState)
            {
                case ChatState.AwaitingYesNo:
                    if (input == "yes")
                    {
                        _output.AppendText("\nGreat! Before we begin, what is your name?\n");
                        CurrentState = ChatState.AwaitingName;
                    }
                    else if (input == "no")
                    {
                        _output.AppendText("\nClosing program, bye bye!\n");
                        Application.Exit();
                    }
                    else
                    {
                        _output.AppendText("\nSorry, I didn't understand that. Please type 'yes' or 'no'\n");
                    }
                    break;

                case ChatState.AwaitingName:
                    UserName = input;
                    _output.AppendText($"\nGood to meet you {UserName}!\n");
                    _output.AppendText("\nLet's get started. Ask me a question. Remember, you can type 'exit' at any time to stop.\n");
                    CurrentState = ChatState.Chatting;
                    break;

                case ChatState.Chatting:
                    if (input == "exit")
                    {
                        _output.AppendText($"\nGoodbye, {UserName}! It was nice chatting with you.\n");
                        Application.Exit();
                    }
                    else if (input == "help")
                    {
                        _output.AppendText("\nHere are some questions you can ask me:\n");
                        _questionsHandler.ListQuestions(_output);
                    }
                    else
                    {
                        _questionsHandler.RespondToQuestion(input, _output);
                    }
                    break;
                }
        }
    }
}
