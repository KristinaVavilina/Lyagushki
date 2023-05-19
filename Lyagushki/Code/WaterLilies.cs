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
        public static Lilies[] lilies;
        static Fly fly;

        public static void Init(SpriteBatch SpriteBatch, int Width, int Height)
        {
            WaterLilies.Width = Width;
            WaterLilies.Height = Height;
            WaterLilies.SpriteBatch = SpriteBatch;
            lilies = new Lilies[5];

            float x1 = 300;
            float x2 = 550;
            float x3 = 800;
            float y1 = 0;
            float y2 = 250;
            float y3 = 500;
            float y4 = 750;

            var pos1 = new Vector2[] { new Vector2(x1, y1),
                                       new Vector2(x3, y1),
                                       new Vector2(x2, y2),
                                       new Vector2(x3, y3),
                                       new Vector2(x2, y4) };

            for (var i = 0; i < lilies.Length; i++)
            {
                lilies[i] = new Lilies(pos1[i], new Vector2(0,3), 0);
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
        Vector2 position, direction;
        int posTexture, index;
        int posX;
        float posCopy = 550;
        bool flag;

        public static Texture2D Lily1 { get; set; }
        public static Texture2D Lily2 { get; set; }
        public static Texture2D Lily3 { get; set; }
        public static Texture2D DeadLily { get; set; }
        public static Texture2D LilyFlower { get; set; }

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
            position += direction;

            if (position.Y >= WaterLilies.Height)
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
            float x1 = 300;
            float x2 = 550;
            float x3 = 800;

            var pos1 = new float[] { x2, x3, x2, x3, x1 };
            var pos2 = new float[] { x2, x1, x2, x3, x1 };
            var pos3 = new float[] { x2, x3, x1, x2, x3 };
            var pos4 = new float[] { x2, x1, x3, x2, x3 };

            var arrayPosX = new float[][] { pos1, pos2, pos3, pos4 };
            posX = WaterLilies.GetIntRandomValues(0, arrayPosX.Length);
            if (!flag)
            {
                index = 0;
                flag = true;
            }
            else
            {
                if (index == 3) flag = false;
                position = new Vector2(pos1[index], -250);
                index++;
            }
            //switch (posX)
            //{
            //    case 0:
            //        foreach (var x in pos1)
            //        {
            //            position = new Vector2(x, -250);
            //        }
            //        break;
            //    case 1:
            //        foreach (var x in pos2)
            //        {
            //            position = new Vector2(x, -250);
            //        }
            //        break;
            //    case 2:
            //        foreach (var x in pos3)
            //        {
            //            position = new Vector2(x, -250);
            //        }
            //        break;
            //    case 3:
            //        foreach (var x in pos4)
            //        {
            //            position = new Vector2(x, -250);
            //        }
            //        break;
            //}

            //float y1 = 0;
            //float y2 = 250;
            //float y3 = 500;
            //float y4 = 750;

            //var pos1 = new Vector2[] { new Vector2(x1, y1),
            //                           new Vector2(x3, y1),
            //                           new Vector2(x2, y2),
            //                           new Vector2(x3, y3),
            //                           new Vector2(x2, y4) };

            //var pos2 = new Vector2[] { new Vector2(x1, y1),
            //                           new Vector2(x3, y1),
            //                           new Vector2(x2, y2),
            //                           new Vector2(x1, y3),
            //                           new Vector2(x2, y4) };

            //var pos3 = new Vector2[] { new Vector2(x3, y1),
            //                           new Vector2(x2, y2),
            //                           new Vector2(x1, y3),
            //                           new Vector2(x3, y3),
            //                           new Vector2(x2, y4) };

            //var pos4 = new Vector2[] { new Vector2(x3, y1),
            //                           new Vector2(x2, y2),
            //                           new Vector2(x3, y2),
            //                           new Vector2(x2, y3),
            //                           new Vector2(x1, y4) };
            /// switch case, который будет обрабатывать позицию и внутри foreach или while, который будет задавать нужный вектор

            //var arrayPosX = new float[][] { pos1, pos2, pos3, pos4 };
            //if (!flag)
            //{
            //    posX = pos1; ///arrayPosX[WaterLilies.GetIntRandomValues(0, arrayPosX.Length - 1)];
            //    index = 0;
            //    position = new Vector2(posX[index], -250);
            //    flag = true;
            //}

            //else
            //{
            //    index++;
            //    if (index == 4) flag = false;
            //    position = new Vector2(posX[index], -250);
            //}
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
            position.Y += direction.Y;
            position.X += WaterLilies.GetIntRandomValues((int)direction.X - 5, (int)direction.X + 5);

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