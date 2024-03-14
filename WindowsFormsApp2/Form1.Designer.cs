namespace WindowsFormsApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Minutes = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label_Countdown = new System.Windows.Forms.Label();
            this.richTextBox_Output = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ShowWarning = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hibernate PC in minutes";
            // 
            // textBox_Minutes
            // 
            this.textBox_Minutes.Location = new System.Drawing.Point(202, 67);
            this.textBox_Minutes.Name = "textBox_Minutes";
            this.textBox_Minutes.Size = new System.Drawing.Size(82, 22);
            this.textBox_Minutes.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(347, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_Countdown
            // 
            this.label_Countdown.AutoSize = true;
            this.label_Countdown.Location = new System.Drawing.Point(624, 73);
            this.label_Countdown.Name = "label_Countdown";
            this.label_Countdown.Size = new System.Drawing.Size(0, 16);
            this.label_Countdown.TabIndex = 3;
            // 
            // richTextBox_Output
            // 
            this.richTextBox_Output.Location = new System.Drawing.Point(38, 214);
            this.richTextBox_Output.Name = "richTextBox_Output";
            this.richTextBox_Output.Size = new System.Drawing.Size(701, 211);
            this.richTextBox_Output.TabIndex = 4;
            this.richTextBox_Output.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(490, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "PC Will Hibernate in:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(347, 103);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 29);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(229, 428);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(311, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Copyright (c) 2024 Robert Engel. All rights reserved.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(277, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Easy Auto PC Shutdown";
            // 
            // ShowWarning
            // 
            this.ShowWarning.AutoSize = true;
            this.ShowWarning.Checked = true;
            this.ShowWarning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowWarning.Location = new System.Drawing.Point(38, 112);
            this.ShowWarning.Name = "ShowWarning";
            this.ShowWarning.Size = new System.Drawing.Size(167, 20);
            this.ShowWarning.TabIndex = 10;
            this.ShowWarning.Text = "Show 5 minute Warning";
            this.ShowWarning.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ShowWarning);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox_Output);
            this.Controls.Add(this.label_Countdown);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_Minutes);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Easy Auto PC Shutdown";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Minutes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_Countdown;
        private System.Windows.Forms.RichTextBox richTextBox_Output;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ShowWarning;
    }
}

