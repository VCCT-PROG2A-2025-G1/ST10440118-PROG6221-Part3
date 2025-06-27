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
            _questionsHandler = new Questions(_output);  // pass the RichTextBox here!
            CurrentState = ChatState.AwaitingYesNo;
        }

        public void RunIntro()
        {
            _output.AppendText("-------------------------------------------------------------\n");
            _output.AppendText("CYBER SECURITY CHATBOT\n");
            _output.AppendText("-------------------------------------------------------------\n");

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

            _output.AppendText(robotArt + Environment.NewLine);
            _output.AppendText("-------------------------------------------------------------\n");

            try
            {
                SoundPlayer player = new SoundPlayer("Resources/Welcome.wav");
                player.PlaySync();
            }
            catch { }

            _output.AppendText("Do you have any questions for me? (yes/no): ");
            CurrentState = ChatState.AwaitingYesNo;
        }

        public void ProcessInput(string input)
        {
            switch (CurrentState)
            {
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

                case ChatState.AwaitingName:
                    UserName = input.Trim();
                    _output.AppendText($"Nice to meet you, {UserName}! You can now ask me about cybersecurity.\n");
                    CurrentState = ChatState.Chatting;
                    break;

                case ChatState.Chatting:
                    _questionsHandler.RespondToQuestion(input);  // only pass the input string here
                    break;
            }
        }
    }
}
