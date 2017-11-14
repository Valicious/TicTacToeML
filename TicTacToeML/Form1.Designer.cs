namespace TicTacToeML
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.c3 = new System.Windows.Forms.Button();
            this.c2 = new System.Windows.Forms.Button();
            this.c1 = new System.Windows.Forms.Button();
            this.b3 = new System.Windows.Forms.Button();
            this.b2 = new System.Windows.Forms.Button();
            this.b1 = new System.Windows.Forms.Button();
            this.a3 = new System.Windows.Forms.Button();
            this.a2 = new System.Windows.Forms.Button();
            this.a1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(442, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.c3);
            this.groupBox1.Controls.Add(this.c2);
            this.groupBox1.Controls.Add(this.c1);
            this.groupBox1.Controls.Add(this.b3);
            this.groupBox1.Controls.Add(this.b2);
            this.groupBox1.Controls.Add(this.b1);
            this.groupBox1.Controls.Add(this.a3);
            this.groupBox1.Controls.Add(this.a2);
            this.groupBox1.Controls.Add(this.a1);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 426);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game";
            // 
            // c3
            // 
            this.c3.Font = new System.Drawing.Font("OCR A Extended", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c3.Location = new System.Drawing.Point(278, 287);
            this.c3.Name = "c3";
            this.c3.Size = new System.Drawing.Size(128, 128);
            this.c3.TabIndex = 18;
            this.c3.Tag = "108";
            this.c3.Text = "x";
            this.c3.UseVisualStyleBackColor = true;
            this.c3.Click += new System.EventHandler(this.BoardClick);
            // 
            // c2
            // 
            this.c2.Font = new System.Drawing.Font("OCR A Extended", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c2.Location = new System.Drawing.Point(144, 287);
            this.c2.Name = "c2";
            this.c2.Size = new System.Drawing.Size(128, 128);
            this.c2.TabIndex = 17;
            this.c2.Tag = "105";
            this.c2.Text = "x";
            this.c2.UseVisualStyleBackColor = true;
            this.c2.Click += new System.EventHandler(this.BoardClick);
            // 
            // c1
            // 
            this.c1.Font = new System.Drawing.Font("OCR A Extended", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1.Location = new System.Drawing.Point(10, 287);
            this.c1.Name = "c1";
            this.c1.Size = new System.Drawing.Size(128, 128);
            this.c1.TabIndex = 16;
            this.c1.Tag = "102";
            this.c1.Text = "x";
            this.c1.UseVisualStyleBackColor = true;
            this.c1.Click += new System.EventHandler(this.BoardClick);
            // 
            // b3
            // 
            this.b3.Font = new System.Drawing.Font("OCR A Extended", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b3.Location = new System.Drawing.Point(278, 153);
            this.b3.Name = "b3";
            this.b3.Size = new System.Drawing.Size(128, 128);
            this.b3.TabIndex = 15;
            this.b3.Tag = "107";
            this.b3.Text = "x";
            this.b3.UseVisualStyleBackColor = true;
            this.b3.Click += new System.EventHandler(this.BoardClick);
            // 
            // b2
            // 
            this.b2.Font = new System.Drawing.Font("OCR A Extended", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b2.Location = new System.Drawing.Point(144, 153);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(128, 128);
            this.b2.TabIndex = 14;
            this.b2.Tag = "104";
            this.b2.Text = "x";
            this.b2.UseVisualStyleBackColor = true;
            this.b2.Click += new System.EventHandler(this.BoardClick);
            // 
            // b1
            // 
            this.b1.Font = new System.Drawing.Font("OCR A Extended", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b1.Location = new System.Drawing.Point(10, 153);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(128, 128);
            this.b1.TabIndex = 13;
            this.b1.Tag = "101";
            this.b1.Text = "x";
            this.b1.UseVisualStyleBackColor = true;
            this.b1.Click += new System.EventHandler(this.BoardClick);
            // 
            // a3
            // 
            this.a3.Font = new System.Drawing.Font("OCR A Extended", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.a3.Location = new System.Drawing.Point(278, 19);
            this.a3.Name = "a3";
            this.a3.Size = new System.Drawing.Size(128, 128);
            this.a3.TabIndex = 12;
            this.a3.Tag = "106";
            this.a3.Text = "x";
            this.a3.UseVisualStyleBackColor = true;
            this.a3.Click += new System.EventHandler(this.BoardClick);
            // 
            // a2
            // 
            this.a2.Font = new System.Drawing.Font("OCR A Extended", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.a2.Location = new System.Drawing.Point(144, 19);
            this.a2.Name = "a2";
            this.a2.Size = new System.Drawing.Size(128, 128);
            this.a2.TabIndex = 11;
            this.a2.Tag = "103";
            this.a2.Text = "x";
            this.a2.UseVisualStyleBackColor = true;
            this.a2.Click += new System.EventHandler(this.BoardClick);
            // 
            // a1
            // 
            this.a1.Font = new System.Drawing.Font("OCR A Extended", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.a1.Location = new System.Drawing.Point(10, 19);
            this.a1.Name = "a1";
            this.a1.Size = new System.Drawing.Size(128, 128);
            this.a1.TabIndex = 10;
            this.a1.Tag = "100";
            this.a1.Text = "x";
            this.a1.UseVisualStyleBackColor = true;
            this.a1.Click += new System.EventHandler(this.BoardClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 470);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Tic Tac Toe Machine Learn";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button a1;
        private System.Windows.Forms.Button c3;
        private System.Windows.Forms.Button c2;
        private System.Windows.Forms.Button c1;
        private System.Windows.Forms.Button b3;
        private System.Windows.Forms.Button b2;
        private System.Windows.Forms.Button b1;
        private System.Windows.Forms.Button a3;
        private System.Windows.Forms.Button a2;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
    }
}

