using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace mancala
{
    class Turn
    {
        int turnNum;
        int p1Score;
        int p2Score;
        bool p1Turn = true;
        bool p2Turn = false;
        bool mancala = false;
        Hole[,] turnBoard;


        public Turn(int p1Score, int p2Score, int turnNum, Hole[,] newboard)
        {
            this.turnBoard = newboard;
        }

        public void whosTurn()
        {
            if (!(turnNum % 2 == 0))
            { // player1's turn
                p1Turn = true;
                p2Turn = false;
            }
            else
            {
                p2Turn = true;
                p1Turn = false;
            }
        }

        public Hole[,] getTurnBoard() {
            return this.turnBoard;
        }

        public void move(Hole selected) {
            if (p1Turn)
            {
                int tempserial = selected.getSerialNum();
                int tempNumofMarbles = selected.getNumOfMarbles();

                if (tempserial - tempNumofMarbles > 0)
                {
                    for (int j = 0 ; j< tempNumofMarbles; j++)
                    {
                        turnBoard[0, tempserial-j-1].getFrom(selected);
                        mancala = false;
                    }
                    return;
                }
                if (tempserial - tempNumofMarbles == 0) {
                    for (int j = 0; j < tempNumofMarbles; j++)
                    {
                        turnBoard[0, tempserial - j - 1].getFrom(selected);
                        mancala = true;
                    }

                }
                if (tempserial - tempNumofMarbles < 0)
                {
                    int rest = tempNumofMarbles - tempserial;

                    for (int j = 0; j < tempserial; j++)
                    {
                        turnBoard[0, tempserial - j - 1].getFrom(selected);
                    }
                    for (int j = 0; j < rest; j++)
                    {
                        if (j == 7) { move(selected); }
                        turnBoard[1, j + 1].getFrom(selected);

                    }

                }
                else {
                    int tempserial2 = selected.getSerialNum();
                    int tempNumofMarbles2 = selected.getNumOfMarbles();

                    if (12 - tempserial2 >= tempNumofMarbles2)
                    {
                        for (int j = 0; j < tempNumofMarbles2; j++) {
                            turnBoard[1, (tempserial2 - 5 + j)].getFrom(selected);
                        }
                    }

                    if (12 - tempserial2 - tempNumofMarbles2 == -1)
                    {
                        for (int j = 0; j < tempNumofMarbles2; j++)
                        {
                            if (j == tempNumofMarbles2 - 1)
                            {
                                turnBoard[0, 7].getFrom(selected);
                            }
                            else
                            {
                                turnBoard[1, (tempserial2 - 5 + j)].getFrom(selected);
                            }
                        }
                    }


                    if (12 - tempserial2 - tempNumofMarbles2 < -1) {
                        for (int j = 0; j < 12 - tempserial2; j++)
                        {
                            turnBoard[1, (tempserial2 - 5 + j)].getFrom(selected);
                        }
                        turnBoard[0, 7].getFrom(selected);
                        for (int j = 0; j < tempNumofMarbles2 - (12 - tempserial2 - 1); j++) {
                            if ((tempNumofMarbles2 - (12 - tempserial2 - 1)) > 6) { move(selected); }
                            turnBoard[1, 6-j].getFrom(selected);
                        }
                    }
}
            }


            }
        }
    }

