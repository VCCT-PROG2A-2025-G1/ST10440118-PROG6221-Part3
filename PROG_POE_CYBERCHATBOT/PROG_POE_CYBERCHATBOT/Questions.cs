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

            // Quiz mode active
            if (inQuiz)
            {
                QuizzLogic(lower);
                return;
            }

            if (lower.Contains("quiz") || lower.Contains("quizz"))
            {
                StartQuiz();
                return;
            }

            if (lower.Contains("task"))
            {
                TaskManagerLogic(question); // pass original input
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

            output.AppendText("I don't understand that, Try asking something else or type 'help' for a list of questions to ask\n");
        }

        //Quizz logic
        private void QuizzLogic(string input)
        {
            {
                if (!inQuiz)
                    return;

                int userAnswer;
                if (int.TryParse(input.Trim(), out userAnswer))
                {
                    userAnswer--; // convert to 0-based index

                    var currentQuestion = quizQuestions[currentQuestionIndex];

                    if (userAnswer >= 0 && userAnswer < currentQuestion.Options.Length)
                    {
                        if (userAnswer == currentQuestion.CorrectOptionIndex)
                        {
                            output.AppendText("Correct\n");
                            score++;
                        }
                        else
                        {
                            output.AppendText("Incorrect " + currentQuestion.Explanation + "\n");
                        }

                        currentQuestionIndex++;

                        if (currentQuestionIndex >= quizQuestions.Count)
                        {
                            output.AppendText($"\nQuizz is done, Your score is: {score}/{quizQuestions.Count}\n");

                            if (score >= 3)
                            {
                                output.AppendText("Well done! You have a good understanding of cybersecurity\n");
                            }
                            else
                            {
                                output.AppendText("A good effort, Review the tips and try again to improve your score\n");
                            }

                            inQuiz = false;
                        }
                        else
                        {
                            var nextQuestion = quizQuestions[currentQuestionIndex];
                            output.AppendText($"\nQuestion {currentQuestionIndex + 1}: {nextQuestion.QuestionText}\n");
                            for (int i = 0; i < nextQuestion.Options.Length; i++)
                            {
                                output.AppendText($"{i + 1}. {nextQuestion.Options[i]}\n");
                            }
                        }
                    }
                    else
                    {
                        output.AppendText("Please enter a valid number\n");
                    }
                }
                else
                {
                    output.AppendText("Please enter a number corresponding to an answer\n");
                }
            }
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

        //Quizz questions
        public void StartQuiz()
        {
            quizQuestions.Clear();
            currentQuestionIndex = 0;
            score = 0;
            inQuiz = true;

            // Question 1
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "True or False: '123456' is a secure password.",
                Options = new[] { "True", "False" },
                CorrectOptionIndex = 1,
                Explanation = "'123456' is one of the most commonly hacked passwords."
            });

            // Question 2
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "What does 2FA stand for?",
                Options = new[] { "Two-Factor Authentication", "Two-Faced Attack", "Firewall Access" },
                CorrectOptionIndex = 0,
                Explanation = "2FA adds a second layer of security to logins."
            });

            // Question 3
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "Which of these is a sign of a phishing email?",
                Options = new[] { "It has perfect grammar and spelling", "It comes from your boss’s official email", "It urges immediate action and contains suspicious links" },
                CorrectOptionIndex = 2,
                Explanation = "Phishing emails often pressure you to act quickly and include suspicious links or attachments."
            });

            // Question 4
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "What should you do if you receive a suspicious link in an email?",
                Options = new[] { "Click it quickly to see what it is", "Ignore your instincts and open it anyway", "Avoid clicking and verify the sender through another method" },
                CorrectOptionIndex = 2,
                Explanation = "Always verify suspicious messages via another method before clicking any links."
            });

            // Question 5
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "What is the safest way to store your passwords?",
                Options = new[] { "Write them in a notebook near your desk", "Save them in your browser without protection", "Use a trusted password manager" },
                CorrectOptionIndex = 2,
                Explanation = "A password manager stores your credentials securely and encrypts them."
            });
            //6
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "Which of the following is the most secure way to connect to public Wi-Fi?",
                Options = new[] { "Connect freely without any protection", "Use a VPN while connected", "Only browse social media" },
                CorrectOptionIndex = 1,
                Explanation = "A VPN encrypts your connection, making it safer when using public Wi-Fi."
            });
            //7
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "What is malware?",
                Options = new[] { "A type of antivirus software", "Malicious software designed to harm or exploit systems", "A secure browser extension" },
                CorrectOptionIndex = 1,
                Explanation = "Malware is any software intentionally designed to cause damage to a computer or network."
            });
            //8
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "Why should you avoid reusing the same password for multiple accounts?",
                Options = new[] { "It’s hard to remember", "It increases the chance of all accounts being hacked if one is compromised", "It slows down your internet" },
                CorrectOptionIndex = 1,
                Explanation = "If one account is breached, reused passwords can give hackers access to other accounts."
            });
            //9
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "What should you do if you receive a call from someone claiming to be tech support asking for remote access?",
                Options = new[] { "Give them access if they sound professional", "Hang up and contact the company directly", "Follow their instructions carefully" },
                CorrectOptionIndex = 1,
                Explanation = "Scammers often pretend to be tech support to steal your information. Always verify through official channels."
            });
            //10
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "Which of these file extensions should you be cautious about opening in emails?",
                Options = new[] { ".pdf", ".exe", ".jpg" },
                CorrectOptionIndex = 1,
                Explanation = "Executable files (.exe) can install malware on your system when opened."
            });


            // Show the first question right away
            var first = quizQuestions[0];
            output.AppendText($"Question 1: {first.QuestionText}\n");
            for (int i = 0; i < first.Options.Length; i++)
            {
                output.AppendText($"{i + 1}. {first.Options[i]}\n");
            }
        }

        //Task manager logic
        private class TaskItem
        {
            public string Description { get; set; }
            public DateTime Due { get; set; }
            public bool Completed { get; set; }
        }

        private List<TaskItem> tasks = new List<TaskItem>();

        private void TaskManagerLogic(string input)
        {
            string lower = input.ToLower();

            if (lower == "task manager")
            {
                if (tasks.Count == 0)
                {
                    output.AppendText("No tasks added yet, say 'add task <description> at <yyyy-MM-dd HH:mm>' to add tasks\n");
                    return;
                }

                output.AppendText("Task Manager:\n");
                for (int i = 0; i < tasks.Count; i++)
                {
                    var t = tasks[i];
                    string status = t.Completed ? "Completed" : "Pending";
                    output.AppendText($"{i + 1}. {t.Description} (Due: {t.Due:yyyy-MM-dd HH:mm}) - {status}\n");
                }
            }
            else if (lower.StartsWith("add task "))
            {
                try
                {
                    int atIndex = input.IndexOf(" at ", StringComparison.OrdinalIgnoreCase);
                    if (atIndex > 8)
                    {
                        string desc = input.Substring(9, atIndex - 9).Trim();
                        string dateStr = input.Substring(atIndex + 4).Trim();
                        if (DateTime.TryParse(dateStr, out DateTime dueDate))
                        {
                            tasks.Add(new TaskItem { Description = desc, Due = dueDate, Completed = false });
                            output.AppendText($"Task added: {desc} (Due: {dueDate:yyyy-MM-dd HH:mm})\n");
                        }
                        else
                        {
                            output.AppendText("Invalid date format, Please use the following: yyyy-MM-dd HH:mm\n");
                        }
                    }
                    else
                    {
                        output.AppendText("Use, add task <description> at <yyyy-MM-dd HH:mm>\n");
                    }
                }
                catch
                {
                    output.AppendText("There was an error adding the task, be sure the format is correct\n");
                }
            }
            else if (lower.StartsWith("complete task "))
            {
                if (int.TryParse(input.Substring(14).Trim(), out int index) && index > 0 && index <= tasks.Count)
                {
                    tasks[index - 1].Completed = true;
                    output.AppendText($"Task {index} is marked as completed\n");
                }
                else
                {
                    output.AppendText("Invalid task number\n");
                }
            }
            else if (lower.StartsWith("delete task "))
            {
                if (int.TryParse(input.Substring(12).Trim(), out int index) && index > 0 && index <= tasks.Count)
                {
                    var removedTask = tasks[index - 1];
                    tasks.RemoveAt(index - 1);
                    output.AppendText($"Task {index} deleted: {removedTask.Description}\n");
                }
                else
                {
                    output.AppendText("Invalid task number\n");
                }
            }
            else
            {
                output.AppendText("Task Manager commands:\n");
                output.AppendText("'task manager' to list tasks\n");
                output.AppendText("'add task <description> at <yyyy-MM-dd HH:mm>' to add a task\n");
                output.AppendText("'complete task <number>' to mark a task as done\n");
                output.AppendText("'delete task <number>' to remove a task\n");
            }
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