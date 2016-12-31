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

        public Sprite(Texture2D texture, Vector2 size, Vector2 Origin)
        {
            this.texture = texture;
            this.size = size;
            this.Scale = Vector2.One;
            this.Color = Color.White;
        }

        public Sprite(Texture2D texture, Vector2 size)
            : this(texture, size, Vector2.Zero) { }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture: this.texture,
                destinationRectangle: this.destinationRectangle,
                origin: this.origin,
                color: this.Color,
                rotation: this.Rotation,
                scale: this.Scale);       
        }

        private Rectangle destinationRectangle
        {
            get
            {
                Vector2 position = Position;
                return new Rectangle(
                    (int)position.X,
                    (int)position.Y,
                    (int)this.size.X,
                    (int)this.size.Y);
            }
        }

    }
}
