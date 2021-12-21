using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;     // для ContentManager
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Arkanoid.Classes
{
    class Win
    {
        private KeyboardState keyboard; 
        private KeyboardState prevKeyboard; 
        public void Update()
        {
            keyboard = Keyboard.GetState();

            if ((keyboard.IsKeyDown(Keys.Enter) && (keyboard != prevKeyboard)))
            {
                Game1.gameState = GameState.Game;
            }
        }
    }
}
