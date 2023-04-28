using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyagushki
{
    static class SplashScreen
    {
        public static Texture2D Background { get; set; }
        static Color color;
        public static SpriteFont Font { get; set; }
        static int timeCounter = 0;

        public static float weidthTextInSM = 13.6f;
        public static float heightTextInSM = 0.9f;

        public static float weidthWindowInSM = 24.5f;
        public static float heightWindowInSM = 14.5f;

        static float weidthWindow = Game1.graphics.PreferredBackBufferWidth;///1366
        static float heightWindow = Game1.graphics.PreferredBackBufferHeight;///768

        static float positionX = weidthWindow / weidthWindowInSM * (weidthWindowInSM / 2 - weidthTextInSM/2);
        static float positionY = heightWindow / heightWindowInSM * (heightWindowInSM / 2 - heightTextInSM);


        static Vector2 textPosition = new Vector2(positionX, positionY);

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Background, Vector2.Zero, Color.White);
            spriteBatch.DrawString(Font, "water lilies", textPosition, color);
        }

        public static void Update()
        {
            var array = Enumerable.Range(0, 256).ToArray();
            var newArray = array.Concat(array.Reverse()).Where(x => x % 4 == 0).ToArray();
            color = Color.FromNonPremultiplied(255, 255, 255, newArray[timeCounter%128]);
            timeCounter++;
        }
    }
}
