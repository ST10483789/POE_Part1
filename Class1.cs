using System;

namespace POE_Part1
{
    internal class ChatBot
    {
        string[] keywords = { "password", "phishing", "browsing" };

        string[] responses =
        {
            "Use strong passwords with letters, numbers, and symbols.",
            "Be careful of phishing emails. Do not click suspicious links.",
            "Always browse secure websites (https) and avoid unsafe downloads."
        };

        public string GetResponse(string question)
        {
            if (string.IsNullOrWhiteSpace(question))
            {
                return "Chatbot: Please enter something.";
            }

            if (question == "exit")
            {
                return "exit";
            }

            bool found = false;

            string[] words = question.Split(' ');

            foreach (string word in words)
            {
                for (int i = 0; i < keywords.Length; i++)
                {
                    if (word == keywords[i])
                    {
                        found = true;
                        return "Chatbot: " + responses[i];
                    }
                }
            }

            if (!found)
            {
                return "Chatbot: I didn’t quite understand that. Could you rephrase?";
            }

            return "";
        }
    }
}