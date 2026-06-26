 using System.Collections.Generic;
using System.Windows.Forms;

namespace POE_Part2
{
    public partial class Form1 : Form
    {
        string userName = "";
        string favoriteTopic = "";

        Random random = new Random();

        List<TaskItem> tasks = new List<TaskItem>();

        List<string> activityLog = new List<string>();

        List<QuizQuestion> quizQuestions = new List<QuizQuestion>();

        bool quizMode = false;

        int currentQuestion = 0;

        int quizScore = 0;

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
            LoadQuizQuestions();

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
            // NLP - Reminder Requests
            if (input.Contains("remind me") ||
                input.Contains("set reminder") ||
                input.Contains("remember to"))
            {
                return "I can help you remember that! Add it as a task with a reminder date using the Task Assistant.";
            }
            // NLP - Task Requests
            if (input.Contains("add task") ||
                input.Contains("create task") ||
                input.Contains("new task"))
            {
                return "Use the Task Assistant on the right to create your cybersecurity task.";
            }
            // NLP - Password Requests
            if (input.Contains("change password") ||
                input.Contains("update password") ||
                input.Contains("new password"))
            {
                return "Remember to use a strong password with uppercase, lowercase, numbers and symbols.";
            }
            if (input.Contains("show activity") ||
           input.Contains("activity log") ||
           input.Contains("what have you done"))
            {
                if (activityLog.Count == 0)
                    return "No recent activity.";

                return "Recent Activity:\n\n" +
                       string.Join("\n", activityLog);
            }
            // START QUIZ
            if (input.Contains("start quiz") ||
             input.Contains("quiz") ||
             input.Contains("play quiz") ||
             input.Contains("test me") ||
             input.Contains("ask me questions") ||
             input.Contains("quiz time"))
            {
                quizMode = true;
                activityLog.Add("Quiz started");
                currentQuestion = 0;
                quizScore = 0;

                QuizQuestion q = quizQuestions[currentQuestion];

                return "🎮 Cybersecurity Quiz Started!\n\n" +
                       "Question 1:\n" +
                       q.Question + "\n\n" +
                       string.Join("\n", q.Options) +
                       "\n\nType A, B, C or D.";
            }
            // QUIZ MODE
            if (quizMode)
            {
                QuizQuestion q = quizQuestions[currentQuestion];

                if (input.ToUpper() == q.CorrectAnswer)
                {
                    quizScore++;

                    string reply = "✅ Correct!\n" + q.Explanation + "\n\n";

                    currentQuestion++;

                    if (currentQuestion >= quizQuestions.Count)
                    {
                        quizMode = false;
                        activityLog.Add("Quiz completed. Score: " + quizScore + "/" + quizQuestions.Count);

                        reply += "🎉 Quiz Finished!\n";
                        reply += "\n\nYour Score: " + quizScore + "/" + quizQuestions.Count + "\n\n";

                        if (quizScore >= 9)
                        {
                            reply += "🏆 Excellent! You're a cybersecurity pro!";
                        }
                        else if (quizScore >= 7)
                        {
                            reply += "😊 Great job! You have strong cybersecurity knowledge.";
                        }
                        else if (quizScore >= 5)
                        {
                            reply += "👍 Good effort! Keep learning to stay safe online.";
                        }
                        else
                        {
                            reply += "📚 Keep practising. Cybersecurity is an important skill!";
                        }

                        return reply;
                    }

                    QuizQuestion next = quizQuestions[currentQuestion];

                    reply += "\nQuestion " + (currentQuestion + 1) + ":\n";
                    reply += next.Question + "\n\n";
                    reply += string.Join("\n", next.Options);
                    reply += "\n\nType A, B, C or D.";

                    return reply;
                }
                else
                {
                    string reply = "❌ Incorrect.\n";
                    reply += q.Explanation + "\n\n";

                    currentQuestion++;

                    if (currentQuestion >= quizQuestions.Count)
                    {
                        quizMode = false;
                        activityLog.Add("Quiz completed. Score: " + quizScore + "/" + quizQuestions.Count);

                        reply += "🎉 Quiz Finished!\n";
                        reply += "Your Score: " + quizScore + "/" + quizQuestions.Count;

                        return reply;
                    }

                    QuizQuestion next = quizQuestions[currentQuestion];

                    reply += "\nQuestion " + (currentQuestion + 1) + ":\n";
                    reply += next.Question + "\n\n";
                    reply += string.Join("\n", next.Options);
                    reply += "\n\nType A, B, C or D.";

                    return reply;
                }
            }

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtTaskTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaskTitle.Text))
            {
                MessageBox.Show("Please enter a task title.");
                return;
            }

            TaskItem task = new TaskItem();

            task.Title = txtTaskTitle.Text;
            task.Description = txtTaskDescription.Text;
            task.ReminderDate = dtpReminder.Value;
            task.Completed = false;

            tasks.Add(task);

            lstTasks.Items.Add(task);

            activityLog.Add("Task added: " + task.Title);

            MessageBox.Show("Task added successfully!");

            txtTaskTitle.Clear();
            txtTaskDescription.Clear();
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a task to delete.");
                return;
            }

            activityLog.Add("Task deleted: " + tasks[lstTasks.SelectedIndex].Title);

            tasks.RemoveAt(lstTasks.SelectedIndex);
            lstTasks.Items.RemoveAt(lstTasks.SelectedIndex);

            MessageBox.Show("Task deleted.");
        }

        private void btnCompleteTask_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a task.");
                return;
            }

            tasks[lstTasks.SelectedIndex].Completed = true;

            lstTasks.Items[lstTasks.SelectedIndex] = tasks[lstTasks.SelectedIndex];

            activityLog.Add("Task completed: " + tasks[lstTasks.SelectedIndex].Title);

            MessageBox.Show("Task marked as completed.");
        }
        private void LoadQuizQuestions()
        {
            quizQuestions.Add(new QuizQuestion
            {
                Question = "What should you do if you receive an email asking for your password?",
                Options = new string[]
                {
            "A. Reply with your password",
            "B. Delete the email",
            "C. Report it as phishing",
            "D. Ignore it"
                },
                CorrectAnswer = "C",
                Explanation = "Reporting phishing emails helps prevent scams."
            });

            quizQuestions.Add(new QuizQuestion
            {
                Question = "True or False: You should use the same password for every account.",
                Options = new string[]
                {
            "A. True",
            "B. False"
                },
                CorrectAnswer = "B",
                Explanation = "Using unique passwords makes your accounts more secure."
            });
            quizQuestions.Add(new QuizQuestion
            {
                Question = "Which of these is the strongest password?",
                Options = new string[]
    {
        "A. password123",
        "B. John123",
        "C. P@55w0rd!",
        "D. 123456"
    },
                CorrectAnswer = "C",
                Explanation = "Strong passwords contain uppercase, lowercase, numbers and symbols."
            });

            quizQuestions.Add(new QuizQuestion
            {
                Question = "True or False: Antivirus software should be updated regularly.",
                Options = new string[]
                {
        "A. True",
        "B. False"
                },
                CorrectAnswer = "A",
                Explanation = "Updated antivirus software protects against the latest threats."
            });

            quizQuestions.Add(new QuizQuestion
            {
                Question = "What is phishing?",
                Options = new string[]
                {
        "A. A type of fishing",
        "B. A scam to steal personal information",
        "C. A firewall",
        "D. A password manager"
                },
                CorrectAnswer = "B",
                Explanation = "Phishing tricks people into giving away sensitive information."
            });

            quizQuestions.Add(new QuizQuestion
            {
                Question = "True or False: Public Wi-Fi is always safe.",
                Options = new string[]
                {
        "A. True",
        "B. False"
                },
                CorrectAnswer = "B",
                Explanation = "Public Wi-Fi can expose your personal information."
            });

            quizQuestions.Add(new QuizQuestion
            {
                Question = "What does VPN stand for?",
                Options = new string[]
                {
        "A. Virtual Private Network",
        "B. Verified Personal Network",
        "C. Virtual Password Number",
        "D. Visual Protection Node"
                },
                CorrectAnswer = "A",
                Explanation = "A VPN encrypts your internet connection."
            });

            quizQuestions.Add(new QuizQuestion
            {
                Question = "Which is an example of malware?",
                Options = new string[]
                {
        "A. Trojan",
        "B. Word document",
        "C. Calculator",
        "D. Keyboard"
                },
                CorrectAnswer = "A",
                Explanation = "A Trojan is a common type of malware."
            });

            quizQuestions.Add(new QuizQuestion
            {
                Question = "True or False: Software updates improve security.",
                Options = new string[]
                {
        "A. True",
        "B. False"
                },
                CorrectAnswer = "A",
                Explanation = "Updates often fix security vulnerabilities."
            });

            quizQuestions.Add(new QuizQuestion
            {
                Question = "What should you do before clicking a link in an email?",
                Options = new string[]
                {
        "A. Click immediately",
        "B. Check who sent it",
        "C. Forward it",
        "D. Ignore every email"
                },
                CorrectAnswer = "B",
                Explanation = "Always verify the sender before clicking links."
            });
        }
    }

}

