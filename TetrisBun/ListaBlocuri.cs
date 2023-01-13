using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class ListaBlocuri
    {
        private readonly Blocuri[] blocks = new Blocuri[]
        {
            new BloculI(),
            new BloculJ(),
            new BloculS(),
            new BloculT(),
            new BloculO(),
            new BloculL(),
            new BloculZ()
        };
        private readonly Random random=new Random();
        
        public Blocuri NextBlocuri { get; private set; }

        public ListaBlocuri()
        {
            NextBlocuri = RandomBlocuri();
        }
        private Blocuri RandomBlocuri()
        {
            return blocks[random.Next(blocks.Length)];
        }

        public Blocuri GetandUpdate()
        {
            Blocuri bloc=NextBlocuri;
            do { NextBlocuri = RandomBlocuri(); }
            while (bloc.Id == NextBlocuri.Id);
          
            return bloc;
        }
    }
}
