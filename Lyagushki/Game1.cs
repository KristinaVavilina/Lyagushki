using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lyagushki
{
    enum Stat
    {
        SplashScreen,
        Game,
        Menu,
    }

    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        Stat Stat = Stat.SplashScreen;
        SpriteFont Font;
        KeyboardState keyboardState2;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1366;
            graphics.PreferredBackBufferHeight = 768;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            SplashScreen.Background = Content.Load<Texture2D>("Background(1366,768)");
            SplashScreen.Font = Content.Load<SpriteFont>("SplashFont");

            WaterLilies.Init(spriteBatch, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            Lilies.Lily1 = Content.Load<Texture2D>("Lily1");
            Lilies.Lily2 = Content.Load<Texture2D>("Lily2");
            Lilies.Lily3 = Content.Load<Texture2D>("Lily3");
            Lilies.DeadLily = Content.Load<Texture2D>("DeadLily");
            Lilies.LilyFlower = Content.Load<Texture2D>("LilyFlower");

            GamePlay.Hunger1 = Content.Load<Texture2D>("Hunger/Hunger1");
            GamePlay.Hunger2 = Content.Load<Texture2D>("Hunger/Hunger2");
            GamePlay.Hunger3 = Content.Load<Texture2D>("Hunger/Hunger3");
            GamePlay.Hunger4 = Content.Load<Texture2D>("Hunger/Hunger4");
            GamePlay.Hunger5 = Content.Load<Texture2D>("Hunger/Hunger5");
            GamePlay.Hunger6 = Content.Load<Texture2D>("Hunger/Hunger6");
            GamePlay.Hunger7 = Content.Load<Texture2D>("Hunger/Hunger7");
            GamePlay.Hunger8 = Content.Load<Texture2D>("Hunger/Hunger8");
            GamePlay.Hunger9 = Content.Load<Texture2D>("Hunger/Hunger9");
            GamePlay.Hunger10 = Content.Load<Texture2D>("Hunger/Hunger10");
            GamePlay.Hunger11 = Content.Load<Texture2D>("Hunger/Hunger11");
            GamePlay.Hunger12 = Content.Load<Texture2D>("Hunger/Hunger12");
            GamePlay.Hunger13 = Content.Load<Texture2D>("Hunger/Hunger13");
            GamePlay.Hunger14 = Content.Load<Texture2D>("Hunger/Hunger14");
            GamePlay.Hunger15 = Content.Load<Texture2D>("Hunger/Hunger15");
            GamePlay.Hunger16 = Content.Load<Texture2D>("Hunger/Hunger16");
            GamePlay.Hunger17 = Content.Load<Texture2D>("Hunger/Hunger17");
            GamePlay.Hunger18 = Content.Load<Texture2D>("Hunger/Hunger18");
            GamePlay.Hunger19 = Content.Load<Texture2D>("Hunger/Hunger19");
            GamePlay.Hunger20 = Content.Load<Texture2D>("Hunger/Hunger20");
            GamePlay.Hunger21 = Content.Load<Texture2D>("Hunger/Hunger21");
            GamePlay.Hunger22 = Content.Load<Texture2D>("Hunger/Hunger22");
            GamePlay.Hunger23 = Content.Load<Texture2D>("Hunger/Hunger23");

            GamePlay.Background = Content.Load<Texture2D>("Swamp");
            GamePlay.Init(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight, spriteBatch);

            Frog.Init(spriteBatch, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            MoveFrog.TextureFrog = Content.Load<Texture2D>("Frog(1)");
            MoveFrog.TextureFrogDead = Content.Load<Texture2D>("Frog(2)");

            Menu.Init(spriteBatch, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            Menu.Font = Content.Load<SpriteFont>("MenuFont");
            Menu.FontBig = Content.Load<SpriteFont>("MenuFontBig");
            Menu.Background = Content.Load<Texture2D>("BackgroundMenu");

            Fly.TextureFly = Content.Load<Texture2D>("Fly");
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            switch (Stat)
            {
                case Stat.SplashScreen:
                    SplashScreen.Update();
                    if (keyboardState.IsKeyDown(Keys.Space)) Stat = Stat.Game;
                    break;
                case Stat.Game:
                    WaterLilies.Update();
                    Frog.Update();
                    GamePlay.Update();
                    if (keyboardState.IsKeyDown(Keys.Escape)) Stat = Stat.Menu;
                    if (keyboardState.IsKeyDown(Keys.Space)) Frog.MoveFrog.Jump();
                    if (keyboardState.IsKeyDown(Keys.W)) Frog.MoveFrog.Up();
                    if (keyboardState.IsKeyDown(Keys.A)) Frog.MoveFrog.Left();
                    if (keyboardState.IsKeyDown(Keys.D)) Frog.MoveFrog.Right();
                    if (keyboardState.IsKeyDown(Keys.S)) Frog.MoveFrog.Down();
                    if (keyboardState.IsKeyUp(Keys.Space)) MoveFrog.endJump = false;

                    break;
                case Stat.Menu:
                    if (keyboardState.IsKeyDown(Keys.W) && keyboardState2.IsKeyUp(Keys.W)) Menu.OptionsCounter--;
                    if (keyboardState.IsKeyDown(Keys.S) && keyboardState2.IsKeyUp(Keys.S)) Menu.OptionsCounter++;
                    if (keyboardState.IsKeyDown(Keys.Enter))
                    {
                        switch (Menu.option)
                        {
                            case Menu.MenuOptions.Play:
                                Stat = Stat.Game;
                                break;
                            case Menu.MenuOptions.Training:
                                break;
                            case Menu.MenuOptions.Exit:
                                Exit();
                                break;
                        }
                    }
                    break;
            }
            keyboardState2 = keyboardState;
            base.Update(gameTime);
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.Escape))
            //    Exit();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            switch (Stat)
            {
                case Stat.SplashScreen:
                    SplashScreen.Draw(spriteBatch);
                    break;
                case Stat.Game:
                    GamePlay.Draw();
                    WaterLilies.Draw();
                    Frog.Draw();
                    break;
                case Stat.Menu:
                    Menu.Draw();
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}