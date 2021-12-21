using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arkanoid.Classes
{
    public class GameObj 
    {
        public Color Color;
        public Texture2D texture { get; set; }
        public Vector2 Position;
        public Vector2 Speed;
        public int Width { get { return texture.Width; } }
        public int Height { get { return texture.Height; } }
        public bool IsAlive { get; set; }
        public Rectangle boundingBox
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
            }
        }
        
        

        public GameObj(Texture2D texture)
        {
            this.texture = texture;
            IsAlive = true;
            Position = Vector2.Zero;
            Speed = Vector2.Zero;
        }
        public void HorizontalRepulsion()
        {
            Speed.Y = -Speed.Y;
        }
        public void VerticalRepulsion()
        {
           Speed.X = -Speed.X;
        }
    }
}