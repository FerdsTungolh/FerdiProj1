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
            pictureBox1 = new PictureBox();
            button1 = new Button();
            progressBar1 = new ProgressBar();
            progressBar2 = new ProgressBar();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            label4 = new Label();
            label6 = new Label();
            progressBar3 = new ProgressBar();
            progressBar4 = new ProgressBar();
            comboBox1 = new ComboBox();
            chp1 = new Label();
            chp2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._980dc67df49074c5efe8fb7e81534105_removebg_preview;
            pictureBox1.Location = new Point(29, 237);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(226, 369);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(306, 544);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "Attack";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(282, 403);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(150, 33);
            progressBar1.TabIndex = 3;
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(623, 104);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(125, 29);
            progressBar2.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(319, 377);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(641, 72);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(464, 321);
            label3.Name = "label3";
            label3.Size = new Size(98, 20);
            label3.TabIndex = 7;
            label3.Text = "Naruto's turn ";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = Properties.Resources._36e60313ea50d1b04317d367c7647022_removebg_preview;
            pictureBox2.Location = new Point(754, 15);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(167, 383);
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(432, 267);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ActiveCaptionText;
            label6.Location = new Point(14, 57);
            label6.Name = "label6";
            label6.Size = new Size(0, 31);
            label6.TabIndex = 11;
            // 
            // progressBar3
            // 
            progressBar3.BackColor = SystemColors.ActiveCaption;
            progressBar3.ForeColor = SystemColors.ActiveCaption;
            progressBar3.Location = new Point(282, 456);
            progressBar3.Name = "progressBar3";
            progressBar3.Size = new Size(150, 11);
            progressBar3.TabIndex = 13;
            // 
            // progressBar4
            // 
            progressBar4.Location = new Point(623, 153);
            progressBar4.Name = "progressBar4";
            progressBar4.Size = new Size(125, 11);
            progressBar4.TabIndex = 14;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(266, 484);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(247, 28);
            comboBox1.TabIndex = 15;
            // 
            // chp1
            // 
            chp1.AutoSize = true;
            chp1.BackColor = Color.Transparent;
            chp1.Location = new Point(282, 436);
            chp1.Name = "chp1";
            chp1.Size = new Size(61, 20);
            chp1.TabIndex = 16;
            chp1.Text = "Chakra :";
            // 
            // chp2
            // 
            chp2.AutoSize = true;
            chp2.BackColor = Color.Transparent;
            chp2.Location = new Point(623, 133);
            chp2.Name = "chp2";
            chp2.Size = new Size(61, 20);
            chp2.TabIndex = 18;
            chp2.Text = "Chakra :";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(921, 625);
            Controls.Add(chp2);
            Controls.Add(chp1);
            Controls.Add(comboBox1);
            Controls.Add(progressBar4);
            Controls.Add(progressBar3);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(pictureBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(progressBar2);
            Controls.Add(progressBar1);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
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
        private Label label6;
        private ProgressBar progressBar3;
        private ProgressBar progressBar4;
        private ComboBox comboBox1;
        private Label chp1;
        private Label chp2;
    }
}
