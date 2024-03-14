using System.Diagnostics;
using System.Windows.Forms;
using System;

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
                // Save the last minutes value to application settings
                WindowsFormsApp2.Properties.Settings.Default.LastMinutesValue = minutes;
                WindowsFormsApp2.Properties.Settings.Default.Save();
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

            if (timeRemaining == TimeSpan.FromMinutes(5) && ShowWarning.Checked)
            {
                // Ensure the form is visible and on top
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal; // Restore the window
                }
                this.BringToFront(); // Bring the form to the front
                this.TopMost = true; // Make the form topmost momentarily

                // Display a warning message to the user
                DialogResult result = MessageBox.Show("System will hibernate in 5 minutes. Do you want to cancel hibernation?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                this.TopMost = false; // Revert the topmost status after the dialog is closed

                if (result == DialogResult.Yes)
                {
                    // Cancel hibernation
                    btnCancel_Click(sender, e);
                }
            }

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
                HibernateComputer();
            }
        }




        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Stop the timer
            countdownTimer.Enabled = false;
            // Optionally notify the user
            MessageBox.Show(this, "Hibernation canceled!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Append diagnostic message to RichTextBox
            AppendToOutput("Hibernation canceled.");

            // Reset the timer if cancellation occurs within the 5-minute window
            if (timeRemaining <= TimeSpan.FromMinutes(5) && timeRemaining > TimeSpan.Zero)
            {
                int minutes;
                if (int.TryParse(textBox_Minutes.Text, out minutes))
                {
                    // Initialize the remaining time span
                    timeRemaining = TimeSpan.FromMinutes(minutes);
                    // Update the label
                    label_Countdown.Text = timeRemaining.ToString(@"mm\:ss");
                }
            }
        }

        private void AppendToOutput(string message)
        {
            // Append the message to the RichTextBox
            richTextBox_Output.AppendText(message + Environment.NewLine);
        }

        private void HibernateComputer()
        {
            // Start the hibernation process
            Process.Start("shutdown", "/h");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load the last minutes value from application settings and set it in the textbox
            textBox_Minutes.Text = WindowsFormsApp2.Properties.Settings.Default.LastMinutesValue.ToString();
        }

    }
}
