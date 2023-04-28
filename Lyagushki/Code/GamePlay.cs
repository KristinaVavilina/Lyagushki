using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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

        public static Texture2D Background { get; set; }

        public static int Width;
        public static int Height;

        public static SpriteBatch spriteBatch { get; set; }

        public static void Init(int Width, int Height, SpriteBatch spriteBatch)
        {
            GamePlay.spriteBatch = spriteBatch;
            GamePlay.Width = Width;
            GamePlay.Height = Height;
        }

        public static void Draw()
        {
            var texturesHunger = new Texture[]
            {
                Hunger1, Hunger2, Hunger3, Hunger4, Hunger5, Hunger6, Hunger7, Hunger8,
                Hunger9, Hunger10, Hunger11, Hunger12, Hunger13, Hunger14, Hunger15, Hunger16,
                Hunger17, Hunger18, Hunger19, Hunger20, Hunger21, Hunger22,
            };

            spriteBatch.Draw(Background, new Rectangle(0, 0, 1366, 768), Color.White);
            spriteBatch.Draw(Hunger1, Vector2.Zero, Color.White);
        }

        public static void Update()
        {
        }
    }
}
