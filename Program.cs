using System;
using System.Collections.Generic;
using System.Media;
using System.Threading;

namespace CyberSec_Chatbot
{
    internal class Program
    {
        static string userName = "";
        static string favoriteTopic = "";
        static string lastTopic = "";

        static Random rand = new Random();

        static Dictionary<string, List<string>> topicResponses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
        {
            ["phishing"] = new List<string>
            {
                "Phishing emails often appear to come from trusted sources. Always double-check the sender's address.",
                "Don't click on suspicious links or attachments. They might contain malware.",
                "Scammers may create fake websites that look real. Always verify the URL."
            },
            ["password"] = new List<string>
            {
                "Use a strong, unique password for each account.",
                "Avoid using birthdays, names, or easy-to-guess words in your password.",
                "Consider using a password manager to generate and store complex passwords."
            },
            ["privacy"] = new List<string>
            {
                "Check the privacy settings on all your apps and accounts.",
                "Limit what personal information you share online.",
                "Regularly review app permissions on your devices."
            },
            ["scam"] = new List<string>
            {
                "Scams often pressure you to act quickly. Take your time and verify sources.",
                "Be cautious of messages offering rewards or threatening consequences.",
                "Don’t give out personal info to unknown contacts, even if they sound official."
            },
            ["vpn"] = new List<string>
            {
                "A VPN encrypts your internet traffic, especially useful when using public Wi-Fi.",
                "Always choose a reputable VPN provider. Free VPNs can be risky.",
                "VPNs help hide your IP and browsing activity from trackers."
            }
        };

        static Dictionary<string, string> sentimentResponses = new Dictionary<string, string>
        {
            ["worried"] = "It's completely okay to feel that way. Cybersecurity can be overwhelming, but I’m here to help.",
            ["confused"] = "No worries! These topics can be tricky. Let me explain it in a simpler way.",
            ["curious"] = "Curiosity is great! Let's dive deeper into that topic.",
            ["frustrated"] = "Take a deep breath. Cybersecurity takes time to learn — you’re doing great!",
            ["scared"] = "It’s normal to be cautious. With the right knowledge, you can stay secure.",
            ["lost"] = "Let’s take it step by step. What topic would you like me to explain again?"
        };

        static void Main()
        {
            PlayVoiceGreeting();
            DisplayAsciiArt();
            GreetUser();
            StartChat();
        }

        static void PlayVoiceGreeting()
        { 
           
            try
            {
                SoundPlayer player = new SoundPlayer(@"C:\Users\orati\Downloads\greeting.wav");
                player.Load();
                player.PlaySync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error] Audio not played: {ex.Message}");
            }
           
        }

        static void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            SimulateTyping(@"
      .----------.
    /             \
   |    TALKIE |
   |      BOT      |
   |,  .-.  .-.  ,|
   | )(_o/  \o_)( |
   |/     /\     \|
   (_     ^^     _)
    \__|IIIIII|__/
     | \IIIIII/ |
     \          /
      `--------`");
            Console.ResetColor();
        }

        static void GreetUser()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\nWhat is your name? ");
            Console.ResetColor();
            userName = Console.ReadLine().Trim();

            SimulateTyping($"\nHi {userName}, welcome to the Cybersecurity Awareness Bot!");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("What topic are you most interested in (e.g., phishing, password, privacy, scam)? ");
            Console.ResetColor();
            favoriteTopic = Console.ReadLine().Trim().ToLower();

            SimulateTyping($"Awesome! I'll remember that you're especially interested in {favoriteTopic}.");
        }

        static void StartChat()
        {
            SimulateTyping("\nAsk me anything about cybersecurity or type 'bye' to exit.");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\nYou: ");
                Console.ResetColor();
                string input = Console.ReadLine().Trim().ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    SimulateTyping("Bot: Hmm, I didn’t catch that. Can you rephrase?");
                    continue;
                }

                if (input == "bye")
                {
                    SimulateTyping($"Bot: Goodbye {userName}! Stay safe and keep learning about {favoriteTopic}!");
                    break;
                }

                if (HandleSentiment(input)) continue;

                if (input.Contains("more") || input.Contains("explain"))
                {
                    if (!string.IsNullOrEmpty(lastTopic) && topicResponses.ContainsKey(lastTopic))
                    {
                        SendRandomResponse(lastTopic);
                    }
                    else
                    {
                        SimulateTyping("Bot: Please tell me which topic you'd like more info on.");
                    }
                    continue;
                }

                bool topicHandled = false;
                foreach (var topic in topicResponses.Keys)
                {
                    if (input.Contains(topic))
                    {
                        lastTopic = topic;
                        SendRandomResponse(topic);
                        topicHandled = true;
                        break;
                    }
                }

                if (!topicHandled)
                {
                    SimulateTyping("Bot: I'm not sure I understand. Can you try rephrasing or ask about a cybersecurity topic like VPNs, scams, or passwords?");
                }
            }
        }

        static void SendRandomResponse(string topic)
        {
            List<string> responses = topicResponses[topic];
            string response = responses[rand.Next(responses.Count)];
            SimulateTyping($"Bot: {response}");
        }

        static bool HandleSentiment(string input)
        {
            foreach (var sentiment in sentimentResponses)
            {
                if (input.Contains(sentiment.Key))
                {
                    SimulateTyping($"Bot: {sentiment.Value}");
                    return true;
                }
            }
            return false;
        }

        static void SimulateTyping(string message, int delay = 30)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
