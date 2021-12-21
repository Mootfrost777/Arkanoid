using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace Arkanoid.Classes
{

    class Bricks
    {
        Random random = new Random();
        private int bricksCountWidth = 10;
        private int bricksCountHeight = 5;

        private Texture2D texture;
        Color t = Color.White;
        public static GameObj[,] bricksArray;
        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("Brick");
        }
        public void ResetBricks(int lvl)
        {
            bricksArray = new GameObj[bricksCountWidth, bricksCountHeight];

            for (int i = 0; i < bricksCountWidth; i++)
            {


                for (int j = 0; j < bricksCountHeight; j++)
                {



                    bricksArray[i, j] = new GameObj(texture)
                    {

                        Position = new Vector2(i * 82, j * 31 + 100)

                    };


                }
            }
            if (Game1.levels == 1)
            {
                for (int i = 0; i < 20; i++)
                {
                    int xx = random.Next(0, 9);
                    int yy = random.Next(0, 5);
                    bricksArray[xx, yy].IsAlive = false;
                }

            }
            if (Game1.levels == 0)
            {
                for (int i = 0; i < 100; i++)
                {
                    int xx = random.Next(0, 9);
                    int yy = random.Next(0, 5);
                    bricksArray[xx, yy].IsAlive = false;
                }
            }
            if (Game1.levels == 1)
            {
                for (int i = 0; i < 27; i++)
                {
                    int xx = random.Next(0, 9);
                    int yy = random.Next(0, 5);
                    bricksArray[xx, yy].IsAlive = false;
                }

            }
            if (Game1.levels >= 2 && lvl <= 6)
            {
                for (int i = 0; i < 20; i++)
                {
                    int xx = random.Next(0, 9);
                    int yy = random.Next(0, 5);
                    bricksArray[xx, yy].IsAlive = false;
                }

            }
            if (Game1.levels == 7)
            {
                for (int i = 0; i < 15; i++)
                {
                    int xx = random.Next(0, 9);
                    int yy = random.Next(0, 5);
                    bricksArray[xx, yy].IsAlive = false;
                }

            }
            if (Game1.levels == 8 || lvl == 9)
            {
                for (int i = 0; i < 10; i++)
                {
                    int xx = random.Next(0, 9);
                    int yy = random.Next(0, 5);
                    bricksArray[xx, yy].IsAlive = false;
                }

            }
            if (Game1.levels == 10)
            {
                for (int i = 0; i < 0; i++)
                {
                    int xx = random.Next(0, 9);
                    int yy = random.Next(0, 5);
                    bricksArray[xx, yy].IsAlive = false;
                }

            }



        }
        public void Update(int lvl)
        {
            bool flag = false;
            for (int i = 0; i < bricksCountWidth; i++)
            {
                for (int j = 0; j < bricksCountHeight; j++)
                {
                    if (bricksArray[i, j].IsAlive)
                    {
                        flag = true;

                    }

                }
            }
            if (flag == false)
            {
                Game1.gameState = GameState.Win;
                Game1.levels++;
                ResetBricks(lvl);
            }
        }
        public void Draw(SpriteBatch spriteBatch, int lvl)
        {


            for (int i = 0; i < bricksCountWidth; i++)
            {

                for (int j = 0; j < bricksCountHeight; j++)
                {

                    if (bricksArray[i, j].IsAlive)  //Невыбит ли кирпичик
                    {
                        if (i > -1 && i < 10 && j == 0)
                        {
                            t = Color.Yellow;
                        }
                        if (i > -1 && i < 10 && j == 1)
                        {
                            t = Color.LightCoral;
                        }
                        if (i > -1 && i < 10 && j == 2)
                        {
                            t = Color.Pink;
                        }
                        if (i > -1 && i < 10 && j == 3)
                        {
                            t = Color.Lavender;
                        }
                        if (i > -1 && i < 10 && j == 4)
                        {
                            t = Color.LightSkyBlue;
                        }
                        spriteBatch.Draw(bricksArray[i, j].texture, bricksArray[i, j].Position, t);
                    }

                }
            }



        }

    }
}