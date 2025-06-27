using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PROG_POE_CYBERCHATBOT
{
    internal class Questions
    {
        //List of variables
        private RichTextBox output;
        private List<string> activityLog = new List<string>();
        private const int logPageSize = 5;
        private List<QuizQuestion> quizQuestions = new List<QuizQuestion>();
        private int currentQuestionIndex = 0;
        private int score = 0;
        private bool inQuiz = false;
        //------------------------------------------------------------------------------------------------------
        
        //Constructor that initializes the output in RichTextBox
        public Questions(RichTextBox outputBox)
        {
            output = outputBox;
        }
        //------------------------------------------------------------------------------------------------------
        
        //Dictionary to hold responses for different questions
        //Used GitHub Copilot to generate these responses
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
            {"how do i create a safe password?", new[] {
                "When creating a password you want it to be as safe as posible. Use techniques such as a unique word, never a pets name, and a mix of special characters and numbers",
                "Make your password long (12+ characters), use uppercase and lowercase letters, numbers, and special characters. Avoid using personal info",
                "Consider using a passphrase — a series of unrelated words — and a password manager to keep track of them"
            }},
            {"what are some online scams?", new[] {
                "Common scams include: phishing, tech support scams, prize scams, and impersonation scams",
                "Scams you might see include romance scams, fake online stores, investment scams, and job offer scams",
                "Watch out for scams like fake charity appeals, lottery winnings, and social media impersonations"
            }},
            {"what is a phishing scam?", new[] {
                "Phishing is when attackers trick you into giving away personal info via fake messages or websites",
                "Phishing often comes as emails or texts that seem real but try to steal your passwords or credit card info",
                "These scams usually pretend to be from banks, companies, or even friends, urging you to click fake links"
            }},
            {"what is a tech support scam?", new[] {
                "A scam where someone pretends to be tech support to trick you into giving access or money",
                "Scammers may call you or show fake warnings on your computer claiming there's a problem only they can fix—for a fee",
                "They'll try to get you to install software or give remote access, then steal info or demand payment"
            }},
            {"what is a prize scam?", new[] {
                "You’re told you won something, but you have to pay or share info to claim it — it’s a scam!",
                "These scams use excitement to trick you — if you didn’t enter a contest, you didn’t win",
                "Scammers might ask for 'shipping fees' or personal details to claim the fake prize"
            }},
            {"how do i avoid scams?", new[] {
                "Never click suspicious links, use 2FA, and be skeptical of 'urgent' messages asking for info",
                "Always verify unexpected messages or calls before acting — better safe than sorry",
                "Keep your software up to date and don’t share personal details unless you're sure it's safe"
            }},
            //Help list
            {"help", new[]
            {
                @"Here are some things that you can ask me:
                Password saftey
                Types of scams
                Overall safety
                Features i can do:
                Quiz me on cybersecurity (Ask for 'Quizz')
                Show activity log (Ask for 'Activity Log' and 'show more' to see all activity))
                Open task manager for tasks (Ask for 'Task Manager')
                To leave the program type 'Exit'"

            }}
        };
        //------------------------------------------------------------------------------------------------------

        //Dictionary to hold responses for different sentiments
        //Used GitHub Copilot to generate these responses
        private readonly Dictionary<string, string> sentimentResponses = new Dictionary<string, string>
        {
            { "worried", "It's completely understandable to feel that way. Scammers can be very convincing. Let me share some tips to help you stay safe"},
            { "frustrated", "I'm sorry you're feeling frustrated. Cybersecurity can feel overwhelming, but you're not alone. Let's go over it together"},
            { "curious", "It's great that you're curious! Learning about cybersecurity is a smart move and I'm here to help"},
            { "confused", "No worries! Cybersecurity can be complex, but I'm here to make it easier to understand"},
            { "scared", "It's okay to feel scared — the online world can be risky. Let's work together to stay safe"},
            { "angry", "I understand your frustration. If something's gone wrong, let’s talk through how to prevent it next time"},
            { "happy", "That’s great to hear! Let’s keep that good energy while learning about staying secure online"},
            { "anxious", "Feeling anxious is normal when it comes to online safety. I'll help guide you step by step"},
            { "unsure", "If you're unsure about anything, just ask. I'm here to make things clearer for you"},
            { "overwhelmed", "There’s a lot to take in, but don’t worry — we’ll go through it one step at a time"}
        };
        //------------------------------------------------------------------------------------------------------

        //Method to respond to user questions
        //Calls each method for different questions
        public void RespondToQuestion(string question)
        {
            //Checks if input is lowercase
            string lower = question.ToLower();

            //Checks if user wants to stop
            if (lower == "stop")
            {
                output.AppendText($"Goodbye, {UserName}! Lovely chatting to you!\n");
                Application.Exit();
                return;
            }

            //If the quizz is active, it will call the QuizzLogic method
            if (inQuiz)
            {
                QuizzLogic(lower);
                return;
            }

            //Quiz logic is called if user asks for quiz
            if (lower.Contains("quiz") || lower.Contains("quizz"))
            {
                LogActivity("User started a quiz");
                StartQuiz();
                return;
            }

            //If contains "task" will call TaskManagerLogic method
            if (lower.Contains("task"))
            {
                TaskManagerLogic(question);
                return;
            }

            //If contains "activity log" or "show more" will call ShowActivityLog method
            if (lower.Contains("activity log"))
            {
                ShowActivityLog();
                return;
            }
            if (lower == "show more")
            {
                ShowActivityLog(true);
                return;
            }

            //Checks if the input contains any of the keys in the responses dictionary
            foreach (var key in responses.Keys)
            {
                if (lower.Contains(key.ToLower()))
                {
                    var random = new Random();
                    var selectedResponse = responses[key][random.Next(responses[key].Length)];
                    output.AppendText(selectedResponse + "\n");
                    LogActivity($"Asked about: {key}");
                    return;
                }
            }

            //Checks if the input contains any of the keys in the sentimentResponses dictionary
            foreach (var key in sentimentResponses.Keys)
            {
                if (lower.Contains(key))
                {
                    output.AppendText(sentimentResponses[key] + "\n");
                    return;
                }
            }
            //If no keywords matched, respond with a default message
            output.AppendText("I don't understand, Try asking something else or type 'help' for a list of questions to ask\n");
        }
        //------------------------------------------------------------------------------------------------------

        //Quizzlogic method
        private void QuizzLogic(string input)
        {
            {
                //Check if the input is a number and parse it
                int userAnswer;

                //If a valid number is entered, it will check if the answer is correct
                if (int.TryParse(input.Trim(), out userAnswer))
                {
                    //Decrement userAnswer by 1 to match array index (0-based)
                    userAnswer--;

                    //Get the current question based on the index
                    var currentQuestion = quizQuestions[currentQuestionIndex];

                    //Check if the answer is within the valid range of options
                    if (userAnswer >= 0 && userAnswer < currentQuestion.Options.Length)
                    {
                        //If the answer is correct, increment the score and display a message
                        if (userAnswer == currentQuestion.CorrectOptionIndex)
                        {
                            output.AppendText("Correct\n");
                            score++;
                        }
                        //If not, display the explanation for the correct answer
                        else
                        {
                            output.AppendText("Incorrect " + currentQuestion.Explanation + "\n");
                        }

                        //Increment the question index to move to the next question
                        currentQuestionIndex++;

                        //If all questions have been answered, display the final score and a message
                        if (currentQuestionIndex >= quizQuestions.Count)
                        {
                            output.AppendText($"\nQuizz is done, Your score is: {score}/{quizQuestions.Count}\n");
                            
                            //If the score is 5 or more, display a congratulatory message, otherwise encourage the user to review the tips
                            if (score >= 5)
                            {
                                output.AppendText("Well done! You have a good understanding of cybersecurity\n");
                            }
                            else
                            {
                                output.AppendText("A good effort, Review the tips and try again to improve your score\n");
                            }

                            //Log the quiz completion activity
                            inQuiz = false;
                        }
                        else
                        {
                            //Display the next question and its options
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
                        //If the answer is not valid, display an error message
                        output.AppendText("Please enter a valid number\n");
                    }
                }
                else
                {
                    //If the input is not a valid number, display an error message
                    output.AppendText("Please enter a number corresponding to an answer\n");
                }
            }
        }
        //------------------------------------------------------------------------------------------------------

        //Method to log activity in the activity log
        public void LogActivity(string message)
        {
            //Add a timestamp to the message and insert it at the beginning of the activity log
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            activityLog.Insert(0, $"[{timestamp}] {message}");
        }
        //Store the current index of the activity log to show more entries
        private int currentLogIndex = 0;

        //Method to show the activity log
        public void ShowActivityLog(bool showMore = false)
        {
            //Check if the activity log is empty
            if (showMore)
                currentLogIndex += logPageSize;
            else
                currentLogIndex = 0;
            //If the log is empty, display a message and return
            output.AppendText("Activity Log:\n");

            //Work out how many entries to show based on the logPageSize and currentLogIndex
            int count = Math.Min(logPageSize, activityLog.Count - currentLogIndex);
            if (count <= 0)
            {
                //If there are no more entries to show, display a message and return
                output.AppendText("No more activity log entries\n");
                return;
            }

            //Loop through the activity log from the current index and append the entries to the output
            for (int i = currentLogIndex; i < currentLogIndex + count; i++)
            {
                //Print each entry in the activity log
                output.AppendText(activityLog[i] + "\n");
            }

            //If there are more entries to show, display a message prompting the user to type 'Show More'
            if (currentLogIndex + count < activityLog.Count)
            {
                output.AppendText("\nType 'Show More' to see more log entries\n");
            }
        }
        //------------------------------------------------------------------------------------------------------

        //Start quizz method
        public void StartQuiz()
        {
            //Clear the quiz questions and reset the state variables
            quizQuestions.Clear();
            currentQuestionIndex = 0;
            score = 0;
            inQuiz = true;

            //Questions for the quizz
            //Used GitHub Copilot to help come up with questions and answers
            //1
            quizQuestions.Add(new QuizQuestion
            {
                //Question
                QuestionText = "True or False: '123456' is a secure password",
                //Answers
                Options = new[] { "True", "False" },
                //Correct answer index
                CorrectOptionIndex = 1,
                //Explanation for the answer
                Explanation = "'123456' is one of the most commonly hacked passwords"
            });
            //2
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "What does 2FA stand for?",
                Options = new[] { "Two-Factor Authentication", "Two-Faced Attack", "Firewall Access" },
                CorrectOptionIndex = 0,
                Explanation = "2FA adds a second layer of security to logins"
            });
            //3
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "Which of these is a sign of a phishing email?",
                Options = new[] { "It has perfect grammar and spelling", "It comes from your boss’s official email", "It urges immediate action and contains suspicious links" },
                CorrectOptionIndex = 2,
                Explanation = "Phishing emails often pressure you to act quickly and include suspicious links or attachments"
            });
            //4
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "What should you do if you receive a suspicious link in an email?",
                Options = new[] { "Click it quickly to see what it is", "Ignore your instincts and open it anyway", "Avoid clicking and verify the sender through another method" },
                CorrectOptionIndex = 2,
                Explanation = "Always verify suspicious messages via another method before clicking any links"
            });
            //5
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "What is the safest way to store your passwords?",
                Options = new[] { "Write them in a notebook near your desk", "Save them in your browser without protection", "Use a trusted password manager" },
                CorrectOptionIndex = 2,
                Explanation = "A password manager stores your credentials securely and encrypts them"
            });
            //6
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "Which of the following is the most secure way to connect to public Wi-Fi?",
                Options = new[] { "Connect freely without any protection", "Use a VPN while connected", "Only browse social media" },
                CorrectOptionIndex = 1,
                Explanation = "A VPN encrypts your connection, making it safer when using public Wi-Fi"
            });
            //7
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "What is malware?",
                Options = new[] { "A type of antivirus software", "Malicious software designed to harm or exploit systems", "A secure browser extension" },
                CorrectOptionIndex = 1,
                Explanation = "Malware is any software intentionally designed to cause damage to a computer or network"
            });
            //8
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "Why should you avoid reusing the same password for multiple accounts?",
                Options = new[] { "It’s hard to remember", "It increases the chance of all accounts being hacked if one is compromised", "It slows down your internet" },
                CorrectOptionIndex = 1,
                Explanation = "If one account is breached, reused passwords can give hackers access to other accounts"
            });
            //9
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "What should you do if you receive a call from someone claiming to be tech support asking for remote access?",
                Options = new[] { "Give them access if they sound professional", "Hang up and contact the company directly", "Follow their instructions carefully" },
                CorrectOptionIndex = 1,
                Explanation = "Scammers often pretend to be tech support to steal your information, always verify through official channels"
            });
            //10
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "Which of these file extensions should you be cautious about opening in emails?",
                Options = new[] { ".pdf", ".exe", ".jpg" },
                CorrectOptionIndex = 1,
                Explanation = "Executable files (.exe) can install malware on your system when opened"
            });

            //Variable to track if the quiz is active
            var first = quizQuestions[0];
            output.AppendText($"Question 1: {first.QuestionText}\n");
            for (int i = 0; i < first.Options.Length; i++)
            {
                output.AppendText($"{i + 1}. {first.Options[i]}\n");
            }
        }
        //------------------------------------------------------------------------------------------------------

        //Method to create define a task item
        private class TaskItem
        {
            public string Description { get; set; }
            public DateTime Due { get; set; }
            public bool Completed { get; set; }
        }
        //------------------------------------------------------------------------------------------------------

        //Task manager logic
        private List<TaskItem> tasks = new List<TaskItem>();
        //------------------------------------------------------------------------------------------------------

        //Property to hold the user's name
        public object UserName { get; private set; }
        //------------------------------------------------------------------------------------------------------

        //Method to handle task management logic
        private void TaskManagerLogic(string input)
        {
            //Set the input to lowercase
            string lower = input.ToLower();

            //If the input is "task manager", it will display the task list
            if (lower == "task manager")
            {
                //Check if there are any tasks to display
                if (tasks.Count == 0)
                {
                    //If no tasks, display a message
                    output.AppendText("No tasks added yet, say 'add task (description) at (yyyy-MM-dd HH:mm)' to add tasks\n");
                    return;
                }
                //If there are tasks, display them
                output.AppendText("Task Manager:\n");
                for (int i = 0; i < tasks.Count; i++)
                {
                    var t = tasks[i];
                    //Display the task number, description, when its due and its status
                    string status = t.Completed ? "Completed" : "Pending";
                    output.AppendText($"{i + 1}. {t.Description} (Due: {t.Due:yyyy-MM-dd HH:mm}) - {status}\n");
                }
            }
            //If the input starts with "add task " it will add a new task
            else if (lower.StartsWith("add task "))
            {
                try
                {
                    //Extract the description and due date from the input
                    int atIndex = input.IndexOf(" at ", StringComparison.OrdinalIgnoreCase);
                    //If the index is greater than 8, it means the description is valid
                    if (atIndex > 8)
                    {
                        //Extract the description and due date from the input
                        string desc = input.Substring(9, atIndex - 9).Trim();
                        //Check if the due date is valid
                        string dateStr = input.Substring(atIndex + 4).Trim();
                        //If the date string is not empty, try to parse it
                        if (DateTime.TryParse(dateStr, out DateTime dueDate))
                        {
                            //Create a new task item and add it to the tasks list
                            tasks.Add(new TaskItem { Description = desc, Due = dueDate, Completed = false });
                            //Display a message confirming the task was added
                            output.AppendText($"Task added: {desc} (Due: {dueDate:yyyy-MM-dd HH:mm})\n");

                            //Log the activity of adding a task
                            LogActivity($"Task added: '{desc}' due {dueDate:yyyy-MM-dd HH:mm}");
                        }
                        else
                        {
                            //If the date format is invalid, display an error message
                            output.AppendText("Invalid date format, Please use the following: yyyy-MM-dd HH:mm\n");
                        }
                    }
                    else
                    {
                        //If the input format is incorrect, display an error message explaining how to add a task
                        output.AppendText("Type 'add task <description> at <yyyy-MM-dd HH:mm>'\n");
                    }
                }
                catch
                {
                    //If there was an error adding the task, display an error message
                    output.AppendText("There was an error adding the task, be sure the format is correct\n");
                }
            }
            //If the input starts with "complete task ", it will mark a task as completed
            else if (lower.StartsWith("complete task "))
            {
                if (int.TryParse(input.Substring(14).Trim(), out int index) && index > 0 && index <= tasks.Count)
                {
                    tasks[index - 1].Completed = true;
                    output.AppendText($"Task {index} is marked as completed\n");

                    //Log the activity of completing a task
                    LogActivity($"Task {index} marked as completed");
                }
                else
                {
                    //If the task number is invalid, display an error message
                    output.AppendText("Invalid task number\n");
                }
            }
            //If the input starts with "delete task ", it will delete a task
            else if (lower.StartsWith("delete task "))
            {
                if (int.TryParse(input.Substring(12).Trim(), out int index) && index > 0 && index <= tasks.Count)
                {
                    //Remove the task from the list and display a message confirming the deletion
                    var removedTask = tasks[index - 1];
                    tasks.RemoveAt(index - 1);
                    output.AppendText($"Task {index} deleted: {removedTask.Description}\n");

                    //Log the activity of deleting a task
                    LogActivity($"Task {index} deleted: {removedTask.Description}");
                }
                else
                {
                    //If the task number is invalid, display an error message
                    output.AppendText("Invalid task number\n");
                }
            }
            else
            {
                //If the input does not match any task commands, display the task manager commands they can use
                output.AppendText("Task Manager commands:\n");
                output.AppendText("'task manager' to list tasks\n");
                output.AppendText("'add task <description> at <yyyy-MM-dd HH:mm>' to add a task\n");
                output.AppendText("'complete task <number>' to mark a task as done\n");
                output.AppendText("'delete task <number>' to remove a task\n");
            }
        }
    }
    //------------------------------------------------------------------------------------------------------

    //Class to define a quiz question
    public class QuizQuestion
        {
            public string QuestionText { get; set; }
            public string[] Options { get; set; }
            public int CorrectOptionIndex { get; set; }
            public string Explanation { get; set; }
        }
    }
//------------------------------------------...ooo000 END OF FILE 000ooo...------------------------------------------------------//