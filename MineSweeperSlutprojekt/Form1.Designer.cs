namespace MineSweeperSlutprojekt
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
            Easy = new RadioButton();
            Medium = new RadioButton();
            Hard = new RadioButton();
            Impossible = new RadioButton();
            Spela = new Button();
            Play = new Button();
            SuspendLayout();
            // 
            // Easy
            // 
            Easy.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Easy.AutoSize = true;
            Easy.Location = new Point(12, 45);
            Easy.Name = "Easy";
            Easy.Size = new Size(48, 19);
            Easy.TabIndex = 0;
            Easy.TabStop = true;
            Easy.Text = "Easy";
            Easy.UseVisualStyleBackColor = true;
            // 
            // Medium
            // 
            Medium.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Medium.AutoSize = true;
            Medium.Location = new Point(190, 45);
            Medium.Name = "Medium";
            Medium.Size = new Size(70, 19);
            Medium.TabIndex = 1;
            Medium.TabStop = true;
            Medium.Text = "Medium";
            Medium.UseVisualStyleBackColor = true;
            Medium.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // Hard
            // 
            Hard.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Hard.AutoSize = true;
            Hard.Location = new Point(12, 113);
            Hard.Name = "Hard";
            Hard.Size = new Size(51, 19);
            Hard.TabIndex = 2;
            Hard.TabStop = true;
            Hard.Text = "Hard";
            Hard.UseVisualStyleBackColor = true;
            // 
            // Impossible
            // 
            Impossible.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Impossible.AutoSize = true;
            Impossible.Location = new Point(190, 113);
            Impossible.Name = "Impossible";
            Impossible.Size = new Size(82, 19);
            Impossible.TabIndex = 3;
            Impossible.TabStop = true;
            Impossible.Text = "Impossible";
            Impossible.UseVisualStyleBackColor = true;
            // 
            // Spela
            // 
            Spela.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Spela.Location = new Point(24, 166);
            Spela.Name = "Spela";
            Spela.Size = new Size(0, 0);
            Spela.TabIndex = 4;
            Spela.Text = "Spela";
            Spela.UseVisualStyleBackColor = true;
            // 
            // Play
            // 
            Play.Location = new Point(73, 166);
            Play.Name = "Play";
            Play.Size = new Size(147, 53);
            Play.TabIndex = 5;
            Play.Text = "Spela";
            Play.UseVisualStyleBackColor = true;
            Play.Click += Play_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 261);
            Controls.Add(Play);
            Controls.Add(Spela);
            Controls.Add(Impossible);
            Controls.Add(Hard);
            Controls.Add(Medium);
            Controls.Add(Easy);
            Name = "Form1";
            Text = "MineSweeperSlutProjekt";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton Easy;
        private RadioButton Medium;
        private RadioButton Hard;
        private RadioButton Impossible;
        private Button Spela;
        private Button Play;
    }
}
