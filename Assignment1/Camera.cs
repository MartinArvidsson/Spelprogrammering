using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Assignment1
{
    class Camera
    {
        int sizeOfTile = 64;
        int borderSize = 64;

        public Vector2 GetCoordinates(int xcoordinate,int ycoordinate)
        {
            int visualX = borderSize + xcoordinate * sizeOfTile;
            int visualY = borderSize + ycoordinate * sizeOfTile;

            return new Vector2(visualX, visualY);
        }
    }
}
