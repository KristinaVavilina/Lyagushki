using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lyagushki
{
    public class WaterLilies
    {
        public static GameTime GameTime;
        public static int Width, Height;
        public static Random Random = new Random();
        public static SpriteBatch SpriteBatch { get; set; }
        static Lilies[] lilies;
        static Fly fly;

        public static void Init(SpriteBatch SpriteBatch, int Width, int Height)
        {
            WaterLilies.Width = Width;
            WaterLilies.Height = Height;
            WaterLilies.SpriteBatch = SpriteBatch;
            //WaterLilies.GameTime = GameTime;
            lilies = new Lilies[8];
            for (var i = 0; i < lilies.Length; i++)
            {
                lilies[i] = new Lilies(new Vector2(0, 5));
            }
            fly = new Fly(new Vector2(0, 10));
        }

        public static int GetIntRandomValues(int min, int max)
        {
            return Random.Next(min, max);
        }

        public static void Draw()
        {
            foreach (var lily in lilies)
            {
                lily.Draw(lily);
            }

            fly.Draw();
        }

        public static void Update()
        {
            for (int i = 0; i < lilies.Length; i++)
                lilies[i].Update();
            fly.Update();
        }
    }

    public class Lilies
    {
        //double currentTime;
        //double countDuration = 2;

        Vector2 position;
        Vector2 direction;
        int posTexture;
        int timeCounter;

        public static Texture2D Lily1 { get; set; }
        public static Texture2D Lily2 { get; set; }
        public static Texture2D Lily3 { get; set; }
        public static Texture2D DeadLily { get; set; }
        public static Texture2D LilyFlower { get; set; }

        public static Vector2 positionForFrog;

        public Lilies(Vector2 Position, Vector2 Direction, int PosTexture)
        {
            this.position = Position;
            this.direction = Direction;
            this.posTexture = PosTexture;
        }

        public Lilies(Vector2 Direction)
        {
            this.direction = Direction;
        }

        public void Update()
        {
            timeCounter++;
            position += direction;
            positionForFrog = position;

            if (position.Y >= WaterLilies.Height)/* && timeCounter % 5 == 0)*/
            {
                RandomSet();
                posTexture = WaterLilies.GetIntRandomValues(0, 5);
            }
        }

        public void Draw(Lilies lily)
        {
            var textures = new Texture2D[] { Lily1, Lily2, Lily3, DeadLily, LilyFlower };
            WaterLilies.SpriteBatch.Draw(textures[lily.posTexture], position, Color.White);
        }

        public void RandomSet()
        {
            //currentTime += WaterLilies.GameTime.TotalGameTime.TotalSeconds;

            var posX = WaterLilies.GetIntRandomValues(300, WaterLilies.Width - 300 - 250);

            if (posX % 250 == 0)
            {
                position = new Vector2(posX, -170);
            }
        }
    }

    public class Fly
    {
        Vector2 position;
        Vector2 direction;

        public static Texture2D TextureFly { get; set; }

        public Fly(Vector2 Position, Vector2 Direction)
        {
            this.position = Position;
            this.direction = Direction;
        }

        public Fly(Vector2 Direction)
        {
            this.direction = Direction;
        }

        public void Update()
        {
            position += direction;

            if (position.Y >= WaterLilies.Height)
            {
                RandomSet();
            }
        }

        public void Draw()
        {
            WaterLilies.SpriteBatch.Draw(TextureFly, position, Color.White);
        }

        public void RandomSet()
        {
            var posX = WaterLilies.GetIntRandomValues(0, WaterLilies.Width);
            position = new Vector2(posX, -50);
        }
    }
}
