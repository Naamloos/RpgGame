using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RpgGame.Engine;
using RpgGame.Modding;
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
        SpriteBatch spritebatch;
        ModManager mods;
        Drawer drawer;
        InputManager input;

        public RpgGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            mods = new ModManager();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spritebatch = new SpriteBatch(GraphicsDevice);
            drawer = new Drawer(spritebatch);
            input = new InputManager();
            mods.LoadModAssemblies();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            input.Update(Keyboard.GetState(), GamePad.GetState(PlayerIndex.One));
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);

            spritebatch.Begin();
            // Drawing Sprites or Animations sends them to the Drawer's queue

            // Drawer will draw all queued items on their respective layers
            drawer.DrawAll(spritebatch);
            spritebatch.End();
        }
    }
}
