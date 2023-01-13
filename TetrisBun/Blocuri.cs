using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tetris
{
    public abstract class Blocuri
    {
        protected abstract Pozitii[][] Tiles { get; }
        protected abstract Pozitii StartOffset { get; }
        public abstract int Id {get;}
        private int rotationState;
        private Pozitii offset;

        public Blocuri()
        {
            offset = new Pozitii(StartOffset.Row, StartOffset.Column);
        }  
        public IEnumerable<Pozitii> TilePozitii()
        {
        foreach(Pozitii p in Tiles[rotationState])    {
                yield return new Pozitii(p.Row + offset.Row, p.Column + offset.Column);
            }
        }
        public void RotateCW()
        {
            rotationState=(rotationState+1)%Tiles.Length;
        }
        public void RotateCCW()
        {
            if (rotationState == 0)
            {
                rotationState=Tiles.Length-1;
            }
            else { rotationState--; }
        }
        public void Muta(int rows,int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }
        public void Reset()
        {
            rotationState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}
