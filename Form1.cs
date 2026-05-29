using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace POE_Part2
{
    public partial class Form1 : Form
    {
        string userName = "";
        string favoriteTopic = "";

        Random random = new Random();

        Dictionary<string, string[]> responses =
    new Dictionary<string, string[]>()
{
    {
        "privacy",
        new string[]
        {
            "Always review your privacy settings on social media.",
            "Do not share personal information publicly online.",
            "Use strong passwords to protect your private accounts."
        }
    },

    {
        "scam",
        new string[]
        {
            "Be careful of online offers that seem too good to be true.",
            "Scammers often create urgency to trick victims.",
            "Never send money to unknown people online."
        }
    },

    {
        "vpn",
        new string[]
        {
            "A VPN helps protect your online privacy.",
            "VPNs encrypt your internet connection.",
            "Using a VPN on public Wi-Fi improves security."
        }
    },

    {
        "password",
        new string[]
        {
            "Use strong passwords with symbols and numbers.",
            "Avoid using your birthday as a password.",
            "Enable two-factor authentication for better security."
        }
    },

    {
        "phishing",
        new string[]
        {
            "Do not click suspicious links.",
            "Check the sender's email carefully.",
            "Phishing emails often create fake urgency."
        }
    },

    {
        "malware",
        new string[]
        {
            "Install trusted antivirus software.",
            "Keep your system updated.",
            "Avoid downloading unknown files."
        }
    }
};

        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.KeyPreview = true;

            rtbChat.AppendText("======================================" + Environment.NewLine);
            rtbChat.AppendText(" CYBERSECURITY AI ASSISTANT " + Environment.NewLine);
            rtbChat.AppendText("======================================" + Environment.NewLine);

            rtbChat.AppendText("Initializing secure connection..." + Environment.NewLine);
            rtbChat.AppendText("Loading cybersecurity modules..." + Environment.NewLine);
            rtbChat.AppendText("Scanning threats..." + Environment.NewLine);
            rtbChat.AppendText("System secured successfully!" + Environment.NewLine);

            rtbChat.AppendText(Environment.NewLine);

            rtbChat.AppendText("Bot: Welcome! Ask me about cybersecurity." + Environment.NewLine);

            rtbChat.AppendText(Environment.NewLine);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string userInput = txtUserInput.Text;

            // ERROR HANDLING
            if (string.IsNullOrWhiteSpace(userInput))
            {
                MessageBox.Show("Please enter a message.");
                return;
            }

            // SHOW USER MESSAGE
            rtbChat.AppendText("[" + DateTime.Now.ToShortTimeString() + "] You: " + userInput + Environment.NewLine);

            // GET BOT RESPONSE
            string botReply = GetBotResponse(userInput);

            // SHOW BOT RESPONSE
            rtbChat.AppendText("[" + DateTime.Now.ToShortTimeString() + "] Bot: " + botReply + Environment.NewLine);

            rtbChat.AppendText(Environment.NewLine);

            // CLEAR TEXTBOX
            txtUserInput.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public string GetBotResponse(string input)
        {
            input = input.ToLower();

            // MEMORY
            if (input.Contains("my name is"))
            {
                userName = input.Replace("my name is", "").Trim();

                return "Nice to meet you, " + userName + "!";
            }

            if (input.Contains("i like"))
            {
                favoriteTopic = input.Replace("i like", "").Trim();

                return "Great! I will remember that you like " + favoriteTopic + ".";
            }

            // SENTIMENT DETECTION
            if (input.Contains("worried"))
            {
                return "It's understandable to feel worried. Cybersecurity threats can seem scary.";
            }

            if (input.Contains("frustrated"))
            {
                return "I understand your frustration. Cybersecurity can be confusing at first.";
            }

            // RANDOM RESPONSES
            foreach (var topic in responses)
            {
                if (input.Contains(topic.Key))
                {
                    int index = random.Next(topic.Value.Length);

                    return topic.Value[index];
                }
            }

            // MEMORY RECALL
            if (favoriteTopic != "")
            {
                return "Since you like " + favoriteTopic + ", remember to stay safe online.";
            }

            // DEFAULT RESPONSE
            return "I did not understand that. Try asking about passwords, phishing, or malware.";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend.PerformClick();
            }
        }
    }

}

