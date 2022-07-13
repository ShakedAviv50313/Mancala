using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace mancala
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        Texture2D emptyBoard;
        private new2pGame new_game;
   
        string text = "hello";
        public int counter = 0;
        bool displayText = false;
        MouseState prevMouseState;
        MouseState Mousestate;
        SpriteFont mainfont;

   


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            S.cm = Content;


        }


        protected override void Initialize()
        {

            this.IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            graphics.PreferredBackBufferWidth = 1400;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 800;  // set this value to the desired height of your window
            graphics.ApplyChanges();

            mainfont = Content.Load<SpriteFont>("SpriteFont1");

            emptyBoard = Content.Load<Texture2D>("mancala board new2");

 
        }

        protected override void UnloadContent()
        {
        
        }

        public int getCounter() {
            return this.counter;
        }
        public void setCounter(int a) {
            this.counter = a;
        }
       
        protected override void Update(GameTime gameTime)
        {
         
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            prevMouseState = Mousestate;
            Mousestate = Mouse.GetState();

            if (Mousestate.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
            {
                counter++;
            }
            else if (Mousestate.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed)
            {
                counter--; 
            }
            //base.Draw(gameTime);
            base.Update(gameTime);

        }

       
        protected override void Draw(GameTime gameTime)
        {
           GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(emptyBoard, new Rectangle (0,0,1400,800) , Color.White);
            this.new_game = new new2pGame();
           // spriteBatch.DrawString(mainfont, counter.ToString(), new Vector2(50, 50), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
