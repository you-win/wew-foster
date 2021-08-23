using System.Numerics;
using Foster.Framework;

namespace Wew.Entities
{
    public class Player : AbstractEntity
    {
        public Player()
        {
            speed = 500;
            position = new Vector2(Wew.WINDOW_WIDTH / 2, Wew.WINDOW_HEIGHT / 2);

            CreateResetVars();
        }

        public override void Cleanup()
        {

        }

        public override void Ready()
        {
            // TODO in theory this should be added when entering the scene
        }

        public override void Render()
        {
            Wew.Batcher.RoundedRect(position.X, position.Y, 128, 128, 5, Color.Blue);
        }

        public override void Update()
        {
            if (App.Input.Keyboard.Down(Keys.W))
            {
                position.Y -= speed * Time.Delta;
            }
            if (App.Input.Keyboard.Down(Keys.S))
            {
                position.Y += speed * Time.Delta;
            }
            if (App.Input.Keyboard.Down(Keys.A))
            {
                position.X -= speed * Time.Delta;
            }
            if (App.Input.Keyboard.Down(Keys.D))
            {
                position.X += speed * Time.Delta;
            }
        }
    }
}