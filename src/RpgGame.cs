using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RpgGame.Engine;
using RpgGame.GameData;
using RpgGame.GameData.Entities;
using RpgGame.Modding;
using System;
using System.Collections.Generic;

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
        RenderTarget2D rendertarget;
        GraphicsDeviceManager graphics;
        SpriteBatch spritebatch;
        ModManager mods;
        Drawer drawer;
        InputManager input;
        MapManager maps;

        public RpgGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 450;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spritebatch = new SpriteBatch(GraphicsDevice);
            rendertarget = new RenderTarget2D(GraphicsDevice, 320, 180);
            drawer = new Drawer(spritebatch);
            input = new InputManager();
            maps = new MapManager();
            mods = new ModManager();
            maps.LoadMaps();
            mods.LoadModAssemblies();

            List<IDrawableItem> draws = new List<IDrawableItem>();

            var an = new Animation(0, 0, TimeSpan.FromMilliseconds(200), drawer, DrawLayer.Entities);
            var spr = Content.Load<Texture2D>("testplayer");
            for (int i = 0; i < 2; i++)
            {
                an.AddFrame(new Sprite(spr, 32, 32, drawer, DrawLayer.Entities, 32, 32, i));
            }

            draws.Add(an);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            p.Update(input);

            input.Update(Keyboard.GetState(), GamePad.GetState(PlayerIndex.One));
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            spritebatch.GraphicsDevice.SetRenderTarget(rendertarget);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spritebatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied, SamplerState.PointWrap,
                DepthStencilState.None, RasterizerState.CullCounterClockwise, null, null);
            // Drawing Sprites or Animations sends them to the Drawer's queue

            // Drawer will draw all queued items on their respective layers
            drawer.DrawAll(spritebatch);
            spritebatch.End();
            spritebatch.GraphicsDevice.SetRenderTarget(null);
            spritebatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied, SamplerState.PointWrap,
                DepthStencilState.None, RasterizerState.CullCounterClockwise, null, null);
            spritebatch.Draw(rendertarget, new Rectangle(0, 0,
                graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spritebatch.End();
        }
    }
}
