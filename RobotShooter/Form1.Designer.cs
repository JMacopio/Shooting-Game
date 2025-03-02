namespace RobotShooter
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textAmmo = new System.Windows.Forms.Label();
            this.textKills = new System.Windows.Forms.Label();
            this.playerHealth = new System.Windows.Forms.ProgressBar();
            this.gameStart = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 506);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "AMMO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(314, 506);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "KILLS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(608, 506);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "HEALTH";
            // 
            // textAmmo
            // 
            this.textAmmo.AutoSize = true;
            this.textAmmo.Location = new System.Drawing.Point(94, 506);
            this.textAmmo.Name = "textAmmo";
            this.textAmmo.Size = new System.Drawing.Size(51, 20);
            this.textAmmo.TabIndex = 5;
            this.textAmmo.Text = "label4";
            // 
            // textKills
            // 
            this.textKills.AutoSize = true;
            this.textKills.Location = new System.Drawing.Point(373, 506);
            this.textKills.Name = "textKills";
            this.textKills.Size = new System.Drawing.Size(51, 20);
            this.textKills.TabIndex = 6;
            this.textKills.Text = "label5";
            // 
            // playerHealth
            // 
            this.playerHealth.Location = new System.Drawing.Point(687, 491);
            this.playerHealth.Name = "playerHealth";
            this.playerHealth.Size = new System.Drawing.Size(139, 41);
            this.playerHealth.TabIndex = 7;
            // 
            // gameStart
            // 
            this.gameStart.Enabled = true;
            this.gameStart.Interval = 10;
            this.gameStart.Tick += new System.EventHandler(this.gameStartEvent);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::RobotShooter.Properties.Resources.ru;
            this.pictureBox2.Location = new System.Drawing.Point(547, 126);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 49);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "robot";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RobotShooter.Properties.Resources.mr;
            this.pictureBox1.Location = new System.Drawing.Point(99, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "player";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::RobotShooter.Properties.Resources.ammo;
            this.pictureBox3.Location = new System.Drawing.Point(469, 260);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 64);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Tag = "ammo";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 544);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.playerHealth);
            this.Controls.Add(this.textKills);
            this.Controls.Add(this.textAmmo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label textAmmo;
        private System.Windows.Forms.Label textKills;
        private System.Windows.Forms.ProgressBar playerHealth;
        private System.Windows.Forms.Timer gameStart;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

