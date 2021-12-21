using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using System.IO;
using System.Linq;

namespace Arkanoid.Classes
{
    class History
    {
        private SpriteFont spriteFont;
        private Color defaultColor;
        Vector2 Position = new Vector2(0, 0);
        public string Text { get; set; } = "";
        public Color Color { get; set; }

        public History()
        {
            Color = Color.Black;
            defaultColor = Color;
        }

        public void LoadContent(ContentManager Content)
        {
            spriteFont = Content.Load<SpriteFont>("GameFont");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, "Game history:", Position, Color);
            Position.Y += 26;
            int count = File.ReadAllLines("GameHistory.txt").Length;
            int c2 = count;
            if (count >= 22) count = 22;
            for (int i = 0; i < count; i++)
            {
                spriteBatch.DrawString(spriteFont, File.ReadLines("GameHistory.txt").ElementAt(c2 - i - 1), Position, Color);
                Position.Y += 26;
            }
            Position.Y = 0;
        }
    }
}
