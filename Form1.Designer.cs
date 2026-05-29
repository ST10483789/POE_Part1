namespace POE_Part2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            IblTitle = new Label();
            rtbChat = new RichTextBox();
            txtUserInput = new TextBox();
            btnSend = new Button();
            btnExit = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // IblTitle
            // 
            IblTitle.AutoSize = true;
            IblTitle.ForeColor = Color.LimeGreen;
            IblTitle.Location = new Point(407, 9);
            IblTitle.Name = "IblTitle";
            IblTitle.Size = new Size(184, 20);
            IblTitle.TabIndex = 0;
            IblTitle.Text = "CYBERSECURITY CHATBOT";
            // 
            // rtbChat
            // 
            rtbChat.BackColor = Color.Black;
            rtbChat.ForeColor = Color.White;
            rtbChat.Location = new Point(149, 211);
            rtbChat.Name = "rtbChat";
            rtbChat.ReadOnly = true;
            rtbChat.Size = new Size(700, 300);
            rtbChat.TabIndex = 1;
            rtbChat.Text = "";
            // 
            // txtUserInput
            // 
            txtUserInput.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUserInput.Location = new Point(196, 537);
            txtUserInput.Name = "txtUserInput";
            txtUserInput.Size = new Size(550, 31);
            txtUserInput.TabIndex = 2;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.Lime;
            btnSend.Font = new Font("Consolas", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSend.Location = new Point(407, 587);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(120, 40);
            btnSend.TabIndex = 3;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Red;
            btnExit.Location = new Point(407, 651);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(120, 40);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(309, 44);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(373, 161);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1064, 720);
            Controls.Add(pictureBox1);
            Controls.Add(btnExit);
            Controls.Add(btnSend);
            Controls.Add(txtUserInput);
            Controls.Add(rtbChat);
            Controls.Add(IblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = ";.n ";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label IblTitle;
        private RichTextBox rtbChat;
        private TextBox txtUserInput;
        private Button btnSend;
        private Button btnExit;
        private PictureBox pictureBox1;
    }
}
