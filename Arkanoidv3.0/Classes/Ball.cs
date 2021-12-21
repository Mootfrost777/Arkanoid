using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

using Microsoft.Xna.Framework.Content;

using Arkanoid.Classes;
using System.IO;
using System;
using System.Linq;

using MonoGame_Textbox;
using MonoGame_Test;

namespace Arkanoid.Classes
{
    class Ball
    {
        private GameObj ball;
        Random random = new Random();
        SoundEffect GameOverSong;
        SoundEffect PlatformCollideSong;
        public int speed1 = -3;
        public int speed2 = -3;
        Vector2 pos2 = new Vector2();

        public void LoadContent(ContentManager Content, Vector2 cpos)
        {
            ball = new GameObj(Content.Load<Texture2D>("Ball"));
            ball.Position = new Vector2(cpos.X, cpos.Y - 100);
            ball.Speed = new Vector2(speed1, speed2);
            GameOverSong = Content.Load<SoundEffect>("GameOver");
            PlatformCollideSong = Content.Load<SoundEffect>("PlatformCollide");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ball.texture, ball.Position, Color.White);
        }

        public void UpdateBall(Platform p, Vector2 cpos, string f, Bricks bricks, SoundEffect Explosion, SoundEffect Explosion2, SoundEffect Explosion3, int levels, Cube cub)
        {

            Rectangle Next = new Rectangle((int)(ball.Position.X + ball.Speed.X),
            (int)(ball.Position.Y + ball.Speed.Y),
            ball.Width, ball.Height);

            if (Next.Y <= 0)
            {
                ball.HorizontalRepulsion();
            }

            if (Next.Y >= 700 - Next.Height)

            {
                p.position = new Vector2(400, 500);
                ball.Position = new Vector2(cpos.X, cpos.Y - 100);
                ball.HorizontalRepulsion();
                Game1.SaveHistory();
                Game1.SaveBestScore();
                Game1.score = 0;
                speed1 = -3;
                speed2 = -3;
                p.speed = 6;
                Game1.newFlag = false;
                bricks.ResetBricks(levels);
                ball.IsAlive = false;
                Game1.gameState = GameState.GameOver;
                GameOverSong.Play();
                MediaPlayer.Stop();
            }

            if ((Next.X >= 800 - Next.Width) || Next.X <= 0)
            {
                ball.VerticalRepulsion();
            }

            foreach (var brick in Bricks.bricksArray)
            {
                if (Next.Intersects(brick.boundingBox) && brick.IsAlive)
                {
                    if (random.Next(0, 2) == 1)
                    {
                        if (Game1.levels == 10)
                        {
                            if (random.Next(0, 2) == 1)
                            {
                                Game1.isBoss = true;

                                Game1.xforboss = brick.Position.X;
                                Game1.yforboss = brick.Position.Y;
                                if (Game1.isBoss == true)
                                {
                                    //  cub = new cuber(Game1.xforboss,Game1.yforboss);
                                    cub.position = new Vector2(Game1.xforboss, Game1.yforboss);

                                    if (p.destinationRectangle.Intersects(cub.dest))
                                    {
                                        Game1.isBoss = false;



                                    }
                                }
                            }




                            int a = random.Next(0, 5);
                            if (a == 0) Explosion.Play();
                            else if (a == 1) Explosion2.Play();
                            else Explosion3.Play();
                            brick.IsAlive = false;



                            //int u = random.Next(0, 5);
                            //if (u==0)
                            //{

                            //}
                            Game1.score++;
                        }
                        else
                        {
                            int a = random.Next(0, 3);
                            if (a == 0) Explosion.Play();
                            else if (a == 1) Explosion2.Play();
                            else Explosion3.Play();
                            brick.IsAlive = false;
                            Game1.score++;
                        }

                    }
                    Collide(ball, brick.boundingBox);
                }
            }
            ball.Position += ball.Speed;
            if (Next.Intersects(p.destinationRectangle))
            {
                PlatformCollideSong.Play();
                Collide(ball, p.destinationRectangle);
            }
        }

        public void Collide(GameObj gameObj, Rectangle rectangle)//отбиться от стенок
        {
            if (rectangle.Left <= gameObj.boundingBox.Center.X && gameObj.boundingBox.Center.X <= rectangle.Right)
            {
                gameObj.HorizontalRepulsion();
            }
            else if (rectangle.Top <= gameObj.boundingBox.Center.Y && gameObj.boundingBox.Center.Y <= rectangle.Bottom)
            {
                gameObj.HorizontalRepulsion();
            }
        }

    }
}
