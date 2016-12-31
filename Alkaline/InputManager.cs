using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alkaline
{
    public class InputManager
    {
        private KeyboardState previousKeyboard;
        private KeyboardState currentKeyboard;

        public void Update(GameTime gameTime)
        {
            this.previousKeyboard = this.currentKeyboard;
            this.currentKeyboard = Keyboard.GetState();
        }

        public bool IsKeyDown(Keys key)
        {
            return this.currentKeyboard.IsKeyDown(key);
        }

        public bool IsKeyUp(Keys key)
        {
            return this.currentKeyboard.IsKeyUp(key);
        }

        public bool IsKeyPress(Keys key)
        {
            return this.currentKeyboard.IsKeyUp(key)
                && this.previousKeyboard.IsKeyDown(key);
        }

    }
}
