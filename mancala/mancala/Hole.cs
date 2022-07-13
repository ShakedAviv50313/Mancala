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
    class Hole
    {
        int serialnum;
        int numOfMarbles = 4;
        Stack<string> colors = new Stack <string>();
        string[] colorNames = { "Blue", "Green", "Red", "Yellow"};


        public Hole(int serialnum, int numOfMarbles2)
        {
            
            this.serialnum = serialnum;
            this.numOfMarbles = numOfMarbles2;
            initialize();
        }


        private void initialize() {
            for (int i = 0; i < numOfMarbles; i++)
            {
                if (serialnum == 0 || serialnum == 13) { return; }
               else
                {
                    this.colors.Push(colorNames[i % 4]);
                }
            }

        }

        public Stack<string> getColors()
        {
                return this.colors;
        }

        public int getSerialNum()
        {
                return this.serialnum;
        }

        public void setNumberOfMarbles(int a)
        {
            this.numOfMarbles = a;
        }


        public int getNumOfMarbles()
        {
            int i = 0;
            Stack<string> s1 = new Stack<string>();
            if (colors == null) { return 0; }
            while (!(colors.Count == 0)) // .isEmpty();
            {
                s1.Push(this.colors.Pop());
                i++;
            }
            while (!(s1.Count == 0)) // .isEmpty();
            {
                this.colors.Push(s1.Pop());
            }
            return i;

        }


        public void getFrom (Hole hl2)
        {
                this.colors.Push(hl2.getColors().Pop());
                this.numOfMarbles--;
        }
  
       





        






    }
}
