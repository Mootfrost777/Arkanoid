using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

using Arkanoid.Classes;
using System.IO;
using System;
using System.Linq;

//using MonoGame_Textbox;
//using MonoGame_Test;

namespace Arkanoid
{
    public enum GameState { Menu, Game, Exit, Info, GameOver, Pause, Win, NameEnter, History}
    public class Game1 : Game
    {
        public static int score = 0;
        public static int levels = 10;
        public static string name = "";
        public static bool newFlag = false;
        Label labInfo = new Label("Welcome to our new game called \n" +
            "Arkanoid! If you want to win, you need to \n" +
            "complete ten levels using the platform \n" +
            "to control the ball!",
            new Vector2(0, 100), Color.Yellow);
        public static GameState gameState = GameState.Menu;
        public GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public string f;
        SoundEffect ExplosionSong;
        SoundEffect ExplosionSong2;
        SoundEffect ExplosionSong3;
        Bricks bricks = new Bricks();
        Ball ball = new Ball();
        Platform platform = new Platform();
        Background background = new Background();
        GameOver gameOver = new GameOver();
        Label lab1;
        Label er = new Label("Your name:" + name, new Vector2(200, 0), Color.Black);
        Label lev = new Label("level:" + levels.ToString(), new Vector2(0, 0), Color.AliceBlue);
        Label yourname = new Label("Please, write your name", new Vector2(200, 300), Color.Black);
        Cube cube = new Cube();
        Menu menu = new Menu();
        Label winner = new Label("Level completed!", new Vector2(240, 300), Color.Yellow);
        Win win = new Win();
        public Song song;
        NameEnter nameEnter = new NameEnter();
        History history = new History();
        //public TextBox textBox;
        public SpriteFont font;
        public Rectangle viewport;
        public static bool isBoss = false;
        public static float xforboss;
        public static float yforboss;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            f = score.ToString();
            lab1 = new Label("Score " + f, new Vector2(0, 50), Color.Yellow);
            //MonoGame_Textbox.KeyboardInput.Initialize(this, 500f, 20);
           // _graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            MediaPlayer.Volume = 0.15f;
            ExplosionSong = Content.Load<SoundEffect>("Explosion");
            ExplosionSong2 = Content.Load<SoundEffect>("Explosion2");
            ExplosionSong3 = Content.Load<SoundEffect>("Explosion3");
            lab1.LoadContent(Content);
            bricks.LoadContent(Content);
            bricks.ResetBricks(levels);
            ball.LoadContent(Content, platform.position);
            platform.LoadContent(Content);
            menu.LoadContent(Content);
            gameOver.LoadContent(Content);
            background.LoadContent(Content);
            labInfo.LoadContent(Content);
            song = Content.Load<Song>("MainSong");
            winner.LoadContent(Content);
            nameEnter.LoadContent(Content);
            history.LoadContent(Content);
            er.LoadContent(Content);
            lev.LoadContent(Content);
            yourname.LoadContent(Content);
            cube.LoadContent(Content);
            MediaPlayer.IsRepeating = true;
            // прикрепляем обработчик изменения состояния проигрывания мелодии
            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
            font = Content.Load<SpriteFont>("GameFont");
            viewport = new Rectangle(280, 200, 200, 100);
            //textBox = new TextBox(viewport, 30, "", GraphicsDevice, font, Color.White, Color.DarkGreen, 30);
            //textBox.EnterDown += Enter;
            //textBox.Active = true;
        }
        void MediaPlayer_MediaStateChanged(object sender, System.EventArgs e)
        {
            MediaPlayer.Volume = 40;
        }

        private void Enter(object sender/*, MonoGame_Textbox.KeyboardInput.KeyEventArgs */)
        {
            //name = textBox.Text.String;
            er.Text = "Your name: " + name;
            gameState = GameState.Menu;
            //textBox.Active = false;
            menu.prevKeyboard = Keyboard.GetState();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Game1.gameState = GameState.Menu;
                MediaPlayer.Stop();
            }

