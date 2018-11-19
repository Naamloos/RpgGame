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
        SpriteBatch spriteBatch;
        ModManager mods;
        Animation testanim;
        Drawer drawer;

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
            spriteBatch = new SpriteBatch(GraphicsDevice);
            drawer = new Drawer(spriteBatch);
            mods.LoadModAssemblies();
            testanim = new Animation(74, 86, TimeSpan.FromMilliseconds(1000), drawer, DrawLayer.Entities);

            var sheet = Content.Load<Texture2D>("testsh");
            for(int i = 0; i < 27; i++)
            {
                testanim.AddFrame(new Sprite(sheet, 74, 86, drawer, DrawLayer.Entities, 74, 86, i));
            }

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
            // Drawing Sprites or Animations sends them to the Drawer's queue
            testanim.Draw(10, 10);

            // Drawer will draw all queued items on their respective layers
            drawer.DrawAll(spriteBatch);
            spriteBatch.End();
        }
    }
}
