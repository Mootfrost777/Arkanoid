using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Text;
namespace Arkanoid.Classes
{
    class GameOver
    {
        private SpriteFont spriteFont;
        private Color defaultColor;
        public Vector2 Position { get; set; }
        public string Text { get; set; }
        public Color Color { get; set; }
        private bool isReset = false;
        private KeyboardState keyboard;
        private KeyboardState prevKeyboard;
        public GameOver()
        {
            Position = new Vector2(270, 300);
            Text = "GAME OVER!";
            Color = Color.Red;
            defaultColor = Color;
        }
        public void LoadContent(ContentManager manager)
        {
            spriteFont = manager.Load<SpriteFont>("GameOverFont");
            
        }
        public void Draw(SpriteBatch brush)
        {
            brush.DrawString(spriteFont, Text, Position, Color);
        }
        public void Update()
        {
            keyboard = Keyboard.GetState();
            if (prevKeyboard.IsKeyDown(Keys.Enter) && (keyboard != prevKeyboard))
            {
                if (keyboard.IsKeyUp(Keys.Enter))
                {
                    
                    Game1.gameState = GameState.Menu;
                    isReset = true;
                }
            }
            prevKeyboard = keyboard;
        }
    }
}
