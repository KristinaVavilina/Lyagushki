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
    public class Frog
    {
        public static int Width;
        public static int Height;

        public static SpriteBatch SpriteBatch { get; set; }
        public static MoveFrog MoveFrog { get; set; }

        public static void Init(SpriteBatch spriteBatch, int Width, int Height)
        {
            Frog.SpriteBatch = spriteBatch;
            Frog.Width = Width;
            Frog.Height = Height;

            MoveFrog = new MoveFrog(new Vector2(300, 0));
        }

        public static void Draw()
        {
            MoveFrog.Draw();
        }
    }

    public class MoveFrog
    {
        static Color color = Color.White;
        Vector2 position;

        public static Texture2D TextureFrog { get; set; }
        public static Texture2D TextureFrogDead { get; set; }

        public static int Speed { get; set; } = 10;
        public static int JumpLength { get; set; } = 250;

        public static bool endJump = false;

        public MoveFrog(Vector2 position)
        {
            this.position = position;
        }

        //public void Right()
        //{
        //    if (position.X < Frog.Width - TextureFrog.Width) position.X += Speed;
        //}

        //public void Left()
        //{
        //    if (position.X > 0) position.X -= Speed;
        //}

        //public void Up()
        //{
        //    if (position.Y > 0) position.Y -= Speed;
        //}

        public void Down()
        {
            if (position.Y < Frog.Height - TextureFrog.Height) position.Y += Speed;
        }

        public void Jump()
        {
            if (position.Y > 0 && !endJump && Keyboard.GetState().IsKeyDown(Keys.W))
                position.Y -= JumpLength;

            if (position.X > 0 && !endJump && Keyboard.GetState().IsKeyDown(Keys.A))
                position.X -= JumpLength;

            if (position.X < Frog.Width - TextureFrog.Width && !endJump && Keyboard.GetState().IsKeyDown(Keys.D))
                position.X += JumpLength;

            endJump = true;
        }

        public void Draw()
        {
            Frog.SpriteBatch.Draw(TextureFrog, position, color);
        }
    }

    //public class InteractionWithLilies
    //{

    //}
}
