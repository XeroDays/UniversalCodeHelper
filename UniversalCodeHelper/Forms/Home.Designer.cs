
namespace UniversalCodeHelper.Forms
{
    partial class Home
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
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            btnFlutterClassGenerate = new System.Windows.Forms.Button();
            btnClose = new System.Windows.Forms.Button();
            btnLocalization = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = System.Drawing.Color.Silver;
            label1.Dock = System.Windows.Forms.DockStyle.Top;
            label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(819, 73);
            label1.TabIndex = 0;
            label1.Text = "Universal Code Helper";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label1.MouseDown += onMouseDown;
            label1.MouseMove += onMouseMove;
            label1.MouseUp += onMouseUp;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(13, 133);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(208, 25);
            label2.TabIndex = 1;
            label2.Text = "Flutter Class Generator";
            // 
            // btnFlutterClassGenerate
            // 
            btnFlutterClassGenerate.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
            btnFlutterClassGenerate.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            btnFlutterClassGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnFlutterClassGenerate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            btnFlutterClassGenerate.ForeColor = System.Drawing.Color.Green;
            btnFlutterClassGenerate.Location = new System.Drawing.Point(227, 125);
            btnFlutterClassGenerate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnFlutterClassGenerate.Name = "btnFlutterClassGenerate";
            btnFlutterClassGenerate.Size = new System.Drawing.Size(178, 41);
            btnFlutterClassGenerate.TabIndex = 2;
            btnFlutterClassGenerate.Text = "Generate";
            btnFlutterClassGenerate.UseVisualStyleBackColor = false;
            btnFlutterClassGenerate.Click += btnFlutterClassGenerate_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            btnClose.ForeColor = System.Drawing.Color.Red;
            btnClose.Location = new System.Drawing.Point(775, 16);
            btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(31, 37);
            btnClose.TabIndex = 3;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnLocalization
            // 
            btnLocalization.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
            btnLocalization.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            btnLocalization.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLocalization.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            btnLocalization.ForeColor = System.Drawing.Color.Green;
            btnLocalization.Location = new System.Drawing.Point(227, 175);
            btnLocalization.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnLocalization.Name = "btnLocalization";
            btnLocalization.Size = new System.Drawing.Size(178, 41);
            btnLocalization.TabIndex = 5;
            btnLocalization.Text = "Generate";
            btnLocalization.UseVisualStyleBackColor = false;
            btnLocalization.Click += btnLocalization_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(33, 183);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(176, 25);
            label3.TabIndex = 4;
            label3.Text = "Localization Helper";
            // 
            // Home
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            ClientSize = new System.Drawing.Size(819, 460);
            Controls.Add(btnLocalization);
            Controls.Add(label3);
            Controls.Add(btnClose);
            Controls.Add(btnFlutterClassGenerate);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "Home";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Home";
            MouseDown += onMouseDown;
            MouseMove += onMouseMove;
            MouseUp += onMouseUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFlutterClassGenerate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnLocalization;
        private System.Windows.Forms.Label label3;
    }
}