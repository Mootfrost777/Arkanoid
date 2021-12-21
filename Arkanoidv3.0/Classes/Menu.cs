using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;     // для ContentManager
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Arkanoid.Classes
{
    class Menu
    {
        private List<Label> items;
        private string[] texts = { "Play", "Info", "History", "Exit" };
        private int selected = 0;
        private KeyboardState keyboard;

        public KeyboardState prevKeyboard;
        SoundEffect MenuSound;
        SoundEffect SelectSound;

        public Vector2 Position { get; set; }

        public Menu()
        {
            items = new List<Label>();

            Vector2 position = new Vector2(350, 300);
            for (int i = 0; i < texts.Length; i++)
            {
                Label label = new Label(texts[i], position, Color.Yellow);
                items.Add(label);

                position.Y += 40;
            }
        }

        public void SetMenuPosition(Vector2 Position)
        {
            this.Position = Position;
            for (int i = 0; i < items.Count; i++)
            {
                items[i].Position = Position;
                Position.Y += 30;
            }
        }

        public void LoadContent(ContentManager Content)
        {
            foreach (Label item in items)
            {
                item.LoadContent(Content);
            }
            MenuSound = Content.Load<SoundEffect>("MenuSong");
            SelectSound = Content.Load<SoundEffect>("Select");
        }

        public void Update(Song song)
        {
            keyboard = Keyboard.GetState();

            // Down
            if ((keyboard.IsKeyDown(Keys.S) || keyboard.IsKeyDown(Keys.Down))  && (keyboard != prevKeyboard))
            {
                if (selected < items.Count - 1)
                {
                    SelectSound.Play();
                    items[selected].ResetColor();
                    selected++;
                }
            }

            if ((keyboard.IsKeyDown(Keys.W) || keyboard.IsKeyDown(Keys.Up)) && (keyboard != prevKeyboard))
            {
                if (selected > 0)
                {
                    SelectSound.Play();
                    items[selected].ResetColor();
                    selected--;
                }
            }

            // Enter - выбор в меню
            if (keyboard.IsKeyDown(Keys.Enter) && (keyboard != prevKeyboard))
            {
                MenuSound.Play();
                switch (selected)
                {
                    case 0:
                        Game1.gameState = GameState.Game;
                        MediaPlayer.Play(song);
                        break;
                    case 1:
                        Game1.gameState = GameState.Info;
                        //Game1.gameState = GameState.Win;
                        break;
                    case 3:
                        Game1.gameState = GameState.Exit;
                        break;
                    case 2:
                        Game1.gameState = GameState.History;
                        break;
                    default:
                        break;
                }
            }

            prevKeyboard = keyboard;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            items[selected].Color = Color.Green;

            foreach (var item in items)
            {
                item.Draw(spriteBatch);
            }
        }
    }
}
