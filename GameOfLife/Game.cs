using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Game
    {
        private int gen { get; set; }
        private int cellCount { get; set; }
        private int height { get; set; }
        private int width { get; set; }
        //private cell[] {get;set;}
        private int interval { get; set; }
        private bool torusRules { get; set; }


        public void CheckCell()
        {
            if (!torusRules)
            {

            }
            
        }

        public void CheckCellTorus()
        {
            if (torusRules)
            {

            }

        }

        public void NextGen()
        {
            this.gen += 1;

        }

    }
}
