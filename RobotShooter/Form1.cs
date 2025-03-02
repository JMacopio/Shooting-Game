using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotShooter
{
    public partial class Form1 : Form
    {
        //controls player position on screen
        bool keyup, keydown, keyleft, keyright;
        string playerDirection = "right";

        //state of game at game start
        bool gameOver = false;

        //player stats at game start
        double health = 100;
        int movementSpeed = 10;
        int ammoLevel = 7;
        int robotSpeed = 3;
        int kills = 0;
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        //moves player when keys are pressed down
        private void keyDown(object sender, KeyEventArgs e)
        {
            //player won't be able to move if game is over
            if (gameOver)
            {
                return;
            }

            //moves player left with left arrow key and sets image as "man-left"
            if (e.KeyCode == Keys.Left)
            {
                keyleft = true;
                playerDirection = "left";
                pictureBox1.Image = Properties.Resources.ml;
            }

            //moves player right with right arrow key and sets image as "man-right"
            if (e.KeyCode == Keys.Right)
            {
                keyright = true;
                playerDirection = "right";
                pictureBox1.Image = Properties.Resources.mr;
            }

            //moves player down with right down key and sets image as "man-down"
            if (e.KeyCode == Keys.Down)
            {
                keydown = true;
                playerDirection = "down";
                pictureBox1.Image = Properties.Resources.md;
            }

            //moves player up with right up key and sets image as "man-up"
            if (e.KeyCode == Keys.Up)
            {
                keyup = true;
                playerDirection = "up";
                pictureBox1.Image = Properties.Resources.mu;
            }
        }

        //stops player movement when keys arent pressed
        private void keyUp(object sender, KeyEventArgs e)
        {
            //player won't be able to move if game is over
            if (gameOver)
            {
                return;
            }

            //disables keys when not pressed
            if (e.KeyCode == Keys.Left)
            {
                keyleft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                keyright = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                keydown = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                keyup = false;
            }

            //if the space bar is pressed down - it's here to prevent spamming of key
            if (e.KeyCode == Keys.Space && ammoLevel > 0)

            {
                //reduce ammo and shoots in the direction the  player faces
                ammoLevel--;
                shootMain(playerDirection);

                //spawn ammo boxes if ammo is low (defined later)
                if (ammoLevel < 3)
                {
                    spawnAmmo();
                }
            }
        }

        //timer event on game start
        private void gameStartEvent(object sender, EventArgs e)
        {
            //if the player has enough health left, the progressbar will be shown
            if (health > 1)
            {
                playerHealth.Value = Convert.ToInt32(health);
                playerHealth.ForeColor = Color.Orange;
            }
            //else the player will be killed and game over is called
            else
            {
                pictureBox1.Image = Properties.Resources.death;
                gameStart.Stop();
                gameOver = true;
            }

            //if health is less than zero make bar red as warning
            if (health < 20)
            {
                playerHealth.ForeColor = Color.Red;
            }

            //displays our player stats value on the form
            textAmmo.Text = ammoLevel.ToString();
            textKills.Text = kills.ToString();

            //if health is less than zero make bar red as warning
            if (health < 20)
            {
                playerHealth.ForeColor = Color.Red;
            }

            //affect speed of payer according to their direction
            if (keyleft && pictureBox1.Left > 0)
            {
                pictureBox1.Left -= movementSpeed;
            }

            if (keyright && pictureBox1.Left + pictureBox1.Width < this.ClientSize.Width)
            {
                pictureBox1.Left += movementSpeed;
            }

            if (keyup && pictureBox1.Top > 0)
            {
                pictureBox1.Top -= movementSpeed;
            }

            if (keydown && pictureBox1.Top + pictureBox1.Height < this.ClientSize.Height)
            {
                pictureBox1.Top += movementSpeed;
            }


            foreach (Control x in this.Controls)
            {
                //if the player runs over the ammo picture, they will pick it up (and the picture will dissapear), and their ammo level will increase
                if (x is PictureBox && x.Tag == "ammo")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(pictureBox1.Bounds))
                    {
                        this.Controls.Remove(((PictureBox)x)); // remove the ammo picture box
                        ((PictureBox)x).Dispose();
                        ammoLevel += 7;
                    }
                }

                //if our players bullet hits the frame of the form, the bullet will "dissapear"
                if (x is PictureBox && x.Tag == "bullet")
                {
                    if (((PictureBox)x).Left < 1 || ((PictureBox)x).Left > 930 || ((PictureBox)x).Top < 10 || ((PictureBox)x).Top > 700)
                    {
                        this.Controls.Remove(((PictureBox)x));
                        ((PictureBox)x).Dispose();
                    }
                }

                //player-robot interaction
                if (x is PictureBox && x.Tag == "robot")
                {

                    //if the robot runs into the player, our health goes down and we get a red background to show injury
                    if (((PictureBox)x).Bounds.IntersectsWith(pictureBox1.Bounds) && gameOver == false)
                    {
                        health -= 1;
                        pictureBox1.BackColor = Color.Red;
                    }
                    else
                    {
                        pictureBox1.BackColor = Color.Transparent;
                    }

                    //will allow the robots to move towards the player (just like the player keys above, it will change the robots direction and image)
                    if (((PictureBox)x).Left > pictureBox1.Left)
                    {
                        ((PictureBox)x).Left -= robotSpeed;
                        ((PictureBox)x).Image = Properties.Resources.rl;
                    }

                    if (((PictureBox)x).Top > pictureBox1.Top)
                    {
                        ((PictureBox)x).Top -= robotSpeed;
                        ((PictureBox)x).Image = Properties.Resources.ru;
                    }

                    if (((PictureBox)x).Left < pictureBox1.Left)
                    {
                        ((PictureBox)x).Left += robotSpeed;
                        ((PictureBox)x).Image = Properties.Resources.rr;
                    }

                    if (((PictureBox)x).Top < pictureBox1.Top)
                    {
                        ((PictureBox)x).Top += robotSpeed;
                        ((PictureBox)x).Image = Properties.Resources.rd;
                    }

                }


                //if our player hits the robot with our bullets, then the robots is killed and more are spawned
                foreach (Control j in this.Controls)
                {
                    if ((j is PictureBox && j.Tag == "bullet") && (x is PictureBox && x.Tag == "robot"))
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            //up our kill streak
                            kills++;
                            //removes the robot(x) and the ammo(j)
                            this.Controls.Remove(j);
                            j.Dispose();
                            this.Controls.Remove(x);
                            x.Dispose();
                            //spawns more robots
                            spawnRobots();
                        }
                    }
                }
            }
        }

        //function needed to spawn more ammo during game
        private void spawnAmmo()
        {
            //creates new PictureBox for ammo that will spawn randomly across screen
            PictureBox ammo = new PictureBox();
            ammo.BringToFront();
            ammo.Image = Properties.Resources.ammo;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.BackColor = Color.Transparent;
            ammo.Left = random.Next(10, this.ClientSize.Width - ammo.Width);
            ammo.Top = random.Next(10, this.ClientSize.Height - ammo.Height);
            ammo.Tag = "ammo";

            //adds the controls needed to pick it up and dispose of it above
            this.Controls.Add(ammo);
            pictureBox1.BringToFront();

        }

        //allows the player to shoot the robots in the direction it faces
        private void shootMain(string direction)
        {
            bullet shoot = new bullet();
            shoot.direction = direction;
            shoot.bulletLeft = pictureBox1.Left + (pictureBox1.Width / 2);
            shoot.bulletTop = pictureBox1.Top + (pictureBox1.Height / 2);
            shoot.spawnBullets(this);
        }

        //spawns robots
        private void spawnRobots()
        {
            PictureBox robots = new PictureBox();
            robots.Tag = "robot";
            robots.Image = Properties.Resources.rl;
            robots.Left = random.Next(0, 900);
            robots.Top = random.Next(0, 800);
            robots.SizeMode = PictureBoxSizeMode.AutoSize;
            robots.BackColor = Color.Transparent;
            this.Controls.Add(robots);
            pictureBox1.BringToFront();
            robots.BringToFront();
        }
    }
}
