using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;     // для ContentManager
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Arkanoid.Classes
{
    class Platform
    {
        // поля
        public Texture2D texture;
        public Vector2 position;



        public int speed;



        public Rectangle destinationRectangle;
        // данные


        public Platform()
        {


            position = new Vector2(400, 500);
            texture = null;
            speed = 6;
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("Platform");


        }

        // прорисовка
        public void Draw(SpriteBatch brush)
        {
            brush.Draw(texture, destinationRectangle, Color.White);


        }

        // логика
        public void Update()
        {
            // Считывание статуса клавиатуры
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.Left))
            {
                position.X -= speed;
            }
            if (keyState.IsKeyDown(Keys.D) || keyState.IsKeyDown(Keys.Right))
            {
                position.X += speed;
            }


            if (position.X <= 0)
            {

                position.X = 0;
            }
            if (position.Y <= 0)
            {
                position.Y = 0;
            }
            if (position.X + destinationRectangle.Width >= 800)
            {
                position.X = 800 - destinationRectangle.Width;
            }
            if (position.Y + destinationRectangle.Height >= 600)
            {
                position.Y = 600 - destinationRectangle.Height;
            }

            if (Game1.newFlag)
            {
                destinationRectangle = new Rectangle((int)position.X,
(int)position.Y, texture.Width - 120, texture.Height - 90);
            }
            else
            {
                destinationRectangle = new Rectangle((int)position.X,
(int)position.Y, texture.Width - 220, texture.Height - 90);
            }



        }

    }
}