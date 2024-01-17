namespace FileReaderApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            progressBar1 = new ProgressBar();
            btnFinish = new Button();
            btnCancel = new Button();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(165, 333);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(477, 23);
            progressBar1.TabIndex = 0;
            // 
            // btnFinish
            // 
            btnFinish.Location = new Point(710, 420);
            btnFinish.Name = "btnFinish";
            btnFinish.Size = new Size(78, 23);
            btnFinish.TabIndex = 1;
            btnFinish.Text = "Завершити";
            btnFinish.UseVisualStyleBackColor = true;
            btnFinish.Click += btnFinish_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(629, 420);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(71, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Скасувати";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(307, 269);
            label1.Name = "label1";
            label1.Size = new Size(0, 32);
            label1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(364, 384);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnFinish);
            Controls.Add(progressBar1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBar1;
        private Button btnFinish;
        private Button btnCancel;
        private Label label1;
        private Button button1;
    }
}
