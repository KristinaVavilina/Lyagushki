using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyagushki
{
    public class Menu
    {
        public static Texture2D Background { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }
        public static SpriteFont Font { get; set; }
        public static SpriteFont FontBig { get; set; }
        static int Width;
        static int Height;

        public static int optionsCounter = 1;
        public static MenuOptions option = MenuOptions.Play;
        static string play = "Play";
        static string training = "Training";
        static string exit = "Exit";

        public enum MenuOptions
        {
            Play,
            Training,
            Exit
        }

        public static void Init(SpriteBatch spriteBatch, int Width, int Height)
        {
            Menu.SpriteBatch = spriteBatch;
            Menu.Width = Width;
            Menu.Height = Height;
        }

        public static int OptionsCounter
        {
            get
            {
                return optionsCounter;
            }

            set
            {
                if (value > 3) optionsCounter = 3;
                if (value < 1) optionsCounter = 1;
                else optionsCounter = value;
                if (optionsCounter == 1) option = MenuOptions.Play;
                else if (optionsCounter == 2) option = MenuOptions.Training;
                else option = MenuOptions.Exit;
            }
        }

        public static void Draw()
        {
            SpriteBatch.Draw(Background, Vector2.Zero, Color.White);
            /*  60 - размер шрифта MenuFont
                (Height - 60*3 - 60/3*2)/2
                (y2 = y1 + 60 + 60/2)
                (y3 = y2 + 60 + 60/2)       */
            var playLocationY = Height/2 - 120;
            var trainingLocationY = playLocationY + 90;
            var exitLocationY = trainingLocationY + 90;

            /* k - количество букв в строке
               (Width - k * 80) / 2
                locationX - расположение по х самого длинного слова */

            var locationX = Width / 2 - 240;

            if (option == MenuOptions.Play) SpriteBatch.DrawString(FontBig, play, new Vector2(locationX, playLocationY), Color.Black);
            else SpriteBatch.DrawString(Font, play, new Vector2(locationX, playLocationY), Color.White); 

            if (option == MenuOptions.Training) SpriteBatch.DrawString(FontBig, training, new Vector2(locationX, trainingLocationY), Color.Black);
            else SpriteBatch.DrawString(Font, training, new Vector2(locationX, trainingLocationY), Color.White);

            if (option == MenuOptions.Exit) SpriteBatch.DrawString(FontBig, exit, new Vector2(locationX, exitLocationY), Color.Black);
            else SpriteBatch.DrawString(Font, exit, new Vector2(locationX, exitLocationY), Color.White);
        }
    }
}
