using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class BloculO:Blocuri
    {
        private readonly Pozitii[][] tiles = new Pozitii[][]
        {
            new Pozitii[]{new Pozitii(0,0),new Pozitii(0,1),new Pozitii(1,0),new Pozitii(1,1)}
        };
        public override int Id => 4;
        protected override Pozitii StartOffset => new Pozitii(0, 4);
        protected override Pozitii[][] Tiles => tiles;
    }
}
