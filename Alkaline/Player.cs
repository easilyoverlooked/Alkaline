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
            float movement = gameTime.ElapsedGameTime.Milliseconds * Speed;
            Vector2 playerPosition = this.sprite.Position;
            if (this.input.IsKeyDown(Keys.W))
            {
                playerPosition.Y -= movement;
            }
            if (this.input.IsKeyDown(Keys.S))
            {
                playerPosition.Y += movement;
            }
            if (this.input.IsKeyDown(Keys.D))
            {
                playerPosition.X += movement;
            }
            if (this.input.IsKeyDown(Keys.A))
            {
                playerPosition.X -= movement;
            }
            this.sprite.Position = playerPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
        }

    }
}
