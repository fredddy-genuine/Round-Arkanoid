namespace Round_Arkanoid
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.ColourScheme = new System.Windows.Forms.PictureBox();
            this.MenuSettings = new System.Windows.Forms.PictureBox();
            this.buttonEasy = new System.Windows.Forms.Button();
            this.buttonMedium = new System.Windows.Forms.Button();
            this.buttonHard = new System.Windows.Forms.Button();
            this.buttonVeryHard = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCyberSport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColourScheme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(800, 660);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 15;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // ColourScheme
            // 
            this.ColourScheme.BackColor = System.Drawing.Color.Gainsboro;
            this.ColourScheme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ColourScheme.Location = new System.Drawing.Point(819, 285);
            this.ColourScheme.Name = "ColourScheme";
            this.ColourScheme.Size = new System.Drawing.Size(205, 192);
            this.ColourScheme.TabIndex = 2;
            this.ColourScheme.TabStop = false;
            this.ColourScheme.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ColourScheme_MouseClick);
            // 
            // MenuSettings
            // 
            this.MenuSettings.BackColor = System.Drawing.Color.Gray;
            this.MenuSettings.Location = new System.Drawing.Point(799, 0);
            this.MenuSettings.Name = "MenuSettings";
            this.MenuSettings.Size = new System.Drawing.Size(238, 660);
            this.MenuSettings.TabIndex = 3;
            this.MenuSettings.TabStop = false;
            // 
            // buttonEasy
            // 
            this.buttonEasy.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonEasy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEasy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEasy.Font = new System.Drawing.Font("Monotype Corsiva", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEasy.Location = new System.Drawing.Point(818, 12);
            this.buttonEasy.Name = "buttonEasy";
            this.buttonEasy.Size = new System.Drawing.Size(207, 46);
            this.buttonEasy.TabIndex = 5;
            this.buttonEasy.Text = "Easy";
            this.buttonEasy.UseVisualStyleBackColor = false;
            this.buttonEasy.Click += new System.EventHandler(this.buttonEasy_Click);
            // 
            // buttonMedium
            // 
            this.buttonMedium.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonMedium.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMedium.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMedium.Font = new System.Drawing.Font("Monotype Corsiva", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMedium.Location = new System.Drawing.Point(818, 64);
            this.buttonMedium.Name = "buttonMedium";
            this.buttonMedium.Size = new System.Drawing.Size(207, 46);
            this.buttonMedium.TabIndex = 6;
            this.buttonMedium.Text = "Medium";
            this.buttonMedium.UseVisualStyleBackColor = false;
            this.buttonMedium.Click += new System.EventHandler(this.buttonMedium_Click);
            // 
            // buttonHard
            // 
            this.buttonHard.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonHard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHard.Font = new System.Drawing.Font("Monotype Corsiva", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHard.Location = new System.Drawing.Point(818, 116);
            this.buttonHard.Name = "buttonHard";
            this.buttonHard.Size = new System.Drawing.Size(207, 46);
            this.buttonHard.TabIndex = 7;
            this.buttonHard.Text = "Hard";
            this.buttonHard.UseVisualStyleBackColor = false;
            this.buttonHard.Click += new System.EventHandler(this.buttonHard_Click);
            // 
            // buttonVeryHard
            // 
            this.buttonVeryHard.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonVeryHard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonVeryHard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVeryHard.Font = new System.Drawing.Font("Monotype Corsiva", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonVeryHard.Location = new System.Drawing.Point(818, 168);
            this.buttonVeryHard.Name = "buttonVeryHard";
            this.buttonVeryHard.Size = new System.Drawing.Size(207, 46);
            this.buttonVeryHard.TabIndex = 8;
            this.buttonVeryHard.Text = "Very Hard";
            this.buttonVeryHard.UseVisualStyleBackColor = false;
            this.buttonVeryHard.Click += new System.EventHandler(this.buttonVeryHard_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(840, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 39);
            this.label1.TabIndex = 9;
            this.label1.Text = "Color scheme";
            // 
            // buttonCyberSport
            // 
            this.buttonCyberSport.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonCyberSport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCyberSport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCyberSport.Font = new System.Drawing.Font("Monotype Corsiva", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCyberSport.Location = new System.Drawing.Point(818, 220);
            this.buttonCyberSport.Name = "buttonCyberSport";
            this.buttonCyberSport.Size = new System.Drawing.Size(207, 46);
            this.buttonCyberSport.TabIndex = 10;
            this.buttonCyberSport.Text = "Cyber Sport";
            this.buttonCyberSport.UseVisualStyleBackColor = false;
            this.buttonCyberSport.Click += new System.EventHandler(this.buttonCyberSport_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1037, 660);
            this.Controls.Add(this.buttonCyberSport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonVeryHard);
            this.Controls.Add(this.buttonHard);
            this.Controls.Add(this.buttonMedium);
            this.Controls.Add(this.buttonEasy);
            this.Controls.Add(this.ColourScheme);
            this.Controls.Add(this.Canvas);
            this.Controls.Add(this.MenuSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Round Arkanoid";
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColourScheme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuSettings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox ColourScheme;
        private System.Windows.Forms.PictureBox MenuSettings;
        private System.Windows.Forms.Button buttonEasy;
        private System.Windows.Forms.Button buttonMedium;
        private System.Windows.Forms.Button buttonHard;
        private System.Windows.Forms.Button buttonVeryHard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCyberSport;
    }
}

