///Sam Wolfgram
///Air Hockey
///wednesday January 10 2021
///
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Air_Hockey
{
    public partial class Form1 : Form
    {
        #region// variables
        int player1X = 175;
        int player1Y = 25;
        int player1Score = 0;

        int goal = 100;

        int player2X = 175;
        int player2Y = 475;
        int player2Score = 0;


        int playerHeight = 30;
        int playerWidth = 30;
        int playerspeed = 7;

        int puckX = 175;
        int puckY = 300;
        int puckHeight = 15;
        int puckWidth = 15;
        int puckXSpeed = 5;
        int puckYSpeed = 6;

        bool wUp = false;
        bool sDown = false;
        bool dRight = false;
        bool aLeft = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool rightArrowDown = false;
        bool leftArrowDown = false;

        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        Pen redpen = new Pen(Color.Red);
        Font screenFont = new Font("Consolas", 12);
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wUp = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dRight = true;
                    break;
                case Keys.A:
                    aLeft = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wUp = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.D:
                    dRight = false;
                    break;
                case Keys.A:
                    aLeft = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
            }
        }

        private void GameEnigine_Tick(object sender, EventArgs e)
        {

            #region // movment
            //move puck
            puckX += puckXSpeed;
            puckY += puckYSpeed;

            //Move player 1
            if (wUp && player1Y > 5)
            {
                player1Y -= playerspeed;
            }
            if (sDown && player1Y < 270)
            {
                player1Y += playerspeed;
            }
            if (dRight && player1X < 315)
            {
                player1X += playerspeed;
            }
            if (aLeft && player1X > 5)
            {
                player1X -= playerspeed;
            }

            // move player two
            if (upArrowDown && player2Y > 305)
            {
                player2Y -= playerspeed;
            }
            if (downArrowDown && player2Y < 566)
            {
                player2Y += playerspeed;
            }
            if (rightArrowDown && player2X < 315)
            {
                player2X += playerspeed;
            }
            if (leftArrowDown && player2X > 5)
            {
                player2X -= playerspeed;
            }
            #endregion
            #region //collisions
            //rectangles
            Rectangle player1Rec = new Rectangle(player1X, player1Y, playerWidth, playerHeight);
            Rectangle player2Rec = new Rectangle(player2X, player2Y, playerWidth, playerHeight);
            Rectangle puckRec = new Rectangle(puckX,puckY,puckWidth,puckHeight);
            Rectangle goal1 = new Rectangle(126,5,goal,1);
            Rectangle goal2 = new Rectangle(125, 595, goal, 1);

            //colision
            if (puckY < 0 || puckY > this.Height - puckHeight)
            {
                puckYSpeed *= -1;
            }
            if (puckX < 0 || puckX > this.Width - puckWidth)
            {
                puckXSpeed *= -1;
            }

            if (player1Rec.IntersectsWith(puckRec))
            {
                puckYSpeed *= -1;
                puckY = player1Y + playerWidth + 1;
            }
            else if (player2Rec.IntersectsWith(puckRec))
            {
                puckYSpeed *= -1;
                puckY = player2Y - playerWidth - 1;
            }
            #endregion

            #region // goals and points
            if (puckRec.IntersectsWith(goal1))
            {
                player2Score++;
                player1X = 175;
                player1Y = 25;
                player2X = 175;
                player2Y = 475;
                puckX = 175;
                puckY = 300;
            }
            else if (puckRec.IntersectsWith(goal2))
            {
                player1Score++;
                player1X = 175;
                player1Y = 25;
                player2X = 175;
                player2Y = 475;
                puckX = 175;
                puckY = 300;
            }
            if (player1Score == 3 || player2Score == 3)
            {
                GameEnigine.Enabled = false;
            }
            #endregion
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //drawing
            e.Graphics.FillRectangle(redBrush, player1X, player1Y, playerWidth,playerHeight);
            e.Graphics.FillRectangle(redBrush, player2X, player2Y, playerWidth, playerHeight);

            e.Graphics.FillRectangle(blackBrush, puckX, puckY, puckWidth, puckHeight);
            e.Graphics.DrawLine(redpen,0,300,350,300);
            e.Graphics.DrawEllipse(redpen,125,565,goal,70);
            e.Graphics.DrawEllipse(redpen,125,35,goal,-70);

            e.Graphics.DrawString($"{player1Score}", screenFont, blackBrush, 330, 280);
            e.Graphics.DrawString($"{player2Score}", screenFont, blackBrush, 330, 300);







        }
    }
}
