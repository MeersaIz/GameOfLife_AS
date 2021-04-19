using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Game
    {
        private int Gen { get; set; }
        private int CellCount { get; set; }
        private int Height { get; set; }
        private int Width { get; set; }
        //private cell[] {get;set;}
        private int Interval { get; set; }
        private bool TorusRules { get; set; }


        public void CheckCell()
        {
            if (!TorusRules)
            {

            }
            
        }

        public void CheckCellTorus()
        {
            if (TorusRules)
            {

            }

        }

        public void NextGen()
        {
            this.Gen += 1;

        }

    }
}
