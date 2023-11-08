namespace Snake
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.граToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новаГраToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.паузаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.важкістьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.легкоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.середнєToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.важкоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.граToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(504, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // граToolStripMenuItem
            // 
            this.граToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новаГраToolStripMenuItem,
            this.паузаToolStripMenuItem,
            this.важкістьToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.граToolStripMenuItem.Name = "граToolStripMenuItem";
            this.граToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.граToolStripMenuItem.Text = "Game";
            // 
            // новаГраToolStripMenuItem
            // 
            this.новаГраToolStripMenuItem.Name = "новаГраToolStripMenuItem";
            this.новаГраToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.новаГраToolStripMenuItem.Text = "New game";
            this.новаГраToolStripMenuItem.Click += new System.EventHandler(this.новаГраToolStripMenuItem_Click);
            // 
            // паузаToolStripMenuItem
            // 
            this.паузаToolStripMenuItem.Name = "паузаToolStripMenuItem";
            this.паузаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.паузаToolStripMenuItem.Text = "Pause";
            this.паузаToolStripMenuItem.Click += new System.EventHandler(this.паузаToolStripMenuItem_Click);
            // 
            // важкістьToolStripMenuItem
            // 
            this.важкістьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.легкоToolStripMenuItem,
            this.середнєToolStripMenuItem,
            this.важкоToolStripMenuItem});
            this.важкістьToolStripMenuItem.Name = "важкістьToolStripMenuItem";
            this.важкістьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.важкістьToolStripMenuItem.Text = "Difficulty";
            // 
            // легкоToolStripMenuItem
            // 
            this.легкоToolStripMenuItem.Name = "легкоToolStripMenuItem";
            this.легкоToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.легкоToolStripMenuItem.Text = "Eaxy";
            this.легкоToolStripMenuItem.Click += new System.EventHandler(this.легкоToolStripMenuItem_Click);
            // 
            // середнєToolStripMenuItem
            // 
            this.середнєToolStripMenuItem.Checked = true;
            this.середнєToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.середнєToolStripMenuItem.Name = "середнєToolStripMenuItem";
            this.середнєToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.середнєToolStripMenuItem.Text = "medium";
            this.середнєToolStripMenuItem.Click += new System.EventHandler(this.середнєToolStripMenuItem_Click);
            // 
            // важкоToolStripMenuItem
            // 
            this.важкоToolStripMenuItem.Name = "важкоToolStripMenuItem";
            this.важкоToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.важкоToolStripMenuItem.Text = "hight";
            this.важкоToolStripMenuItem.Click += new System.EventHandler(this.важкоToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(504, 294);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem граToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новаГраToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem паузаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem важкістьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem легкоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem середнєToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem важкоToolStripMenuItem;
    }
}

