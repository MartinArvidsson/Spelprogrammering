using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Assignment1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Gamecontroller : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D squareBlack;
        Texture2D squareWhite;
        Texture2D chessPiece;
        Camera camera = new Camera();

        public Gamecontroller()
        {
            graphics = new GraphicsDeviceManager(this);
            //graphics.PreferredBackBufferWidth = 640;
            //graphics.PreferredBackBufferHeight = 640;
            graphics.PreferredBackBufferWidth = 320;
            graphics.PreferredBackBufferHeight = 240;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //https://msdn.microsoft.com/en-us/library/bb447674.aspx
            camera.ScaleGame(graphics);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            squareBlack = Content.Load<Texture2D>("squareblack64.png");
            squareWhite = Content.Load<Texture2D>("squarewhite64.png");
            chessPiece = Content.Load<Texture2D>("Chesspiece.png");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            int squarecounter = 0;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (squarecounter % 2 == 0)
                   {
                       //White square
                       spriteBatch.Draw(squareWhite, camera.GetCoordinates(x, y), null, Color.White, 0, new Vector2(0, 0), camera.scale, SpriteEffects.None, 0);
                     //spriteBatch.Draw(whiteSquare, camera.getVisualCoord(x, y), null, Color.White, 0, new Vector2(0, 0), camera.scale, SpriteEffects.None, 0);
                   }
                   else
                   {
                        //Black Square
                       spriteBatch.Draw(squareBlack, camera.GetCoordinates(x, y), null, Color.White, 0, new Vector2(0, 0), camera.scale, SpriteEffects.None, 0);
                   }
                    squarecounter++;
                }
                squarecounter++;
            }
            //Testing writing a chesspice in upper left corner No rotation on board
            spriteBatch.Draw(chessPiece, camera.GetCoordinates(0,0), null, Color.White, 0, new Vector2(0, 0), camera.scale, SpriteEffects.None, 0);

            //Testing writing a chesspice in lower right corner rotation on board
            //spriteBatch.Draw(chessPiece, camera.GetRotatedCoordinates(0,0), null, Color.White, 0, new Vector2(0, 0), camera.scale, SpriteEffects.None, 0);



            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
