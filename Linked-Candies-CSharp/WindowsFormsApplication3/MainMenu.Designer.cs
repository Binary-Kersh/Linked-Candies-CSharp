namespace WindowsFormsApplication3
{
    partial class MainMenu
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
            this.play_btn = new System.Windows.Forms.Button();
            this.exit_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // play_btn
            // 
            this.play_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.play_btn.ForeColor = System.Drawing.Color.Crimson;
            this.play_btn.Location = new System.Drawing.Point(298, 254);
            this.play_btn.Name = "play_btn";
            this.play_btn.Size = new System.Drawing.Size(183, 62);
            this.play_btn.TabIndex = 0;
            this.play_btn.Text = "P L A Y";
            this.play_btn.UseVisualStyleBackColor = true;
            this.play_btn.Click += new System.EventHandler(this.play_btn_Click);
            // 
            // exit_btn
            // 
            this.exit_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit_btn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.exit_btn.Location = new System.Drawing.Point(73, 254);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(183, 62);
            this.exit_btn.TabIndex = 2;
            this.exit_btn.Text = "E X I T";
            this.exit_btn.UseVisualStyleBackColor = true;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "Linked Candies";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(20, 23);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 207);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.8F);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Location = new System.Drawing.Point(2, 332);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Developed By: Binary Kersh";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 351);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.exit_btn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.play_btn);
            this.Name = "MainMenu";
            this.Text = "Linked Candies";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button play_btn;
        private System.Windows.Forms.Button exit_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
    }
}