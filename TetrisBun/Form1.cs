using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris;
using System.Net.NetworkInformation;



namespace Tetris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var panel = new Panel();
            this.Controls.Add(panel);
            this.Text = "Tetris Game";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Confirmation dialog before exiting the game
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Game", MessageBoxButtons.YesNo);
            e.Cancel = (result == DialogResult.No);
        }

        /*private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(205, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 400);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }*/

        private GameState gameState;
        private Timer gameLoopTimer;
        private void GameLoopTimer_Tick(object sener, EventArgs e)
        {
            gameState.MoveBlockDown();
            panel2.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gameState = new GameState();
            gameLoopTimer = new Timer();
            gameLoopTimer.Interval = 2000; // 1 second
            gameLoopTimer.Tick += GameLoopTimer_Tick;
            gameLoopTimer.Start();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Get the Graphics object from the PaintEventArgs
            Graphics g = e.Graphics;
            // Set the size of each cell in the grid
            int cellSize = 20;
            // Set the color of the grid lines
            Pen gridPen = new Pen(Color.Black);
            // Set the color of the filled cells
            SolidBrush filledCellBrush = new SolidBrush(Color.Blue);
            // Draw the grid
            for (int r = 0; r < gameState.GameGrid.Rows; r++)
            {
                for (int c = 0; c < gameState.GameGrid.Columns; c++)
                {
                    if (gameState.GameGrid[r, c] != 0)
                    {
                        g.FillRectangle(filledCellBrush, c * cellSize, r * cellSize, cellSize, cellSize);
                    }
                    g.DrawRectangle(gridPen, c * cellSize, r * cellSize, cellSize, cellSize);
                }
            }
            // Draw the current block
            SolidBrush currentBlockBrush = new SolidBrush(Color.Red);
            foreach (Pozitii p in gameState.CurrentBlock.TilePozitii())
            {
                if (p.Row >= 0 && p.Column >= 0)
                {
                    g.FillRectangle(currentBlockBrush, p.Column * cellSize, p.Row * cellSize, cellSize, cellSize);
                }
            }
            if (gameState.GameOver)
            {
                SolidBrush gameOverBrush = new SolidBrush(Color.Black);
                Font gameOverFont = new Font("Arial", 20);
                string gameOverText = "Game Over";
                SizeF gameOverTextSize = g.MeasureString(gameOverText, gameOverFont);
                g.DrawString(gameOverText, gameOverFont, gameOverBrush, (panel2.Width - gameOverTextSize.Width) / 2, (panel2.Height - gameOverTextSize.Height) / 2);
            }
        }
    }
    } 





