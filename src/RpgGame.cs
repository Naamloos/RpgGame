using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RpgGame.Engine;
using System;

namespace RpgGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new RpgGame())
                game.Run();
        }
    }

    public class RpgGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Animation testanim;

        public RpgGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            testanim = new Animation(100, 100, TimeSpan.FromSeconds(1), spriteBatch);
            testanim.AddFrame(Content.Load<Texture2D>("testanim1"));
            testanim.AddFrame(Content.Load<Texture2D>("testanim2"));
            testanim.FinalizeAnimation();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);

            testanim.Update();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);

            spriteBatch.Begin();
            testanim.Draw(10, 10);
            spriteBatch.End();
        }
    }
}
