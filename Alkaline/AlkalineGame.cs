﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Alkaline
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class AlkalineGame : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private readonly InputManager input;
        private SpriteBatch spriteBatch;
        private Texture2D pixel;
        private Player player;

        private Sprite[] blocks;

        public AlkalineGame()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.input = new InputManager();
            this.Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            this.pixel = new Texture2D(GraphicsDevice, 1, 1);
            this.pixel.SetData(new Color[] { Color.White });
            createPlayer();
            createBlocks();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            this.input.Update(gameTime);

            if (this.input.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            this.player.Update(gameTime);

            Rectangle playerCollision = this.player.Sprite.Collision;
            foreach (Sprite block in this.blocks)
            {
                block.Color = playerCollision.Intersects(block.Collision) ? Color.Crimson : Color.SlateBlue;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);

            foreach (Sprite block in this.blocks)
            {
                block.Draw(spriteBatch);
            }

            this.player.Draw(spriteBatch);

            this.spriteBatch.End();

            base.Draw(gameTime);
        }

        private void createPlayer()
        {
            Vector2 size = new Vector2(20f, 20f);
            Viewport viewport = GraphicsDevice.Viewport;
            Vector2 position = new Vector2(viewport.Width / 2, viewport.Height / 2);
            Sprite sprite = new Sprite(this.pixel, size) { Position = position };
            this.player = new Player(sprite, this.input, viewport) { Speed = 0.15f };
        }

        private void createBlocks()
        {
            float size = 75f;
            this.blocks = new Sprite[4];
            for(int i = 0; i < this.blocks.Length; i++)
            {
                Sprite sprite = new Sprite(this.pixel, new Vector2(size, size))
                {
                    Position = new Vector2(2 * size * (i + 1), size),
                    Color = Color.SlateGray
                };
                this.blocks[i] = sprite;
            }
        }

    }
}
