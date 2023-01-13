using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris;

namespace TetrisBun
{
    public class Panel : Form
    {
        private GameState gameState;
        private Timer timer;
        private readonly int blockSize = 25;

        public Panel()
        {
            gameState = new GameState();
            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += Timer_Tick;
            timer.Start();
            this.Paint += Panel_Paint;
            this.KeyDown += Panel_KeyDown;
            this.FormClosing += Panel_FormClosing;
            this.ClientSize = new Size(gameState.GameGrid.Columns * blockSize, gameState.GameGrid.Rows * blockSize);
        }

        private void Panel_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }

        private void Panel_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    gameState.MoveBlockLeft();
                    break;
                case Keys.Right:
                    gameState.MoveBlockRight();
                    break;
                case Keys.Down:
                    gameState.MoveBlockDown();
                    break;
                case Keys.Up:
                    gameState.RotateBlockCW();
                    break;
            }
            Invalidate();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            gameState.MoveBlockDown();
            Invalidate();
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            if (gameState.GameOver)
            {
                e.Graphics.DrawString("Game Over", new Font("Arial", 14), Brushes.Red, new PointF(ClientSize.Width / 2 - 40, ClientSize.Height / 2));
                return;
            }
            for (int r = 0; r < gameState.GameGrid.Rows; r++)
            {
                for (int c = 0; c < gameState.GameGrid.Columns; c++)
                {
                    if (gameState.GameGrid[r, c] != 0)
                    {
                        e.Graphics.FillRectangle(Brushes.Blue, c * blockSize, r * blockSize, blockSize, blockSize);
                    }
                }
            }
            foreach (Pozitii p in gameState.CurrentBlock.TilePozitii())
            {
                e.Graphics.FillRectangle(Brushes.Green, p.Column * blockSize, p.Row * blockSize, blockSize, blockSize);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.ClientSize = new System.Drawing.Size(148, 3);
            this.Name = "Panel";
            this.Load += new System.EventHandler(this.Panel_Load);
            this.ResumeLayout(false);

        }

        private void Panel_Load(object sender, EventArgs e)
        {

        }
    }
}

