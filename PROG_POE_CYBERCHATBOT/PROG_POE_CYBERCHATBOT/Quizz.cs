using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_POE_CYBERCHATBOT
{
    internal class Quizz
    {

        quizQuestions.Clear();
        currentQuestionIndex = 0;
        score = 0;
        inQuiz = true;

        quizQuestions.Add(new QuizQuestion
    {
        QuestionText = "True or False: Using '123456' as a password is safe.",
        Options = new[] { "True", "False" },
        CorrectOptionIndex = 1,
        Explanation = "'123456' is one of the most common and insecure passwords."
    });

    quizQuestions.Add(new QuizQuestion
{
    QuestionText = "What does 2FA stand for?",
    Options = new[] { "Two-Factor Authentication", "Two-Faced Access", "Firewall Access", "Functional Attack" },
    CorrectOptionIndex = 0,
    Explanation = "2FA stands for Two-Factor Authentication."
});

    quizQuestions.Add(new QuizQuestion
{
    QuestionText = "True or False: You should click links in suspicious emails to see where they go.",
    Options = new[] { "True", "False" },
    CorrectOptionIndex = 1,
    Explanation = "Never click links in suspicious emails."
});

    quizQuestions.Add(new QuizQuestion
{
    QuestionText = "Which of these is a strong password?",
    Options = new[] { "password123", "qwerty", "MyDog$Runs@5", "123456" },
    CorrectOptionIndex = 2,
    Explanation = "A strong password uses uppercase, lowercase, numbers, and symbols."
});

    quizQuestions.Add(new QuizQuestion
{
    QuestionText = "True or False: Public Wi-Fi is always secure.",
    Options = new[] { "True", "False" },
    CorrectOptionIndex = 1,
    Explanation = "Public Wi-Fi is not always secure; use a VPN if possible."
});

    quizQuestions.Add(new QuizQuestion
{
    QuestionText = "What type of attack tricks you into giving away sensitive information?",
    Options = new[] { "Brute-force", "Phishing", "DDoS", "SQL Injection" },
    CorrectOptionIndex = 1,
    Explanation = "Phishing attacks trick users into revealing sensitive info."
});

    quizQuestions.Add(new QuizQuestion
{
    QuestionText = "True or False: Antivirus software should be updated regularly.",
    Options = new[] { "True", "False" },
    CorrectOptionIndex = 0,
    Explanation = "Regular updates keep antivirus protection effective."
});

    quizQuestions.Add(new QuizQuestion
{
    QuestionText = "Which of these is a secure practice?",
    Options = new[] { "Writing passwords on sticky notes", "Reusing the same password", "Using a password manager", "Sharing passwords" },
    CorrectOptionIndex = 2,
    Explanation = "Using a password manager is a secure practice."
});

    quizQuestions.Add(new QuizQuestion
{
    QuestionText = "True or False: HTTPS is more secure than HTTP.",
    Options = new[] { "True", "False" },
    CorrectOptionIndex = 0,
    Explanation = "HTTPS encrypts data for secure communication."
});

    quizQuestions.Add(new QuizQuestion
{
    QuestionText = "Which of these is an example of multi-factor authentication?",
    Options = new[] { "Password only", "Password + OTP", "Username only", "PIN only" },
    CorrectOptionIndex = 1,
    Explanation = "Multi-factor uses more than one method: password + something else."
});

}

    ShowNextQuestion();
}
}

