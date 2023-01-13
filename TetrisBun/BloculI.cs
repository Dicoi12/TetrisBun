using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class BloculI : Blocuri
    {
        private readonly Pozitii[][] tiles = new Pozitii[][]
        {
           new Pozitii[]{new Pozitii(1,0),new Pozitii(1,1),new Pozitii(1,2),new Pozitii(1,3)},//poz 1 _
           new Pozitii[]{new Pozitii(0,2),new Pozitii(1,2),new Pozitii(2,2),new Pozitii(3,2)},//poz 2|
           new Pozitii[]{new Pozitii(2,0),new Pozitii(2,1),new Pozitii(2,2),new Pozitii(2,3)},//poz 3 -
           new Pozitii[]{new Pozitii(0,1),new Pozitii(1,1),new Pozitii(2,1),new Pozitii(3,1)}//poz 4  |
        };

        public override int Id => 1;
        protected override Pozitii StartOffset => new Pozitii(-1, 3);
        protected override Pozitii[][] Tiles => tiles;
    }
}
