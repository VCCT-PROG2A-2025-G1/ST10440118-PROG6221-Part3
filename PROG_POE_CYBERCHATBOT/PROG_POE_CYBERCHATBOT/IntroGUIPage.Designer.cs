namespace PROG_POE_CYBERCHATBOT
{
    partial class IntroGUIPage
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
            this.lblWelcomeText = new System.Windows.Forms.Label();
            this.lblWelcomeTxt2 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblWelcomeText
            // 
            this.lblWelcomeText.AutoSize = true;
            this.lblWelcomeText.Font = new System.Drawing.Font("Lucida Sans Typewriter", 25.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeText.ForeColor = System.Drawing.Color.Lavender;
            this.lblWelcomeText.Location = new System.Drawing.Point(446, 39);
            this.lblWelcomeText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcomeText.Name = "lblWelcomeText";
            this.lblWelcomeText.Size = new System.Drawing.Size(507, 88);
            this.lblWelcomeText.TabIndex = 0;
            this.lblWelcomeText.Text = "WELCOME TO";
            this.lblWelcomeText.Click += new System.EventHandler(this.lblWelcomeText_Click);
            // 
            // lblWelcomeTxt2
            // 
            this.lblWelcomeTxt2.AutoSize = true;
            this.lblWelcomeTxt2.Font = new System.Drawing.Font("Lucida Sans Typewriter", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeTxt2.ForeColor = System.Drawing.Color.Lavender;
            this.lblWelcomeTxt2.Location = new System.Drawing.Point(635, 161);
            this.lblWelcomeTxt2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcomeTxt2.Name = "lblWelcomeTxt2";
            this.lblWelcomeTxt2.Size = new System.Drawing.Size(152, 76);
            this.lblWelcomeTxt2.TabIndex = 1;
            this.lblWelcomeTxt2.Text = "THE";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Lucida Sans Typewriter", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Lavender;
            this.lblName.Location = new System.Drawing.Point(348, 400);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(678, 164);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "CHATBOT";
            this.lblName.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Lucida Sans Typewriter", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.ForeColor = System.Drawing.Color.Lavender;
            this.lblDesc.Location = new System.Drawing.Point(403, 588);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(641, 204);
            this.lblDesc.TabIndex = 3;
            this.lblDesc.Text = "Are you ready to \r\nlearn all about \r\ncybersecurity?";
            this.lblDesc.Click += new System.EventHandler(this.lblDesc_Click);
            // 
            // btnYes
            // 
            this.btnYes.Font = new System.Drawing.Font("Lucida Sans Typewriter", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.ForeColor = System.Drawing.Color.Indigo;
            this.btnYes.Location = new System.Drawing.Point(352, 833);
            this.btnYes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(692, 166);
            this.btnYes.TabIndex = 4;
            this.btnYes.Text = "YES";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Typewriter", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lavender;
            this.label1.Location = new System.Drawing.Point(99, 236);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1200, 164);
            this.label1.TabIndex = 5;
            this.label1.Text = "CYBERSECURITY";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // IntroGUIPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(1382, 1233);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblWelcomeTxt2);
            this.Controls.Add(this.lblWelcomeText);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "IntroGUIPage";
            this.Text = "IntroGUIPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcomeText;
        private System.Windows.Forms.Label lblWelcomeTxt2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Label label1;
    }
}