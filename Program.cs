using System;
using System.Media;
using System.Threading;

namespace POE_Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Chatbot";

            PlayVoiceGreeting();
            ShowBanner();

            Console.WriteLine("=========================================");
            Console.WriteLine("     CYBERSECURITY AWARENESS CHATBOT     ");
            Console.WriteLine("=========================================\n");

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Type 'exit' to quit the chatbot");

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Name cannot be empty. Enter your name: ");
                name = Console.ReadLine();
            }

            TypeText($"\n Welcome {name}! Ask me about cybersecurity.");
            Console.WriteLine("-----------------------------------------");

            string[] keywords = { "password", "phishing", "browsing" };

            string[] responses =
            {
                "Use strong passwords with a mix of letters, numbers, and symbols.",
                "Be careful of phishing emails. Do not click suspicious links.",
                "Always browse secure websites (https) and avoid unknown downloads."
            };

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n You: ");
                Console.ResetColor();

                string question = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(question))
                {
                    Console.WriteLine("Chatbot: please enter something.");continue;
                }

                question = question.ToLower();

                if (question == "exit")
                {
                    TypeText(" Chatbot: Goodbye! Stay safe online.");
                    Console.WriteLine("=========================================");
                    break;
                }

                bool found = false;

                string[] words = question.Split(' ');

                foreach (string word in words)
                {
                    for (int i = 0; i < keywords.Length; i++)
                    {
                        if (word == keywords[i])
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            TypeText($" Chatbot: {responses[i]}");
                            Console.ResetColor();

                            found = true;
                        }
                    }
                }

                if (!found)
                {
                    TypeText("Chatbot: I didn’t quite understand that. Try keywords like password, phishing, or browsing.");
                }

                Console.WriteLine("-----------------------------------------");
            }
        }

        static void ShowBanner()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(@"
██╗  ██╗ █████╗  ██████╗██╗  ██╗███████╗██████╗ 
██║  ██║██╔══██╗██╔════╝██║ ██╔╝██╔════╝██╔══██╗
███████║███████║██║     █████╔╝ █████╗  ██████╔╝
██╔══██║██╔══██║██║     ██╔═██╗ ██╔══╝  ██╔══██╗
██║  ██║██║  ██║╚██████╗██║  ██╗███████╗██║  ██║
╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝
");

            Console.ResetColor();
        }

        static void TypeText(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(30);
            }
            Console.WriteLine();
        }

        static void PlayVoiceGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("greeting.wav");
                player.PlaySync();
            }
            catch
            {
                Console.WriteLine("(Voice greeting failed to play)");
            }
        }
    }
}