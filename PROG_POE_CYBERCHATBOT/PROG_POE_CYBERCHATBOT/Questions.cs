using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PROG_POE_CYBERCHATBOT
{
    internal class Questions
    {
        private RichTextBox output;
        private List<string> activityLog = new List<string>();
        private int logDisplayIndex = 0;
        private const int logPageSize = 5;
        private List<QuizQuestion> quizQuestions = new List<QuizQuestion>();
        private int currentQuestionIndex = 0;
        private int score = 0;
        private bool inQuiz = false;

        public Questions(RichTextBox outputBox)
        {
            output = outputBox;
        }

        private readonly Dictionary<string, string[]> responses = new Dictionary<string, string[]>
        {
            {"password", new[] {
                "When creating a password you want it to be as safe as posible. Use techniques such as a unique word, never a pets name, and a mix of special characters and numbers",
                "Make your password long (12+ characters), use uppercase and lowercase letters, numbers, and special characters. Avoid using personal info",
                "Consider using a passphrase — a series of unrelated words — and a password manager to keep track of them" }},
            {"scam", new[] {
                "Common scams include: phishing, tech support scams, prize scams, and impersonation scams",
                "Scams you might see include romance scams, fake online stores, investment scams, and job offer scams",
                "Watch out for scams like fake charity appeals, lottery winnings, and social media impersonations" }},
            {"phishing", new[] {
                "Phishing is when attackers trick you into giving away personal info via fake messages or websites",
                "Phishing often comes as emails or texts that seem real but try to steal your passwords or credit card info",
                "These scams usually pretend to be from banks, companies, or even friends, urging you to click fake links" }},
            {"how are you?", new[] {
                "I'm doing well! Thanks for asking.",
                "I'm great, excited to help with any security questions you may have",
                "Feeling secure and helpful today!"
            }},
            {"what can you help with?", new[] {
                "I'm here to help with raising awareness and provide tips to help you stay safe online",
                "I can assist with cybersecurity questions and tips",
                "I can help you understand online safety and security"
            }},
            {"what type of questions can i ask?", new[] {
                "You can ask me about things like password safety, types of scams, and overall safety",
                "Feel free to ask about online safety, scams, and password security",
                "You can ask me anything related to cybersecurity"
            }},
            {"How do i create a safe password?", new[] {
                "When creating a password you want it to be as safe as posible. Use techniques such as a unique word, never a pets name, and a mix of special characters and numbers",
                "Make your password long (12+ characters), use uppercase and lowercase letters, numbers, and special characters. Avoid using personal info",
                "Consider using a passphrase — a series of unrelated words — and a password manager to keep track of them"
            }},
            {"What are some online scams?", new[] {
                "Common scams include: phishing, tech support scams, prize scams, and impersonation scams",
                "Scams you might see include romance scams, fake online stores, investment scams, and job offer scams",
                "Watch out for scams like fake charity appeals, lottery winnings, and social media impersonations"
            }},
            {"What is a phishing scam?", new[] {
                "Phishing is when attackers trick you into giving away personal info via fake messages or websites",
                "Phishing often comes as emails or texts that seem real but try to steal your passwords or credit card info",
                "These scams usually pretend to be from banks, companies, or even friends, urging you to click fake links"
            }},
            {"What is a tech support scam?", new[] {
                "A scam where someone pretends to be tech support to trick you into giving access or money",
                "Scammers may call you or show fake warnings on your computer claiming there's a problem only they can fix—for a fee",
                "They'll try to get you to install software or give remote access, then steal info or demand payment"
            }},
            {"What is a prize scam?", new[] {
                "You’re told you won something, but you have to pay or share info to claim it — it’s a scam!",
                "These scams use excitement to trick you — if you didn’t enter a contest, you didn’t win",
                "Scammers might ask for 'shipping fees' or personal details to claim the fake prize"
            }},
            {"How do i avoid scams?", new[] {
                "Never click suspicious links, use 2FA, and be skeptical of 'urgent' messages asking for info",
                "Always verify unexpected messages or calls before acting — better safe than sorry",
                "Keep your software up to date and don’t share personal details unless you're sure it's safe"
            }},
            //Help
            {"Help", new[]
            {
                "Here are some things that you can ask me:",
                "Password saftey",
                "Types of scams",
                "Overall safety",
                "Features i can do:",
                "Quiz me on cybersecurity (Ask for 'Quizz')",
                "Show activity log (Ask for 'Activity Log')",
                "Open task manager for tasks (Ask for 'Task Manager')"

            }}
        };

        private readonly Dictionary<string, string> sentimentResponses = new Dictionary<string, string>
        {
            { "worried", "It's completely understandable to feel that way. Scammers can be very convincing. Let me share some tips to help you stay safe." },
            { "frustrated", "I'm sorry you're feeling frustrated. Cybersecurity can feel overwhelming, but you're not alone. Let's go over it together." },
            { "curious", "It's great that you're curious! Learning about cybersecurity is a smart move and I'm here to help." },
            { "confused", "No worries! Cybersecurity can be complex, but I'm here to make it easier to understand." },
            { "scared", "It's okay to feel scared — the online world can be risky. Let's work together to stay safe." },
            { "angry", "I understand your frustration. If something's gone wrong, let’s talk through how to prevent it next time." },
            { "happy", "That’s great to hear! Let’s keep that good energy while learning about staying secure online." },
            { "anxious", "Feeling anxious is normal when it comes to online safety. I'll help guide you step by step." },
            { "unsure", "If you're unsure about anything, just ask. I'm here to make things clearer for you." },
            { "overwhelmed", "There’s a lot to take in, but don’t worry — we’ll go through it one step at a time." }
        };

        public void RespondToQuestion(string question)
        {
            string lower = question.ToLower();

            if (lower == "stop")
            {
                output.AppendText("Goodbye! Closing the chatbot...\n");
                Application.Exit();
                return;
            }

            if (lower.Contains("task manager"))
            {
                OpenTaskManager();
                return;
            }
            if (lower.Contains("quiz") || lower.Contains("quizz"))
            {
                StartQuiz();
                return;
            }
            if (lower.Contains("activity log"))
            {
                ShowActivityLog();
                return;
            }

            foreach (var key in responses.Keys)
            {
                if (lower.Contains(key))
                {
                    foreach (var r in responses[key])
                    {
                        output.AppendText(r + "\n");
                    }
                    return;
                }
            }

            foreach (var key in sentimentResponses.Keys)
            {
                if (lower.Contains(key))
                {
                    output.AppendText(sentimentResponses[key] + "\n");
                    return;
                }
            }

            output.AppendText("I don't understand that. Try asking something else or type 'help'.\n");
        }

        public void ListQuestions()
        {
            output.AppendText("Here are some things you can ask:\n");
            output.AppendText("- How do I create a safe password?\n- What are some online scams?\n- Quiz me\n- Activity log\n- Task manager\n");
        }

        public void LogActivity(string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            activityLog.Insert(0, $"[{timestamp}] {message}");
        }

        public void ShowActivityLog()
        {
            output.AppendText("Activity Log:\n");
            int count = Math.Min(logPageSize, activityLog.Count);
            for (int i = 0; i < count; i++)
            {
                output.AppendText(activityLog[i] + "\n");
            }
        }

        public void StartQuiz()
        {
            quizQuestions.Clear();
            currentQuestionIndex = 0;
            score = 0;
            inQuiz = true;

            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "True or False: '123456' is a secure password.",
                Options = new[] { "True", "False" },
                CorrectOptionIndex = 1,
                Explanation = "'123456' is one of the most commonly hacked passwords."
            });

            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "What does 2FA stand for?",
                Options = new[] { "Two-Factor Authentication", "Two-Faced Attack", "Firewall Access" },
                CorrectOptionIndex = 0,
                Explanation = "2FA adds a second layer of security to logins."
            });

            ShowNextQuestion();
        }

        private void ShowNextQuestion()
        {
            if (currentQuestionIndex >= quizQuestions.Count)
            {
                output.AppendText($"Quiz complete! Your score: {score}/{quizQuestions.Count}\n");
                inQuiz = false;
                return;
            }

            var q = quizQuestions[currentQuestionIndex];
            output.AppendText($"Question {currentQuestionIndex + 1}: {q.QuestionText}\n");
            for (int i = 0; i < q.Options.Length; i++)
            {
                output.AppendText($"{i + 1}. {q.Options[i]}\n");
            }
        }

        public void OpenTaskManager()
        {
            output.AppendText("Task Manager:\n");
            output.AppendText("- Task 1: Check system updates\n");
            output.AppendText("- Task 2: Review security logs\n");
            output.AppendText("- Task 3: Change passwords regularly\n");
        }
    }

    public class QuizQuestion
    {
        public string QuestionText { get; set; }
        public string[] Options { get; set; }
        public int CorrectOptionIndex { get; set; }
        public string Explanation { get; set; }
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...------------------------------------------------------//