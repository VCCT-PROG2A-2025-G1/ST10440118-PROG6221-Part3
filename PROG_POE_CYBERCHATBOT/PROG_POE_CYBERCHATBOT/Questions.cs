using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Diagnostics;
using System.Security.Policy;
using System.Net.NetworkInformation;

namespace PROG_POE_CYBERCHATBOT
{
    internal class Questions
    {
        //Variable to store the last topic discussed
        private string lastTopic = null;
        //Variable to store the user's interest in cybersecurity
        private string userInterest = null;
        //Variable to store the user's name
        private string userName = null;

        //Storing the questions and related answers

        //Dictionary to store sentiment responses based on keywords in user input
        //Used ChatGPT to generate the answers to the sentiment responses
        private readonly Dictionary<string, string> sentimentResponses = new Dictionary<string, string>
        {
            { "worried", "It's completely understandable to feel that way. Scammers can be very convincing. Let me share some tips to help you stay safe." },
            { "frustrated", "I'm sorry you're feeling frustrated. Cybersecurity can feel overwhelming, but you're not alone. Let's go over it together." },
            { "curious", "It's great that you're curious! Learning about cybersecurity is a smart move and I'm here to help." }
        };
        //Used an array of strings to store the answers for each question
        private readonly Dictionary<string, string[]> responses = new Dictionary<string, string[]>
        {
            //Keywords spotting within the user input
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
            //Questions and answers for the chatbot
            //Some questions answers have been gernerated by ChatGPT
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
            }}
        };
        //-------------------------------------------------------------------------------------------------------------------------
        //List of all the questions the user can ask
        private readonly string[] questionList = {
            "Questions relating to cybersecurity:",
            "How do i create a safe password?",
            "What are some online scams?",
            "What is a phishing scam?",
            "What is a tech support scam?",
            "What is a prize scam?",
            "How do i avoid scams?",
            "",
            "Fun questions:",
            "How are you?",
            "What can you help with?",
            "What type of questions can i ask?",
        };
        //-------------------------------------------------------------------------------------------------------------------------
        //Method to respond to the user's question
        public void RespondToQuestion(string question)
        {
            //Normalize the input to lowercase and trim whitespace
            string input = question.ToLower().Trim();
            Console.ForegroundColor = ConsoleColor.Cyan;
            //Random number generator to select a random response
            Random random = new Random();
            bool found = false;
            //Determine if the input contains any sentiment keywords
            string sentimentPrefix = null;
            foreach (var sentiment in sentimentResponses)
            {
                if (input.Contains(sentiment.Key))
                {
                    //If a sentiment keyword is found, respond with the corresponding prefix
                    sentimentPrefix = sentiment.Value;
                    break;
                }
            }
            //Check if user shares an interest
            if (input.StartsWith("i'm interested in "))
            {
                //Extract the user's interest from the input
                userInterest = input.Substring("i'm interested in ".Length).Trim();
                Console.WriteLine($"Thats amazing, i'll remember that you're interested in {userInterest}");
                Console.ResetColor();
                return;
            }
            //If the user has said any keywords related to sentiment, respond with the sentiment response
            foreach (var pair in responses)
            {
                if (input == pair.Key.ToLower())
                {
                    //If an exact match is found, select a random response from the answers
                    string[] answers = pair.Value;
                    string reply = answers[random.Next(answers.Length)];
                    if (userName != null)
                    {
                        reply = $"{userName}, {reply}";
                    }
                    if (sentimentPrefix != null)
                    {
                        reply = $"{sentimentPrefix} {reply}";
                    }
                    Console.WriteLine(reply);
                    lastTopic = pair.Key.ToLower();
                    found = true;
                    break;
                }
            }
            //If not found, but there was a previous topic
            if (!found && lastTopic != null && responses.ContainsKey(lastTopic))
            {
                Console.WriteLine("Following up on your last question...");
                string[] answers = responses[lastTopic];
                string reply = answers[random.Next(answers.Length)];
                if (userName != null)
                {
                    reply = $"{userName}, {reply}";
                }
                if (sentimentPrefix != null)
                {
                    reply = $"{sentimentPrefix} {reply}";
                }
                Console.WriteLine(reply);
                found = true;
            }
            //Still not found
            if (!found)
            {
                Console.WriteLine("I am sorry, I don't understand. Please type 'help' for a list of questions to ask me.");
                lastTopic = null;
            }
            Console.ResetColor();
        }
        //-------------------------------------------------------------------------------------------------------------------------
        //Method to be able to list every question the user can ask
        public void ListQuestions()
        {
            foreach (var question in questionList)
            {
                Console.WriteLine(question);  
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...------------------------------------------------------//