using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Cell
    {
        private bool status;
        private int posX;
        private int posY;

        public Cell(int posX, int posY)
        {
            this.status = false;
            this.posX = posX;
            this.posY = posY;
        }

        public static bool GetStatus()
        {
            return this.status;
        }

        public static void SetStatus(bool status)
        {
            this.status = status;
        }

        public static int GetPosY()
        {
            return this.posY;
        }
        public static int GetposX()
        {
            return this.posX;
        }


    }
}
