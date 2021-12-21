using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Arkanoid.Classes
{
    class Background
    {
        private Texture2D texture;
        private Vector2 position1;
        private Vector2 position2;
        private int speed;
        public Background()
        {
            texture = null;
            position1 = new Vector2(0, 0);
            position2 = new Vector2(0, -995);
            speed = 1;

        }
        public void LoadContent(ContentManager dr)
        {
            texture = dr.Load<Texture2D>("newfon3");
        }
        public void Draw(SpriteBatch spr)
        {
            spr.Draw(texture, position1, Color.White);
            spr.Draw(texture, position2, Color.White);
        }
        public void Update()
        {
            position1.Y += speed;
            position2.Y += speed;


            if (position1.Y >= 995)
            {
                position1.Y = 0;
                position2.Y = -995;
            }
        }

    }
}