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

        public void ChangeStatus()
        {
            if (this.status == false) 
            {
                this.status = true;
            }
            else
            {
                this.status = false;
            }
        }

        public bool GetStatus()
        {
            return this.status;
        }

        public void SetStatus(bool status)
        {
            this.status = status;
        }

        public int GetPosY()
        {
            return this.posY;
        }
        public int GetposX()
        {
            return this.posX;
        }


    }
}
