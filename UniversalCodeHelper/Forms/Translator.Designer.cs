namespace UniversalCodeHelper.Forms
{
    partial class Translator
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
            txtFrom = new System.Windows.Forms.TextBox();
            btnLocalization = new System.Windows.Forms.Button();
            txtLanguageCode = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // txtFrom
            // 
            txtFrom.Location = new System.Drawing.Point(11, 31);
            txtFrom.Multiline = true;
            txtFrom.Name = "txtFrom";
            txtFrom.Size = new System.Drawing.Size(613, 558);
            txtFrom.TabIndex = 0;
            txtFrom.Text = "[\r\n  {\r\n    \"en\": \"Please enter your first name\",\r\n    \"th\": \"Please enter your first name\"\r\n  },\r\n  {\r\n    \"en\": \"Please enter your last name\",\r\n    \"th\": \"Please enter your first name\"\r\n  }\r\n]";
            // 
            // btnLocalization
            // 
            btnLocalization.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
            btnLocalization.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            btnLocalization.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLocalization.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnLocalization.ForeColor = System.Drawing.Color.Green;
            btnLocalization.Location = new System.Drawing.Point(631, 79);
            btnLocalization.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnLocalization.Name = "btnLocalization";
            btnLocalization.Size = new System.Drawing.Size(169, 41);
            btnLocalization.TabIndex = 6;
            btnLocalization.Text = "Generate";
            btnLocalization.UseVisualStyleBackColor = false;
            btnLocalization.Click += btnLocalization_Click;
            // 
            // txtLanguageCode
            // 
            txtLanguageCode.Location = new System.Drawing.Point(631, 45);
            txtLanguageCode.Name = "txtLanguageCode";
            txtLanguageCode.Size = new System.Drawing.Size(125, 27);
            txtLanguageCode.TabIndex = 7;
            txtLanguageCode.Text = "en";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(630, 21);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(195, 20);
            label1.TabIndex = 8;
            label1.Text = "Locale Lang (Key Language)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(175, 20);
            label2.TabIndex = 9;
            label2.Text = "Json Sample (Paste Here)";
            // 
            // Translator
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(833, 598);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtLanguageCode);
            Controls.Add(btnLocalization);
            Controls.Add(txtFrom);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "Translator";
            Text = "Translator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Button btnLocalization;
        private System.Windows.Forms.TextBox txtLanguageCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}