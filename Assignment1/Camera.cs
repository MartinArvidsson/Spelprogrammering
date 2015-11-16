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
        public float scale;

        public Vector2 GetCoordinates(int xcoordinate,int ycoordinate)
        {
            // 0-0 = 64-64, 7-7 = 512-512 etc...
                        //64 + X * 64 = Place to start writing tile from
                        //Ex. 64 + 0 * 64 = 64
                            //Start at end of border
            //draw square where border + coordinate * tilesize is then scale it
            //(64 + X * 64) * scale
            //(64 + 4 * 64) * scale
            //(64 + 256) * scale
            float visualX = (borderSize + xcoordinate * sizeOfTile) * scale;
            float visualY = (borderSize + ycoordinate * sizeOfTile) * scale;

            return new Vector2(visualX,visualY);
        }

        public Vector2 GetRotatedCoordinates(int xplayercoordinate,int yplayercoordinate)
        {
            // 0-0 = 512-512, 7-7 = 64-64 etc...
            //  Logical Coordinate    Visual Coordinate
            //  0,0                   512,512
            //  6,0	                  128,512
            //  2,7	                  384,64
            //  7,7	                  64,64

            //              entire board   -    Already placed tiles
            int visualX = (sizeOfTile * 8) - (xplayercoordinate * sizeOfTile);
            int visualY = (sizeOfTile * 8) - (yplayercoordinate * sizeOfTile);

            return new Vector2(visualX, visualY);
        }

        public void ScaleGame(GraphicsDeviceManager graphics)
        {
            float XScale = (float)graphics.GraphicsDevice.Viewport.Width / (sizeOfTile * 8 + borderSize *2);
            float YScale = (float)graphics.GraphicsDevice.Viewport.Height / (sizeOfTile * 8 + borderSize *2);

            if(XScale < YScale)
            {
                scale = XScale;
            }
            else
            {
                scale = YScale;
            }
        }
    }
}
