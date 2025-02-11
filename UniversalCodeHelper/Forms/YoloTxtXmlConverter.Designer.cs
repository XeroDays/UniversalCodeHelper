namespace UniversalCodeHelper.Forms
{
    partial class YoloTxtXmlConverter
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
            txtLabelsBrowse = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            btnBrowseLabels = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            btnStart = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            lblTotalFiles = new System.Windows.Forms.Label();
            btnBrowseImages = new System.Windows.Forms.Button();
            label4 = new System.Windows.Forms.Label();
            txtImageBrowse = new System.Windows.Forms.TextBox();
            lblTotalImages = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // txtLabelsBrowse
            // 
            txtLabelsBrowse.Location = new System.Drawing.Point(21, 91);
            txtLabelsBrowse.Name = "txtLabelsBrowse";
            txtLabelsBrowse.Size = new System.Drawing.Size(413, 23);
            txtLabelsBrowse.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(21, 73);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(179, 15);
            label1.TabIndex = 1;
            label1.Text = "Browse labels folder with txt files";
            // 
            // btnBrowseLabels
            // 
            btnBrowseLabels.Location = new System.Drawing.Point(440, 91);
            btnBrowseLabels.Name = "btnBrowseLabels";
            btnBrowseLabels.Size = new System.Drawing.Size(75, 23);
            btnBrowseLabels.TabIndex = 2;
            btnBrowseLabels.Text = "browse";
            btnBrowseLabels.UseVisualStyleBackColor = true;
            btnBrowseLabels.Click += btnBrowseFolder_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(106, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(328, 32);
            label2.TabIndex = 3;
            label2.Text = "Yolo txt file to XML Converter";
            // 
            // btnStart
            // 
            btnStart.Location = new System.Drawing.Point(21, 237);
            btnStart.Name = "btnStart";
            btnStart.Size = new System.Drawing.Size(75, 23);
            btnStart.TabIndex = 4;
            btnStart.Text = "Start Process";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(19, 173);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(86, 17);
            label3.TabIndex = 5;
            label3.Text = "Information:";
            // 
            // lblTotalFiles
            // 
            lblTotalFiles.AutoSize = true;
            lblTotalFiles.Location = new System.Drawing.Point(19, 196);
            lblTotalFiles.Name = "lblTotalFiles";
            lblTotalFiles.Size = new System.Drawing.Size(82, 15);
            lblTotalFiles.TabIndex = 6;
            lblTotalFiles.Text = "Total txt files : ";
            // 
            // btnBrowseImages
            // 
            btnBrowseImages.Location = new System.Drawing.Point(440, 138);
            btnBrowseImages.Name = "btnBrowseImages";
            btnBrowseImages.Size = new System.Drawing.Size(75, 23);
            btnBrowseImages.TabIndex = 9;
            btnBrowseImages.Text = "browse";
            btnBrowseImages.UseVisualStyleBackColor = true;
            btnBrowseImages.Click += btnBrowseImages_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(21, 120);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(198, 15);
            label4.TabIndex = 8;
            label4.Text = "Browse labels folder with image files";
            // 
            // txtImageBrowse
            // 
            txtImageBrowse.Location = new System.Drawing.Point(21, 138);
            txtImageBrowse.Name = "txtImageBrowse";
            txtImageBrowse.Size = new System.Drawing.Size(413, 23);
            txtImageBrowse.TabIndex = 7;
            // 
            // lblTotalImages
            // 
            lblTotalImages.AutoSize = true;
            lblTotalImages.Location = new System.Drawing.Point(19, 211);
            lblTotalImages.Name = "lblTotalImages";
            lblTotalImages.Size = new System.Drawing.Size(106, 15);
            lblTotalImages.TabIndex = 10;
            lblTotalImages.Text = "Total images files : ";
            // 
            // YoloTxtXmlConverter
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(532, 280);
            Controls.Add(lblTotalImages);
            Controls.Add(btnBrowseImages);
            Controls.Add(label4);
            Controls.Add(txtImageBrowse);
            Controls.Add(lblTotalFiles);
            Controls.Add(label3);
            Controls.Add(btnStart);
            Controls.Add(label2);
            Controls.Add(btnBrowseLabels);
            Controls.Add(label1);
            Controls.Add(txtLabelsBrowse);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Name = "YoloTxtXmlConverter";
            Text = "YoloTxtXmlConverter";
            Load += YoloTxtXmlConverter_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtLabelsBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowseLabels;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalFiles;
        private System.Windows.Forms.Button btnBrowseImages;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtImageBrowse;
        private System.Windows.Forms.Label lblTotalImages;
    }
}