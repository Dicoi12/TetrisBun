using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameState
    {
        private Blocuri currentBlock;
        public Blocuri CurrentBlock
        {
            get => currentBlock;
            private set
            {
                currentBlock = value;
                currentBlock.Reset();
            }
        }
        public Grid GameGrid { get; }
        public ListaBlocuri Lista { get; }
        public bool GameOver { get; private set; }
        public GameState()
        {
            GameGrid = new Grid(22, 10);
            Lista = new ListaBlocuri();
            CurrentBlock = Lista.GetandUpdate();
        }
        private bool IfBlockFits()
        {
            foreach (Pozitii p in CurrentBlock.TilePozitii())
            {
                if (!GameGrid.IsEmpty(p.Row, p.Column))
                {
                    return false;
                }
            }
            return true;
        }
        public void RotateBlockCW()
        {
            CurrentBlock.RotateCW();
            if (!IfBlockFits())
            {
                CurrentBlock.RotateCCW();
            }
        }
        public void RotateBlockCCW()
        {
            CurrentBlock.RotateCCW();
            if (!IfBlockFits())
            {
                CurrentBlock.RotateCW();

            }
        }
        public void MoveBlockLeft()
        {
            CurrentBlock.Muta(0, -1);
            if (!IfBlockFits())
            {
                CurrentBlock.Muta(0, 1);
            }
        }

        public void MoveBlockRight()
        {
            CurrentBlock.Muta(0, 1);
            if (!IfBlockFits())
            {
                CurrentBlock.Muta(0, -1);
            }
        }
        private bool IsGameOver()
        {
            return !(GameGrid.EmptyRow(0) && GameGrid.EmptyRow(1));
        }
        private void PlaceBlock()
        {
            foreach (Pozitii p in CurrentBlock.TilePozitii())
            {
                GameGrid[p.Row, p.Column] = CurrentBlock.Id;
            }
            GameGrid.StergeTLin();
            if (IsGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = Lista.GetandUpdate();
            } }
        public void MoveBlockDown()
        {
            CurrentBlock.Muta(1, 0);
            if (!IfBlockFits())
            {
                CurrentBlock.Muta(-1, 0);
                PlaceBlock();
            }
        }
                    
                    
    }
}
