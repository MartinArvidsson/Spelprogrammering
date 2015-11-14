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
            // 0-0 = 64-64, 7-7 = 512-512 etc...
            int visualX = borderSize + xcoordinate * sizeOfTile;
            int visualY = borderSize + ycoordinate * sizeOfTile;

            return new Vector2(visualX, visualY);
        }

        public Vector2 GetRotatedCoordinates(int xplayercoordinate,int yplayercoordinate)
        {
            // 0-0 = 512-512, 7-7 = 64-64 etc...
            //  Logical Coordinate    Visual Coordinate
            //  0,0                   512,512
            //  6,0	                  128,512
            //  2,7	                  384,64
            //  7,7	                  64,64

            int visualX = (sizeOfTile * 8) - (xplayercoordinate * sizeOfTile);
            int visualY = (sizeOfTile * 8) - (yplayercoordinate * sizeOfTile);

            return new Vector2(visualX, visualY);
        }
    }
}
