namespace FerdiProj1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            button1 = new Button();
            progressBar1 = new ProgressBar();
            progressBar2 = new ProgressBar();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            pictureBox3 = new PictureBox();
            progressBar3 = new ProgressBar();
            progressBar4 = new ProgressBar();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._980dc67df49074c5efe8fb7e81534105_removebg_preview;
            pictureBox1.Location = new Point(99, 234);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(222, 280);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(566, 427);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "Attack";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(327, 361);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(125, 29);
            progressBar1.TabIndex = 3;
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(399, 100);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(125, 29);
            progressBar2.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(358, 317);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(439, 55);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(576, 375);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 7;
            label3.Text = "Player turn";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = Properties.Resources._36e60313ea50d1b04317d367c7647022_removebg_preview;
            pictureBox2.Location = new Point(566, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(134, 304);
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(338, 234);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 9;
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(338, 196);
            label5.Name = "label5";
            label5.Size = new Size(0, 20);
            label5.TabIndex = 10;
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ActiveCaptionText;
            label6.Location = new Point(12, 100);
            label6.Name = "label6";
            label6.Size = new Size(0, 31);
            label6.TabIndex = 11;
            label6.Click += label6_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(-9, -128);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(945, 660);
            pictureBox3.TabIndex = 12;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // progressBar3
            // 
            progressBar3.Location = new Point(327, 398);
            progressBar3.Name = "progressBar3";
            progressBar3.Size = new Size(125, 11);
            progressBar3.TabIndex = 13;
            progressBar3.Click += progressBar3_Click;
            // 
            // progressBar4
            // 
            progressBar4.Location = new Point(399, 135);
            progressBar4.Name = "progressBar4";
            progressBar4.Size = new Size(125, 11);
            progressBar4.TabIndex = 14;
            progressBar4.Click += progressBar4_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(524, 398);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(181, 28);
            comboBox1.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(852, 544);
            Controls.Add(comboBox1);
            Controls.Add(progressBar4);
            Controls.Add(progressBar3);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(pictureBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(progressBar2);
            Controls.Add(progressBar1);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox3);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private ProgressBar progressBar1;
        private ProgressBar progressBar2;
        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox2;
        private Label label4;
        private Label label5;
        private Label label6;
        private PictureBox pictureBox3;
        private ProgressBar progressBar3;
        private ProgressBar progressBar4;
        private ComboBox comboBox1;
    }
}
