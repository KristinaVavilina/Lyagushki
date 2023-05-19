using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Lyagushki
{
    public class GamePlay
    {
        public static Texture2D Hunger1 { get; set; }
        public static Texture2D Hunger2 { get; set; }
        public static Texture2D Hunger3 { get; set; }
        public static Texture2D Hunger4 { get; set; }
        public static Texture2D Hunger5 { get; set; }
        public static Texture2D Hunger6 { get; set; }
        public static Texture2D Hunger7 { get; set; }
        public static Texture2D Hunger8 { get; set; }
        public static Texture2D Hunger9 { get; set; }
        public static Texture2D Hunger10 { get; set; }
        public static Texture2D Hunger11 { get; set; }
        public static Texture2D Hunger12 { get; set; }
        public static Texture2D Hunger13 { get; set; }
        public static Texture2D Hunger14 { get; set; }
        public static Texture2D Hunger15 { get; set; }
        public static Texture2D Hunger16 { get; set; }
        public static Texture2D Hunger17 { get; set; }
        public static Texture2D Hunger18 { get; set; }
        public static Texture2D Hunger19 { get; set; }
        public static Texture2D Hunger20 { get; set; }
        public static Texture2D Hunger21 { get; set; }
        public static Texture2D Hunger22 { get; set; }
        public static Texture2D Hunger23 { get; set; }
        public static Texture2D Background { get; set; }
        public static SpriteBatch spriteBatch { get; set; }

        public static int Width, Height, timeCounter;
        public static int index = 22;
        public static Vector2 position;

        public static MouseState lastMouseState;

        public static void Init(int Width, int Height, SpriteBatch spriteBatch)
        {
            GamePlay.spriteBatch = spriteBatch;
            GamePlay.Width = Width;
            GamePlay.Height = Height;
            //IsMouseVisible = true;
        }

        public static void Draw()
        {
            var textursHunger = new Texture2D[]
            {
                Hunger1, Hunger2, Hunger3, Hunger4, Hunger5, Hunger6, Hunger7, Hunger8,
                Hunger9, Hunger10, Hunger11, Hunger12, Hunger13, Hunger14, Hunger15, Hunger16,
                Hunger17, Hunger18, Hunger19, Hunger20, Hunger21, Hunger22, Hunger23
            };

            spriteBatch.Draw(Background, new Rectangle(0, 0, 1366, 768), Color.White);
            spriteBatch.Draw(textursHunger[index], Vector2.Zero, Color.White);
            TextureHunger();
        }

        public static void Update()
        {
            timeCounter++;

            //MouseState currentMouseState = Mouse.GetState();

            //if (currentMouseState.X != lastMouseState.X ||
            //    currentMouseState.Y != lastMouseState.Y)
            //    position = new Vector2(currentMouseState.X, currentMouseState.Y);
            //lastMouseState = currentMouseState;
        }

        public static void TextureHunger()
        {
            if (timeCounter % 10 == 0 && index != -1) index--;
            if (index == -1)
            {
                index = 22;
                MoveFrog.Index = 1;
            }
        }

        public static void InteractionCursorAndFly()
        {
            //if (Mouse.GetState().LeftButton)
        }
    }

    public class Timer
    {
        public static float Time { get; private set; }

        public static void Update(GameTime gameTime)
        {
            Time = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
