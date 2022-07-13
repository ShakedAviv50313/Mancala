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
    class new2pGame
    {


         private Texture2D Blue_marble;
         private Texture2D Green_marble;
         private Texture2D Red_marble;
         private Texture2D Yellow_marble;
         
         private int p1Score = 0;
         private int p2Score = 0;

         SpriteFont mainfont;
         string text = "hello";

         public Hole[,] boardArr = new Hole[2, 8];
         const int p1Mancalax = 100;
         const int p1Mancalay = 375;
         const int p2Mancalax = 1300;
         const int p2Mancalay = 375;
         const int hole1x = 220;
         const int hole1y = 300;
         const int hole2x = 400;
         const int hole2y = 300;
         const int hole3x = 575;
         const int hole3y = 300;
         const int hole4x = 760;
         const int hole4y = 300;
         const int hole5x = 940;
         const int hole5y = 300;
         const int hole6x = 1120;
         const int hole6y = 300;
         const int hole7x = 220;
         const int hole7y = 450;
         const int hole8x = 400;
         const int hole8y = 450;
         const int hole9x = 570;
         const int hole9y = 450;
         const int hole10x = 760;
         const int hole10y = 450;
         const int hole11x = 940;
         const int hole11y = 450;
         const int hole12x = 1120;
         const int hole12y = 450;
        Hole hl6 = new Hole(6, 4);

         const int spaceX = 175
            ; // 185

        public  new2pGame()
        {
            cleanArr();
            loadMarbles();
            drawMarbles();
            checkifholepressed();
            drawMarbles();

       
        }




        private void cleanArr()
        {
            //this function initiae start values for the board
            for (int i = 0; i < 8; i++)
            {
               
                if (i == 0 )
                {
                    this.boardArr[0, i] = new Hole(0,0);
                }
                if (i == 7)
                {
                    this.boardArr[0, i] = new Hole(13, 0);
                }

                if (!(i == 7 || i == 0))
                {
                    this.boardArr[0, i] = new Hole(i,4);
                    this.boardArr[1, i] = new Hole(i+6, 4);
                }
            
            

            }
        }

            private void loadMarbles() {
            this.Blue_marble = S.cm.Load<Texture2D>("Marbles" + "/" + "Bluemarble");
            this.Green_marble = S.cm.Load<Texture2D>("Marbles" + "/" + "Greenmarble");
            this.Red_marble = S.cm.Load<Texture2D>("Marbles" + "/" + "Redmarble");
            this.Yellow_marble = S.cm.Load<Texture2D>("Marbles" + "/" + "Yellowmarble");
        }
        private void drawmarblesxtimes(int i, Stack<string> colors, int x, int y)
        {
            double idk = 1.0;
            Stack<string> s1 = new Stack<string>();
            for (int j = 0; j < i; j++)
            {
                s1.Push(colors.Pop());
                idk += 1.0;
             //   Game1.spriteBatch.Begin();
                if (s1.Peek() == "Blue")
                {
                    Game1.spriteBatch.Draw(Blue_marble, new Rectangle(x, y, Blue_marble.Width, Blue_marble.Height), Color.White);
                }
                if (s1.Peek() == "Green")
                {
                    Game1.spriteBatch.Draw(Green_marble, new Rectangle(x, y, Green_marble.Width, Green_marble.Height), Color.White);
                }
                if (s1.Peek() == "Red")
                {
                    Game1.spriteBatch.Draw(Red_marble, new Rectangle(x, y, Red_marble.Width, Red_marble.Height), Color.White);
                }
                if (s1.Peek() == "Yellow")
                {
                    Game1.spriteBatch.Draw(Yellow_marble, new Rectangle(x, y, Yellow_marble.Width, Yellow_marble.Height), Color.White);
                }
               
                //     Game1.spriteBatch.End();

                if (idk == 3)
                {
                    y += 20;
                    x -= 40;
                }

                x += 20;          
          }
        }

        public void drawMarbles()
        {

            int numofMarbles = 0;
            for (int i = 0; i < 16; i++)
            {
                if (i < 8)
                {
                    numofMarbles = boardArr[0, i].getNumOfMarbles();
                    if (!(i == 0 || i == 7))
                    {
                        drawmarblesxtimes(numofMarbles, boardArr[0, i].getColors(), (p1Mancalax - 40) + i * spaceX, 300);
                    }
                }

                else
                {
                    if (i != 8 & i != 15)
                    {
                        numofMarbles = boardArr[1, i - 8].getNumOfMarbles();
                        drawmarblesxtimes(numofMarbles, boardArr[1, i-8].getColors(), (p1Mancalax - 40) + ((i - 8) * spaceX), 450);
                    }
                }

            }
        }

        public void checkifholepressed()
        {
            MouseState mouseState = Mouse.GetState();
            Point mousePosition = new Point(mouseState.X, mouseState.Y);
            bool pressed = false;
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if ((mouseState.X > 1080 & mouseState.X < 1235) & (mouseState.Y > 250 & mouseState.Y < 400))
                {
                   pressed = true;
                }
            }
            if (pressed) { 
            Turn turn1 = new Turn(0, 0, 1, boardArr);
            turn1.move(hl6); //boardArr[0, 6]
            this.mainfont = S.cm.Load<SpriteFont>("SpriteFont1");
            Game1.spriteBatch.DrawString(mainfont, text, new Vector2(50, 50), Color.White);
        }

                }
            
            
       
       


            public void setboardArr(Hole[,] newboardArr)
            {
                this.boardArr = newboardArr;
            }
            


            public Hole[,] getboardArr() 
            {
                return this.boardArr ;
            }

        }

    }


        
    

