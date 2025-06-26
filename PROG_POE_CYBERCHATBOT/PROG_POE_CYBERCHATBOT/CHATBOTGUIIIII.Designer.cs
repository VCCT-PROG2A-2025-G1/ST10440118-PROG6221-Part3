namespace PROG_POE_CYBERCHATBOT
{
    partial class CHATBOTGUIIIII
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
            this.btnGo = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAsk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Lucida Sans Typewriter", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.ForeColor = System.Drawing.Color.Indigo;
            this.btnGo.Location = new System.Drawing.Point(327, 681);
            this.btnGo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(814, 102);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "START";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(327, 124);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(814, 379);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(570, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 85);
            this.label1.TabIndex = 4;
            this.label1.Text = "CHATBOT";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(327, 548);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(569, 100);
            this.textBox1.TabIndex = 5;
            // 
            // btnAsk
            // 
            this.btnAsk.Font = new System.Drawing.Font("Lucida Sans Typewriter", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsk.ForeColor = System.Drawing.Color.Indigo;
            this.btnAsk.Location = new System.Drawing.Point(926, 548);
            this.btnAsk.Name = "btnAsk";
            this.btnAsk.Size = new System.Drawing.Size(215, 100);
            this.btnAsk.TabIndex = 6;
            this.btnAsk.Text = "Ask";
            this.btnAsk.UseVisualStyleBackColor = true;
            this.btnAsk.Click += new System.EventHandler(this.btnAsk_Click);
            // 
            // CHATBOTGUIIIII
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(1437, 947);
            this.Controls.Add(this.btnAsk);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnGo);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "CHATBOTGUIIIII";
            this.Text = "CHATBOTGUIIIII";
            this.Load += new System.EventHandler(this.CHATBOTGUIIIII_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAsk;
    }
}