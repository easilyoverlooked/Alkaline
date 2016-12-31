using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alkaline
{
    public class Player
    {
        private readonly Sprite sprite;
        private readonly InputManager input;

        public float Speed { get; set; }

        public Player(Sprite sprite, InputManager input)
        {
            this.sprite = sprite;
            this.input = input;
        }

        public void Update(GameTime gameTime)
        {
            float movementSpeed = (float)(gameTime.ElapsedGameTime.TotalMilliseconds * Speed);
            float rotationSpeed = movementSpeed * 0.0075f;

            float rotation = this.sprite.Rotation;
            Vector2 position = this.sprite.Position;
            if (this.input.IsKeyDown(Keys.W))
            {
                position.Y -= movementSpeed;
            }
            if (this.input.IsKeyDown(Keys.S))
            {
                position.Y += movementSpeed;
            }
            if (this.input.IsKeyDown(Keys.D))
            {
                position.X += movementSpeed;
            }
            if (this.input.IsKeyDown(Keys.A))
            {
                position.X -= movementSpeed;
            }
            if(this.input.IsKeyDown(Keys.Q))
            {
                rotation -= rotationSpeed;
            }
            if(this.input.IsKeyDown(Keys.E))
            {
                rotation += rotationSpeed;
            }
            this.sprite.Position = position;
            this.sprite.Rotation = rotation;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
        }

    }
}
