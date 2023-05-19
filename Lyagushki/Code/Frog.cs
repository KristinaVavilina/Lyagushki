using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.CompilerServices;

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

            MoveFrog = new MoveFrog(new Vector2(350, (250 - 164) / 2));
        }

        public static void Draw()
        {
            MoveFrog.Draw();
        }

        public static void Update()
        {
            MoveFrog.Update();
        }
    }

    public class MoveFrog
    {
        static Color color = Color.White;
        Vector2 position;

        public static Texture2D TextureFrog { get; set; }
        public static Texture2D TextureFrogDead { get; set; }

        public static int Speed { get; set; } = 2;
        public static int JumpLength { get; set; } = 250;
        public static int SuperJumpLength { get; set; } = 325;

        public static bool endJump;
        public static bool jump;

        public static int Index { get; set; } = 0;

        public MoveFrog(Vector2 position)
        {
            this.position = position;
        }

        public void Update()
        {
            position += new Vector2(0, 3);
        }

        public void Right()
        {
            if (position.X < Frog.Width - TextureFrog.Width) position.X += Speed;
        }

        public void Left()
        {
            if (position.X > 0) position.X -= Speed;
        }

        public void Up()
        {
            if (position.Y > 0) position.Y -= Speed;
        }

        public void Down()
        {
            if (position.Y < Frog.Height - TextureFrog.Height) position.Y += Speed;
        }

        public void Jump()
        {
            var kgs = Keyboard.GetState();
            if (InTheWindow())
            {
                if (kgs.IsKeyDown(Keys.W))
                    position.Y -= JumpLength;
                if (kgs.IsKeyDown(Keys.A))
                    position.X -= JumpLength;
                if (kgs.IsKeyDown(Keys.D))
                    position.X += JumpLength;
            }
            endJump = true;
        }

        public void Draw()
        {
            var textursFrog = new Texture2D[] { TextureFrog, TextureFrogDead };
            Frog.SpriteBatch.Draw(textursFrog[Index], position, color);
        }

        public bool InTheWindow() => (position.Y > 0 && position.X > 0 && !endJump && (position.X < Frog.Width - TextureFrog.Width));

        public void InteractionWithLilies()
        {
            
        }
    }
}
