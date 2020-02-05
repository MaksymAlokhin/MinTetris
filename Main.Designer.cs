namespace MinTetris
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.GlassPanel = new System.Windows.Forms.Panel();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.scoresPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ScoreIndicator = new System.Windows.Forms.Label();
            this.LevelIndicator = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LinesIndicator = new System.Windows.Forms.Label();
            this.HelpText = new System.Windows.Forms.Label();
            this.NextTetrominoPanel = new System.Windows.Forms.Label();
            this.nextLabel = new System.Windows.Forms.Label();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tetroMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.pentoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.SpeedIndicator = new System.Windows.Forms.Label();
            this.InfoPanel.SuspendLayout();
            this.scoresPanel.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // GlassPanel
            // 
            this.GlassPanel.BackColor = System.Drawing.SystemColors.Window;
            this.GlassPanel.Location = new System.Drawing.Point(0, 30);
            this.GlassPanel.Name = "GlassPanel";
            this.GlassPanel.Size = new System.Drawing.Size(302, 644);
            this.GlassPanel.TabIndex = 0;
            this.GlassPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GlassPanel_Paint);
            // 
            // InfoPanel
            // 
            this.InfoPanel.BackColor = System.Drawing.SystemColors.Control;
            this.InfoPanel.Controls.Add(this.scoresPanel);
            this.InfoPanel.Controls.Add(this.HelpText);
            this.InfoPanel.Controls.Add(this.NextTetrominoPanel);
            this.InfoPanel.Controls.Add(this.nextLabel);
            this.InfoPanel.Location = new System.Drawing.Point(308, 30);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(180, 644);
            this.InfoPanel.TabIndex = 1;
            this.InfoPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.InfoPanel_Paint);
            // 
            // scoresPanel
            // 
            this.scoresPanel.Controls.Add(this.SpeedIndicator);
            this.scoresPanel.Controls.Add(this.label4);
            this.scoresPanel.Controls.Add(this.label1);
            this.scoresPanel.Controls.Add(this.ScoreIndicator);
            this.scoresPanel.Controls.Add(this.LevelIndicator);
            this.scoresPanel.Controls.Add(this.label3);
            this.scoresPanel.Controls.Add(this.label2);
            this.scoresPanel.Controls.Add(this.LinesIndicator);
            this.scoresPanel.Location = new System.Drawing.Point(3, 258);
            this.scoresPanel.Name = "scoresPanel";
            this.scoresPanel.Size = new System.Drawing.Size(176, 119);
            this.scoresPanel.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Score:";
            // 
            // ScoreIndicator
            // 
            this.ScoreIndicator.AutoSize = true;
            this.ScoreIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScoreIndicator.Location = new System.Drawing.Point(84, 14);
            this.ScoreIndicator.Name = "ScoreIndicator";
            this.ScoreIndicator.Size = new System.Drawing.Size(19, 20);
            this.ScoreIndicator.TabIndex = 1;
            this.ScoreIndicator.Text = "0";
            this.ScoreIndicator.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LevelIndicator
            // 
            this.LevelIndicator.AutoSize = true;
            this.LevelIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LevelIndicator.Location = new System.Drawing.Point(84, 64);
            this.LevelIndicator.Name = "LevelIndicator";
            this.LevelIndicator.Size = new System.Drawing.Size(19, 20);
            this.LevelIndicator.TabIndex = 7;
            this.LevelIndicator.Text = "0";
            this.LevelIndicator.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(18, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Lines:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(18, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Level:";
            // 
            // LinesIndicator
            // 
            this.LinesIndicator.AutoSize = true;
            this.LinesIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LinesIndicator.Location = new System.Drawing.Point(84, 39);
            this.LinesIndicator.Name = "LinesIndicator";
            this.LinesIndicator.Size = new System.Drawing.Size(19, 20);
            this.LinesIndicator.TabIndex = 3;
            this.LinesIndicator.Text = "0";
            this.LinesIndicator.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // HelpText
            // 
            this.HelpText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HelpText.Location = new System.Drawing.Point(17, 180);
            this.HelpText.Name = "HelpText";
            this.HelpText.Size = new System.Drawing.Size(147, 74);
            this.HelpText.TabIndex = 8;
            this.HelpText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NextTetrominoPanel
            // 
            this.NextTetrominoPanel.Location = new System.Drawing.Point(28, 42);
            this.NextTetrominoPanel.Name = "NextTetrominoPanel";
            this.NextTetrominoPanel.Size = new System.Drawing.Size(122, 122);
            this.NextTetrominoPanel.TabIndex = 5;
            this.NextTetrominoPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.NextTetrominoPanel_Paint);
            // 
            // nextLabel
            // 
            this.nextLabel.AutoSize = true;
            this.nextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nextLabel.Location = new System.Drawing.Point(65, 11);
            this.nextLabel.Name = "nextLabel";
            this.nextLabel.Size = new System.Drawing.Size(45, 20);
            this.nextLabel.TabIndex = 4;
            this.nextLabel.Text = "Next:";
            this.nextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.endToolStripMenuItem,
            this.highToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.quitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "&Game";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.startToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.startToolStripMenuItem.Text = "&Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.pauseToolStripMenuItem.Text = "&Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // endToolStripMenuItem
            // 
            this.endToolStripMenuItem.Name = "endToolStripMenuItem";
            this.endToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.endToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.endToolStripMenuItem.Text = "&End";
            this.endToolStripMenuItem.Click += new System.EventHandler(this.endToolStripMenuItem_Click);
            // 
            // highToolStripMenuItem
            // 
            this.highToolStripMenuItem.Name = "highToolStripMenuItem";
            this.highToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.highToolStripMenuItem.Text = "&High Scores";
            this.highToolStripMenuItem.Click += new System.EventHandler(this.highToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(137, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.quitToolStripMenuItem.Text = "&Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.modeToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(493, 24);
            this.MainMenu.TabIndex = 2;
            this.MainMenu.Text = "MainMenu";
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tetroMenu,
            this.pentoMenu});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.modeToolStripMenuItem.Text = "&Mode";
            // 
            // tetroMenu
            // 
            this.tetroMenu.Checked = true;
            this.tetroMenu.CheckOnClick = true;
            this.tetroMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tetroMenu.Name = "tetroMenu";
            this.tetroMenu.Size = new System.Drawing.Size(133, 22);
            this.tetroMenu.Text = "&Tetromino";
            this.tetroMenu.Click += new System.EventHandler(this.tetrominoToolStripMenuItem_Click);
            // 
            // pentoMenu
            // 
            this.pentoMenu.CheckOnClick = true;
            this.pentoMenu.Name = "pentoMenu";
            this.pentoMenu.Size = new System.Drawing.Size(133, 22);
            this.pentoMenu.Text = "&Pentomino";
            this.pentoMenu.Click += new System.EventHandler(this.pentominoToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(9, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Speed:";
            // 
            // SpeedIndicator
            // 
            this.SpeedIndicator.AutoSize = true;
            this.SpeedIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SpeedIndicator.Location = new System.Drawing.Point(84, 88);
            this.SpeedIndicator.Name = "SpeedIndicator";
            this.SpeedIndicator.Size = new System.Drawing.Size(19, 20);
            this.SpeedIndicator.TabIndex = 11;
            this.SpeedIndicator.Text = "0";
            this.SpeedIndicator.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 683);
            this.Controls.Add(this.InfoPanel);
            this.Controls.Add(this.GlassPanel);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MinTetris";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.InfoPanel.ResumeLayout(false);
            this.InfoPanel.PerformLayout();
            this.scoresPanel.ResumeLayout(false);
            this.scoresPanel.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion



        private System.Windows.Forms.Panel GlassPanel;
        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NextTetrominoPanel;
        private System.Windows.Forms.Label nextLabel;
        private System.Windows.Forms.Label LinesIndicator;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ScoreIndicator;
        private System.Windows.Forms.Label LevelIndicator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label HelpText;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.Panel scoresPanel;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tetroMenu;
        private System.Windows.Forms.ToolStripMenuItem pentoMenu;
        private System.Windows.Forms.Label SpeedIndicator;
        private System.Windows.Forms.Label label4;
    }
}

