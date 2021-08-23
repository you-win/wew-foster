using System.Numerics;

namespace Wew.Entities
{
    public abstract class AbstractEntity
    {
        protected float speed;
        protected float initialSpeed;
        protected Vector2 position;
        protected Vector2 initialPosition;

        public AbstractEntity()
        {

        }

        public float Speed
        {
            get => speed;
            set
            {
                if (value >= 0)
                {
                    speed = value;
                }
                else
                {
                    speed = initialSpeed;
                }
            }
        }

        protected virtual void CreateResetVars()
        {
            initialSpeed = speed;
            initialPosition = position;
        }

        public abstract void Ready();

        public abstract void Update();

        public abstract void Render();

        public abstract void Cleanup();
    }
}