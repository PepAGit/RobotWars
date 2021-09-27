using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    class Robot
    {
        private string[] Direction = { "N", "W", "S", "E" };
        private string curOrientation = "N";

        private int curPosX = 0, curPosY = 0;
        private int originX = 0, originY = 0;
        private int gridWidth = 1, gridHeight = 1;
   
        public Robot(int positionX, int positionY, string orientation, int origin_x, int origin_y, int width, int height)
        {
            curPosX = positionX;
            curPosY = positionY;
            curOrientation = orientation;
            originX = origin_x;
            originY = origin_y;
            gridWidth = width;
            gridHeight = height;
        }

        public int getPositionX()
        {
            return curPosX;
        }
        public int getPositionY()
        {
            return curPosY;
        }
        public string getOrientation()
        {
            return curOrientation;
        }
       
        public string calculatePosition(string movement)
        {
            string newPosition = curPosX.ToString() + " " + curPosY.ToString() + " " + curOrientation;

            foreach (char x in movement)
            {
                switch (x)
                {
                    case ('L'):
                        {
                            int index = Array.FindIndex(Direction, row => row == curOrientation);

                            curOrientation = (index < Direction.Length - 1) ? Direction[index + 1] : Direction[0];
                        }
                        break;
                    case ('R'):
                        {
                            int index = Array.FindIndex(Direction, row => row == curOrientation);

                            curOrientation = (index > 0) ? Direction[index - 1] : Direction[3];
                        }
                        break;
                    case ('M'):
                        {
                            if ((curOrientation == "N") && (curPosY < gridHeight))
                            {
                                curPosY++;
                            }
                            if ((curOrientation == "W") && (curPosX > originX))
                            {
                                curPosX--;
                            }

                            if ((curOrientation == "S") && (curPosY > originY))
                            {
                                curPosY--;
                            }

                            if ((curOrientation == "E") && (curPosX < gridWidth))
                            {
                                curPosX++;
                            }
                        }
                        break;
                }
            }

            newPosition = curPosX + " " + curPosY + " " + curOrientation;
            return newPosition;
        }
    }
}
