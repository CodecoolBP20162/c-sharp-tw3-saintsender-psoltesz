namespace MailClient
{
    partial class MailClientForm
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
            this.components = new System.ComponentModel.Container();
            this.GetMailTimer = new System.Windows.Forms.Timer(this.components);
            this.saveCredsButton = new System.Windows.Forms.Button();
            this.sendMailButton = new System.Windows.Forms.Button();
            this.deleteCredsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GetMailTimer
            // 
            this.GetMailTimer.Interval = 4000;
            this.GetMailTimer.Tick += new System.EventHandler(this.GetMailTimer_Tick);
            // 
            // saveCredsButton
            // 
            this.saveCredsButton.Location = new System.Drawing.Point(710, 30);
            this.saveCredsButton.Name = "saveCredsButton";
            this.saveCredsButton.Size = new System.Drawing.Size(80, 134);
            this.saveCredsButton.TabIndex = 0;
            this.saveCredsButton.Text = "Save Credentials";
            this.saveCredsButton.UseVisualStyleBackColor = true;
            this.saveCredsButton.Click += new System.EventHandler(this.saveCredsButton_Click);
            // 
            // sendMailButton
            // 
            this.sendMailButton.Location = new System.Drawing.Point(710, 390);
            this.sendMailButton.Name = "sendMailButton";
            this.sendMailButton.Size = new System.Drawing.Size(80, 137);
            this.sendMailButton.TabIndex = 1;
            this.sendMailButton.Text = "Send E-mail";
            this.sendMailButton.UseVisualStyleBackColor = true;
            this.sendMailButton.Click += new System.EventHandler(this.sendMailButton_Click);
            // 
            // deleteCredsButton
            // 
            this.deleteCredsButton.Location = new System.Drawing.Point(710, 210);
            this.deleteCredsButton.Name = "deleteCredsButton";
            this.deleteCredsButton.Size = new System.Drawing.Size(80, 134);
            this.deleteCredsButton.TabIndex = 2;
            this.deleteCredsButton.Text = "Delete Credentials";
            this.deleteCredsButton.UseVisualStyleBackColor = true;
            this.deleteCredsButton.Click += new System.EventHandler(this.deleteCredsButton_Click);
            // 
            // MailClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 561);
            this.Controls.Add(this.deleteCredsButton);
            this.Controls.Add(this.sendMailButton);
            this.Controls.Add(this.saveCredsButton);
            this.Name = "MailClientForm";
            this.Text = "SaintSender";
            this.Load += new System.EventHandler(this.MailClientForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer GetMailTimer;
        private System.Windows.Forms.Button saveCredsButton;
        private System.Windows.Forms.Button sendMailButton;
        private System.Windows.Forms.Button deleteCredsButton;
    }
}

