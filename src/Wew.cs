using System.Collections.Generic;
using Foster.Framework;

using Wew.Entities;

namespace Wew
{
    public class Wew : Module
    {
        public const int WINDOW_WIDTH = 1280;
        public const int WINDOW_HEIGHT = 720;

        public static readonly Batch2D Batcher = new Batch2D();
        // public float Offset = 0f;

        protected readonly List<AbstractEntity> entities = new List<AbstractEntity>();
        public List<AbstractEntity> Entities { get => entities; }

        // This is called when the Application has Started
        protected override void Startup()
        {
            // Add a Callback to the primary window's Render loop
            App.Window.OnRender += Render;

            entities.Add(new Player());
        }

        // This is called when the Application is shutting down, or when the Module is removed
        protected override void Shutdown()
        {
            // Remove our Callback
            App.Window.OnRender -= Render;

            foreach (AbstractEntity e in entities)
            {
                e.Cleanup();
            }
            entities.Clear();
        }

        // This is called every frame of the Application
        protected override void Update()
        {
            // Offset += 32 * Time.Delta;
            foreach (AbstractEntity e in entities)
            {
                e.Update();
            }

            if (App.Input.Keyboard.Pressed(Keys.Escape))
            {
                Shutdown(); // TODO malloc, deallocating pointer error somewhere
                App.Exit();
            }
        }

        private void Render(Window window)
        {
            // clear the batcher from the previous frame
            Batcher.Clear();

            // draw a rectangle
            // Batcher.Rect(Offset, 0, 32, 32, Color.Red);

            foreach (AbstractEntity e in entities)
            {
                e.Render();
            }

            // clear the Window
            App.Graphics.Clear(window, Color.Black);

            // draw the batcher to the Window
            Batcher.Render(window);
        }
    }
}