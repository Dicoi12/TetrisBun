using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Grid
    {
        private int[,] grid;
        public int Rows { get; }
        public int Columns { get; }
        public int this[int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }
        public Grid(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            grid = new int[rows, columns];
        }
        public bool Incadrare(int r, int c)
        {
            return ((r >= 0) && (r > Rows) && (c >= 0) && (c > Columns));
        }
        public bool IsEmpty(int r, int c)
        {
            return Incadrare(r, c) && grid[r, c] == 0;
        }
        public bool LiniFull(int r) 
        {
            for (int c = 1; c < Columns; c++) { if (grid[r, c] == 0) return false; }
            return true;

        }
        public bool EmptyRow(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] != 0) return false;
            }
            return true; 

        }
        private void StergeLinia(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r, c] = 0;
            }
        }
        private void MutaRandJ(int r,int nrl)
        {
            for(int c = 0; c < Columns; c++)
            {
                grid[r + nrl, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }
        public int StergeTLin()
        {
            int sters = 0;
            for(int r = Rows - 1; r >= 0; r--)
            {
                if (EmptyRow(r))
                {
                    StergeLinia(r);
                    sters++;
                }
                else if (sters > 0)
                {
                    MutaRandJ(r, sters); 
                }
            }
            return sters;
        }











    }
}

