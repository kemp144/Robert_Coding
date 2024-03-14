using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        private Timer countdownTimer = new Timer();
        private TimeSpan timeRemaining;

        public Form1()
        {
            InitializeComponent();

            // Set the timer to tick every second
            countdownTimer.Interval = 1000;
            // Hook up the Tick event
            countdownTimer.Tick += new EventHandler(countdownTimer_Tick);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Try to parse the minutes entered by the user
            if (int.TryParse(textBox_Minutes.Text, out int minutes))
            {
                // Initialize the remaining time span
                timeRemaining = TimeSpan.FromMinutes(minutes);
                // Update the label
                label_Countdown.Text = timeRemaining.ToString(@"mm\:ss");
                // Enable the timer
                countdownTimer.Enabled = true;
                // Append diagnostic message to RichTextBox
                AppendToOutput("Timer enabled. Remaining time: " + timeRemaining);
            }
            else
            {
                // Show a message if the input is not valid
                MessageBox.Show("Please enter a valid number of minutes.");
            }
        }

        private void countdownTimer_Tick(object sender, EventArgs e)
        {
            // Decrease the remaining time
            timeRemaining = timeRemaining.Subtract(TimeSpan.FromSeconds(1));
            // Update the label
            label_Countdown.Text = timeRemaining.ToString(@"mm\:ss");
            // Append diagnostic message to RichTextBox
            AppendToOutput("Tick event. Remaining time: " + timeRemaining);

            // Check if the countdown has finished
            if (timeRemaining <= TimeSpan.Zero)
            {
                // Stop the timer
                countdownTimer.Enabled = false;
                // Optionally notify the user
                MessageBox.Show("Countdown finished!");
                // Append diagnostic message to RichTextBox
                AppendToOutput("Countdown finished.");
                // Hibernate the computer
                Process.Start("shutdown", "/h");
            }
        }

        private void AppendToOutput(string message)
        {
            // Append the message to the RichTextBox
            richTextBox_Output.AppendText(message + Environment.NewLine);
        }
    }
}
