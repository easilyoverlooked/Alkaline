using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alkaline
{
    public class Sprite
    {
        private readonly Texture2D texture;
        private readonly Vector2 size;
        private readonly Vector2 origin;

        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        public float Rotation { get; set; }
        public Color Color { get; set; }    

        public Rectangle Collision
        {
            get
            {
                Vector2 position = this.Position;
                Vector2 actualScale = this.size * this.Scale;
                Vector2 offset = this.size * this.origin;
                return new Rectangle(
                    (int)(position.X - offset.X),
                    (int)(position.Y - offset.Y),
                    (int)actualScale.X,
                    (int)actualScale.Y);
            }
        }

        public Sprite(Texture2D texture, Vector2 size, Vector2 origin)
        {
            this.texture = texture;
            this.size = size;
            this.origin = origin;
            this.Scale = Vector2.One;
            this.Color = Color.White;
        }

        public Sprite(Texture2D texture, Vector2 size)
            : this(texture, size, new Vector2(texture.Width / 2f, texture.Height / 2f)) { }
         
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture: this.texture,
                position: this.Position,
                origin: this.origin,
                color: this.Color,
                rotation: this.Rotation,
                scale: this.size * this.Scale);
            spriteBatch.Draw(
                texture: this.texture,
                position: this.Position,
                origin: this.origin,
                color: Color.Black);
        }

    }
}
