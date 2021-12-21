using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;


using System.Collections.Generic;
using System.IO;

using System.Text;

namespace Arkanoid.Classes
{
    class Cube
    {
        public Texture2D texture;
        public Vector2 position;
        public int Width { get { return texture.Width; } }
        public int Height { get { return texture.Height; } }
        public Rectangle dest;
        public int speed = 1;


        public Cube(float x, float y)
        {
            position = new Vector2(x, y);
        }
        public Cube()
        {

        }
        public void LoadContent(ContentManager dr)
        {
            texture = dr.Load<Texture2D>("cube2");

        }
        public void Update()
        {
            position.Y += speed;
            dest.Y += speed;
            dest = new Rectangle((int)position.X,
(int)position.Y, texture.Width, texture.Height);
        }
        public void Draw(SpriteBatch srt)
        {


            srt.Draw(texture, dest, Color.White);



        }


    }
}