            // TODO: Add your update logic here
            switch (gameState)
            {
                case GameState.Pause:
                    break;
                case GameState.GameOver:
                    gameOver.Update();
                    // gameover.Update(_spriteBatch);
                    break;
                case GameState.Menu:
                    //MonoGame_Textbox.KeyboardInput.Update();
                    background.Update();
                    menu.Update(song);
                    break;
                case GameState.Game:
                    UpdateGame();
                    break;
                case GameState.Exit:
                    Exit();
                    break;
                case GameState.Win:
                    background.Update();
                    win.Update();
                    break;
                case GameState.Info:
                    background.Update();
                    break;
                case GameState.NameEnter:
                    background.Update();
                    //MonoGame_Textbox.KeyboardInput.Update();
                    //textBox.Update();
                    break;
                case GameState.History:
                    background.Update();
                    break;
                default:
                    break;
            }
            base.Update(gameTime);
        }
        public void UpdateGame()
        {
            if (isBoss == true)
            {
                if (platform.destinationRectangle.Intersects(cube.dest))
                {
                    Random r = new Random();
                    int r1 = r.Next(0, 2);
                    Game1.isBoss = false;
                    if (r1 == 1)
                    {
                        int u = ball.speed2 + ball.speed1;
                        if (u >= 100 * (-1))
                        {
                            ball.speed1 -= 30;
                            ball.speed2 -= 30;
                        }

                        if (platform.speed > 3)
                        {
                            platform.speed -= 1;
                        }
                    }
                    else
                    {
                        newFlag = true;
                    }

                    //изменить спиид 
                }
                cube.Update();
            }
            f = score.ToString();
            lab1.Text = "Score " + score.ToString();
            // TODO: Add your update logic here
            ball.UpdateBall(platform, platform.position, f, bricks, ExplosionSong, ExplosionSong2, ExplosionSong3, levels, cube);
            bricks.Update(levels);
            background.Update();
            er.Text = "Your name:" + name;
            lev.Text = "level:" + levels;
            platform.Update();
            cube.Update();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);

            switch (gameState)
            {
                case GameState.Pause:
                    break;
                case GameState.GameOver:
                    background.Draw(_spriteBatch);
                    gameOver.Draw(_spriteBatch);
                    // gameover.Draw(_spriteBatch);
                    break;
                case GameState.Menu:
                    background.Draw(_spriteBatch);
                    menu.Draw(_spriteBatch);
                    break;
                case GameState.Game:
                    DrawGame();
                    break;
                case GameState.Win:
                    background.Draw(_spriteBatch);
                    winner.Draw(_spriteBatch);
                    break;
                case GameState.Info:
                    background.Draw(_spriteBatch);
                    labInfo.Draw(_spriteBatch);
                    break;
                case GameState.NameEnter:
                    background.Draw(_spriteBatch);
                    //textBox.Draw(_spriteBatch);
                    yourname.Draw(_spriteBatch);
                    //_spriteBatch.DrawRectangle(viewport, Color.Red, 1f, 1f);
                    break;
                case GameState.History:
                    background.Draw(_spriteBatch);
                    history.Draw(_spriteBatch);
                        break;
                default:
                    break;
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public void DrawGame()
        {
            background.Draw(_spriteBatch);
            platform.Draw(_spriteBatch);
            er.Draw(_spriteBatch);
            bricks.Draw(_spriteBatch, levels);
            ball.Draw(_spriteBatch);
            lev.Draw(_spriteBatch);
            lab1.Draw(_spriteBatch);
            if (isBoss == true)
            {
                cube.Draw(_spriteBatch);
            }
        }

        public static void SaveHistory()
        {
            StreamWriter r = new StreamWriter("GameHistory.txt", true);
            r.WriteLine("Player: " + name + ", score: " + score);
            r.Close();
        }
        public static void SaveBestScore()
        {
            StreamReader r = new StreamReader("BestScore.txt");
            string a = r.ReadLine();
            r.Close();
            if (int.Parse(a) <= score)
            {
                StreamWriter w = new StreamWriter("BestScore.txt");
                w.WriteLine(score);
                w.Close();
            }

        }
    }
}