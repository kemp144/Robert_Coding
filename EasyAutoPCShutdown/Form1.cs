using System.Diagnostics;
using System.Windows.Forms;
using System;

namespace EasyAutoPCPowerSwitch
{
    public partial class Form1 : Form
    {
        private Timer countdownTimer = new Timer();
        private TimeSpan timeRemaining;
        private char selectedAction; // Variable to store the selected action

        public Form1()
        {
            InitializeComponent();

            // Set the timer to tick every second
            countdownTimer.Interval = 1000;
            // Hook up the Tick event
            countdownTimer.Tick += new EventHandler(countdownTimer_Tick);

            selectedAction = EasyAutoPCPowerSwitch.Properties.Settings.Default.LastSelectedAction;

            // If no action has been selected, default to 's' (Shut Down)
            if (selectedAction != 's' && selectedAction != 'h')
            {
                selectedAction = 's';
            }
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
                EasyAutoPCPowerSwitch.Properties.Settings.Default.LastMinutesValue = minutes;
                EasyAutoPCPowerSwitch.Properties.Settings.Default.Save();
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

            if (timeRemaining == TimeSpan.FromMinutes(1) && ShowWarning.Checked)
            {
                // Ensure the form is visible and on top
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal; // Restore the window
                }
                this.BringToFront(); // Bring the form to the front
                this.TopMost = true; // Make the form topmost momentarily

                // Display a warning message to the user
                DialogResult result = MessageBox.Show("System will hibernate in 1 minute. Do you want to cancel hibernation?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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
                // Perform the shutdown or hibernation
                TakeAction(selectedAction);
                // Exit the app
                Application.Exit();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Stop the timer
            countdownTimer.Enabled = false;
            // Optionally notify the user
            MessageBox.Show(this, "Task canceled!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void TakeAction(char action)
        {
            string command = (action == 's') ? "/s /t 0" : "/h";
            Process.Start("shutdown", command);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load the last minutes value from application settings and set it in the textbox
            textBox_Minutes.Text = EasyAutoPCPowerSwitch.Properties.Settings.Default.LastMinutesValue.ToString();

            // Load the last selected action from application settings and set it in the ComboBox
            switch (selectedAction)
            {
                case 's':
                    comboBox1.SelectedItem = "Shut Down";
                    break;
                case 'h':
                    comboBox1.SelectedItem = "Hibernate";
                    break;
                default:
                    break;
            }

            // Center the form on the screen
            CenterFormOnScreen();
        }

        private void CenterFormOnScreen()
        {
            // Calculate the center position of the screen
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            int formWidth = this.Width;
            int formHeight = this.Height;
            int centerX = (screenWidth - formWidth) / 2;
            int centerY = (screenHeight - formHeight) / 2;

            // Set the form's location to the center position
            this.Location = new System.Drawing.Point(centerX, centerY);
        }

        private void PictureBoxDonate_Click(object sender, EventArgs e)
        {
            // Open the PayPal donation link in the default web browser
            Process.Start($"https://www.paypal.com/paypalme/engelrobert");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = comboBox1.SelectedItem.ToString();

            // Store the selected action
            switch (selectedOption)
            {
                case "Shut Down":
                    selectedAction = 's'; // Shutdown
                    break;
                case "Hibernate":
                    selectedAction = 'h'; // Hibernate
                    break;
                default:
                    break;
            }
        }

        // Override the OnFormClosing event to save settings before closing the form
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // Save the last selected action to application settings
            EasyAutoPCPowerSwitch.Properties.Settings.Default.LastSelectedAction = selectedAction;
            EasyAutoPCPowerSwitch.Properties.Settings.Default.Save();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
