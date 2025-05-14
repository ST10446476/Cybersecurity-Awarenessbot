CyberSec_Chatbot – Documentation
Overview
The CyberSec_Chatbot is a console-based chatbot application written in C#. Its purpose is to educate users on cybersecurity topics like phishing, password safety, privacy, and scams. It simulates natural conversations, recognizes user sentiments, remembers user preferences, and displays messages with a typing animation for realism.
Namespace & Class
namespace CyberSec_Chatbot
{
    internal class Program
    {
        // Entry point and main logic
    }
}
Features
- Name personalization
- Favorite topic memory
- Last discussed topic tracking
- Sentiment handling (e.g., worried, frustrated)
- Randomized responses per topic
- Typing simulation
- ASCII bot art
- Voice greeting using .wav file
- 
Main Flow
Main():
- Plays audio greeting
- Displays ASCII art
- Prompts user for name and favorite topic
- Starts chat loop via StartChat()
Memory System
Stores user data:
- userName
- favoriteTopic
- lastTopic
Used for greetings, farewells, and follow-ups.

Emotion Recognition
Recognizes keywords like worried, confused, curious, frustrated.
Replies with empathetic messages based on sentimentResponses dictionary.
Topic Knowledge
Uses topicResponses dictionary with multiple randomized messages for topics:
- phishing
- password
- privacy
- scam
- vpn
- 
Conversation Loop
StartChat():
- Prompts user continuously
- Exits on 'bye'
- Responds to 'more' or 'explain'
- Handles emotions and topics
- Asks for rephrasing on unrecognized input
- 
Random Response System
SendRandomResponse(topic):
- Picks a random message from the topic list using rand.Next().
- 
Typing Simulation
SimulateTyping(message, delay = 30):
- Prints characters one by one with delay to simulate typing.
- 
Audio Playback
PlayVoiceGreeting():
- Plays .wav greeting file.
- Displays error if file is missing.
- 
ASCII Bot
DisplayAsciiArt():
- Displays ASCII art of a robot.
- 
How to Customize
- Add topics: topicResponses
- Add emotions: sentimentResponses
- Typing speed: change delay in SimulateTyping()
- Update ASCII art or greeting audio path
- 
Example Chat
User: I'm worried about phishing
Bot: It's completely okay to feel that way...
User: Tell me more
Bot: Phishing emails often appear to come from trusted sources...
User: Bye
Bot: Goodbye Alex! Stay safe...
Future Improvements
- Add logging of chats
- GUI version (WinForms/WPF)
- Use APIs like HaveIBeenPwned
- Add voice input
